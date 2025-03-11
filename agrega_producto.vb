Imports MySql.Data.MySqlClient
Public Class agrega_producto
    Public dedonde As String
    Dim consulta, Exis As String
    Dim adapatador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader

    Private Sub agrega_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Dispose()
        End If
    End Sub
    Private Sub agrega_producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 9)
        End With
        'valido de donde estoy llamando a la ventana para buscar solo determinados productos 
        If dedonde = 3 Then
            'abo ventana desde orden de laboratorio campo aro, busco solo aros 
            Try
                conexion.Open()
                consulta = "select id_codigo, producto,servicio from inventario where linea<='2' limit 10"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).Visible = False
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MessageBox.Show("No pude obtener el listado de productos, Contacta a Soporte Tecnico")
                conexion.Close()
            End Try
        ElseIf dedonde = 4 Then
            'abro desde buscar lente ojo derecho receta, solo muestro lentes
            Try
                conexion.Open()
                consulta = "select id_codigo,producto,precio1,linea,servicio  from inventario  where linea='5'  and status='A' order by producto limit 50 "
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "PRECIO"
                DataGridView1.Columns(2).Width = 85
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
            End Try
        ElseIf dedonde = 5 Then
            'abro desde buscar lente ojo izquierdo receta, solo muestro lentes
            Try
                conexion.Open()
                consulta = "select id_codigo,producto,precio1,linea,servicio  from inventario  where linea='5'  and status='A' order by producto limit 50 "
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "PRECIO"
                DataGridView1.Columns(2).Width = 85
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
            End Try
        ElseIf dedonde = 1 Then
            'busco productos por descripcion desde orden de trabajo
            Try
                conexion.Open()
                ' consulta = "select id_codigo, producto, id_marca, precio1,linea,servicio,costo1 from inventario where status='A' and linea<>'' and '5' order by linea limit 100;"
                consulta = "select i.id_codigo, i.producto, i.id_marca, i.precio1,i.linea,i.servicio,i.costo1,(SUM(k.entrada) - SUM(k.salida)) AS existencia   from inventario as i inner join kardexinven as k on k.id_codigo=i.id_codigo where i.status='A' and i.linea<>'' and '5'  and id_agencia='" & dashboard.no_agencia & "' group by i.id_codigo  order by i.linea limit 50 ;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 425
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).HeaderText = "PRECIO"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).HeaderText = "EXIS"
                DataGridView1.Columns(7).Width = 60
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show("No pude obtener el listado de productos, Contacta a Soporte Tecnico")
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            'abro desde buscar producto en movimientos de kardex, valido para solo mostrar productos inventariables 
            Try
                conexion.Open()
                consulta = "select id_codigo, producto, id_marca, precio1,linea,servicio,costo1 from inventario where status='A' and linea<>'' and servicio='N' order by id_codigo desc limit 50;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 350
                DataGridView1.Columns(2).HeaderText = "MARCA"
                DataGridView1.Columns(2).Width = 135
                DataGridView1.Columns(3).HeaderText = "PRECIO"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show("No pude obtener el listado de productos, Contacta a Soporte Tecnico")
                conexion.Close()
            End Try
        ElseIf dedonde = 6 Then
            'consulto tipo de movimiento de kardex 
            Try
                conexion.Open()
                consulta = "select *"
            Catch ex As Exception

            End Try
        End If
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dedonde = 6 Then
            'abro desde consulta tipo de movimiento de kardex 
            Me.Close()
        Else
            'abro desde cualquier ventana de agrega producto 
            Me.Dispose()
        End If

        'Me.Dispose()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseMove

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' realizo la busquedad por descripcion y por letra ingresada 
        For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next
        If dedonde = 3 Then
            'realizo la busquedad solo de aros oftalmicos y de sol 
            Try
                consulta = "SELECT id_codigo, producto,servicio FROM inventario WHERE producto like '%" & TextBox1.Text & "%' and linea<='2'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).Visible = False
                conexion.Close()
                DataGridView1.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MessageBox.Show("No puede obtener el catalogo de productos, Contacta a Soporte Tecnico")
                conexion.Close()
            End Try
        ElseIf dedonde = 4 Then
            'busco lente por descripcion, lente de ojo derecho receta
            Try
                conexion.Open()
                consulta = "select id_codigo,producto,precio1,linea,servicio from inventario where producto like '%" & TextBox1.Text & "%' and linea='5' and status='A'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "PRECIO"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
            End Try
        ElseIf dedonde = 1 Then
            'busco productos para orden de trabajo, busco todos excepto lentes
            Try
                conexion.Open()
                consulta = "select id_codigo, producto, id_marca, precio1,linea,servicio,costo1 from inventario where producto like '%" & TextBox1.Text & "%'and status='A' and linea<>'5'  "
                ' consulta = "select i.id_codigo, i.producto, i.id_marca, i.precio1,i.linea,i.servicio,i.costo1,(SUM(k.entrada) - SUM(k.salida)) AS existencia   from inventario as i inner join kardexinven as k on k.id_codigo=i.id_codigo where i.producto like '%" & TextBox1.Text & "%' and i.status='A'  and id_agencia='" & dashboard.no_agencia & "';"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 485
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).HeaderText = "PRECIO"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                ' DataGridView1.Columns(7).HeaderText = "EXIS"
                ' DataGridView1.Columns(7).Width = 60
                ' DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                conexion.Close()
                conexion.Close()
            Catch ex As Exception
                'MessageBox.Show(ex.ToString)
                MessageBox.Show("El producto que buscas no tiene existencia o esta desactivado, por favor verifica")
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            'busco desde carga producto a movimientos/traslados todo excepto servicios y lentes 
            Try
                conexion.Open()
                consulta = "select id_codigo, producto, id_marca, precio1,linea,servicio,costo1 from inventario where producto like '%" & TextBox1.Text & "%' and  status='A' and linea<>'' and servicio='N' ;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 350
                DataGridView1.Columns(2).HeaderText = "MARCA"
                DataGridView1.Columns(2).Width = 135
                DataGridView1.Columns(3).HeaderText = "PRECIO"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MessageBox.Show("No puede obtener el catalogo de productos, Contacta a Soporte Tecnico")
                conexion.Close()
            End Try
        End If
        TextBox1.Focus()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        If dedonde = 1 Then
            'al dar doble clic a la selda copio la fila completa a mi ventana de carga producto 
            carga_producto.codigo.Text = CStr(row.Cells(0).Value)
            carga_producto.descripcion.Text = CStr(row.Cells(1).Value)
            carga_producto.precioventa = CStr(row.Cells(3).Value)
            carga_producto.precioa.Text = CStr(row.Cells(3).Value)
            carga_producto.linea = CStr(row.Cells(4).Value)
            carga_producto.marca_aro1 = CStr(row.Cells(2).Value)
            carga_producto.Tipo = CStr(row.Cells(5).Value)
            carga_producto.PrecioCosto = CStr(row.Cells(6).Value)
            carga_producto.cantidad.Enabled = True
            carga_producto.Button1.Enabled = True
            carga_producto.cantidad.Select()
        ElseIf dedonde = 2 Then
            ' MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"))
            'agrega producto dsde ventana de movimientos/traslados
            carga_producto_1.codigo.Text = CStr(row.Cells(0).Value)
            carga_producto_1.descripcion.Text = CStr(row.Cells(1).Value)
            carga_producto_1.marca = CStr(row.Cells(2).Value)
            Try
                conexion.Open()
                consulta = "SELECT i.id_codigo,SUM(IF(k.id_agencia='" & dashboard.no_agencia & "',entrada-salida,0)) AS Agencia1
                            FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                            left outer join catagencias as a on k.id_agencia=a.id_agencia
                            WHERE fecha <= '" & DateTime.Now.ToString("yyyy-MM-dd") & "' and  i.id_codigo='" & CStr(row.Cells(0).Value) & "'
                            GROUP BY i.id_marca ORDER BY i.id_marca;"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                Exis = rs(1)
                conexion.Close()
                ' MessageBox.Show(Exis)
            Catch ex As Exception
                conexion.Close()
            End Try
            carga_producto_1.disponible.Text = Exis
            carga_producto_1.cantidad.Enabled = True
            carga_producto_1.Button1.Enabled = True
            carga_producto_1.cantidad.Select()
        ElseIf dedonde = 3 Then
            'cargo la descripcion a la ventana de orden laboratorio
            receta.aro.Text = CStr(row.Cells(1).Value)
        ElseIf dedonde = 4 Then
            'agrego el lente seleccionado al campo lente ojo derecho de la orden de trabajo 
            receta.cod_lente_od.Text = CStr(row.Cells(0).Value)
            receta.od_descplente.Text = CStr(row.Cells(1).Value)
            receta.od_subtotal.Text = CStr(row.Cells(2).Value)
            receta.TipoProductoOD = CStr(row.Cells(4).Value)
        ElseIf dedonde = 5 Then
            'agrego el lente seleccionado al campo lente de ojo izquierdo de la orden de trabajo 
            'agrego el lente seleccionado al campo lente ojo derecho de la orden de trabajo 
            receta.cod_lente_oi.Text = CStr(row.Cells(0).Value)
            receta.oi_descplente.Text = CStr(row.Cells(1).Value)
            receta.oi_subtotal.Text = CStr(row.Cells(2).Value)
            receta.TipoProductoOI = CStr(row.Cells(4).Value)
        End If
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If dedonde = 1 Then

            ElseIf dedonde = 2 Then
                'al dar Enter a la celda copio la fila completa a mi ventana de carga producto 
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                carga_producto_1.codigo.Text = CStr(row.Cells(0).Value)
                carga_producto_1.descripcion.Text = CStr(row.Cells(1).Value)
                carga_producto_1.marca = CStr(row.Cells(2).Value)
                carga_producto_1.MdiParent = dashboard
                carga_producto_1.Show()
                carga_producto_1.cantidad.Enabled = True
                carga_producto_1.Button1.Enabled = True
                carga_producto_1.cantidad.Focus()
            ElseIf dedonde = 3 Then
                'cargo la descripcion a la ventana de orden laboratorio
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                receta.aro.Text = CStr(row.Cells(1).Value)
            End If

            Me.Dispose()
        End If
    End Sub
End Class