Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports Newtonsoft.Json
Public Class facturacion_directa
    Public id_vendedor, serie, correlativo, fecha_anulacion, orden, recibo, material, aro, Marca_aro, tratamiento, serie_orden, recibo_anterior, TotalImpuesto, fechacertifica As String
    Dim consulta, movimiento, pregunta, dia, mes, ano, m_dia(2), m_mes(2), m_ano(2), m_nombre(2), m_telefono(2), m_direccion(2), m_nit(2), m_advertencia(2), m_total(2), m_cantidad(2), m_descripcion(2), m_precio(2), m_abono(2), m_saldo(2), m_observaciones(2), m_subtotal(2), m_descuento(2), m_enletras(2), fechalarga, enletras As String
    Dim precio1, Vbien, Vserv, Viva, Vtotal, SSubtotal, Sdescto As Decimal
    Dim Agregar_adenda As Boolean
    Public ordenlab, serieordenlab, ordtotal, ordabono, ordsaldo, tota_descuento As String
    Dim orden_cantidad, orden_agrega(1), valor(2), ContadorLinea, TotalServicio, TotalBienes, Mesano, DBienServ, DUmed, DCant, DDescrip, DNumL, DPunit, DPrecio, DDescto, DPtotal, DNombre, DTsiniva, DTiva, ValidaFel(), DfirmaElect, Fserie, Fnumero, Fcliente As String
    'para anualcion
    Dim RequestA As New conectorfelv2.RequestAnulacionFel
    Dim Datos_anulacion As Boolean
    Dim fechafact As Date
    Private Sub ChNIT_CheckedChanged(sender As Object, e As EventArgs) Handles ChNIT.CheckedChanged
        If Me.ChNIT.Checked = True Then
            nombre.ReadOnly = True
            If dedonde = 4 Then
            Else
                Label2.Text = "NIT"
                nit.Text = "CF"
                nombre.Text = "CONSUMIDOR FINAL"
                nit.Focus()
            End If

        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Telefonocliente_TextChanged(sender As Object, e As EventArgs) Handles Telefonocliente.TextChanged

    End Sub

    Private Sub ChDPI_CheckedChanged(sender As Object, e As EventArgs) Handles ChDPI.CheckedChanged
        If Me.ChDPI.Checked = True Then
            nombre.ReadOnly = False
            If dedonde = 4 Then
            Else
                Label2.Text = "CUI"
                nit.Text = ""
                nombre.Text = ""
                nit.Focus()
            End If

        End If
    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        'PRIMERO SACAMOS REGISTROS UNICOS
        For Each row In dtv_facturacion.Rows
            Dim Timpuesto, Tsinimpuesto, PrecioUnitarioTotal As Double

            Dim Tipo As String
            'obtengo el valor del IVA 
            Timpuesto = Val(row.cells(5).value / 1.12)
            Tsinimpuesto = FormatNumber(Timpuesto, 2)

            Timpuesto = Val(Timpuesto) * 0.12
            Timpuesto = FormatNumber(Timpuesto, 2)
            'valido el tipo de producto
            If row.cells(6).value = "N" Then
                Tipo = "B"
            Else
                Tipo = "S"

            End If
            'Realizo la multiplicacion de la cantidad por el precio unitario sin descuento 
            PrecioUnitarioTotal = Val(row.cells(4).value) * Val(row.cells(0).value)
            PrecioUnitarioTotal = FormatNumber(PrecioUnitarioTotal, 2)
            dtv_facturacionsinf.Rows.Add(row.cells(0).value, row.cells(1).value, row.cells(2).value, row.cells(3).value, row.cells(4).value, row.cells(5).value, Tipo, PrecioUnitarioTotal, Tsinimpuesto, Timpuesto, row.cells(7).value)
            'MessageBox.Show(row.cells(1).value)
            Timpuesto = 0
        Next
        'realizo la sumatoria del total para calcular los impuestos 
        Dim fila1 As DataGridViewRow = New DataGridViewRow()
        For Each fila1 In dtv_facturacionsinf.Rows
            TotalImpuesto += Convert.ToDouble(fila1.Cells(9).Value)
        Next
        ivav()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ivav()
    End Sub
    Sub ivav()
        ':::Funcion para obtener datos del libro de ventas 
        'OBTENGO LOS BIENES
        Vbien = 0
        Vserv = 0
        Vtotal = 0
        For Each row In dtv_facturacionsinf.Rows
            If row.cells(6).value = "B" Then
                dtv_medidas.Rows.Add(row.cells(5).value, 0)
            ElseIf row.cells(6).value = "S" Then

                dtv_medidas.Rows.Add(0, row.cells(5).value)
            End If
            Vtotal += Val(row.cells(9).value)
        Next

        For Each row3 In dtv_medidas.Rows
            Vbien += Val(row3.Cells(0).Value)
            Vserv += Val(row3.cells(1).value)

        Next
    End Sub
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim TopRigth As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat

    Private Sub PrintFactura_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintFactura.PrintPage
        Dim fuente, fuente1, fuente2, fuente3, fuente4, fuente5, fuente6 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Consolas", 9)
        fuente6 = New Font("Consolas", 9, FontStyle.Bold)
        fuente5 = New Font("Arial", 9, FontStyle.Bold)
        fuente4 = New Font("Arial", 9, FontStyle.Bold)
        fuente1 = New Font("Arial", 8)
        fuente2 = New Font("consolas", 7)
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
        e.Graphics.DrawImage(PictureBox1.Image, 75, 0, 140, 60)
        'nombre comercial 
        cellRect.Location = New Point(CurX, CurY + 18)
        e.Graphics.DrawString(dashboard.Sysnomestable, fuente1, Brushes.Black, cellRect, TopCenter)
        'razon social
        cellRect.Location = New Point(CurX, CurY + 30)
        e.Graphics.DrawString(dashboard.SysRazonsocial, fuente1, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 44)
        e.Graphics.DrawString(dashboard.direcciontienda & ", " & dashboard.SySMuni & ", " & dashboard.SysDepto, fuente1, Brushes.Black, cellRect, TopCenter)
        'imprimo NIT empresa
        cellRect.Location = New Point(CurX, CurY + 89)
        e.Graphics.DrawString("NIT: " & dashboard.SysNitempresa, fuente1, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 105)
        e.Graphics.DrawString("Sucursal: " & dashboard.agencia.Text, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 119)
        e.Graphics.DrawString("TELEFONO: " & dashboard.telefonotienda & "  PBX: " & dashboard.pbx, fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 133)
        e.Graphics.DrawString(dashboard.correotienda, fuente, Brushes.Black, cellRect, TopCenter)
        ' imprimo tipo de documento 
        cellRect.Location = New Point(CurX, CurY + 155)
        If dedonde = 51 Then
            'desde factura 
            e.Graphics.DrawString("Documento Tributario Electrónico FEL", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 170)
            e.Graphics.DrawString("Factura Electrónica", fuente, Brushes.Black, cellRect, TopCenter)
            'numero de autorizacion
            cellRect.Location = New Point(CurX, CurY + 188)
            e.Graphics.DrawString("Número de autorizacion ", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 199)
            e.Graphics.DrawString(DfirmaElect, fuente6, Brushes.Black, cellRect, TopCenter)
        ElseIf dedonde = 52 Then
            'desde nota de entrega
            e.Graphics.DrawString("NOTA DE ENTREGA", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 170)
            e.Graphics.DrawString("Este no es un documento fiscal", fuente, Brushes.Black, cellRect, TopCenter)
        ElseIf dedonde = 4 Then
            If DfirmaElect = "." Then
                'desde nota de entrega 
                'desde nota de entrega
                e.Graphics.DrawString("NOTA DE ENTREGA", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 170)
                e.Graphics.DrawString("Este no es un documento fiscal", fuente, Brushes.Black, cellRect, TopCenter)
            Else
                'desde factura 
                e.Graphics.DrawString("Documento Tributario Electrónico FEL", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 170)
                e.Graphics.DrawString("Factura Electrónica", fuente, Brushes.Black, cellRect, TopCenter)
                'numero de autorizacion
                cellRect.Location = New Point(CurX, CurY + 188)
                e.Graphics.DrawString("Número de autorizacion ", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 199)
                e.Graphics.DrawString(DfirmaElect, fuente6, Brushes.Black, cellRect, TopCenter)
            End If

        End If



        cellRect.Location = New Point(CurX, CurY + 220)
        e.Graphics.DrawString("Serie: " & Fserie, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 235)
        e.Graphics.DrawString("Número: " & Fnumero, fuente, Brushes.Black, cellRect, TopLeft)
        'Fecha de emision
        cellRect.Location = New Point(CurX, CurY + 252)
        If dedonde = 51 Then
            fecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        End If
        e.Graphics.DrawString("Fecha: " & fecha.Text, fuente, Brushes.Black, cellRect, TopLeft)
        'imprimo no de docto 
        ' cellRect.Location = New Point(CurX, CurY + 38)
        ' e.Graphics.DrawString(serie & "  - " & correlativo, fuente3, Brushes.Black, cellRect, TopCenter)
        ' cellRect.Location = New Point(CurX, CurY + 54)
        ' e.Graphics.DrawString("FECHA RECIBO " & fecha.Text, fuente, Brushes.Black, cellRect, TopCenter)
        'NIT CLIENTE
        cellRect.Location = New Point(CurX, CurY + 275)
        'valido si es cui o nit la factura 
        If ChDPI.Checked = True Then
            e.Graphics.DrawString("CUI: " & nit.Text, fuente, Brushes.Black, cellRect, TopLeft)
        Else
            e.Graphics.DrawString("NIT: " & nit.Text, fuente, Brushes.Black, cellRect, TopLeft)
        End If
        'Cliente
        cellRect.Location = New Point(CurX, CurY + 290)
        e.Graphics.DrawString("Nombre: " & nombre.Text, fuente, Brushes.Black, cellRect, TopLeft)
        e.Graphics.DrawString("UND", New Font(fuente, FontStyle.Bold), Brushes.Black, 5, 375)
        e.Graphics.DrawString("COD", New Font(fuente, FontStyle.Bold), Brushes.Black, 35, 375)
        e.Graphics.DrawString("DESCRIPCION", New Font(fuente, FontStyle.Bold), Brushes.Black, 85, 375)
        e.Graphics.DrawString("SUB-TOTAL", New Font(fuente, FontStyle.Bold), Brushes.Black, 210, 375)
        cellRect.Location = New Point(CurX, CurY + 340)
        e.Graphics.DrawString("--------------------------------------", fuente, Brushes.Black, cellRect, TopLeft)

        'defino el ancho del recuadro para la descripcion del producto
        iWidth = 152
        cellRect.Size = New Size(iWidth, CurY)
        'imprimo horizontal del dtv
        CurX = 73
        CurY = 400
        cellRect.Location = New Point(CurX, CurY)
        'defino en donde empieza el detalle de los productos 
        Dim cont = 0
        For linea = 0 To dtv_facturacion.RowCount - 1
            'codigo
            e.Graphics.DrawString(dtv_facturacion.Item(1, linea).Value.ToString, fuente2, Brushes.Black, 28, cont + CurY)
            e.Graphics.DrawString(dtv_facturacion.Item(0, linea).Value.ToString, fuente2, Brushes.Black, 8, cont + CurY, TopLeft)
            e.Graphics.DrawString(dtv_facturacion.Item(2, linea).Value.ToString, fuente2, Brushes.Black, cellRect, TopLeft)
            If orden_cantidad <= 1 Then
                If dedonde = 4 Then
                    'consulta de facturas
                    ' Label15.Text = 0
                    Label15.Text = dtv_facturacion.Item(5, linea).Value.ToString
                Else
                    Label15.Text = 0
                    Label15.Text = dtv_facturacion.Item(4, linea).Value.ToString
                End If

                Label15.Text = Format(CType(Label15.Text, Decimal), "#,##0.00")
                'realizo el llamado desde factura directa o consulta de factura 
                e.Graphics.DrawString(Label15.Text, fuente2, Brushes.Black, 275, cont + CurY, TopRigth)
            ElseIf orden_cantidad > 1 Then
                Label15.Text = 0
                'realizo llamado desde facturacion de orden de trabajo 
                Label15.Text = dtv_facturacionsinf.Item(7, linea).Value.ToString
                Label15.Text = Format(CType(Label15.Text, Decimal), "#,##0.00")
                e.Graphics.DrawString(Label15.Text, fuente2, Brushes.Black, 275, cont + CurY, TopRigth)
            End If

            cont += 33
            cellRect.Location = New Point(CurX, CurY + cont)
        Next
        iWidth = 288
        CurX = 0
        cellRect.Size = New Size(iWidth, CurY)
        'imprimo totales
        cellRect.Location = New Point(CurX, CurY + cont - 7)
        e.Graphics.DrawString("--------------------------------------", fuente, Brushes.Black, cellRect, TopCenter)
        cont = Val(cont) - 7
        CurY = Val(cont) + Val(CurY)
        Sdescto = 0
        SSubtotal = 0
        'imprimo total alineado a la izquierda
        If dedonde = 4 Then
            'abro desde consulta de facturas 
            'realizo la sumatoria de la columna descuento 
            For Each row As DataGridViewRow In dtv_facturacion.Rows
                Sdescto += Convert.ToDouble(row.Cells(3).Value)
                SSubtotal += Convert.ToDouble(row.Cells(5).Value)
            Next
        ElseIf dedonde = 51 And orden_cantidad > 1 Then
            'realizo los calculos desde facturacion orden de trabajo 

            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                Sdescto += Convert.ToDouble(row.Cells(3).Value)
                SSubtotal += Convert.ToDouble(row.Cells(7).Value)
            Next

        ElseIf dedonde = 51 And orden_cantidad = 1 Then
            'realizo los calculos desde factura directa 
            For Each row As DataGridViewRow In dtv_facturacion.Rows
                Sdescto += Convert.ToDouble(row.Cells(5).Value)
                SSubtotal += Convert.ToDouble(row.Cells(6).Value)
            Next
        End If
        'imprimo totales
        e.Graphics.DrawString("SUB-TOTAL      Q", fuente1, Brushes.Black, 110, CurY + 10)
        Label13.Text = Format(CType(Sdescto, Decimal), "#,##0.00")
        Label14.Text = Format(CType(SSubtotal, Decimal), "#,##0.00")
        TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")

        cellRect.Location = New Point(CurX, CurY + cont)
        e.Graphics.DrawString(Label14.Text, fuente1, Brushes.Black, 275, CurY + 10, TopRigth)

        e.Graphics.DrawString("DESCUENTO   Q", fuente1, Brushes.Black, 110, CurY + 25)
        cellRect.Location = New Point(CurX, CurY + 30)
        e.Graphics.DrawString(Label13.Text, fuente1, Brushes.Black, 275, CurY + 25, TopRigth)

        e.Graphics.DrawString("TOTAL                Q", fuente1, Brushes.Black, 110, CurY + 40)
        cellRect.Location = New Point(CurX, CurY + 35)
        e.Graphics.DrawString(TextBox4.Text, fuente1, Brushes.Black, 275, CurY + 40, TopRigth)

        'numero de autorizacion
        If dedonde = 51 Then
            'desde factura 
            cellRect.Location = New Point(CurX, CurY + 100)
            e.Graphics.DrawString("Fecha Certificacion ", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 125)
            e.Graphics.DrawString(fechacertifica, fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 145)
            e.Graphics.DrawString("** Sujeto a pagos trimestrales ISR **", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 180)
            e.Graphics.DrawString("CERTIFICADOR: INFILE, S.A.", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 195)
            e.Graphics.DrawString("NIT: 12521337", fuente, Brushes.Black, cellRect, TopCenter)

        ElseIf dedonde = 52 Then
            'nota de entrega

            cellRect.Location = New Point(CurX, CurY + 100)
            e.Graphics.DrawString("Fecha Entrega ", fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 125)
            e.Graphics.DrawString(fechacertifica, fuente, Brushes.Black, cellRect, TopCenter)
            cellRect.Location = New Point(CurX, CurY + 145)
            e.Graphics.DrawString("** Gracias por su compra! **", fuente, Brushes.Black, cellRect, TopCenter)
            ' cellRect.Location = New Point(CurX, CurY + 180)
            ' e.Graphics.DrawString("CERTIFICADOR: INFILE, S.A.", fuente, Brushes.Black, cellRect, TopCenter)
            ' cellRect.Location = New Point(CurX, CurY + 195)
            ' e.Graphics.DrawString("NIT: 12521337", fuente, Brushes.Black, cellRect, TopCenter)
        ElseIf dedonde = 4 Then
            If DfirmaElect = "." Then
                'nota de entrega

                cellRect.Location = New Point(CurX, CurY + 100)
                e.Graphics.DrawString("Fecha Entrega ", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 125)
                e.Graphics.DrawString(fechacertifica, fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 145)
                e.Graphics.DrawString("** Gracias por su compra! **", fuente, Brushes.Black, cellRect, TopCenter)
                ' cellRect.Location = New Point(CurX, CurY + 180)
                ' e.Graphics.DrawString("CERTIFICADOR: INFILE, S.A.", fuente, Brushes.Black, cellRect, TopCenter)
                ' cellRect.Location = New Point(CurX, CurY + 195)
                ' e.Graphics.DrawString("NIT: 12521337", fuente, Brushes.Black, cellRect, TopCenter)
            Else
                'desde factura 
                cellRect.Location = New Point(CurX, CurY + 100)
                e.Graphics.DrawString("Fecha Certificacion ", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 125)
                e.Graphics.DrawString(fechacertifica, fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 145)
                e.Graphics.DrawString("** Sujeto a pagos trimestrales ISR **", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 180)
                e.Graphics.DrawString("CERTIFICADOR: INFILE, S.A.", fuente, Brushes.Black, cellRect, TopCenter)
                cellRect.Location = New Point(CurX, CurY + 195)
                e.Graphics.DrawString("NIT: 12521337", fuente, Brushes.Black, cellRect, TopCenter)
            End If
        End If
        ' cellRect.Location = New Point(CurX, CurY + 220)
        ' e.Graphics.DrawString("** TÉRMINOS Y CONDICIONES **", fuente, Brushes.Black, cellRect, TopCenter)
        ' cellRect.Location = New Point(CurX, CurY + 240)
        ' e.Graphics.DrawString("*Cada orden contiene los aros y lentes seleccionados por el cliente, NO SE ACEPTAN CAMBIOS O DEVOLUCIONES POSTERIORES A SU COMPRA.", fuente1, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 285)
        'e.Graphics.DrawString("*Optical Plus+  No se hace responsable por garantías con RECETAS EXTERNAS.", fuente1, Brushes.Black, cellRect, TopLeft)

        'cellRect.Location = New Point(CurX, CurY + 320)
        'e.Graphics.DrawString("*Optical Plus+  Requiere como mínimo el 50% de anticipo, sobre la totalidad de la compra para poder procesar su orden de trabajo.", fuente1, Brushes.Black, cellRect, TopLeft)

        'cellRect.Location = New Point(CurX, CurY + 365)
        'e.Graphics.DrawString("*Se debe presentar recibo o factura para recoger su orden procesada.", fuente1, Brushes.Black, cellRect, TopLeft)

        'cellRect.Location = New Point(CurX, CurY + 400)
        'e.Graphics.DrawString("*Optical Plus+  No se hace responsable por órdenes de trabajo no recogidas después de los 30 días posteriores al presente documento.", fuente1, Brushes.Black, cellRect, TopLeft)

        'cellRect.Location = New Point(CurX, CurY + 448)
        'e.Graphics.DrawString("*Toda orden de trabajo tiene 6 meses de garantía por desperfecto de fábrica, NO APLICA EN: mercadería en liquidación, paquetes en promocion, gotas, lentes de contacto y recetas externas.", fuente1, Brushes.Black, cellRect, TopLeft)

        'cellRect.Location = New Point(CurX, CurY + 508)
        'e.Graphics.DrawString("*Las graduaciones realizadas por Optical Plus+, tienen garantía de 15 días por adaptación posterior a la entrega, NO NOS HACEMOS REPONSABLES DESPUES DE EL TIEMPO ESTIPULADO.", fuente1, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 570)
        'e.Graphics.DrawString("*SE DEBERÁ PRESENTAR FACTURA PARA CUALQUIER CONSULTA O COMENTARIO POSTERIOR A LA COMPRA.", fuente1, Brushes.Black, cellRect, TopCenter)


        e.HasMorePages = False
    End Sub

    Dim nitexiste As Boolean
    'factura electronica variables 
    Dim request As New conectorfelv2.RequestCertificacionFel
    Dim response As String
    Dim Datos_emisor
    Dim Datos_generales, Frases, Datos_receptor, Totales, Adenda, Total_impuestos, Item_un_impuesto As Boolean

    'Variables para detalle de productos 
    Private Sub numero_Click(sender As Object, e As EventArgs) Handles numero.Click

    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs)


    End Sub

    Dim UnProducto(14) As String
    ' /*bool Complemento_notas*/
    ' /*bool Complemento_cambiaria*/
    ' /*bool Complemento_especial*/
    ' /*bool Complemento_exportacion*/
    Private Sub anular_Click(sender As Object, e As EventArgs) Handles anular.Click
        Dim hora5 As String = Now.ToString("HH:mm:ss")
        'anulacion de factura contable 
        If dedonde = 4 Then
            'anulacion
            If observaciones.Text = "" Then
                MessageBox.Show("Por favor ingrese el motivo de la anulacion en el campo de OBSERVACIONES para poder continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                'pregunto antes de anular 
                pregunta = MsgBox("Se anulara la Factura Numero 00" & correlativo & "  a nombre de " & nombre.Text & vbCrLf & "  ¿Desea Continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Anulacion de Factura")
                If pregunta = vbYes Then
                    'actualizado el status de la factura 
                    fechafact = fecha.Text
                    fechacertifica = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss") & "-06:00"
                    Datos_anulacion = RequestA.Datos_anulacion(fechafact.ToString("yyyy-MM-dd"), fechacertifica, nit.Text, dashboard.SysNitempresa, observaciones.Text, DfirmaElect)
                    response = RequestA.enviar_anulacion_fel(dashboard.Sysaliasfel, dashboard.Sysllavefel, serie & "-" & correlativo & "A", "optica.sosa.vision@gmail.com", dashboard.Sysaliasfel, dashboard.Systokenfel, True)
                    'MsgBox(response)
                    ValidaFel = Split(response, ",")
                    If ValidaFel(0) = "respuesta:true" Then
                        ' actualizo el encabezado 
                        Try
                            'actualizo encabezado de factura para grabar los valores como anulada
                            conexion.Open()
                            consulta = "UPDATE facturas SET status='A',horaa='" & hora5 & "', obs='ANULADA: " & observaciones.Text & "',anuladopor='" & dashboard.usuario.Text & "', fechaanula='" & fechacertifica & "', fechaanulacion='" & fechacertifica & "' where firmaelectronica='" & DfirmaElect & "' "
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                            'elimino el movimiento del kardex
                            consulta = "DELETE FROM kardexinven WHERE   docto='" & correlativo & "' and serie='" & serie & "'"
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                            'libero la orden anexada la factura
                            consulta = "UPDATE orden set status='P',factura='', seriefact='' where factura='" & correlativo & "'  AND seriefact='" & serie & "'"
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                            'anulo movimiento de IVA
                            consulta = "UPDATE ivav SET status='A',anuladopor='" & dashboard.usuario.Text & "',fechaanulamov='" & fechacertifica & "' where no_docto='" & correlativo & "' and serie='" & serie & "' and id_agencia='" & dashboard.no_agencia & "'"
                            com = New MySqlCommand(consulta, conexion)
                            com.ExecuteNonQuery()
                            MessageBox.Show("Factura anulada con exito!")
                            conexion.Close()
                            Me.Dispose()
                        Catch ex As Exception
                            MsgBox("No fue posible grabar la anulacion, por favor avisa a Informatica" &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try
                    Else
                        MessageBox.Show("Error al enviar los datos a Infile, la factura no finalizo el proceso de anulacion, por favor envie una captura del error a informatica ")
                        MsgBox(response)
                    End If
                Else
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'enumero las filas a grabar 
        Dim Cuentafila As Integer
        ContadorLinea = 0
        Cuentafila = 0
        If dtv_facturacionsinf.Rows.Count > 0 Then
            For Each Fila As DataGridViewRow In dtv_facturacionsinf.Rows
                ContadorLinea = (Val(ContadorLinea) + 1).ToString("000")
                dtv_facturacionsinf.Item(11, Cuentafila).Value = ContadorLinea
                Cuentafila = Val(Cuentafila) + 1
                'MessageBox.Show(ContadorLinea)
            Next
        End If
        fechacertifica = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss") & "-06:00"
        Datos_generales = request.Datos_generales("GTQ", fechacertifica, "FACT", "", "", "")
        Datos_emisor = request.Datos_emisor("GEN", 1, "01001", "infile@opticalplus.com.gt", dashboard.SysCodpais, dashboard.SySMuni, dashboard.SysDepto, "CUIDAD", dashboard.SysNitempresa, dashboard.SysRazonsocial, dashboard.Sysnomestable)
        Datos_receptor = request.Datos_receptor(nit.Text, nombre.Text, "01001", correo.Text, dashboard.SysCodpais, dashboard.SySMuni, dashboard.SysDepto, "CUIDAD", "")
        Frases = request.Frases(1, 1, "", "")
        Frases = request.Frases(2, 1, "", "")
        For linea = 0 To dtv_facturacionsinf.RowCount - 1
            'bien o servicio
            DBienServ = dtv_facturacionsinf.Item(6, linea).Value.ToString
            'unidad de medida
            DUmed = "UND"
            'cantidad
            DCant = dtv_facturacionsinf.Item(0, linea).Value.ToString
            'descripcion
            DDescrip = dtv_facturacionsinf.Item(2, linea).Value.ToString
            'numero de linea
            DNumL = dtv_facturacionsinf.Item(11, linea).Value.ToString
            'Precio Unitario
            DPunit = dtv_facturacionsinf.Item(4, linea).Value.ToString
            'Precio (precio unit*cantdiad)
            DPrecio = dtv_facturacionsinf.Item(7, linea).Value.ToString
            'Descuento
            DDescto = dtv_facturacionsinf.Item(3, linea).Value.ToString
            'total
            DPtotal = dtv_facturacionsinf.Item(5, linea).Value.ToString
            'nombre corto del impuesto 
            DNombre = "IVA"
            'Monto Base (Sin IVa)
            DTsiniva = dtv_facturacionsinf.Item(8, linea).Value.ToString
            'Valor del impuesto (IVA)
            DTiva = dtv_facturacionsinf.Item(9, linea).Value.ToString
            Item_un_impuesto = request.Item_un_impuesto(DBienServ, DUmed, DCant, DDescrip, DNumL, DPunit, DPrecio, DDescto, DPtotal, DNombre, 1, "", DTsiniva, DTiva)
            'MessageBox.Show(DBienServ & " " & DUmed & " " & DCant & " " & DDescrip & " " & DNumL & " " & DPunit & " " & DPrecio & " " & DDescto & " " & DPtotal & " " & DNombre & " " & "1" & " " & "" & " " & DTsiniva & " " & DTiva)
            'limpio variables 
            DBienServ = ""
            DCant = ""
            DDescrip = ""
            DNumL = ""
            DPunit = ""
            DPrecio = ""
            DDescto = ""
            DPtotal = ""
            DTsiniva = ""
            DTiva = ""
        Next
        Total_impuestos = request.total_impuestos("IVA", TotalImpuesto)
        Totales = request.Totales(TextBox5.Text)
        response = request.enviar_peticion_fel(dashboard.Sysaliasfel, dashboard.Sysllavefel, serie & "-" & correlativo, "infile@opticalplus.com.gt", dashboard.Sysaliasfel, dashboard.Systokenfel, True)
        ' MsgBox(response)
        ValidaFel = Split(response, ",")
        If ValidaFel(0) = "respuesta:true" Then
            MessageBox.Show("Grabado con Exito!")
        Else
            MessageBox.Show("Error al grabar ")
        End If
        'MessageBox.Show(ValidaFel(3))
        'MessageBox.Show(ValidaFel(4))

    End Sub

    Dim tabladatos, tabla_medidas As DataTable
    Dim adaptador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Public tdescuento As Double
    Public dedonde, codigo2 As Integer


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'cargo la ventana para agregar el producto 
        carga_producto.dedonde = 1
        carga_producto.ShowDialog()
    End Sub

    Private Sub facturacion_directa_InputLanguageChanging(sender As Object, e As InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging

    End Sub

    Private Sub facturacion_directa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()

        End If
    End Sub
    Class respuesta
        Public Property nit As String
        Public Property nombre As String

    End Class
    Private Sub facturacion_directa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center
        TopRigth.Alignment = StringAlignment.Far
        Mesano = DateTime.Now.ToString("yyyy_MM")
        'asigno variable como true para no grabar ningun numero de nit hasta no comprobar si el nit existe o  no 
        nitexiste = True
        orden_cantidad = 1
        recibo_anterior = 0
        'doy estilo y agrego formato de decimales a la columna precio venta del dtv
        dtv_facturacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dtv_facturacion.Columns(3).DefaultCellStyle.Format = "N2"
        dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
        dtv_facturacion.DefaultCellStyle.Font = New Font("Arial", 9)

        If dedonde = 1 Then
            'consulta/re impresion factura contable 
            'busco el encabezado del documento seleccionado 
            'llamo al formulario desde la ventana de anulacion de documento y lo relleno con la info del documento seleccinado 
            Try
                conexion.Open()
                consulta = "SELECT f.cliente,f.fecha,v.nombre,f.telefono,f.nit,f.total,f.direccion,f.obs from facturas as f left join vendedores as v on (f.id_vendedor=v.id_codigo)  where no_factura='" & correlativo & "' and serie='" & serie & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                fecha.Text = rs(1)
                txt_vendedor.Text = rs(2)
                correo.Text = rs(3)
                nit.Text = rs(4)
                TextBox4.Text = rs(5)
                direccion.Text = rs(6)
                observaciones.Text = rs(7)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            'realizo la busquedad del detalle de la factura y la muestro en mi dtv
            'doy formato al textbox del total 
            TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            Try
                'limpio mi dtv para que elimine las columnas predefinidas
                dtv_facturacion.Columns.Clear()
                'dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                'dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
                'empiezo la consulta 
                consulta = "SELECT cantidad, id_codigo, obs, descto,precio,sum(precio*cantidad) as subtotal  FROM detfacturas where no_factura='" & correlativo & "' and serie='" & serie & "' GROUP BY id_codigo order by subtotal desc"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_facturacion.DataSource = tabladatos
                conexion.Close()
                dtv_facturacion.Columns(0).HeaderText = "CANTIDAD"
                dtv_facturacion.Columns(0).Width = 80
                dtv_facturacion.Columns(1).HeaderText = "CODIGO"
                dtv_facturacion.Columns(1).Width = 80
                dtv_facturacion.Columns(2).HeaderText = "DESCRIPCION"
                dtv_facturacion.Columns(2).Width = 335
                dtv_facturacion.Columns(3).HeaderText = "DECUENTO"
                dtv_facturacion.Columns(3).Width = 80
                dtv_facturacion.Columns(4).HeaderText = "PRECIO"
                dtv_facturacion.Columns(4).Width = 80
                ' doy estilo y agrego formato de decimales a la columna precio venta del dtv
                dtv_facturacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dtv_facturacion.Columns(3).DefaultCellStyle.Format = "N2"
                dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
                dtv_facturacion.DefaultCellStyle.Font = New Font("Arial", 9)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            Button7.Enabled = False
            nombre.Enabled = False
            nit.Enabled = False
            direccion.Enabled = False
            correo.Enabled = False
            txt_vendedor.Enabled = False
            Button1.Visible = False
            Button2.Text = "Anular"
            Button4.Enabled = False
            'orden el dtv facturacion 
        ElseIf dedonde = 4 Then

            ' anulacion factura contable 
            fecha_anulacion = DateTime.Now.ToString("yyyy-MM-dd")
            'busco el encabezado del documento seleccionado 
            'llamo al formulario desde la ventana de anulacion de documento y lo relleno con la info del documento seleccinado 
            Try
                conexion.Open()
                consulta = "SELECT f.cliente,f.fecha,v.nombre,f.telefono,f.nit,f.total,f.direccion,f.firmaelectronica,f.email,f.obs,f.felfechacertifica from facturas as f left join vendedores as v on (f.id_vendedor=v.id_codigo)  where no_factura='" & correlativo & "' and serie='" & serie & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(0)
                fecha.Text = rs(1)
                txt_vendedor.Text = rs(2)
                Telefonocliente.Text = rs(3)
                nit.Text = rs(4)
                TextBox4.Text = rs(5)
                direccion.Text = rs(6)
                DfirmaElect = rs(7)
                correo.Text = rs(8)
                If anular.Visible = False Then
                    observaciones.Text = rs(9)
                Else

                End If

                fechacertifica = rs(10)
                Fserie = serie
                Fnumero = correlativo
                rs.Close()
                conexion.Close()
                Label7.Visible = True
                '  MessageBox.Show(fechacertifica)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try

            'realizo la busquedad del detalle de la factura y la muestro en mi dtv
            'doy formato al textbox del total 
            TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            Try
                'limpio mi dtv para que elimine las columnas predefinidas
                dtv_facturacion.Columns.Clear()
                'dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                'dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
                'empiezo la consulta 
                consulta = "SELECT cantidad, id_codigo, obs, format(descto,2), format(precio,2), format(precio*cantidad,2) as subtotal FROM detfacturas where no_factura='" & correlativo & "' and serie='" & serie & "'  GROUP BY id_codigo order by subtotal desc"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_facturacion.DataSource = tabladatos
                conexion.Close()
                dtv_facturacion.Columns(0).HeaderText = "CANTIDAD"
                dtv_facturacion.Columns(0).Width = 70
                dtv_facturacion.Columns(1).HeaderText = "CODIGO"
                dtv_facturacion.Columns(1).Width = 73
                dtv_facturacion.Columns(2).HeaderText = "DESCRIPCION"
                dtv_facturacion.Columns(2).Width = 300
                dtv_facturacion.Columns(3).HeaderText = "DECUENTO"
                dtv_facturacion.Columns(3).Width = 73
                dtv_facturacion.Columns(4).HeaderText = "PRECIO"
                dtv_facturacion.Columns(4).Width = 73
                dtv_facturacion.Columns(5).HeaderText = "SUB-TOTAL"
                dtv_facturacion.Columns(5).Width = 73
                ' doy estilo y agrego formato de decimales a la columna precio venta del dtv
                dtv_facturacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dtv_facturacion.Columns(3).DefaultCellStyle.Format = "N2"
                dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
                dtv_facturacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dtv_facturacion.Columns(5).DefaultCellStyle.Format = "N2"
                dtv_facturacion.DefaultCellStyle.Font = New Font("Arial", 9)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            Dim Total, desto As Double
            'realizo la suma de la columna precio del dtv recetapara mostrar en tiempo real lo que se va cobrar  
            Dim fila As DataGridViewRow = New DataGridViewRow()
            For Each fila In dtv_facturacion.Rows
                Total += Convert.ToDouble(fila.Cells(5).Value)
                desto += Convert.ToDouble(fila.Cells(3).Value)
            Next
            TextBox5.Text = Val(Total.ToString) - Val(desto.ToString)
            nombre.Enabled = False
            nit.Enabled = False
            direccion.Enabled = False
            correo.Enabled = False
            txt_vendedor.Enabled = False
            Button1.Visible = False
            Button2.Visible = False
            fecha.Enabled = False
            Button7.Enabled = False



        ElseIf dedonde = 51 Then
            'obtengo correlativo de facturas 
            Try
                conexion.Open()
                consulta = "SELECT facturas,seriefac FROM catagencias WHERE id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = rs(1)
                'obtengo el correlativo a seguir
                rs.Close()
                conexion.Close()
                Button4.Enabled = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Me.Dispose()
            End Try
            ' correlativo = Val(correlativo) + 1
            numero.Text = "FACTURA   000" & correlativo
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            dia = DateTime.Now.ToString("dd")
            mes = DateTime.Now.ToString("MM")
            ano = DateTime.Now.ToString("yyyy")
            nit.Select()

        ElseIf dedonde = 52 Then
            'abro desde nota de entrega
            'es la misma fuuncion que una factura solo que con diferente correlativo y sin ceritificar 
            'obtengo correlativo de las notas de entregaa
            Try
                conexion.Open()
                consulta = "SELECT comprobante,seriecomp FROM catagencias WHERE id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = rs(1)
                'obtengo el correlativo a seguir
                rs.Close()
                conexion.Close()
                Button4.Enabled = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Me.Dispose()
            End Try
            ' correlativo = Val(correlativo) + 1
            numero.Text = "NOTA ENTREGA  000" & correlativo
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            dia = DateTime.Now.ToString("dd")
            mes = DateTime.Now.ToString("MM")
            ano = DateTime.Now.ToString("yyyy")
            txt_vendedor.Select()
            nombre.ReadOnly = False
        End If
    End Sub

    Private Sub txt_vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vendedor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'muestra la ventana para poder seleccionar al vendedor 
            If Me.txt_vendedor.Text = "" Then
                muestra_vendedor.MdiParent = dashboard
                muestra_vendedor.dedonde = 1
                muestra_vendedor.Show()
            Else
            End If
        End If

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txt_vendedor.TextChanged




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim hora5 As String = Now.ToString("hh:mm:ss")
        'separo la fecha que tenga el textbox fecha
        ano = Mid(fecha.Text, 1, Len(fecha.Text) - 6)
        mes = Mid(fecha.Text, 6, Len(fecha.Text) - 8)
        dia = Mid(fecha.Text, 9, Len(fecha.Text) - 1)
        'verifico de donde tengo abierta la ventana para grabar la accion solicitada
        movimiento = dedonde
        If dedonde = 51 Then

            'Cargo la ventana para realizar el cobro  desde la factura
            cobrar_orden.dedonde = 1
            cobrar_orden.TextBox1.Text = correlativo
            cobrar_orden.TextBox2.Text = serie
            cobrar_orden.TextBox3.Text = TextBox5.Text
            cobrar_orden.total_orden = TextBox5.Text
            cobrar_orden.nombre = nombre.Text
            cobrar_orden.fecha = fecha.Text
            cobrar_orden.id_vendedor = id_vendedor
            cobrar_orden.TextBox8.Text = "RECIBO DE CANCELACION FACTURA # " & correlativo & " - " & serie
            cobrar_orden.Button2.Enabled = False
            cobrar_orden.ShowDialog()
            Button4.Select()
        ElseIf dedonde = 52 Then
            'cobro desde nota de entrega 
            cobrar_orden.dedonde = 1
            cobrar_orden.TextBox1.Text = correlativo
            cobrar_orden.TextBox2.Text = serie
            cobrar_orden.TextBox3.Text = TextBox5.Text
            cobrar_orden.total_orden = TextBox5.Text
            cobrar_orden.nombre = nombre.Text
            cobrar_orden.fecha = fecha.Text
            cobrar_orden.id_vendedor = id_vendedor
            cobrar_orden.TextBox8.Text = "RECIBO DE CANCELACION NOTA ENTREGA # " & correlativo & " - " & serie
            cobrar_orden.Button2.Enabled = False
            cobrar_orden.ShowDialog()
            Button4.Select()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Telefonocliente.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles direccion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            nit.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles direccion.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nit.KeyPress
        'valido si estoy ingresando DPI o NIT 
        If ChDPI.Checked = True Then
            e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        End If
        If Asc(e.KeyChar) = 13 Then
            If ChDPI.Checked = True Then
                'es con DPI no hago nada solo paso a nombre 
                nombre.Focus()
            ElseIf ChDPI.Checked = False Then
                If nit.Text = "" Then
                    nombre.Text = "CONSUMIDOR FINAL"
                    nit.Text = "CF"
                    txt_vendedor.Focus()
                Else
                    'verifico si el NIT existe en la base de datos
                    Try
                        conexion.Open()
                        consulta = "select nit,nombre from b_nits where nit='" & nit.Text & "' "
                        com = New MySqlCommand(consulta, conexion)
                        rs = com.ExecuteReader
                        rs.Read()
                        nombre.Text = rs(1)
                        txt_vendedor.Focus()
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
                            nombre.Text = result.nombre.ToString()
                            nitexiste = False
                            txt_vendedor.Focus()
                        End If
                    End Try
                End If

            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles nit.TextChanged

    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub

    Private Sub dtv_facturacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_facturacion.CellContentClick

    End Sub

    Private Sub telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles correo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Print_Factura(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        'puedo utilizar la variable mes para poder imprimir el total en latras(PENDIENTE)
        Dim largo = Len(CStr(Format(CDbl(TextBox4.Text), "#,###.00")))
        Dim decimales = Mid(CStr(Format(CDbl(TextBox4.Text), "#,###.00")), largo - 2)
        enletras = GetMyNumberToWords(TextBox4.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
        'obtengo la fecha larga  
        fechalarga = fecha.Text
        fechalarga = Format(Now.ToLongDateString.ToUpper)
        Dim fuente As Font
        Dim margenEsq As Single = ev.MarginBounds.Left ' defino margen a impresion de la grilla
        Dim cont = m_cantidad(2)
        ev.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 10)
        'funcion para imprimir 
        'primera coordenada alinea en horizontal
        'segunda coordenada alinea en vertical 
        'Imprimo Fecha
        ev.Graphics.DrawString(dia, New Font(fuente, FontStyle.Regular), Brushes.Black, m_dia(1), m_dia(2))
        ev.Graphics.DrawString(mes, New Font(fuente, FontStyle.Regular), Brushes.Black, m_mes(1), m_mes(2))
        ev.Graphics.DrawString(ano, New Font(fuente, FontStyle.Regular), Brushes.Black, m_ano(1), m_ano(2))
        'Imprimo nombre de cliente 
        ev.Graphics.DrawString(nombre.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nombre(1), m_nombre(2))
        'imprimo direccion 
        ev.Graphics.DrawString(direccion.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_direccion(1), m_direccion(2))
        'imprimo nit 
        ev.Graphics.DrawString(nit.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nit(1), m_nit(2))
        'Imprimo No. de DOcumento y Serie 
        ev.Graphics.DrawString("Fact.:  000" & correlativo & " - " & serie, New Font(fuente, FontStyle.Regular), Brushes.Black, m_advertencia(1), m_advertencia(2))
        'imprimo total de la factura 
        ev.Graphics.DrawString(TextBox4.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_total(1), m_total(2))
        'Imprimo datagrid view (cantidad, codigo, descripcion)
        For linea = 0 To dtv_facturacion.RowCount - 1
            If cont < 900 Then
                ev.Graphics.DrawString(dtv_facturacion.Item(0, linea).Value.ToString, fuente, Brushes.Black, m_cantidad(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(2, linea).Value.ToString, fuente, Brushes.Black, m_descripcion(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(4, linea).Value.ToString, fuente, Brushes.Black, m_precio(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(5, linea).Value.ToString, fuente, Brushes.Black, m_subtotal(1), cont)
                cont += 7
            Else
                cont = 370
            End If
        Next
        'imprimo el descuento total 
        ev.Graphics.DrawString("Descuento  " & tota_descuento, New Font(fuente, FontStyle.Regular), Brushes.Black, m_descuento(1), m_descuento(2))
        'imprimo cantidad en letras 
        ev.Graphics.DrawString(enletras, New Font(fuente, FontStyle.Regular), Brushes.Black, m_enletras(1), m_enletras(2))
        ev.HasMorePages = False

    End Sub
    Private Sub rePrint_Factura(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        'puedo utilizar la variable mes para poder imprimir el total en latras(PENDIENTE)
        Dim largo = Len(CStr(Format(CDbl(TextBox4.Text), "#,###.00")))
        Dim decimales = Mid(CStr(Format(CDbl(TextBox4.Text), "#,###.00")), largo - 2)
        enletras = GetMyNumberToWords(TextBox4.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
        'obtengo la fecha larga  
        fechalarga = fecha.Text
        fechalarga = Format(Now.ToLongDateString.ToUpper)
        Dim fuente As Font
        Dim margenEsq As Single = ev.MarginBounds.Left ' defino margen a impresion de la grilla
        Dim cont = m_cantidad(2)
        ev.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 10)
        'funcion para imprimir 
        'primera coordenada alinea en horizontal
        'segunda coordenada alinea en vertical 
        'Imprimo Fecha
        ev.Graphics.DrawString(dia, New Font(fuente, FontStyle.Regular), Brushes.Black, m_dia(1), m_dia(2))
        ev.Graphics.DrawString(mes, New Font(fuente, FontStyle.Regular), Brushes.Black, m_mes(1), m_mes(2))
        ev.Graphics.DrawString(ano, New Font(fuente, FontStyle.Regular), Brushes.Black, m_ano(1), m_ano(2))
        'Imprimo nombre de cliente 
        ev.Graphics.DrawString(nombre.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nombre(1), m_nombre(2))
        'imprimo direccion 
        ev.Graphics.DrawString(direccion.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_direccion(1), m_direccion(2))
        'imprimo nit 
        ev.Graphics.DrawString(nit.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nit(1), m_nit(2))
        'Imprimo No. de DOcumento y Serie 
        ev.Graphics.DrawString("Fact.:  000" & correlativo & " - " & serie, New Font(fuente, FontStyle.Regular), Brushes.Black, m_advertencia(1), m_advertencia(2))
        'imprimo total de la factura 
        ev.Graphics.DrawString(TextBox4.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_total(1), m_total(2))
        'Imprimo datagrid view (cantidad, codigo, descripcion)
        For linea = 0 To dtv_facturacion.RowCount - 1
            If cont < 900 Then
                ev.Graphics.DrawString(dtv_facturacion.Item(0, linea).Value.ToString, fuente, Brushes.Black, m_cantidad(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(2, linea).Value.ToString, fuente, Brushes.Black, m_descripcion(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(4, linea).Value.ToString, fuente, Brushes.Black, m_precio(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(5, linea).Value.ToString, fuente, Brushes.Black, m_subtotal(1), cont)
                cont += 7
            Else
                cont = 370
            End If
        Next
        'imprimo el descuento total 
        ev.Graphics.DrawString("Descuento            " & tota_descuento, New Font(fuente, FontStyle.Regular), Brushes.Black, m_descuento(1), m_descuento(2))
        'imprimo cantidad en letras 
        ev.Graphics.DrawString(enletras, New Font(fuente, FontStyle.Regular), Brushes.Black, m_enletras(1), m_enletras(2))
        ev.HasMorePages = False

    End Sub
    Private Sub Print_orden(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim fuente As Font
        Dim margenEsq As Single = ev.MarginBounds.Left ' defino margen a impresion de la grilla
        Dim cont = m_cantidad(2)
        ev.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 10)
        'funcion para imprimir 
        'primera coordenada alinea en horizontal
        'segunda coordenada alinea en vertical 
        'Imprimo Fecha
        ev.Graphics.DrawString(dia, New Font(fuente, FontStyle.Regular), Brushes.Black, m_dia(1), m_dia(2))
        ev.Graphics.DrawString(mes, New Font(fuente, FontStyle.Regular), Brushes.Black, m_mes(1), m_mes(2))
        ev.Graphics.DrawString(ano, New Font(fuente, FontStyle.Regular), Brushes.Black, m_ano(1), m_ano(2))
        'Imprimo nombre de cliente 
        ev.Graphics.DrawString(nombre.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nombre(1), m_nombre(2))
        'imprimo direccion 
        ev.Graphics.DrawString(direccion.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_direccion(1), m_direccion(2))
        'imprimo telefono 
        ev.Graphics.DrawString(correo.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_telefono(1), m_telefono(2))
        'Imprimo No. de DOcumento y Serie 
        ev.Graphics.DrawString("Ord.:  000" & correlativo & " - " & serie, New Font(fuente, FontStyle.Regular), Brushes.Black, m_advertencia(1), m_advertencia(2))
        'imprimo total de la factura 
        ev.Graphics.DrawString(TextBox4.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_total(1), m_total(2))
        'imprimo el abono 
        ev.Graphics.DrawString(TextBox4.Text, New Font(fuente, FontStyle.Regular), Brushes.Black, m_abono(1), m_abono(2))

        'imprimo el saldo 
        ev.Graphics.DrawString("0.00", New Font(fuente, FontStyle.Regular), Brushes.Black, m_saldo(1), m_saldo(2))

        'Imprimo datagrid view (cantidad, codigo, descripcion)
        For linea = 0 To dtv_facturacion.RowCount - 1
            If cont < 900 Then
                ev.Graphics.DrawString(dtv_facturacion.Item(0, linea).Value.ToString, fuente, Brushes.Black, m_cantidad(1), cont)
                ev.Graphics.DrawString(dtv_facturacion.Item(2, linea).Value.ToString, fuente, Brushes.Black, m_descripcion(1), cont)
                ev.Graphics.DrawString("---", fuente, Brushes.Black, m_precio(1), cont)
                cont += 6
            Else
                cont = 38
            End If
        Next

        ev.HasMorePages = False

    End Sub

    Private Sub fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fecha.KeyPress



    End Sub

    Private Sub fecha_TextChanged(sender As Object, e As EventArgs) Handles fecha.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dedonde = 51 Then
            'valido desde facturacion
            If correo.Text = "" Then
                'si es factura verifico el campo correo 
                MessageBox.Show("No puedes emitir una factura sin tener correo de cliente", "Correo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf correo.Text = "." Then
                'si es factura verifico el correo de cliente 
                MessageBox.Show("No puedes emitir una factura sin tener correo de cliente", "Correo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            Else

                'si telefono esta vacio lo igualo a punto 
                If Telefonocliente.Text = "" Then
                    Telefonocliente.Text = "."
                End If
                Button4.Enabled = False
                'valido si es factura con DPI o con CUI
                If ChDPI.Checked = True Then
                Else
                    'valido si el NIT existe para grabar en bitacora o omitir
                    If nitexiste = True Then
                    Else
                        Try
                            'realizo la grabacion en la base de datos de G-optics
                            conexion.Open()
                            consulta = "INSERT INTO b_nits(nit,nombre) values('" & nit.Text & "','" & nombre.Text & "')"
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
                End If


                'llamo a la funcion que obtiene los datos para libro de iva
                ivav()
                'obtengo la hora para grabar
                Dim hora6 As String = Now.ToString("hh:mm:ss")
                'obtengo el total de la factura en letras
                'puedo utilizar la variable mes para poder imprimir el total en latras(PENDIENTE)
                Dim largo = Len(CStr(Format(CDbl(TextBox4.Text), "#,###.00")))
                Dim decimales = Mid(CStr(Format(CDbl(TextBox4.Text), "#,###.00")), largo - 2)
                enletras = GetMyNumberToWords(TextBox4.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
                'enumero las filas a grabar 
                Dim Cuentafila As Integer
                ContadorLinea = 0
                Cuentafila = 0
                If dtv_facturacionsinf.Rows.Count > 0 Then
                    For Each Fila As DataGridViewRow In dtv_facturacionsinf.Rows
                        ContadorLinea = (Val(ContadorLinea) + 1).ToString("000")
                        dtv_facturacionsinf.Item(11, Cuentafila).Value = ContadorLinea
                        Cuentafila = Val(Cuentafila) + 1
                    Next
                End If


                'FACTURA NUEVA
                movimiento = dedonde
                    'obtengo el numero de FACTURA
                    'realizo la sumatoria de la columna descuento 
                    For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                        tota_descuento += Val(row.Cells(3).Value)
                    Next
                    tota_descuento = Format(CType(tota_descuento, Decimal), "#,##0.00")
                    'obtengo el correlativo actual
                    Try
                        conexion.Open()
                        consulta = "SELECT facturas,seriefac FROM catagencias WHERE id_agencia='" & dashboard.no_agencia & "'"
                        com = New MySqlCommand(consulta, conexion)
                        rs = com.ExecuteReader
                        rs.Read()
                        correlativo = rs(0)
                        serie = rs(1)
                        rs.Close()
                        conexion.Close()
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & " -Verifica tu conexion a internet " &
                       vbCrLf & vbCrLf & ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try





                'emito factura
                Fcliente = Replace(nombre.Text, "&", "&amp;")
                    Fcliente = Replace(nombre.Text, "'", "&apos;")
                    Fcliente = Replace(nombre.Text, "'", "&apos;")
                    'obtengo el correlativo a seguir
                    'correlativo = Val(correlativo) + 1
                    'realizo el envio de datos a Infile 
                    fechacertifica = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss") & "-06:00"
                    Datos_generales = request.Datos_generales("GTQ", fechacertifica, "FACT", "", "", "")
                    Datos_emisor = request.Datos_emisor("GEN", dashboard.SysEstable, "01001", "infile@opticalplus.com.gt", dashboard.SysCodpais, dashboard.SysDepto, dashboard.SySMuni, dashboard.Sysdireccion, dashboard.SysNitempresa, dashboard.SysRazonsocial, dashboard.Sysnomestable)
                    'valido si es factura con CUI o con NIt
                    If ChDPI.Checked = True Then
                        Datos_receptor = request.Datos_receptor(nit.Text, nombre.Text, "01001", correo.Text, dashboard.SysCodpais, dashboard.SysDepto, dashboard.SySMuni, "CIUDAD", "CUI")
                    Else
                        Datos_receptor = request.Datos_receptor(nit.Text, nombre.Text, "01001", correo.Text, dashboard.SysCodpais, dashboard.SysDepto, dashboard.SySMuni, "CIUDAD", "")

                    End If
                    Frases = request.Frases(1, 1, "", "")
                    ' Frases = request.Frases(2, 1, "", "")
                    For linea = 0 To dtv_facturacionsinf.RowCount - 1
                        'bien o servicio
                        DBienServ = dtv_facturacionsinf.Item(6, linea).Value.ToString
                        'unidad de medida
                        DUmed = "UND"
                        'cantidad
                        DCant = dtv_facturacionsinf.Item(0, linea).Value.ToString
                        'descripcion
                        DDescrip = dtv_facturacionsinf.Item(2, linea).Value.ToString
                        'elimino simbolos especiales antes de lanzar a infile
                        DDescrip = Replace(DDescrip, "&", "&amp;")
                        'numero de linea
                        DNumL = dtv_facturacionsinf.Item(11, linea).Value.ToString
                        'Precio Unitario
                        DPunit = dtv_facturacionsinf.Item(4, linea).Value.ToString
                        'Precio (precio unit*cantdiad)
                        DPrecio = dtv_facturacionsinf.Item(7, linea).Value.ToString
                        'Descuento
                        DDescto = dtv_facturacionsinf.Item(3, linea).Value.ToString
                        'total
                        DPtotal = dtv_facturacionsinf.Item(5, linea).Value.ToString
                        'nombre corto del impuesto 
                        DNombre = "IVA"
                        'Monto Base (Sin IVa)
                        DTsiniva = dtv_facturacionsinf.Item(8, linea).Value.ToString
                        'Valor del impuesto (IVA)
                        DTiva = dtv_facturacionsinf.Item(9, linea).Value.ToString
                        Item_un_impuesto = request.Item_un_impuesto(DBienServ, DUmed, DCant, DDescrip, DNumL, DPunit, DPrecio, DDescto, DPtotal, DNombre, 1, "", DTsiniva, DTiva)
                        'MessageBox.Show(DBienServ & " " & DUmed & " " & DCant & " " & DDescrip & " " & DNumL & " " & DPunit & " " & DPrecio & " " & DDescto & " " & DPtotal & " " & DNombre & " " & "1" & " " & "" & " " & DTsiniva & " " & DTiva)
                        'limpio variables 
                        DBienServ = ""
                        DCant = ""
                        DDescrip = ""
                        DNumL = ""
                        DPunit = ""
                        DPrecio = ""
                        DDescto = ""
                        DPtotal = ""
                        DTsiniva = ""
                        DTiva = ""
                    Next
                    Total_impuestos = request.total_impuestos("IVA", TotalImpuesto)
                    Totales = request.Totales(TextBox5.Text)
                response = request.enviar_peticion_fel(dashboard.Sysaliasfel, dashboard.Sysllavefel, serie & "-" & correlativo, "infile@opticalplus.com.gt", dashboard.Sysaliasfel, dashboard.Systokenfel, True)
                ValidaFel = Split(response, ",")
                If ValidaFel(0) = "respuesta:true" Then
                    DfirmaElect = ValidaFel(4)
                    '  MessageBox.Show(ValidaFel(5))
                    ' MessageBox.Show(ValidaFel(6))
                    DfirmaElect = Mid(DfirmaElect, 7)
                    Fserie = Mid(ValidaFel(5), 8)
                    Fnumero = Mid(ValidaFel(6), 9)
                    fechacertifica = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    'realizo la grabacion del encabezado
                    Try
                        conexion.Open()
                        consulta = "INSERT INTO facturas(no_factura,serie,fecha,status,fechap,id_cliente,cliente,nit,id_vendedor,direccion,total,tdescto,piva,cont_cred,obs,hechopor,id_agencia,impresa,no_docto,no_autoriza,telefono,email,horai,firmaelectronica,felfechacertifica) values('" & Fnumero & "','" & Fserie & "','" & fecha.Text & "', 'I','" & fecha.Text & "','" & nit.Text & "', '" & nombre.Text & "', '" & nit.Text & "', '" & id_vendedor & "', '" & direccion.Text & "', '" & TextBox5.Text & "', '" & tdescuento & "', '12.00','1','" & observaciones.Text & "', '" & dashboard.usuario.Text & "', '" & dashboard.no_agencia & "', 'S','" & correlativo & "','" & serie & "','" & Telefonocliente.Text & "','" & correo.Text & "', '" & hora6 & "','" & DfirmaElect & "','" & fechacertifica & "'  )"
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                        conexion.Close()

                    Catch ex As Exception
                        MsgBox("No fue posible grabar el encabezado de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try

                    If grabar1.Text = 0 Then
                        'guardo el detalle del documento desde factura
                        Try
                            conexion.Open()
                            consulta = "INSERT INTO detfacturas(no_factura,serie,id_codigo,cantidad,precio,costo,descto,tdescto,subtotal,obs,id_agencia,no_cor,precioi) VALUES ('" & Fnumero & "','" & Fserie & "',@codigosinf,@cantidadsinf,@PRECIOsinf,@costosinf,@descuentosinf,@descuentosinf,@subtotalsinf,@descripcionsinf,'" & dashboard.no_agencia & "',@CuentaLinea,@TotalsinIVAsinf)"
                            com = New MySqlCommand(consulta, conexion)
                            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                                com.Parameters.Clear()
                                com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                                com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                                com.Parameters.AddWithValue("@descripcionsinf", row.Cells(2).Value)
                                com.Parameters.AddWithValue("@descuentosinf", row.Cells(3).Value)
                                com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                                com.Parameters.AddWithValue("@subtotalsinf", row.Cells(5).Value)
                                com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                                com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                                com.Parameters.AddWithValue("@TotalsinIVAsinf", row.Cells(8).Value)
                                com.ExecuteNonQuery()
                            Next
                            conexion.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                            MsgBox("No fue posible grabar el detalle de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try
                        Try
                            'guardo detalle de la factura en el kardex
                            conexion.Open()
                            consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,costo1,costo2,precio,correlativo,obs,hechopor)VALUES (@codigosinf,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & movimiento & "','" & Fnumero & "', '" & Fserie & "', '0', @cantidadsinf,@costosinf,@costosinf, @PRECIOsinf, @CuentaLinea,'Ingresado en modulo de Punto de Venta', '" & dashboard.usuario.Text & "')"
                            com = New MySqlCommand(consulta, conexion)
                            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                                com.Parameters.Clear()
                                com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                                com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                                com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                                com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                                com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                                com.ExecuteNonQuery()
                            Next
                            conexion.Close()
                        Catch ex As Exception
                            MsgBox("No fue posible registrar la salida del producto en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try

                    ElseIf grabar1.Text = 1 Then
                        'grabo el detalle del documento desde la carga de una orden de trabajo
                        Try
                            conexion.Open()
                            consulta = "INSERT INTO detfacturas(no_factura,serie,id_codigo,cantidad,precio,costo,descto,tdescto,subtotal,obs,id_agencia,no_cor,precioi) VALUES ('" & Fnumero & "','" & Fserie & "',@codigosinf,@cantidadsinf,@PRECIOsinf,@costosinf,@descuentosinf,@descuentosinf,@subtotalsinf,@descripcionsinf,'" & dashboard.no_agencia & "',@CuentaLinea,@TotalsinIVAsinf)"
                            com = New MySqlCommand(consulta, conexion)
                            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                                com.Parameters.Clear()
                                com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                                com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                                com.Parameters.AddWithValue("@descripcionsinf", row.Cells(2).Value)
                                com.Parameters.AddWithValue("@descuentosinf", row.Cells(3).Value)
                                com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                                com.Parameters.AddWithValue("@subtotalsinf", row.Cells(5).Value)
                                com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                                com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                                com.Parameters.AddWithValue("@TotalsinIVAsinf", row.Cells(8).Value)
                                com.ExecuteNonQuery()
                            Next
                            conexion.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                            MsgBox("No fue posible grabar el detalle de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            MessageBox.Show(ex.ToString)
                            Return
                        End Try
                        Try
                            'guardo detalle de la factura en el kardex
                            conexion.Open()
                            consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,costo1,costo2,precio,correlativo,obs,hechopor)VALUES (@codigosinf,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & movimiento & "','" & Fnumero & "', '" & Fserie & "', '0', @cantidadsinf,@costosinf,@costosinf, @PRECIOsinf, @CuentaLinea,'Ingresado en modulo de Punto de Venta', '" & dashboard.usuario.Text & "')"
                            com = New MySqlCommand(consulta, conexion)
                            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                                com.Parameters.Clear()
                                com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                                com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                                com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                                com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                                com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                                com.ExecuteNonQuery()
                            Next
                            conexion.Close()
                        Catch ex As Exception
                            MsgBox("No fue posible registrar la salida del producto en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                           vbCrLf & vbCrLf & ex.Message,
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try
                        'actualizo status de la orden para colocarla como facturada
                        Try
                            conexiongoptics.Open()
                            consulta = "UPDATE orden SET status='F',factura='" & Fnumero & "',seriefact='" & Fserie & "' where no_orden='" & ordenlab & "' and id_agencia='" & dashboard.no_agencia & "' "
                            com = New MySqlCommand(consulta, conexiongoptics)
                            com.ExecuteNonQuery()
                            conexiongoptics.Close()
                        Catch ex As Exception
                            MsgBox("No fue posible actualizar status de la orden, por favor contacta con soporte tecnico " &
                       vbCrLf & vbCrLf & ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                            conexion.Close()
                            Return
                        End Try
                    End If
                    ' MessageBox.Show("Bien:   " & Vbien & " Servicio:   " & Vserv & "  Total:  " & Vtotal)
                    'Guardo en el libro de IVA
                    Try
                        conexion.Open()
                        consulta = "INSERT INTO ivav(id_nit,no_docto,serie,fecha,empresa,importe,servicio,bienes,tiva,piva,id_tipo,status,mesano,subtipo,tipodoc,id_agencia) values('" & nit.Text & "','" & Fnumero & "','" & Fserie & "','" & fecha.Text & "', '" & nombre.Text & "','" & TextBox5.Text & "','" & Vserv & "','" & Vbien & "','" & Vtotal & "','12.0','1','I','" & Mesano & "','5','FACTURA','" & dashboard.no_agencia & "')"
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        MsgBox("No fue posible grabar la informacion en el libro de iva," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                       vbCrLf & vbCrLf & ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                    correlativo = Val(correlativo) + 1
                    Try
                        'actualizo el correlativo
                        conexion.Open()
                        consulta = "UPDATE catagencias set facturas='" & correlativo & "'  where id_agencia='" & dashboard.no_agencia & "'"
                        com = New MySqlCommand(consulta, conexion)
                        com.ExecuteNonQuery()
                        conexion.Close()
                        'imprimo factura 
                        Try
                            Dim dialog As New PrintPreviewDialog()
                            dialog.Document = PrintFactura
                            'defino en donde voy a realizar la impresion 
                            'If dashboard.ip_maquina.Text = "192.168.47.2" Then
                            '    print_tiket.PrinterSettings.PrinterName = "\\192.168.47.4\TICKET"
                            'Else
                            PrintFactura.PrinterSettings.PrinterName = "TICKET"
                            'End If
                            ' print_tiket.PrinterSettings.PrinterName = "TICKET"
                            DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                            dialog.PrintPreviewControl.Zoom = 1.5
                            dialog.ShowDialog()
                            Me.Close()
                        Catch ex As Exception
                            MessageBox.Show("La Impresion ha fallado", ex.ToString())
                        End Try
                    Catch ex As Exception
                        MsgBox("No fue posible actualizar el correlativo del documento, sin embargo si se grabo," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                         vbCrLf & vbCrLf & ex.Message,
                         MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                Else
                    MessageBox.Show("Error al enviar los datos a Infile, factura no grabada por favor contacte con informatica ")
                    MsgBox(response)
                End If
            End If
        ElseIf dedonde = 52 Then
            'valido desde nota de entrega y no pido correo 
            'si telefono esta vacio lo igualo a punto 
            If Telefonocliente.Text = "" Then
                Telefonocliente.Text = "."
            End If
            Button4.Enabled = False
            'llamo a la funcion que obtiene los datos para libro de iva
            ivav()
            'obtengo la hora para grabar
            Dim hora6 As String = Now.ToString("hh:mm:ss")
            'obtengo el total de la factura en letras
            'puedo utilizar la variable mes para poder imprimir el total en latras(PENDIENTE)
            Dim largo = Len(CStr(Format(CDbl(TextBox4.Text), "#,###.00")))
            Dim decimales = Mid(CStr(Format(CDbl(TextBox4.Text), "#,###.00")), largo - 2)
            enletras = GetMyNumberToWords(TextBox4.Text - decimales) & "  " & "QUETZ.  CON  " & Mid(decimales, Len(decimales) - 1) & "/100"
            'enumero las filas a grabar 
            Dim Cuentafila As Integer
            ContadorLinea = 0
            Cuentafila = 0
            If dtv_facturacionsinf.Rows.Count > 0 Then
                For Each Fila As DataGridViewRow In dtv_facturacionsinf.Rows
                    ContadorLinea = (Val(ContadorLinea) + 1).ToString("000")
                    dtv_facturacionsinf.Item(11, Cuentafila).Value = ContadorLinea
                    Cuentafila = Val(Cuentafila) + 1
                Next
            End If
            'NOTA DE ENTREGA NUEVA 
            'Obtengo el correlativo de las notas de entrega 
            movimiento = dedonde

            'realizo la sumatoria de la columna descuento 
            For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                tota_descuento += Val(row.Cells(3).Value)
            Next
            tota_descuento = Format(CType(tota_descuento, Decimal), "#,##0.00")
            'obtengo el correlativo actual
            Try
                conexion.Open()
                consulta = "SELECT comprobante,seriecomp FROM catagencias WHERE id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(0)
                serie = rs(1)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & " -Verifica tu conexion a internet " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            DfirmaElect = "."
            DfirmaElect = "."
            Fserie = serie
            Fnumero = correlativo
            fechacertifica = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
            'realizo la grabacion del encabezado
            Try
                conexion.Open()
                consulta = "INSERT INTO facturas(no_factura,serie,fecha,status,fechap,id_cliente,cliente,nit,id_vendedor,direccion,total,tdescto,piva,cont_cred,obs,hechopor,id_agencia,impresa,no_docto,no_autoriza,telefono,email,horai,firmaelectronica,felfechacertifica) values('" & Fnumero & "','" & Fserie & "','" & fecha.Text & "', 'I','" & fecha.Text & "','" & nit.Text & "', '" & nombre.Text & "', '" & nit.Text & "', '" & id_vendedor & "', '" & direccion.Text & "', '" & TextBox5.Text & "', '" & tdescuento & "', '12.00','1','NOTA DE ENTREGA: " & observaciones.Text & "', '" & dashboard.usuario.Text & "', '" & dashboard.no_agencia & "', 'S','" & correlativo & "','" & serie & "','" & Telefonocliente.Text & "','" & correo.Text & "', '" & hora6 & "','" & DfirmaElect & "','" & fechacertifica & "'  )"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()

            Catch ex As Exception
                MsgBox("No fue posible grabar el encabezado de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            If grabar1.Text = 0 Then
                'guardo el detalle del documento desde factura
                Try
                    conexion.Open()
                    consulta = "INSERT INTO detfacturas(no_factura,serie,id_codigo,cantidad,precio,costo,descto,tdescto,subtotal,obs,id_agencia,no_cor,precioi) VALUES ('" & Fnumero & "','" & Fserie & "',@codigosinf,@cantidadsinf,@PRECIOsinf,@costosinf,@descuentosinf,@descuentosinf,@subtotalsinf,@descripcionsinf,'" & dashboard.no_agencia & "',@CuentaLinea,@TotalsinIVAsinf)"
                    com = New MySqlCommand(consulta, conexion)
                    For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                        com.Parameters.Clear()
                        com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                        com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                        com.Parameters.AddWithValue("@descripcionsinf", row.Cells(2).Value)
                        com.Parameters.AddWithValue("@descuentosinf", row.Cells(3).Value)
                        com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                        com.Parameters.AddWithValue("@subtotalsinf", row.Cells(5).Value)
                        com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                        com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                        com.Parameters.AddWithValue("@TotalsinIVAsinf", row.Cells(8).Value)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    MsgBox("No fue posible grabar el detalle de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
                Try
                    'guardo detalle de la factura en el kardex
                    conexion.Open()
                    consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,costo1,costo2,precio,correlativo,obs,hechopor)VALUES (@codigosinf,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & movimiento & "','" & Fnumero & "', '" & Fserie & "', '0', @cantidadsinf,@costosinf,@costosinf, @PRECIOsinf, @CuentaLinea,'Ingresado en modulo de Punto de Venta', '" & dashboard.usuario.Text & "')"
                    com = New MySqlCommand(consulta, conexion)
                    For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                        com.Parameters.Clear()
                        com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                        com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                        com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                        com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                        com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()
                Catch ex As Exception
                    MsgBox("No fue posible registrar la salida del producto en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try

            ElseIf grabar1.Text = 1 Then
                'grabo el detalle del documento desde la carga de una orden de trabajo
                Try
                    conexion.Open()
                    consulta = "INSERT INTO detfacturas(no_factura,serie,id_codigo,cantidad,precio,costo,descto,tdescto,subtotal,obs,id_agencia,no_cor,precioi) VALUES ('" & Fnumero & "','" & Fserie & "',@codigosinf,@cantidadsinf,@PRECIOsinf,@costosinf,@descuentosinf,@descuentosinf,@subtotalsinf,@descripcionsinf,'" & dashboard.no_agencia & "',@CuentaLinea,@TotalsinIVAsinf)"
                    com = New MySqlCommand(consulta, conexion)
                    For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                        com.Parameters.Clear()
                        com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                        com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                        com.Parameters.AddWithValue("@descripcionsinf", row.Cells(2).Value)
                        com.Parameters.AddWithValue("@descuentosinf", row.Cells(3).Value)
                        com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                        com.Parameters.AddWithValue("@subtotalsinf", row.Cells(5).Value)
                        com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                        com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                        com.Parameters.AddWithValue("@TotalsinIVAsinf", row.Cells(8).Value)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    MsgBox("No fue posible grabar el detalle de la factura," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    MessageBox.Show(ex.ToString)
                    Return
                End Try
                Try
                    'guardo detalle de la factura en el kardex
                    conexion.Open()
                    consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,costo1,costo2,precio,correlativo,obs,hechopor)VALUES (@codigosinf,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & movimiento & "','" & Fnumero & "', '" & Fserie & "', '0', @cantidadsinf,@costosinf,@costosinf, @PRECIOsinf, @CuentaLinea,'Ingresado en modulo de Punto de Venta', '" & dashboard.usuario.Text & "')"
                    com = New MySqlCommand(consulta, conexion)
                    For Each row As DataGridViewRow In dtv_facturacionsinf.Rows
                        com.Parameters.Clear()
                        com.Parameters.AddWithValue("@codigosinf", row.Cells(1).Value)
                        com.Parameters.AddWithValue("@cantidadsinf", row.Cells(0).Value)
                        com.Parameters.AddWithValue("@costosinf", row.Cells(10).Value)
                        com.Parameters.AddWithValue("@PRECIOsinf", row.Cells(4).Value)
                        com.Parameters.AddWithValue("@CuentaLinea", row.Cells(11).Value)
                        com.ExecuteNonQuery()
                    Next
                    conexion.Close()
                Catch ex As Exception
                    MsgBox("No fue posible registrar la salida del producto en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
                'actualizo status de la orden para colocarla como facturada
                Try
                    conexiongoptics.Open()
                    consulta = "UPDATE orden SET status='F',factura='" & Fnumero & "',seriefact='" & Fserie & "' where no_orden='" & ordenlab & "' and id_agencia='" & dashboard.no_agencia & "' "
                    com = New MySqlCommand(consulta, conexiongoptics)
                    com.ExecuteNonQuery()
                    conexiongoptics.Close()
                Catch ex As Exception
                    MsgBox("No fue posible actualizar status de la orden, por favor contacta con soporte tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            End If
            ' MessageBox.Show("Bien:   " & Vbien & " Servicio:   " & Vserv & "  Total:  " & Vtotal)
            'Guardo en el libro de IVA
            Try
                conexion.Open()
                consulta = "INSERT INTO ivav(id_nit,no_docto,serie,fecha,empresa,importe,servicio,bienes,tiva,piva,id_tipo,status,mesano,subtipo,tipodoc,id_agencia) values('" & nit.Text & "','" & Fnumero & "','" & Fserie & "','" & fecha.Text & "', '" & nombre.Text & "','" & TextBox5.Text & "','" & Vserv & "','" & Vbien & "','" & Vtotal & "','12.0','1','I','" & Mesano & "','5','FACTURA','" & dashboard.no_agencia & "')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MsgBox("No fue posible grabar la informacion en el libro de iva," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            correlativo = Val(correlativo) + 1
            Try
                'actualizo el correlativo
                conexion.Open()
                consulta = "UPDATE catagencias set comprobante='" & correlativo & "'  where id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                'imprimo factura 
                Try
                    Dim dialog As New PrintPreviewDialog()
                    dialog.Document = PrintFactura
                    'defino en donde voy a realizar la impresion 
                    'If dashboard.ip_maquina.Text = "192.168.47.2" Then
                    '    print_tiket.PrinterSettings.PrinterName = "\\192.168.47.4\TICKET"
                    'Else
                    PrintFactura.PrinterSettings.PrinterName = "TICKET"
                    'End If
                    ' print_tiket.PrinterSettings.PrinterName = "TICKET"
                    DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                    dialog.PrintPreviewControl.Zoom = 1.5
                    dialog.ShowDialog()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("La Impresion ha fallado", ex.ToString())
                End Try
            Catch ex As Exception
                MsgBox("No fue posible actualizar el correlativo del documento, sin embargo si se grabo," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"
        'imprimo desde la agencia 2 por tiket 
        Try
            Dim dialog As New PrintPreviewDialog()
            dialog.Document = PrintFactura
            'defino en donde voy a realizar la impresion 
            'If dashboard.ip_maquina.Text = "192.168.47.2" Then
            '    print_tiket.PrinterSettings.PrinterName = "\\192.168.47.4\TICKET"
            'Else
            PrintFactura.PrinterSettings.PrinterName = "TICKET"
            'End If
            ' print_tiket.PrinterSettings.PrinterName = "TICKET"
            DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
            dialog.PrintPreviewControl.Zoom = 1.5
            dialog.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("La Impresion ha fallado", ex.ToString())
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If dedonde = 20 Then
            codigo2 = codigo2 + 1
            'copio lo que tiene el campo observaciones y el campo cantidad 
            dtv_facturacionsinf.Rows.Add("1", codigo2, observaciones.Text, " ", "--", "--")
            dtv_facturacion.Rows.Add("1", codigo2, observaciones.Text, " ", "--")
            observaciones.Clear()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If orden_cantidad = 1 Then
            'cargo la priemera orden
            orden_cantidad = Val(orden_cantidad) + 1
            'selecciona_orden.MdiParent = dashboard
            selecciona_orden.dedonde = 2
            selecciona_orden.ShowDialog()
            Try
                'limpio mi dtv para que elimine las columnas predefinidas
                dtv_facturacion.Columns.Clear()
                'busco el detalle de la orden
                'empiezo la consulta 
                ' consulta = "SELECT sum(cantidad),id_codigo,obs,sum(descto),precio,sum(subtotal) FROM detorden where no_docto='" & ordenlab & "' and id_agencia='" & dashboard.no_agencia & "' and id_codigo<>'' and id_codigo<>'.' group by id_codigo"
                consulta = "SELECT sum(d.cantidad),d.id_codigo,d.obs,sum(d.descto),d.precio,sum(d.subtotal),i.servicio,i.costo1 FROM detorden as d left join inventario as i on d.id_codigo=i.id_codigo where d.no_docto='" & ordenlab & "' and  d.id_agencia='" & dashboard.no_agencia & "' and d.id_codigo<>'' and d.id_codigo<>'.' group by d.id_codigo"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_facturacion.DataSource = tabladatos
                conexion.Close()
                dtv_facturacion.Columns(0).HeaderText = "CANT."
                dtv_facturacion.Columns(0).Width = 45
                dtv_facturacion.Columns(1).HeaderText = "CODIGO"
                dtv_facturacion.Columns(1).Width = 60
                dtv_facturacion.Columns(2).HeaderText = "DESCRIPCION"
                dtv_facturacion.Columns(2).Width = 306
                dtv_facturacion.Columns(3).HeaderText = "DECUENTO"
                dtv_facturacion.Columns(3).Width = 90
                dtv_facturacion.Columns(4).HeaderText = "PRECIO U."
                dtv_facturacion.Columns(4).Width = 90
                dtv_facturacion.Columns(5).HeaderText = "SUBTOTAL"
                dtv_facturacion.Columns(5).Width = 90
                dtv_facturacion.Columns(6).Visible = False
                dtv_facturacion.Columns(7).Visible = False
                'alineo columnas de valores a la derecha 
                dtv_facturacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtv_facturacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtv_facturacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'sumo el total con descuento realizado
                Dim Total As Single
                Dim Col As Integer = 5
                For Each row As DataGridViewRow In Me.dtv_facturacion.Rows
                    Total += Val(row.Cells(Col).Value)
                Next
                TextBox5.Text = Total.ToString
                'sumo el total de descuento 
                Dim Total2 As Single
                Dim Col2 As Integer = 3
                For Each row As DataGridViewRow In Me.dtv_facturacion.Rows
                    Total2 += Val(row.Cells(Col2).Value)
                Next
                tdescuento = Total2.ToString
                dtv_facturacion.DefaultCellStyle.Font = New Font("Arial", 9)
                If dedonde = 51 Then
                    observaciones.Text = "FACTURACION DE OT NO. " & ordenlab
                ElseIf dedonde = 52 Then
                    observaciones.Text = "NOTA DE ENTREGA DE OT NO. " & ordenlab

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            ' Button1.Visible = False
            ' Button4.Enabled = True
            grabar1.Text = 1

            'grabo en la variable el numero de la primer orden
            orden_agrega(0) = ordenlab
            'obtengo el numero de nit que agregue en el recibo que tenia anexada la orden 

            Try
                conexion.Open()
                consulta = "select color,direccion from recibos where orden='" & ordenlab & "' and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nit.Text = rs(0)
                nombre.Text = rs(1)
                conexion.Close()
            Catch ex As Exception
                ' MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try
            'recorro el dtv para obtener los datos de los productos
            Button12.PerformClick()
            Button1.Enabled = False
            Button4.Enabled = True
            Button2.Visible = False
            correo.Focus()
        ElseIf orden_cantidad = 2 Then
            ''cargo la segunda orden
            'orden_cantidad = Val(orden_cantidad) + 1
            ''selecciona_orden.MdiParent = dashboard
            'selecciona_orden.dedonde = 2
            'selecciona_orden.ShowDialog()
            'orden_agrega(1) = ordenlab
            'Try
            '    conexion.Open()
            '    'realizo la busquedad del detalle de las ordenes y lo ingreso a la tabla temporal 
            '    consulta = "INSERT  INTO temporal SELECT id_codigo,cantidad,precio,tdescto,subtotal,obs FROM detorden WHERE no_docto='" & orden_agrega(0) & "' and id_agencia='" & dashboard.no_agencia & "' union SELECT id_codigo,cantidad,precio,tdescto,subtotal,obs FROM detorden WHERE no_docto='" & orden_agrega(1) & "' and id_agencia='" & dashboard.no_agencia & "';"
            '    com = New MySqlCommand(consulta, conexion)
            '    com.ExecuteNonQuery()
            '    conexion.Close()
            'Catch ex As Exception
            '    conexion.Close()
            '    MessageBox.Show(ex.ToString)
            '    Me.Close()
            'End Try
            'Try
            '    'limpio mi dtv para que elimine las columnas predefinidas
            '    dtv_facturacion.Columns.Clear()
            '    dtv_facturacionsinf.Columns.Clear()
            '    'realizo la consulta de la informacion ingresada
            '    consulta = "select sum(cantidad),id_codigo, obs, sum(tdescto),precio,sum(subtotal)from temporal group by id_codigo;"
            '    adaptador = New MySqlDataAdapter(consulta, conexion)
            '    'empiezo la consulta 
            '    tabladatos = New DataTable
            '    adaptador.Fill(tabladatos)
            '    dtv_facturacion.DataSource = tabladatos
            '    conexion.Close()
            '    dtv_facturacion.Columns(0).HeaderText = "CANTIDAD"
            '    dtv_facturacion.Columns(0).Width = 80
            '    dtv_facturacion.Columns(1).HeaderText = "CODIGO"
            '    dtv_facturacion.Columns(1).Width = 80
            '    dtv_facturacion.Columns(2).HeaderText = "DESCRIPCION"
            '    dtv_facturacion.Columns(2).Width = 197
            '    dtv_facturacion.Columns(3).HeaderText = "DECUENTO"
            '    dtv_facturacion.Columns(3).Width = 100
            '    dtv_facturacion.Columns(4).HeaderText = "PRECIO U."
            '    dtv_facturacion.Columns(4).Width = 100
            '    dtv_facturacion.Columns(5).HeaderText = "SUBTOTAL"
            '    'sumo el total con descuento realizado
            '    Dim Total As Single
            '    Dim Col As Integer = 5
            '    For Each row As DataGridViewRow In Me.dtv_facturacion.Rows
            '        Total += Val(row.Cells(Col).Value)
            '    Next
            '    TextBox5.Text = Total.ToString
            '    'sumo el total de descuento 
            '    Dim Total2 As Single
            '    Dim Col2 As Integer = 3
            '    For Each row As DataGridViewRow In Me.dtv_facturacion.Rows
            '        Total2 += Val(row.Cells(Col2).Value)
            '    Next
            '    tdescuento = Total2.ToString
            '    dtv_facturacion.DefaultCellStyle.Font = New Font("Arial", 9)
            '    conexion.Open()
            '    consulta = "delete  from temporal"
            '    com = New MySqlCommand(consulta, conexion)
            '    com.ExecuteNonQuery()
            '    conexion.Close()
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            '    conexion.Close()
            'End Try
            '' Button1.Visible = False
            '' Button4.Enabled = True
            'grabar1.Text = 1
            'TextBox4.Text = TextBox5.Text
            'TextBox4.Text = Format(CType(TextBox4.Text, Decimal), "#,##0.00")
            ''desactivo boton para agregar otra orden 
            'Button7.Enabled = False
        End If
    End Sub
    'Sub ivav()
    '    ':::Funcion para obtener datos del libro de ventas 
    '    'OBTENGO LOS BIENES
    '    Vbien = 0
    '    For Each row In dtv_facturacionsinf.Rows
    '        If row.cells(6).value = "B" Then
    '            dtv_medidas.Rows.Add(row.cells(8).value)
    '        End If
    '    Next

    '    For Each row3 In dtv_medidas.Rows
    '        Vbien += Val(row3.Cells(0).Value)
    '    Next
    '    MessageBox.Show("Bien:   " & Vbien & " Servicio:   " & Vserv & "  Total:  " & Vtotal)
    'End Sub
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        dtv_facturacion.Columns(4).DefaultCellStyle.Format = "N2"

        Try
            Dim dialog As New PrintPreviewDialog()
            dialog.Document = PrintFactura
            'defino en donde voy a realizar la impresion 
            'If dashboard.ip_maquina.Text = "192.168.47.2" Then
            '    print_tiket.PrinterSettings.PrinterName = "\\192.168.47.4\TICKET"
            'Else
            PrintFactura.PrinterSettings.PrinterName = "TICKET"
            'End If
            ' print_tiket.PrinterSettings.PrinterName = "TICKET"
            DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
            dialog.PrintPreviewControl.Zoom = 1.5
            dialog.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("La Impresion ha fallado", ex.ToString())
        End Try
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'PRIMERO SACAMOS REGISTROS UNICOS
        For Each row In dtv_facturacionsinf.Rows
            Dim existe As Integer = 0
            For Each row2 In dtv_medidas.Rows
                If row.cells(0).value = row2.cells(0).value Then
                    existe = 1
                    Exit For
                End If
            Next
            If existe Then
            Else
                dtv_medidas.Rows.Add(row.cells(0).value, row.cells(1).value)
            End If
        Next
        'DESPUES RECORREMOS A LA INVERSA Y UNICAMENTE SUMAMOS
        For Each row3 In dtv_medidas.Rows
            For Each row4 In dtv_facturacionsinf.Rows
                If row3.cells(0).value = row4.cells(0).value Then
                    row3.cells(1).value += row4.cells(1).value
                End If
            Next
        Next
    End Sub

    Private Sub Telefonocliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Telefonocliente.KeyPress
        If Asc(e.KeyChar) = 13 Then
            correo.Focus()

        End If
    End Sub
End Class