Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Public Class reporte_precios
    Dim consulta, identificador, codigo_interno, total, entr, sal, producto, sucursal, tienda, linea, marca_id As String
    Dim adapatador As MySqlDataAdapter
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim precio As Double
    Dim tabladatos, tablamovimientos, tabla_codigos, tablamovimientos1 As DataTable
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'verifico que checkbox marque para cargar el listado 
        If general.Checked = True Then
            'realizo la busquedad de precio de todos los aros cargados en la tienda 

        ElseIf marca.Checked = True Then
            'realizo la busquedad de todas las marcas cargadas en la tienda
            Try
                consulta = "select id_linea from catmarcasi "
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            Catch ex As Exception
                conexion.Close()
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf categoria.Checked = True Then
            'realizo la busquedad de todas las categorias cargas en la tienda 
            Try
                consulta = "SELECT id_linea,descripcion FROM catlineasi "
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "CODIGO"
                DataGridView1.Columns(0).Width = 50


                DataGridView1.Columns(1).HeaderText = "LINEA"
                DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Catch ex As Exception
                conexion.Close()
                MessageBox.Show(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub reporte_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        'obtengo el nombre y nuermo de agencia 
        sucursal = dashboard.agencia.Text
        tienda = dashboard.no_agencia.ToString
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'realizo la carga del id en la variable identificador
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        identificador = CStr(row.Cells(0).Value)
        If categoria.Checked = True Then
            TextBox1.Text = CStr(row.Cells(1).Value)
        Else
            TextBox1.Text = CStr(row.Cells(0).Value)
        End If

        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dtv_final.DataSource = Nothing
        dtv_codigos.DataSource = Nothing
        dtv_temporal.DataSource = Nothing
        'descargo todos los movimientos  de la agencia seleccionada
        Try
            consulta = "SELECT id_codigo, entrada,salida, obs from kardexinven where id_agencia='" & dashboard.no_agencia & "'"
            adapatador = New MySqlDataAdapter(consulta, conexion)
            tablamovimientos = New DataTable
            adapatador.Fill(tablamovimientos)
            conexion.Close()
            DataGridView2.DataSource = tablamovimientos
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("No pude obtener el catalogo de movimientos, por favor Contacta a Sporte Tecnico")
        End Try

        If general.Checked = True Then
            'descargo todos los codigos que han tenido movimiento del kardex 
            Try
                consulta = "SELECT id_codigo FROM kardexinven where id_agencia='" & dashboard.no_agencia & "' group by id_codigo having count(*)>=1;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tablamovimientos1 = New DataTable
                adapatador.Fill(tablamovimientos1)
                conexion.Close()
                DataGridView3.DataSource = tablamovimientos1
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No pude obtener el catalogo de movimientos, por favor Contacta a Sporte Tecnico")
            End Try
            'descargo todos los productos de la tabla inventario 
            Try
                consulta = "SELECT id_codigo, producto, precio1, id_marca from inventario "
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabla_codigos = New DataTable
                adapatador.Fill(tabla_codigos)
                conexion.Close()
                dtv_codigos.DataSource = tabla_codigos
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No pude obtener los codigos de la marca seleccionada")
            End Try
            dtv_final.Columns.Add(0, "CODIGO")
            dtv_final.Columns.Add(1, "DESCRIPCION")
            dtv_final.Columns.Add(2, "MARCA")
            dtv_final.Columns.Add(3, "EXISTENCIA")
            dtv_final.Columns.Add(4, "PRECIO")
            dtv_final.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dtv_final.Columns(4).DefaultCellStyle.Format = "N2"
            'empiezo a recorrer el dtv de los codigos que tuvieron movimientos en la tienda 
            For columnas1 As Integer = 0 To DataGridView3.RowCount - 1
                codigo_interno = DataGridView3.Item(0, columnas1).Value.ToString


                'busco los movimientos del  primer codigo encontrado 
                Dim rows() As DataRow = tablamovimientos.Select("id_codigo='" & codigo_interno & "'")
                Dim dt As DataTable = tablamovimientos.Clone()
                For Each row As DataRow In rows
                    dt.ImportRow(row)
                Next
                dtv_temporal.DataSource = dt
                'obtengo el total de las entradas del codigo seleccionado 
                total = 0

                'busco los datos del aro en la tabla de inventario 
                Dim rows2() As DataRow = tabla_codigos.Select("id_codigo='" & codigo_interno & "'")
                Dim dt2 As DataTable = tabla_codigos.Clone()
                For Each row As DataRow In rows2
                    dt2.ImportRow(row)
                Next
                DataGridView4.DataSource = dt2
                marca_id = DataGridView4.Item(3, 0).Value.ToString
                producto = DataGridView4.Item(1, 0).Value.ToString
                precio = DataGridView4.Item(2, 0).Value.ToString
                'sumo las cantidades para obtener la existencia
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
                'valido si tiene existencia
                If total <= 0 Then
                    'si no tengo existencia no muestro el producto en el reporte 
                Else
                    'si tengo exitencia entonces muestro el producto en el reporte 
                    dtv_final.Rows.Add(codigo_interno, producto, marca_id, total, precio)
                End If
            Next
            'valido el dtv final para indicar si hay o no hay marcas con existencias 
            If dtv_final.Rows.Count = 0 Then
                MessageBox.Show("No hay aros con existencia de la marca seleccionada por favor intente con otra marca")
            Else
                Try
                    'exporto el resultado a mi libro de excel 
                    ExportarDatosExcel(dtv_final, "Generado: " + System.DateTime.Now())
                    Me.Close()
                Catch ex As Exception
                    'Si el intento es fallido, mostrar MsgBox.
                    MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf marca.Checked = True Then

            dtv_final.Columns.Add(0, "CODIGO")
            dtv_final.Columns.Add(1, "DESCRIPCION")
            dtv_final.Columns.Add(2, "EXISTENCIA")
            dtv_final.Columns.Add(3, "PRECIO")
            dtv_final.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dtv_final.Columns(3).DefaultCellStyle.Format = "N2"
            'busco los aros de la marca selecionada en la tabla inventario 
            Try
                consulta = "SELECT id_codigo, producto, precio1 from inventario where id_marca='" & identificador & "'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabla_codigos = New DataTable
                adapatador.Fill(tabla_codigos)
                conexion.Close()
                dtv_codigos.DataSource = tabla_codigos
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No pude obtener los codigos de la marca seleccionada")
            End Try
            'recorro el dtv_codigos para buscarlos en la tabla movimientos
            For columnas As Integer = 0 To dtv_codigos.RowCount - 1
                codigo_interno = dtv_codigos.Item(0, columnas).Value.ToString
                producto = dtv_codigos.Item(1, columnas).Value.ToString
                precio = dtv_codigos.Item(2, columnas).Value.ToString
                'busco los movimientos del  primer codigo encontrado 
                Dim rows() As DataRow = tablamovimientos.Select("id_codigo='" & codigo_interno & "'")
                Dim dt As DataTable = tablamovimientos.Clone()
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
                If total <= 0 Then
                    'si no tengo existencia no muestro el producto en el reporte 
                Else
                    'si tengo exitencia entonces muestro el producto en el reporte 
                    dtv_final.Rows.Add(codigo_interno, producto, total, precio)
                End If
            Next
            'valido el dtv final para indicar si hay o no hay marcas con existencias 
            If dtv_final.Rows.Count = 0 Then
                MessageBox.Show("No hay aros con existencia de la marca seleccionada por favor intente con otra marca")
            Else
                Try
                    'exporto el resultado a mi libro de excel 
                    ExportarDatosExcel(dtv_final, "Generado: " + System.DateTime.Now())
                    Me.Close()
                Catch ex As Exception
                    'Si el intento es fallido, mostrar MsgBox.
                    MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        ElseIf categoria.Checked = True Then

            'declaro las columnas de mi dtv final 
            dtv_final.Columns.Add(0, "CODIGO")
            dtv_final.Columns.Add(1, "DESCRIPCION")
            dtv_final.Columns.Add(2, "EXISTENCIA")
            dtv_final.Columns.Add(3, "PRECIO")
            dtv_final.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dtv_final.Columns(3).DefaultCellStyle.Format = "N2"
            'busco los precios de todos los aros de la categoria selecionada
            Try
                consulta = "SELECT id_codigo, producto, precio1 from inventario where linea='" & identificador & "'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabla_codigos = New DataTable
                adapatador.Fill(tabla_codigos)
                conexion.Close()
                dtv_codigos.DataSource = tabla_codigos
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No pude obtener los codigos de la marca seleccionada")
            End Try

            If linea = 5 Or linea = 6 Or linea = 8 Then
                'imprimo listado de precios sin mostrar existencia 
            Else
                'verifico existencia
                'recorro el dtv_codigos para buscarlos en la tabla movimientos
                For columnas As Integer = 0 To dtv_codigos.RowCount - 1
                    codigo_interno = dtv_codigos.Item(0, columnas).Value.ToString
                    producto = dtv_codigos.Item(1, columnas).Value.ToString
                    precio = dtv_codigos.Item(2, columnas).Value.ToString
                    'busco los movimientos del  primer codigo encontrado 
                    Dim rows() As DataRow = tablamovimientos.Select("id_codigo='" & codigo_interno & "'")
                    Dim dt As DataTable = tablamovimientos.Clone()
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
                    If total <= 0 Then
                        'si no tengo existencia no muestro el producto en el reporte 
                    Else
                        'si tengo exitencia entonces muestro el producto en el reporte 
                        dtv_final.Rows.Add(codigo_interno, producto, total, precio)
                    End If
                Next
                'valido el dtv final para indicar si hay o no hay marcas con existencias 
                If dtv_final.Rows.Count = 0 Then
                    MessageBox.Show("No hay aros con existencia de la marca seleccionada por favor intente con otra marca")
                Else
                    Try
                        'exporto el resultado a mi libro de excel 
                        ExportarDatosExcel(dtv_final, "Generado: " + System.DateTime.Now())
                        Me.Close()
                    Catch ex As Exception
                        'Si el intento es fallido, mostrar MsgBox.
                        MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        Else
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
            .Range("A1:D1").Merge()
            .Range("A1:D1").Value = dashboard.empresa.Text
            .Range("A1:D1").Font.Bold = True
            .Range("A1:D1").Font.Size = 18
            'Rango de fechas 
            .Range("A2:D2").Merge()
            .Range("A2:D2").Value = "Lista de Precios  " + TextBox1.Text
            .Range("A2:D2").Font.Size = 12
            'sucursal generada 
            .Range("A4:D4").Merge()
            .Range("A4:D4").Value = "Existencias en la tienda :   " + sucursal + " (" + tienda + ")"
            .Range("A4:D4").Font.Size = 11
            'sucursal fecha 
            .Range("A5:D5").Merge()
            .Range("A5:D5").Value = "Generado al " + System.DateTime.Now.ToString
            .Range("A5:D5").Font.Size = 10
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 7
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
                    ' objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format
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
                'dibuo borde de fila 
                'objRangoReg.Rows.BorderAround()
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

    Private Sub marca_CheckedChanged(sender As Object, e As EventArgs) Handles marca.CheckedChanged
        Button1.Enabled = True
        Button2.Enabled = False
        TextBox1.Clear()
    End Sub

    Private Sub general_CheckedChanged(sender As Object, e As EventArgs) Handles general.CheckedChanged
        Button1.Enabled = False
        Button2.Enabled = True
        TextBox1.Clear()
    End Sub

    Private Sub categoria_CheckedChanged(sender As Object, e As EventArgs) Handles categoria.CheckedChanged
        Button1.Enabled = True
        Button2.Enabled = False
        TextBox1.Clear()

    End Sub
End Class