Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Public Class reporte_existencias
    Dim consulta, codigo, descripcion, total, entr, sal, marca, linea, precio, fechaexis, NombreReporte As String
    Dim adaptador As MySqlDataAdapter
    Dim tablamarca As DataTable
    Public dedonde As String



    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Dim tabla_codigos, tabla_movimientos, tabla_documento As DataTable

    Private Sub descrip_marca_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub general_CheckedChanged(sender As Object, e As EventArgs) Handles general.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dedonde = 1 Then
            'emito reporte de existencias solo de la agencia seleccionada 
            dtv_final.Columns.Add(0, "CODIGO")
            dtv_final.Columns.Add(1, "DESCRIPCION")
            dtv_final.Columns.Add(2, "LINEA")
            dtv_final.Columns.Add(3, "MARCA")
            dtv_final.Columns.Add(4, "ENTRADA")
            dtv_final.Columns.Add(5, "SALIDA")
            dtv_final.Columns.Add(6, "EXISTENCIA")
            dtv_final.Columns.Add(7, "CONTEO")

            'descargo todos los movimientos  de la agencia seleccionada
            Try
                consulta = "SELECT id_codigo,entrada,salida,obs from kardexinven where id_agencia='" & dashboard.no_agencia & "'"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_movimientos = New DataTable
                adaptador.Fill(tabla_movimientos)
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
         vbCrLf & vbCrLf & ex.Message,
         MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            'Obtengo el catalogo de codigos
            Try
                consulta = "SELECT id_codigo,producto,linea,id_marca,status from inventario "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabla_codigos = New DataTable
                adaptador.Fill(tabla_codigos)
                DataGridView1.DataSource = tabla_codigos
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el numero de movimientos por codigo," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
         vbCrLf & vbCrLf & ex.Message,
         MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'recorro la tabla de coditos que tuvieron movimiento 
            For columnas As Integer = 0 To DataGridView1.RowCount - 1
                codigo = DataGridView1.Item(0, columnas).Value.ToString
                linea = DataGridView1.Item(2, columnas).Value.ToString
                marca = DataGridView1.Item(3, columnas).Value.ToString
                descripcion = DataGridView1.Item(1, columnas).Value.ToString

                If linea = 5 Then
                    'omito la linea de lentes
                ElseIf linea = 6 Then
                    'omito la linea de tratamiento
                ElseIf linea = 8 Then
                    'omito la linea de servicios
                Else
                    'busco los movimientos del  primer codigo encontrado 
                    Dim rows() As DataRow = tabla_movimientos.Select("id_codigo='" & codigo & "'")
                    Dim dt As DataTable = tabla_movimientos.Clone()
                    For Each row As DataRow In rows
                        dt.ImportRow(row)
                    Next
                    dtv_temporal.DataSource = dt
                    'obtengo el total de las entradas del codigo seleccionado 
                    total = 0
                    Dim fila As DataGridViewRow = New DataGridViewRow
                    For Each fila In dtv_temporal.Rows
                        total += Convert.ToDouble(fila.Cells("entrada").Value)
                    Next
                    entr = Convert.ToString(total)
                    'verifico si entr esta vacia para igualar a cero 
                    If entr = "" Then
                        entr = 0
                    End If
                    'obtengo el resultado de la segunda columna (salida)
                    Dim total1 As Double = 0
                    Dim fila1 As DataGridViewRow = New DataGridViewRow()
                    For Each fila1 In dtv_temporal.Rows
                        total1 += Convert.ToDouble(fila1.Cells("salida").Value)
                    Next
                    sal = Convert.ToString(total1)
                    If sal = "" Then
                        sal = 0
                    End If

                    total = Val(entr) - Val(sal)
                    'valido si es reporte general o solo existencias 
                    If existencias.Checked = True Then
                        If total = 0 Then
                        Else
                            'agrego los datos filaes al dtv final 
                            dtv_final.Rows.Add(codigo, descripcion, linea, marca, entr, sal, total, precio)
                            marca = ""
                            codigo = ""
                            descripcion = ""
                            entr = ""
                            sal = ""
                            total = ""
                            precio = ""
                        End If
                    ElseIf general.Checked = True Then
                        'agrego los datos filaes al dtv final 
                        dtv_final.Rows.Add(codigo, descripcion, linea, marca, entr, sal, total, precio)
                        marca = ""
                        codigo = ""
                        descripcion = ""
                        entr = ""
                        sal = ""
                        total = ""
                        precio = ""
                    End If

                End If
            Next
            'ordeno el dtv final por marca
            dtv_final.Sort(dtv_final.Columns(1), System.ComponentModel.ListSortDirection.Descending)
            MessageBox.Show("Listo para Exportar")
            Button2.Enabled = True
            Button1.Enabled = False
        ElseIf dedonde = 2 Then
            'emito reporte de existencias consolidadas 
            If existencias.Checked = True Then
                'existencias consolidada general, todas las marcas y todas las lineas 
                'verifico si es detallado o resumido: detallado muestra todos los codigos individuales, resumido solo las marcas 
                If Resumidocodigos.Checked = True Then
                    'emito listado general agrupado por marcas 
                    Try
                        consulta = "SELECT i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                                    SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_marca
                                    ORDER BY i.id_marca;"
                        NombreReporte = "GENERAL // TODAS LAS MARCAS Y LINEAS"
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                ElseIf Detalladocodigos.Checked = True Then
                    'emito listado detallado por codigo de producto de todas las marcas y lineas
                    Try
                        consulta = "SELECT i.id_codigo,i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                                SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE k.id_codigo=i.id_codigo AND   fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_codigo
                                    ORDER BY i.id_marca;"

                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                        NombreReporte = " DETALLADO// TODAS LAS MARCAS Y LINEAS"
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                End If

            ElseIf RadioButton4.Checked = True Then
                'existencia de una linea en especifico 
                If Resumidocodigos.Checked = True Then
                    'verifico si tengo marca seleccionada
                    Try
                        If descrip_marca.Text = " NO DEFINIDA" Or descrip_marca.Text = "" Then
                            'Emito reporte sin marca definida solo linea 
                            consulta = "SELECT i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                             SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE i.linea='" & familia.SelectedValue.ToString & "'  AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_marca
                                    ORDER BY i.id_marca;"
                            NombreReporte = "GENERAL // FAMILIA: " & familia.Text
                        Else
                            consulta = "SELECT i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                             SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE i.linea='" & familia.SelectedValue.ToString & "' AND i.id_marca='" & descrip_marca.Text & "'  AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_marca
                                    ORDER BY i.id_marca;"
                            NombreReporte = "GENERAL // FAMILIA: " & familia.Text & " MARCA : " & descrip_marca.Text

                        End If
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                ElseIf Detalladocodigos.Checked = True Then
                    'existencia consolidada por marca detallado******
                    Try
                        If descrip_marca.Text = " NO DEFINIDA" Or descrip_marca.Text = "" Then
                            'Emito reporte sin marca definida solo linea 
                            consulta = "SELECT i.id_codigo,i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                          SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE k.id_codigo=i.id_codigo and  i.linea='" & familia.SelectedValue.ToString & "'  AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_codigo
                                    ORDER BY i.id_marca;"
                            NombreReporte = "DETALLADO //  FAMILIA : " & descrip_marca.Text

                        Else
                            consulta = "SELECT i.id_codigo,i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
               SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE k.id_codigo=i.id_codigo and i.linea='" & familia.SelectedValue.ToString & "' AND i.id_marca='" & descrip_marca.Text & "'  AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_codigo
                                    ORDER BY i.id_marca;"
                            NombreReporte = "DETALLADO //  MARCA : " & descrip_marca.Text & "  FAMILIA: " & familia.Text

                        End If
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                End If
            ElseIf general.Checked = True Then
                'existencia de una marca
                If Resumidocodigos.Checked = True Then
                    Try
                        If familia.Text = "" Or familia.Text = "NO DEFINIDA" Then
                            consulta = "SELECT i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                   SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE i.id_marca='" & descrip_marca.Text & "' AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_marca
                                    ORDER BY i.id_marca;"
                            NombreReporte = "GENERAL //  MARCA : " & descrip_marca.Text

                        Else
                            consulta = "SELECT i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
               SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE i.id_marca='" & descrip_marca.Text & "' AND i.linea='" & familia.SelectedValue.ToString & "' AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_marca
                                    ORDER BY i.id_marca;"
                            NombreReporte = "GENERAL //  MARCA : " & descrip_marca.Text & "  FAMILIA: " & familia.Text

                        End If
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                ElseIf Detalladocodigos.Checked = True Then
                    'reporte detallado ////////
                    Try
                        If familia.Text = "" Or familia.Text = "NO DEFINIDA" Then
                            consulta = "SELECT i.id_codigo,i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
           SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE k.id_codigo=i.id_codigo and i.id_marca='" & descrip_marca.Text & "' AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_codigo
                                    ORDER BY i.id_marca;"
                            NombreReporte = "DETALLADO //  MARCA : " & descrip_marca.Text

                        Else
                            consulta = "SELECT i.id_codigo,i.producto,i.id_marca,(SUM(entrada)-SUM(salida)) AS Existencia_Global,
                                    SUM(IF(k.id_agencia= 1,entrada-salida,0)) AS Bodega_Central,
                SUM(IF(k.id_agencia= 2,entrada-salida,0)) AS Ciudad_Quetzal,
                                    SUM(IF(k.id_agencia= 3,entrada-salida,0)) AS San_Raymundo
                                    FROM inventario AS i LEFT JOIN kardexinven AS k ON(i.id_codigo=k.id_codigo)
                                    left outer join catagencias as a on k.id_agencia=a.id_agencia
                                    WHERE k.id_codigo=i.id_codigo AND  i.id_marca='" & descrip_marca.Text & "' AND i.linea='" & familia.SelectedValue.ToString & "' AND fecha <= '" & fechaexis & "' AND i.linea not in(5,6,8) 
                                    GROUP BY i.id_codigo
                                    ORDER BY i.id_marca;"
                            NombreReporte = "DETALLADO //  MARCA : " & descrip_marca.Text & "  FAMILIA: " & familia.Text

                        End If
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_movimientos = New DataTable
                        adaptador.Fill(tabla_movimientos)
                        dtv_final.DataSource = tabla_movimientos
                        conexion.Close()
                        MessageBox.Show("Listo para Exportar")
                        Button1.Enabled = False
                        Button2.Enabled = True
                    Catch ex As Exception
                        MsgBox("No fue posible obtener el catalogo de movimientos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
             vbCrLf & vbCrLf & ex.Message,
             MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            'Intentar generar el documento.
            'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
            ExportarDatosExcel(dtv_final, "Generado: " + Now.Date())
            Me.Close()
        Catch ex As Exception
            'Si el intento es fallido, mostrar MsgBox.
            MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            .Range("A2:H2").Merge()
            'tienda a generar
            .Range("A3:G3").Merge()
            If dedonde = 2 Then
                'abro desde reporte consolidado
                .Range("A2:H2").Value = "REPORTE EXISTENCIAS CONSOLIDADAS  " & NombreReporte
                .Range("A3:G3").Value = "Existencia de todas las sucurales"
            Else
                'abro desde reporte genral 
                .Range("A2:H2").Value = "REPORTE GENERAL DE EXISTENCIAS"
                .Range("A3:G3").Value = "SUCURSAL  :" & dashboard.agencia.Text & "    (" & dashboard.no_agencia & ")"
            End If

            .Range("A2:H2").Font.Bold = True
            .Range("A2:H2").Font.Size = 15
            .Range("A3:G3").Font.Bold = True
            .Range("A3:G3").Font.Color = RGB(0, 0, 128)
            .Range("A3:G3").Font.Size = 12
            'Rango de fechas 
            .Range("a4:d4").Merge()
            .Range("A4:D4").Value = "Existencias al   " & Date.Now.ToString & ""
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
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i
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

    Private Sub reporte_existencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dedonde = 1 Then
            'existencia de tienda 
        ElseIf dedonde = 2 Then
            'existencia consolidada 
        End If
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        Fechar.MaxDate = DateTime.Now.ToLongDateString()
        fechaexis = Format(Fechar.Value, "yyyy-MM-dd")


    End Sub

    Private Sub docto_CheckedChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub existencias_CheckedChanged(sender As Object, e As EventArgs) Handles existencias.CheckedChanged

    End Sub

    Private Sub RadioButton4_MouseClick(sender As Object, e As MouseEventArgs) Handles RadioButton4.MouseClick
        GroupBox3.Enabled = True
        GroupBox4.Enabled = False
        'obtengo el listado de marcas
        Try
            conexion.Open()
            consulta = "select * from catlineasi where id_linea not in(5,6,8)"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tablamarca = New DataTable
            adaptador.Fill(tablamarca)
            familia.DataSource = tablamarca
            familia.ValueMember = "id_linea"
            familia.DisplayMember = "descripcion"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de marcas, si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub

    Private Sub general_Click(sender As Object, e As EventArgs) Handles general.Click
        GroupBox3.Enabled = False
        GroupBox4.Enabled = True
        'obtengo el listado de marcas
        Try
            conexion.Open()
            consulta = "select * from catmarcasi"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tablamarca = New DataTable
            adaptador.Fill(tablamarca)
            descrip_marca.DataSource = tablamarca
            descrip_marca.ValueMember = "id_linea"
            descrip_marca.DisplayMember = "id_linea"
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el listado de marcas, si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
    End Sub
End Class