Imports MySql.Data.MySqlClient
Public Class productos_nuevo
    Public dedonde As String
    Dim consulta, pregunta, temp1(2), tservicio As String
    Dim precio1 As Decimal
    Dim adapatador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim tablalinea, tablamedida, tablamarca, tablatipo As DataTable

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmb_linea.SelectedIndex = 0
        cmb_marca.SelectedIndex = 0
        cmb_medida.SelectedIndex = 0
        cmb_tipo.SelectedIndex = 0
        descripcion.Clear()
        precio.Text = "0.00"
        descripcion.Focus()
        Me.Close()
    End Sub

    Private Sub productos_nuevo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            cmb_linea.SelectedIndex = 0
            cmb_marca.SelectedIndex = 0
            cmb_medida.SelectedIndex = 0
            cmb_tipo.SelectedIndex = 0
            descripcion.Clear()
            precio.Text = "0.00"
            descripcion.Focus()
            Me.Close()
        End If

    End Sub

    Private Sub productos_nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtengo el listado de lineas 
        Try
            conexion.Open()
            consulta = "SELECT * FROM catlineasi"
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tablalinea = New DataTable
            adapatador.Fill(tablalinea)
            cmb_linea.DataSource = tablalinea
            cmb_linea.DisplayMember = "descripcion"
            cmb_linea.ValueMember = "id_linea"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de lineas, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return

        End Try
        'obtengo el listado de unidad de medida 
        Try
            conexion.Open()
            consulta = "select * from catmedidasi"
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tablamedida = New DataTable
            adapatador.Fill(tablamedida)
            cmb_medida.DataSource = tablamedida
            cmb_medida.DisplayMember = "id_linea"
            cmb_medida.ValueMember = "id_linea"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de unidad de medidas, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try

        'obtengo el listado de marcas
        Try
            conexion.Open()
            consulta = "select * from catmarcasi"
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tablamarca = New DataTable
            adapatador.Fill(tablamarca)
            cmb_marca.DataSource = tablamarca
            cmb_marca.ValueMember = "id_linea"
            cmb_marca.DisplayMember = "id_linea"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de marcas, si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try

        'obtengo el listado de tipo
        Try
            conexion.Open()
            consulta = "select * from cattipoi"
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tablatipo = New DataTable
            adapatador.Fill(tablatipo)
            cmb_tipo.DataSource = tablatipo
            cmb_tipo.DisplayMember = "tipo"
            cmb_tipo.ValueMember = "id_tipo"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado tipos de producto, si el error persiste contacta con Soporte Tecnico " &
                       vbCrLf & vbCrLf & ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try

        'valido desde donde estoy llamando a la ventana para poder ver si es modificacion o creacion 
        If dedonde = 1 Then
            'llamada desde nuevo producto  'genero el codigo del producto a seguir
            Try
                conexion.Open()
                consulta = "select id_codigo from inventario where id_codigo=(SELECT MAX(id_codigo) FROM inventario)"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                codigo.Text = rs(0)
                rs.Close()
                conexion.Close()
                codigo.Text = Val(codigo.Text) + 1
            Catch ex As Exception
                MsgBox("No fue posible obtener el codigo para el nuevo producto, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        ElseIf dedonde = 2 Then

            Dim tiposerv As String
            'llamada desde modificar Producto 
            Label8.ForeColor = Color.Red
            'busco el producto en base al codigo que seleccione 
            Try
                conexion.Open()
                consulta = "select producto,precio1,linea,servicio,id_marca,id_medida from inventario where id_codigo='" & codigo.Text & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                descripcion.Text = rs(0)
                precio1 = rs(1)
                cmb_linea.SelectedIndex = rs(2)
                tiposerv = rs(3)
                cmb_marca.SelectedValue = rs(4)
                cmb_medida.SelectedValue = rs(5)
                rs.Close()
                conexion.Close()
                precio.Text = Format(precio1, "##,##0.00")
                Button1.Text = "Actualizar"
                If tiposerv = "N" Then
                    cmb_tipo.SelectedIndex = 0
                Else
                    cmb_tipo.SelectedIndex = 1
                End If
            Catch ex As Exception
                MsgBox("ThenNo fue posible obtener el detalle del producto a editar, si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        precio1 = Format(CDec(precio.Text), "C")
        'valido desde donde estoy llamando la accion 1 nuevo 2 actualizar
        If cmb_tipo.SelectedValue = 1 Then
            tservicio = "N"
        Else
            tservicio = "S"
        End If
        If dedonde = 1 Then
            'obtengo el codigo de nuevo para no duplicar antes de guardar
            Try
                conexion.Open()
                consulta = "select id_codigo from inventario where id_codigo=(SELECT MAX(id_codigo) FROM inventario)"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                codigo.Text = rs(0)
                rs.Close()
                conexion.Close()
                codigo.Text = Val(codigo.Text) + 1
            Catch ex As Exception
                MsgBox("No fue posible generar un codigo interno para el producto, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'Guardo el producto
            Try
                conexion.Open()
                consulta = "INSERT INTO inventario  (id_codigo,producto,linea,existencia,precio1,servicio,status,id_marca,id_medida,id_umedida ) values ('" & codigo.Text & "', '" & descripcion.Text & "', '" & cmb_linea.SelectedValue & "', '1', '" & precio1 & "', '" & tservicio & "', 'A','" & cmb_marca.Text & "', '" & cmb_medida.Text & "','" & cmb_medida.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                pregunta = MsgBox("Codigo " & codigo.Text & "  creado con exito." & vbCrLf & "¿Desea crear otro?", vbYesNo + vbInformation + vbDefaultButton1, "Justificacion.")
                If pregunta = vbYes Then
                    Try
                        conexion.Open()
                        consulta = "select id_codigo from inventario where id_codigo=(SELECT MAX(id_codigo) FROM inventario)"
                        com = New MySqlCommand(consulta, conexion)
                        rs = com.ExecuteReader
                        rs.Read()
                        codigo.Text = rs(0)
                        rs.Close()
                        conexion.Close()
                        codigo.Text = Val(codigo.Text) + 1
                    Catch ex As Exception
                        MessageBox.Show("No pude generar el codigo del producto, Contacta a Soporte Tecnico")
                        conexion.Close()
                    End Try
                    cmb_linea.SelectedIndex = 0
                    cmb_marca.SelectedIndex = 0
                    cmb_medida.SelectedIndex = 0
                    cmb_tipo.SelectedIndex = 0
                    descripcion.Clear()
                    precio.Text = "0.00"
                    descripcion.Focus()
                ElseIf pregunta = vbNo Then
                    Me.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("No pude guardar el producto, Contacta a Soporte Tecnico ")
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            Try
                conexion.Open()
                consulta = "UPDATE inventario SET producto='" & descripcion.Text & "',linea='" & cmb_linea.SelectedValue & "',precio1='" & precio1 & "', servicio='" & tservicio & "', id_marca='" & cmb_marca.Text & "', id_medida='" & cmb_medida.Text & "', id_umedida='" & cmb_medida.Text & "' where id_codigo='" & codigo.Text & "' "
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Registro Guardado con Exito")
                conexion.Close()
                cmb_linea.SelectedIndex = 0
                cmb_marca.SelectedIndex = 0
                cmb_medida.SelectedIndex = 0
                cmb_tipo.SelectedIndex = 0
                descripcion.Clear()
                precio.Text = "0.00"
                descripcion.Focus()
                productos_buscar.Button1.PerformClick()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el detalle del producto, si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If

    End Sub

    Private Sub precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles precio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()

        End If
    End Sub

    Private Sub precio_LostFocus(sender As Object, e As EventArgs) Handles precio.LostFocus
        precio1 = precio.Text
        precio.Text = Format(precio1, "##,##0.00")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles precio.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub descripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles descripcion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'verifico si la descripcion del producto ingresada ya existe
            Try
                conexion.Open()
                consulta = "select id_codigo,producto,precio1 from inventario where producto='" & descripcion.Text & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                temp1(0) = rs(0)
                temp1(1) = rs(1)
                temp1(2) = rs(2)
                rs.Close()
                conexion.Close()
                MsgBox("El producto ingresado ya existe, por favor revisa antes de grabar, codigo interno " & temp1(0) & " con descripcion " & temp1(1) & " precio " & temp1(2), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)

               
                Button1.Enabled = False
            Catch ex As Exception
                 cmb_tipo.Focus()
                conexion.Close()
                Return
            End Try


        End If
    End Sub

    Private Sub descripcion_TextChanged(sender As Object, e As EventArgs) Handles descripcion.TextChanged

    End Sub

    Private Sub cmb_tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_tipo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmb_marca.Focus()
            'MessageBox.Show(cmb_tipo.SelectedValue)
            If cmb_tipo.SelectedValue = 1 Then
                tservicio = "N"
            Else
                tservicio = "S"
            End If
        End If
    End Sub

    Private Sub cmb_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipo.SelectedIndexChanged

    End Sub

    Private Sub cmb_marca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_marca.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmb_linea.Focus()

        End If
    End Sub

    Private Sub cmb_marca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_marca.SelectedIndexChanged

    End Sub

    Private Sub cmb_linea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_linea.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmb_medida.Focus()

        End If
    End Sub

    Private Sub cmb_linea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_linea.SelectedIndexChanged

    End Sub

    Private Sub cmb_medida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_medida.KeyPress
        If Asc(e.KeyChar) = 13 Then
            precio.Focus()

        End If
    End Sub

    Private Sub cmb_medida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_medida.SelectedIndexChanged

    End Sub
End Class