Imports MySql.Data.MySqlClient
Public Class carga_producto
    Public precioventa, subtotal1, dedonde, PrecioCosto As Decimal
    Public linea, marca_aro1, Tipo As String
    Dim consulta, totla2, total3, descuentosinf, existencia As String
    Dim PrecioUnitarioTotal, PrecioSinIva, Tiva As Double
    Dim rs As MySqlDataReader
    Dim adaptador As MySqlDataAdapter
    Dim com As New MySqlCommand
    Dim tabladatos As DataTable
    Dim total As Double = 0
    Dim subtotal2 As Double = 0
    Dim subtotal3 As Double = 0
    Dim entrada, salida As Integer



    Private Sub carga_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub
    'limito para que no utilicen la tecla de tabulador
    Protected Overrides Function ProcessDialogKey(
ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData <> Keys.Tab Then
            Return MyBase.ProcessDialogKey(keyData)
        End If

    End Function

    Private Sub carga_producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        descuento.Text = 0
        descuento.Text = Format(CType(descuento.Text, Decimal), "#,##0.00")
        precioa.Text = 0
        precioa.Text = Format(CType(precioa.Text, Decimal), "#,##0.00")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'valido el tipo de producto
        If Tipo = "N" Then
            Tipo = "B"
        ElseIf Tipo = "S" Then
        End If
        'realizo la conversion de IVA 
        PrecioSinIva = Val(subtotal1) / 1.12
        PrecioSinIva = FormatNumber(PrecioSinIva, 2)
        Tiva = Val(PrecioSinIva) * 0.12
        Tiva = FormatNumber(Tiva, 2)
        '  MessageBox.Show(PrecioSinIva)
        ' MessageBox.Show(Tiva)
        If dedonde = 1 Then
            'realizo el proceso para la ventana de facturas
            precioa.Text = Format(CType(precioa.Text, Decimal), "#,##0.00")
            'valido si tiene descuento el cambo descuento para no exportar el 0.00
            facturacion_directa.dtv_facturacion.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text, precioventa, PrecioUnitarioTotal, descuento.Text, subtotal.Text, PrecioCosto)
            facturacion_directa.dtv_facturacionsinf.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text, descuentosinf, precioventa, subtotal1, Tipo, PrecioUnitarioTotal, PrecioSinIva, Tiva, PrecioCosto)
            'realizo la suma de la columna precio del dtv facturacion directa para mostrar en tiempo real lo gastado 
            Dim fila As DataGridViewRow = New DataGridViewRow()
            For Each fila In facturacion_directa.dtv_facturacion.Rows
                total += Convert.ToDouble(fila.Cells("preciounitotal").Value)
                subtotal2 += Convert.ToDouble(fila.Cells("descuentodt").Value)
            Next

            facturacion_directa.TotalImpuesto = 0
            'realizo la sumatoria del total para calcular los impuestos 
            Dim fila1 As DataGridViewRow = New DataGridViewRow()
            For Each fila1 In facturacion_directa.dtv_facturacionsinf.Rows
                facturacion_directa.TotalImpuesto += Convert.ToDouble(fila1.Cells("tivasinf").Value)
            Next
            'doy formato al textbox total de la suma 
            facturacion_directa.TextBox4.Clear()
            subtotal3 = Val(total) - Val(subtotal2)
            facturacion_directa.tdescuento = subtotal2
            facturacion_directa.TextBox4.Text = Convert.ToString(subtotal3)
            facturacion_directa.TextBox5.Text = Convert.ToString(subtotal3)
            facturacion_directa.TextBox4.Text = Format(CType(facturacion_directa.TextBox4.Text, Decimal), "#,##0.00")
            If linea <= 2 Then
                facturacion_directa.aro = descripcion.Text
                facturacion_directa.Marca_aro = marca_aro1
            End If
            'limpio controles 
            total = 0
            subtotal2 = 0
            subtotal3 = 0
            codigo.Enabled = True
            codigo.Clear()
            codigo.Focus()
            descripcion.Clear()
            cantidad.Text = "1"
            cantidad.Enabled = False
            Button1.Enabled = False
            subtotal.Text = "0"
            subtotal1 = 0
            descuento.Text = 0
            precioventa = 0
            precioa.Text = 0
            PrecioCosto = 0
        ElseIf dedonde = 2 Then
            'realizo el proceso desde la ventana orden de laboratorio
            precioa.Text = Format(CType(precioa.Text, Decimal), "#,##0.00")

            'valido que el producto que estoy agragando no exista ya en el detalle de laa orden de trabajo 
            Dim Valor As String
            Valor = codigo.Text
            Dim existe As Boolean = receta.DataGridView1.Rows.Cast(Of DataGridViewRow).Any(Function(x) CStr(x.Cells("Codigo").Value) = Valor)
            If Not existe Then
                'valido si tiene descuento el campo descuento para no exportar el 0.00
                receta.DataGridView1.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text, descuento.Text, precioa.Text, subtotal.Text)
                receta.dtvsinf.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text, descuentosinf, precioventa, subtotal1, Tipo)
                'valido el producto que estoy agregando para copiarlo al campo correspondiente
                If linea = 1 Or linea = 2 Then
                    receta.aro.Text = descripcion.Text
                    receta.marca_aro.Text = marca_aro1
                ElseIf linea = 8 Then
                    receta.tipo_lente.Text = descripcion.Text
                End If
                receta.Calcular()
                total = 0
                subtotal2 = 0
                subtotal3 = 0
                codigo.Enabled = True
                codigo.Clear()
                codigo.Focus()
                descripcion.Clear()
                cantidad.Text = "1"
                cantidad.Enabled = False
                Button1.Enabled = False
                subtotal.Text = "0"
                subtotal1 = 0
                descuento.Text = 0
                precioventa = 0
                precioa.Text = 0
            Else
                MessageBox.Show("Ya has agregado el codigo " & codigo.Text & vbCrLf & vbCrLf & "- Si necesitas descargar mas unidades del mismo codigo, por favor eliminalo del listado dando doble click sobre el  y vuelve a agregarlo con la cantidad corregida", "Codigo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ' receta.Calcular()
                total = 0
                subtotal2 = 0
                subtotal3 = 0
                codigo.Enabled = True
                codigo.Clear()
                codigo.Focus()
                descripcion.Clear()
                cantidad.Text = "1"
                cantidad.Enabled = False
                Button1.Enabled = False
                subtotal.Text = "0"
                subtotal1 = 0
                descuento.Text = 0
                precioventa = 0
                precioa.Text = 0
            End If
        End If
        'MessageBox.Show(facturacion_directa.TotalImpuesto)
    End Sub

    Private Sub codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles codigo.KeyPress
        'al presionar enter 
        If Asc(e.KeyChar) = 13 Then
            'valido si el textbox esta vacio, si esta vacio abro la ventana para buscar producto por descripcion
            If Me.codigo.Text = "" Then
                agrega_producto.dedonde = 1
                agrega_producto.TextBox1.Select()
                agrega_producto.ShowDialog()
            Else
                'si tiene codigo entonces busco el codigo ingresado directo en la base de datos 
                Try
                    conexion.Open()
                    consulta = "select id_codigo, producto, id_marca, precio1,linea,servicio,costo1 from inventario where id_codigo='" & codigo.Text & "' and status='A' and linea<>''  ;"
                    ' consulta = "select i.id_codigo, i.producto, i.id_marca, i.precio1,i.linea,i.servicio,i.costo1,(SUM(k.entrada) - SUM(k.salida)) AS exis from inventario as i inner join kardexinven as k on k.id_codigo=i.id_codigo where i.id_codigo='" & codigo.Text & "' and i.status='A'  and k.id_agencia='" & dashboard.no_agencia & "';"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    codigo.Text = rs(0)
                    descripcion.Text = rs(1)
                    precioventa = rs(3)
                    precioa.Text = rs(3)
                    linea = rs(4)
                    marca_aro1 = rs(2)
                    Tipo = rs(5)
                    PrecioCosto = rs(6)
                    'If IsDBNull(rs(7)) Then
                    '    existencia = 0
                    'Else
                    '    existencia = rs(7)
                    'End If
                    cantidad.Enabled = True
                    Button1.Enabled = True
                    conexion.Close()
                    rs.Close()
                    ' MessageBox.Show(linea)
                    'If linea = 8 Or linea = 5 Or linea = 6 Then
                    '    'son servicios no valido existencia 
                    cantidad.Focus()
                    'Else
                    '    If existencia <= 0 Then
                    '        MessageBox.Show("El producto no tiene existencia, no podras agregarlo a la orden.")
                    '        codigo.Focus()
                    '        codigo.Clear()
                    '        descripcion.Clear()
                    '        precioventa = 0
                    '        precioa.Text = "0"
                    '        linea = 0
                    '        marca_aro1 = ""
                    '        Tipo = ""
                    '        PrecioCosto = 0
                    '        existencia = 0
                    '        cantidad.Enabled = False
                    '        Button1.Enabled = False
                    '    Else
                    '        cantidad.Focus()
                    '    End If
                    'End If
                Catch ex As Exception
                    'si no encuento el codigo muestro mensaje de error 
                    MessageBox.Show("El codigo que ingresaste no existe o esta desactivado." & vbCrLf & vbCrLf & "Tomar encuenta que si es una OT solo puedes agregar 1 aro por orden.")
                    conexion.Close()
                    codigo.Enabled = True
                    codigo.Clear()
                    codigo.Focus()
                    cantidad.Enabled = False
                    Button1.Enabled = False
                    descripcion.Clear()
                    cantidad.Text = "1"
                    precioa.Clear()
                    precioventa = "0.00"
                End Try
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'cierro ventana
        If dedonde = 2 Then
            Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub
    Private Sub cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then

            descuento.Focus()
        End If
    End Sub
    Private Sub descuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles descuento.KeyPress
        'al presionar enter 
        If Asc(e.KeyChar) = 13 Then


            Button1.Focus()
            End If


    End Sub

    Private Sub descripcion_TextChanged(sender As Object, e As EventArgs) Handles descripcion.TextChanged


    End Sub

    Private Sub codigo_TextChanged(sender As Object, e As EventArgs) Handles codigo.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub descuento_TextChanged(sender As Object, e As EventArgs) Handles descuento.TextChanged

    End Sub

    Private Sub cantidad_TextChanged(sender As Object, e As EventArgs) Handles cantidad.TextChanged

    End Sub

    Private Sub cantidad_LostFocus(sender As Object, e As EventArgs) Handles cantidad.LostFocus
        precioa.Text = Val(precioventa) * cantidad.Text
        PrecioUnitarioTotal=precioa.Text
        descuento.ReadOnly = False
    End Sub

    Private Sub descuento_LostFocus(sender As Object, e As EventArgs) Handles descuento.LostFocus
        If descuento.Text = "" Then
            descuento.Text = 0
        ElseIf descuento.Text = " " Then
            descuento.Text = 0
        ElseIf descuento.Text = "." Then
            descuento.Text = 0
        End If
        If Val(descuento.Text) > Val(precioa.Text) Then
            Dim prueba As Integer
            prueba = Val(precioa.Text) - Val(descuento.Text)
            MessageBox.Show("No puedes hacer un descuento mayor al precio del producto, por favor verifica")
            descuento.Text = 0
        Else
            descuentosinf = descuento.Text
            descuento.Text = Format(CType(descuento.Text, Decimal), "#,##0.00")
            subtotal1 = Val(precioa.Text) - Val(descuentosinf)
            subtotal.Text = subtotal1
            subtotal.Text = Format(CType(subtotal.Text, Decimal), "#,##0.00")
            Button1.Enabled = True
        End If
    End Sub
End Class