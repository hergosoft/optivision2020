Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Public Class reporte_ventasdiaras
    Dim fechafinaliza, mesactual, fechainicia, dia2, mes2, ano2, dia1, mes1, ano1, fecha1, fecha2, consulta, total_compra, total_cobrado, total_efectivo, total_tarjeta As String
    Dim tabladatos As New DataTable
    Dim adaptador As MySqlDataAdapter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'limpio variables
        total_compra = 0
        total_cobrado = 0
        total_efectivo = 0
        total_tarjeta = 0

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
        'realizo la busquedad del rango de fechas seleccionadas de las ordenes de laboratorio
        Try
            consulta = "select r.fecha,r.recibo,r.nombre,r.valor,r.este_pago,r.orden,r.efectivo,r.tarjeta,r.voucher,r.observa,v.nombre,r.no_factura,r.seriefac from recibos as r left join vendedores as v ON(r.id_vendedor=v.id_codigo ) where r.fecha between '" & fecha1 & "' and '" & fecha2 & "' and r.id_agencia='" & dashboard.no_agencia & "'; "

            adaptador = New MySqlDataAdapter(consulta, conexion)
            Tabladatos = New DataTable
            adaptador.Fill(Tabladatos)
            DataGridView1.DataSource = tabladatos
            conexion.Close()
            DataGridView1.Columns(0).HeaderText = "FECHA"
            DataGridView1.Columns(1).HeaderText = "NO RECIBO"
            DataGridView1.Columns(2).HeaderText = "NOMBRE"
            DataGridView1.Columns(3).HeaderText = "TOTAL COMPRA"
            DataGridView1.Columns(4).HeaderText = "COBRADO"
            DataGridView1.Columns(5).HeaderText = "ORDEN TRABAJO"
            DataGridView1.Columns(6).HeaderText = "EFECTIVO"
            DataGridView1.Columns(7).HeaderText = "TARJETA"
            DataGridView1.Columns(8).HeaderText = "VOUCHER"
            DataGridView1.Columns(9).HeaderText = "CONCEPTO"
            DataGridView1.Columns(10).HeaderText = "VENDEDOR"
            DataGridView1.Columns(11).HeaderText = "FACTURA/ NOTA ENTREGA"
            DataGridView1.Columns(12).HeaderText = "SERIE FACT / NOTA ENTREGA"
            MessageBox.Show("Reporte listo para exportar.", "Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'realizo las sumatorias de las columnas con cantidades
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                total_compra += Val(row.Cells(3).Value)
                total_cobrado += Val(row.Cells(4).Value)
                total_efectivo += Val(row.Cells(6).Value)
                total_tarjeta += Val(row.Cells(7).Value)
            Next
            'exporto la data encontrada a excel 
            Try
                'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
                ExportarDatosExcel(DataGridView1, "Generado:    " + Now.Date())
                Me.Close()
            Catch ex As Exception
                'Si el intento es fallido, mostrar MsgBox.
                MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox("No fue posible obtener los datos de venta para generar el reporte," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub

    Private Sub reporte_ventasdiaras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fechafinaliza = System.DateTime.Now
        mesactual = Mid(fechafinaliza, 4, Len(fechafinaliza) - 17)
        fecha_inicial.MaxDate = fechafinaliza
        fecha_final.MaxDate = fechafinaliza
        'limito para generar corte solo del dia, esto solo si es usuairo vendedor, si es usuario administrador no limito nada 
        If dashboard.permisos.Text = 3 Then
            'limito usuario vendedor
            fecha_inicial.MinDate = fechafinaliza
            fecha_final.MinDate = fechafinaliza
        ElseIf dashboard.permisos.Text = 1 Then
            'usuario administrador 


        End If

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
            .Range("A2:G2").Value = "REPORTE GENERAL DE VENTAS DIARIAS"
            .Range("A2:G2").Font.Bold = True
            .Range("A2:G2").Font.Size = 15
            'tienda a generar
            .Range("A3:G3").Merge()
            .Range("A3:G3").Value = "SUCURSAL  :  " & dashboard.agencia.Text & "    (" & dashboard.no_agencia & ")"
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
                    objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format()
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
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i
            'escribo los totales al finalizar el cuadro principal
            .Range("C" & UltimoNumero + 1).Merge()
            .Range("C" & UltimoNumero + 1).Value = "TOTALES"
            .Range("C" & UltimoNumero + 1).Font.Bold = True
            .Range("C" & UltimoNumero + 1).Font.Color = RGB(5, 43, 138)

            'total compra
            .Range("D" & UltimoNumero + 1).Value = total_compra.ToString
            .Range("D" & UltimoNumero + 1).Font.Bold = True
            .Range("D" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
            .Range("D" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            'total cobrado
            .Range("E" & UltimoNumero + 1).Value = total_cobrado.ToString
            .Range("E" & UltimoNumero + 1).Font.Bold = True
            .Range("E" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
            .Range("E" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            'total efectivo
            .Range("G" & UltimoNumero + 1).Value = total_efectivo.ToString
            .Range("G" & UltimoNumero + 1).Font.Bold = True
            .Range("G" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
            .Range("G" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            'total tarjeta
            .Range("H" & UltimoNumero + 1).Value = total_tarjeta.ToString
            .Range("H" & UltimoNumero + 1).Font.Bold = True
            .Range("H" & UltimoNumero + 1).Font.Color = RGB(234, 0, 0)
            .Range("H" & UltimoNumero + 1).NumberFormat = "Q #,##0.00"
            'le doy formato de decimales a las  columnas que contienen numeros 
            .Range("D7:D" & UltimoNumero).NumberFormat = "#,##0.00"
            .Range("E7:E" & UltimoNumero).NumberFormat = "#,##0.00"
            .Range("G7:G" & UltimoNumero).NumberFormat = "#,##0.00"
            .Range("H7:H" & UltimoNumero).NumberFormat = "#,##0.00"




            'Dibujar las líneas de las columnas   
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso   
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
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