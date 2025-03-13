Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class receta
    Dim consulta, prgunta, mono, biflap, bi_invi, prog As String
    Dim fecha_larga As String = DateTime.Now.ToString("dd MMMM yyyy")
    Dim monofocal_valor, bifocal_valor, progresivo_valor, policarbonato_valor, plastico_valor, vidrio_valor, tipolente, material, Recibos As String
    Dim rs As MySqlDataReader
    Dim com As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla_medidas, tabla_datos As DataTable
    Public dedonde, serie, id_vendedor, totalsinf, correlativosinf, oddesclente, odsubtotallente, odpreciofinal, oidesclente, oisubtotallente, oipreciofinal, nit, email, abonosinf, TipoProductoOD, TipoProductoOI As String
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim TopRigth As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat
    Dim tabla_recibos As DataTable
    Dim Correlativo1 As Integer
    'limito para que no utilicen la tecla de tabulador
    Protected Overrides Function ProcessDialogKey(
ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData <> Keys.Tab Then
            Return MyBase.ProcessDialogKey(keyData)
        End If

    End Function
    Private Sub receta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center
        TopRigth.Alignment = StringAlignment.Far
        'valido si estoy abriendo la ventana desde una orden de laboratorio nueva o una consulta 
        If dedonde = 1 Then
            'nueva orden de trabajo 
            'obtengo el correlativo a seguir
            'Try
            '    conexion.Open()
            '    consulta = "SELECT ordenes,serieord FROM catagencias WHERE id_agencia='" & dashboard.no_agencia & "'"
            '    com = New MySqlCommand(consulta, conexion)
            '    rs = com.ExecuteReader
            '    rs.Read()
            '    correlativo.Text = rs(0)
            '    serie = rs(1)
            '    rs.Close()
            '    conexion.Close()
            'Catch ex As Exception
            '    MsgBox("No fue posible obtener el correlativo para la Orden de Trabajo," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
            '     vbCrLf & vbCrLf & ex.Message,
            '     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            '    conexion.Close()
            '    Return
            'End Try

            'obtengo el numero de recibo 
            Try
                conexion.Open()
                consulta = "select MAX(no_orden) from orden  where id_agencia='" & dashboard.no_agencia & "' and serie='" & dashboard.serie_orden & "';"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                Correlativo1 = rs(0)
                serie = dashboard.serie_orden
                rs.Close()
                conexion.Close()
                'obtengo el correlativo a seguir
                Correlativo1 = Correlativo1 + 1
                correlativosinf = Correlativo1
                correlativo.Text = Correlativo1
                serie = dashboard.serie_orden
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo  de ordenes" & vbCrLf & "- Verifica tu conexion a internet." & vbCrLf & "- Abre nuevamente la ventana." &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Button3.Enabled = False
                btn_agg.Enabled = False
                TextBox1.Enabled = False
            End Try
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            TextBox1.Select()
            TextBox1.Focus()
            Dim hoy As Date = Date.Now
            Dim fechafinal As Date = hoy.AddDays(4)
            f_entrega.Text = fechafinal.ToString("dd/MM/yyyy")
        ElseIf dedonde = 2 Or 3 Then
            'oculto la leyenda de numero de orden de trabajo y el numero 
            Label2.Visible = False
            TextBox1.Visible = False
            'consulta // anulacion orden de TRABAJO
            TextBox1.ReadOnly = True
            'realizo la busquedad de la orden consultada 
            Try
                conexion.Open()
                consulta = "SELECT o.od_esfera,o.od_cilindro,o.od_eje,o.od_adicion,o.oi_esfera,o.oi_cilindro,o.oi_eje,o.oi_adicion,o.dp,o.altura,o.aro,o.recibo,o.obs,o.total,o.abono,o.saldo,o.direccion,o.f_entrega,o.odt_esf,o.odt_cil,o.odt_eje,o.oit_esf,o.oit_cil,o.oit_eje,o.tipo_lente,o.material,v.nombre,o.marca_aro,o.tipo_material,o.optometra,o.oi_adicion,o.factura,o.seriefact,o.status  FROM orden as o left join vendedores as v on(o.id_vendedor=v.id_codigo)  where no_orden='" & correlativo.Text & "' and serie='" & serie & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                odesfera.Text = rs(0)
                odcilindro.Text = rs(1)
                odeje.Text = rs(2)
                odadd.Text = rs(3)
                oiesfera.Text = rs(4)
                oicilindro.Text = rs(5)
                oieje.Text = rs(6)
                dp.Text = rs(8)
                altura.Text = rs(9)
                aro.Text = rs(10)
                recibo.Text = rs(11)
                obs.Text = rs(12)
                total.Text = rs(13)
                abono.Text = rs(14)
                saldo.Text = rs(15)
                direccion.Text = rs(16)
                f_entrega.Value = rs(17)
                tod_esf.Text = rs(18)
                tod_cil.Text = rs(19)
                tod_eje.Text = rs(20)
                toi_esf.Text = rs(21)
                toi_cil.Text = rs(22)
                toi_eje.Text = rs(23)
                Tipo_Aro.SelectedIndex = rs(24)
                material = rs(25)
                txt_vendedor.Text = rs(26)
                marca_aro.Text = rs(27)
                tipo_lente.Text = rs(28)
                opto.Text = rs(29)
                oiadd.Text = rs(30)
                If rs(33) = "F" Then
                    Advertencia1.Text = "ANEXADA A FACTURA " & rs(31) & " SERIE " & rs(32)
                Else
                    Advertencia1.Text = "ORDEN PENDIENTE DE FACTURAR"
                    Advertencia1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                    Advertencia1.ForeColor = Color.Red
                End If

                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el detalle de la orden de trabajo," & vbCrLf & "- Verifica tu conexion a internet, intenta abrir nuevamente la ventana." &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'busco todos los recibos aplicados a la orden que estoy consultando*************************** 
            Try
                conexion.Open()
                consulta = "select recibo from recibos where orden='" & correlativo.Text & "' and id_agencia='" & dashboard.no_agencia & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_recibos = New DataTable
                adaptador.Fill(tabla_recibos)
                dtv_recibos.DataSource = tabla_recibos
                conexion.Close()
                If dtv_recibos.Rows.Count = 0 Then
                    recibo.Text = " "
                ElseIf dtv_recibos.Rows.Count = 1 Then
                    recibo.Text = dtv_recibos.Item(0, 0).Value.ToString
                ElseIf dtv_recibos.Rows.Count = 2 Then
                    recibo.Text = dtv_recibos.Item(0, 0).Value.ToString & " y " & dtv_recibos.Item(0, 1).Value.ToString
                ElseIf dtv_recibos.Rows.Count = 3 Then
                    recibo.Text = dtv_recibos.Item(0, 0).Value.ToString & ", " & dtv_recibos.Item(0, 1).Value.ToString & " y  " & dtv_recibos.Item(0, 2).Value.ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            If tipolente = "MONOFOCAL" Then
                monofocal.Checked = True
            ElseIf tipolente = "BIFOCALES" Then
                bifocal.Checked = True
            ElseIf tipolente = "PROGRESIVO" Then
                progresivos.Checked = True
            End If
            If material = "POLICARBONATO" Then
                policarbonato.Checked = True
            ElseIf material = "PLASTICO" Then
                plastico.Checked = True
            ElseIf material = "VIDRIO" Then
                vidrio.Checked = True
            End If
            'limpio mi dtv para que elimine las columnas predefinidas
            DataGridView1.Columns.Clear()
            'busco el detalle de la orden de laboratorio
            Try
                conexion.Open()
                consulta = "SELECT cantidad,id_codigo,obs,descto,subtotal,tipo from detorden where no_docto='" & correlativo.Text & "' and id_agencia='" & dashboard.no_agencia & "' order by tipo"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_datos = New DataTable
                adaptador.Fill(tabla_datos)
                DataGridView1.DataSource = tabla_datos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "CANTIDAD"
                DataGridView1.Columns(1).HeaderText = "CODIGO"
                DataGridView1.Columns(2).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(3).HeaderText = "DESCUENTO"
                DataGridView1.Columns(4).HeaderText = "TOTAL"
                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(2).Width = 310
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).Width = 70
                DataGridView1.Columns(5).Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el detalle de los productos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'recorro dtv para buscar si tiene lente derecho 
            Dim rows() As DataRow = tabla_datos.Select("tipo='LD'")
            If rows.Length > 0 Then
                Dim dr As DataRow = rows(0)
                ' MessageBox.Show(CStr(dr.Item("id_codigo")))
                cod_lente_od.Text = (CStr(dr.Item("id_codigo")))
                od_descplente.Text = (CStr(dr.Item("obs")))
                desc_od.Text = (CStr(dr.Item("descto")))
                od_subtotal.Text = (CStr(dr.Item("subtotal")))
            End If

            'recorro dtv para buscar si tiene lente izquierdo 
            Dim rows1() As DataRow = tabla_datos.Select("tipo='LI'")
            If rows1.Length > 0 Then
                Dim dr As DataRow = rows1(0)
                'MessageBox.Show(CStr(dr.Item("id_codigo")))
                cod_lente_oi.Text = (CStr(dr.Item("id_codigo")))
                oi_descplente.Text = (CStr(dr.Item("obs")))
                desc_oi.Text = (CStr(dr.Item("descto")))
                oi_subtotal.Text = (CStr(dr.Item("subtotal")))
            End If

            correlativosinf = correlativo.Text
            correlativo.Text = "00" & correlativo.Text
            total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
            abono.Text = Format(CType(abono.Text, Decimal), "#,##0.00")
            saldo.Text = Format(CType(saldo.Text, Decimal), "#,##0.00")

            'cod_lente_oi.Enabled = False
            'oi_descplente.Enabled = False
            'desc_oi.Enabled = False
            'oi_subtotal.Enabled = False
            'cod_lente_od.Enabled = False
            'od_descplente.Enabled = False
            'desc_od.Enabled = False
            'od_subtotal.Enabled = False
            GroupBox5.Enabled = False
            GroupBox6.Enabled = False
            GroupBox7.Enabled = False
            nombre.Enabled = False
            direccion.Enabled = False
            telefono.Enabled = False
            obs.Enabled = False
            txt_vendedor.Enabled = False
            If dedonde = 2 Then
                Button5.Visible = True
            Else

            End If

        End If

        If nombre.Text = "**ANULADO**" Then
            Button5.Visible = False
            Button4.Visible = False

        End If
    End Sub

    Private Sub fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fecha.KeyPress
        If Asc(e.KeyChar) = 13 Then
            nombre.Focus()

        End If
    End Sub


    Private Sub nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            telefono.Focus()

        End If
    End Sub

    Private Sub telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles telefono.KeyPress
        If Asc(e.KeyChar) = 13 Then
            direccion.Focus()

        End If
    End Sub

    Private Sub odesfera_KeyPress(sender As Object, e As KeyPressEventArgs) Handles odesfera.KeyPress
        If Asc(e.KeyChar) = 13 Then
            altura.Focus()

        End If
    End Sub


    Private Sub odcilindro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles odcilindro.KeyPress
        If Asc(e.KeyChar) = 13 Then
            odeje.Focus()

        End If
    End Sub


    Private Sub odeje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles odeje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            oiesfera.Focus()

        End If
    End Sub


    Private Sub odadicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles odadd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dp.Focus()

        End If
    End Sub



    Private Sub oiesfera_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oiesfera.KeyPress
        If Asc(e.KeyChar) = 13 Then
            oicilindro.Focus()

        End If
    End Sub



    Private Sub oicilindro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oicilindro.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Tipo_Aro.Focus()

        End If
    End Sub



    Private Sub oieje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oieje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            oiadd.Focus()
        End If
    End Sub



    Private Sub oiadicion_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            dp.Focus()

        End If
    End Sub



    Private Sub dp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dp.KeyPress
        If Asc(e.KeyChar) = 13 Then
            toi_esf.Focus()
        End If
    End Sub



    Private Sub altura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles altura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cod_lente_od.Focus()

        End If
    End Sub





    Private Sub tratamiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles obs.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_vendedor.Focus()

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If monofocal.Checked = True Then
            tipolente = "MONOFOCAL"
            monofocal_valor = "X"
        ElseIf bifocal.Checked = True Then
            tipolente = "BIFOCAL"
            bifocal_valor = "X"
        ElseIf progresivos.Checked = True Then
            tipolente = "PROGRESIVO"
            progresivo_valor = "X"
        End If
        If policarbonato.Checked = True Then
            material = "POLICARBONATO"
            policarbonato_valor = "X"
        ElseIf vidrio.Checked = True Then
            material = "VIDRIO"
            vidrio_valor = "X"
        ElseIf plastico.Checked = True Then
            material = "PLASTICO"
            plastico_valor = "X"
        End If

        'inicio grabacion en base de datos de goptics
        Try
            conexion.Open()
            consulta = "INSERT INTO orden(no_orden,serie,fecha,nombre,telefono,od_esfera,od_cilindro,od_eje,od_adicion,oi_esfera,oi_cilindro,oi_eje,oi_adicion,dp,altura,aro,marca_aro,recibo,obs,total,abono,saldo,status,id_agencia,id_vendedor,direccion,f_entrega,odt_esf,odt_cil,odt_eje,oit_esf,oit_cil,oit_eje,tipo_lente,material,tipo_material,optometra) values('" & correlativo.Text & "','" & serie & "','" & fecha.Text & "','" & nombre.Text & "','" & telefono.Text & "','" & odesfera.Text & "','" & odcilindro.Text & "','" & odeje.Text & "','" & odadd.Text & "','" & oiesfera.Text & "','" & oicilindro.Text & "','" & oieje.Text & "','" & oiadd.Text & "','" & dp.Text & "','" & altura.Text & "','" & aro.Text & "','" & marca_aro.Text & "','" & recibo.Text & "','" & obs.Text & "','" & totalsinf & "','" & abono.Text & "', '" & saldo.Text & "','P','" & dashboard.no_agencia & "','" & id_vendedor & "','" & direccion.Text & "','" & f_entrega.Value.ToString & "','" & tod_esf.Text & "','" & tod_cil.Text & "','" & tod_eje.Text & "','" & toi_esf.Text & "','" & toi_cil.Text & "','" & toi_eje.Text & "','" & Tipo_Aro.SelectedIndex.ToString & "','" & material & "','" & tipo_lente.Text & "','" & opto.Text & "')"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            consulta = "INSERT INTO detorden (no_docto,serie,id_codigo,cantidad,precio,descto,tdescto,subtotal,obs,id_agencia,tipo,t_product) VALUES ('" & correlativosinf & "','" & serie & "','" & cod_lente_od.Text & "','1','" & odsubtotallente & "','" & oddesclente & "','" & oddesclente & "','" & odpreciofinal & "','" & od_descplente.Text & "','" & dashboard.no_agencia & "','LD','" & TipoProductoOD & "')"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            consulta = "INSERT INTO detorden (no_docto,serie,id_codigo,cantidad,precio,descto,tdescto,subtotal,obs,id_agencia,tipo,t_product) VALUES ('" & correlativosinf & "','" & serie & "','" & cod_lente_oi.Text & "','1','" & oisubtotallente & "','" & oidesclente & "','" & oidesclente & "','" & oipreciofinal & "','" & oi_descplente.Text & "','" & dashboard.no_agencia & "','LI', '" & TipoProductoOI & "')"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible grabar la orden de trabajo No. 00," & correlativo.Text & "  Serie " & serie & "," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        'realizo la grabacion del detalle de la orden de trabajo
        Try
            conexion.Open()
            consulta = "INSERT INTO detorden (no_docto,serie,id_codigo,cantidad,precio,descto,tdescto,subtotal,obs,id_agencia,t_product) VALUES ('" & correlativosinf & "','" & serie & "',@codigosinf,@cantidadsinf,@preciosinf,@descuentosinf,@descuentosinf,@subtotalsinf,@descripcionsinf,'" & dashboard.no_agencia & "',@tiposinf)"
            com = New MySqlCommand(consulta, conexion)
            For Each row As DataGridViewRow In dtvsinf.Rows
                com.Parameters.Clear()
                com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                com.Parameters.AddWithValue("@descripcionsinf", row.Cells(2).Value)
                com.Parameters.AddWithValue("@descuentosinf", row.Cells(3).Value)
                com.Parameters.AddWithValue("@preciosinf", row.Cells(4).Value)
                com.Parameters.AddWithValue("@subtotalsinf", row.Cells(5).Value)
                com.Parameters.AddWithValue("@tiposinf", row.Cells(6).Value)
                com.ExecuteNonQuery()
            Next
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible grabar el detalle de los productos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                     vbCrLf & vbCrLf & ex.Message,
                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
     
        Try
            'actualizo el status de la historia clinica para que ya no aparezca como pendiente de operar 
            conexion.Open()
            consulta = "UPDATE clinica set estado='O',orden='" & correlativosinf & "'  where no_clinica='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "'"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible actualizar el status de la historia clinica," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        'actualizo correlativo de orden de laboratorio
        Try
            conexion.Open()
            consulta = "UPDATE catagencias set ordenes='" & correlativo.Text & "'  where id_agencia='" & dashboard.no_agencia & "'"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            conexion.Close()
            'imprimo la orden 
            prgunta = MsgBox("Orden de Trabajo Numero 00" & correlativo.Text & "  grabada con exito." & vbCrLf, vbOKOnly + vbInformation, "Orden Grabada.")
            abono.Text = Format(CType(abono.Text, Decimal), "#,##0.00")
            saldo.Text = Format(CType(saldo.Text, Decimal), "#,##0.00")
            'imprimo desde la agencia 2 por tiket 
            Try
                Dim dialog As New PrintPreviewDialog()
                dialog.Document = Print_Orden_Ticket
                Print_Orden_Ticket.PrinterSettings.PrinterName = "TICKET"
                DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                dialog.PrintPreviewControl.Zoom = 1.5
                dialog.ShowDialog()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("La Impresion ha fallado", ex.ToString())
            End Try
            Me.Close()
        Catch ex As Exception
            MsgBox("No fue posible actualizar el correlativo de la orden de laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub
    Private Sub recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles recibo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            orden.Focus()
        End If
    End Sub
    Private Sub aro_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If aro.Text = "" Then
                agrega_producto.dedonde = 3
                agrega_producto.ShowDialog()
            Else
                total.Focus()
            End If
        End If
    End Sub
    Private Sub total_KeyPress(sender As Object, e As KeyPressEventArgs) Handles total.KeyPress
        If Asc(e.KeyChar) = 13 Then
            abono.Focus()
        End If
    End Sub
    Private Sub abono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles abono.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Val(total.Text) < Val(abono.Text) Then
                MessageBox.Show("No puedes agregar un abono mayor al total de la orden de trabajo", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                recibo.Focus()
                saldo.Text = Val(total.Text) - Val(abono.Text)
                total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
                abono.Text = Format(CType(abono.Text, Decimal), "#,##0.00")
                saldo.Text = Format(CType(saldo.Text, Decimal), "#,##0.00")
            End If

        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox1.Text = "" Then
                'abro la ventana para buscar la historia clinica por nombre de paciente 
                altura.Focus()
                busca_hclinica.dedonde = 2
                busca_hclinica.ShowDialog()
            Else
                ''realizo la busquedad de la historia clinica al presionar la tecla enter
                'Try
                '    conexion.Open()
                '    consulta = "SELECT nombre, direccion,telefono,rx2_od_esf,rx2_od_cil,rx2_od_eje,rx2_adicion,rx2_oi_esf,rx2_oi_cil,rx2_oi_eje from clinica where no_clinica='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "'"
                '    com = New MySqlCommand(consulta, conexion)
                '    rs = com.ExecuteReader
                '    rs.Read()
                '    nombre.Text = rs(0)
                '    direccion.Text = rs(1)
                '    telefono.Text = rs(2)
                '    odesfera.Text = rs(3)
                '    odcilindro.Text = rs(4)
                '    odeje.Text = rs(5)
                '    odadd.Text = rs(6)
                '    oiesfera.Text = rs(7)
                '    oicilindro.Text = rs(8)
                '    oieje.Text = rs(9)
                '    rs.Close()
                '    conexion.Close()
                '    txt_vendedor.Focus()
                'Catch ex As Exception
                '    MsgBox("No fue posible encontrar la historia clinica consultada," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                '  vbCrLf & vbCrLf & ex.Message,
                '  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                '    conexion.Close()
                '    Return
                'End Try
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If monofocal.Checked = True Then
            tipolente = "MONOFOCAL"
            monofocal_valor = "X"
        ElseIf bifocal.Checked = True Then
            tipolente = "BIFOCAL"
            bifocal_valor = "X"
        ElseIf progresivos.Checked = True Then
            tipolente = "PROGRESIVO"
            progresivo_valor = "X"
        End If
        If policarbonato.Checked = True Then
            material = "POLICARBONATO"
            policarbonato_valor = "X"
        ElseIf vidrio.Checked = True Then
            material = "VIDRIO"
            vidrio_valor = "X"
        ElseIf plastico.Checked = True Then
            material = "PLASTICO"
            plastico_valor = "X"
        End If
        'imprimo la orden 
        prgunta = MsgBox("Orden de Trabajo Numero 00" & correlativo.Text & "  ." & vbCrLf & vbCrLf & "¿Desea Re imprimir la Orden de Trabajo?", vbYesNo + vbInformation + vbDefaultButton2, "Re impresion.")
        If prgunta = vbYes Then
            abono.Text = Format(CType(abono.Text, Decimal), "#,##0.00")
            saldo.Text = Format(CType(saldo.Text, Decimal), "#,##0.00")

            'imprimo desde la agencia 2 por tiket 
            Try
                Dim dialog As New PrintPreviewDialog()
                dialog.Document = Print_Orden_Ticket
                Print_Orden_Ticket.PrinterSettings.PrinterName = "TICKET"
                DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                dialog.PrintPreviewControl.Zoom = 1.5
                dialog.ShowDialog()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("La Impresion ha fallado", ex.ToString())
            End Try
        Else
            Me.Close()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_agg.Click
        'cargo la ventana para agregar el producto 
        carga_producto.dedonde = 2
        carga_producto.ShowDialog()
    End Sub
    Private Sub txt_vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vendedor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'muestra la ventana para poder seleccionar al vendedor 
            If Me.txt_vendedor.Text = "" Then
                muestra_vendedor.dedonde = 2
                muestra_vendedor.ShowDialog()
                obs.Focus()
            Else
            End If
        End If
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        'valido que la orden no este con valor cero 
        If total.Text = "" Then
            MessageBox.Show("No puedes grabar una orden sin agregar productos", "Orden Vacia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        Else


            If nombre.Text = "" Then
                MessageBox.Show("No puedes grabar una orden sin nombre de paciente")
                nombre.Focus()
            ElseIf telefono.Text = "" Or telefono.Text = "00000000" Then
                MessageBox.Show("No puedes grabar una orden sin numero de telefono de paciente")
            ElseIf txt_vendedor.Text = "" Then
                MessageBox.Show("No puedes grabar una orden sin codigo de vendedor")
            Else
                'defino fecha de entrga en formato fecha americana
                Label33.Text = Format(f_entrega.Value, "yyyy-MM-dd")
                'Realizo la primera validacion si la orden no lleva aro incluido
                If aro.Text = "" Then
                    Dim pregunta = MsgBox("Estas por grabar una orden de trabajo sin agregar ARO." & vbCrLf & "Deseas continuar?", vbYesNo + vbQuestion + vbDefaultButton2, "Orden sin ARO")
                    If pregunta = vbNo Then
                        Return
                    Else
                        'Si tiene aro paso a lo siguiente.
                        'Pregunto si se desea generar recibo de pago para la orden de trabajo   
                        'Envio el material a trabajar para actualizar o grabar recibo en la ventana de cobros
                        If monofocal.Checked = True Then
                            cobrar_orden.material.Text = "MONOFOCAL"
                        ElseIf bifocal.Checked = True Then
                            cobrar_orden.material.Text = "BIFOCAL"
                        ElseIf progresivos.Checked = True Then
                            cobrar_orden.material.Text = "PROGRESIVO"
                        ElseIf RadioButton1.Checked = True Then
                            cobrar_orden.material.Text = "NINGUNO"
                        End If
                        'Cargo la ventana para realizar el cobro 
                        cobrar_orden.dedonde = 2
                        cobrar_orden.TextBox1.Text = correlativosinf
                        cobrar_orden.TextBox2.Text = dashboard.serie_orden_laboratorio
                        cobrar_orden.TextBox3.Text = totalsinf
                        cobrar_orden.total_orden = totalsinf
                        cobrar_orden.nombre = nombre.Text
                        cobrar_orden.fecha = fecha.Text
                        cobrar_orden.id_vendedor = id_vendedor
                        cobrar_orden.titulo.Text = "//Cobrar Anticipo"
                        cobrar_orden.Label1.Text = "Orden No."
                        cobrar_orden.ShowDialog()

                    End If
                Else
                    'Envio el material a trabajar para actualizar o grabar recibo en la ventana de cobros
                    If monofocal.Checked = True Then
                        cobrar_orden.material.Text = "MONOFOCAL"
                    ElseIf bifocal.Checked = True Then
                        cobrar_orden.material.Text = "BIFOCAL"
                    ElseIf progresivos.Checked = True Then
                        cobrar_orden.material.Text = "PROGRESIVO"
                    ElseIf RadioButton1.Checked = True Then
                        cobrar_orden.material.Text = "NINGUNO"
                    End If
                    'Cargo la ventana para realizar el cobro 
                    cobrar_orden.dedonde = 2
                    cobrar_orden.TextBox1.Text = correlativosinf
                    cobrar_orden.TextBox2.Text = serie
                    cobrar_orden.TextBox3.Text = totalsinf
                    cobrar_orden.total_orden = totalsinf
                    cobrar_orden.nombre = nombre.Text
                    cobrar_orden.fecha = fecha.Text
                    cobrar_orden.id_vendedor = id_vendedor
                    cobrar_orden.TextBox8.Text = "ABONO ORDEN #" & correlativosinf & " - " & serie

                    cobrar_orden.titulo.Text = "//Cobrar Anticipo"
                    cobrar_orden.Label1.Text = "Orden No."
                    cobrar_orden.ShowDialog()
                End If
            End If
        End If

        'actualizo el status de la historia clinica para que desaparezca como pendiente de operar



    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'realizo la anulacion del documento 
        If dedonde = 3 Then
            'elimino el detalle del documento
            Try
                conexion.Open()
                consulta = "UPDATE orden set status='A', nombre='**ANULADO**' where no_orden='" & correlativosinf & "' and serie='" & serie & "' and id_agencia='" & dashboard.no_agencia & "';UPDATE recibos set anticipo='x', orden='0',serieord='' where orden='" & correlativosinf & "' and id_agencia='" & dashboard.no_agencia & "' "
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                MsgBox("Orden de Trabajo  anulada con exito", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                dashboard.AnularToolStripMenuItem1.PerformClick()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible anular la orden," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
            vbCrLf & vbCrLf & ex.Message,
            MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If dedonde = 1 Then
            'elimino el item del datagridview
            MessageBox.Show("Se eliminara el producto seleccionado")
            Dim total1 As Double = 0
            Dim subtotal2 As Double = 0
            Dim subtotal3 As Double = 0
            Dim i As Integer
            Dim row As DataGridViewRow = DataGridView1.CurrentRow
            i = DataGridView1.CurrentRow.Index
            If aro.Text = CStr(row.Cells(2).Value) Then
                aro.Text = ""
                marca_aro.Text = ""
            Else
            End If
            DataGridView1.Rows.RemoveAt(i)
            dtvsinf.Rows.RemoveAt(i)
            'recalculo la suma del total 
            Calcular()
        End If
    End Sub
    Private Sub direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles direccion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            f_entrega.Focus()
        End If
    End Sub
    Private Sub f_entrega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles f_entrega.KeyPress
        If Asc(e.KeyChar) = 13 Then
            tod_esf.Focus()
        End If
    End Sub
    Private Sub monofocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles monofocal.KeyPress
        If Asc(e.KeyChar) = 13 Then
            policarbonato.Focus()
        End If
    End Sub
    Private Sub bifocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bifocal.KeyPress
        If Asc(e.KeyChar) = 13 Then
            policarbonato.Focus()
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Print_Orden_Ticket.PrintPage

        Dim fuente, fuente1, fuente2, fuente3, fuente4, fuente5, fuente6 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        fuente1 = New Font("Consolas", 8)
        fuente2 = New Font("consolas", 7)
        fuente3 = New Font("Arial", 12, FontStyle.Regular)
        fuente4 = New Font("Arial", 9, FontStyle.Bold)
        fuente5 = New Font("3 of 9 Barcode", 24, FontStyle.Regular)
        fuente6 = New Font("Arial", 12, FontStyle.Bold)
        Dim prFont As New Font("Consolas", 7, FontStyle.Bold)
        'defino coordenada en horizontal 
        Dim CurX As Integer = 0
        'defino coordenada en vertical 
        Dim CurY As Integer = 0
        'defino ancho del rectangulo que tomo como base para imprimir centrado 
        Dim iWidth As Integer = 295
        Dim cellRect As RectangleF
        cellRect = New RectangleF()
        cellRect.Location = New Point(CurX, CurY)
        cellRect.Size = New Size(iWidth, CurY)
        'imprimo logo de la orden
        e.Graphics.DrawImage(PictureBox1.Image, 43, 8, 215, 50)
        '  e.Graphics.DrawString("empresa", New Font(fuente, FontStyle.Bold), Brushes.Black, cellRect, TopCenter)
        'imprimo tipo de documento 
        '  cellRect.Location = New Point(CurX, CurY)
        ' e.Graphics.DrawString("*** OPTICAS DELUXE ***", fuente6, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 76)
        e.Graphics.DrawString("ORDEN DE TRABAJO", fuente4, Brushes.Black, cellRect, TopCenter)
        'imprimo nombre de la agencia
        cellRect.Location = New Point(CurX, CurY + 91)
        e.Graphics.DrawString(dashboard.agencia.Text, fuente6, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 106)
        e.Graphics.DrawString(serie & "  - " & correlativo.Text, fuente3, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 125)
        e.Graphics.DrawString("---------   SUCURSAL   --------- ", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 140)
        e.Graphics.DrawString(dashboard.direcciontienda & ", " & dashboard.SySMuni & ", " & dashboard.SysDepto, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 190)
        e.Graphics.DrawString("PBX: " & dashboard.pbx & "  DIRECTO: " & dashboard.telefonotienda, fuente, Brushes.Black, cellRect, TopCenter)
        'cellRect.Location = New Point(CurX, CurY + 203)
        'e.Graphics.DrawString("correo de la tienda", fuente, Brushes.Black, cellRect, TopCenter)

        'IMPRIMO DATOS DEL CLIENTE 
        cellRect.Location = New Point(CurX, CurY + 223)
        e.Graphics.DrawString("------   DATOS DEL CLIENTE   ------ ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 240)
        e.Graphics.DrawString("FECHA ORDEN " & fecha.Text, fuente4, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 255)
        e.Graphics.DrawString("PACIENTE:  " & nombre.Text, fuente, Brushes.Black, cellRect, TopCenter)
        '  cellRect.Location = New Point(CurX, CurY + 280)
        '  e.Graphics.DrawString("TELEFONO:  " & telefono.Text, fuente4, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 293)
        e.Graphics.DrawString("FECHA PROMETIDA:  " & f_entrega.Text, fuente4, Brushes.Black, cellRect, TopCenter)
        'Imprimo Graduaciones
        cellRect.Location = New Point(CurX, CurY + 315)
        e.Graphics.DrawString("RX:  ", fuente4, Brushes.Black, cellRect, TopLeft)

        'Ojo derecho
        e.Graphics.DrawString("OD", fuente4, Brushes.Black, 5, 340)
        e.Graphics.DrawString("ESF.", fuente4, Brushes.Black, 40, 330)
        e.Graphics.DrawString(tod_esf.Text, fuente, Brushes.Black, 38, 350)
        e.Graphics.DrawString("CIL.", fuente4, Brushes.Black, 100, 330)
        e.Graphics.DrawString(tod_cil.Text, fuente, Brushes.Black, 97, 350)
        e.Graphics.DrawString("EJE.", fuente4, Brushes.Black, 150, 330)
        e.Graphics.DrawString(tod_eje.Text, fuente, Brushes.Black, 152, 350)
        e.Graphics.DrawString("ADD.", fuente4, Brushes.Black, 210, 330)
        e.Graphics.DrawString(odadd.Text, fuente, Brushes.Black, 208, 350)

        'Ojo izquierdo
        e.Graphics.DrawString("OI", fuente4, Brushes.Black, 5, 375)
        e.Graphics.DrawString(toi_esf.Text, fuente, Brushes.Black, 38, 375)
        e.Graphics.DrawString(toi_cil.Text, fuente, Brushes.Black, 97, 375)
        e.Graphics.DrawString(toi_eje.Text, fuente, Brushes.Black, 152, 375)
        e.Graphics.DrawString(oiadd.Text, fuente, Brushes.Black, 208, 375)

        e.Graphics.DrawString("DP: ", fuente4, Brushes.Black, 5, 410)
        e.Graphics.DrawString(dp.Text & "/" & odesfera.Text, fuente, Brushes.Black, 35, 410)

        e.Graphics.DrawString("ALTURA: ", fuente4, Brushes.Black, 100, 410)
        e.Graphics.DrawString(altura.Text, fuente, Brushes.Black, 170, 410)


        'Tipo Lente y Armazon
        cellRect.Location = New Point(CurX, CurY + 435)
        e.Graphics.DrawString("--------   LENTES   -------- ", fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 450)
        e.Graphics.DrawString("OD:", fuente4, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 465)
        e.Graphics.DrawString(cod_lente_od.Text & " - " & od_descplente.Text, fuente, Brushes.Black, cellRect, TopLeft)


        cellRect.Location = New Point(CurX, CurY + 500)
        e.Graphics.DrawString("OI:", fuente4, Brushes.Black, cellRect, TopLeft)


        cellRect.Location = New Point(CurX, CurY + 515)
        e.Graphics.DrawString(cod_lente_oi.Text & " - " & oi_descplente.Text, fuente, Brushes.Black, cellRect, TopLeft)


        '  cellRect.Location = New Point(CurX, CurY + 550)
        '  e.Graphics.DrawString("TRATAMIENTO", fuente4, Brushes.Black, cellRect, TopLeft)


        ' cellRect.Location = New Point(CurX, CurY + 550)
        ' e.Graphics.DrawString(tipo_lente.Text, fuente, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 550)
        e.Graphics.DrawString("ARO:", fuente4, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 570)
        e.Graphics.DrawString(aro.Text & " / " & marca_aro.Text, fuente, Brushes.Black, cellRect, TopLeft)

        'medidas aro
        e.Graphics.DrawString("TIPO:", fuente4, Brushes.Black, 0, 600)
        e.Graphics.DrawString(Tipo_Aro.Text, fuente, Brushes.Black, 35, 600)

        e.Graphics.DrawString("Horizontal:", fuente4, Brushes.Black, 0, 620)
        e.Graphics.DrawString(odcilindro.Text, fuente4, Brushes.Black, 90, 620)

        e.Graphics.DrawString("Vertical:", fuente4, Brushes.Black, 140, 620)
        e.Graphics.DrawString(odeje.Text, fuente4, Brushes.Black, 200, 620)

        e.Graphics.DrawString("Diagonal:", fuente4, Brushes.Black, 0, 640)
        e.Graphics.DrawString(oicilindro.Text, fuente4, Brushes.Black, 90, 640)

        e.Graphics.DrawString("Puente:", fuente4, Brushes.Black, 140, 640)
        e.Graphics.DrawString(oiesfera.Text, fuente4, Brushes.Black, 200, 640)

        cellRect.Location = New Point(CurX, CurY + 700)
        e.Graphics.DrawString("OBS:", fuente4, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 720)
        e.Graphics.DrawString(obs.Text, fuente, Brushes.Black, cellRect, TopLeft)

        'imprimo el tipo de trabajo 
        'cellRect.Location = New Point(CurX, CurY + 760)
        'e.Graphics.DrawString("Tipo de Trabajo:  " & tipo_trabajo.Text, fuente, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 745)
        e.Graphics.DrawString("RECIBO ANTICIPO No." & recibo.Text, fuente4, Brushes.Black, cellRect, TopCenter)

        '  cellRect.Location = New Point(CurX, CurY + 800)
        '  e.Graphics.DrawString("SALDO  Q. " & saldo.Text, fuente4, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 795)
        e.Graphics.DrawString("ASESOR", fuente4, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 810)
        e.Graphics.DrawString("** " & txt_vendedor.Text, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 845)
        e.Graphics.DrawString("OPTOMETRA ", fuente4, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 920)
        e.Graphics.DrawString("F:____________________________", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 975)
        e.Graphics.DrawString(opto.Text, fuente4, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 935)
        e.Graphics.DrawString("*" & correlativo.Text & "*", fuente5, Brushes.Black, cellRect, TopCenter)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub altura_TextChanged(sender As Object, e As EventArgs) Handles altura.TextChanged

    End Sub

    Private Sub odcilindro_TextChanged(sender As Object, e As EventArgs) Handles odcilindro.TextChanged

    End Sub

    Private Sub odeje_TextChanged(sender As Object, e As EventArgs) Handles odeje.TextChanged

    End Sub

    Private Sub oiesfera_TextChanged(sender As Object, e As EventArgs) Handles oiesfera.TextChanged

    End Sub

    Private Sub oicilindro_TextChanged(sender As Object, e As EventArgs) Handles oicilindro.TextChanged

    End Sub

    Private Sub Tipo_Aro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo_Aro.SelectedIndexChanged

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub f_entrega_ValueChanged(sender As Object, e As EventArgs) Handles f_entrega.ValueChanged

    End Sub

    Private Sub od_subtotal_TextChanged(sender As Object, e As EventArgs) Handles od_subtotal.TextChanged

    End Sub

    Private Sub desc_od_TextChanged(sender As Object, e As EventArgs) Handles desc_od.TextChanged

    End Sub

    Private Sub desc_oi_TextChanged(sender As Object, e As EventArgs) Handles desc_oi.TextChanged

    End Sub

    Private Sub odadd_TextChanged(sender As Object, e As EventArgs) Handles odadd.TextChanged

    End Sub

    Private Sub toi_eje_TextChanged(sender As Object, e As EventArgs) Handles toi_eje.TextChanged

    End Sub

    Private Sub oiadd_TextChanged(sender As Object, e As EventArgs) Handles oiadd.TextChanged

    End Sub

    Private Sub odesfera_TextChanged(sender As Object, e As EventArgs) Handles odesfera.TextChanged

    End Sub

    Private Sub cod_lente_oi_TextChanged(sender As Object, e As EventArgs) Handles cod_lente_oi.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub cod_lente_od_TextChanged(sender As Object, e As EventArgs) Handles cod_lente_od.TextChanged

    End Sub

    Private Sub txt_vendedor_TextChanged(sender As Object, e As EventArgs) Handles txt_vendedor.TextChanged

    End Sub

    Private Sub dp_TextChanged(sender As Object, e As EventArgs) Handles dp.TextChanged

    End Sub

    Private Sub progresivos_CheckedChanged(sender As Object, e As EventArgs) Handles progresivos.CheckedChanged

    End Sub

    Private Sub progresivos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles progresivos.KeyPress
        If Asc(e.KeyChar) = 13 Then
            policarbonato.Focus()
        End If
    End Sub

    Private Sub policarbonato_CheckedChanged(sender As Object, e As EventArgs) Handles policarbonato.CheckedChanged

    End Sub

    Private Sub policarbonato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles policarbonato.KeyPress
        If Asc(e.KeyChar) = 13 Then
            obs.Focus()
        End If
    End Sub

    Private Sub plastico_CheckedChanged(sender As Object, e As EventArgs) Handles plastico.CheckedChanged

    End Sub

    Private Sub plastico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles plastico.KeyPress
        If Asc(e.KeyChar) = 13 Then
            obs.Focus()
        End If
    End Sub
    Private Sub vidrio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles vidrio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            obs.Focus()
        End If
    End Sub

    Private Sub oiadd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oiadd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            odesfera.Focus()
        End If
    End Sub
    Private Sub tod_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tod_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            tod_cil.Focus()
        End If
    End Sub
    Private Sub tod_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tod_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            tod_eje.Focus()
        End If
    End Sub
    Private Sub tod_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tod_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            odadd.Focus()
        End If
    End Sub

    Private Sub tod_eje_TextChanged(sender As Object, e As EventArgs) Handles tod_eje.TextChanged

    End Sub

    Private Sub toi_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles toi_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            toi_cil.Focus()
        End If
    End Sub

    Private Sub toi_esf_TextChanged(sender As Object, e As EventArgs) Handles toi_esf.TextChanged

    End Sub

    Private Sub toi_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles toi_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            toi_eje.Focus()
        End If
    End Sub

    Private Sub toi_cil_TextChanged(sender As Object, e As EventArgs) Handles toi_cil.TextChanged

    End Sub

    Private Sub toi_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles toi_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            oiadd.Focus()
        End If
    End Sub
    Private Sub cod_lente_od_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cod_lente_od.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cod_lente_od.Text = "." Then
                'no ingreso codigo de lente igualo todo a cero
                desc_od.ReadOnly = True
                desc_od.Text = 0
                od_subtotal.Text = 0
                od_descplente.Clear()
                cod_lente_oi.Focus()
            ElseIf cod_lente_od.Text = "" Then
                'abro ventana para buscar solo lentes 
                agrega_producto.dedonde = 4
                agrega_producto.ShowDialog()
                desc_od.Focus()
                odsubtotallente = od_subtotal.Text
            Else
                'busco la descripcion y precio de lente segun el codigo interno ingresado 
                Try
                    conexion.Open()
                    consulta = "select id_codigo,producto,precio1,linea,servicio from inventario where id_codigo= '" & cod_lente_od.Text & "' and  linea='5' and status='A';"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    od_descplente.Text = rs(1)
                    od_subtotal.Text = rs(2)
                    TipoProductoOD = rs(4)
                    odsubtotallente = od_subtotal.Text
                    conexion.Close()
                    rs.Close()
                    desc_od.Focus()
                Catch ex As Exception
                    'MessageBox.Show(ex.ToString)
                    'si no encuento el codigo muestro mensaje de error 
                    MessageBox.Show("El codigo que ingresaste no existe o no es un  lente, intenta de nuevo")
                    conexion.Close()
                    Return
                End Try

            End If
            If TipoProductoOD = "N" Then
                TipoProductoOD = "B"
            End If
        End If
    End Sub

    Private Sub desc_od_KeyPress(sender As Object, e As KeyPressEventArgs) Handles desc_od.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cod_lente_oi.Focus()
        End If
    End Sub

    Private Sub cod_lente_oi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cod_lente_oi.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cod_lente_oi.Text = "." Then
                'no ingreso codigo de lente igualo todo a cero
                desc_oi.ReadOnly = True
                desc_oi.Text = 0
                oi_subtotal.Text = 0
                oi_descplente.Clear()
                btn_agg.Focus()

            ElseIf cod_lente_oi.Text = "" Then
                'abro ventana para buscar solo lentes 
                agrega_producto.dedonde = 5
                agrega_producto.ShowDialog()
                desc_oi.Focus()
                oisubtotallente = oi_subtotal.Text

            Else
                'busco la descripcion y precio de lente segun el codigo interno ingresado 
                Try
                    conexion.Open()
                    consulta = "select id_codigo,producto,precio1,linea,servicio from inventario where id_codigo= '" & cod_lente_oi.Text & "' and  linea='5' and status='A';"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    oi_descplente.Text = rs(1)
                    oi_subtotal.Text = rs(2)
                    TipoProductoOI = rs(4)
                    oisubtotallente = oi_subtotal.Text
                    conexion.Close()
                    rs.Close()
                    desc_oi.Focus()
                Catch ex As Exception
                    'MessageBox.Show(ex.ToString)
                    'si no encuento el codigo muestro mensaje de error 
                    MessageBox.Show("El codigo que ingresaste no existe o no es un  lente, intenta de nuevo")
                    conexion.Close()
                    Return
                End Try

            End If
            If TipoProductoOI = "N" Then
                TipoProductoOI = "B"
            End If
        End If
    End Sub

    Private Sub desc_oi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles desc_oi.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btn_agg.Focus()
        End If
    End Sub

    Private Sub cod_lente_od_LostFocus(sender As Object, e As EventArgs) Handles cod_lente_od.LostFocus

    End Sub

    Private Sub desc_od_LostFocus(sender As Object, e As EventArgs) Handles desc_od.LostFocus
        If desc_od.Text = "" Then
            'esta vacio igualo el descuento a cero 
            desc_od.Text = 0
            oddesclente = desc_od.Text
            odpreciofinal = Val(odsubtotallente) - Val(oddesclente)
            od_subtotal.Text = Format(CType(od_subtotal.Text, Decimal), "#,##0.00")
            desc_od.Text = Format(CType(desc_od.Text, Decimal), "#,##0.00")

        Else
            oddesclente = desc_od.Text
            odpreciofinal = Val(odsubtotallente) - Val(oddesclente)
            od_subtotal.Text = odpreciofinal
            od_subtotal.Text = Format(CType(od_subtotal.Text, Decimal), "#,##0.00")
            desc_od.Text = Format(CType(desc_od.Text, Decimal), "#,##0.00")
        End If
        Calcular()
    End Sub

    Private Sub desc_oi_LostFocus(sender As Object, e As EventArgs) Handles desc_oi.LostFocus
        If desc_oi.Text = "" Then
            'esta vacio igualo el descuento a cero 
            desc_oi.Text = 0

            oidesclente = desc_oi.Text
            oipreciofinal = Val(oisubtotallente) - Val(oidesclente)
            oi_subtotal.Text = Format(CType(oi_subtotal.Text, Decimal), "#,##0.00")
            desc_oi.Text = Format(CType(desc_oi.Text, Decimal), "#,##0.00")
        Else
            oidesclente = desc_oi.Text
            oipreciofinal = Val(oisubtotallente) - Val(oidesclente)
            oi_subtotal.Text = oipreciofinal
            oi_subtotal.Text = Format(CType(oi_subtotal.Text, Decimal), "#,##0.00")
            desc_oi.Text = Format(CType(desc_oi.Text, Decimal), "#,##0.00")
        End If
        Calcular()
    End Sub
    Public Function Calcular() As String

        Dim totaltemp As Double = 0
        Dim subtotal2 As Double = 0
        Dim subtotal3 As Double = 0
        'funcion que realiza el calculo del total de la orden
        'realizo la suma de la columna precio del dtv recetapara mostrar en tiempo real lo que se va cobrar  
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In DataGridView1.Rows
            totaltemp += Convert.ToDouble(fila.Cells("precio").Value)
            subtotal2 += Convert.ToDouble(fila.Cells("descuento").Value)
        Next
        'doy formato al textbox total de la suma 
        total.Clear()
        subtotal3 = Val(totaltemp) - Val(subtotal2)
        total.Text = subtotal3 + Val(odpreciofinal) + Val(oipreciofinal)
        totalsinf = subtotal3 + Val(odpreciofinal) + Val(oipreciofinal)
        total.Text = Format(CType(total.Text, Decimal), "#,##0.00")
    End Function

    Private Sub Tipo_Aro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tipo_Aro.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_vendedor.Focus()

        End If
    End Sub
End Class