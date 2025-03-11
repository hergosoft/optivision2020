Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Public Class exportaexcel_temp
    Public dedonde As String
    Dim consulta, Second, estado, mensaje, cuenta1, banco1, mes, subtitulo As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As New DataTable
    Private Sub exportaexcel_temp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'mensaje pago sistema
        Timer1.Interval = 1000
        Timer1.Start() 'Timer starts functioning
        ProgressBar.Enabled = True
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
            .Range("A1:G1").Value = "" & dashboard.empresa.Text & ""
            .Range("A1:G1").Font.Bold = True
            .Range("A1:G1").Font.Size = 18

            .Range("A2:G2").Merge()
            .Range("A2:G2").Value = "" & titulo & ""
            .Range("A2:G2").Font.Bold = False
            .Range("A2:G2").Font.Size = 15
            'tienda a generar
            .Range("A3:G3").Merge()
            .Range("A3:G3").Value = "ESTADO: A=ACTIVO   B=BAJA (desactivado)"
            .Range("A3:G3").Font.Bold = True
            .Range("A3:G3").Font.Color = RGB(0, 0, 128)
            .Range("A3:G3").Font.Size = 10

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
        '  m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        '   Aca almacenar en la ruta especificada de un directorio
        'm_Excel.ActiveWorkbook.SaveAs(Filename:="UserProfile" & "\desktop\Prueba.xls")
        'm_Excel.ActiveWorkbook.Close(False)
        'Cierra el archivo y elimina la variable m_Excel.Quit()
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Second = Val(Second) + 1
        'set position
        ProgressBar.Value = ProgressBar.Value + 1
        'add the progress bar to the form
        If Second >= 5 Then
            Timer1.Stop() 'Timer stops functioning

            If dedonde = 1 Then
                'descargo el reporte de la nomenclatura contable completa 
                Try
                    conexion.Open()
                    consulta = "select no_cuenta,descrip,acde from catcuentasconta"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    adaptador.Fill(tabladatos)
                    DataGridView1.DataSource = tabladatos
                    DataGridView1.Columns(0).HeaderText = "No CUENTA"
                    DataGridView1.Columns(0).Width = 180
                    DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                    DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.Columns(2).HeaderText = "TIPO"
                    DataGridView1.Columns(2).Width = 150
                    conexion.Close()
                    'exporto la data encontrada a excel 
                    Try
                        'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
                        ExportarDatosExcel(DataGridView1, "NOMENCLATURA CONTABLE GENERAL")
                    Catch ex As Exception
                        'Si el intento es fallido, mostrar MsgBox.
                        MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MessageBox.Show(ex.ToString)
                    End Try
                Catch ex As Exception
                    MsgBox("No fue posible obtener la nomenclatura contable," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            ElseIf dedonde = 2 Then
                'descargo el reporte de grupo de cuentas contables
                Try
                    conexion.Open()
                    consulta = "select g.id_cuenta,g.descripcion,c.descripcion from gruposctasconta as g left join cat_gruposctasconta as c on (g.grupo=c.id_grupo)"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    tabladatos = New DataTable
                    adaptador.Fill(tabladatos)
                    DataGridView1.DataSource = tabladatos
                    DataGridView1.Columns(0).HeaderText = "No CUENTA"
                    DataGridView1.Columns(0).Width = 180
                    DataGridView1.Columns(1).HeaderText = "DESCRIPCION DE LA CUENTA"
                    DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.Columns(2).HeaderText = "GRUPO"
                    DataGridView1.Columns(2).Width = 200
                    conexion.Close()
                    'exporto la data encontrada a excel 
                    Try
                        'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
                        ExportarDatosExcel(DataGridView1, "REPORTE GENERAL DE CUENTAS CONTABLES")
                    Catch ex As Exception
                        'Si el intento es fallido, mostrar MsgBox.
                        MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MessageBox.Show(ex.ToString)
                    End Try
                Catch ex As Exception
                    MsgBox("No fue posible obtener el grupo de cuentas contables," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            ElseIf dedonde = 3 Then
                'descargo el listado de vendedores 
                Try
                    conexion.Open()
                    consulta = " SELECT v.id_codigo,v.nombre,v.status as estado,a.nombre FROM vendedores as v left join catagencias as a on (v.id_agencia=a.id_agencia) order by v.id_codigo"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    tabladatos = New DataTable
                    adaptador.Fill(tabladatos)
                    DataGridView1.DataSource = tabladatos
                    DataGridView1.Columns(0).HeaderText = "CODIGO"
                    DataGridView1.Columns(0).Width = 180
                    DataGridView1.Columns(1).HeaderText = "NOMBRE"
                    DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.Columns(2).HeaderText = "ESTADO"
                    DataGridView1.Columns(2).Width = 200
                    DataGridView1.Columns(3).HeaderText = "AGENCIA"
                    DataGridView1.Columns(3).Width = 200
                    conexion.Close()
                    'exporto la data encontrada a excel 
                    Try
                        'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
                        ExportarDatosExcel(DataGridView1, "REPORTE GENERAL DE VENDEDORES ")
                    Catch ex As Exception
                        'Si el intento es fallido, mostrar MsgBox.
                        MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MessageBox.Show(ex.ToString)
                    End Try
                Catch ex As Exception
                    MsgBox("No fue posible obtener el grupo de cuentas contables," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            End If
            Second = 0
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class