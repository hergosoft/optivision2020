Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class cobrar_orden
    Public total_orden, nombre, fecha, id_vendedor, dedonde, anticiposapp(3), recibo_ant1, nit, nombrepf, total_anticipos As String
    Dim total_orden1, saldo_pendiente, este_pag, consulta, correlativo, serie, pregunta, m_fecha(2), m_nombre(2), m_cantidadletras(2), m_concepto(2), m_total(2), m_estepago(2), m_saldo(2), m_advertencia(2), m_direccion(2), m_armazon(2), m_material(2), m_autorizacion(2), m_tarjeta(2), m_efectivo(2), m_valor(2), m_telefono(2), m_fprometida(2), efectivo, tarjeta, voucher1, t_tarjeta As String
    Dim Cefectivo, Ctarjeta, Ctotal As Double
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'realizo la impresion del recibo
        pregunta = MsgBox("Recibo Numero 00" & correlativo & " ." & vbCrLf & vbCrLf & "¿Desea Imprimir el recibo?", vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
        If pregunta = vbYes Then

            'imprimo desde la agencia 2 por tiket 
            Try
                Dim dialog As New PrintPreviewDialog()
                dialog.Document = Print_recibo
                Print_recibo.PrinterSettings.PrinterName = "TICKET"
                DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                dialog.PrintPreviewControl.Zoom = 1.5
                dialog.ShowDialog()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("La Impresion ha fallado", ex.ToString())
            End Try
        Else
            Return
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Print_recibo.PrintPage
        Dim fuente, fuente1, fuente2, fuente3, fuente4 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        fuente4 = New Font("Arial", 9, FontStyle.Bold)
        fuente1 = New Font("Consolas", 8)
        fuente2 = New Font("consolas", 7)
        fuente3 = New Font("Arial", 12, FontStyle.Regular)
        Dim prFont As New Font("Consolas", 7, FontStyle.Bold)
        'defino coordenada en horizontal 
        Dim CurX As Integer = 0
        'defino coordenada en vertical 
        Dim CurY As Integer = 100
        'defino ancho del rectangulo que tomo como base para imprimir centrado 
        Dim iWidth As Integer = 290
        Dim cellRect As RectangleF
        cellRect = New RectangleF()
        cellRect.Location = New Point(CurX, CurY)
        cellRect.Size = New Size(iWidth, CurY + 1050)
        'imprimo nombre de la empresa 
        e.Graphics.DrawImage(PictureBox1.Image, 30, 30, 230, 85)
        'imprimo tipo de documento 

        cellRect.Location = New Point(CurX, CurY + 23)
        e.Graphics.DrawString("RECIBO DE PAGO", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 38)
        e.Graphics.DrawString(serie & "  - " & correlativo, fuente4, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 50)
        e.Graphics.DrawString("FECHA RECIBO " & facturacion_directa.fecha.Text, fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 71)
        e.Graphics.DrawString("---------   SUCURSAL   --------- ", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 86)
        e.Graphics.DrawString(dashboard.direcciontienda, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 141)
        e.Graphics.DrawString("PBX: " & dashboard.pbx & "  DIRECTO: " & dashboard.telefonotienda, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 155)
        e.Graphics.DrawString(dashboard.correotienda, fuente, Brushes.Black, cellRect, TopCenter)
        'IMPRIMO DATOS DEL CLIENTE 
        cellRect.Location = New Point(CurX, CurY + 190)
        e.Graphics.DrawString("------   DATOS DEL CLIENTE   ------ ", fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 205)
        e.Graphics.DrawString("CLIENTE:  " & facturacion_directa.nombre.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 230)
        e.Graphics.DrawString("TELEFONO:  " & facturacion_directa.Telefonocliente.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 245)
        e.Graphics.DrawString("FECHA PROMETIDA:  " & facturacion_directa.fecha.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 260)
        e.Graphics.DrawString("NIT P/FACTURAR:  " & facturacion_directa.nit.Text, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 275)
        e.Graphics.DrawString("NOMBRE P/FACTURAR:  " & facturacion_directa.nombre.Text, fuente, Brushes.Black, cellRect, TopCenter)
        'detallo productos 
        cellRect.Location = New Point(CurX, CurY + 310)
        e.Graphics.DrawString("------------   DETALLE   ----------- ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 325)
        e.Graphics.DrawString("ARO:", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 340)
        e.Graphics.DrawString(facturacion_directa.aro, fuente4, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 375)
        'e.Graphics.DrawString("MATERIAL:", fuente, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 390)
        'e.Graphics.DrawString(material.Text, fuente4, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 425)
        e.Graphics.DrawString("OBSERVACIONES:", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 440)
        e.Graphics.DrawString(TextBox8.Text, fuente, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 470)
        e.Graphics.DrawString("------------   TOTALES   ------------", fuente, Brushes.Black, cellRect, TopCenter)
        e.Graphics.DrawString("TOTAL COMPRA ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 590)
        e.Graphics.DrawString(TextBox3.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 590)
        e.Graphics.DrawString("COBRADO EN EFECTIVO", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 605)
        e.Graphics.DrawString(TextBox6.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 605)
        e.Graphics.DrawString("COBRADO EN TARJETA ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 620)
        e.Graphics.DrawString(TextBox7.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 620)
        e.Graphics.DrawString("TOTAL ANTICIPO ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 635)
        e.Graphics.DrawString(TextBox5.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 635)
        cellRect.Location = New Point(CurX, CurY + 537)
        e.Graphics.DrawString("__________________________________", fuente, Brushes.Black, cellRect, TopCenter)
        e.Graphics.DrawString("PENDIENTE DE PAGO ", New Font(fuente, FontStyle.Regular), Brushes.Black, 20, 655)
        e.Graphics.DrawString(TextBox4.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 200, 655)
        cellRect.Location = New Point(CurX, CurY + 645)
        e.Graphics.DrawString("F:________________________________", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 661)
        e.Graphics.DrawString("Firma y Sello Optica", fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 678)
        e.Graphics.DrawString("** ATENDIO **", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 689)
        e.Graphics.DrawString(facturacion_directa.txt_vendedor.Text, fuente, Brushes.Black, cellRect, TopCenter)


        '  e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(cellRect))
        'imprimo QR atencion al cliente
        'e.Graphics.DrawImage(PictureBox2.Image, 65, 870, 150, 150)
        'cellRect.Location = New Point(CurX, CurY + 925)
        'e.Graphics.DrawString("Escanea para hablar con atencion al cliente.", fuente, Brushes.Black, cellRect, TopCenter)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "0.00" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub

    Dim no_recibo, nombre1, estepago As String
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim adaptador As MySqlDataAdapter
    Dim tabla_medidas As DataTable
    Private Sub cobrar_orden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center

        If recibo_ant1 = 0 Then
            total_orden1 = total_orden
            saldo_pendiente = facturacion_directa.ordsaldo
            total_anticipos = facturacion_directa.ordabono
            saldo_pendiente = Val(total_orden1) - Val(total_anticipos)
            TextBox4.Text = saldo_pendiente
            TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            TextBox5.Text = Format(CType(TextBox5.Text, Decimal), "#,##0.00")
            TextBox3.Text = Format(CType(TextBox3.Text, Decimal), "#,##0.00")
            TextBox6.Text = Format(CType(TextBox6.Text, Decimal), "#,##0.00")
            TextBox7.Text = Format(CType(TextBox7.Text, Decimal), "#,##0.00")
        Else
            Try
                'realizo la busquedad del anticipo agregado a la orden
                conexion.Open()
                consulta = "SELECT recibo,nombre,este_pago from viscobros where recibo='" & recibo_ant1 & "' and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                no_recibo = rs(0)
                nombre1 = rs(1)
                estepago = rs(2)
                rs.Close()
                conexion.Close()
                DataGridView1.Rows.Add(no_recibo, nombre1, estepago)

            Catch ex As Exception
                MsgBox("No fue posible obtener los datos del recibo anterior," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            total_orden1 = total_orden
            saldo_pendiente = facturacion_directa.ordsaldo
            total_anticipos = estepago
            saldo_pendiente = Val(total_orden1) - Val(total_anticipos) - Val(este_pag)
            sumar_dtv.PerformClick()
            TextBox4.Text = saldo_pendiente
            TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            TextBox5.Text = Format(CType(TextBox5.Text, Decimal), "#,##0.00")
            TextBox3.Text = Format(CType(TextBox3.Text, Decimal), "#,##0.00")
            TextBox6.Text = Format(CType(TextBox6.Text, Decimal), "#,##0.00")
            TextBox7.Text = Format(CType(TextBox7.Text, Decimal), "#,##0.00")
        End If
        If dedonde = 2 Then
            TextBox6.Enabled = False
            TextBox7.Enabled = False
        End If



    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        busca_anticipo.total_ordencompra = saldo_pendiente
        busca_anticipo.conteo = Val(contador.Text) + 1
        If dedonde = 1 Then
            efectivo = 0
            tarjeta = 0
            TextBox6.Enabled = False
            TextBox7.Enabled = False
        End If
        busca_anticipo.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'valido si tengo recibos cargados en el dtv de anticipos para liberarlos al momento de cerrar la ventana 
        If DataGridView1.Rows.Count = 0 Then
            Me.Dispose()
        Else
            Try
                conexiongoptics.Open()
                'libero todos los recibos que habia jalado a la orden 
                For Each Fila As DataGridViewRow In DataGridView1.Rows
                    consulta = "UPDATE recibos SET anticipo='x' where recibo='" & Fila.Cells(0).Value & "' and  nombre='" & Fila.Cells(1).Value & "' and id_agencia='" & dashboard.no_agencia & "'"
                    com = New MySqlCommand(consulta, conexiongoptics)
                    com.ExecuteNonQuery()
                Next
                conexiongoptics.Close()
                Me.Dispose()
            Catch ex As Exception
                MsgBox("No fue posible liberar los recibos jalados a la orden," & vbCrLf & "Contacta con Soporte Tecnico " &
                         vbCrLf & vbCrLf & ex.Message,
                         MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexiongoptics.Close()
                Return
            End Try
        End If

    End Sub

    Private Sub sumar_dtv_Click(sender As Object, e As EventArgs) Handles sumar_dtv.Click
        total_anticipos = 0
        saldo_pendiente = 0
        Dim total As DataGridViewRow = New DataGridViewRow()
        For Each total In DataGridView1.Rows
            total_anticipos += Convert.ToDouble(total.Cells(2).Value)
        Next
        Try
            conexiongoptics.Open()
            consulta = "UPDATE recibos set anticipo='' where recibo='" & CStr(total.Cells(0).Value) & "' and id_agencia='" & dashboard.no_agencia & "' and nombre='" & CStr(total.Cells(1).Value) & "' "
            com = New MySqlCommand(consulta, conexiongoptics)
            com.ExecuteNonQuery()
            conexiongoptics.Close()
        Catch ex As Exception
            conexiongoptics.Close()
            MessageBox.Show(ex.ToString)
        End Try
        ' MessageBox.Show("esta es la suma de todos los recibos cargados" & total_anticipos)
        'realizo la resta del valor de la orden contra el total del anticipo para mostrar el saldo pendiente 
        saldo_pendiente = Val(total_orden1) - Val(total_anticipos) - Val(este_pag)
        'MessageBox.Show("Total de la orden " & total_orden1 & "  Total Anticipos " & total_anticipos & " Saldo pendiente " & saldo_pendiente)
        TextBox5.Text = total_anticipos
        TextBox4.Text = saldo_pendiente
        TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
        TextBox5.Text = Format(CType(TextBox5.Text, Decimal), "#,##0.00")
        TextBox6.Select()
        If dedonde = 2 Then
            'abro desde orden de trabajo 
            Button2.Enabled = True
        Else
            'abro desde factura directa 
            If saldo_pendiente.ToString = 0 Then
                Button2.Enabled = True

            End If
        End If


    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox7.Focus()
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click




        If tarjeta <> 0 Then
            voucher1 = InputBox("Introduzca el numero de Voucher", "No.")
            t_tarjeta = InputBox("Indique el tipo de POS Utilizado:  NEONET= '1'   CREDOMATIC= '2'", "Tipo POS:")
        End If

        'valido si ingrese valor en el campo este pago para crear recibo o solamente grabar el pago 
        If este_pag = 0 Then

            MessageBox.Show("Se acreditaran los anticipos seleccionados a la orden", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'valido desde donde estoy realizando el cobro
            If dedonde = 1 Then

                Try
                    conexion.Open()
                    For columnas As Integer = 0 To DataGridView1.RowCount - 1
                        no_recibo = DataGridView1.Item(0, columnas).Value.ToString
                        'actualizo el status del recibo seleccionado
                        consulta = "UPDATE recibos set id_vendedor='" & id_vendedor & "', anticipo='0', marca_armazon='" & facturacion_directa.aro & "', no_factura='" & TextBox1.Text & "', seriefac='" & TextBox2.Text & "'  where recibo='" & no_recibo & "' and serierec='" & dashboard.serie_recibo & "' and  id_agencia='" & dashboard.no_agencia & "'"
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error mientras se trataba de actualizar el estatus del recibo", "Contacta a Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show(ex.ToString)
                    conexion.Close()
                    Return
                End Try

                ' Try
                '     conexion.Open()
                '     'recorro el datagridview de los recibos seleccionados para poder actualizar el status 
                '     For columnas As Integer = 0 To DataGridView1.RowCount - 1
                '         no_recibo = DataGridView1.Item(0, columnas).Value.ToString
                '         'actualizo el status del recibo seleccionado
                '         consulta = "UPDATE viscobros set no_factura='" & TextBox1.Text & "', anticipo='', seriefac='" & TextBox2.Text & "',no_factura='" & TextBox1.Text & "',seriefac='" & TextBox2.Text & "'  where recibo='" & no_recibo & "' and serierec='" & dashboard.serie_recibo & "' and  id_agencia='" & dashboard.no_agencia & "'"
                '         com = New MySqlCommand(consulta, conexion)
                '         com.ExecuteNonQuery()
                '     Next
                '     conexion.Close()
                ' Catch ex As Exception
                '     MsgBox("No fue posible actualizar los datos del recibo anterior," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                'vbCrLf & vbCrLf & ex.Message,
                'MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                '     conexion.Close()
                '     Return
                ' End Try
                facturacion_directa.Button4.Enabled = True
                facturacion_directa.Button2.Visible = False
                MessageBox.Show("Factura lista para grabar", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()

            ElseIf dedonde = 2 Then
                'cobro desde orden de trabajo 
                'realizo la operacion en la tabla de base de datos de g-Optics 
                Try
                    conexion.Open()
                    For columnas As Integer = 0 To DataGridView1.RowCount - 1
                        no_recibo = DataGridView1.Item(0, columnas).Value.ToString
                        'actualizo el status del recibo seleccionado
                        consulta = "UPDATE recibos set id_vendedor='" & id_vendedor & "', anticipo='0', marca_armazon='" & receta.aro.Text & "', orden='" & TextBox1.Text & "', serieord='" & TextBox2.Text & "'  where recibo='" & no_recibo & "' and serierec='" & dashboard.serie_recibo & "' and  id_agencia='" & dashboard.no_agencia & "'"
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error mientras se trataba de actualizar el estatus del recibo", "Contacta a Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show(ex.ToString)
                    conexion.Close()
                    Return
                End Try

                receta.abono.Text = total_anticipos
                receta.saldo.Text = saldo_pendiente
                receta.recibo.Text = anticiposapp(1) & "  " & anticiposapp(2) & "  " & anticiposapp(3)
                MessageBox.Show("Orden de Trabajo lista para Grabar", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                receta.Button2.Visible = True
                receta.Button3.Visible = False
                receta.Button1.Enabled = False
                receta.btn_agg.Enabled = False
                Me.Dispose()
            End If
        Else
            'obtengo el numero de recibo 
            Try
                conexion.Open()
                consulta = "Select recibos, serierec from catagencias where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = rs(1)
                rs.Close()
                conexion.Close()
                correlativo = correlativo + 1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No pude obtener el correlativo a seguir", "Contacta a Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'valido desde donde estoy llamando a la ventana para realizar el cobro
            If dedonde = 1 Then
                'cobro desde FACTURA
                '  MessageBox.Show("Se generara recibo de pago para la orden seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'realizo la grabacion
                'cobro desde facturacion directa 
                TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
                TextBox5.Text = Format(CType(TextBox5.Text, Decimal), "#,##0.00")
                TextBox6.Text = Format(CType(TextBox6.Text, Decimal), "#,##0.00")
                TextBox7.Text = Format(CType(TextBox7.Text, Decimal), "#,##0.00")
                'realizo la operacion en la tabla de base de datos de g-Optics 
                Try

                    'realizo la grabacion en la base de datos de G-optics
                    conexion.Open()
                    consulta = "INSERT INTO recibos(id_agencia,recibo,serierec,fecha,valor,pagono,nombre,observa,este_pago,tipo_pago,voucher,efectivo,tarjeta,telefono,fecha_prometida,marca_armazon,material,modelo_armazon,id_vendedor,vendedor,color,direccion) values('" & dashboard.no_agencia & "','" & correlativo & "','" & serie & "','" & facturacion_directa.fecha.Text & "','" & total_orden1 & "','1','" & facturacion_directa.nombre.Text & "','" & TextBox8.Text & "', '" & este_pag & "','" & t_tarjeta & "','" & voucher1 & "','" & efectivo & "','" & tarjeta & "','" & facturacion_directa.Telefonocliente.Text & "','" & facturacion_directa.fecha.Text & "','" & facturacion_directa.Marca_aro & "','" & material.Text & "','" & facturacion_directa.aro & "','" & id_vendedor & "','" & facturacion_directa.txt_vendedor.Text & "','" & facturacion_directa.nit.Text & "','" & facturacion_directa.nombre.Text & "')"
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    conexion.Close()
                Catch ex As Exception
                    conexion.Close()
                    MessageBox.Show(ex.ToString)
                End Try
                'verifico si el dtv esta vacio o con datos para actualizar los recibos cargados
                If DataGridView1.Rows.Count >= 1 Then
                    ''cobro desde orden de trabajo 
                    'Try
                    '    conexion.Open()
                    '    'recorro el datagridview de los recibos seleccionados para poder actualizar el status 
                    '    For columnas As Integer = 0 To DataGridView1.RowCount - 1
                    '        no_recibo = DataGridView1.Item(0, columnas).Value.ToString
                    '        'actualizo el status del recibo seleccionado
                    '        consulta = "UPDATE viscobros set id_vendedor='" & id_vendedor & "', no_factura='" & TextBox1.Text & "', anticipo='0', seriefac='" & TextBox2.Text & "',material='" & material.Text & "',marca_armazon='" & receta.aro.Text & "'  where recibo='" & no_recibo & "' and serierec='" & dashboard.serie_recibo & "' and  id_agencia='" & dashboard.no_agencia & "'"
                    '        com = New MySqlCommand(consulta, conexion)
                    '        com.ExecuteNonQuery()
                    '    Next
                    '    conexion.Close()
                    'Catch ex As Exception
                    '    MessageBox.Show("Ocurrio un error mientras se trataba de actualizar el estatus del recibo", "Contacta a Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    MessageBox.Show(ex.ToString)
                    '    conexion.Close()
                    '    Return
                    'End Try
                End If
            ElseIf dedonde = 2 Then
                'cobro desde orden de laboratorio
                MessageBox.Show("Se generara recibo de pago para la orden de trabajo", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'realizo la grabacion
                Try
                    'realizo la grabacion en la base de datos de G-optics
                    conexion.Open()
                    consulta = "INSERT INTO recibos(id_agencia,recibo,serierec,fecha,valor,pagono,nombre,observa,este_pago,tipo_pago,voucher,efectivo,tarjeta,telefono,fecha_prometida,marca_armazon,material,modelo_armazon,id_vendedor,vendedor,color,direccion) values('" & dashboard.no_agencia & "','" & correlativo & "','" & serie & "','" & receta.fecha.Text & "','" & receta.totalsinf & "','1','" & receta.nombre.Text & "','" & TextBox8.Text & "', '" & este_pag & "','" & t_tarjeta & "','" & voucher1 & "','" & efectivo & "','" & tarjeta & "','" & receta.telefono.Text & "','" & receta.f_entrega.Text & "','" & receta.marca_aro.Text & "','" & material.Text & "','" & receta.aro.Text & "','" & id_vendedor & "','" & receta.txt_vendedor.Text & "','" & nit & "','" & nombrepf & "')"
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
                'valido si el dtv tiene recibos de pagos anteriores 
                If DataGridView1.Rows.Count >= 1 Then
                    'cobro desde orden de laboratorio
                    Try
                        conexion.Open()
                        'recorro el datagridview de los recibos seleccionados para poder actualizar el status y anexarlos a la orden en la base de datos de goptics

                        For columnas As Integer = 0 To DataGridView1.RowCount - 1
                            no_recibo = DataGridView1.Item(0, columnas).Value.ToString
                            'actualizo el status del recibo seleccionado
                            consulta = "UPDATE recibos set id_vendedor='" & id_vendedor & "', orden='" & TextBox1.Text & "', anticipo='0', serieord='" & TextBox2.Text & "',marca_armazon='" & receta.aro.Text & "',material='" & material.Text & "'  where recibo='" & no_recibo & "' and   id_agencia='" & dashboard.no_agencia & "'"
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                        Next
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show("Ocurrio un error mientras se trataba de actualizar el estatus del recibo en G-Optics", "Contacta con Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MessageBox.Show(ex.ToString)
                        conexion.Close()
                        Return
                    End Try



                End If
                receta.abono.Text = Val(total_anticipos) + Val(este_pag)
                receta.saldo.Text = saldo_pendiente
                receta.recibo.Text = correlativo
                receta.abonosinf = Val(total_anticipos) + Val(este_pag)
                receta.abono.Text = Format(CType(receta.abono.Text, Decimal), "#,##0.00")
                receta.saldo.Text = Format(CType(receta.saldo.Text, Decimal), "#,##0.00")
                ' MessageBox.Show("Orden de Laboratorio para Imprimir")
                receta.Button2.Visible = True
                receta.Button3.Visible = False
            End If
            Try
                'actualizo correlativo de recibos
                conexion.Open()
                consulta = "UPDATE catagencias set recibos='" & correlativo & "'  where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                receta.nit = nit

                pregunta = MsgBox("Recibo Numero 00" & correlativo & "  grabado con exito.", vbYes + vbDefaultButton1 + vbInformation, "Imprimir.")

                Try
                        Dim dialog As New PrintPreviewDialog()
                        dialog.Document = Print_recibo
                        Print_recibo.PrinterSettings.PrinterName = "TICKET"
                        DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                        dialog.PrintPreviewControl.Zoom = 1.5
                        dialog.ShowDialog()
                    Me.Dispose()

                Catch ex As Exception
                        MessageBox.Show("La Impresion ha fallado", ex.ToString())
                    End Try

                If dedonde = 1 Then
                        'valido la ventana de orden de trabjao
                        facturacion_directa.Button4.Enabled = True
                        facturacion_directa.Button2.Enabled = False
                        MessageBox.Show("Factura lista para Grabar", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        facturacion_directa.Button4.Focus()
                    ElseIf dedonde = 2 Then
                        receta.Button2.Visible = True
                        receta.Button1.Enabled = False
                        receta.Button3.Visible = False
                        receta.btn_agg.Enabled = False
                    ' MessageBox.Show("Orden Lista para Grabar", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    facturacion_directa.Button4.PerformClick()
                End If
                Me.Dispose()

            Catch ex As Exception
                MsgBox("No fue posible actualizar el correlativo de los recibos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If

    End Sub

    Public Function GetMyNumberToWords(ByVal value As String) As String
        Dim str As String = String.Empty

        Select Case Convert.ToDouble(value)
            Case 0 : str = "CERO"
            Case 1 : str = "UN"
            Case 2 : str = "DOS"
            Case 3 : str = "TRES"
            Case 4 : str = "CUATRO"
            Case 5 : str = "CINCO"
            Case 6 : str = "SEIS"
            Case 7 : str = "SIETE"
            Case 8 : str = "OCHO"
            Case 9 : str = "NUEVE"
            Case 10 : str = "DIEZ"
            Case 11 : str = "ONCE"
            Case 12 : str = "DOCE"
            Case 13 : str = "TRECE"
            Case 14 : str = "CATORCE"
            Case 15 : str = "QUINCE"
            Case Is < 20 : str = "DIECI" & GetMyNumberToWords(value - 10)
            Case 20 : str = "VEINTE"
            Case Is < 30 : str = "VEINTI" & GetMyNumberToWords(value - 20)
            Case 30 : str = "TREINTA"
            Case 40 : str = "CUARENTA"
            Case 50 : str = "CINCUENTA"
            Case 60 : str = "SESENTA"
            Case 70 : str = "SETENTA"
            Case 80 : str = "OCHENTA"
            Case 90 : str = "NOVENTA"
            Case Is < 100 : str = GetMyNumberToWords(Int(value \ 10) * 10) & " Y " & GetMyNumberToWords(value Mod 10)
            Case 100 : str = "CIEN"
            Case Is < 200 : str = "CIENTO " & GetMyNumberToWords(value - 100)
            Case 200, 300, 400, 600, 800 : str = GetMyNumberToWords(Int(value \ 100)) & "CIENTOS"
            Case 500 : str = "QUINIENTOS"
            Case 700 : str = "SETECIENTOS"
            Case 900 : str = "NOVECIENTOS"
            Case Is < 1000 : str = GetMyNumberToWords(Int(value \ 100) * 100) & " " & GetMyNumberToWords(value Mod 100)
            Case 1000 : str = "MIL"
            Case Is < 2000 : str = "MIL " & GetMyNumberToWords(value Mod 1000)
            Case Is < 1000000 : str = GetMyNumberToWords(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then str = str & " " & GetMyNumberToWords(value Mod 1000)
            Case 1000000 : str = "UN MILLON"
            Case Is < 2000000 : str = "UN MILLON " & GetMyNumberToWords(value Mod 1000000)
            Case Is < 1000000000000.0# : str = GetMyNumberToWords(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then str = str & " " & GetMyNumberToWords(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : str = "UN BILLON"
            Case Is < 2000000000000.0# : str = "UN BILLON " & GetMyNumberToWords(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : str = str(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then str = str & " " & GetMyNumberToWords(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

        Return str
    End Function

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox6.Text = "" Then
                TextBox6.Text = 0
            End If
            If TextBox7.Text = "" Then
                TextBox7.Text = 0
            End If
            Toperacion()
            'efectivo = TextBox6.Text
            'tarjeta = TextBox7.Text
            'este_pag = Val(TextBox6.Text) + Val(TextBox7.Text)
            ''valido que el valor ingresado no supere el valor del saldo pendiente 
            'If Val(este_pag) > Val(saldo_pendiente) Then
            '    MessageBox.Show("No puedes ingresar un valor mayor al del saldo pendiente de la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return
            '    TextBox6.Clear()
            '    TextBox6.Focus()
            'Else
            '    'ralizo la suma del valor ingresado contra el anticipo realizado para sacar el saldo pendiente 
            '    saldo_pendiente = Val(total_orden1) - Val(total_anticipos) - Val(este_pag)
            '    TextBox4.Text = saldo_pendiente
            '    TextBox5.Text = Format(CType(este_pag, Decimal), "#,##0.00")
            '    TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            '    TextBox6.Text = Format(CType(TextBox6.Text, Decimal), "#,##0.00")
            '    TextBox7.Text = Format(CType(TextBox7.Text, Decimal), "#,##0.00")

            '    TextBox8.Focus()
            '    'muestro la cantidad ingresada en letras
            '    Dim largo = Len(CStr(Format(CDbl(este_pag), "#,###.00")))
            '    Dim decimales = Mid(CStr(Format(CDbl(este_pag), "#,###.00")), largo - 2)
            '    enletras.Text = GetMyNumberToWords(este_pag - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
            'End If
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles titulo.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    'limito para que no utilicen la tecla de tabulador
    Protected Overrides Function ProcessDialogKey(
ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData <> Keys.Tab Then
            Return MyBase.ProcessDialogKey(keyData)
        End If

    End Function

    Private Sub TextBox6_LostFocus(sender As Object, e As EventArgs) Handles TextBox6.LostFocus
        Toperacion()
    End Sub
    Sub Toperacion()
        ':::Funcion para realizar operacion de totales 
        Cefectivo = 0
        Ctarjeta = 0
        Ctotal = 0
        total_anticipos = 0
        Cefectivo = TextBox6.Text
        Ctarjeta = TextBox7.Text
        Ctotal = Val(Cefectivo) + Val(Ctarjeta)
        TextBox5.Text = Ctotal
        If Ctotal > saldo_pendiente Then
            MessageBox.Show("Lo cobrado no puede ser mayor al saldo pendiente de la factura ")
            Return
        Else
            total_anticipos = Val(saldo_pendiente) - Val(Ctotal)
            TextBox4.Text = total_anticipos
            ' MessageBox.Show(total_anticipos)
            If total_anticipos = 0 Then
                Button2.Enabled = True
            Else
                Button2.Enabled = False
            End If
        End If
        efectivo = Cefectivo
        tarjeta = Ctarjeta
        este_pag = Ctotal

        'MessageBox.Show(total_orden1 & " 0 " & total_anticipos & " 1 " & saldo_pendiente)
    End Sub

    Private Sub TextBox7_LostFocus(sender As Object, e As EventArgs) Handles TextBox7.LostFocus
        Toperacion()
    End Sub
End Class