Imports MySql.Data.MySqlClient
Public Class correlativos
    Public dedonde As String
    Dim consulta As String
    Dim rs As MySqlDataReader
    Dim com As MySqlCommand


    Private Sub correlativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dedonde = 20 Then
            titulo.Text = "Correlativo de Facturas"
            Try
                'verifico correlativo de facturas 
                conexion.Open()
                consulta = "Select facturas, seriefac from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                serie.Text = rs(1)
                rs.Close()
                conexion.Close()
                correlativo.Text = Val(correlativo.Text) + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el correlativo actual, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 21 Then
            titulo.Text = "Correlativo Orden de Trabajo"
            ' verifico correlativo de ordenes de trabajo 
            Try
                'verifico correlativo de facturas 
                conexion.Open()
                consulta = "Select ordenes, serieord from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                serie.Text = rs(1)
                rs.Close()
                conexion.Close()
                correlativo.Text = Val(correlativo.Text) + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el correlativo actual, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 50 Then
            titulo.Text = "Correlativo Recibo"
            Try
                'verifico correlativo de facturas 
                conexion.Open()
                consulta = "Select recibos, serierec from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                serie.Text = rs(1)
                rs.Close()
                conexion.Close()
                correlativo.Text = Val(correlativo.Text) + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el correlativo actual, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 51 Then
            titulo.Text = "Correlativo Orden Trabajo"
            Try
                'verifico correlativo de facturas 
                conexion.Open()
                consulta = "Select ordenes,serieord from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                serie.Text = rs(1)
                rs.Close()
                conexion.Close()
                correlativo.Text = Val(correlativo.Text) + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el correlativo actual, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 52 Then
            titulo.Text = "Correlativo Historia Clinica"
            Try
                'verifico correlativo de facturas 
                conexion.Open()
                consulta = "Select h_clinica, serieh_clinica from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                serie.Text = rs(1)
                rs.Close()
                conexion.Close()
                correlativo.Text = Val(correlativo.Text) + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el correlativo actual, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        correlativo.Text = Val(correlativo.Text) - 1
        If dedonde = 20 Then

            'actualizo correlativo de facturas 
            Try
                conexion.Open()
                consulta = "UPDATE catagencias set facturas='" & correlativo.Text & "', seriefac='" & serie.Text & "' where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Correlativo Actualizado Exitosamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible actualizar el correlativo, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)

            End Try
        ElseIf dedonde = 21 Then
            'actualizo correlativo de ordenes de trabajo  
            Try
                conexion.Open()
                consulta = "UPDATE catagencias set ordenes='" & correlativo.Text & "', serieord='" & serie.Text & "' where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Correlativo Actualizado Exitosamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible actualizar el correlativo, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)

            End Try
        ElseIf dedonde = 50 Then
            'actualizo correlativo de recibos
            Try
                conexion.Open()
                consulta = "UPDATE catagencias set recibos='" & correlativo.Text & "', serierec='" & serie.Text & "' where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Correlativo Actualizado Exitosamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible actualizar el correlativo, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)

            End Try
        ElseIf dedonde = 51 Then
            'actualizo correlativo de orden de laboratorio
            Try
                conexion.Open()
                consulta = "UPDATE catagencias set ordenes='" & correlativo.Text & "', serieord='" & serie.Text & "' where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Correlativo Actualizado Exitosamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible actualizar el correlativo, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 52 Then
            'actualizo correlativo de historias clinicas
            Try
                conexion.Open()
                consulta = "UPDATE catagencias set h_clinica='" & correlativo.Text & "', serieh_clinica='" & serie.Text & "' where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Correlativo Actualizado Exitosamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
                Me.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible actualizar el correlativo, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub
End Class