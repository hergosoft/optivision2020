Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop

Public Class reporte_receta
    Dim fechainicia, fechafinaliza, mesactual, consulta, dia1, mes1, ano1, dia2, mes2, ano2, fecha1, fecha2 As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Dim com As MySqlCommand
    Public dedonde As Integer
    Dim pregunta As String
    Dim total1, Tarjeta1, Efectivo1, Cobrado1, descuento1, subtotal1, total_iva As Decimal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub reporte_receta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fechafinaliza = System.DateTime.Now
        mesactual = Mid(fechafinaliza, 4, Len(fechafinaliza) - 17)
        fecha_inicial.MaxDate = fechafinaliza
        fecha_final.MaxDate = fechafinaliza
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'extraigo el dia, el mes y el año
        'fecha inicial 
        fechainicia = fecha_inicial.Value.Date.ToShortDateString
        dia1 = Mid(fechainicia, 1, Len(fechainicia) - 8)
        mes1 = Mid(fechainicia, 4, Len(fechainicia) - 8)
        ano1 = Mid(fechainicia, 7, Len(fechainicia) - 6)
        'fecha final
        fechafinaliza = fecha_final.Value.Date.ToShortDateString
        dia2 = Mid(fechafinaliza, 1, Len(fechafinaliza) - 8)
        mes2 = Mid(fechafinaliza, 4, Len(fechafinaliza) - 8)
        ano2 = Mid(fechafinaliza, 7, Len(fechafinaliza) - 6)

        fecha1 = ano1 + "-" + mes1 + "-" + dia1
        fecha2 = ano2 + "-" + mes2 + "-" + dia2
        If dedonde = 1 Then
            'realizo la busquedad de ordenes de trabajo
            Try
                consulta = "select o.no_orden, o.serie,o.fecha,o.nombre,o.telefono,o.aro,o.obs,o.total,o.abono,o.saldo,o.status,v.nombre,o.optometra from orden as o left join vendedores as v on o.id_vendedor=v.id_codigo where o.id_agencia='" & dashboard.no_agencia & "' and o.fecha between  '" & fecha1 & "' and '" & fecha2 & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "ORDEN"
                dtv_general.Columns(1).HeaderText = "SERIE"
                dtv_general.Columns(2).HeaderText = "FECHA"
                dtv_general.Columns(3).HeaderText = "PACIENTE"
                dtv_general.Columns(4).HeaderText = "TELEFONO"
                dtv_general.Columns(5).HeaderText = "ARO"
                dtv_general.Columns(6).HeaderText = "OBSERVACIONES"
                dtv_general.Columns(7).HeaderText = "TOTAL"
                dtv_general.Columns(8).HeaderText = "ABONO"
                dtv_general.Columns(9).HeaderText = "SALDO"
                dtv_general.Columns(10).HeaderText = "ESTADO"
                dtv_general.Columns(11).HeaderText = "VENDEDOR"
                dtv_general.Columns(12).HeaderText = "OPTOMETRA"

                'verifico que mi DTV no este vacio

                If dtv_general.Rows.Count > 0 Then
                    'no esta vacio realizo operacion, 
                    'Sumo las columnas, tota, descuento, subtotal
                    Dim Total, descuento, subtotal As Single
                    Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                    For Each row As DataGridViewRow In Me.dtv_general.Rows
                        Total += Val(row.Cells(7).Value)
                        descuento += Val(row.Cells(8).Value)
                        subtotal += Val(row.Cells(9).Value)
                    Next
                    total1 = Total.ToString
                    descuento1 = descuento.ToString
                    subtotal1 = subtotal.ToString
                Else
                    'esta vacio no hago nada 



                End If




                MessageBox.Show("Reporte listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Button3.Enabled = False
                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible obtener las ordenes en el rango de fechas seleccionada," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 2 Then
            Try
                'busco el encabezado de todas las facturas segun rango de fechas 
                consulta = "select f.no_factura,f.serie,f.fecha,f.status,v.nombre,f.cliente,f.nit,sum(f.total+f.tdescto)as total1,tdescto,total,sum(total*0.12) as iva, f.obs,f.hechopor,f.anuladopor,f.telefono,f.horai,f.horaa from facturas as f left join vendedores as v on (f.id_vendedor=v.id_codigo) where f.id_agencia='" & dashboard.no_agencia & "' and f.status<>'A' and f.fecha between  '" & fecha1 & "' and '" & fecha2 & "'  group by f.no_factura;"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "FACTURA"
                dtv_general.Columns(1).HeaderText = "SERIE"
                dtv_general.Columns(2).HeaderText = "FECHA"
                dtv_general.Columns(3).HeaderText = "STATUS"
                dtv_general.Columns(4).HeaderText = "VENDEDOR"
                dtv_general.Columns(5).HeaderText = "CLIENTE"
                dtv_general.Columns(6).HeaderText = "NIT"
                dtv_general.Columns(7).HeaderText = "SUB TOTAL"
                dtv_general.Columns(8).HeaderText = "DESCUENTO"
                dtv_general.Columns(9).HeaderText = "TOTAL FACTURA"
                dtv_general.Columns(10).HeaderText = "IVA"
                dtv_general.Columns(11).HeaderText = "OBS"
                dtv_general.Columns(12).HeaderText = "HECHO POR"
                dtv_general.Columns(13).HeaderText = "ANULADO POR"
                dtv_general.Columns(14).HeaderText = "TELEFONO"
                dtv_general.Columns(15).HeaderText = "HORA INGERSO"
                dtv_general.Columns(16).HeaderText = "HORA ANULACION"
                'valido que el DTV no este vacio
                If dtv_general.Rows.Count > 0 Then
                    'si tiene datos hago operacion
                    'Sumo las columnas, tota, descuento, subtotal
                    Dim Total, descuento, subtotal, iva As Single
                    Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                    For Each row As DataGridViewRow In Me.dtv_general.Rows
                        Total += Val(row.Cells(7).Value)
                        descuento += Val(row.Cells(8).Value)
                        subtotal += Val(row.Cells(9).Value)
                        iva += Val(row.Cells(10).Value)
                    Next
                    total1 = Total.ToString
                    descuento1 = descuento.ToString
                    subtotal1 = subtotal.ToString
                    total_iva = iva.ToString
                Else
                    'no tiene datos no hago nada
                    total1 = 0
                    descuento1 = 0
                    subtotal1 = 0
                    total_iva = 0
                End If


                MessageBox.Show("Reporte general de facturas listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de facturas, por favor intenta de nuevo" & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 3 Then
            pregunta = MsgBox("Emitir reporte solo de la agencia seleccionada." & vbCrLf & vbCrLf & "Selecciona NO para generar reporte de todas las agencias y SI para emitir solo de la agencia actual", vbYesNo + vbQuestion + vbDefaultButton1, "Reporte Detalle Ventas")
            If pregunta = vbYes Then
                'busco el detalle de todas las facturas segun rango de fechas
                Try
                    consulta = "select f.no_factura,f.serie,f.fecha,f.id_agencia,a.nombre,d.id_codigo,d.obs,d.cantidad,d.precio,d.tdescto from facturas as f inner join detfacturas as d on f.no_factura=d.no_factura  left join catagencias as a on f.id_agencia=a.id_agencia and f.serie=d.serie  where f.fecha between '" & fecha1 & "' and '" & fecha2 & "' and f.id_agencia='" & dashboard.no_agencia & "';"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    tabladatos = New DataTable
                    adaptador.Fill(tabladatos)
                    dtv_general.DataSource = tabladatos
                    conexion.Close()
                    dtv_general.Columns(0).HeaderText = "FACTURA"
                    dtv_general.Columns(1).HeaderText = "SERIE"
                    dtv_general.Columns(2).HeaderText = "FECHA"
                    dtv_general.Columns(3).HeaderText = "NO AGENCIA"
                    dtv_general.Columns(4).HeaderText = "AGENCIA"
                    dtv_general.Columns(5).HeaderText = "CODIGO"
                    dtv_general.Columns(6).HeaderText = "DESCRIPCION"
                    dtv_general.Columns(7).HeaderText = "CANTIDAD"
                    dtv_general.Columns(8).HeaderText = "PRECIO"
                    dtv_general.Columns(9).HeaderText = "DESCUENTO"
                    'Sumo las columnas, tota, descuento, subtotal
                    ' Dim Total, descuento, subtotal As Single
                    ' Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                    ' For Each row As DataGridViewRow In Me.dtv_general.Rows
                    ' Total += Val(row.Cells(6).Value)
                    ' descuento += Val(row.Cells(7).Value)
                    ' subtotal += Val(row.Cells(8).Value)
                    ' Next
                    ' total1 = Total.ToString
                    ' descuento1 = descuento.ToString
                    ' subtotal1 = subtotal.ToString
                    MessageBox.Show("Reporte detallado de facturas listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Button2.Enabled = True
                Catch ex As Exception
                    MsgBox("No fue posible obtener el detalle de las facturas, por favor intenta de nuevo." & vbCrLf & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                      vbCrLf & vbCrLf & ex.Message,
                      MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try

            ElseIf pregunta = vbNo Then
                Try
                    consulta = "select f.no_factura,f.serie,f.fecha,f.id_agencia,a.nombre,d.id_codigo,d.obs,d.cantidad,d.precio,d.tdescto,i.id_marca from facturas as f inner join detfacturas as d on f.no_factura=d.no_factura  left join catagencias as a on f.id_agencia=a.id_agencia and f.serie=d.serie left join inventario as i on i.id_codigo=d.id_codigo  where f.fecha between '" & fecha1 & "' and '" & fecha2 & "' order by f.id_agencia;"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    tabladatos = New DataTable
                    adaptador.Fill(tabladatos)
                    dtv_general.DataSource = tabladatos
                    conexion.Close()
                    dtv_general.Columns(0).HeaderText = "FACTURA"
                    dtv_general.Columns(1).HeaderText = "SERIE"
                    dtv_general.Columns(2).HeaderText = "FECHA"
                    dtv_general.Columns(3).HeaderText = "NO AGENCIA"
                    dtv_general.Columns(4).HeaderText = "AGENCIA"
                    dtv_general.Columns(5).HeaderText = "CODIGO"
                    dtv_general.Columns(6).HeaderText = "DESCRIPCION"
                    dtv_general.Columns(7).HeaderText = "CANTIDAD"
                    dtv_general.Columns(8).HeaderText = "PRECIO"
                    dtv_general.Columns(9).HeaderText = "DESCUENTO"
                    dtv_general.Columns(10).HeaderText = "MARCA"

                    'Sumo las columnas, tota, descuento, subtotal
                    ' Dim Total, descuento, subtotal As Single
                    ' Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                    ' For Each row As DataGridViewRow In Me.dtv_general.Rows
                    ' Total += Val(row.Cells(6).Value)
                    ' descuento += Val(row.Cells(7).Value)
                    ' subtotal += Val(row.Cells(8).Value)
                    ' Next
                    ' total1 = Total.ToString
                    ' descuento1 = descuento.ToString
                    ' subtotal1 = subtotal.ToString
                    MessageBox.Show("Reporte detallado de facturas listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Button2.Enabled = True
                Catch ex As Exception
                    MsgBox("No fue posible obtener el detalle de las facturas, por favor intenta de nuevo." & vbCrLf & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                      vbCrLf & vbCrLf & ex.Message,
                      MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try



            End If





                ElseIf dedonde = 4 Then
                'busco detalle de ordendes de trabajo 
            ElseIf dedonde = 5 Then
            'busco encabezado de notas de entrega
            Try
                'busco el encabezado de todas las facturas segun rango de fechas 
                consulta = "select f.no_factura,f.serie,f.fecha,f.status,v.nombre,f.cliente,f.nit,sum(f.total+f.tdescto)as total1,format(f.tdescto,2),format(f.total,2), f.obs,f.hechopor,f.anuladopor,f.telefono,f.horai,f.horaa from facturas as f left join vendedores as v on (f.id_vendedor=v.id_codigo) where f.id_agencia='" & dashboard.no_agencia & "' and f.fecha between  '" & fecha1 & "' and '" & fecha2 & "' and f.serie='NE' group by f.cliente;"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "FACTURA"
                dtv_general.Columns(1).HeaderText = "SERIE"
                dtv_general.Columns(2).HeaderText = "FECHA"
                dtv_general.Columns(3).HeaderText = "STATUS"
                dtv_general.Columns(4).HeaderText = "VENDEDOR"
                dtv_general.Columns(5).HeaderText = "CLIENTE"
                dtv_general.Columns(6).HeaderText = "NIT"
                dtv_general.Columns(7).HeaderText = "SUB TOTAL"
                dtv_general.Columns(8).HeaderText = "DESCUENTO"
                dtv_general.Columns(9).HeaderText = "TOTAL FACTURA"
                dtv_general.Columns(10).HeaderText = "OBS"
                dtv_general.Columns(11).HeaderText = "HECHO POR"
                dtv_general.Columns(12).HeaderText = "ANULADO POR"
                dtv_general.Columns(13).HeaderText = "TELEFONO"
                dtv_general.Columns(14).HeaderText = "HORA INGERSO"
                dtv_general.Columns(15).HeaderText = "HORA ANULACION"
                'Sumo las columnas, tota, descuento, subtotal
                Dim Total, descuento, subtotal, iva As Single
                Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                For Each row As DataGridViewRow In Me.dtv_general.Rows
                    Total += Val(row.Cells(7).Value)
                    descuento += Val(row.Cells(8).Value)
                    subtotal += Val(row.Cells(9).Value)
                Next
                total1 = Total.ToString
                descuento1 = descuento.ToString
                subtotal1 = subtotal.ToString
                total_iva = iva.ToString
                MessageBox.Show("Reporte general de notas de entrega listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de facturas, por favor intenta de nuevo" & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            ElseIf dedonde = 6 Then
            'busco detalle de notas de entrega
            Try
                consulta = "select f.no_factura,f.serie,f.fecha,d.id_codigo,d.cantidad,d.obs,d.precio,d.tdescto,d.subtotal from facturas as f  left join detfacturas as d on f.no_factura=d.no_factura and f.serie=d.serie  where f.fecha between '" & fecha1 & "' and '" & fecha2 & "' and f.serie='NE' and f.id_agencia='" & dashboard.no_agencia & "';"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "FACTURA"
                dtv_general.Columns(1).HeaderText = "SERIE"
                dtv_general.Columns(2).HeaderText = "FECHA"
                dtv_general.Columns(3).HeaderText = "CODIGO"
                dtv_general.Columns(4).HeaderText = "CANTIDAD"
                dtv_general.Columns(5).HeaderText = "DESCRIPCION"
                dtv_general.Columns(6).HeaderText = "PRECIO UNITARIO"
                dtv_general.Columns(7).HeaderText = "DESCUENTO"
                dtv_general.Columns(8).HeaderText = "SUBTOTAL"
                'Sumo las columnas, tota, descuento, subtotal
                Dim Total, descuento, subtotal As Single
                Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                For Each row As DataGridViewRow In Me.dtv_general.Rows
                    Total += Val(row.Cells(6).Value)
                    descuento += Val(row.Cells(7).Value)
                    subtotal += Val(row.Cells(8).Value)
                Next
                total1 = Total.ToString
                descuento1 = descuento.ToString
                subtotal1 = subtotal.ToString
                MessageBox.Show("Reporte detallado de notas de entrega listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible obtener el detalle de las facturas, por favor intenta de nuevo." & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try


            ElseIf dedonde = 7 Then
            'busco recibos de ventas 
            Try

                consulta = "select recibo,serierec,orden,no_factura,seriefac,fecha,nombre,valor,este_pago,efectivo,tarjeta,voucher,estado,vendedor from recibos where id_agencia='" & dashboard.no_agencia & "' and fecha between '" & fecha1 & "' and '" & fecha2 & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "RECIBO"
                dtv_general.Columns(1).HeaderText = "SERIE"
                dtv_general.Columns(2).HeaderText = "ORDEN"
                dtv_general.Columns(3).HeaderText = "FACTURA"
                dtv_general.Columns(4).HeaderText = "SERIE FACT"
                dtv_general.Columns(5).HeaderText = "FECHA"
                dtv_general.Columns(6).HeaderText = "PACIENTE"
                dtv_general.Columns(7).HeaderText = "TOTAL COMPRA"
                dtv_general.Columns(8).HeaderText = "COBRADO"
                dtv_general.Columns(9).HeaderText = "EFECTIVO"
                dtv_general.Columns(10).HeaderText = "TARJETA"
                dtv_general.Columns(11).HeaderText = "VOUCHER"
                dtv_general.Columns(12).HeaderText = "ESTADO"
                dtv_general.Columns(13).HeaderText = "VENDEDOR"
                'Sumo las columnas, tota, descuento, subtotal
                Dim Total, Cobrado, Efectivo, Tarjeta As Single
                'Dim Col As Integer = Me.dtv_general.CurrentCell.ColumnIndex
                For Each row As DataGridViewRow In Me.dtv_general.Rows
                    Total += Val(row.Cells(7).Value)
                    Cobrado += Val(row.Cells(8).Value)
                    Efectivo += Val(row.Cells(9).Value)
                    Tarjeta += Val(row.Cells(10).Value)
                Next
                total1 = Total.ToString
                Cobrado1 = Cobrado.ToString
                Efectivo1 = Efectivo.ToString
                Tarjeta1 = Tarjeta.ToString
                MessageBox.Show("Reporte recibo de ventas listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("No fue posible obtener el detalle de los recibos en las fechas seleccionadas." & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'exporto la data encontrada a excel 
        Try
            'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
            ExportarDatosExcel(dtv_general, "Generado:    " + Now.Date())
            Me.Dispose()
        Catch ex As Exception
            'Si el intento es fallido, mostrar MsgBox.
            MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'titulo   
            .Range("A1:G1").Merge()
            .Range("A1:G1").Value = dashboard.empresa.Text
            .Range("A1:G1").Font.Bold = True
            .Range("A1:G1").Font.Size = 18

            .Range("A2:G2").Merge()
            .Range("A2:G2").Value = Label8.Text
            .Range("A2:G2").Font.Bold = True
            .Range("A2:G2").Font.Size = 15
            'tienda a generar
            .Range("A3:G3").Merge()
            If dedonde = 3 Then
                If pregunta = vbYes Then
                    .Range("A3:G3").Value = "SUCURSAL  :" & dashboard.agencia.Text & "    (" & dashboard.no_agencia & ")"
                Else
                    .Range("A3:G3").Value = "TODAS LAS SUCURSALES"
                End If
            Else
                .Range("A3:G3").Value = "SUCURSAL  :" & dashboard.agencia.Text & "    (" & dashboard.no_agencia & ")"
            End If


            .Range("A3:G3").Font.Bold = True
            .Range("A3:G3").Font.Color = RGB(0, 0, 128)
            .Range("A3:G3").Font.Size = 12
            'Rango de fechas 
            .Range("a4:d4").Merge()
            .Range("A4:D4").Value = "Reporte del   " & fecha_inicial.Text & "   Al    " & fecha_final.Text
            .Range("A4:D4").Font.Bold = True
            .Range("A4:D4").Font.Color = RGB(47, 79, 79)
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 6
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hoja de cálculo   
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireRow.Font.Bold = True
                    objCelda.EntireColumn.Font.Size = 11
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS   
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga   
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))   
                        '.Range(strColumna + i, strColumna + i).In()

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                'objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'valido el tipo de reporte que estoy lanzando para imprimir totales


            If dedonde = 1 Then
                'reporte encabezado ordenes de trabajo 
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Merge()
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Value = "TOTALES"
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Bold = True
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)
                'total compra
                .Range("H" & UltimoNumero + 1).Value = total1
                .Range("H" & UltimoNumero + 1).Font.Bold = True
                .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'total cobrado
                .Range("I" & UltimoNumero + 1).Value = descuento1.ToString
                .Range("I" & UltimoNumero + 1).Font.Bold = True
                .Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

                'subtotal de factura 
                .Range("J" & UltimoNumero + 1).Value = subtotal1.ToString
                .Range("J" & UltimoNumero + 1).Font.Bold = True
                .Range("J" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("J" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

            ElseIf dedonde = 2 Then
                'reporte de encabezado de facturas 
                'escribo los totales al finalizar el cuadro principal
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Merge()
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Value = "TOTALES"
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Bold = True
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)
                'total compra
                .Range("H" & UltimoNumero + 1).Value = total1
                .Range("H" & UltimoNumero + 1).Font.Bold = True
                .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'total cobrado
                .Range("I" & UltimoNumero + 1).Value = descuento1.ToString
                .Range("I" & UltimoNumero + 1).Font.Bold = True
                .Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

                'subtotal de factura 
                .Range("J" & UltimoNumero + 1).Value = subtotal1.ToString
                .Range("J" & UltimoNumero + 1).Font.Bold = True
                .Range("J" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("J" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

                'total IVA
                .Range("K" & UltimoNumero + 1).Value = total_iva.ToString
                .Range("K" & UltimoNumero + 1).Font.Bold = True
                .Range("K" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("K" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

            ElseIf dedonde = 3 Then
                'reporte detallado de facturas 
                'escribo los totales al finalizar el cuadro principal
                '.Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Merge()
                '.Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Value = "TOTALES"
                '.Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Bold = True
                '.Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)
                ''total compra
                '.Range("H" & UltimoNumero + 1).Value = total1
                '.Range("H" & UltimoNumero + 1).Font.Bold = True
                '.Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                '.Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                ''total cobrado
                '.Range("I" & UltimoNumero + 1).Value = descuento1.ToString
                '.Range("I" & UltimoNumero + 1).Font.Bold = True
                '.Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                '.Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                ''subtotal de factura 
                '.Range("J" & UltimoNumero + 1).Value = subtotal1.ToString
                '.Range("J" & UltimoNumero + 1).Font.Bold = True
                '.Range("J" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                '.Range("J" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            ElseIf dedonde = 5 Then
                'reporte encabezado de notas de entrega
                'escribo los totales al finalizar el cuadro principal
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Merge()
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Value = "TOTALES"
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Bold = True
                .Range("A" & UltimoNumero + 1 & ":G" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)
                'total compra
                .Range("H" & UltimoNumero + 1).Value = total1
                .Range("H" & UltimoNumero + 1).Font.Bold = True
                .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'total cobrado
                .Range("I" & UltimoNumero + 1).Value = descuento1.ToString
                .Range("I" & UltimoNumero + 1).Font.Bold = True
                .Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"

                'subtotal de factura 
                .Range("J" & UltimoNumero + 1).Value = subtotal1.ToString
                .Range("J" & UltimoNumero + 1).Font.Bold = True
                .Range("J" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("J" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            ElseIf dedonde = 6 Then
                'reporte detallado notas de entrega 
                'escribo los totales al finalizar el cuadro principal
                .Range("A" & UltimoNumero + 1 & ":F" & UltimoNumero + 1).Merge()
                .Range("A" & UltimoNumero + 1 & ":F" & UltimoNumero + 1).Value = "TOTALES"
                .Range("A" & UltimoNumero + 1 & ":F" & UltimoNumero + 1).Font.Bold = True
                .Range("A" & UltimoNumero + 1 & ":F" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)
                'total compra
                .Range("G" & UltimoNumero + 1).Value = total1
                .Range("G" & UltimoNumero + 1).Font.Bold = True
                .Range("G" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("G" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'total cobrado
                .Range("H" & UltimoNumero + 1).Value = descuento1.ToString
                .Range("H" & UltimoNumero + 1).Font.Bold = True
                .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'subtotal de factura 
                .Range("I" & UltimoNumero + 1).Value = subtotal1.ToString
                .Range("I" & UltimoNumero + 1).Font.Bold = True
                .Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            ElseIf dedonde = 7 Then
                'recibo de ventas 
                'total compra
                .Range("H" & UltimoNumero + 1).Value = total1.ToString
                .Range("H" & UltimoNumero + 1).Font.Bold = True
                .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'Total Cobrado 
                .Range("I" & UltimoNumero + 1).Value = Cobrado1.ToString
                .Range("I" & UltimoNumero + 1).Font.Bold = True
                .Range("I" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("I" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'Total Efectivo 
                .Range("J" & UltimoNumero + 1).Value = Efectivo1.ToString
                .Range("J" & UltimoNumero + 1).Font.Bold = True
                .Range("J" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("J" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
                'Total Tarjeta
                .Range("K" & UltimoNumero + 1).Value = Tarjeta1.ToString
                .Range("K" & UltimoNumero + 1).Font.Bold = True
                .Range("K" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
                .Range("K" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            End If
            'Dibujar las líneas de las columnas   
            'LetraIzq = ""
            'cod_LetraIzq = Asc("A")
            'cod_letra = Asc(primeraLetra)
            'Letra = primeraLetra
            ' For Each c As DataGridViewColumn In DataGridView1.Columns
            ' If c.Visible Then
            ' objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
            ' objCelda.BorderAround()
            ' If Letra = "Z" Then
            ' Letra = primeraLetra
            ' cod_letra = Asc(primeraLetra)
            ' LetraIzq = Chr(cod_LetraIzq)
            ' cod_LetraIzq += 1
            ' Else
            ' cod_letra += 1
            ' Letra = Chr(cod_letra)
            ' End If
            ' End If
            ' Next

            'Dibujar el border exterior grueso   
            'Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            'objRango.Select()
            'objRango.Columns.AutoFit()
            'objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        'esta siguiente linea comentada
        'm_Excel.Cursor = Excel.XlMousePointer.xlDefault

        'Aca almacenar en la ruta especificada de un directorio
        'm_Excel.ActiveWorkbook.SaveAs(Filename:="UserProfile" & "\desktop\Prueba.xls")
        'm_Excel.ActiveWorkbook.Close(False)

        'Cierra el archivo y elimina la variable m_Excel.Quit()
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
End Class