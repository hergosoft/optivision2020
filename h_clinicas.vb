Imports MySql.Data.MySqlClient
Public Class h_clinicas
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Public dedonde, no_cliente As String
    Dim com As MySqlCommand




    Private Sub h_clinicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtengo el listado de historias  pendientes de imprimir
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        If dedonde = 3 Then
            'cargo solo las historias clinicas que no tienen asignado codigo de cliente 
            'consultra traslados pendientes de rececpcion
            Try
                consulta = "select no_clinica,fecha,paciente,telefono from clinica where id_agencia='" & dashboard.no_agencia & "' and id_cliente='0' order by fecha desc "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "HISTORIA"
                DataGridView1.Columns(0).Width = 90
                DataGridView1.Columns(1).HeaderText = "FECHA"
                DataGridView1.Columns(1).Width = 90
                DataGridView1.Columns(2).HeaderText = "PACIENTE"
                DataGridView1.Columns(2).Width = 350
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).Width = 95
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de historias pendientes de imprimir, " & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return

            End Try
        Else
            'muestro todas las historias clinicas pendientes de operar 
            Try
                consulta = "select no_clinica,serie,nombre,telefono from clinica where status='P' and id_agencia='" & dashboard.no_agencia & "' order by fecha desc "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(0).Width = 95
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 80
                DataGridView1.Columns(2).HeaderText = "PACIENTE"
                DataGridView1.Columns(2).Width = 350
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).Width = 80
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de historias pendientes de imprimir, " & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return

            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        If dedonde = 1 Then

        ElseIf dedonde = 2 Then
            'edito historia clinica 
            HistoriaClinica_nueva.dedonde = 2
            HistoriaClinica_nueva.correlativo.Text = CStr(row.Cells(0).Value)
            HistoriaClinica_nueva.ShowDialog()
        ElseIf dedonde = 3 Then
            'anexo la historia clinca seleccionada al codigo de cliente desde mantenimiento de expendientes 
            Try
                conexion.Open()
                consulta = "UPDATE clinica SET id_cliente='" & no_cliente & "' where no_clinica='" & (row.Cells(0).Value) & "'  and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                MessageBox.Show("Historia clinica agregada al expendiente")
                conexion.Close()
                mantenimiento_expedientes.funcion.PerformClick()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible agregar la historia clinica al expendiente, si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If
    End Sub
End Class