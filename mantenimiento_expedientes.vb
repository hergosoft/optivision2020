Imports MySql.Data.MySqlClient
Public Class mantenimiento_expedientes
    Dim adaptador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim tabladatos As DataTable

    Public dedonde, no_cliente, quehago As Integer

    Dim ano, mes, dia, rx2odesf, rx2oiesf, rx2odcil, rx2oicil, rx2odeje, rx2oieje, rx2odav, rx2oiav, rx2odadd, rx2oiadd, rx2avcc, pregunta, consulta, rx2odav1, rx2oiav1, rx2oddnp, rx2oidnp As String
    Private Sub NUEVO_Click(sender As Object, e As EventArgs) Handles NUEVO.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        historia_completa.Enabled = False
        consulta_documento.titulo.Text = "Busca Paciente"
        consulta_documento.subtitulo.Text = "Doble clic sobre cliente a consultar"
        consulta_documento.radionumero.Text = "DPI"
        consulta_documento.radionombre.Text = "NOMBRE PACIENTE"
        consulta_documento.dedonde = 10
        consulta_documento.TextBox1.Select()
        consulta_documento.ShowDialog()
        ' desactivar.Enabled = True
        quehago = 20
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        historia_completa.Enabled = False
        'bloqueo boton editar y cargar historia clinica
        editar.Enabled = False
        cargar_historia.Enabled = False
        Button3.Enabled = False
        grabar.Enabled = True
        GroupBox1.Enabled = True
        'indico al boton guardar que es lo que debe grabar
        quehago = 2
        'limpio controles
        nombre.Clear()
        direccion.Clear()
        telefono.Clear()
        dpi.Clear()

        ocupacion.Clear()
        email.Clear()

        dtv_rx.Rows.Clear()
        dtv_hclinica.DataSource = Nothing
        nombre.Focus()
        desactivar.Enabled = False
        'abro la ventana de historias clinicas pendientes de operar para poder jalar los datos principales del cliente 
        ' h_clinicas.MdiParent = dashboard
        ' h_clinicas.dedonde = 3
        ' h_clinicas.Show()

    End Sub

    Private Sub grabar_Click(sender As Object, e As EventArgs) Handles grabar.Click

        historia_completa.Enabled = False
        If quehago = 1 Then
            'grabo editar cliente//solo encabezado 
            Try
                conexion.Open()
                consulta = "UPDATE clientes SET nombre='" & nombre.Text & "',direccion='" & direccion.Text & "',ocupacion='" & ocupacion.Text & "',telefono='" & telefono.Text & "',email='" & email.Text & "',fecha_nac='" & fecha_nac.Text & "',dpi='" & dpi.Text & "' WHERE id_cliente='" & no_cliente & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                MsgBox("La informacion se actualizo con exito.", vbOKOnly + vbInformation, "Actualizacion Exitosa")
            Catch ex As Exception
                MsgBox("No fue posible editar los datos de cliente, si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            grabar.Enabled = False
        ElseIf quehago = 2 Then
            'grabo cliente nuevo
            'realizo la grabacion del encabezado de los clientes 
            Try
                conexion.Open()
                consulta = "INSERT INTO clientes  (nombre,direccion,ocupacion,telefono,email,fecha_nac,dpi,id_agencia,tienda) values ('" & nombre.Text & "', '" & direccion.Text & "', '" & ocupacion.Text & "', '" & telefono.Text & "', '" & email.Text & "',  '" & fecha_nac.Text & "','" & dpi.Text & "','" & dashboard.no_agencia & "','" & dashboard.agencia.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                MsgBox("Cliente grabado con exito, ya puede ingresarle la historia clinica", vbOKOnly + vbInformation, "Grabacion Exitosa")
                cargar_historia.Enabled = True
                Button3.Enabled = True
            Catch ex As Exception
                cargar_historia.Enabled = False
                Button3.Enabled = False
                MsgBox("No fue posible crear el nuevo cliente, si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub editar_Click(sender As Object, e As EventArgs) Handles editar.Click
        'activo el groupbox1 para editar datos de paciente
        GroupBox1.Enabled = True
        'le indico a la variable que funcion debe ejecutar el boton guardar
        quehago = 1
        grabar.Enabled = True
        historia_completa.Enabled = False
        nombre.Focus()
    End Sub

    Private Sub desactivar_Click(sender As Object, e As EventArgs) Handles desactivar.Click

        pregunta = MsgBox("Se eliminara toda la informacion  del cliente " & nombre.Text & vbCrLf & "  ¿Desea Continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Eliminar  Cliente")
        If pregunta = vbYes Then
            'desactivo al cliente 
            Try
                conexion.Open()
                consulta = "UPDATE clientes SET status='B' WHERE id_cliente='" & no_cliente & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                MsgBox("Cliente eliminado con exito.", vbOKOnly + vbInformation, "Eliminacion Exitosa")
                quehago = 2
                Button1.PerformClick()

            Catch ex As Exception
                MsgBox("No fue posible eliminar la ficha del cliente, si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        Else
            Return
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        funcion.PerformClick()
    End Sub

    Private Sub funcion_Click(sender As Object, e As EventArgs) Handles funcion.Click
        If dedonde = 1 Then
        ElseIf dedonde = 2 Then
            'cargo datos desde buscar cliente 
            'busco el encabezado del cliente
            Try
                conexion.Open()
                consulta = "select nombre,direccion,ocupacion,telefono,email,ultima_compr,fecha_nac,dpi FROM clientes where id_cliente='" & no_cliente & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                direccion.Text = rs(1)
                ocupacion.Text = rs(2)
                telefono.Text = rs(3)
                email.Text = rs(4)
                edad.Text = rs(5)
                fecha_nac.Text = rs(6)
                dpi.Text = rs(7)
                rs.Close()
                conexion.Close()
                grabar.Enabled = False
                cargar_historia.Enabled = False
                Button3.Enabled = False
                dpi.Focus()
                'realizo el calculo para obtener la edad del paciente 
                Dim FechaNacimientoString = fecha_nac.Value.ToShortDateString
                '  MessageBox.Show(FechaNacimientoString)
                Dim FechaNacimientoDate = DateTime.ParseExact(FechaNacimientoString, "dd/MM/yyyy", Nothing)
                Dim FechaHoy = DateTime.Now
                Dim Diferencia = FechaHoy - FechaNacimientoDate
                Dim Dias = Diferencia.TotalDays
                Dim Anos = Math.Floor(Dias / 365)
                edad.Text = Anos
                'busco las historias clinicas del cliente 
                Try
                    conexion.Open()
                    consulta = "SELECT h.no_clinica,h.fecha,h.edad,h.motivo,h.obs,c.nombre,h.optometra  FROM clinica as h left join catagencias as c on h.id_agencia=c.id_agencia where h.id_cliente='" & no_cliente & "' order by h.no_clinica desc"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    tabladatos = New DataTable
                    adaptador.Fill(tabladatos)
                    dtv_hclinica.DataSource = tabladatos
                    conexion.Close()
                    dtv_hclinica.Columns(0).HeaderText = "NO. HISTORIA"
                    dtv_hclinica.Columns(0).Width = 80
                    dtv_hclinica.Columns(1).HeaderText = "FECHA EXAMEN"
                    dtv_hclinica.Columns(1).Width = 120
                    dtv_hclinica.Columns(2).HeaderText = "EDAD"
                    dtv_hclinica.Columns(2).Width = 50
                    dtv_hclinica.Columns(3).HeaderText = "MOTIVO CONSULTA"
                    dtv_hclinica.Columns(3).Width = 300
                    dtv_hclinica.Columns(4).HeaderText = "OBSERVACIONES "
                    dtv_hclinica.Columns(4).Width = 350
                    dtv_hclinica.Columns(5).HeaderText = "SUCURSAL"
                    dtv_hclinica.Columns(5).Width = 250
                    dtv_hclinica.Columns(6).HeaderText = "EVALUA"
                    dtv_hclinica.Columns(6).Width = 300
                Catch ex As Exception
                    MsgBox("No fue posible cargar las historias clinicas del paciente, si el error persiste contacta con Soporte Tecnico " &
            vbCrLf & vbCrLf & ex.Message,
            MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                End Try

            Catch ex As Exception
                MsgBox("No fue posible cargar el encabezado del cliente, si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try
            GroupBox1.Enabled = False
            editar.Enabled = True
            cargar_historia.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub mantenimiento_expedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dedonde = 1 Then
            'abro desde nuevo cliente 
            editar.Enabled = False
            grabar.Enabled = False
            GroupBox1.Enabled = False
            desactivar.Enabled = False
        ElseIf dedonde = 2 Then
            'abro desde buscar historial de cliente
            desactivar.Enabled = True
        ElseIf dedonde = 3 Then
            'Abro desde modificacion de clientes, solo habilito encabezado mas no historias clinicas
            'busco el encabezado del cliente
            Try
                conexion.Open()
                consulta = "select nombre,direccion,ocupacion,telefono,email,fecha_nac,dpi FROM clientes where id_cliente='" & no_cliente & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                direccion.Text = rs(1)
                ocupacion.Text = rs(2)
                telefono.Text = rs(3)
                email.Text = rs(4)
                fecha_nac.Text = rs(5)
                dpi.Text = rs(6)
                rs.Close()
                conexion.Close()
                grabar.Enabled = False
                cargar_historia.Enabled = False
                Button3.Enabled = False
                editar.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible cargar la informacion del cliente, si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
            End Try
        End If

        'doy estilo a mi datagridview
        With dtv_hclinica
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        'doy estilo a mi datagridview
        With dtv_rx
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
    End Sub

    Private Sub nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            direccion.Focus()
        End If
    End Sub

    Private Sub nombre_TextChanged(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub

    Private Sub direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles direccion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            telefono.Focus()
        End If
    End Sub

    Private Sub direccion_TextChanged(sender As Object, e As EventArgs) Handles direccion.TextChanged

    End Sub

    Private Sub telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles telefono.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dpi.Focus()
        End If
    End Sub

    Private Sub telefono_TextChanged(sender As Object, e As EventArgs) Handles telefono.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles fecha_nac.ValueChanged

    End Sub

    Private Sub dpi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dpi.KeyPress
        If Asc(e.KeyChar) = 13 Then
            fecha_nac.Focus()
        End If
    End Sub

    Private Sub dpi_TextChanged(sender As Object, e As EventArgs) Handles dpi.TextChanged

    End Sub

    Private Sub ocupacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ocupacion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            email.Focus()
        End If
    End Sub

    Private Sub ocupacion_TextChanged(sender As Object, e As EventArgs) Handles ocupacion.TextChanged

    End Sub

    Private Sub fecha_nac_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ocupacion.Focus()
        End If
    End Sub

    Private Sub fecha_nac_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles email.KeyPress
        If Asc(e.KeyChar) = 13 Then
            edad.Focus()
        End If
    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub edad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            grabar.Focus()
        End If
    End Sub

    Private Sub edad_TextChanged(sender As Object, e As EventArgs) Handles edad.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If quehago = 2 Then
            'abro desde cliente nuevo 
            h_clinicas.dedonde = 3
            h_clinicas.ShowDialog()
        ElseIf quehago = 20 Then
            'abro dsede buscar cliente 
            h_clinicas.dedonde = 3
            h_clinicas.no_cliente = no_cliente
            h_clinicas.ShowDialog()
        End If

    End Sub

    Private Sub dtv_hclinica_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_hclinica.CellContentClick

    End Sub

    Private Sub dtv_hclinica_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_hclinica.CellDoubleClick
        dtv_rx.Rows.Clear()
        Dim row As DataGridViewRow = dtv_hclinica.CurrentRow
        If quehago = 1 Then
            'edito la historia clinica al darle doble clic 
            'Dim row1 As DataGridViewRow = dtv_hclinica.CurrentRow
            'HistoriaClinica_nueva.correlativo.Text = (row1.Cells(0).Value)
            'HistoriaClinica_nueva.serie = (row1.Cells(1).Value)
            'h_clinica_nueva.no_tienda = (row1.Cells(7).Value)
            ' h_clinica_nueva.graba.Enabled = False
            ' h_clinica_nueva.titulo.Text = "Detalle Historia Clinica"
            ' h_clinica_nueva.imprime.Visible = True
            ' h_clinica_nueva.graba.Visible = False
            ' h_clinica_nueva.dedonde = 3
            'h_clinica_nueva.ShowDialog()

        Else
            'busco el detalle de la graduacion ingresada en la historia clinica seleccionada 
            Try
                conexion.Open()
                consulta = "select rx5_od_esf,rx5_oi_esf,rx5_od_cil,rx5_oi_cil,rx5_od_eje,rx5_oi_eje,rx5_od_av,rx5_oi_av,rx5_od_add,rx5_oi_add,rx5_od_av1,rx5_oi_av1,rx5_od_dnp,rx5_oi_dnp from clinica where no_clinica='" & CStr(row.Cells(0).Value) & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                rx2odesf = rs(0)
                rx2oiesf = rs(1)
                rx2odcil = rs(2)
                rx2oicil = rs(3)
                rx2odeje = rs(4)
                rx2oieje = rs(5)
                rx2odav = rs(6)
                rx2oiav = rs(7)
                rx2odadd = rs(8)
                rx2oiadd = rs(9)
                rx2odav1 = rs(10)
                rx2oiav1 = rs(11)
                rx2oddnp = rs(12)
                rx2oidnp = rs(13)

                rs.Close()
                conexion.Close()
                'agrego los items al dtv rx
                dtv_rx.Rows.Add(rx2odesf, rx2odcil, rx2odeje, rx2odav, rx2odadd, rx2odav1, rx2oddnp)
                dtv_rx.Rows.Add(rx2oiesf, rx2oicil, rx2oieje, rx2oiav, rx2oiadd, rx2oiav1, rx2oidnp)
                historia_completa.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible cargar la graduacion de la historia clinica seleccionada, si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If
    End Sub

    Private Sub historia_completa_Click(sender As Object, e As EventArgs) Handles historia_completa.Click
        Dim row As DataGridViewRow = dtv_hclinica.CurrentRow
        HistoriaClinica_nueva.correlativo.Text = (row.Cells(0).Value)
        HistoriaClinica_nueva.sucursal.Text = CStr(row.Cells(5).Value)
        HistoriaClinica_nueva.titulo.Text = "Detalle Historia Clinica"
        HistoriaClinica_nueva.imprime.Visible = True
        HistoriaClinica_nueva.grabar.Visible = False
        HistoriaClinica_nueva.dedonde = 2
        HistoriaClinica_nueva.ShowDialog()
    End Sub

    Private Sub cargar_historia_Click(sender As Object, e As EventArgs) Handles cargar_historia.Click
        'obtengo el numero de cliente agregado 
        Try
            conexion.Open()
            consulta = "SELECT id_cliente FROM clientes where nombre='" & nombre.Text & "'"
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            no_cliente = rs(0)
            rs.Close()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible encontrar el codigo del cliente, si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        HistoriaClinica_nueva.no_cliente = no_cliente
        HistoriaClinica_nueva.nombre.Text = nombre.Text
        HistoriaClinica_nueva.oi_oftal2.Text = direccion.Text
        HistoriaClinica_nueva.telefono.Text = telefono.Text
        ' HistoriaClinica_nueva.motivo.Text = ocupacion.Text
        HistoriaClinica_nueva.email.Text = email.Text
        HistoriaClinica_nueva.oi_oftal1.Text = dpi.Text
        HistoriaClinica_nueva.profesion.Text = ocupacion.Text
        HistoriaClinica_nueva.edad.Text = edad.Text
        HistoriaClinica_nueva.DateTimePicker1.Value = fecha_nac.Value
        HistoriaClinica_nueva.dedonde = 1
        HistoriaClinica_nueva.Show()
        HistoriaClinica_nueva.motivo.Focus()

    End Sub

    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fecha_nac.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ocupacion.Focus()
        End If
    End Sub

    Private Sub fecha_nac_LostFocus(sender As Object, e As EventArgs) Handles fecha_nac.LostFocus

        ''realizo el calculo para obtener la edad del paciente 
        'Dim FechaNacimientoString = fecha_nac.Value.ToShortDateString
        '' MessageBox.Show(FechaNacimientoString)
        'Dim FechaNacimientoDate = DateTime.ParseExact(FechaNacimientoString, "dd/MM/yyyy", Nothing)
        '    Dim FechaHoy = DateTime.Now
        'Dim Diferencia = FechaHoy - FechaNacimientoDate
        'Dim Dias = Diferencia.TotalDays
        'MessageBox.Show(Dias)
        'Dim Anos = Math.Floor(Dias / 365)
        '    edad.Text = Anos

        Dim fecha As Date = fecha_nac.Value
        Dim edadpx As Integer = CalcularEdad(fecha)
        edad.Text = edadpx

    End Sub
    Public Function CalcularEdad(ByVal fechaNacimiento As Date) As Integer

        Dim date1 As Date = CDate(fecha_nac.Value)
        Dim date2 As Date = CDate(DateTime.Now)

        Dim edadpx As Integer
        edadpx = date2.Year - date1.Year
        If (fechaNacimiento > Today.AddYears(-edadpx)) Then
            edadpx -= 1
        End If
        Return edadpx
    End Function
End Class