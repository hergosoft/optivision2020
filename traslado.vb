Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class traslado
    Dim consulta, pregunta, fechaformato As String
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Dim correlativo As Integer
    Dim total As Double = 0
    Public dedonde, serie As String


    Private Sub traslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dedonde = 1 Then
            fecha.Text = DateTime.Now.ToString("yyyy/MM/dd")
            'obtengo el correlativo de consignaciones 
            Try
                conexion.Open()
                consulta = "SELECT * FROM catkardex where id_movi='52'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(2)
                serie = rs(3)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            correlativo = Val(correlativo) + 1
            documento.Text = correlativo
        ElseIf dedonde = 2 Then
            'verifico el formato de la fecha obtenida de la ventana anterior 
            fechaformato = Format(CDate(fecha.Text), "yyyy-MM-dd")
            fecha.Text = fechaformato
        ElseIf dedonde = 3 Then
            'verifico el formato de la fecha obtenida de la ventana anterior 
            fechaformato = Format(CDate(fecha.Text), "yyyy-MM-dd")
            fecha.Text = fechaformato
        End If
      
    End Sub

    Private Sub no_agencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles no_agencia.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'valido el numero de agencia ingresado 
            If Me.no_agencia.Text = " " Then
                MessageBox.Show("Por favor ingresa un numero de agencia valido para poder continuar ")
                Return
                no_agencia.Focus()
            Else
                'valido que la agencia ingresada no sea la misma que se tiene seleccionada 
                If no_agencia.Text = dashboard.no_agencia Then
                    MessageBox.Show("La agencia que recibe no puede ser igual a la agencia de donde se esta sacando el producto" & vbCrLf & "Por favor elige otra")
                Else
                    'busco la agencia ingresada
                    Try
                        conexion.Open()
                        consulta = "SELECT  nombre from catagencias where id_agencia='" & no_agencia.Text & "' "
                        com = New MySqlCommand(consulta, conexion)
                        rs = com.ExecuteReader
                        rs.Read()
                        agencia_recibe.Text = rs(0)
                        rs.Close()
                        conexion.Close()
                        obs.Focus()
                    Catch ex As Exception
                        MsgBox("No fue posible encontrar la agencia solicitada," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                        conexion.Close()
                        Return
                    End Try
                End If
            End If
            
        End If
    End Sub


    Private Sub obs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles obs.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btn_agrega.Focus()

        End If
    End Sub

    Private Sub obs_TextChanged(sender As Object, e As EventArgs) Handles obs.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub btn_agrega_Click(sender As Object, e As EventArgs) Handles btn_agrega.Click
        carga_producto_1.dedonde = 2
        carga_producto_1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'prgunto si deseo eliminar el codigo seleccionado 
        pregunta = MsgBox("Se eliminara el codigo seleccionado" & vbCrLf & "  ¿Desea Continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Eliminar Codigo")
        If vbYes Then
            'elimino la celada
            For Each r As DataGridViewRow In dtv_traslado.SelectedRows
                dtv_traslado.Rows.Remove(r)
            Next
        Else
            'cancelo la accion 
            Return
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dedonde = 1 Then
            'realizo la grabacion por ingreso de traslado 
            Dim fila As DataGridViewRow = New DataGridViewRow()
            For Each fila In dtv_traslado.Rows
                total += Convert.ToDouble(fila.Cells("cantidad").Value)
            Next
            'verifico nuevamente el correlativo del documento a grabar 
            'obtengo el correlativo de consignaciones 
            Try
                conexion.Open()
                consulta = "SELECT * FROM catkardex where id_movi='52'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo = rs(2)
                serie = rs(3)
                rs.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el correlativo a seguir," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            correlativo = Val(correlativo) + 1
            documento.Text = correlativo
            'realizo la grabacion del encabezado
            Try
                conexion.Open()
                consulta = "INSERT INTO consignaciones  (no_factura,serie,fecha,status,id_cliente,cliente,obs,hechopor,id_agencia,id_movi) values ('" & correlativo & "', '" & serie & "', '" & fecha.Text & "', 'P', '" & no_agencia.Text & "', '" & agencia_recibe.Text & "', '" & obs.Text & "','" & dashboard.usuario.Text & "', '" & dashboard.no_agencia & "','52')"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No fue posible grabar el encabezado del documento," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            Try
                'realizo la grabacion del detalle de la cosignacion
                consulta = "INSERT INTO detconsigna (no_factura,serie,id_codigo,cantidad,obs,id_agencia,id_cliente,id_movi) VALUES ('" & correlativo & "','" & serie & "',@codigo,@cantidad,@descripcion,'" & dashboard.no_agencia & "','" & no_agencia.Text & "','52')"
                com = New MySqlCommand(consulta, conexion)
                For Each row As DataGridViewRow In dtv_traslado.Rows
                    com.Parameters.Clear()
                    com.Parameters.AddWithValue("@cantidad", row.Cells(0).Value)
                    com.Parameters.AddWithValue("@codigo", row.Cells(1).Value)
                    com.Parameters.AddWithValue("@descripcion", row.Cells(2).Value)
                    com.ExecuteNonQuery()
                Next
            Catch ex As Exception
                MsgBox("No fue posible grabar el detalle del documento," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            'realizo la grabacion en el kardex
            Try
                consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,obs,hechopor) VALUES (@codigo,'" & dashboard.no_agencia & "','" & fecha.Text & "','52','" & correlativo & "','" & serie & "','0',@cantidad,@descripcion,'" & dashboard.usuario.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                For Each row As DataGridViewRow In dtv_traslado.Rows
                    com.Parameters.Clear()
                    com.Parameters.AddWithValue("@cantidad", row.Cells(0).Value)
                    com.Parameters.AddWithValue("@codigo", row.Cells(1).Value)
                    com.Parameters.AddWithValue("@descripcion", row.Cells(2).Value)
                    com.ExecuteNonQuery()
                Next
                conexion.Close()
                Try
                    'actualizo el correlativo
                    conexion.Open()
                    consulta = "UPDATE catkardex set correlativo='" & correlativo & "' where id_movi='52' "
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
                MessageBox.Show("Traslado    No. " & correlativo & "    Serie " & serie & "    Grabado con exito!")
                pregunta = MsgBox("¿Desea Imprimir el Traslado?" & vbCrLf, vbYesNo + vbInformation + vbDefaultButton1, "Imprimir.")
            Catch ex As Exception
                MsgBox("No fue posible grabar la salida del documento en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            If pregunta = vbYes Then
                Dim dialog As New PrintPreviewDialog()
                dialog.Document = PrintDocument1
                DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
                DirectCast((dialog.Controls(1)), ToolStrip).Items.RemoveAt(0)
                DirectCast((dialog.Controls(1)), ToolStrip).Items.Insert(0, Me.ToolStripButton1)
                dialog.ShowDialog()
                Me.Close()
            ElseIf pregunta = vbNo Then
                Me.Close()
            End If
        ElseIf dedonde = 2 Then
            'realizo la grabacion por recepcion de traslado
            'grabo recepcion en el kardex 
            'realizo la grabacion en el kardex
            Try
                conexion.Open()
                consulta = "INSERT INTO kardexinven (id_codigo,id_agencia,fecha,id_movi,docto,serie,entrada,salida,obs,hechopor) VALUES (@CODIGO,'" & dashboard.no_agencia & "','" & fecha.Text & "','45','" & documento.Text & "','" & serie & "',@CANTIDAD,'0',@DESCRIPCION,'" & dashboard.usuario.Text & "')"
                com = New MySqlCommand(consulta, conexion)
                For Each row As DataGridViewRow In dtv_traslado.Rows
                    com.Parameters.Clear()
                    com.Parameters.AddWithValue("@CANTIDAD", row.Cells(0).Value)
                    com.Parameters.AddWithValue("@CODIGO", row.Cells(1).Value)
                    com.Parameters.AddWithValue("@DESCRIPCION", row.Cells(2).Value)
                    com.ExecuteNonQuery()
                Next    
            Catch ex As Exception
                MsgBox("No fue posible grabar la entrada del producto en el kardex," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            Try
                'actualizo el estatus del encabezado de la consignacion para que ya no aparezca como pendiente 
                consulta = "UPDATE consignaciones set status='R' where no_factura='" & documento.Text & "' and serie='" & serie & "' "
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                MessageBox.Show("Traslado    No. " & documento.Text & "    Serie " & serie & "    Recibido con Exito!", "Recepcion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                traslado_consulta.refrescar.PerformClick()
                Me.Close()
            Catch ex As Exception
                MsgBox("No fue posible actualizar el status del documento," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 3 Then
            'consultra traslado 
            'realizo impresion del trasaldo en pantalla 

        End If
    End Sub
    ' Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim blackPen As New Pen(Color.FromArgb(255, 0, 0, 0), 0.5)
        Dim fuente As Font
        Dim margenEsq As Single = e.MarginBounds.Left ' defino margen a impresion de la grilla
        Dim cont = 79
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        'declaro la fuente que utilzare
        'imprimo titulo
        e.Graphics.DrawString(dashboard.empresa.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 70, 20)
        'imprimo fecha
        e.Graphics.DrawString("FECHA :  " & fecha.Text, fuente, Brushes.Black, 150, 48)
        e.Graphics.DrawRectangle(blackPen, 10, 38, 195, 20)
        ' imprimo la sucursal 
        e.Graphics.DrawString("SUCURSAL QUE ENVIA:  " & dashboard.agencia.Text & " No. (" & dashboard.no_agencia & ")", fuente, Brushes.Black, 15, 43)
        e.Graphics.DrawString("SUCURSAL QUE RECIBE:  " & agencia_recibe.Text & " No. (" & no_agencia.Text & ")", fuente, Brushes.Black, 15, 48)

        'imprimo el tipo de documento 
        e.Graphics.DrawString("TIPO DOCUMENTO:  TRASLADO", fuente, Brushes.Black, 150, 43)
        'imprimo el correlativo y la serie 
        e.Graphics.DrawString("Docto:.  " & correlativo & " - " & serie, New Font("Arial", 12, FontStyle.Bold), Brushes.Red, 165, 5)

        'imprimo encabezado del datagridview
        e.Graphics.DrawString("CODIGO", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 23, 70)
        e.Graphics.DrawString("DESCRIPCION", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 60, 70)
        e.Graphics.DrawString("CANTIDAD", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, 70)
        e.Graphics.DrawRectangle(blackPen, 10, 75, 195, 150)
        'e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 15, 73)
        For linea = 0 To dtv_traslado.RowCount - 1
            If cont < 900 Then
                e.Graphics.DrawString(dtv_traslado.Item(1, linea).Value.ToString, fuente, Brushes.Black, 26, cont)
                e.Graphics.DrawString(dtv_traslado.Item(2, linea).Value.ToString, fuente, Brushes.Black, 55, cont)
                e.Graphics.DrawString(dtv_traslado.Item(0, linea).Value.ToString, fuente, Brushes.Black, 180, cont)
                cont += 5
            Else
                cont = 370
            End If
        Next

        'e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 15, 220)
        e.Graphics.DrawString("Total:. " & total.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 160, 226)
        e.Graphics.DrawString("HECHO POR: ", Font, Brushes.Black, 15, 235)
        e.Graphics.DrawString(dashboard.usuario.Text, New Font("Arial", 11, FontStyle.Bold), Brushes.Black, 40, 234)
        e.Graphics.DrawString("ENTREGO:  _______________________________", Font, Brushes.Black, 15, 245)
        e.Graphics.DrawString("RECIBIO: ____________________________________", Font, Brushes.Black, 120, 235)
        e.Graphics.DrawString("FECHA RECIBIO: ______________________________", Font, Brushes.Black, 120, 245)

        e.Graphics.DrawRectangle(blackPen, 10, 253, 195, 15)
        e.Graphics.DrawString("Obs:. " & obs.Text, Font, Brushes.Black, 15, 255)
        e.HasMorePages = False
    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs) Handles buscar.Click
        dtv_traslado.Columns.Clear()
        Try
            conexion.Open()
            consulta = "SELECT cantidad, id_codigo, obs from detconsigna where no_factura='" & documento.Text & "' and serie='" & serie & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabladatos = New DataTable
            adaptador.Fill(tabladatos)
            dtv_traslado.DataSource = tabladatos
            'doy formato al dtv
            dtv_traslado.Columns(0).HeaderText = "CANTIDAD"
            dtv_traslado.Columns(0).Width = 100
            dtv_traslado.Columns(1).HeaderText = "CODIGO"
            dtv_traslado.Columns(1).Width = 100
            dtv_traslado.Columns(2).HeaderText = "DESCRIPCION"
            dtv_traslado.Columns(2).Width = 400

            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el detalle del documento solicitado," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
     

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtv_traslado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_traslado.CellContentClick

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'Dim PrintDialog1 As New PrintDialog()
        'PrintDialog1.Document = PrintDocument1
        '  Dim result As DialogResult = PrintDialog1.ShowDialog()
        '  If (result = DialogResult.OK) Then
        ' PrintDocument1.Print()
        ' End If

        Dim result As DialogResult = PrintDialog1.ShowDialog
        If (result = DialogResult.OK) Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            ' PrintDocument1.PrinterSettings.DefaultPageSettings.Margins.Top = 10
            ' PrintDocument1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 10
            ' PrintDocument1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            ' PrintDocument1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            ' PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = True
            PrintDocument1.Print()

            'PrintDocument1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        pregunta = MsgBox("¿Desea Imprimir el Traslado?" & vbCrLf, vbYesNo + vbInformation + vbDefaultButton2, "Imprimir.")

        If pregunta = vbYes Then
            Dim dialog As New PrintPreviewDialog()
            dialog.Document = PrintDocument1
            DirectCast(dialog, Form).WindowState = FormWindowState.Maximized
            DirectCast((dialog.Controls(1)), ToolStrip).Items.RemoveAt(0)
            DirectCast((dialog.Controls(1)), ToolStrip).Items.Insert(0, Me.ToolStripButton1)
            dialog.ShowDialog()
            Me.Close()
        ElseIf pregunta = vbNo Then
            Me.Close()
        End If
    End Sub

    Private Sub dtv_traslado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_traslado.CellDoubleClick
        'elimino al darle doble clic 
        MessageBox.Show("Se eliminara el producto seleccionado")
        Dim i As Integer
        i = dtv_traslado.CurrentRow.Index
        dtv_traslado.Rows.RemoveAt(i)
    End Sub
End Class