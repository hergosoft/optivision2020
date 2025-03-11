Imports MySql.Data.MySqlClient
Public Class muestra_vendedor
    Public dedonde As String
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub muestra_vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub
    Private Sub muestra_vendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With dtv_vendedores
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
            .RowsDefaultCellStyle.ForeColor = Color.Black
        End With
        'cargo algunos productos al iniciar la ventana 
        Try
            consulta = "select id_codigo,nombre from vendedores where id_agencia='" & dashboard.no_agencia & "' and status='A'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            dtv_vendedores.DataSource = tabladatos
            dtv_vendedores.Columns(0).HeaderText = "CODIGO"
            dtv_vendedores.Columns(0).Width = 88
            dtv_vendedores.Columns(1).HeaderText = "NOMBRE"
            dtv_vendedores.Columns(1).Width = 446
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el catalogo de vendedores," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub

    Private Sub dtv_vendedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_vendedores.CellContentClick

    End Sub

    Private Sub dtv_vendedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_vendedores.CellDoubleClick
        Dim row As DataGridViewRow = dtv_vendedores.CurrentRow
        'verifico de donde estoy llamando a la ventana 
        'desde facturacion
        If dedonde = 1 Then
            facturacion_directa.id_vendedor = CStr(row.Cells(0).Value)
            facturacion_directa.txt_vendedor.Text = CStr(row.Cells(1).Value)
            If facturacion_directa.dedonde = 51 Then
                'si es factura contable llevo el foco al corrreo 
                facturacion_directa.correo.Focus()
            ElseIf facturacion_directa.dedonde = 52 Then
                'si es nota de entrega llevo el foco para que escriban el nombre del paciente para las notas de entrega 
                facturacion_directa.nombre.Focus()
            End If
            Me.Close()
                'desde orden laboratorio
            ElseIf dedonde = 2 Then
                receta.id_vendedor = CStr(row.Cells(0).Value)
                receta.txt_vendedor.Text = CStr(row.Cells(1).Value)
                receta.cod_lente_od.Focus()
                Me.Dispose()
                'desde orden
            ElseIf dedonde = 3 Then
                'agrego el vendedor a la ventana de recibos 
                recibos_nuevo.id_vendedor = CStr(row.Cells(0).Value)
            recibos_nuevo.txt_vendedor.Text = CStr(row.Cells(1).Value)
            Me.Dispose()
        End If
    End Sub

    Private Sub dtv_vendedores_KeyDown(sender As Object, e As KeyEventArgs) Handles dtv_vendedores.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim row As DataGridViewRow = dtv_vendedores.CurrentRow
            'verifico de donde estoy llamando a la ventana 
            'desde facturacion
            If dedonde = 1 Then
                facturacion_directa.id_vendedor = CStr(row.Cells(0).Value)
                facturacion_directa.txt_vendedor.Text = CStr(row.Cells(1).Value)
                facturacion_directa.correo.Focus()
                Me.Close()
                'desde recibo
            ElseIf dedonde = 2 Then
                receta.id_vendedor = CStr(row.Cells(0).Value)
                receta.txt_vendedor.Text = CStr(row.Cells(1).Value)
                receta.cod_lente_od.Focus()
                Me.Dispose()
                'desde orden
            ElseIf dedonde = 3 Then
                'agrego el vendedor a la ventana de recibos 
                recibos_nuevo.id_vendedor = CStr(row.Cells(0).Value)
                recibos_nuevo.txt_vendedor.Text = CStr(row.Cells(1).Value)
                Me.Dispose()
            End If
            'tu codigo

            e.SuppressKeyPress = True

        End If
    End Sub

    Private Sub dtv_vendedores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtv_vendedores.KeyPress
       
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dtv_vendedores_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles dtv_vendedores.CellContextMenuStripNeeded

    End Sub
End Class