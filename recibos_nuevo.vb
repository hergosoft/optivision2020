Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports Newtonsoft.Json

Public Class recibos_nuevo
    Dim consulta, pregunta, dia, mes, ano, m_fecha(2), m_direccion(2), m_nombre(2), m_telefono(2), m_cantidadletras(2), m_concepto(2), m_total(2), m_estepago(2), m_saldo(2), m_advertencia(2), m_fprometida(2), m_pagoreci(2), m_efectivo(2), m_tarjeta(2), m_autorizacion(2), m_monto(2), m_marcaarmazon(2), m_tipomat(2), m_armazon(2), m_color(2), voucher1, t_tarjeta, Factura, Serie_fact As String
    Dim total1, anticipo1, Totalcobrado1, efectivo1, tarjeta1 As Decimal
    Dim correlativo, correlanterior As Integer
    Dim adaptador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim tablarecibo, tabla_medidas As DataTable
    Public dedonde, documento, serie, id_vendedor, orden, anticipoanterior As String
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim TopRigth As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat
    Dim nitexiste As Boolean
    Dim tarjetatemp, efectivotemp As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'valido si el NIT existe para grabar en bitacora o omitir
        If nitexiste = True Then
        Else
            Try
                'realizo la grabacion en la base de datos de G-optics
                conexion.Open()
                consulta = "INSERT INTO b_nits(nit,nombre) values('" & nit.Text & "','" & nombrepf.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible grabar el numero de NIT en bitacora," & vbCrLf & " Verifica que tengas internet, si el error persiste contacta con soporte tecnico" &
               vbCrLf & vbCrLf & "Codigo: Vnit01" & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        End If

        'separo la fecha que tenga el textbox fecha
        ano = Mid(fecha.Text, 1, Len(fecha.Text) - 6)
        mes = Mid(fecha.Text, 6, Len(fecha.Text) - 8)
        dia = Mid(fecha.Text, 9, Len(fecha.Text) - 1)
        If dedonde = 2 Then
            'verifico que el recibo no este anexado a una orden
            If orden = 0 Then
                If obs.Text = "" Or obs.Text = " " Then
                    MessageBox.Show("Ingresa el motivo de la anulacion para continuar", "Anulacion de Recibo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Else
                    pregunta = MsgBox("Se anulara el recibo Numero  " & documento & "  a nombre de " & nombre.Text & vbCrLf & "  ¿Desea Continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Anulacion de Recibo")
                    If pregunta = vbYes Then
                        'anulacion de recibo G-Optics 
                        Try
                            conexion.Open()
                            consulta = "UPDATE recibos set estado='A', nombre='** A N U L A D O **' ,anticipo='',valor='0',este_pago='0',efectivo='0', tarjeta='0',observa='" & obs.Text & "' where recibo='" & documento & "' and serierec='" & serie & "' and id_agencia='" & dashboard.no_agencia & "'"
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                            MessageBox.Show("Recibo No.00 " & documento & "   Serie " & serie & " Anulado con Exito ")
                            conexion.Close()

                            consulta_documento.Button1.PerformClick()
                            Me.Close()
                        Catch ex As Exception
                            MsgBox("No fue posible realizar la  anulacion del recibo," & vbCrLf & "- Verifica tu conexion a internet. " &
                            vbCrLf & "Codigo de Error: AR02 " & vbCrLf & ex.Message,
                            MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try
                    Else
                        Return
                    End If
                End If
            Else
                'si el recibo esta anexado a una orden entonces no habilito la anulacion 
                MessageBox.Show("El recibo que intentas anular esta anexado a la orden de trabajo No. " & orden & vbCrLf & vbCrLf & "- Debes Solicitar anulacion de la orden para liberar el recibo y anularlo.", "Anula Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf dedonde = 4 Then
            'grabo desde recibo de abono/cancelacion OT
            'obtengo el correlativo a seguir 
            Try
                conexiongoptics.Open()
                consulta = "select MAX(recibo)from recibos where id_agencia='" & dashboard.no_agencia & "';"
                com = New MySqlCommand(consulta, conexiongoptics)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = dashboard.serie_recibo
                rs.Close()
                conexiongoptics.Close()
                'obtengo el correlativo a seguir
                correlativo = correlativo + 1
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo de recibos," & vbCrLf & "-Verifica tu conexion a internet e intenta grabar el recibo nuevamente. " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            'muestro mensaje con el correlativo a imprimir
            'realizo la grabacion
            If t_cobrado.Text = "0.00" Then
                MessageBox.Show("No puedes grabar un recibo a valor cero")
            End If
            'nuevo recibo DIRECTO
            If tarjeta1 <> 0 Then
                voucher1 = InputBox("Introduzca el numero de Autorizacion", "No.")
                t_tarjeta = InputBox("Indique el tipo de POS Utilizado:  Neonet= '1'   Credomatic= '2'", "Tipo POS:")
            End If

            'obtengo el correlativo a seguir
            '  correlativo = correlativo + 1
            'muestro mensaje con el correlativo a imprimir
            'realizo la grabacion en base de datos G-OPTICS
            Try
                'realizo la grabacion en la base de datos de G-optics
                conexion.Open()
                consulta = "INSERT INTO recibos(id_agencia,recibo,serierec,fecha,valor,pagono,nombre,observa,anticipo,este_pago,tipo_pago,voucher,efectivo,tarjeta,telefono,fecha_prometida,direccion,marca_armazon,material,color,modelo_armazon,id_vendedor,vendedor,p_anterior, orden) values('" & dashboard.no_agencia & "','" & correlativo & "','" & serie & "','" & fecha.Text & "','" & total1 & "','1','" & nombre.Text & "','" & obs.Text & "','x', '" & Totalcobrado1 & "','" & t_tarjeta & "','" & voucher1 & "','" & efectivo1 & "','" & tarjeta1 & "','" & telefono.Text & "','" & f_prometida.Text & "','" & nombrepf.Text & "','" & marca.Text & "','" & material.Text & "','" & nit.Text & "','" & armazon.Text & "','" & id_vendedor & "','" & txt_vendedor.Text & "','" & anticipoanterior & "','" & orden & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()

                'actualizo orden y elimino el saldo 
                conexion.Open()
                consulta = "UPDATE orden set abono='" & anticipo1 & "', saldo='" & saldo_pendiente.Text & "', status='G' where no_orden='" & orden & "' and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()

            Catch ex As Exception
                MsgBox("No fue posible grabar el nuevo recibo," & vbCrLf & "-Verifica tu conexion a internet  e intenta grabar nuevamente el recibo." &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            Try
                'actualizo correlativo de recibos
                conexion.Open()
                consulta = "UPDATE catagencias set recibos='" & correlativo & "'  where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                pregunta = MsgBox("Recibo Numero 00" & correlativo & "  grabado con exito." & vbCrLf & vbCrLf & "¿Desea Imprimir el recibo?", vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
                If pregunta = vbYes Then
                    'imprimo el recibo formato ticket
                    Try
                        Dim dialog As New PrintPreviewDialog()
                        dialog.Document = print_tiket
                        print_tiket.PrinterSettings.PrinterName = "TICKET"
                        DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                        dialog.PrintPreviewControl.Zoom = 1.5
                        dialog.ShowDialog()
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show("La Impresion ha fallado, verifica que la impresora de ticket este encendida y conectada al equipo.", ex.ToString())
                    End Try
                Else
                    'si no quiero imprimir solo cierro la ventana
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("No fue posible actualizar el correlativo de recibos," & vbCrLf & "-El recibo si se grabo,  cierra esta ventana e imprimelo desde el menu > consultas re impresion" &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                'Return
            End Try
        ElseIf dedonde = 1 Then
            If t_cobrado.Text = "0.00" Or t_cobrado.Text = 0 Then
                MessageBox.Show("No puedes grabar un recibo a valor cero")
                Return
                efectivo.Focus()

            End If
            'nuevo recibo DIRECTO
            If tarjeta1 <> 0 Then
                voucher1 = InputBox("Introduzca el numero de Voucher", "No.")
                t_tarjeta = InputBox("Indique el tipo de POS Utilizado:  Neonet= '1'   Credomatic= '2'", "Tipo POS:")
            End If
            'obtengo el numero de recibo 
            'obtengo el numero de recibo 
            Try
                conexiongoptics.Open()
                consulta = "select MAX(recibo)from recibos where id_agencia='" & dashboard.no_agencia & "';"
                com = New MySqlCommand(consulta, conexiongoptics)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = dashboard.serie_recibo
                rs.Close()
                conexiongoptics.Close()
                'obtengo el correlativo a seguir
                correlativo = correlativo + 1
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo de recibos," & vbCrLf & "-Verifica tu conexion a internet,  intenta dar click en grabar nuevamente. " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            'muestro mensaje con el correlativo a imprimir
            'realizo la grabacion en base de datos G-OPTICS
            Try
                'realizo la grabacion en la base de datos de G-optics
                conexion.Open()
                consulta = "INSERT INTO recibos(id_agencia,recibo,serierec,fecha,valor,pagono,nombre,observa,anticipo,este_pago,tipo_pago,voucher,efectivo,tarjeta,telefono,fecha_prometida,direccion,marca_armazon,material,color,modelo_armazon,id_vendedor,vendedor) values('" & dashboard.no_agencia & "','" & correlativo & "','" & serie & "','" & fecha.Text & "','" & total1 & "','1','" & nombre.Text & "','" & obs.Text & "','x', '" & anticipo1 & "','" & t_tarjeta & "','" & voucher1 & "','" & efectivo1 & "','" & tarjeta1 & "','" & telefono.Text & "','" & f_prometida.Text & "','" & nombrepf.Text & "','" & marca.Text & "','" & material.Text & "','" & nit.Text & "','" & armazon.Text & "','" & id_vendedor & "','" & txt_vendedor.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()

            Catch ex As Exception
                MsgBox("No fue posible grabar el nuevo recibo," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            Try
                'actualizo correlativo de recibos
                conexion.Open()
                consulta = "UPDATE catagencias set recibos='" & correlativo & "'  where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                pregunta = MsgBox("Recibo Numero 00" & correlativo & "  grabado con exito." & vbCrLf & vbCrLf & "¿Desea Imprimir el recibo?", vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
                If pregunta = vbYes Then
                    'imprimo el recibo formato ticket
                    Try
                        Dim dialog As New PrintPreviewDialog()
                        dialog.Document = print_tiket

                        print_tiket.PrinterSettings.PrinterName = "TICKET"

                        DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                        dialog.PrintPreviewControl.Zoom = 1.5
                        dialog.ShowDialog()
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show("La Impresion ha fallado, verifica que la impresora de ticket este encendida y conectada al equipo.", ex.ToString())
                    End Try
                Else
                    'si no quiero imprimir solo cierro la ventana
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("No fue posible actualizar el correlativo de los recibos," & vbCrLf & "- El recibo si fue grabado, por favor cierra la ventana del recibo e imprimelo desde el menu de Consultas>Re imprimir." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub recibos_nuevo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()

        End If
    End Sub

    Private Sub nombre_TextChanged(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub

    Private Sub efectivo_TextChanged(sender As Object, e As EventArgs) Handles efectivo.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub obs_TextChanged(sender As Object, e As EventArgs) Handles obs.TextChanged

    End Sub

    Private Sub telefono_TextChanged(sender As Object, e As EventArgs) Handles telefono.TextChanged

    End Sub

    Private Sub tarjeta_TextChanged(sender As Object, e As EventArgs) Handles tarjeta.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
    'limito para que no utilicen la tecla de tabulador
    Protected Overrides Function ProcessDialogKey(
    ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData <> Keys.Tab Then
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function
    Private Sub recibos_nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'nit existe como true para no grabar nadda
        nitexiste = True
        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center
        TopRigth.Alignment = StringAlignment.Far

        fecha_enletras.Text = DateTime.Now.ToLongDateString()
        efectivotemp = 0
        tarjetatemp = 0
        If dedonde = 2 Then
            'CARGO DESDE ANULACION DE RECIBOS
            Button3.Visible = False
            Button1.Enabled = True
            Button1.Text = "Anular"
            'cambio la imagen del boton guardar para que sea anular 
            Button1.Image = My.Resources.ResourceManager.GetObject("cancel")

            'busco el detalle del recibo
            Try
                conexion.Open()
                consulta = "SELECT nombre,valor,observa,efectivo,tarjeta,este_pago,fecha,direccion,telefono,fecha_prometida,modelo_armazon,marca_armazon,color,material,vendedor,orden,p_anterior from  recibos WHERE recibo='" & documento & "' and serierec='" & serie & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                total.Text = rs(1)
                id_vendedor = 0
                efectivo.Text = rs(3)
                tarjeta.Text = rs(4)
                t_cobrado.Text = rs(5)
                fecha.Text = rs(6)
                nombrepf.Text = rs(7)
                telefono.Text = rs(8)
                f_prometida.Text = rs(9)
                armazon.Text = rs(10)
                marca.Text = rs(11)
                nit.Text = rs(12)
                material.Text = rs(13)
                txt_vendedor.Text = rs(14)
                orden = rs(15)
                anterior.Text = rs(16)
                rs.Close()
                conexion.Close()
                'realizo la resta del total cobrado contra el total de la compra
                saldo_pendiente.Text = Val(total.Text) - Val(t_cobrado.Text) - Val(anterior.Text)
                'muestro la cantidad cobrada en letras
                Dim largo = Len(CStr(Format(CDbl(t_cobrado.Text), "#,###.00")))
                Dim decimales = Mid(CStr(Format(CDbl(t_cobrado.Text), "#,###.00")), largo - 2)
                'enletras.Text = GetMyNumberToWords(t_cobrado.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
                total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
                efectivo.Text = Format(CType(efectivo.Text, Decimal), "#,##0.00")
                tarjeta.Text = Format(CType(tarjeta.Text, Decimal), "#,##0.00")
                t_cobrado.Text = Format(CType(t_cobrado.Text, Decimal), "#,##0.00")
                saldo_pendiente.Text = Format(CType(saldo_pendiente.Text, Decimal), "#,##0.00")
                Label2.Text = "Motivo Anulacion"
                If orden = 0 Then
                Else
                    Advertencia.Text = "Recibo anexado a orden de trabajo  No." & orden & "  para Anularlo debes anular la orden primero."
                End If

            Catch ex As Exception
                MsgBox("Error al obtener el detalle del recibo. " & vbCrLf & "-Verifica tu conexion a internet y abre de nuevo la ventana para anular." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            nombre.Enabled = False
            nombrepf.Enabled = False
            telefono.Enabled = False
            f_prometida.Enabled = False
            total.Enabled = False
            efectivo.Enabled = False
            tarjeta.Enabled = False
            saldo_pendiente.Enabled = False

            nit.Enabled = False
            armazon.Enabled = False
            marca.Enabled = False
            txt_vendedor.Enabled = False
            'separo la fecha que tenga el textbox fecha
            ano = Mid(fecha.Text, 7, Len(fecha.Text) - 1)
            mes = Mid(fecha.Text, 4, Len(fecha.Text) - 8)
            dia = Mid(fecha.Text, 1, Len(fecha.Text) - 8)
            correlativo = documento
            obs.Clear()
            obs.Select()

        ElseIf dedonde = 3 Then
            'llamo desde consulta de recibo
            Button3.Visible = True
            Button1.Enabled = False
            Button1.Visible = True
            Button3.Text = "RE IMPRIMIR"
            'busco el detalle del recibo
            Try
                conexion.Open()
                consulta = "SELECT nombre,valor,observa,efectivo,tarjeta,este_pago,fecha,direccion,telefono,fecha_prometida,modelo_armazon,marca_armazon,color,material,vendedor,orden,p_anterior,no_factura,seriefac  from  recibos WHERE recibo='" & documento & "' and serierec='" & serie & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                total.Text = rs(1)
                id_vendedor = 0
                obs.Text = rs(2)
                efectivo.Text = rs(3)
                tarjeta.Text = rs(4)
                t_cobrado.Text = rs(5)
                fecha.Text = rs(6)
                nombrepf.Text = rs(7)
                telefono.Text = rs(8)
                f_prometida.Text = rs(9)
                armazon.Text = rs(10)
                marca.Text = rs(11)
                nit.Text = rs(12)
                material.Text = rs(13)
                txt_vendedor.Text = rs(14)
                orden = rs(15)
                anterior.Text = rs(16)
                Factura = rs(17)
                Serie_fact = rs(18)
                rs.Close()
                conexion.Close()
                'realizo la resta del total cobrado contra el total de la compra
                saldo_pendiente.Text = Val(total.Text) - Val(t_cobrado.Text) - Val(anterior.Text)
                'muestro la cantidad cobrada en letras
                Dim largo = Len(CStr(Format(CDbl(t_cobrado.Text), "#,###.00")))
                Dim decimales = Mid(CStr(Format(CDbl(t_cobrado.Text), "#,###.00")), largo - 2)
                'enletras.Text = GetMyNumberToWords(t_cobrado.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
                total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
                efectivo.Text = Format(CType(efectivo.Text, Decimal), "#,##0.00")
                tarjeta.Text = Format(CType(tarjeta.Text, Decimal), "#,##0.00")
                t_cobrado.Text = Format(CType(t_cobrado.Text, Decimal), "#,##0.00")
                saldo_pendiente.Text = Format(CType(saldo_pendiente.Text, Decimal), "#,##0.00")
                anterior.Text = Format(CType(anterior.Text, Decimal), "#,##0.00")
                If orden = 0 Then
                Else
                    Advertencia.Text = "Recibo anexado a orden de trabajo  No." & orden
                End If
                If Factura = 0 Then
                    Advertencia1.Text = ""
                Else
                    Advertencia1.Text = "Recibo anexado a factura " & Factura & " Serie " & Serie_fact
                End If
            Catch ex As Exception
                MsgBox("No fue posible obtener toda la informacion del recibo. " & vbCrLf & "- Verifica tu conexion a internet." & vbCrLf & "-Cierra la ventana y vuelve a intentarlo." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            nombre.Enabled = False
            nombrepf.Enabled = False
            telefono.Enabled = False
            f_prometida.Enabled = False
            total.Enabled = False
            efectivo.Enabled = False
            tarjeta.Enabled = False
            saldo_pendiente.Enabled = False
            obs.Enabled = False
            nit.Enabled = False
            armazon.Enabled = False
            marca.Enabled = False
            txt_vendedor.Enabled = False
            'separo la fecha que tenga el textbox fecha
            ano = Mid(fecha.Text, 7, Len(fecha.Text) - 1)
            mes = Mid(fecha.Text, 4, Len(fecha.Text) - 8)
            dia = Mid(fecha.Text, 1, Len(fecha.Text) - 8)
            correlativo = documento
            If anterior.Text <> "" Then
                Label20.Visible = True
                anterior.Visible = True
            End If

        ElseIf dedonde = 1 Then
            total.Text = 0
            'llamo desde nuevo recibo
            Dim hoy As Date = Date.Now
            Dim fechafinal As Date = hoy.AddDays(4)
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            f_prometida.Text = fechafinal.ToString("ddMMyyyy")
            telefono.Text = "0000-0000"
            'igualo mi variable a cero para evitar errores 
            nombre.Focus()
            correlativo = 0
            'obtengo el numero de recibo 
            Try
                conexion.Open()
                consulta = "select MAX(recibo)from recibos where id_agencia='" & dashboard.no_agencia & "';"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                ' serie = rs(1)
                rs.Close()
                conexion.Close()
                'obtengo el correlativo a seguir
                correlativo = correlativo + 1
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo de recibos, la ventana se cerrara." & vbCrLf & "- Verifica tu conexion a internet." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()

                Button1.Enabled = False
                nombre.Enabled = False
                GroupBox2.Enabled = False
            End Try

            numero.Text = "Recibo 000" & correlativo
        ElseIf dedonde = 4 Then
            'abro desde recibo de abono para orden de trabajo 
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            Label20.Visible = True
            anterior.Visible = True
            'obtengo el numero de recibo 
            Try
                conexion.Open()
                consulta = "select MAX(recibo)from recibos where id_agencia='" & dashboard.no_agencia & "';"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                'serie = rs(1)
                rs.Close()
                conexion.Close()
                'obtengo el correlativo a seguir
                correlativo = Val(correlativo) + 1
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo de recibos, la ventana se cerrara." & vbCrLf & "-Verifica tu conexion a internet." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()

                Button1.Enabled = False
                nombre.Enabled = False
                GroupBox2.Enabled = False
            End Try

            numero.Text = "Doucmento 000" & correlativo
            f_prometida.Text = DateTime.Now.ToString("ddMMyyyy")
            'busco todos los recibos asociados a la orden
            Try
                conexion.Open()
                consulta = "select recibo,sum(este_pago) from recibos where id_agencia='" & dashboard.no_agencia & "' and orden='" & orden & "' and estado='I' group by orden"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlanterior = rs(0)
                anterior.Text = rs(1)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo de recibos, la ventana se cerrara." & vbCrLf & "- Verifica tu conexion a internet." &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()

                Button1.Enabled = False
                nombre.Enabled = False
                GroupBox2.Enabled = False
            End Try
            anticipoanterior = anterior.Text
            total1 = total.Text
            Calcular()
            obs.Text = "Recibo Abono OT " & orden & " anticipo anterior " & correlanterior
            Button1.Enabled = False
        End If


    End Sub

    Private Sub txt_vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vendedor.KeyPress
        'limito el textbox para que solo acepte el codigo del vendedor
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            If txt_vendedor.Text = "" Then
                'si no ingreso codigo de vendedor entonces busco en el catologo de ayuda
                muestra_vendedor.dedonde = 3
                muestra_vendedor.ShowDialog()
                obs.Focus()
                txt_vendedor.Enabled = False
            Else
                'realizo la busquedad en base al codigo del vendedor ingresado
                Try
                    conexion.Open()
                    consulta = "select id_codigo,nombre from vendedores where id_codigo='" & txt_vendedor.Text & "' and status='A'"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    id_vendedor = rs(0)
                    txt_vendedor.Text = rs(1)
                    rs.Close()
                    conexion.Close()
                    obs.Focus()
                    txt_vendedor.Enabled = False
                Catch ex As Exception

                    MessageBox.Show("El codigo de asesor ingresado no existe, por favor verifica e intenta nuevamente")
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub txt_vendedor_TextChanged(sender As Object, e As EventArgs) Handles txt_vendedor.TextChanged

    End Sub

    Private Sub nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            If nombre.Text = " " Then
                busca_hclinica.dedonde = 1
                busca_hclinica.ShowDialog()
                f_prometida.Focus()
            Else
                telefono.Focus()
            End If
        End If
    End Sub
    Private Sub valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles efectivo.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then

            tarjeta.Focus()
        End If
    End Sub

    Private Sub Print_tiket_PrintPage(sender As Object, e As PrintPageEventArgs) Handles print_tiket.PrintPage
        Dim fuente, fuente1, fuente2, fuente3, fuente4, fuente5 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        fuente5 = New Font("Arial", 9, FontStyle.Bold)
        fuente4 = New Font("Arial", 9, FontStyle.Bold)
        fuente1 = New Font("Consolas", 8)
        fuente2 = New Font("Arial", 8)
        fuente3 = New Font("Arial", 12, FontStyle.Regular)
        Dim prFont As New Font("Consolas", 7, FontStyle.Bold)
        'defino coordenada en horizontal 
        Dim CurX As Integer = 0
        'defino coordenada en vertical 
        Dim CurY As Integer = 45
        'defino ancho del rectangulo que tomo como base para imprimir centrado 
        Dim iWidth As Integer = 288
        Dim cellRect As RectangleF
        cellRect = New RectangleF()
        cellRect.Location = New Point(CurX, CurY)
        cellRect.Size = New Size(iWidth, CurY)
        'imprimo nombre de la empresa 
        e.Graphics.DrawImage(PictureBox1.Image, 70, 0, 150, 79)
        'imprimo tipo de documento 
        cellRect.Location = New Point(CurX, CurY + 37)
        e.Graphics.DrawString("RECIBO DE PAGO", fuente3, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 52)
        e.Graphics.DrawString(serie & "  - " & correlativo, fuente3, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 69)
        e.Graphics.DrawString("FECHA RECIBO " & fecha.Text, fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 85)
        e.Graphics.DrawString("---------   SUCURSAL   --------- ", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 100)
        e.Graphics.DrawString(dashboard.direcciontienda & ", " & dashboard.SySMuni & ", " & dashboard.SysDepto, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 151)
        e.Graphics.DrawString("TEL: " & dashboard.pbx & "  WHATSAPP: " & dashboard.telefonotienda, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 165)
        e.Graphics.DrawString(dashboard.correotienda, fuente, Brushes.Black, cellRect, TopCenter)
        'IMPRIMO DATOS DEL CLIENTE 
        cellRect.Location = New Point(CurX, CurY + 188)
        e.Graphics.DrawString("------   DATOS DEL CLIENTE   ------ ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 205)
        e.Graphics.DrawString("CLIENTE:  " & nombre.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 230)
        e.Graphics.DrawString("TELEFONO:  " & telefono.Text, fuente4, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 245)
        e.Graphics.DrawString("FECHA PROMETIDA:  " & f_prometida.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 260)
        e.Graphics.DrawString("NIT P/FACTURAR:  " & nit.Text, fuente4, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 275)
        e.Graphics.DrawString("NOMBRE P/FACTURAR:  " & nombrepf.Text, fuente, Brushes.Black, cellRect, TopCenter)
        'detallo productos 
        cellRect.Location = New Point(CurX, CurY + 315)
        e.Graphics.DrawString("------------   DETALLE   ----------- ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 330)
        e.Graphics.DrawString("ARO:", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 345)
        e.Graphics.DrawString(armazon.Text, fuente4, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 375)
        'e.Graphics.DrawString("MATERIAL:", fuente, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 390)
        'e.Graphics.DrawString(material.Text, fuente4, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 373)
        e.Graphics.DrawString("OBSERVACIONES:", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 388)
        e.Graphics.DrawString(obs.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 463)
        e.Graphics.DrawString("------------   TOTALES   ------------", fuente, Brushes.Black, cellRect, TopCenter)
        e.Graphics.DrawString("TOTAL COMPRA ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 522)
        cellRect.Location = New Point(CurX - 25, CurY + 477)
        e.Graphics.DrawString(total.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        ' e.Graphics.DrawString(total.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 485)
        e.Graphics.DrawString("ABONOS ANTERIORES ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 536)
        cellRect.Location = New Point(CurX - 25, CurY + 490)
        e.Graphics.DrawString(anterior.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        ' e.Graphics.DrawString(anterior.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 497)
        e.Graphics.DrawString("COBRADO EN EFECTIVO", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 550)
        cellRect.Location = New Point(CurX - 25, CurY + 506)
        e.Graphics.DrawString(efectivo.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        '  e.Graphics.DrawString(efectivo.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 510)
        e.Graphics.DrawString("COBRADO EN TARJETA ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 566)
        cellRect.Location = New Point(CurX - 25, CurY + 521)
        e.Graphics.DrawString(tarjeta.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        'e.Graphics.DrawString(tarjeta.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 525)
        e.Graphics.DrawString("TOTAL COBRADO ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 580)
        cellRect.Location = New Point(CurX - 25, CurY + 537)
        e.Graphics.DrawString(t_cobrado.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        '  e.Graphics.DrawString(t_cobrado.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 540)
        cellRect.Location = New Point(CurX, CurY + 536)
        e.Graphics.DrawString("____________________________________", fuente, Brushes.Black, cellRect, TopCenter)
        e.Graphics.DrawString("PENDIENTE DE PAGO ", New Font(fuente, FontStyle.Bold), Brushes.Black, 20, 597)
        cellRect.Location = New Point(CurX - 25, CurY + 552)
        e.Graphics.DrawString(saldo_pendiente.Text, fuente5, Brushes.Black, cellRect, TopRigth)
        'e.Graphics.DrawString(saldo_pendiente.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 557)

        cellRect.Location = New Point(CurX, CurY + 655)
        e.Graphics.DrawString("F:________________________________", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 670)
        e.Graphics.DrawString("Firma y Sello Optica", fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 685)
        e.Graphics.DrawString("** ATENDIO **", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 700)
        e.Graphics.DrawString(txt_vendedor.Text, fuente, Brushes.Black, cellRect, TopCenter)

        '  cellRect.Location = New Point(CurX, CurY + 690)
        '  e.Graphics.DrawString("** TÉRMINOS Y CONDICIONES **", fuente, Brushes.Black, cellRect, TopCenter)
        '  cellRect.Location = New Point(CurX, CurY + 710)
        '  e.Graphics.DrawString("*Cada orden contiene los aros y lentes seleccionados por el cliente, NO SE ACEPTAN CAMBIOS O DEVOLUCIONES POSTERIORES A SU COMPRA.", fuente2, Brushes.Black, cellRect, TopLeft)
        '  cellRect.Location = New Point(CurX, CurY + 755)
        ' e.Graphics.DrawString("*Optical Plus+  No se hace responsable por garantías con RECETAS EXTERNAS.", fuente2, Brushes.Black, cellRect, TopLeft)

        '  cellRect.Location = New Point(CurX, CurY + 790)
        '  e.Graphics.DrawString("*Optical Plus+  Requiere como mínimo el 50% de anticipo, sobre la totalidad de la compra para poder procesar su orden de trabajo.", fuente2, Brushes.Black, cellRect, TopLeft)

        '  cellRect.Location = New Point(CurX, CurY + 835)
        '   e.Graphics.DrawString("*Se debe presentar recibo o factura para recoger su orden procesada.", fuente2, Brushes.Black, cellRect, TopLeft)

        '   cellRect.Location = New Point(CurX, CurY + 865)
        '   e.Graphics.DrawString("*Optica Sosa  No se hace responsable por órdenes de trabajo no recogidas después de los 30 días posteriores al presente documento.", fuente2, Brushes.Black, cellRect, TopLeft)

        '  cellRect.Location = New Point(CurX, CurY + 910)
        '  e.Graphics.DrawString("*Toda orden de trabajo tiene 6 meses de garantía por desperfecto de fábrica, NO APLICA EN: mercadería en liquidación, paquetes en promocion, gotas, lentes de contacto y recetas externas.", fuente2, Brushes.Black, cellRect, TopLeft)

        '  cellRect.Location = New Point(CurX, CurY + 970)
        '  e.Graphics.DrawString("*Las graduaciones realizadas por Optical Plus+, tienen garantía de 15 días por adaptación posterior a la entrega, NO NOS HACEMOS REPONSABLES DESPUES DE EL TIEMPO ESTIPULADO.", fuente2, Brushes.Black, cellRect, TopLeft)
        '  cellRect.Location = New Point(CurX, CurY + 1025)
        '  e.Graphics.DrawString("*SE DEBERÁ PRESENTAR FACTURA PARA CUALQUIER CONSULTA O COMENTARIO POSTERIOR A LA COMPRA.", fuente2, Brushes.Black, cellRect, TopCenter)

        '  e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(cellRect))
        'imprimo QR atencion al cliente
        '  e.Graphics.DrawImage(PictureBox2.Image, 95, 786, 100, 100)
        ' cellRect.Location = New Point(CurX, CurY + 840)
        ' e.Graphics.DrawString("Escanea para hablar con atencion al cliente.", fuente, Brushes.Black, cellRect, TopCenter)
    End Sub


    Private Sub telefono_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txt_vendedor.Focus()

        End If
    End Sub



    Private Sub obs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles obs.KeyPress
        If Asc(e.KeyChar) = 13 Then
            total.Focus()

        End If
    End Sub



    Private Sub total_KeyPress(sender As Object, e As KeyPressEventArgs) Handles total.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then

            efectivo.Focus()
        End If
    End Sub

    Private Sub total_Leave(sender As Object, e As EventArgs) Handles total.Leave

    End Sub

    Private Sub total_TextChanged(sender As Object, e As EventArgs) Handles total.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'realizo la impresion del recibo
        pregunta = MsgBox("Recibo Numero 00" & documento & " ." & vbCrLf & vbCrLf & "¿Desea Imprimir el recibo?", vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
        If pregunta = vbYes Then

            'imprimo desde la agencia 2 por tiket 
            Try
                Dim dialog As New PrintPreviewDialog()
                dialog.Document = print_tiket
                'defino en donde voy a realizar la impresion 
                'If dashboard.ip_maquina.Text = "192.168.47.2" Then
                '    print_tiket.PrinterSettings.PrinterName = "\\192.168.47.4\TICKET"
                'Else
                print_tiket.PrinterSettings.PrinterName = "TICKET"
                'End If
                ' print_tiket.PrinterSettings.PrinterName = "TICKET"
                DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                dialog.PrintPreviewControl.Zoom = 1.5
                dialog.ShowDialog()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("La Impresion ha fallado, verifica que la impresora de ticket este encendida y conectada al equipo.", ex.ToString())
            End Try
        Else
            Return
        End If
    End Sub

    Private Sub tarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tarjeta.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            Button1.Focus()
        End If
    End Sub
    Public Function Calcular() As String
        'funcion que realiza el calculo en el evento focus de los campos efectivo/tarjeta
        If efectivo.Text = "" Or efectivo.Text = 0.00 Then
            efectivo.Text = 0
        End If
        If tarjeta.Text = "" Or tarjeta.Text = 0.00 Then
            tarjeta.Text = 0
        End If
        'realizo la validacion, si es recibo nuevo hago proceso normal, si es recibo de abono incluyo en la resta del saldo pendiente el abono anterior 
        If dedonde = 1 Then
            'recibo nuevo
            anticipo1 = Val(efectivotemp) + Val(tarjetatemp)
            efectivo1 = efectivotemp
            tarjeta1 = tarjetatemp
            t_cobrado.Text = Val(efectivo1) + Val(tarjeta1)
        ElseIf dedonde = 4 Then
            'recibo de abono/cancelacion
            anticipo1 = Val(efectivotemp) + Val(tarjetatemp) + Val(anticipoanterior)
            Totalcobrado1 = Val(efectivotemp) + Val(tarjetatemp)
            efectivo1 = efectivotemp
            tarjeta1 = tarjetatemp
            t_cobrado.Text = Val(efectivo1) + Val(tarjeta1)
        End If

        If Val(anticipo1) > Val(total1) Then
            MessageBox.Show("No puedes realizar un cobro mayor al del valor del trabajo")
            Button1.Enabled = False
            tarjeta.Text = 0
            efectivo.Text = 0
            efectivotemp = 0
            tarjetatemp = 0
            Totalcobrado1 = 0
            If dedonde = 1 Then
                'recibo nuevo 
                anticipo1 = Val(efectivotemp) + Val(tarjetatemp)
                efectivo1 = efectivotemp
                tarjeta1 = tarjetatemp
                t_cobrado.Text = Val(efectivo1) + Val(tarjeta1)
            ElseIf dedonde = 4 Then
                anticipo1 = Val(efectivotemp) + Val(tarjetatemp) + Val(anticipoanterior)
                efectivo1 = efectivotemp
                tarjeta1 = tarjetatemp
                t_cobrado.Text = Val(efectivo1) + Val(tarjeta1)
                Totalcobrado1 = Val(efectivo1) + Val(tarjeta1)
            End If
        Else
            saldo_pendiente.Text = Val(total1) - Val(anticipo1)
            t_cobrado.Text = Format(CType(t_cobrado.Text, Decimal), "#,##0.00")
            total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
            efectivo.Text = Format(CType(efectivo.Text, Decimal), "#,##0.00")
            tarjeta.Text = Format(CType(tarjeta.Text, Decimal), "#,##0.00")
            saldo_pendiente.Text = Format(CType(saldo_pendiente.Text, Decimal), "#,##0.00")
            anterior.Text = Format(CType(anterior.Text, Decimal), "#,##0.00")
            Button1.Enabled = True
            If dedonde = 4 Then
                If saldo_pendiente.Text = "0.00" Then
                    obs.Text = "Recibo Cancelacion OT " & orden & " anticipo anterior " & correlanterior
                Else
                    obs.Text = "Recibo Abono OT " & orden & " anticipo anterior " & correlanterior
                End If
            End If
        End If
    End Function
    Private Sub direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombrepf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            armazon.Focus()
        End If
    End Sub

    Private Sub direccion_TextChanged(sender As Object, e As EventArgs) Handles nombrepf.TextChanged

    End Sub

    Private Sub telefono_KeyPress1(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            f_prometida.Focus()
        End If
    End Sub
    Private Sub telefono_MaskInputRejected_1(sender As Object, e As MaskInputRejectedEventArgs)
    End Sub

    Private Sub f_prometida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles f_prometida.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            nit.Focus()
        End If
    End Sub
    Private Sub f_prometida_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles f_prometida.MaskInputRejected

    End Sub

    Private Sub telefono_KeyPress2(sender As Object, e As KeyPressEventArgs) Handles telefono.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            f_prometida.Focus()
        End If
    End Sub

    Private Sub armazon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles armazon.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            If armazon.Text = "" Then
                marca.Enabled = False

                armazon.Text = "SIN ARO"
                marca.Clear()
                txt_vendedor.Focus()
            Else
                'si ingreso el codigo del aro busco la info
                Try
                    conexion.Open()
                    consulta = "select producto,id_marca,id_codigo from inventario where id_codigo='" & armazon.Text & "' and linea='1'"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    armazon.Text = "(" & rs(2) & ") " & rs(0)
                    marca.Text = rs(1)
                    rs.Close()
                    conexion.Close()
                    txt_vendedor.Focus()
                Catch ex As Exception
                    conexion.Close()
                    MsgBox("El codigo ingresado no pertenece a un aro o bien no existe, por favor verifica nuevamente" &
                  vbCrLf & vbCrLf,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Information)

                End Try
            End If
        End If
    End Sub


    Private Sub armazon_TextChanged(sender As Object, e As EventArgs) Handles armazon.TextChanged

    End Sub

    Private Sub marca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles marca.KeyPress
        If Asc(e.KeyChar) = 13 Then
            nit.Focus()
        End If
    End Sub

    Private Sub marca_TextChanged(sender As Object, e As EventArgs) Handles marca.TextChanged

    End Sub

    Private Sub color_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nit.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
            If nit.Text = "" Then
                nombrepf.Text = "CONSUMIDOR FINAL"
                nit.Text = "CF"
                armazon.Focus()
            Else
                'verifico si el NIT existe en la base de datos
                Try
                    conexion.Open()
                    consulta = "select nit,nombre from b_nits where nit='" & nit.Text & "' "
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    nombrepf.Text = rs(1)
                    armazon.Focus()
                    conexion.Close()
                    nitexiste = True
                Catch ex As Exception
                    conexion.Close()
                    'realizo la validacion del numero de nit en base de datos de INFILE para obtener el nombre del contribuyente
                    Dim api = New DBApi()
                    Dim persona = New Persona()
                    persona.emisor_codigo = dashboard.Sysaliasfel
                    persona.emisor_clave = dashboard.Sysllavefel
                    persona.nit_consulta = nit.Text
                    Dim url = "https://consultareceptores.feel.com.gt/rest/action"
                    Dim headers = New List(Of Parametro) From {
                        New Parametro("Authorization", "bearer asdasdas"),
                        New Parametro("Cookie", "asdasdasdas")
                    }
                    Dim parametros = New List(Of Parametro)
                    Dim response = api.Post(url, headers, parametros, persona)

                    Dim result = JsonConvert.DeserializeObject(Of respuesta)(response)

                    If result.nombre.ToString = "" Then
                        MessageBox.Show("NIT NO EXISTE POR FAVOR VERIFICA")
                        nit.Text = ""
                    Else
                        nombrepf.Text = result.nombre.ToString()
                        armazon.Focus()
                        nitexiste = False
                    End If
                End Try
            End If
        End If
    End Sub
    Class respuesta
        Public Property nit As String
        Public Property nombre As String

    End Class

    Private Sub color_TextChanged(sender As Object, e As EventArgs) Handles nit.TextChanged

    End Sub

    Private Sub material_KeyPress(sender As Object, e As KeyPressEventArgs) Handles material.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_vendedor.Focus()
        End If
    End Sub

    Private Sub material_TextChanged(sender As Object, e As EventArgs) Handles material.TextChanged

    End Sub

    Private Sub txt_vendedor_MouseClick(sender As Object, e As MouseEventArgs) Handles txt_vendedor.MouseClick

    End Sub

    Private Sub tarjeta_LostFocus(sender As Object, e As EventArgs) Handles tarjeta.LostFocus
        tarjeta.Text = Replace(tarjeta.Text, ",", "")
        tarjetatemp = tarjeta.Text
        Calcular()
    End Sub

    Private Sub efectivo_LostFocus(sender As Object, e As EventArgs) Handles efectivo.LostFocus
        efectivo.Text = Replace(efectivo.Text, ",", "")
        efectivotemp = efectivo.Text
            Calcular()


    End Sub

    Private Sub total_LostFocus(sender As Object, e As EventArgs) Handles total.LostFocus
        'envio el monto ingresado a mi variable total 
        total.Text = Replace(total.Text, ",", "")
        total1 = 0
        total1 = Val(total.Text)
    End Sub
End Class