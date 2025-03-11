Imports MySql.Data.MySqlClient
Public Class parametro_cuenta_bancaria
    Dim consulta, pregunta As String
    Dim com As MySqlCommand
    Public dedonde, id_banco As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub parametro_cuenta_bancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        estado.SelectedIndex = 0
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cuenta_cont.KeyPress
        'abro ventana para seleccionar cuenta contable 
        If Asc(e.KeyChar) = 13 Then
            If Me.cuenta_cont.Text = "" Then
                selecciona_cuenta.ShowDialog()
                Button2.Focus()
            Else
                Button2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles cuenta_cont.TextChanged

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
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cuenta_cont.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dedonde = 1 Then
            'grabo nuevo registro
            'realizo la grabacion
            Try
                conexion.Open()
                consulta = "INSERT INTO cuentasbancarias  (nombre,cuenta_bancaria,cuenta_contable,moneda,simbolo,hechopor) values ('" & TextBox2.Text & "','" & TextBox1.Text & "','" & cuenta_cont.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "','" & dashboard.usuario.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                'pregunto si deseo grabar otra cuenta
                pregunta = MsgBox("Cuenta bancaria creada con exito." & vbCrLf & "¿Desea crear otra?", vbYesNo + vbInformation + vbDefaultButton2, "Cuenta Nueva.")
                If pregunta = vbYes Then
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    cuenta_cont.Clear()
                    TextBox1.Focus()
                    mantenimiento_ctas_bancarias.Button1.PerformClick()
                Else
                    mantenimiento_ctas_bancarias.Button1.PerformClick()
                    Me.Dispose()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        ElseIf dedonde = 2 Then
            'actualizo registro
            Try
                conexion.Open()
                consulta = "UPDATE cuentasbancarias SET nombre='" & TextBox2.Text & "',cuenta_bancaria='" & TextBox1.Text & "',cuenta_contable='" & cuenta_cont.Text & "', moneda='" & TextBox4.Text & "', simbolo='" & TextBox3.Text & "', hechopor='" & dashboard.usuario.Text & "' where id_banco='" & id_banco & "' "
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Cuenta bancaria actualizada con Exito!")
                conexion.Close()
                mantenimiento_ctas_bancarias.Button1.PerformClick()
                Me.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
        End If
    End Sub
End Class