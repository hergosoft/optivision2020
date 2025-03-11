Imports System.IO
Imports MySql.Data.MySqlClient
Public Class login
    Dim nombre, departamento, nivel, usuario, pass, id_agencia, usario_valido, contraseña_invalida, passencritado As String
    Dim encript As String()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'realizo la conversion de la contrasena a MD5 para luego ser comparada con la grabada en la base de datos
        'inicio libreria
        Dim has As New OC.Core.Crypto.Hash
        'obtengo  el valor del string ingresado por el usuario
        Dim texto As String = TextBox1.Text
        'encripto el string recibido al metodo MD5 y los muestro en minuscula
        passencritado = has.MD5(texto).ToLower
        ' MessageBox.Show(passencritado)
        If usario_valido = 0 Then
            Try
                Dim consulta As String
                Dim rs As MySqlDataReader
                Dim com As New MySqlCommand
                com.Connection = conexion
                conexion.Open()
                consulta = "SELECT nombre,departamento,nivel,usuario,pass FROM usuarios WHERE usuario='" & txt_area.Text & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre = rs(0)
                departamento = rs(1)
                nivel = rs(2)
                usuario = rs(3)
                pass = rs(4)
                rs.Close()
                conexion.Close()
                usario_valido = 1
                If passencritado = pass Then
                    'voy a leer el archivo de configuracion de SEM para saber en que agencia estoy ubicado
                    encript = System.IO.File.ReadAllLines("C:\goptics\conf.ini")
                    id_agencia = encript(20)
                    id_agencia = Mid(id_agencia, 12, Len(id_agencia) - 1)

                    'entro al programa
                    dashboard.usuario.Text = usuario
                    dashboard.depto.Text = departamento
                    dashboard.no_agencia = id_agencia
                    dashboard.permisos.Text = nivel
                    dashboard.nombre_usuario = nombre
                    dashboard.Show()
                    Me.Close()
                Else
                    MessageBox.Show("La contraseña ingresada no es valida, por favor intentalo de nuevo ")
                    TextBox1.Clear()
                    TextBox1.Focus()
                    passencritado = ""
                    usario_valido = 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MessageBox.Show("Por favor verifica tu usuario y vuelve a intentarlo.",
             "Usuario Invalido",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1)
                conexion.Close()
                txt_area.Clear()
                txt_area.Focus()
                passencritado = ""
                usario_valido = 0
                Return

            End Try
        Else
            If passencritado = pass Then
                'entro al programa
                dashboard.usuario.Text = usuario
                dashboard.depto.Text = departamento
                dashboard.no_agencia = id_agencia
                dashboard.permisos.Text = nivel
                dashboard.Show()
                Me.Close()
            Else
                MessageBox.Show("La contraseña ingresada no es valida, por favor intentalo de nuevo ")
                TextBox1.Clear()
                TextBox1.Focus()
                usario_valido = 1
            End If
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        usario_valido = 0
        VERSION.Text = My.Application.Info.Version.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub txt_area_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_area.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub txt_area_TextChanged(sender As Object, e As EventArgs) Handles txt_area.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:soporte@hergosoft.com")
    End Sub
End Class
