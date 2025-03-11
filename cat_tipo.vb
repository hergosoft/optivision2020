Imports MySql.Data.MySqlClient
Public Class cat_tipo
    Dim consulta, desactivar, codigo_vendedor, nombre_vendedor, pregunta As String
    Dim adaptador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Dim com As New MySqlCommand
    Dim numero As Integer

    Private Sub cat_tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()

        End If

    End Sub
    Private Sub cat_tipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo al dtv 
        With dtv_general
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
        End With
        'valido de donde llamaron al formulario para cargar los datos
        If dedonde.Text = 1 Then
            nuevo_parametro.Label2.Text = "TIPO"
            Label1.Text = "Administrador de Tipos de Producto"
            'cargo la tabla tipo 
            Try
                consulta = "select * from cattipoi"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                Button4.Visible = False
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible cargar los datos, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
                Return
            End Try
        ElseIf dedonde.Text = 2 Then
            nuevo_parametro.Label2.Text = "MARCA"
            Label1.Text = "Administrador de Marcas"
            'cargo la tabla Marca 
            Try
                consulta = "select id_linea from catmarcasi"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                Button4.Visible = False
                Button1.Focus()
                dtv_general.Columns(0).HeaderText = "DESCRIPCION"
                'dtv_general.Columns(1).HeaderText = "DESCRIPCION"
                ' dtv_general.Columns(0).Width = dtv_general.Columns(0).FillWeight
                dtv_general.Columns(0).Width = 410
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible cargar los datos, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde.Text = 3 Then
            nuevo_parametro.Label2.Text = "LINEA"
            Label1.Text = "Catalogo Lineas de Producto"
            'cargo la tabla linea  
            Try
                consulta = "select * from catlineasi"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                Button4.Visible = False
                dtv_general.Columns(0).HeaderText = "NO."
                dtv_general.Columns(1).HeaderText = "DESCRIPCION"
                dtv_general.Columns(0).Width = 50
                dtv_general.Columns(1).Width = 360
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible cargar los datos, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde.Text = 4 Then
            nuevo_parametro.Label2.Text = "UNIDAD MEDIDA"
            Label1.Text = "Administrador de Unidad Medidas"
            'cargo la tabla unidad Medida
            Try
                consulta = "select * from catmedidasi"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                Button4.Visible = False
                dtv_general.Columns(0).HeaderText = "DESCRIPCION"
                'dtv_general.Columns(1).HeaderText = "DESCRIPCION"
                ' dtv_general.Columns(0).Width = dtv_general.Columns(0).FillWeight
                dtv_general.Columns(0).Width = 410
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("No fue posible cargar los datos, si el problema persiste Contacta con Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde.Text = 5 Then
            nuevo_parametro.Label2.Text = "Vendedor"
            Label1.Text = "Administrador de Vendedores"
            'Administrador de Vendedores 
            Try
                consulta = "SELECT id_codigo,nombre FROM vendedores WHERE status<>'B' "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adaptador.Fill(tabladatos)
                dtv_general.DataSource = tabladatos
                conexion.Close()
                dtv_general.Columns(0).HeaderText = "COD."
                dtv_general.Columns(1).HeaderText = "NOMBRE"
                dtv_general.Columns(0).Width = 50
                dtv_general.Columns(1).Width = 360
            Catch ex As Exception
                MsgBox("No fue posible obtener el catalogo de vendedores," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If



        Button1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub dtv_general_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_general.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles dedonde.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'abro ventana para agregar parametro en modo limitado
        nuevo_parametro.Label1.Text = dedonde.Text
        'averiguo cual es el ultimo registro del dtv
        Dim ultimafila As Integer
        ultimafila = dtv_general.Rows.Count - 1

        nuevo_parametro.correlativo = Val(ultimafila) + 1
        nuevo_parametro.ShowDialog()
        'verifico de donde estoy llamando la ventana para nombrar el groupbox 
        If dedonde.Text = 2 Then
            nuevo_parametro.GroupBox1.Text = "Nuevo"
        End If
    End Sub



    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'defino desde donde estoy llamando a la ventana nuevo parametro para que actualice 
        desactivar = 51
        numero = Val(dedonde.Text) + 10
        If numero = 11 Then
            nuevo_parametro.Label2.Text = "Editar Tipo"
            MsgBox("Por favor de doble clic sobre el TIPO a Editar", MsgBoxStyle.Information, "Editar Tipo")
        ElseIf numero = 12 Then
            nuevo_parametro.Label2.Text = "Editar Marca"
            MsgBox("Por favor de doble clic sobre la Marca a Editar", MsgBoxStyle.Information, "Editar Marca")
        ElseIf numero = 13 Then
            nuevo_parametro.Label2.Text = "Editar Linea"
            MsgBox("Por favor de doble clic sobre la Linea a Editar", MsgBoxStyle.Information, "Editar Linea")
        ElseIf numero = 14 Then
            nuevo_parametro.Label2.Text = "Editar Unidad de Medida"
            MsgBox("Por favor de doble clic sobre la Unidad de Medida a Editar", MsgBoxStyle.Information, "Editar Unidad Medida")
        ElseIf numero = 15 Then
            nuevo_parametro.Label2.Text = "Editar Vendedor"
            MsgBox("Por favor de doble clic sobre el vendedor a Editar", MsgBoxStyle.Information, "Editar Vendedor")
        End If
        nuevo_parametro.GroupBox1.Text = "Actualizar"
        nuevo_parametro.Button1.Text = "Grabar"
    End Sub

    Private Sub dtv_general_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtv_general.CellDoubleClick
        If desactivar = 50 Then
            'muestro mensaje para desactivar al vendedor 
            Dim row As DataGridViewRow = dtv_general.CurrentRow
            codigo_vendedor = CStr(row.Cells(0).Value)
            nombre_vendedor = CStr(row.Cells(1).Value)
            'pregunto antes de anular 
            pregunta = MsgBox("Se desactivara al vendedor " & nombre_vendedor & "  tenga en cuenta que al desactivarlo ya no podra seguir facturando" & "  ¿Desea Continuar?", vbYesNo + vbInformation + vbDefaultButton2, "Desactiva Vendedor")
            If pregunta = vbYes Then
                'desactivo vendedor
                Try
                    conexion.Open()
                    consulta = "UPDATE vendedores set status='B' where id_codigo='" & codigo_vendedor & "'"
                    com = New MySqlCommand(consulta, conexion)
                    com.ExecuteNonQuery()
                    MessageBox.Show("Vendedor desactivado con exito")
                    conexion.Close()
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No fue posible desactivar el vendedor," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            Else
                Return
            End If

        ElseIf desactivar = 51 Then
            nuevo_parametro.Label1.Text = numero.ToString
            Dim row As DataGridViewRow = dtv_general.CurrentRow
            nuevo_parametro.correlativo = CStr(row.Cells(0).Value)
            If numero = 12 Then
            Else
                nuevo_parametro.TextBox1.Text = CStr(row.Cells(1).Value)
            End If

            nuevo_parametro.ShowDialog()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.Enabled = False
        Button2.Enabled = False
        nuevo_parametro.Label2.Text = "Vendedor"
        desactivar = 50
        MsgBox("Por favor de doble clic sobre el vendedor a desactivar", MsgBoxStyle.Information, "Desactivar Vendedor")
        

    End Sub
End Class