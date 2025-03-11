Imports MySql.Data.MySqlClient
Public Class usuarios
    Dim consulta, accion, id_usuario As String
    Dim adaptador As MySqlDataAdapter
    Dim tabla_usuarios As DataTable
    Dim com As New MySqlCommand
    Public dedonde As String

    Private Sub usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        accion = 0
        'doy estilo al dtv 
        With dtv_usuarios
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
        End With
        If dedonde = 2 Then
            'abro desde registro de agencias
            Try
                conexion.Open()
                consulta = "select id_agencia,nombre,serial from catagencias"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_usuarios = New DataTable
                adaptador.Fill(tabla_usuarios)
                dtv_usuarios.DataSource = tabla_usuarios
                conexion.Close()
                dtv_usuarios.Columns(0).HeaderText = "NO "
                dtv_usuarios.Columns(1).HeaderText = "NOMBRE"
                dtv_usuarios.Columns(2).HeaderText = "SERIAL"
                dtv_usuarios.Columns(0).Width = 70
                dtv_usuarios.Columns(1).Width = 150
                dtv_usuarios.Columns(2).Width = 108
                GroupBox1.Enabled = False
                PictureBox1.Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de sucursales," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        Else
            'abro desde registra nueva usuario
            Try
                conexion.Open()
                consulta = "SELECT id_usuario,nombre,departamento from usuarios where id_usuario>='1'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_usuarios = New DataTable
                adaptador.Fill(tabla_usuarios)
                dtv_usuarios.DataSource = tabla_usuarios
                conexion.Close()
                dtv_usuarios.Columns(0).Visible = False
                dtv_usuarios.Columns(1).HeaderText = "NOMBRE"
                dtv_usuarios.Columns(2).HeaderText = "PERFIL"
                dtv_usuarios.Columns(1).Width = 220
                dtv_usuarios.Columns(2).Width = 110
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de usuarios," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        usuario_nuevo.TextBox2.Select()
        usuario_nuevo.TextBox2.Focus()
        usuario_nuevo.ShowDialog()
        refrescar.PerformClick()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub refrescar_Click(sender As Object, e As EventArgs) Handles refrescar.Click
        Try
            conexion.Open()
            consulta = "SELECT id_usuario,nombre,departamento from usuarios where id_usuario>='1'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabla_usuarios = New DataTable
            adaptador.Fill(tabla_usuarios)
            dtv_usuarios.DataSource = tabla_usuarios
            conexion.Close()
            dtv_usuarios.Columns(0).Visible = False
            dtv_usuarios.Columns(1).HeaderText = "NOMBRE"
            dtv_usuarios.Columns(2).HeaderText = "PERFIL"
            dtv_usuarios.Columns(1).Width = 220
            dtv_usuarios.Columns(2).Width = 110
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de usuarios," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = 1
        MessageBox.Show("Por favor da doble clic sobre el usuario al que quieres modificar")
        Button1.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub dtv_usuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_usuarios.CellContentClick

    End Sub

    Private Sub dtv_usuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_usuarios.CellDoubleClick
        Dim row As DataGridViewRow = dtv_usuarios.CurrentRow
        If dedonde = 2 Then
            'abro registra la maquina 
            registra_maquina.agencia.Text = CStr(row.Cells(0).Value)
            registra_maquina.sucursal.Text = CStr(row.Cells(1).Value)
            registra_maquina.ShowDialog()
        Else
            If accion = 0 Then
            ElseIf accion = 1 Then
                'modificar usuario
                usuario_nuevo.id_usuario = CStr(row.Cells(0).Value)
                usuario_nuevo.TextBox2.Text = CStr(row.Cells(1).Value)
                usuario_nuevo.id_perfil = CStr(row.Cells(2).Value)
                usuario_nuevo.dedonde = 1
                '   MessageBox.Show(usuario_nuevo.id_perfil)
                usuario_nuevo.Show()
            ElseIf accion = 2 Then
                'eliminar usuario 

                id_usuario = CStr(row.Cells(0).Value)
                Try
                    conexion.Open()
                    consulta = "DELETE  FROM usuarios where id_usuario='" & id_usuario & "'"
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    conexion.Close()
                    MessageBox.Show("Usuario eliminado con exito")
                    refrescar.PerformClick()
                    Button1.Enabled = True
                    Button2.Enabled = True
                    accion = 0
                Catch ex As Exception
                    MsgBox("No fue posible eliminar el usuario seleccionado," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'eliminar usuario
        accion = 2
        MessageBox.Show("Por favor da doble clic sobre el usuario al que quieres eliminar!")
        Button1.Enabled = False
        Button2.Enabled = False
    End Sub
End Class