Imports MySql.Data.MySqlClient
Public Class formato_documentos
    Public dedonde, consulta As String
    Dim tabla_medidas As DataTable
    Dim adaptador As MySqlDataAdapter
    Dim com As MySqlCommand


    Private Sub cerrar_Click(sender As Object, e As EventArgs) Handles cerrar.Click
        Me.Close()
    End Sub

    Private Sub formato_documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With dtv_medidas
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 11)
        End With
        If dedonde = 1 Then
            'llamo desde formato factura 
            consulta = "SELECT correla,campo,linea,columna FROM visformatos where  id_agencia='" & dashboard.no_agencia & "' and FORMATO='factura'"
            formato_medidas.documento = "factura"
        ElseIf dedonde = 2 Then
            'llamo al formato de recibos 
            consulta = "SELECT correla,campo,linea,columna FROM visformatos where  id_agencia='" & dashboard.no_agencia & "' and FORMATO='recibo'"
            formato_medidas.documento = "recibo"
        ElseIf dedonde = 3 Then
            'llamo al formato de orden de laboratorio
            consulta = "SELECT correla,campo,linea,columna FROM visformatos where  id_agencia='" & dashboard.no_agencia & "' and FORMATO='orden_trab'"
            formato_medidas.documento = "orden_trab"
        ElseIf dedonde = 4 Then
            'llamo al formato de historias clinicas 
            consulta = "SELECT correla,campo,linea,columna FROM visformatos where  id_agencia='" & dashboard.no_agencia & "' and FORMATO='historia_c'"
            formato_medidas.documento = "historia_c"
        End If
        adaptador = New MySqlDataAdapter(consulta, conexion)
        tabla_medidas = New DataTable
        adaptador.Fill(tabla_medidas)
        dtv_medidas.DataSource = tabla_medidas
        dtv_medidas.Columns(0).Visible = False
        dtv_medidas.Columns(1).HeaderText = "CAMPO"
        dtv_medidas.Columns(1).Width = 228
        dtv_medidas.Columns(2).HeaderText = "HORIZONTAL"
        dtv_medidas.Columns(2).Width = 150
        dtv_medidas.Columns(3).HeaderText = "VERTICAL"
        dtv_medidas.Columns(3).Width = 150
        dtv_medidas.Columns(2).DefaultCellStyle.Format = "f"
        dtv_medidas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        dtv_medidas.Columns(3).DefaultCellStyle.Format = "f"
        dtv_medidas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        conexion.Close()
    End Sub

    Private Sub dtv_medidas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_medidas.CellContentClick


    End Sub

    Private Sub dtv_medidas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_medidas.CellDoubleClick
        Dim row As DataGridViewRow = dtv_medidas.CurrentRow
        formato_medidas.linea.Text = CStr(row.Cells(2).Value)
        formato_medidas.columna.Text = CStr(row.Cells(3).Value)
        formato_medidas.campo = CStr(row.Cells(0).Value)
        formato_medidas.ShowDialog()

    End Sub

    Private Sub dtv_medidas_KeyDown(sender As Object, e As KeyEventArgs) Handles dtv_medidas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            Dim row As DataGridViewRow = dtv_medidas.CurrentRow
            formato_medidas.linea.Text = CStr(row.Cells(2).Value)
            formato_medidas.columna.Text = CStr(row.Cells(3).Value)
            formato_medidas.campo = CStr(row.Cells(0).Value)
            formato_medidas.ShowDialog()


        End If
    End Sub
    Private Sub guardar_Click(sender As Object, e As EventArgs)

    End Sub
End Class