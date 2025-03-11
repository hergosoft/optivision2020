Imports MySql.Data.MySqlClient
Public Class carga_producto_1
    Dim consulta As String
    Dim com As MySqlCommand
    Dim rs As MySqlDataReader
    Public dedonde, marca As String

    Dim existe As Boolean

    Private Sub carga_producto_1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Dispose()
        End If
    End Sub
    Private Sub carga_producto_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles codigo.KeyPress
        'al presionar enter 
        If Asc(e.KeyChar) = 13 Then
            'valido si el textbox esta vacio, si esta vacio abro la ventana para buscar producto por descripcion
            If Me.codigo.Text = "" Then
                agrega_producto.dedonde = 2
                agrega_producto.TextBox1.Select()
                agrega_producto.ShowDialog()
            Else
                'si tiene codigo entonces busco el codigo ingresado directo en la base de datos 
                Try
                    conexion.Open()
                    consulta = "SELECT id_codigo, producto,id_marca from inventario where id_codigo='" & codigo.Text & "' "
                    com = New MySqlCommand(consulta, conexion)
                    rs = com.ExecuteReader
                    rs.Read()
                    descripcion.Text = rs(1)
                    marca = rs(2)
                    conexion.Close()
                    cantidad.Enabled = True
                    cantidad.Focus()
                    codigo.Enabled = False
                    Button1.Enabled = True
                Catch ex As Exception
                    'si no encuento el codigo muestro mensaje de error 
                    MessageBox.Show("El codigo que ingresaste no existe, intenta de nuevo")
                    conexion.Close()
                    codigo.Enabled = True
                    codigo.Clear()
                    codigo.Focus()
                    cantidad.Enabled = False
                    Button1.Enabled = False
                    descripcion.Clear()
                    cantidad.Text = "1"
                    disponible.Text = "0"
                End Try
            End If
        End If
    End Sub

    Private Sub codigo_TextChanged(sender As Object, e As EventArgs) Handles codigo.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'valido de donde estoy llamando al a ventana 
        If dedonde = 1 Then

            'verifico que el codigo que voy a agregar no haya sido ingresado anteriormente evitar mensaje de codigo duplicado
            If movimientos.DataGridView1.Rows.Count < 1 Then
                'guardo en la ventana movimientos 
                movimientos.DataGridView1.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text, marca)
                conexion.Close()
                codigo.Enabled = True
                codigo.Clear()
                codigo.Focus()
                cantidad.Enabled = False
                Button1.Enabled = False
                descripcion.Clear()
                cantidad.Text = "1"
                disponible.Text = "0"
                movimientos.lineas.Text = Val(movimientos.lineas.Text) - 1
            Else
                For Each Fila As DataGridViewRow In movimientos.DataGridView1.Rows
                    If Fila.Cells(1).Value = codigo.Text Then
                        MessageBox.Show("Ya has agregado el codigo " & codigo.Text & vbCrLf & vbCrLf & "- Si necesitas agregar mas existencia del mismo codigo, por favor eliminalo del listado dando doble click sobre el codigo y vuelve a agregarlo con la existencia total", "Codigo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                        cantidad.Focus()
                        existe = True
                    Else
                        existe = False
                    End If
                Next
                If existe = False Then
                    'guardo en la ventana movimientos 
                    movimientos.DataGridView1.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text)
                    codigo.Enabled = True
                    codigo.Clear()
                    codigo.Focus()
                    cantidad.Enabled = False
                    Button1.Enabled = False
                    descripcion.Clear()
                    cantidad.Text = "1"
                    disponible.Text = "0"
                    movimientos.lineas.Text = Val(movimientos.lineas.Text) - 1
                End If
            End If
        ElseIf dedonde = 2 Then
            If traslado.dtv_traslado.Rows.Count < 1 Then
                'guardo en la ventana traslados
                traslado.dtv_traslado.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text)
                conexion.Close()
                codigo.Enabled = True
                codigo.Clear()

                codigo.Focus()
                cantidad.Enabled = False
                Button1.Enabled = False
                descripcion.Clear()
                cantidad.Text = 0
                disponible.Text = 0
            Else
                For Each Fila As DataGridViewRow In traslado.dtv_traslado.Rows
                    If Fila.Cells(1).Value = codigo.Text Then
                        MessageBox.Show("Ya has agregado el codigo " & codigo.Text & vbCrLf & vbCrLf & "- Si necesitas agregar mas existencia del mismo codigo, por favor eliminalo del listado dando doble click sobre el codigo y vuelve a agregarlo con la existencia total", "Codigo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                        cantidad.Focus()
                        existe = True
                    Else
                        existe = False
                    End If
                Next
                If existe = False Then
                    'guardo en la ventana traslados
                    traslado.dtv_traslado.Rows.Add(cantidad.Text, codigo.Text, descripcion.Text)
                    conexion.Close()
                    codigo.Enabled = True
                    codigo.Clear()
                    codigo.Focus()
                    cantidad.Enabled = False
                    Button1.Enabled = False
                    descripcion.Clear()
                    cantidad.Text = "1"
                    disponible.Text = "0"
                End If
            End If
        End If

    End Sub

    Private Sub cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()

        End If
    End Sub

    Private Sub cantidad_TextChanged(sender As Object, e As EventArgs) Handles cantidad.TextChanged

    End Sub
End Class