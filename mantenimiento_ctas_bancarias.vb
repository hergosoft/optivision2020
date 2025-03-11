Imports MySql.Data.MySqlClient
Public Class mantenimiento_ctas_bancarias
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable

    Private Sub titulo_Click(sender As Object, e As EventArgs) Handles titulo.Click

    End Sub

    Private Sub cuentas_bancarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        'Cargo el listado de bancos 
        Try
            conexion.Open()
            consulta = "select id_banco,cuenta_bancaria,nombre,status,moneda,simbolo,cuenta_contable from cuentasbancarias"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            Tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "No"
            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(1).HeaderText = "CUENTA BANCARIA"
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).Width = 343
            DataGridView1.Columns(3).HeaderText = "ESTADO"
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False

            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub nueva_Click(sender As Object, e As EventArgs) Handles nueva.Click
        parametro_cuenta_bancaria.dedonde = 1
        parametro_cuenta_bancaria.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = Nothing
        'Actualizo el listado de bancos 
        Try
            conexion.Open()
            consulta = "select id_banco,cuenta_bancaria,nombre,status,moneda,simbolo,cuenta_contable,id_banco from cuentasbancarias"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            DataGridView1.DataSource = tabladatos
            DataGridView1.Columns(0).HeaderText = "No"
            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(1).HeaderText = "CUENTA BANCARIA"
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).Width = 343
            DataGridView1.Columns(3).HeaderText = "ESTADO"
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(7).Visible = False
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        parametro_cuenta_bancaria.TextBox1.Text = CStr(row.Cells(1).Value)
        parametro_cuenta_bancaria.TextBox2.Text = CStr(row.Cells(2).Value)
        parametro_cuenta_bancaria.TextBox4.Text = CStr(row.Cells(4).Value)
        parametro_cuenta_bancaria.TextBox3.Text = CStr(row.Cells(5).Value)
        parametro_cuenta_bancaria.cuenta_cont.Text = CStr(row.Cells(6).Value)
        parametro_cuenta_bancaria.id_banco = CStr(row.Cells(7).Value)
        parametro_cuenta_bancaria.dedonde = 2
        parametro_cuenta_bancaria.ShowDialog()
    End Sub

End Class