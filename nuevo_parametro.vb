Imports MySql.Data.MySqlClient
Public Class nuevo_parametro
    Dim consulta As String
    Public correlativo As String
    Dim com As New MySqlCommand
    Dim rs As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' al cancelar la operacion limpio textbox y cierro ventana
        TextBox1.Clear()
        Me.Close()

    End Sub

    Private Sub nuevo_parametro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cat_tipo.Close()
        TextBox1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'valido desde donde viene llamada para grabar 
        If Label1.Text = 1 Then
            Try
                conexion.Open()
                consulta = "INSERT INTO cattipoi(tipo)values('" & TextBox1.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Close()
                conexion.Close()
                MessageBox.Show("Grabacion Exitosa!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()

                cat_tipo.dedonde.Text = 1
                cat_tipo.MdiParent = dashboard
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible grabar el registro, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        ElseIf Label1.Text = 2 Then
            Try
                conexion.Open()
                consulta = "INSERT INTO catmarcasi (id_linea) values ('" & TextBox1.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Close()
                conexion.Close()
                MessageBox.Show("Grabacion Exitosa!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()

                cat_tipo.dedonde.Text = 2
                cat_tipo.MdiParent = dashboard
                cat_tipo.Show()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible grabar el registro, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        ElseIf Label1.Text = 3 Then
            'grabo nueva linea 
            'obtengo el ultimo registro para sumarle uno 
            Try
                conexion.Open()
                consulta = "INSERT INTO catlineasi (id_linea,descripcion) values ( '" & correlativo & "','" & TextBox1.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Close()
                conexion.Close()
                MessageBox.Show("Grabacion Exitosa!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()

                cat_tipo.dedonde.Text = 3
                cat_tipo.MdiParent = dashboard
                cat_tipo.Show()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible grabar el registro, si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        ElseIf Label1.Text = 4 Then         
            Try
                conexion.Open()
                consulta = "INSERT INTO catmedidasi (medida) values ('" & TextBox1.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Close()
                conexion.Close()
                MessageBox.Show("Grabacion Exitosa!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()

                cat_tipo.dedonde.Text = 4
                cat_tipo.MdiParent = dashboard
                cat_tipo.Show()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible grabar el registro, si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf Label1.Text = 5 Then
            'grabo nuevo vendedor 
            Try
                conexion.Open()
                consulta = "INSERT INTO vendedores (nombre,id_agencia,status) values ('" & TextBox1.Text & "','" & dashboard.no_agencia & "','A')"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Close()
                conexion.Close()
                MessageBox.Show("Nuevo Vendedor Agregado!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()
                correlativo = 0
                cat_tipo.dedonde.Text = 5
                cat_tipo.MdiParent = dashboard
                cat_tipo.Show()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible grabar el registro, si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try


            'valores a partir del 11 son para Actualizar
            'actualizo tipo
        ElseIf Label1.Text = 11 Then
            Try
                conexion.Open()
                consulta = "UPDATE cattipoi set tipo='" & TextBox1.Text & "' where id_tipo='" & correlativo & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Registro Actualizado con exito", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                cat_tipo.dedonde.Text = 1
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No pude actualizar el registro, si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'actualizo marca
        ElseIf Label1.Text = 12 Then
            Try
                conexion.Open()
                consulta = "UPDATE catmarcasi set id_linea='" & TextBox1.Text & "' where id_linea='" & correlativo & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Registro Actualizado con exito", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                cat_tipo.dedonde.Text = 2
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el registro, si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'actualizo linea 
        ElseIf Label1.Text = 13 Then
            Try
                conexion.Open()
                consulta = "UPDATE catlineasi set descripcion='" & TextBox1.Text & "' where id_linea='" & correlativo & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Registro Actualizado con exito", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                cat_tipo.dedonde.Text = 3
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el registro, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'actualizo Unidad de Medida 
        ElseIf Label1.Text = 14 Then
            Try
                conexion.Open()
                consulta = "UPDATE catmedidasi set medida='" & TextBox1.Text & "' where id_medida='" & correlativo & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Registro Actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                cat_tipo.dedonde.Text = 4
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el registro, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf Label1.Text = 15 Then
            ' actualizo vendedor
            Try
                conexion.Open()
                consulta = "UPDATE vendedores set nombre='" & TextBox1.Text & "' where id_codigo='" & correlativo & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Vendedor Actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                cat_tipo.dedonde.Text = 5
                cat_tipo.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el registro, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If


    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class