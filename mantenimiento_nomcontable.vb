Imports MySql.Data.MySqlClient
Public Class mantenimiento_nomcontable
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Public dedonde As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub mantenimiento_nomcontable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With

        If dedonde = 1 Then
            'Cargo el listado de cuentas contables 
            Try
                conexion.Open()
                consulta = "select no_cuenta,descrip,acde from catcuentasconta"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "No CUENTA"
                DataGridView1.Columns(0).Width = 180
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                DataGridView1.Columns(1).Width = 343
                DataGridView1.Columns(2).HeaderText = "TIPO"
                DataGridView1.Columns(2).Width = 150
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            'cargo grupo de nomenclatura contable
            Try
                conexion.Open()
                consulta = "select id_cuenta,descripcion,grupo from gruposctasconta"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "No CUENTA"
                DataGridView1.Columns(0).Width = 180
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                DataGridView1.Columns(1).Width = 343
                DataGridView1.Columns(2).HeaderText = "GRUPO"
                DataGridView1.Columns(2).Width = 150
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub nueva_Click(sender As Object, e As EventArgs) Handles nueva.Click
        parametros_ctascontables.ShowDialog()
    End Sub

    Private Sub titulo_Click(sender As Object, e As EventArgs) Handles titulo.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = Nothing
        If dedonde = 1 Then
            'Cargo el listado de cuentas contables 
            Try
                conexion.Open()
                consulta = "select no_cuenta,descrip,acde from catcuentasconta"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "No CUENTA"
                DataGridView1.Columns(0).Width = 180
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                DataGridView1.Columns(1).Width = 343
                DataGridView1.Columns(2).HeaderText = "TIPO"
                DataGridView1.Columns(2).Width = 150
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            'cargo grupo de nomenclatura contable
            Try
                conexion.Open()
                consulta = "select id_cuenta,descripcion,grupo from gruposctasconta"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "No CUENTA"
                DataGridView1.Columns(0).Width = 180
                DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                DataGridView1.Columns(1).Width = 343
                DataGridView1.Columns(2).HeaderText = "GRUPO"
                DataGridView1.Columns(2).Width = 150
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        End If
    End Sub
End Class