Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Management
Public Class dashboard
    Public no_agencia As Integer
    Public serie_factura, nombre_usuario, serie_orden, serie_recibo, consulta, orden_laboratorio, serie_orden_laboratorio, direcciontienda, telefonotienda, correotienda, pbx, serial, serial1, Sysdireccion, SysRazonsocial, SysNitempresa, SysCodpais, SySMuni, SysDepto, SysEstable, Sysaliasfel, Sysllavefel, Systokenfel, Sysnomestable As String
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim ip As System.Net.IPHostEntry
    Dim pregunta, rxfinal(44), tipo_lente, material, antirreflejo, luz_azul, foto, pola, POrden, PFactura, PCoti, PRecibo, PHclinica As String
    Dim segundos As Integer
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        pregunta = MsgBox("¿Desea salir del sistema de Gestion para Opticas G-Optics?", vbYesNo + vbQuestion + vbDefaultButton2, "Salir del Sistema")
        If pregunta = vbYes Then
            Me.Close()
        Else
            Return
        End If
    End Sub
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        productos_nuevo.MdiParent = Me
        productos_nuevo.dedonde = 1
        productos_nuevo.Show()
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        productos_buscar.MdiParent = Me
        productos_buscar.dedonde = 2
        productos_buscar.Label8.Text = "Modificar Productos // Precio"
        productos_buscar.Label1.Visible = True
        productos_buscar.Show()
    End Sub
    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click

        productos_buscar.MdiParent = Me
        productos_buscar.dedonde = 1
        productos_buscar.Label8.Text = "Buscar Productos // Precio"
        productos_buscar.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem.Click
        facturacion_directa.MdiParent = Me
        facturacion_directa.dedonde = 20
        facturacion_directa.Show()

        facturacion_directa.Label8.Visible = True
    End Sub

    Private Sub TipoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoToolStripMenuItem.Click
        cat_tipo.MdiParent = Me
        cat_tipo.dedonde.Text = 1
        cat_tipo.Show()

    End Sub

    Private Sub MarcaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcaToolStripMenuItem.Click
        cat_tipo.MdiParent = Me
        cat_tipo.dedonde.Text = 2
        cat_tipo.Show()
    End Sub

    Private Sub LineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LineaToolStripMenuItem.Click
        cat_tipo.MdiParent = Me
        cat_tipo.dedonde.Text = 3
        cat_tipo.Show()
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        cat_tipo.MdiParent = Me
        cat_tipo.dedonde.Text = 4

        cat_tipo.Show()
    End Sub
    Private Sub ReciboToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboToolStripMenuItem.Click
        recibos_nuevo.MdiParent = Me
        recibos_nuevo.dedonde = 1
        recibos_nuevo.Show()
        recibos_nuevo.nombre.Focus()

    End Sub
    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is MdiClient Then
                C.BackColor = Color.Gray
                Exit For
            End If
        Next
        C = Nothing
        'Obtengo los datos de la version 
        version1.Text = My.Application.Info.Version.ToString
        'obtengo los datos de la empresa 
        Try
            conexion.Open()
            consulta = "SELECT razon_social,nombre_comercial,nit,aliasfel,llavefel,tokenfel FROM empresa"
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            SysRazonsocial = rs(0)
            empresa.Text = rs(1)
            SysNitempresa = rs(2)
            Sysaliasfel = rs(3)
            Sysllavefel = rs(4)
            Systokenfel = rs(5)
            rs.Close()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener los datos de la empresa, No podras emitir factua electronica, por favor contacta con soporte tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
            '  MessageBox.Show(SysEstable)
        End Try

        'valido permisos de usuario
        If permisos.Text = 1 Then
            'permisos no definidos
            ContabilidadToolStripMenuItem.Visible = False
            GeneralToolStripMenuItem1.Enabled = True
            VendedoresToolStripMenuItem1.Enabled = True
            ToolStripButton7.Enabled = True
            AnulacionToolStripMenuItem1.Enabled = True
            AnularToolStripMenuItem1.Enabled = True
            HistoriasClinicasToolStripMenuItem.Enabled = True
        ElseIf permisos.Text = 3 Then
            'permisos perfil ASESOR VENTAS
            '  BuscarToolStripMenuItem4.Enabled = True
            productos.Enabled = False
            OrdenDeLaboratorioToolStripMenuItem1.Enabled = False
            OrdenesDeTrabajoToolStripMenuItem.Enabled = False
            NotaDeEntregaToolStripMenuItem.Enabled = False
            SalidaAjusteToolStripMenuItem.Enabled = False
            ReImpresionToolStripMenuItem.Enabled = False
            RecepcionToolStripMenuItem.Enabled = False
            HistoriasClinicasToolStripMenuItem.Enabled = Enabled
            MoificarToolStripMenuItem.Enabled = False
            ' ExpedientesToolStripMenuItem.Enabled = True
            ingresoajuste.Enabled = False
            BancosToolStripMenuItem.Enabled = False
            ContabilidadToolStripMenuItem.Visible = False
            ReportesToolStripMenuItem.Enabled = False
            UtileriasToolStripMenuItem.Enabled = False
            ToolStripButton1.Enabled = False
            AnularToolStripMenuItem.Enabled = False
            ToolStripButton7.Enabled = True
            NotaDeEntregaToolStripMenuItem.Enabled = True

        ElseIf permisos.Text = 4 Then
            'permisos perfil laboratorio
            '  BuscarToolStripMenuItem4.Enabled = True
            productos.Enabled = False
            OrdenDeLaboratorioToolStripMenuItem1.Enabled = False
            OrdenesDeTrabajoToolStripMenuItem.Enabled = False
            NotaDeEntregaToolStripMenuItem.Enabled = False
            SalidaAjusteToolStripMenuItem.Enabled = False
            ReImpresionToolStripMenuItem.Enabled = False
            HistoriasClinicasToolStripMenuItem.Enabled = False
            MoificarToolStripMenuItem.Enabled = False
            '  ExpedientesToolStripMenuItem.Enabled = False
            ingresoajuste.Enabled = False
            BancosToolStripMenuItem.Enabled = False
            ContabilidadToolStripMenuItem.Visible = False
            ReportesToolStripMenuItem.Enabled = False
            UtileriasToolStripMenuItem.Enabled = False
            ToolStripButton1.Enabled = False
            RecepcionToolStripMenuItem.Enabled = True
            ToolStripButton7.Enabled = True
        ElseIf permisos.Text = 5 Then
            UtileriasToolStripMenuItem.Enabled = False
            ReportesToolStripMenuItem.Enabled = False
            ContabilidadToolStripMenuItem.Visible = False
        End If

        ToolStripButton1.Text = "Agencia: " & no_agencia

        'obtengo el # de serial del disco duro
        Informacion()

        'verifico que el serial tenga asignada una agencia
        Try
            conexion.Open()
            consulta = "select agencia from regpventa where serial='" & serial1 & "'"
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            no_agencia = rs(0)
            ToolStripButton1.Text = "Agencia: " & no_agencia
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Este equipo no esta registrado como punto de venta ")
            conexion.Close()
            no_agencia = 1
            ToolStripButton1.Text = "Agencia: " & no_agencia
        End Try

        'mensaje pago sistema
        Timer1.Interval = 1000
        '  Timer1.Start() 'Timer starts functioning
        segundos = 0
        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center
        'valido que en donde tenga abierto el sistema sea una tienda para imprimir historia clinica 
        'If serial <> "" Then
        '    Informacion()
        '    If serial = serial1 Then
        '        'MessageBox.Show("este equipo es una tienda")
        '        '   Timer1.Enabled = True
        '    End If
        'Else
        '    MessageBox.Show("este equipo no es una tienda")
        'End If
        '  Timer1.Enabled = True


        ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
        ip_maquina.Text = (ip.AddressList(0).ToString)
        '  MessageBox.Show(serie_orden)
        'ejecuto funcion para obtener los datos de la sucursal
        Info_tienda()
    End Sub
    Sub Informacion()
        ':::Obtenemos el serial del Disco Duro
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        serial1 = serialDD.Properties("SerialNumber").Value.ToString
        'MessageBox.Show(serial1)
    End Sub
    Public Sub Info_tienda()
        'Obtengo la info de la tienda seleccionada 
        Try
            conexion.Open()
            consulta = "SELECT nombre,seriefac,serieord,serierec,codpais,municipio,depto,direccion,establecimiento,telefonos,telefono2,correo,nom_estable from catagencias where id_agencia='" & no_agencia & "' "
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            agencia.Text = rs(0)
            serie_factura = rs(1)
            serie_orden = rs(2)
            serie_recibo = rs(3)
            SysCodpais = rs(4)
            SySMuni = rs(5)
            SysDepto = rs(6)
            Sysdireccion = rs(7)
            direcciontienda = rs(7)
            SysEstable = rs(8)
            pbx = rs(9)
            telefonotienda = rs(10)
            correotienda = rs(11)
            Sysnomestable = rs(12)
            rs.Close()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener los datos de la agencia, si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try

        Try
            conexion.Open()
            consulta = "SELECT * FROM a_tiendas where id_agencia='" & no_agencia & "'"
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            POrden = rs(1)
            PRecibo = rs(2)
            PFactura = rs(3)
            PCoti = rs(4)
            PHclinica = rs(5)
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
            MessageBox.Show("Este equipo no esta autorizado para utilizar este sistema ")
        End Try

        If POrden = "x" Then
            OrdenDeLaboratorioToolStripMenuItem1.Enabled = True
            ToolStripButton5.Enabled = True
        Else
            OrdenDeLaboratorioToolStripMenuItem1.Enabled = False
            ToolStripButton5.Enabled = False
        End If
        If PRecibo = "x" Then
            RecibosToolStripMenuItem.Enabled = True
        Else
            RecibosToolStripMenuItem.Enabled = False
        End If
        If PFactura = "x" Then
            OrdenesDeTrabajoToolStripMenuItem.Enabled = True
            ToolStripButton4.Enabled = True
        Else
            OrdenesDeTrabajoToolStripMenuItem.Enabled = False
        End If
        If PHclinica = "x" Then
            HistoriasClinicasToolStripMenuItem.Enabled = True
            HistoriaClinicaToolStripMenuItem1.Enabled = True
        Else
            HistoriasClinicasToolStripMenuItem.Enabled = False
            HistoriaClinicaToolStripMenuItem1.Enabled = False
        End If
    End Sub
    Private Sub OrdenesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdenesToolStripMenuItem1.Click
        selecciona_orden.MdiParent = Me
        selecciona_orden.dedonde = 1
        selecciona_orden.Show()
    End Sub
    Private Sub NuevaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem1.Click
        facturacion_directa.MdiParent = Me
        facturacion_directa.dedonde = 51
        facturacion_directa.Show()
        facturacion_directa.Label9.Visible = True
        facturacion_directa.nit.Text = "CF"
    End Sub
    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 1
        consulta_documento.titulo.Text = "Consulta de Facturas "
        consulta_documento.subtitulo.Text = "Doble Clic sobre la factura a consultar"
        consulta_documento.radionombre.Text = "NOMBRE DE CLIENTE"
        consulta_documento.radionumero.Text = "NUMERO FACTURA"
        consulta_documento.Show()
    End Sub

    Private Sub BuscarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem2.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 1
        consulta_documento.titulo.Text = "Consulta de Facturas"
        consulta_documento.subtitulo.Text = "Doble Clic sobre la factura a consultar"
        consulta_documento.radionombre.Text = "NOMBRE DE CLIENTE"
        consulta_documento.radionumero.Text = "NUMERO FACTURA"
        consulta_documento.Size = New Size(1050, 523)
        consulta_documento.Show()
    End Sub

    Private Sub BuscarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem1.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 3
        consulta_documento.titulo.Text = "Consulta Recibos de Pago"
        consulta_documento.subtitulo.Text = "Doble Clic sobre el recibo a consultar"
        consulta_documento.radionombre.Text = "NOMBRE DE CLIENTE"
        consulta_documento.radionumero.Text = "NUMERO RECIBO"
        consulta_documento.Show()
        consulta_documento.TextBox1.Select()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 6
        consulta_documento.titulo.Text = "Anulacion Recibos de Pago"
        consulta_documento.subtitulo.Text = "Doble Clic sobre el recibo a Anular"
        consulta_documento.radionombre.Text = "NOMBRE DE CLIENTE"
        consulta_documento.radionumero.Text = "NUMERO RECIBO"
        consulta_documento.subtitulo.ForeColor = Color.Red
        consulta_documento.Show()
        consulta_documento.TextBox1.Select()
    End Sub
    Private Sub VendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendedoresToolStripMenuItem.Click
        cat_tipo.MdiParent = Me
        cat_tipo.dedonde.Text = 5
        cat_tipo.Show()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        cambia_agencia.agencia_id.Text = no_agencia
        cambia_agencia.MdiParent = Me

        cambia_agencia.Show()
        cambia_agencia.agencia_id.Focus()

    End Sub

    Private Sub OrdenesDeLaboratoriosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'verifico correlativo de Orden de trabajo  
        correlativos.MdiParent = Me
        correlativos.dedonde = 21
        correlativos.Show()
    End Sub

    Private Sub RecibosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RecibosToolStripMenuItem2.Click
        'verifico correlativo de Recibos 
        correlativos.MdiParent = Me
        correlativos.dedonde = 50
        correlativos.Show()
    End Sub

    Private Sub FacturasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacturasToolStripMenuItem1.Click
        'verifico correlativo de facturas contables 
        correlativos.MdiParent = Me
        correlativos.dedonde = 20
        correlativos.Show()
    End Sub
    Private Sub FacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasToolStripMenuItem.Click
        formato_documentos.titulo.Text = "Formato Factura"
        formato_documentos.dedonde = 1
        formato_documentos.MdiParent = Me
        formato_documentos.Show()

    End Sub
    Private Sub AccesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccesoToolStripMenuItem.Click
        usuarios.MdiParent = Me
        usuarios.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem2.Click
        receta.MdiParent = Me
        receta.dedonde = 1
        receta.Show()
    End Sub
    Private Sub BuscarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem3.Click
        consulta_documento.titulo.Text = "Orden de Trabajo"
        consulta_documento.subtitulo.Text = "Doble Click sobre la orden para consultar detalles"
        consulta_documento.dedonde = 2
        consulta_documento.MdiParent = Me
        consulta_documento.radionombre.Text = "NOMBRE DE CLIENTE"
        consulta_documento.radionumero.Text = "NUMERO DE ORDEN"
        consulta_documento.Show()
    End Sub
    Private Sub RecepcionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecepcionToolStripMenuItem.Click
        traslado.MdiParent = Me
        traslado.Label9.Text = "Ingreso Traslado"
        traslado.Label9.Visible = True
        traslado.dedonde = 1
        traslado.Show()
    End Sub
    Private Sub ConsultaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem1.Click
        traslado_consulta.MdiParent = Me
        traslado_consulta.Label9.Text = "Traslados Pendientes de Recepcion"
        traslado_consulta.Label9.Visible = True
        traslado_consulta.dedonde = 1
        traslado_consulta.Show()
    End Sub
    Private Sub ConsultaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem2.Click
        traslado_consulta.MdiParent = Me
        traslado_consulta.Label9.Text = "Consulta Traslados Recepcionados"
        traslado_consulta.Label9.Visible = True
        traslado_consulta.dedonde = 2
        traslado_consulta.Button1.Text = "Consultar"
        traslado_consulta.Show()
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        productos_buscar.MdiParent = Me
        productos_buscar.dedonde = 1
        productos_buscar.Label8.Text = "Buscar Productos / Precio"
        productos_buscar.Show()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        recibos_nuevo.MdiParent = Me
        recibos_nuevo.dedonde = 1
        recibos_nuevo.Show()
        recibos_nuevo.nombre.Focus()

    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ''abro consulta de historias clinicas
        'consulta_documento.MdiParent = Me
        'consulta_documento.dedonde = 8
        'consulta_documento.titulo.Text = "RE IMPRIME HISTORIA CLINICA"
        'consulta_documento.subtitulo.Text = "Doble clic sobre la historia a imprimir"
        'consulta_documento.radionumero.Text = "NO. HISTORIA"
        'consulta_documento.radionombre.Text = "NOMBRE DE PACIENTE"
        'consulta_documento.Show()
        receta.MdiParent = Me
        receta.dedonde = 1
        receta.Show()

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 11
        consulta_documento.titulo.Text = "CONSULTA HISTORIA CLINICA"
        consulta_documento.subtitulo.Text = "Doble clic sobre la historia a consultar"
        consulta_documento.radionumero.Visible = False
        consulta_documento.todas_tiendas.Visible = True
        consulta_documento.radionombre.Text = "NOMBRE DE PACIENTE"
        consulta_documento.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        facturacion_directa.MdiParent = Me
        facturacion_directa.dedonde = 51
        facturacion_directa.Show()
        facturacion_directa.Label9.Visible = True
        facturacion_directa.nit.Text = "CF"
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        traslado_consulta.MdiParent = Me
        traslado_consulta.Label9.Text = "Traslados Pendientes de Recepcion"
        traslado_consulta.Label9.Visible = True
        traslado_consulta.dedonde = 1
        traslado_consulta.Show()
    End Sub

    Private Sub ReImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OrdenDeTrabajoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdenDeTrabajoToolStripMenuItem1.Click
        'verifico correlativo de Orden de trabajo  
        correlativos.MdiParent = Me
        correlativos.dedonde = 51
        correlativos.Show()
    End Sub
    Private Sub RecibosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecibosToolStripMenuItem1.Click
        formato_documentos.titulo.Text = "Formato Recibo"
        formato_documentos.dedonde = 2
        formato_documentos.MdiParent = Me
        formato_documentos.Show()

    End Sub

    Private Sub OrdenDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeTrabajoToolStripMenuItem.Click
        formato_documentos.titulo.Text = "Formato Orden Trabajo"
        formato_documentos.dedonde = 3
        formato_documentos.MdiParent = Me
        formato_documentos.Show()

    End Sub

    Private Sub OrdenDeLaboratorioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeLaboratorioToolStripMenuItem.Click
        formato_documentos.titulo.Text = "Formato Historia Clinica"
        formato_documentos.dedonde = 4
        formato_documentos.MdiParent = Me
        formato_documentos.Show()

    End Sub

    Private Sub ReImpresionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReImpresionToolStripMenuItem.Click
        'habro ventana para mostrar todos los tipos de movimiento de kardex 
        agrega_producto.MdiParent = Me
        agrega_producto.dedonde = 6
        agrega_producto.TextBox1.Visible = False
        agrega_producto.Button1.Visible = False
        agrega_producto.Show()


        'movimientos.MdiParent = Me
        'movimientos.dedonde = 3
        'movimientos.Label8.Text = "RE IMPRESION"
        'movimientos.Show()
        'movimientos.cmb_tipo.Visible = False
        'movimientos.Label1.Text = "Ingrese numero de documento"
        'movimientos.no_factura.Visible = True
        'movimientos.serie.ReadOnly = False
        'movimientos.TextBox1.Visible = False
        'movimientos.Label4.Visible = False
        'movimientos.Button4.Visible = True
        'movimientos.Button1.Visible = False
        'movimientos.Button2.Visible = False
        'movimientos.Button5.Visible = True
        'movimientos.no_factura.Focus()
    End Sub
    Private Sub PendientesImprToolStripMenuItem_Click(sender As Object, e As EventArgs)
        h_clinicas.MdiParent = Me
        h_clinicas.Show()
    End Sub

    Private Sub HistoriaClinicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoriaClinicaToolStripMenuItem.Click
        'verifico correlativo de Orden de trabajo  
        correlativos.MdiParent = Me
        correlativos.dedonde = 52
        correlativos.Show()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BuscarToolStripMenuItem4_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub AcercaDeGOpticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeGOpticsToolStripMenuItem.Click
        AboutBox1.MdiParent = Me
        AboutBox1.Show()
    End Sub

    Private Sub RecibosDePagoVentasDiariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDePagoVentasDiariasToolStripMenuItem.Click
        reporte_ventasdiaras.ShowDialog()
    End Sub
    Private Sub AnularToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem1.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 5
        consulta_documento.titulo.Text = "ANULACION ORDEN TRABAJO"
        consulta_documento.subtitulo.Text = "Doble clic sobre la orden a anular"
        consulta_documento.radionumero.Text = "NO. ORDEN"
        consulta_documento.radionombre.Text = "NOMBRE DE PACIENTE"
        consulta_documento.subtitulo.ForeColor = Color.Red
        consulta_documento.Show()
    End Sub
    Private Sub CorteDeCajaToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoToolStripMenuItem.Click
        mantenimiento_nomcontable.MdiParent = Me
        mantenimiento_nomcontable.dedonde = 1
        mantenimiento_nomcontable.Show()
    End Sub

    Private Sub GrupoDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrupoDeCuentasToolStripMenuItem.Click
        mantenimiento_nomcontable.MdiParent = Me
        mantenimiento_nomcontable.dedonde = 2
        mantenimiento_nomcontable.Show()
    End Sub

    Private Sub BuscarToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem6.Click
        'abro consulta de ajustes por salida 
        consulta_documento.titulo.Text = "Movimientos de Salida"
        consulta_documento.subtitulo.Text = "De doble click sobre el movimiento a consultar"
        consulta_documento.dedonde = 14
        consulta_documento.MdiParent = Me
        consulta_documento.Show()
    End Sub

    Private Sub AnularToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem3.Click
        'abro consulta de ajustes por ingreso
        consulta_documento.titulo.Text = "Movimientos de Salida"
        consulta_documento.subtitulo.Text = "De doble click sobre el movimiento a anular"
        consulta_documento.dedonde = 16
        consulta_documento.MdiParent = Me
        consulta_documento.Show()
    End Sub

    Private Sub MovimientosDeKardexGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosDeKardexGeneralToolStripMenuItem.Click
        ' abro consulta de movimientos de kardex general 

        productos_buscar.MdiParent = Me
        productos_buscar.dedonde = 5
        productos_buscar.Label8.Text = "Consulta de Kardex Gerenal"
        productos_buscar.Show()
    End Sub

    Private Sub ExistenciaConsolidadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciaConsolidadaToolStripMenuItem.Click
        reporte_existencias.MdiParent = Me
        reporte_existencias.Label8.Text = "EXISTENCIA CONSOLIDADA"
        reporte_existencias.dedonde = 2
        reporte_existencias.Show()
    End Sub

    Private Sub NotaDeEntregaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeEntregaToolStripMenuItem.Click

    End Sub

    Private Sub OpticaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpticaToolStripMenuItem.Click

    End Sub

    Private Sub HistoriasClinicasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoriasClinicasToolStripMenuItem.Click
        mantenimiento_expedientes.MdiParent = Me
        mantenimiento_expedientes.Dock = DockStyle.Fill
        mantenimiento_expedientes.MaximizeBox = False
        mantenimiento_expedientes.dedonde = 1
        mantenimiento_expedientes.Show()
    End Sub

    Private Sub BuscarToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem7.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 11
        consulta_documento.titulo.Text = "CONSULTA HISTORIA CLINICA"
        consulta_documento.subtitulo.Text = "Doble clic sobre la historia a consultar"
        consulta_documento.radionumero.Visible = False
        consulta_documento.todas_tiendas.Visible = True
        consulta_documento.radionombre.Text = "NOMBRE"
        consulta_documento.RadioTelefono.Enabled = True
        consulta_documento.RadioTelefono.Visible = True
        consulta_documento.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem5.Click
        'HistoriaClinica_nueva.MdiParent = Me
        'HistoriaClinica_nueva.dedonde = 1
        'HistoriaClinica_nueva.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem3.Click
        facturacion_directa.MdiParent = Me
        facturacion_directa.dedonde = 52
        facturacion_directa.Show()
        facturacion_directa.Label9.Visible = True
        facturacion_directa.nit.Text = "CF"
        facturacion_directa.Label9.Text = "Nota de Entrega"
        facturacion_directa.ChDPI.Enabled = False
        facturacion_directa.nit.Enabled = False
    End Sub

    Private Sub AnularToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem2.Click
        'abro consulta de ajustes por ingreso
        consulta_documento.titulo.Text = "Movimientos de Ingreso"
        consulta_documento.subtitulo.Text = "De doble click sobre el movimiento a anular"
        consulta_documento.dedonde = 15
        consulta_documento.MdiParent = Me
        consulta_documento.Show()
    End Sub

    Private Sub CuentasBancariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasBancariasToolStripMenuItem.Click
        mantenimiento_ctas_bancarias.MdiParent = Me
        mantenimiento_ctas_bancarias.Show()
    End Sub

    Private Sub DesactivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesactivarToolStripMenuItem.Click
        'abro consulta de productos para desactivar un producto
        productos_buscar.dedonde = 4
        productos_buscar.Label1.Visible = True
        productos_buscar.Label1.ForeColor = Color.Red
        productos_buscar.Label1.Text = "Doble click sobre el producto a desactivar"
        productos_buscar.MdiParent = Me
        productos_buscar.Show()
    End Sub

    Private Sub BuscarToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem5.Click
        'abro consulta de ajustes por ingreso
        consulta_documento.titulo.Text = "Movimientos de Ingreso"
        consulta_documento.subtitulo.Text = "De doble click sobre el movimiento a consultar"
        consulta_documento.dedonde = 13
        consulta_documento.MdiParent = Me
        consulta_documento.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        mantenimiento_ctas_bancarias.MdiParent = Me
        mantenimiento_ctas_bancarias.nueva.Text = "Nuevo"
        mantenimiento_ctas_bancarias.modificar.Visible = False
        mantenimiento_ctas_bancarias.subtitulo.Text = "Selecciona con doble clic la cuenta"
        mantenimiento_ctas_bancarias.Show()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Label1.Text = DateTime.Now.ToString
        segundos = Val(segundos) + 1
        If segundos >= 10 Then
            Timer1.Stop() 'Timer stops functioning
            'VERIFICO SI TENGO REGISTROS EN LA OPTICA 
            Try
                conexiongopticsh.Open()
                consulta = "SELECT count(*) FROM clinica where id_agencia='" & no_agencia & "' and estado='P';"
                com = New MySqlCommand(consulta, conexiongopticsh)
                rs = com.ExecuteReader
                rs.Read()
                rxfinal(0) = rs(0)
                conexiongopticsh.Close()
                If rxfinal(0) = 0 Then
                    'NO HAY REGISTROS
                    ' MessageBox.Show("NO HYA REGISTROS")
                Else

                    Try
                        conexiongopticsh.Open()
                        consulta = "SELECT no_clinica,fecha,id_agencia,paciente,telefono,edad,ocupacion,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_av,rx5_od_add,rx5_od_av1,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_av,rx5_oi_add,rx5_oi_av1,motivo,chk1,chk5,chk9,chk11,chk12,obs,optometra,email,rx5_od_dnp,rx5_oi_dnp,rx5_dp,distancia,dx
                FROM clinica where id_agencia='" & no_agencia & "' and estado='p'"
                        com = New MySqlCommand(consulta, conexiongopticsh)
                        'verifico si la consulta me dio algun resultado, si no tengo no muestro nada
                        rs = com.ExecuteReader
                        rs.Read()
                        rxfinal(0) = rs(0)
                        rxfinal(1) = rs(1)
                        rxfinal(2) = rs(2)
                        rxfinal(3) = rs(3)
                        rxfinal(4) = rs(4)
                        rxfinal(5) = rs(5)
                        rxfinal(6) = rs(6)
                        'rx5 od
                        rxfinal(7) = rs(7)
                        rxfinal(8) = rs(8)
                        rxfinal(9) = rs(9)
                        rxfinal(10) = rs(10)
                        rxfinal(11) = rs(11)
                        rxfinal(12) = rs(12)
                        'rx5oi
                        rxfinal(13) = rs(13)
                        rxfinal(14) = rs(14)
                        rxfinal(15) = rs(15)
                        rxfinal(16) = rs(16)
                        rxfinal(17) = rs(17)
                        rxfinal(18) = rs(18)
                        'motivo
                        rxfinal(19) = rs(19)
                        'TRATAMIENTO
                        rxfinal(20) = rs(20)
                        rxfinal(21) = rs(21)
                        rxfinal(22) = rs(22)
                        rxfinal(23) = rs(23)
                        rxfinal(24) = rs(24)
                        'optometra
                        rxfinal(25) = rs(25)
                        'correo
                        rxfinal(26) = rs(26)
                        'distancias
                        rxfinal(27) = rs(27)
                        rxfinal(28) = rs(28)
                        rxfinal(29) = rs(29)
                        rxfinal(30) = rs(30)
                        rxfinal(31) = rs(31)
                        rxfinal(32) = rs(32)
                        rs.Close()
                        conexiongopticsh.Close()
                        'REALIZO LA VALIDACION PARA VER QUE TIPO DE LENTE ESCOGIERON
                        Select Case rxfinal(20)
                            Case 1
                                tipo_lente = "VISION SENCILLA"
                            Case 2
                                tipo_lente = "VISION SENCILLA DIGITAL"
                            Case 3
                                tipo_lente = "PROGRESIVO"
                            Case 4
                                tipo_lente = "BIFOCAL"
                        End Select
                        'REALIZO VALIDACION PARA TIPO DE MATERIAL
                        Select Case rxfinal(21)
                            Case 1
                                material = "POLICARBONATO"
                            Case 2
                                material = "THIN & LITE"
                            Case 3
                                material = "CR39"
                            Case 4
                                material = "VIDRIO"
                        End Select


                        'REALIZO VALIDACION DEL ANTIREFLEJANTE
                        Select Case rxfinal(22)
                            Case 1
                                antirreflejo = "CLEAR - "
                            Case 2
                                antirreflejo = " CLEAR PLUS - "
                        End Select
                        If rxfinal(23) = "1" Then
                            luz_azul = "SPEKTRA"
                        End If

                        'REALIZO VALIDACION DE FOTOCROMATICO
                        Select Case rxfinal(24)
                            Case 1
                                foto = "FOTOCROMATICO: BROWN"
                            Case 2
                                foto = "FOTOCROMATICO: GRAY"
                            Case 3
                                foto = "FOTOCROMATICO: GREEN"
                            Case 4
                                foto = "POLARIZADO: BR"
                            Case 5
                                foto = "POLARIZADO: GRAY"
                            Case 6
                                foto = "POLARIZADO: GREEN"
                        End Select

                        conexiongopticsh.Close()
                        'REALIZO LA IMPRESION 
                        Try
                            Dim PrintDoc As New PrintDocument
                            AddHandler PrintDoc.PrintPage, AddressOf Me.Print_recetatemp
                            PrintDoc.PrinterSettings.PrinterName = "TICKET"
                            PrintDoc.Print()
                        Catch ex As Exception
                            'MUESTRO ERROR DE IMPRESION
                            MessageBox.Show("La Impresion de historia clinica ha fallado, contacta con soporte tecnico", ex.ToString())
                        End Try
                        Try
                            'ACTUALIZO EL STATUS DE LA HISTORIA CLINICA PARA PODERLA PONER COMO IMPRESA 
                            conexiongopticsh.Open()
                            consulta = "UPDATE clinica set  estado='I' where no_clinica='" & rxfinal(0) & "'"
                            com = New MySqlCommand(consulta, conexiongopticsh)
                            com.ExecuteNonQuery()
                            conexiongopticsh.Close()
                        Catch ex As Exception
                            'SI NO PUDE EJECUTAR EL SCRIPT DOY MENSAJE DE ERROR 
                            conexiongopticsh.Close()
                            MessageBox.Show("No fue posible actualizar el estado de la historia clinica #" & rxfinal(0) & ", contacta con soporte tecnico", ex.ToString())
                        End Try
                    Catch ex As Exception
                        'SI NO PUEDO OBTENER LOS DATOS DE LA HISTORIA CLINICA MUESTRO ERROR
                        MsgBox("No fue posible obtener los datos de la agencia, si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexiongopticsh.Close()
                        Return
                    End Try
                End If
            Catch ex As Exception
                conexiongopticsh.Close()
                MessageBox.Show("No pude verificar si hay historias clinicas pendientes de imprimir")
                MessageBox.Show(ex.ToString)
                MessageBox.Show(ex.ToString)
            End Try
            'TERMINO MI PROCESO Y REINICIO RELOJ
            segundos = 0
            Timer1.Start()
            rxfinal(0) = ""
            'limpio variables 
            For i = 0 To 39 Step 1
                rxfinal(i) = ""
            Next
        End If
    End Sub
    Private Sub Print_recetatemp(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim fuente, fuente1, fuente2, fuente3 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        fuente1 = New Font("Consolas", 8)
        fuente2 = New Font("consolas", 7)
        fuente3 = New Font("Arial", 12, FontStyle.Regular)
        Dim prFont As New Font("Consolas", 7, FontStyle.Bold)
        'defino coordenada en horizontal 
        Dim CurX As Integer = 0
        'defino coordenada en vertical 
        Dim CurY As Integer = 0
        'defino ancho del rectangulo que tomo como base para imprimir centrado 
        Dim iWidth As Integer = 298
        Dim cellRect As RectangleF
        cellRect = New RectangleF()
        cellRect.Location = New Point(CurX, CurY)
        cellRect.Size = New Size(iWidth, CurY + 1050)
        'imprimo nombre de la empresa 
        'imprimo tipo de documento 
        'Imprimo Fecha
        cellRect.Location = New Point(CurX, CurY)
        ev.Graphics.DrawString("HISTORIA CLINICA", fuente3, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 20)
        ev.Graphics.DrawString("H:.. " & rxfinal(0), fuente, Brushes.Black, cellRect, TopLeft)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 25)
        ev.Graphics.DrawString("---------   SUCURSAL   --------- ", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 45)
        ev.Graphics.DrawString(agencia.Text, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 60)
        ev.Graphics.DrawString("Telefono: " & telefonotienda, fuente, Brushes.Black, cellRect, TopCenter)

        '  cellRect.Location = New Point(CurX, CurY + 75)
        '  ev.Graphics.DrawString("WWW.OPTICASDELUXE.COM", fuente, Brushes.Black, cellRect, TopCenter)

        'IMPRIMO DATOS DEL CLIENTE
        cellRect.Location = New Point(CurX, CurY + 100)
        ev.Graphics.DrawString("------   DATOS DEL CLIENTE   ------ ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 120)
        ev.Graphics.DrawString("FECHA: " & rxfinal(1), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 136)
        ev.Graphics.DrawString("CLIENTE:  " & rxfinal(3), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 162)
        ev.Graphics.DrawString("TELEFONO:  " & rxfinal(4), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 177)
        ev.Graphics.DrawString("CORREO:  " & rxfinal(27), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 202)
        ev.Graphics.DrawString("EDAD:  " & rxfinal(5), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 217)
        ev.Graphics.DrawString("OCUPACION:  " & rxfinal(6), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 242)
        ev.Graphics.DrawString("MOTIVO: " & rxfinal(19), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 270)
        ev.Graphics.DrawString("**ESTE NO ES COMPROBANTE DE PAGO**", fuente, Brushes.Black, cellRect, TopCenter)
        '////////********************
        ev.Graphics.DrawString("ESF.", New Font(fuente, FontStyle.Bold), Brushes.Black, 55, 285)
        ev.Graphics.DrawString("CIL.", New Font(fuente, FontStyle.Bold), Brushes.Black, 104, 285)
        ev.Graphics.DrawString("EJE.", New Font(fuente, FontStyle.Bold), Brushes.Black, 153, 285)
        ev.Graphics.DrawString("ADD.", New Font(fuente, FontStyle.Bold), Brushes.Black, 202, 285)
        '/////////*********************
        ev.Graphics.DrawString("OD", New Font(fuente, FontStyle.Bold), Brushes.Black, 10, 305)
        ev.Graphics.DrawString(rxfinal(7), New Font(fuente, FontStyle.Bold), Brushes.Black, 50, 305)
        ev.Graphics.DrawString(rxfinal(8), New Font(fuente, FontStyle.Bold), Brushes.Black, 99, 305)
        ev.Graphics.DrawString(rxfinal(9), New Font(fuente, FontStyle.Bold), Brushes.Black, 147, 305)
        ev.Graphics.DrawString(rxfinal(11), New Font(fuente, FontStyle.Bold), Brushes.Black, 197, 305)
        '/////////********************
        ev.Graphics.DrawString("OI", New Font(fuente, FontStyle.Bold), Brushes.Black, 10, 328)
        ev.Graphics.DrawString(rxfinal(13), New Font(fuente, FontStyle.Bold), Brushes.Black, 50, 328)
        ev.Graphics.DrawString(rxfinal(14), New Font(fuente, FontStyle.Bold), Brushes.Black, 99, 328)
        ev.Graphics.DrawString(rxfinal(15), New Font(fuente, FontStyle.Bold), Brushes.Black, 147, 328)
        ev.Graphics.DrawString(rxfinal(17), New Font(fuente, FontStyle.Bold), Brushes.Black, 197, 328)
        '//////**********************
        cellRect.Location = New Point(CurX, CurY + 350)
        ev.Graphics.DrawString("DNP Derecho:  " & rxfinal(28) & "                 Izquierdo:  " & rxfinal(29), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 368)
        ev.Graphics.DrawString("DP: " & rxfinal(30), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 385)
        ev.Graphics.DrawString("ALT: " & rxfinal(31), fuente, Brushes.Black, cellRect, TopLeft)
        '///************************
        cellRect.Location = New Point(CurX, CurY + 403)
        ev.Graphics.DrawString("TIPO DE LENTE: " & tipo_lente, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 420)
        ev.Graphics.DrawString("MATERIAL: " & material, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 435)
        ev.Graphics.DrawString("TRATAMIENTO: " & antirreflejo & " " & luz_azul, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 450)
        ev.Graphics.DrawString(foto, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 465)
        ev.Graphics.DrawString("OPTM: " & rxfinal(26), fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 490)
        ev.Graphics.DrawString("DX: " & rxfinal(32), fuente, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 520)
        ev.Graphics.DrawString("OBS: " & rxfinal(25), fuente, Brushes.Black, cellRect, TopLeft)
        '////////*******************
        cellRect.Location = New Point(CurX, CurY + 555)
        ev.Graphics.DrawString("**ESTE NO ES COMPROBANTE DE PAGO** ", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 560)
        ev.Graphics.DrawString("*", fuente, Brushes.Black, cellRect, TopLeft)
        ev.HasMorePages = False
    End Sub

    Private Sub AnulacionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnulacionToolStripMenuItem1.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 4
        consulta_documento.titulo.Text = "Anulacion de Facturas "
        consulta_documento.subtitulo.Text = "Doble Clic sobre la factura a Anular"
        consulta_documento.radionombre.Text = "NOMBRE"
        consulta_documento.radionumero.Text = "NUMERO FACTURA"
        consulta_documento.subtitulo.ForeColor = Color.Red
        consulta_documento.Show()
    End Sub

    Private Sub OrdenesDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDeTrabajoToolStripMenuItem.Click

    End Sub

    Private Sub DetalladoOrdenesTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalladoOrdenesTrabajoToolStripMenuItem.Click

    End Sub

    Private Sub NuevaToolStripMenuItem3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NuevaToolStripMenuItem4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FacturasDetalladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasDetalladoToolStripMenuItem.Click
        reporte_receta.MdiParent = Me
        reporte_receta.Label8.Text = "// DETALLE DE FACTURAS GENERAL"
        reporte_receta.dedonde = 3
        reporte_receta.Show()
    End Sub

    Private Sub MovimientoDeKardexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientoDeKardexToolStripMenuItem.Click
        productos_buscar.MdiParent = Me
        productos_buscar.dedonde = 3
        productos_buscar.Label8.Text = "Consulta de Kardex"
        productos_buscar.Show()
    End Sub

    Private Sub ExistenciasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExistenciasToolStripMenuItem1.Click
        reporte_existencias.MdiParent = Me
        reporte_existencias.dedonde = 1
        reporte_existencias.Show()
    End Sub

    Private Sub AbonoOrdenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbonoOrdenToolStripMenuItem.Click
        consulta_documento.dedonde = 0
        consulta_documento.Close()
        'abro ventana para mostrar todas las ordenes que tengan saldo 
        consulta_documento.Size = New System.Drawing.Size(1050, 500)
        consulta_documento.dedonde = 12
        consulta_documento.titulo.Text = "Ordenes con saldo"
        consulta_documento.subtitulo.Text = "Doble Clic sobre la orden a abonar/cancelar"
        consulta_documento.radionombre.Text = "NOMBRE DE PACIENTE"
        consulta_documento.radionumero.Text = "NUMERO ORDEN"
        consulta_documento.MdiParent = Me
        consulta_documento.Show()
        consulta_documento.TextBox1.Select()

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub RegistraPCTiendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistraPCTiendaToolStripMenuItem.Click
        usuarios.MdiParent = Me
        usuarios.dedonde = 2
        usuarios.Show()
        usuarios.titulo.Text = "GESTION DE AGENCIAS"
    End Sub

    Private Sub agencia_Click(sender As Object, e As EventArgs) Handles agencia.Click

    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDePreciosToolStripMenuItem.Click
        reporte_precios.MdiParent = Me
        reporte_precios.Show()
    End Sub

    Private Sub OrdenesDeTrabajoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdenesDeTrabajoToolStripMenuItem1.Click

        reporte_receta.dedonde = 1
        reporte_receta.Label8.Text = "// Reporte General Orden Trabajo"
        reporte_receta.ShowDialog()
    End Sub
    Private Sub ListaDeVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeVendedoresToolStripMenuItem.Click
        exportaexcel_temp.dedonde = 3
        exportaexcel_temp.MdiParent = Me
        exportaexcel_temp.Show()
    End Sub
    Private Sub GeneralToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem1.Click
        reporte_receta.MdiParent = Me
        reporte_receta.Label8.Text = "Reporte General Facturas"
        reporte_receta.dedonde = 2
        reporte_receta.Show()
    End Sub

    Private Sub NotaDeEntregaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NotaDeEntregaToolStripMenuItem1.Click
        reporte_receta.MdiParent = Me
        reporte_receta.Label8.Text = "Reporte General Notas de Entrega"
        reporte_receta.dedonde = 5
        reporte_receta.Show()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        facturacion_directa.MdiParent = Me
        facturacion_directa.dedonde = 20
        facturacion_directa.Show()
        facturacion_directa.Label9.Visible = True
        facturacion_directa.Label9.Text = "NOTA DE ENTREGA"
        facturacion_directa.nit.Text = "C/F."
    End Sub

    Private Sub ExistenciasPorMarcaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RecibosDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeVentaToolStripMenuItem.Click

        reporte_receta.dedonde = 7
        reporte_receta.Label8.Text = "// Reporte General Recibos de Pago"
        reporte_receta.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)

    End Sub

    Private Sub NotasDeEntregaDetalladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeEntregaDetalladoToolStripMenuItem.Click
        reporte_receta.MdiParent = Me
        reporte_receta.Label8.Text = "Reporte Detallado Notas de Entrega"
        reporte_receta.dedonde = 6
        reporte_receta.Show()
    End Sub

    Private Sub Promo2x1ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        selecciona_orden.dedonde = 3
        selecciona_orden.ShowDialog()
    End Sub

    Private Sub NuevoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem2.Click
        movimientos.MdiParent = Me
        movimientos.dedonde = 1
        movimientos.Label8.Text = "Movimientos - Entradas"
        movimientos.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem3.Click
        movimientos.MdiParent = Me
        movimientos.dedonde = 2
        movimientos.Label8.Text = "Movimientos - Salidas"
        movimientos.Show()
    End Sub

    Private Sub MoificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoificarToolStripMenuItem.Click
        consulta_documento.MdiParent = Me
        consulta_documento.dedonde = 9
        consulta_documento.titulo.Text = "CONSULTA HISTORIA CLINICA"
        consulta_documento.subtitulo.Text = "Doble clic sobre la historia a modificar"
        consulta_documento.radionumero.Text = "NO. HISTORIA"
        consulta_documento.radionombre.Text = "NOMBRE DE PACIENTE"
        consulta_documento.Show()
    End Sub

    Private Sub ExpedientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
End Class