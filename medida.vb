
Public Class medida

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        formato_documentos.dtv_medidas.Item(2, formato_documentos.dtv_medidas.CurrentRow.Index).Value = linea.Text
        formato_documentos.dtv_medidas.Item(3, formato_documentos.dtv_medidas.CurrentRow.Index).Value = columna.Text
        Me.Close()
    End Sub

    Private Sub medida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        linea.Select()
        linea.Focus()
    End Sub

    Private Sub linea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles linea.KeyPress
        If Asc(e.KeyChar) = 13 Then
            columna.Focus()
            Dim val As Decimal = 0
            If Decimal.TryParse(linea.Text, val) Then
                linea.Text=val.ToString("N2")
            End If
        End If
    End Sub

    Private Sub linea_TextChanged(sender As Object, e As EventArgs) Handles linea.TextChanged

    End Sub

    Private Sub columna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles columna.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
            Dim val As Decimal = 0
            If Decimal.TryParse(columna.Text, val) Then
                columna.Text = val.ToString("N2")
            End If
        End If
    End Sub

    Private Sub columna_TextChanged(sender As Object, e As EventArgs) Handles columna.TextChanged

    End Sub
End Class