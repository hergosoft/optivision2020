Imports MySql.Data.MySqlClient
Public Class muestra_agencia

    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Private Sub muestra_agencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With dtv_agencia
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
            .RowsDefaultCellStyle.ForeColor = Color.Black
        End With
        'realizo la busquedad de las agencias 
        Try
            conexion.Open()
            consulta = "select id_agencia,nombre from catagencias"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            dtv_agencia.DataSource = tabladatos
            dtv_agencia.Columns(0).HeaderText = "CODIGO"
            dtv_agencia.Columns(0).Width = 88
            dtv_agencia.Columns(1).HeaderText = "NOMBRE"
            dtv_agencia.Columns(1).Width = 350
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show("No pude obtener el listado de agencias, Contacta a Soporte Tecnico")
        End Try
    End Sub
    Private Sub dtv_agencia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_agencia.CellContentClick

    End Sub
    Private Sub dtv_agencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_agencia.CellDoubleClick
        Dim row As DataGridViewRow = dtv_agencia.CurrentRow
        cambia_agencia.agencia_id.Text = CStr(row.Cells(0).Value)
        cambia_agencia.agencia.Text = CStr(row.Cells(1).Value)
        cambia_agencia.Button1.Focus()
        Me.Dispose()
    End Sub
End Class