Imports MySql.Data.MySqlClient
Public Class usuario_nuevo
    Dim consulta, nivel, passencritado As String
    Public id_usuario, id_perfil, dedonde As String
    Dim rs As MySqlDataReader
    Dim com As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla_categoria As DataTable
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        TextBox5.Clear()
        TextBox3.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Text = 0
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub usuario_nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Focus()
        'verifico de donde estoy llamando a la ventana 
        If dedonde = 0 Then
            'llamo ventana desde nuevo usuario 

        ElseIf dedonde = 1 Then
            TextBox1.Enabled = False
            'llavo ventana desde modificac
            'ion de usuario 
            'obtengo los datos del usuario 
            Try
                conexion.Open()
                consulta = "select usuario,id_agencia,nivel from  usuarios where id_usuario='" & id_usuario & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                TextBox1.Text = rs(0)
                TextBox4.Text = rs(1)
                rs.Close()
                conexion.Close()
                If TextBox4.Text = 1 Then
                    Label7.Text = ""
                ElseIf TextBox4.Text = 2 Then
                    Label7.Text = " "
                ElseIf TextBox4.Text = 3 Then
                    Label7.Text = " "
                End If
            Catch ex As Exception
                MsgBox("No fue posible obtener los datos del usuario a modificar," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
                ComboBox1.SelectedValue = id_perfil
            End Try
        End If
        'obtengo el listado de perfiles usuario 
        Try
            conexion.Open()
            consulta = "SELECT * FROM cat_usuario"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabla_categoria = New DataTable
            adaptador.Fill(tabla_categoria)
            ComboBox1.DataSource = tabla_categoria
            ComboBox1.DisplayMember = "nombre"
            ComboBox1.ValueMember = "id_perfil"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de perfiles," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        If id_perfil = "ADMINISTRACION" Then
            ComboBox1.SelectedValue = 1
        ElseIf id_perfil = "REPORTERIA" Then
            ComboBox1.SelectedValue = 2
        ElseIf id_perfil = "ASESOR VENTAS" Then
            ComboBox1.SelectedValue = 3
        ElseIf id_perfil = "SUPERVISOR" Then
            ComboBox1.SelectedValue = 4
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then

        End If
    End Sub

    Private Sub TextBox4_LostFocus(sender As Object, e As EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            MessageBox.Show("Debes ingresar un numero de agencia para poder continuar")
            Return
            TextBox4.Focus()
        ElseIf TextBox4.Text = 0 Then
            MessageBox.Show("Debes ingresar un numero de agencia valido para poder continuar")
            Return
            TextBox4.Focus()
        ElseIf TextBox4.Text >= 4 Then
            MessageBox.Show("El numero de agencia ingresado no existe, por favor intenta de nuevo ")
'
'+Return
            TextBox4.Focus()
        Else
            'realizo la busquedad de la agencia segun el numero ingresado 
            Try
                conexion.Open()
                consulta = "SELECT nombre from catagencias where id_agencia='" & TextBox4.Text & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                Label7.Text = rs(0)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de agencias," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
                TextBox4.Focus()
            End Try
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox3.Text = TextBox5.Text Then
            nivel = ComboBox1.SelectedIndex
            ' MessageBox.Show(nivel)
            If dedonde = 0 Then
                'realizo la encriptacion de la contase;a ingresada para grbar 
                'nuevo usuario
                'inicio libreria
                Dim has As New OC.Core.Crypto.Hash
                'obtengo  el valor del string ingresado por el usuario
                Dim texto As String = TextBox5.Text
                'encripto el string recibido al metodo MD5 y los muestro en minuscula
                passencritado = has.MD5(texto).ToLower
                Try
                    conexion.Open()
                    consulta = "INSERT INTO usuarios(pass,nombre,departamento, nivel,tipo,usuario, id_agencia) values('" & passencritado & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & nivel & "','1','" & TextBox1.Text & "', '" & TextBox4.Text & "')"
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    conexion.Close()
                    MessageBox.Show("Usuario creado con exito")
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No fue posible crear el nuevo usuario," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            ElseIf dedonde = 1 Then
                nivel = ComboBox1.SelectedIndex
                'actualizo usuario
                Try
                    conexion.Open()
                    'Valido si el campo clave fue modificado o no 
                    If TextBox3.Text <> "" Then
                        'inicio libreria
                        Dim has As New OC.Core.Crypto.Hash
                        'obtengo  el valor del string ingresado por el usuario
                        Dim texto As String = TextBox5.Text
                        'encripto el string recibido al metodo MD5 y los muestro en minuscula
                        passencritado = has.MD5(texto).ToLower
                        consulta = "UPDATE usuarios SET pass='" & passencritado & "',nombre='" & TextBox2.Text & "', departamento='" & ComboBox1.Text & "', nivel='" & nivel & "', tipo='1', id_agencia='" & TextBox4.Text & "' where id_usuario='" & id_usuario & "' "

                    Else
                        consulta = "UPDATE usuarios SET nombre='" & TextBox2.Text & "', departamento='" & ComboBox1.Text & "', nivel='" & nivel & "', tipo='1', id_agencia='" & TextBox4.Text & "' where id_usuario='" & id_usuario & "' "

                    End If
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    MessageBox.Show("Usuario modificado con exito")
                    conexion.Close()
                    usuarios.Button4.PerformClick()
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No fue posible actualizar la informacion del usuario," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            End If
            TextBox5.Clear()
            TextBox3.Clear()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox4.Text = 0
            ComboBox1.SelectedIndex = 0
            Label7.Text = "Sucursal Predefinida"
        Else
            'contraseñas no coinciden
            MessageBox.Show("Las contraseñas ingresadas no coinciden, por favor verifica nuevamente")
            TextBox5.Clear()
            TextBox3.Clear()
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class