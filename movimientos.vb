Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class movimientos
    Dim consulta, opcion, pregunta As String
    Dim adapatador As MySqlDataAdapter
    Dim tabladocto As DataTable
    Dim rs As MySqlDataReader
    Dim com As MySqlCommand
    Dim correlativo As Integer
    Dim total As Double = 0
    Public dedonde, movi, hechopor As String


    Private Sub movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DefaultCellStyle.Font = New Font("Arial", 9)
        If dedonde = 1 Then
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            GroupBox3.Visible = True
            'obtengo el listado de lineas de entradas 
            Try
                conexion.Open()
                consulta = "SELECT * FROM catkardex where id_movi<='5'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladocto = New DataTable
                adapatador.Fill(tabladocto)
                cmb_tipo.DataSource = tabladocto
                cmb_tipo.DisplayMember = "nombre"
                cmb_tipo.ValueMember = "id_movi"
                conexion.Close()
                hechopor = dashboard.usuario.Text
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de movimientos de entrada," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 2 Then
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            GroupBox3.Visible = True
            hechopor = dashboard.usuario.Text
            'obtengo el listado de lineas ed salidas 
            Try
                conexion.Open()
                consulta = "select * from catkardex where id_movi>='51' and id_movi<='54'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladocto = New DataTable
                adapatador.Fill(tabladocto)
                cmb_tipo.DataSource = tabladocto
                cmb_tipo.DisplayMember = "nombre"
                cmb_tipo.ValueMember = "id_movi"
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de movimientos de salida," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 3 Then
            GroupBox3.Visible = False
        ElseIf dedonde = 4 Then
            'consulta/re impresion documentos por ingreso 
            Button4.PerformClick()
            Button4.Visible = False
            If consulta_documento.dedonde = 15 Then
                Button2.Enabled = True
                Button2.Text = "ANULAR"
                Button2.Image = My.Resources.cancel
                Button5.Visible = False

            End If
        ElseIf dedonde = 5 Then
            'consulta/ re impresion documentos de salida
            Button4.PerformClick()
            Button4.Visible = False
            If consulta_documento.dedonde = 16 Then
                Button2.Enabled = True
                Button2.Text = "ANULAR"
                Button2.Image = My.Resources.cancel
                Button5.Visible = False

            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If dedonde = 4 Or dedonde = 5 Then
            Me.Dispose()

        Else
            Me.Close()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carga_producto_1.dedonde = 1
        carga_producto_1.ShowDialog()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If consulta_documento.dedonde = 15 Then
            'anulacion movimiento de entrada a inventario 
            Dim pregunta As String
            pregunta = MsgBox("Esta a punto de eliminar por completo este documento del sistema." & vbCrLf & vbCrLf & "¿Desea continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Elimina movimiento")
            If pregunta = vbYes Then
                'procedo con la eliminacion
                Try

                Catch ex As Exception

                End Try

            ElseIf pregunta = vbNo Then
                'no hago nada 

            End If




        Else
                If cmb_tipo.SelectedIndex = 0 Then
                MessageBox.Show("No puedes grabar el documento como DOCUMENTO NO DEFINIDO, por favor selecciona un tipo diferente", "Tipo de Documento Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                'realizo la suma de los productos cargados
                Dim fila As DataGridViewRow = New DataGridViewRow()
                For Each fila In DataGridView1.Rows
                    total += Convert.ToDouble(fila.Cells(0).Value)
                Next
                'obtengo el correlativo del documento seleccionado a guardar 
                Try
                    conexion.Open()
                    consulta = "SELECT * FROM catkardex where id_movi='" & opcion & "'"
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    correlativo = rs(2)
                    serie.Text = rs(3)
                    rs.Close()
                    conexion.Close()
                Catch ex As Exception
                    MsgBox("No fue posible obtener el correlativo para el documento a grabar," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
                correlativo = Val(correlativo) + 1

                ''verifico de donde llame el formulario para poder guardar si es movimiento de entrada o movimiento de salida    
                If dedonde = 1 Then
                    'movimiento entrada
                    'guardo el dellate en el kardex entrada

                    Try
                        conexion.Open()
                        consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,obs,hechopor,obsservi) VALUES (@codigo,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & opcion & "','" & correlativo & "','" & serie.Text & "',@cantidad,'0',@descripcion,'" & dashboard.usuario.Text & "','" & TextBox1.Text & "')"
                        com = New MySqlCommand(consulta, conexion)
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            com.Parameters.Clear()
                            com.Parameters.AddWithValue("@cantidad", row.Cells(0).Value)
                            com.Parameters.AddWithValue("@codigo", row.Cells(1).Value)
                            com.Parameters.AddWithValue("@descripcion", row.Cells(2).Value)
                            com.ExecuteNonQuery()
                        Next
                        conexion.Close()
                        MessageBox.Show("Documento    No. " & correlativo.ToString & "    Serie " & serie.Text & "    Grabado con exito!")
                        'pregunto si deseo imprimir el documento guardado
                        pregunta = MsgBox("¿Desea Imprimir el documento?" & vbCrLf, vbYesNo + vbInformation + vbDefaultButton2, "Imprimir.")
                    Catch ex As Exception
                        MsgBox("No fue posible grabar el detalle de entrada en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                  vbCrLf & vbCrLf & ex.Message,
                  MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                ElseIf dedonde = 2 Then
                    'guardo el detalle en el kardex de salida
                    Try
                        conexion.Open()
                        consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,obs,hechopor,obsservi) VALUES (@codigo,'" & dashboard.no_agencia & "','" & fecha.Text & "','" & opcion & "','" & correlativo & "','" & serie.Text & "','0',@cantidad,@descripcion,'" & dashboard.usuario.Text & "','" & TextBox1.Text & "')"
                        com = New MySqlCommand(consulta, conexion)
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            com.Parameters.Clear()
                            com.Parameters.AddWithValue("@cantidad", row.Cells(0).Value)
                            com.Parameters.AddWithValue("@codigo", row.Cells(1).Value)
                            com.Parameters.AddWithValue("@descripcion", row.Cells(2).Value)
                            com.ExecuteNonQuery()
                        Next
                        conexion.Close()
                        MessageBox.Show("Documento    No. " & correlativo.ToString & "    Serie " & serie.Text & "    Grabado con exito!")
                        pregunta = MsgBox("¿Desea Imprimir el documento?" & vbCrLf, vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
                    Catch ex As Exception
                        MsgBox("No fue posible grabar el detalle de la salida en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                        conexion.Close()
                        Return
                    End Try
                End If
                Try
                    'actualizo el correlativo
                    conexion.Open()
                    consulta = "UPDATE catkardex set correlativo='" & correlativo & "' where id_movi='" & opcion & "' "
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    conexion.Close()
                Catch ex As Exception
                    MsgBox("No fue posible actualizar el correlativo del documento," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
                If pregunta = vbYes Then
                    Dim dialog As New PrintPreviewDialog()
                    dialog.Document = PrintDocument1
                    DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                    dialog.ShowDialog()
                    Me.Close()
                ElseIf pregunta = vbNo Then
                    Me.Close()
                End If
            End If
        End If


    End Sub

    Private Sub cmb_tipo_MouseClick(sender As Object, e As MouseEventArgs) Handles cmb_tipo.MouseClick
      
    End Sub

    Private Sub cmb_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipo.SelectedIndexChanged
        
       
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub cmb_tipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_tipo.SelectionChangeCommitted
        opcion = cmb_tipo.SelectedValue.ToString
        'recorro la tabla tipodocto para obtener el corelativo y la serie 
        Dim rows1() As DataRow = tabladocto.Select("id_movi='" & opcion & "'")
        Dim dt3 As DataTable = tabladocto.Clone()
        For Each row As DataRow In rows1
            dt3.ImportRow(row)
        Next
        'copio la serie encontrada a un textbox
        DataGridView2.DataSource = dt3
        Dim row2 As DataGridViewRow = DataGridView2.CurrentRow
        serie.Text = CStr(row2.Cells(3).Value)
    End Sub
  
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fuente As Font
        Dim margenEsq As Single = e.MarginBounds.Left ' defino margen a impresion de la grilla
        Dim cont = 79
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        'declaro la fuente que utilzare
        'imprimo titulo
        e.Graphics.DrawString(dashboard.empresa.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 70, 20)
        'imprimo fecha
        e.Graphics.DrawString("FECHA INGRESO:  " & fecha.Text, fuente, Brushes.Black, 150, 50)
        ' imprimo la sucursal 
        e.Graphics.DrawString("SUCURSAL:  " & dashboard.agencia.Text & " No. (" & dashboard.no_agencia & ")", fuente, Brushes.Black, 15, 45)
        'imprimo el tipo de documento 
        If dedonde = 4 Or dedonde = 5 Then
            're impresion consulta movimientos entrada 
            e.Graphics.DrawString("TIPO DOCUMENTO:  " & Label8.Text & " (" & movi & ")", fuente, Brushes.Black, 15, 50)
        Else
            e.Graphics.DrawString("TIPO DOCUMENTO:  " & cmb_tipo.Text & " (" & movi & ")", fuente, Brushes.Black, 15, 50)
        End If

        'imprimo el correlativo y la serie 
        If dedonde = 4 Or dedonde = 5 Then
            'desde re impresion de movimientos ingresos por ajuste 
            e.Graphics.DrawString("Docto:.  " & no_factura.Text & " - " & serie.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Red, 165, 5)
        Else
            e.Graphics.DrawString("Docto:.  " & correlativo & " - " & serie.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Red, 165, 5)
        End If


        'imprimo encabezado del datagridview
        e.Graphics.DrawString("CANT.", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 63)
        e.Graphics.DrawString("CODIGO", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 30, 63)
        e.Graphics.DrawString("DESCRIPCION", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 85, 63)
        e.Graphics.DrawString("MARCA", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 165, 63)
        e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 13, 66)
        For linea = 0 To DataGridView1.RowCount - 1
            If cont < 900 Then
                e.Graphics.DrawString(DataGridView1.Item(0, linea).Value.ToString, fuente, Brushes.Black, 15, cont)
                e.Graphics.DrawString(DataGridView1.Item(1, linea).Value.ToString, fuente, Brushes.Black, 33, cont)
                e.Graphics.DrawString(DataGridView1.Item(2, linea).Value.ToString, fuente, Brushes.Black, 55, cont)
                e.Graphics.DrawString(DataGridView1.Item(3, linea).Value.ToString, fuente, Brushes.Black, 160, cont)
                cont += 5
            Else
                cont = 320
            End If
        Next
        e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 13, 220)
        e.Graphics.DrawString("Total:. " & total.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 13, 225)
        e.Graphics.DrawString("HECHO POR: ", Font, Brushes.Black, 15, 235)
        e.Graphics.DrawString(hechopor, New Font("Arial", 11, FontStyle.Bold), Brushes.Black, 40, 234)
        e.Graphics.DrawString("ENTREGO:  _______________________________", Font, Brushes.Black, 15, 245)
        e.Graphics.DrawString("RECIBIO: ____________________________________", Font, Brushes.Black, 120, 235)
        e.Graphics.DrawString("FECHA RECIBIO: ______________________________", Font, Brushes.Black, 120, 245)
        e.Graphics.DrawString("Obs:. " & TextBox1.Text, Font, Brushes.Black, 15, 255)
        e.HasMorePages = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click

        'realizo la busquedad del documento a re imprimir 
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        If dedonde = 4 Then
            'RE IMPRESION DE DOCUMENTO INGRESO A INVENTARIO 
            Try
                consulta = "select k.entrada,k.id_codigo,k.obs,i.id_marca from kardexinven as k left join inventario as i on i.id_codigo=k.id_codigo  where k.docto='" & no_factura.Text & "' and k.serie='" & serie.Text & "' ;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladocto = New DataTable
                adapatador.Fill(tabladocto)
                DataGridView1.DataSource = tabladocto
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "CANTIDAD"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).HeaderText = "CODIGO"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(2).Width = 328
                DataGridView1.Columns(3).HeaderText = "MARCA"
                DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de documentos operados," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 5 Then
            'RE IMPRESION DE DOCUMENTOS POR SALIDA 
            Try
                consulta = "select k.salida,k.id_codigo,k.obs,i.id_marca from kardexinven as k left join inventario as i on i.id_codigo=k.id_codigo  where k.docto='" & no_factura.Text & "' and k.serie='" & serie.Text & "';"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladocto = New DataTable
                adapatador.Fill(tabladocto)
                DataGridView1.DataSource = tabladocto
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "CANTIDAD"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).HeaderText = "CODIGO"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(2).Width = 328
                DataGridView1.Columns(3).HeaderText = "MARCA"
                DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de documentos operados," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try






        Else
            Try
                consulta = "SELECT cantidad, id_codigo, obs  from detconsigna where no_factura='" & no_factura.Text & "' and serie='" & serie.Text & "'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladocto = New DataTable
                adapatador.Fill(tabladocto)
                DataGridView1.DataSource = tabladocto
                DataGridView1.Columns(0).HeaderText = "CANTIDAD"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).HeaderText = "CODIGO"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "DESCRIPCION"
                DataGridView1.Columns(2).Width = 478
                conexion.Close()
                correlativo = no_factura.Text
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible encontrar el documento solicitado, si el problema persiste favor contacta a Soporte Tecnico")
                MessageBox.Show(ex.ToString)
            End Try
            Try
                conexion.Open()
                consulta = "SELECT c.hechopor,c.fecha,m.nombre FROM consignaciones as c left join catkardex as m on (c.id_movi=m.id_movi) where c.no_factura='" & no_factura.Text & "'  and c.serie='" & serie.Text & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                hechopor = rs(0)
                fecha.Text = rs(1)
                movi = rs(2)
                rs.Close()
                conexion.Close()

            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible obtener el encabezado del documento")
                MessageBox.Show(ex.ToString)
            End Try
            'realizo la suma de los productos cargados
            Dim fila As DataGridViewRow = New DataGridViewRow()
            For Each fila In DataGridView1.Rows
                total += Convert.ToDouble(fila.Cells(0).Value)
            Next

        End If


    End Sub

    Private Sub no_factura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles no_factura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            serie.Focus()
        End If
    End Sub

    Private Sub no_factura_TextChanged(sender As Object, e As EventArgs) Handles no_factura.TextChanged

    End Sub

    Private Sub serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles serie.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button4.Focus()

        End If
    End Sub

    Private Sub serie_TextChanged(sender As Object, e As EventArgs) Handles serie.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If dedonde = 4 Or dedonde = 5 Then
            'realizo la sumatoria de todos los productos cargados 
            Dim fila As DataGridViewRow = New DataGridViewRow()
            For Each fila In DataGridView1.Rows
                total += Convert.ToDouble(fila.Cells(0).Value)
            Next

        End If
        'pregunto si deseo imprimir el documento guardado
        pregunta = MsgBox("¿Desea Imprimir el documento?" & vbCrLf, vbYesNo + vbInformation + vbDefaultButton2, "Imprimir.")
        If pregunta = vbYes Then
            Dim dialog As New PrintPreviewDialog()
            dialog.Document = PrintDocument1
            DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
            dialog.ShowDialog()
            If dedonde = 4 Or dedonde = 5 Then
                Me.Dispose()
            Else
                Me.Close()
            End If
        ElseIf pregunta = vbNo Then
            If dedonde = 4 Or dedonde = 5 Then
                Me.Dispose()
            Else
                Me.Close()

            End If

        End If
    End Sub

    Private Sub lineas_Click(sender As Object, e As EventArgs) Handles lineas.Click
        
    End Sub

    Private Sub lineas_TextChanged(sender As Object, e As EventArgs) Handles lineas.TextChanged
        If Val(lineas.Text) = 0 Then
            carga_producto_1.Close()
            MessageBox.Show("Has llegado al limite de lineas permitidas por documento, guardalo y crea uno nuevo")
            Button1.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'elimino al darle doble clic 
        MessageBox.Show("Se eliminara el producto seleccionado")
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        DataGridView1.Rows.RemoveAt(i)
    End Sub
End Class