Imports MySql.Data.MySqlClient
Public Class traslado_consulta
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Public dedonde As String


    Private Sub traslado_consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtengo el listado de los traslados pendientes de recepcionar
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        'verifico de donde estoy llamando a la ventana
        If dedonde = 1 Then
            'consultra traslados pendientes de rececpcion
            Try
                consulta = "select no_factura, serie, fecha, cliente, obs from consignaciones where status='P' and id_cliente='" & dashboard.no_agencia & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "DOCTO"
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 60
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "CLIENTE"
                DataGridView1.Columns(3).Width = 280
                DataGridView1.Columns(4).Visible = False
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show("No pude obtener el listado de productos, Contacta a Soporte Tecnico")
            End Try
        ElseIf dedonde = 2 Then
            'consulta traslados ya recepcionados
            consulta = "select no_factura, serie, fecha, cliente, obs from consignaciones where status='R' and id_cliente='" & dashboard.no_agencia & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "DOCTO"
            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).HeaderText = "SERIE"
            DataGridView1.Columns(1).Width = 60
            DataGridView1.Columns(2).HeaderText = "FECHA"
            DataGridView1.Columns(2).Width = 90
            DataGridView1.Columns(3).HeaderText = "CLIENTE"
            DataGridView1.Columns(3).Width = 280
            DataGridView1.Columns(4).Visible = False
            conexion.Close()
        End If
       
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'verifico den donde tengo abierta la ventana
        If dedonde = 1 Then
            'ventana desde consignaciones pendientes de recepcion
            'valido que el datagrid no se encuentre vacio 
            If Me.DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No hay traslado seleccionado para recepcionar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            Else
                'abro la ventana de recepcion de traslados 
                traslado.MdiParent = dashboard
                traslado.dedonde = 2
                'copio los datos a la ventana 
                traslado.no_agencia.Text = dashboard.no_agencia
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                traslado.documento.Text = CStr(row.Cells(0).Value)
                traslado.serie = CStr(row.Cells(1).Value)
                traslado.fecha.Text = CStr(row.Cells(2).Value)
                traslado.agencia_recibe.Text = CStr(row.Cells(3).Value)
                traslado.obs.Text = CStr(row.Cells(4).Value)
                traslado.btn_agrega.Visible = False
                traslado.Button3.Visible = False
                traslado.no_agencia.Enabled = False
                traslado.fecha.Enabled = False
                traslado.obs.Enabled = False
                traslado.Label9.Text = "Recibir Traslado"
                traslado.Button4.Text = "Recibir"
                traslado.Show()
                traslado.buscar.PerformClick()
            End If
        ElseIf dedonde = 2 Then
            'ventana desde consulta de consignaciones 
            'valido que el datagrid no se encuentre vacio 
            If Me.DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No hay traslado seleccionado para consultar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            Else
                'abro la ventana de recepcion de traslados 
                traslado.MdiParent = dashboard
                traslado.dedonde = 3
                'copio los datos a la ventana 
                traslado.no_agencia.Text = dashboard.no_agencia
                Dim row As DataGridViewRow = DataGridView1.CurrentRow
                traslado.documento.Text = CStr(row.Cells(0).Value)
                traslado.serie = CStr(row.Cells(1).Value)
                traslado.fecha.Text = CStr(row.Cells(2).Value)
                traslado.agencia_recibe.Text = CStr(row.Cells(3).Value)
                traslado.obs.Text = CStr(row.Cells(4).Value)
                traslado.btn_agrega.Visible = False
                traslado.Button3.Visible = False
                traslado.no_agencia.Enabled = False
                traslado.fecha.Enabled = False
                traslado.obs.Enabled = False
                traslado.Label9.Text = "Consulta Traslado"
                traslado.Button4.Visible = False
                traslado.Show()
                traslado.buscar.PerformClick()
            End If
        End If

       
        

    End Sub

    Private Sub refrescar_Click(sender As Object, e As EventArgs) Handles refrescar.Click
        'actualizo el dtv luego de haber realizado la recepcion o anulacion del documento
        DataGridView1.Columns.Clear()
        'cargo los traslados pendientes de recepcionar 
        Try
            consulta = "select no_factura, serie, fecha, cliente, obs from consignaciones where status='P' and id_cliente='" & dashboard.no_agencia & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "DOCTO"
            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).HeaderText = "SERIE"
            DataGridView1.Columns(1).Width = 60
            DataGridView1.Columns(2).HeaderText = "FECHA"
            DataGridView1.Columns(2).Width = 90
            DataGridView1.Columns(3).HeaderText = "CLIENTE"
            DataGridView1.Columns(3).Width = 280
            DataGridView1.Columns(4).Visible = False
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("No pude obtener el listado de productos, Contacta a Soporte Tecnico")
        End Try

    End Sub
End Class