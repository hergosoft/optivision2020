Imports MySql.Data.MySqlClient

Public Class parametros_ctascontables
    Dim consulta, pregunta, tipo As String
    Dim com As MySqlCommand


    Private Sub parametros_ctascontables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'valido que opcion esta marcada para definir la cuenta contable 
        If RadioButton1.Checked = True Then
            tipo = "A"
        ElseIf RadioButton2.Checked = True Then
            tipo = "D"
        End If
        Try
            'grabo la cuenta contable
            conexion.Open()
            consulta = "INSERT INTO catcuentasconta  (no_cuenta,acde,descrip,hechopor) values ('" & TextBox1.Text & "','" & tipo & "','" & TextBox2.Text & "','" & dashboard.usuario.Text & "')"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            conexion.Close()
            pregunta = MsgBox("Cuenta crada con exito." & vbCrLf & "¿Desea crear otra?", vbYesNo + vbInformation + vbDefaultButton2, "Cuenta Nueva.")
            If pregunta = vbYes Then
                tipo = ""
                TextBox1.Clear()
                TextBox2.Clear()
                RadioButton1.Checked = True
                TextBox1.Focus()
                mantenimiento_nomcontable.Button1.PerformClick()
            Else
                mantenimiento_nomcontable.Button1.PerformClick()
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            RadioButton1.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub
End Class