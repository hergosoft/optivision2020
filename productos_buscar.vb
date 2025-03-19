Imports MySql.Data.MySqlClient
Public Class productos_buscar
    Public dedonde, existenage(5, 5), fecha As String
    Dim consulta As String
    Dim adapatador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim tabladatos As DataTable

    Private Sub productos_buscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()

        End If
    End Sub
    Private Sub productos_buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtengo la fecha de hoy 
        fecha = DateTime.Now.ToString("yyy-MM-dd")
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
        End With
        'cargo algunos productos al iniciar la ventana 
        Try
            consulta = "select i.id_codigo, i.producto, i.id_marca, format(i.precio1,2), i.id_medida,l.descripcion from inventario   as i left join  catlineasi as l on i.linea= l.id_linea where i.status='A' order by i.id_codigo desc  limit 150; "
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adapatador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
            DataGridView1.Columns(0).HeaderText = "CODIGO"
            DataGridView1.Columns(0).Width = 88
            DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
            DataGridView1.Columns(1).Width = 480
            DataGridView1.Columns(2).HeaderText = "MARCA"
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(3).HeaderText = "PRECIO-VENTA"
            DataGridView1.Columns(3).Width = 112
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de productos, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        TextBox1.Focus()
        '  MessageBox.Show(fecha)
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'verifico desde donde estoy llamando a la ventana para poder hacer modificaciones
        If dedonde = 1 Then

            'Verifico los detalles del producto al que se le dio doble click para consultar existencia 
            Dim row As DataGridViewRow = DataGridView1.CurrentRow

            '-verifico existencia del producto a consultar 
            Try
                conexion.Open()
                consulta = "SELECT (SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) '1',
                                    SUM(IF(k.id_agencia= 2,entrada-salida,0)) '2',
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) '3',
                                    SUM(IF(k.id_agencia= 4,entrada-salida,0)) '4',
                                    SUM(IF(k.id_agencia= 5,entrada-salida,0)) '5'            
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                            WHERE fecha <= '" & fecha & "' and  i.id_codigo='" & CStr(row.Cells(0).Value) & "'
                            GROUP BY i.id_marca
                            ORDER BY i.id_marca;"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                existenage(0, 0) = rs(0)
                existenage(1, 0) = rs(1)
                existenage(2, 0) = rs(2)
                existenage(3, 0) = rs(3)
                existenage(4, 0) = rs(4)
                existenage(5, 0) = rs(5)
                existenage(0, 1) = "0"
                existenage(1, 1) = "1"
                existenage(2, 1) = "2"
                existenage(3, 1) = "3"
                existenage(4, 1) = "4"
                existenage(5, 1) = "5"
                existenage(0, 2) = "EXISTENCIA GLOBAL"
                existenage(1, 2) = "BODEGA"
                existenage(2, 2) = "MALACATAN"
                existenage(3, 2) = "PLAZA ZONA 4"
                existenage(4, 2) = "GALERIAS PRIMA"
                existenage(5, 2) = "CATARINA"
                ' MessageBox.Show(existenage(0, 1))
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("El producto a consultar no tiene existencia en ninguna de las sucursales. " &
                   vbCrLf & vbCrLf,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                conexion.Close()
                Return
            End Try
            producto_detalle.codigo.Text = CStr(row.Cells(0).Value)
            producto_detalle.descripcion.Text = CStr(row.Cells(1).Value)
            producto_detalle.marca.Text = CStr(row.Cells(2).Value)
            producto_detalle.tipo.Text = CStr(row.Cells(5).Value)
            producto_detalle.presentacion.Text = CStr(row.Cells(4).Value)
            producto_detalle.precio.Text = CStr(row.Cells(3).Value)
            'inserto los datos obtenidos en la ventana de detalle de producto
            producto_detalle.DataGridView1.Rows.Add(existenage(1, 1), existenage(1, 2), existenage(1, 0))
            producto_detalle.DataGridView1.Rows.Add(existenage(2, 1), existenage(2, 2), existenage(2, 0))
            producto_detalle.DataGridView1.Rows.Add(existenage(3, 1), existenage(3, 2), existenage(3, 0))
            producto_detalle.DataGridView1.Rows.Add(existenage(4, 1), existenage(4, 2), existenage(4, 0))
            producto_detalle.DataGridView1.Rows.Add(existenage(5, 1), existenage(5, 2), existenage(5, 0))
            producto_detalle.DataGridView1.Rows.Add(existenage(0, 1), existenage(0, 2), existenage(0, 0))
            'abro ventana para mostrar existencia en todas las sucursales 
            producto_detalle.ShowDialog()



        ElseIf dedonde = 2 Then
            'llamada desde modificar precio producto 
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            productos_nuevo.codigo.Text = CStr(row.Cells(0).Value)
            productos_nuevo.dedonde = 2
            productos_nuevo.Label8.Text = "Modificar Codigos // Productos"
            productos_nuevo.ShowDialog()
        ElseIf dedonde = 3 Then
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            movimientos_kardex.id_codigo = CStr(row.Cells(0).Value)
            movimientos_kardex.descripcion = CStr(row.Cells(1).Value)
            movimientos_kardex.ShowDialog()
        ElseIf dedonde = 4 Then
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            'desactivo producto
            '-Antes de desactivar compruebo que no tenga existencia en ninguna sucursal 
            Try
                conexion.Open()
                consulta = "SELECT i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS existencia_general,
                            SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Agencia1,
                            SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Agencia2,
                            SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS Agencia3,
                            SUM(IF(k.id_agencia= 4,entrada-salida,0)) AS Agencia4,
                            SUM(IF(k.id_agencia= 5,entrada-salida,0)) AS Agencia5
                          
                            FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                            left outer join catagencias as a on k.id_agencia=a.id_agencia
                            WHERE fecha <= '" & fecha & "' and  i.id_codigo='" & CStr(row.Cells(0).Value) & "'
                            GROUP BY i.id_marca
                            ORDER BY i.id_marca;"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                existenage(0, 0) = rs(0)
                existenage(1, 0) = rs(1)
                existenage(2, 0) = rs(2)
                existenage(3, 0) = rs(3)
                existenage(4, 0) = rs(4)
                existenage(5, 0) = rs(5)
                rs.Close()
                conexion.Close()
                'verifico si la existencia global es 0
                If existenage(2, 0) = 0 Then
                    'desactivo codigo
                    Try
                        conexion.Open()
                        consulta = "UPDATE inventario SET status='B' where id_codigo='" & CStr(row.Cells(0).Value) & "' "
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                        MessageBox.Show("Codigo desactivado con exito", "Desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        conexion.Close()
                        Me.Close()
                    Catch ex As Exception
                        MsgBox("No fue posible actualizar el detalle del producto, si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                Else
                    MessageBox.Show("El codigo no se puede desactivar porque tiene existencia o bien valor negativo en las siguientes sucursales" & vbCrLf & vbCrLf &
                                  "Agencia 1: " & existenage(3, 0) & vbCrLf & "Agencia 2: " & existenage(4, 0) & vbCrLf & "Agencia 3: " & existenage(5, 0) & vbCrLf & "TOTAL      : " & existenage(2, 0), "Codigo con existencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If

            Catch ex As Exception
                conexion.Close()
            End Try
            Try
                conexion.Open()
                consulta = "UPDATE inventario SET status='B' where id_codigo='" & CStr(row.Cells(0).Value) & "' "
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Codigo desactivado con exito", "Desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el detalle del producto, si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 5 Then
            'abro desde consulta de kardex movimientos general 
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            movimientos_kardex.titulo.Text = "HISTORIAL MOVIMIENTOS"
            movimientos_kardex.id_codigo = CStr(row.Cells(0).Value)
            movimientos_kardex.descripcion = CStr(row.Cells(1).Value)
            movimientos_kardex.dedonde = 2
            movimientos_kardex.ShowDialog()

        End If

    End Sub


   
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then
            'busco el producto por letra escrita 
            Try
                consulta = "select id_codigo, producto, id_marca, precio1 from inventario where producto like '%" & TextBox1.Text & "%' and status='A'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 88
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "MARCA"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).HeaderText = "PRECIO-VENTA"
                DataGridView1.Columns(3).Width = 112
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener los datos de la agencia, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try
        ElseIf RadioButton1.Checked = True Then
            'busco el producto por letra escrita 
            Try
                consulta = "select id_codigo, producto, id_marca, format(precio1,2) from inventario where id_codigo like '" & TextBox1.Text & "%' and status='A'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 88
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "MARCA"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).HeaderText = "PRECIO-VENTA"
                DataGridView1.Columns(3).Width = 112
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener los datos de la agencia, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try
        ElseIf RadioButton3.Checked = True Then
            'busco el producto por letra escrita 
            Try
                consulta = "select id_codigo, producto, id_marca, format(precio1,2) from inventario where id_marca like '" & TextBox1.Text & "%' and status='A'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 88
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(1).Width = 480
                DataGridView1.Columns(2).HeaderText = "MARCA"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).HeaderText = "PRECIO-VENTA"
                DataGridView1.Columns(3).Width = 112
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener los datos de la agencia, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try

        End If
    End Sub
End Class