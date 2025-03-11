Imports MySql.Data.MySqlClient

Public Class formato_medidas

    Public campo, documento As String
    Dim consulta As String
    Dim com As MySqlCommand


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'realizo la grabacion de las coordenadas de impresion seleccionadas
            conexion.Open()
            consulta = "UPDATE visformatos set linea='" & linea.Text & "',columna='" & columna.Text & "' where id_agencia='" & dashboard.no_agencia & "' and formato='" & documento & "' and correla='" & campo & "'"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            MessageBox.Show("Actualizado con exito")
            conexion.Close()
            formato_documentos.dtv_medidas.Item(2, formato_documentos.dtv_medidas.CurrentRow.Index).Value = linea.Text
            formato_documentos.dtv_medidas.Item(3, formato_documentos.dtv_medidas.CurrentRow.Index).Value = columna.Text
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return
        End Try
      
    End Sub

    Private Sub columna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles columna.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button2.Focus()
            Dim val As Decimal = 0
            If Decimal.TryParse(columna.Text, val) Then
                columna.Text = val.ToString("N2")
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles columna.TextChanged

    End Sub

    Private Sub formato_medidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        linea.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub linea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles linea.KeyPress
        If Asc(e.KeyChar) = 13 Then
            columna.Focus()
            Dim val As Decimal = 0
            If Decimal.TryParse(linea.Text, val) Then
                linea.Text = val.ToString("N2")
            End If
        End If
    End Sub

    Private Sub linea_TextChanged(sender As Object, e As EventArgs) Handles linea.TextChanged

    End Sub
End Class