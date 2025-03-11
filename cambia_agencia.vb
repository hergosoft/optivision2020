Imports MySql.Data.MySqlClient
Public Class cambia_agencia
    Dim consulta As String
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub agencia_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles agencia_id.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub agencia_id_LostFocus(sender As Object, e As EventArgs) Handles agencia_id.LostFocus
        'al presionar enter 

        'realizo la busquedad de la agencia por medio del numero 
        Try
                conexion.Open()
                consulta = "SELECT nombre,seriefac,serieord,serierec from catagencias where id_agencia='" & agencia_id.Text & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                agencia.Text = rs(0)
                dashboard.serie_factura = rs(1)
                dashboard.serie_orden = rs(2)
                'dashboard.serie_orden_laboratorio = rs(3)
                dashboard.serie_recibo = rs(3)
                rs.Close()
                conexion.Close()
                Button1.Focus()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show(ex.ToString)
                Return
            End Try

    End Sub


    Private Sub agencia_id_TextChanged(sender As Object, e As EventArgs) Handles agencia_id.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        muestra_agencia.ShowDialog()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dashboard.agencia.Text = agencia.Text
        dashboard.no_agencia = agencia_id.Text
        dashboard.ToolStripButton1.Text = "Agencia: " & agencia_id.Text
        'ejecuto funcion que realiza la busquedad de la direccion de la tienda antes de iniciar a operar 
        dashboard.Info_tienda()
        Me.Close()

    End Sub

    Private Sub cambia_agencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        agencia.Text = dashboard.agencia.Text

    End Sub
End Class