Imports MySql.Data.MySqlClient
Public Class busca_anticipo
    Dim consulta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabla_recibo As DataTable
    Dim nombre_paciente, total_compra, valor_recibo, no_recibo, resultado As String
    Public total_ordencompra, conteo As String
    
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            Label1.Text = "Buscando Recibo por Nombre"
            TextBox1.Clear()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            Label1.Text = "Buscando Recibo por Numero"
            TextBox1.Clear()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub busca_anticipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If

    End Sub

    Private Sub busca_anticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dtv_recibo
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        Try
            'cargo recibos para mostrar al abrir la ventana
            conexion.Open()
            consulta = "SELECT  recibo, fecha,nombre,  format(este_pago,2),color,direccion FROM recibos where nombre<>'**ANULADO**' and id_agencia='" & dashboard.no_agencia & "' and anticipo='x' order by fecha desc limit 100"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabla_recibo = New DataTable
            adaptador.Fill(tabla_recibo)
            dtv_recibo.DataSource = tabla_recibo
            conexion.Close()
            dtv_recibo.Columns(0).HeaderText = "RECIBO"
            dtv_recibo.Columns(0).Width = 60
            dtv_recibo.Columns(1).HeaderText = "FECHA"
            dtv_recibo.Columns(2).HeaderText = "NOMBRE"
            dtv_recibo.Columns(2).Width = 255
            dtv_recibo.Columns(3).HeaderText = "VALOR"
            dtv_recibo.Columns(4).Visible = False
            dtv_recibo.Columns(5).Visible = False
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("No pude cargar el listado de recibos pendientes de operar", "Contacta con Soporte Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'valido que el textbox no este vacio
            If Me.TextBox1.Text = "" Then
                MessageBox.Show("Por favor ingresa un valor a buscar", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TextBox1.Clear()
                Me.TextBox1.Focus()
            Else
                'verifico que radio button esta marcado para buscar ya sea por numero o descripcion 
                Try
                    If RadioButton1.Checked = True Then
                        'realizo la busquedad por nombre de paciente 
                        conexion.Open()
                        consulta = "SELECT  recibo, fecha,nombre,  este_pago,color,direccion FROM recibos where nombre like '%" & TextBox1.Text & "%' and id_agencia='" & dashboard.no_agencia & "' and anticipo='x' "
                        adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                        tabla_recibo = New DataTable
                        adaptador.Fill(tabla_recibo)
                        dtv_recibo.DataSource = tabla_recibo
                        conexion.Close()
                        dtv_recibo.Columns(0).HeaderText = "RECIBO"
                        dtv_recibo.Columns(0).Width = 60
                        dtv_recibo.Columns(1).HeaderText = "FECHA"
                        dtv_recibo.Columns(2).HeaderText = "NOMBRE"
                        dtv_recibo.Columns(2).Width = 255
                        dtv_recibo.Columns(3).HeaderText = "VALOR"
                        dtv_recibo.Columns(4).Visible = False
                        dtv_recibo.Columns(5).Visible = False
                        conexion.Close()
                    Else
                        'realizo la busquedad por numero de recibo 
                        conexion.Open()
                        consulta = "SELECT  recibo, fecha,nombre,  este_pago,color,direccion FROM recibos where recibo ='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "' and anticipo='x'  "
                        adaptador = New MySqlDataAdapter(consulta, conexion)
                        tabla_recibo = New DataTable
                        adaptador.Fill(tabla_recibo)
                        dtv_recibo.DataSource = tabla_recibo
                        conexion.Close()
                        dtv_recibo.Columns(0).HeaderText = "RECIBO"
                        dtv_recibo.Columns(0).Width = 60
                        dtv_recibo.Columns(1).HeaderText = "FECHA"
                        dtv_recibo.Columns(2).HeaderText = "NOMBRE"
                        dtv_recibo.Columns(2).Width = 255
                        dtv_recibo.Columns(3).HeaderText = "VALOR"
                        dtv_recibo.Columns(4).Visible = False
                        dtv_recibo.Columns(5).Visible = False
                        conexion.Close()
                    End If
                Catch ex As Exception
                    conexion.Close()
                    MessageBox.Show("No pude cargar el listado de recibos pendientes de operar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub dtv_recibo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_recibo.CellContentClick

    End Sub

    Private Sub dtv_recibo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_recibo.CellDoubleClick
        Dim row As DataGridViewRow = dtv_recibo.CurrentRow
        no_recibo = CStr(row.Cells(0).Value)
        nombre_paciente = CStr(row.Cells(2).Value)
        valor_recibo = CStr(row.Cells(3).Value.ToString)
        cobrar_orden.anticiposapp(conteo) = no_recibo
        cobrar_orden.nit = CStr(row.Cells(4).Value)
        cobrar_orden.nombrepf = CStr(row.Cells(5).Value)
        resultado = Val(total_ordencompra) - Val(valor_recibo)

        ' MessageBox.Show(resultado.ToString)
        'valido que el antipo no sea mayor al valor de la orden 
        If Val(valor_recibo) > Val(total_ordencompra) Then
            MessageBox.Show("No puedes agregar un anticipo que supere el valor del saldo pendiente")
            no_recibo = ""
            nombre_paciente = ""
            valor_recibo = ""
            total_compra = ""
            cobrar_orden.nit = ""
            cobrar_orden.nombrepf = ""
            Return
        Else
            'realizo el abono del anticipo a la orden 
            cobrar_orden.DataGridView1.Rows.Add(no_recibo, nombre_paciente, valor_recibo)
            cobrar_orden.sumar_dtv.PerformClick()
            Me.Dispose()
        End If

    End Sub

    Private Sub dtv_recibo_DoubleClick(sender As Object, e As EventArgs) Handles dtv_recibo.DoubleClick

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

    End Sub
End Class