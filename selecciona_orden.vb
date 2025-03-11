Imports MySql.Data.MySqlClient
Public Class selecciona_orden
    Dim consulta, seleccionar As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Public dedonde As String


    Private Sub selecciona_orden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        If dedonde = 1 Then
            'ordenes de trabajo para facturar
            Try
                consulta = "select no_docto,serie,status,fecha,telefono,cliente,nit,total from orden where id_agencia='" & dashboard.no_agencia & "' and status='I' and saldo=0 order by no_docto desc limit 50"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN"
                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 65
                DataGridView1.Columns(2).HeaderText = "ESTADO"
                DataGridView1.Columns(2).Width = 54
                DataGridView1.Columns(3).HeaderText = "FECHA"
                DataGridView1.Columns(3).Width = 85
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 77
                DataGridView1.Columns(5).HeaderText = "CLIENTE"
                DataGridView1.Columns(5).Width = 350
                DataGridView1.Columns(6).HeaderText = "NIT"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "TOTAL"
                DataGridView1.Columns(7).Width = 80

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 2 Then
            'OBTENGO LA ORDEN DE TRABAJO PARA FACTURA CONTABLE
            Try
                conexion.Open()
                consulta = "select o.no_orden,o.serie,o.fecha,o.nombre,o.telefono,o.total,o.abono,o.saldo,o.nombre,o.id_vendedor,v.nombre,h.email from orden as o left join vendedores as v on o.id_vendedor=v.id_codigo left join clinica as h on o.no_orden=h.orden and o.id_agencia=h.id_agencia where   o.id_agencia='" & dashboard.no_agencia & "' and o.saldo=0 and o.status<>'A' and o.status<>'F' group by o.no_orden order by o.no_orden desc limit 150; "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN"
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 55
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 96
                DataGridView1.Columns(3).HeaderText = "NOMBRE"
                DataGridView1.Columns(3).Width = 395
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 100
                DataGridView1.Columns(5).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(5).HeaderText = "TOTAL"
                DataGridView1.Columns(5).Width = 78
                DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(6).HeaderText = "ABONO"
                DataGridView1.Columns(6).Width = 78
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "SALDO"
                DataGridView1.Columns(7).Width = 78
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False
                'alineo columnas a la derecha de todas las que contienen valores de moneda 
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                'realizo recorrido de dtv para cambiar color si la orden tiene saldo o no tiene 
                For Each fila As DataGridViewRow In DataGridView1.Rows
                    If fila.Cells(7).Value = 0.00 Then
                        fila.DefaultCellStyle.ForeColor = Color.Green
                    Else
                        fila.DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next


            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        ElseIf dedonde = 3 Then
            'obtengo el listado de ordenes de trabajo pendientes de facturar en promo 2x1
            Try
                consulta = "select o.no_orden,o.serie,o.fecha,o.nombre,o.telefono,o.total,o.abono,o.saldo,v.nombre,o.recibo,o.id_vendedor from orden as o left join vendedores as v on (o.id_vendedor=v.id_codigo) where  o.id_agencia='" & dashboard.no_agencia & "' and o.status='P' order by o.no_orden desc "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN"
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 55
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 85
                DataGridView1.Columns(3).HeaderText = "NOMBRE"
                DataGridView1.Columns(3).Width = 345
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 77
                DataGridView1.Columns(5).HeaderText = "TOTAL"
                DataGridView1.Columns(5).Width = 78
                DataGridView1.Columns(6).HeaderText = "ABONO"
                DataGridView1.Columns(6).Width = 78
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "SALDO"
                DataGridView1.Columns(7).Width = 78
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                MessageBox.Show("Por favor seleccione con doble clic la primera orden de la promo 2x1 a facturar")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If dedonde = 1 Then
            'cargo datos a facturacion de orden
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            'facturacion orden de trabajo 
            facturacion_directa.dedonde = 5
            facturacion_directa.MdiParent = dashboard
            facturacion_directa.Label9.Visible = True
            facturacion_directa.Label9.Text = "Facturacion Orden"
            facturacion_directa.orden = CStr(row.Cells(0).Value)
            facturacion_directa.serie_orden = CStr(row.Cells(1).Value)
            facturacion_directa.Show()
        ElseIf dedonde = 2 Then
            'cargo datos a orden de trabajo 
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            If row.Cells(11).Value.ToString = "" Then
                facturacion_directa.correo.Text = "."
            Else

                facturacion_directa.correo.Text = CStr(row.Cells(11).Value)

            End If
            'facturacion orden de trabajo 
            facturacion_directa.ordenlab = CStr(row.Cells(0).Value)
            facturacion_directa.serieordenlab = CStr(row.Cells(1).Value)
            facturacion_directa.ordtotal = Val(facturacion_directa.ordtotal) + Val(CStr(row.Cells(5).Value).ToString)
            facturacion_directa.ordsaldo = Val(facturacion_directa.ordsaldo) + Val(CStr(row.Cells(7).Value).ToString)
            facturacion_directa.ordabono = Val(facturacion_directa.ordabono) + Val(CStr(row.Cells(6).Value).ToString)
            facturacion_directa.nombre.Text = CStr(row.Cells(3).Value)

            facturacion_directa.TextBox4.Text = CStr(row.Cells(5).Value)
            facturacion_directa.txt_vendedor.Text = CStr(row.Cells(10).Value)
            facturacion_directa.recibo_anterior = CStr(row.Cells(8).Value)
            facturacion_directa.id_vendedor = CStr(row.Cells(9).Value)
            facturacion_directa.Telefonocliente.Text = CStr(row.Cells(4).Value)
            If CStr(row.Cells(7).Value).ToString = "0.00" Then
                facturacion_directa.Button2.Visible = False
                facturacion_directa.Button4.Enabled = True
            Else
                '  MessageBox.Show("Esta orden cuenta con un saldo pediente." & vbCrLf & "Debes realizar un recibo de cancelacion para grabar la factura.", "Saldo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()
        ElseIf dedonde = 3 Then
            'al seleccionar don doble clic la primera vez, buscare el detalle de la orden 


            MessageBox.Show("Por favor seleccione la 2da orden de la promo")
        End If
     
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class