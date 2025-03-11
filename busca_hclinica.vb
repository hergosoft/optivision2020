Imports MySql.Data.MySqlClient
Public Class busca_hclinica

    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabla_clinica As DataTable
    Public dedonde As String
    Private Sub busca_hclinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      nombre.Select()
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With


        If dedonde = 1 Then
            'realizo la busquedad de las 10 primeras historias clinicas para rellenar
            Try
                'realizo la busquedad de las 10 primeras historias clinicas para rellenar
                Try
                    conexiongoptics.Open()
                    consulta = "SELECT no_clinica,paciente,telefono,fecha from clinica where id_agencia='" & dashboard.no_agencia & "'  order by fecha desc limit 50"
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    tabla_clinica = New DataTable
                    adaptador.Fill(tabla_clinica)
                    DataGridView1.DataSource = tabla_clinica
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                    DataGridView1.Columns(1).HeaderText = "NOMBRE"
                    DataGridView1.Columns(2).HeaderText = "TELEFONO"
                    DataGridView1.Columns(3).HeaderText = "FECHA"
                    DataGridView1.Columns(0).Width = 100
                    DataGridView1.Columns(1).Width = 330
                    DataGridView1.Columns(2).Width = 110
                    DataGridView1.Columns(3).Width = 100
                Catch ex As Exception
                    conexiongoptics.Close()
                    MsgBox("No fue posible obtener el listado de historias clinicas, por favor cierra la ventana y vuelve a intentar." &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                    conexion.Close()
                    Return
                End Try
            Catch ex As Exception
                conexiongoptics.Close()
                MsgBox("No fue posible obtener el listado de historias clinicas, por favor cierra la ventana y vuelve a intentar." &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 2 Then
            CheckOperadas.Checked = False
            'realizo la busquedad de las 10 primeras historias clinicas para rellenar
            Try
                'cargo las historias clinicas conforme al nombre
                conexiongoptics.Open()
                consulta = "select no_clinica,paciente,telefono,fecha,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_add,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_add,rx5_od_dnp,rx5_oi_dnp,optometra,esfu_visual FROM clinica  where id_agencia='" & dashboard.no_agencia & "' and estado<>'O'  order by fecha desc"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                tabla_clinica = New DataTable
                adaptador.Fill(tabla_clinica)
                DataGridView1.DataSource = tabla_clinica
                conexiongoptics.Close()
                DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(1).HeaderText = "NOMBRE"
                DataGridView1.Columns(2).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).HeaderText = "FECHA"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).Width = 330
                DataGridView1.Columns(2).Width = 110
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False
                DataGridView1.Columns(12).Visible = False
                DataGridView1.Columns(13).Visible = False
                DataGridView1.Columns(14).Visible = False
                DataGridView1.Columns(15).Visible = False

            Catch ex As Exception
                conexiongoptics.Close()
                MsgBox("No fue posible obtener el listado de historias clinicas, por favor cierra la ventana y vuelve a intentar." &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                conexion.Close()
                Return
            End Try
        End If

    End Sub

    Private Sub nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscar.PerformClick()
            nombre.Clear()
            nombre.Select()
        End If
    End Sub

    Private Sub nombre_TextChanged(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs) Handles buscar.Click
        DataGridView1.DataSource = Nothing
        Try

            'cargo las historias clinicas conforme al nombre
            conexiongoptics.Open()
            If CheckOperadas.Checked = True Then
                'busco historias clinicas ya operadas de la tienda 
                consulta = "select no_clinica,paciente,telefono,fecha,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_add,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_add,rx5_od_dnp,rx5_oi_dnp,optometra,email FROM clinica  where id_agencia='" & dashboard.no_agencia & "'  and estado='O' and paciente like '%" & nombre.Text & "%' order by fecha desc"
            Else
                consulta = "select no_clinica,paciente,telefono,fecha,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_add,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_add,rx5_od_dnp,rx5_oi_dnp,optometra,email FROM clinica  where id_agencia='" & dashboard.no_agencia & "'  and estado='I' and paciente like '%" & nombre.Text & "%' order by fecha desc"

            End If
            adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
            tabla_clinica = New DataTable
            adaptador.Fill(tabla_clinica)
            DataGridView1.DataSource = tabla_clinica
            conexiongoptics.Close()
            DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
            DataGridView1.Columns(1).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).HeaderText = "TELEFONO"
            DataGridView1.Columns(3).HeaderText = "FECHA"
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 330
            DataGridView1.Columns(2).Width = 110
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False
            DataGridView1.Columns(11).Visible = False
            DataGridView1.Columns(12).Visible = False
            DataGridView1.Columns(13).Visible = False
        Catch ex As Exception
            conexiongoptics.Close()
            MsgBox("No fue posible obtener el listado de historias clinicas, por favor cierra la ventana y vuelve a intentar." &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            conexion.Close()
            Return
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        If dedonde = 1 Then
            'jalo la informacion al recibo
            recibos_nuevo.nombrepf.Text = CStr(row.Cells(1).Value)
            recibos_nuevo.nombre.Text = CStr(row.Cells(1).Value)
            recibos_nuevo.telefono.Text = CStr(row.Cells(2).Value)
            Me.Dispose()
        ElseIf dedonde = 2 Then
            'jalo la informacion a la orden 
            'agrego los datos encontrados a la ventana receta 
            receta.TextBox1.Text = CStr(row.Cells(0).Value)
            receta.nombre.Text = CStr(row.Cells(1).Value)
            receta.telefono.Text = CStr(row.Cells(2).Value)
            receta.tod_esf.Text = CStr(row.Cells(4).Value)
            receta.tod_cil.Text = CStr(row.Cells(5).Value)
            receta.tod_eje.Text = CStr(row.Cells(6).Value)
            receta.odadd.Text = CStr(row.Cells(7).Value)
            receta.toi_esf.Text = CStr(row.Cells(8).Value)
            receta.toi_cil.Text = CStr(row.Cells(9).Value)
            receta.toi_eje.Text = CStr(row.Cells(10).Value)
            receta.oiadd.Text = CStr(row.Cells(11).Value)
            receta.dp.Text = CStr(row.Cells(12).Value)
            receta.odesfera.Text = CStr(row.Cells(13).Value)
            receta.opto.Text = CStr(row.Cells(14).Value)
            receta.direccion.Text = CStr(row.Cells(15).Value)
            Me.Dispose()
        End If



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class