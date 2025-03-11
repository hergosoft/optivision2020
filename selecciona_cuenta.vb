Imports MySql.Data.MySqlClient

Public Class selecciona_cuenta
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable


    Private Sub selecciona_cuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 9)
        End With
        'cargo algunas cuentas contables a la vista de la ventana 
        Try
            consulta = "select no_cuenta,descrip from catcuentasconta  limit 20"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "No. CUENTA"
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
            DataGridView1.Columns(1).Width = 400
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de productos, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        TextBox1.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        parametro_cuenta_bancaria.cuenta_cont.Text = CStr(row.Cells(0).Value)
        Me.Dispose()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = Nothing
        'realizo la busquedad segun datos ingresados 
        Try
            consulta = "select no_cuenta,descrip from catcuentasconta where descrip like '%%" & TextBox1.Text & "%%'  limit 20"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "No. CUENTA"
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).HeaderText = "DESCRIPCION"
            DataGridView1.Columns(1).Width = 400
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de productos, si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        TextBox1.Focus()
    End Sub
End Class