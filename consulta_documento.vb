Imports MySql.Data.MySqlClient
Public Class consulta_documento
    Dim consulta As String
    Dim rs As MySqlDataReader
    Dim com As New MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim Tabladatos As DataTable
    Public dedonde As String


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub consulta_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.Font = New Font("time new roman", 10)
        End With
        'cargo los primeros 10 registros para mostrar dependiendo de donde llame a la ventana 
        If dedonde = 1 Then
            'llamada desde consulta factura directa
            Try
                conexion.Open()
                consulta = "select no_factura,serie, status, fecha,telefono,cliente,nit,Format(total,2),obs from facturas where id_agencia='" & dashboard.no_agencia & "'  order by fecha desc limit 30"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "FACTURA"
                DataGridView1.Columns(0).Width = 110
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 110
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).HeaderText = "FECHA"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).HeaderText = "CLIENTE"
                DataGridView1.Columns(5).Width = 350
                DataGridView1.Columns(6).HeaderText = "NIT"
                DataGridView1.Columns(6).Width = 105
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "TOTAL"
                DataGridView1.Columns(7).Width = 105
                DataGridView1.Columns(8).HeaderText = "OBS"
                DataGridView1.Columns(8).Width = 350

                'realizo recorrido de dtv para cambiar color si la factura esta anulada 
                For Each fila As DataGridViewRow In DataGridView1.Rows
                    If fila.Cells(2).Value = "A" Then
                        fila.DefaultCellStyle.ForeColor = Color.Red
                    Else
                        fila.DefaultCellStyle.ForeColor = Color.Blue
                    End If
                Next

            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de facturas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 2 Then
            'ordenes de trabajo 
            Try
                conexiongoptics.Open()
                consulta = "SELECT no_orden,serie,fecha,nombre,telefono,aro,saldo,abono,format(total,2) FROM orden where id_agencia='" & dashboard.no_agencia & "' order by no_orden desc limit 30"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexiongoptics.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN LAB."
                DataGridView1.Columns(0).Width = 60

                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "PACIENTE"
                DataGridView1.Columns(3).Width = 300
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 85
                DataGridView1.Columns(5).HeaderText = "ARO"
                DataGridView1.Columns(5).Width = 200
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(6).HeaderText = "SALDO"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "ABONO"
                DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(8).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(8).HeaderText = "TOTAL"
                DataGridView1.Columns(1).Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Ordenes de Laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexiongoptics.Close()
                Return
            End Try
        ElseIf dedonde = 3 Then
            ' consulta recibos 
            Try
                conexiongoptics.Open()
                consulta = "SELECT recibo,serierec,fecha,nombre,format(valor,2),estado FROM recibos WHERE id_agencia='" & dashboard.no_agencia & "'   order by recibo desc limit 100"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexiongoptics.Close()
                'For Each fila As DataGridViewRow In DataGridView1.Rows
                '    If fila.Cells(5).Value = "A" Then

                '        fila.DefaultCellStyle.ForeColor = Color.Red
                '    Else
                '        fila.DefaultCellStyle.ForeColor = Color.Blue
                '    End If
                'Next

                DataGridView1.Columns(0).HeaderText = "RECIBO"
                DataGridView1.Columns(0).Width = 79
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 100
                DataGridView1.Columns(3).HeaderText = "NOMBRE"
                DataGridView1.Columns(3).Width = 500
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(4).HeaderText = "TOTAL"
                DataGridView1.Columns(4).Width = 100
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de recibos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try

            'realizo recorrido de dtv para cambiar color si la orden tiene saldo o no tiene 
            'DataGridView1.Columns(4).DefaultCellStyle.Format = "###,##0.00"

        ElseIf dedonde = 4 Then
            'anulacion de Facturas 
            Try
                conexion.Open()
                consulta = "select no_factura,serie, status, fecha,telefono,cliente,nit,Format(total,2),obs from facturas where status<>'A' and id_agencia='" & dashboard.no_agencia & "'  order by fecha desc limit 50"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "FACTURA"
                DataGridView1.Columns(0).Width = 110
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 110
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).HeaderText = "FECHA"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).HeaderText = "CLIENTE"
                DataGridView1.Columns(5).Width = 350
                DataGridView1.Columns(6).HeaderText = "NIT"
                DataGridView1.Columns(6).Width = 105
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).HeaderText = "TOTAL"
                DataGridView1.Columns(7).Width = 105
                DataGridView1.Columns(8).HeaderText = "OBS"
                DataGridView1.Columns(8).Width = 350


            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de facturas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
       vbCrLf & vbCrLf & ex.Message,
       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 5 Then
            'Anulacion de ordenes de trabajo 
            Try
                conexion.Open()
                consulta = "SELECT no_orden,serie,fecha,nombre,telefono,aro,saldo,abono,total FROM orden where status<>'A' and id_agencia='" & dashboard.no_agencia & "' order by no_orden desc limit 30"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN LAB."
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 45
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "PACIENTE"
                DataGridView1.Columns(3).Width = 300
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 85
                DataGridView1.Columns(5).HeaderText = "ARO"
                DataGridView1.Columns(5).Width = 200
                DataGridView1.Columns(6).HeaderText = "SALDO"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(7).HeaderText = "ABONO"
                DataGridView1.Columns(8).HeaderText = "TOTAL"
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Ordenes de Laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
        vbCrLf & vbCrLf & ex.Message,
        MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 6 Then
            ' ANULACION DE RECIBOS
            Try
                conexiongoptics.Open()
                consulta = "select recibo,serierec,fecha,nombre,Format(valor, 2) from recibos  where estado='I' and id_agencia='" & dashboard.no_agencia & "' order by recibo desc limit 100"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexiongoptics.Close()
                DataGridView1.Columns(0).HeaderText = "RECIBO"
                DataGridView1.Columns(0).Width = 79
                DataGridView1.Columns(1).HeaderText = "SERIE"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 100
                DataGridView1.Columns(3).HeaderText = "NOMBRE"
                DataGridView1.Columns(3).Width = 500
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '  DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(4).HeaderText = "TOTAL"
                DataGridView1.Columns(4).Width = 100
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Recibos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexiongoptics.Close()
                Return
            End Try

        ElseIf dedonde = 8 Then
            'RE IMPRIME HISTORIA CLINCIA
            radionumero.Enabled = False
            radionombre.Checked = True

            'busco por nombre las historias clinicas 
            Try
                conexiongoptics.Open()
                consulta = "Select no_clinica,fecha,paciente,telefono,email from clinica where id_agencia='" & dashboard.no_agencia & "'  order by fecha desc limit 100"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexiongoptics.Close()
                DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(0).Width = 80
                DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                DataGridView1.Columns(1).Width = 90
                DataGridView1.Columns(2).HeaderText = "PACIENTE"
                DataGridView1.Columns(2).Width = 300
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).HeaderText = "EMAIL"
                DataGridView1.Columns(4).Width = 319
                '      DataGridView1.Columns(5).HeaderText = "EDAD"
                '      DataGridView1.Columns(5).Width = 70
                '      DataGridView1.Columns(6).HeaderText = "TIENDA EXAMINA"
                '      DataGridView1.Columns(6).Width = 200

            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
   vbCrLf & vbCrLf & ex.Message,
   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexiongoptics.Close()
                Return
            End Try
        ElseIf dedonde = 9 Then
            'realizo la busquedada de historias clinicas PARA MODIFICAR
            radionumero.Enabled = False
            radionombre.Checked = True
            'realizo busquedad de historias clinicas
            Try
                conexiongoptics.Open()
                consulta = "Select no_clinica,fecha,paciente,telefono,email from clinica where paciente like '%" & TextBox1.Text & "%'  order by fecha desc limit 100"
                adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexiongoptics.Close()
                DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(2).HeaderText = "PACIENTE"
                DataGridView1.Columns(0).Width = 350
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(4).HeaderText = "EMAIL"
                DataGridView1.Columns(0).Width = 100
                '      DataGridView1.Columns(5).HeaderText = "EDAD"
                '      DataGridView1.Columns(5).Width = 70
                '      DataGridView1.Columns(6).HeaderText = "TIENDA EXAMINA"
                '      DataGridView1.Columns(6).Width = 200
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
   vbCrLf & vbCrLf & ex.Message,
   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexiongoptics.Close()
                Return
            End Try
        ElseIf dedonde = 10 Then
            'abro desde consulta de clientes 
            Try
                conexion.Open()
                consulta = "SELECT id_cliente,dpi,nombre,telefono,ultima_compr FROM clientes where status='A' "
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).HeaderText = "DPI"
                DataGridView1.Columns(1).Width = 150
                DataGridView1.Columns(2).HeaderText = "NOMBRE"
                DataGridView1.Columns(2).Width = 515
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).HeaderText = "ULTIMO CHEK"
                DataGridView1.Columns(4).Width = 100
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show(ex.ToString)
            End Try
        ElseIf dedonde = 11 Then
            radionombre.Checked = True
            radionumero.Enabled = False
            'CONSULTA HISTORIA CLINICA 
            Try
                conexion.Open()
                consulta = "select h.no_clinica,h.fecha,h.paciente,h.telefono,t.nombre from clinica as h inner join catagencias as t on h.id_agencia=t.id_agencia where h.id_agencia='" & dashboard.no_agencia & "' order by h.no_clinica desc limit 100"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(0).Width = 80
                DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                DataGridView1.Columns(1).Width = 90
                DataGridView1.Columns(2).HeaderText = "PACIENTE"
                DataGridView1.Columns(2).Width = 345
                DataGridView1.Columns(3).HeaderText = "TELEFONO"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).HeaderText = "TIENDA EXAMINA"
                DataGridView1.Columns(4).Width = 285
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
   vbCrLf & vbCrLf & ex.Message,
   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 12 Then
            'consulta ordenes con saldo para aplicar abono
            'Anulacion de ordenes de trabajo 
            Try
                conexion.Open()
                consulta = "SELECT o.no_orden,o.serie,o.fecha,o.nombre,o.telefono,o.aro,o.saldo,o.abono,o.total,o.marca_aro,o.id_vendedor,r.vendedor,r.color,r.direccion FROM orden as o left join recibos as r on r.orden=o.no_orden  and o.id_agencia=r.id_agencia where o.status<>'A' and o.saldo<>'0' and o.saldo<>'0.00' and o.id_agencia='" & dashboard.no_agencia & "'  group by o.no_orden desc limit 50"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "ORDEN LAB."
                DataGridView1.Columns(0).Width = 60
                DataGridView1.Columns(2).HeaderText = "FECHA"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "PACIENTE"
                DataGridView1.Columns(3).Width = 298
                DataGridView1.Columns(4).HeaderText = "TELEFONO"
                DataGridView1.Columns(4).Width = 85
                DataGridView1.Columns(5).HeaderText = "ARO"
                DataGridView1.Columns(5).Width = 200
                DataGridView1.Columns(6).HeaderText = "SALDO"
                DataGridView1.Columns(6).Width = 90
                DataGridView1.Columns(7).HeaderText = "ABONO"
                DataGridView1.Columns(7).Width = 90
                DataGridView1.Columns(8).HeaderText = "TOTAL"
                DataGridView1.Columns(8).Width = 90
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                DataGridView1.Columns(8).DefaultCellStyle.Format = "N2"
                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False
                DataGridView1.Columns(12).Visible = False
                DataGridView1.Columns(13).Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de Ordenes de Laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 13 Or dedonde = 15 Then

            'Consulta documentos ingreso por ajuste 
            Try
                'consulta = "select k.fecha,k.docto,k.serie,c.nombre, k.hechopor,k.id_movi,k.obsservi from kardexinven as k left join catkardex as c on c.id_movi=k.id_movi where k.id_agencia='" & dashboard.no_agencia & "'  and k.id_movi='1' or k.id_movi='2' or k.id_movi='5' group  by k.docto order by fecha desc"

                consulta = "select a.nombre,k.fecha,k.docto,k.serie,c.nombre, k.hechopor,k.id_movi,k.obsservi from kardexinven as k left join catkardex as c on c.id_movi=k.id_movi left join catagencias as a on a.id_agencia=k.id_agencia where
                            k.id_movi='1' or k.id_movi='2' or k.id_movi='5' group by k.docto,k.serie order by fecha desc"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "AGENCIA"
                DataGridView1.Columns(0).Width = 200
                DataGridView1.Columns(1).HeaderText = "FECHA"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "SERIE"
                DataGridView1.Columns(3).Width = 90
                DataGridView1.Columns(4).HeaderText = "TIPO"
                DataGridView1.Columns(4).Width = 250
                DataGridView1.Columns(5).HeaderText = "HECHO POR"
                DataGridView1.Columns(5).Width = 150
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).Visible = False
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de documentos operados," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            radionumero.Text = "NUMERO DOCUMENTO"
            radionombre.Visible = False
            RadioTelefono.Visible = False
            todas_tiendas.Visible = False

        ElseIf dedonde = 14 Or dedonde = 16 Then

            'Consulta documentos salida por ajuste 
            Try
                'consulta = "select k.fecha,k.docto,k.serie,c.nombre, k.hechopor,k.id_movi,k.obsservi from kardexinven as k left join catkardex as c on c.id_movi=k.id_movi where k.id_agencia='" & dashboard.no_agencia & "'  and k.id_movi='53' or k.id_movi='54' group  by k.docto,k.serie order by k.fecha desc"
                consulta = "select a.nombre,k.fecha,k.docto,k.serie,c.nombre, k.hechopor,k.id_movi,k.obsservi from kardexinven as k left join catkardex as c on c.id_movi=k.id_movi left join catagencias as a on a.id_agencia=k.id_agencia where
                            k.id_movi='53' or k.id_movi='54' group by k.docto,k.serie order by fecha desc"
                adaptador = New MySqlDataAdapter(consulta, conexion)
                Tabladatos = New DataTable
                adaptador.Fill(Tabladatos)
                DataGridView1.DataSource = Tabladatos
                conexion.Close()
                DataGridView1.Columns(0).HeaderText = "AGENCIA"
                DataGridView1.Columns(0).Width = 200
                DataGridView1.Columns(1).HeaderText = "FECHA"
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(2).Width = 90
                DataGridView1.Columns(3).HeaderText = "SERIE"
                DataGridView1.Columns(3).Width = 90
                DataGridView1.Columns(4).HeaderText = "TIPO"
                DataGridView1.Columns(4).Width = 250
                DataGridView1.Columns(5).HeaderText = "HECHO POR"
                DataGridView1.Columns(5).Width = 150
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).Visible = False
                conexion.Close()
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de documentos operados," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
               vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
            radionumero.Text = "NUMERO DOCUMENTO"
            radionombre.Visible = False
            RadioTelefono.Visible = False
            todas_tiendas.Visible = False

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If radionumero.Checked = True Then
            'busco por numero de documentos 
            If dedonde = 1 Or dedonde = 4 Then
                'realizo busquedad de factura
                Try
                    conexiongoptics.Open()
                    consulta = "select no_factura,serie, status, fecha,telefono,cliente,nit,Format(total,2),obs from facturas where  no_factura='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "'  order by no_factura desc "
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "FACTURA"
                    DataGridView1.Columns(0).Width = 65
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 40
                    DataGridView1.Columns(2).HeaderText = "ESTADO"
                    DataGridView1.Columns(2).Width = 54
                    DataGridView1.Columns(3).HeaderText = "FECHA"
                    DataGridView1.Columns(3).Width = 85
                    DataGridView1.Columns(4).HeaderText = "TELEFONO"
                    DataGridView1.Columns(4).Width = 88
                    DataGridView1.Columns(5).HeaderText = "CLIENTE"
                    DataGridView1.Columns(5).Width = 330
                    DataGridView1.Columns(6).HeaderText = "NIT"
                    DataGridView1.Columns(6).Width = 80
                    DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                    DataGridView1.Columns(7).HeaderText = "TOTAL"
                    DataGridView1.Columns(7).Width = 80
                    DataGridView1.Columns(8).HeaderText = "OBS"
                    DataGridView1.Columns(8).Width = 350
                Catch ex As Exception
                    MsgBox("No fue posible realizar la busquedad de Facturas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            ElseIf dedonde = 2 Or dedonde = 5 Then
                'realizo la busquedad de orden de trabajo 
                Try
                    conexiongoptics.Open()
                    consulta = "SELECT no_orden,serie,fecha,nombre,telefono,aro,saldo,abono,Format(total,2) FROM orden where no_orden='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "' order by no_orden desc limit 30"
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "ORDEN LAB."
                    DataGridView1.Columns(0).Width = 60
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 45
                    DataGridView1.Columns(2).HeaderText = "FECHA"
                    DataGridView1.Columns(2).Width = 90
                    DataGridView1.Columns(3).HeaderText = "PACIENTE"
                    DataGridView1.Columns(3).Width = 300
                    DataGridView1.Columns(4).HeaderText = "TELEFONO"
                    DataGridView1.Columns(4).Width = 85
                    DataGridView1.Columns(5).HeaderText = "ARO"
                    DataGridView1.Columns(5).Width = 200
                    DataGridView1.Columns(6).HeaderText = "SALDO"
                    DataGridView1.Columns(6).Width = 80
                    DataGridView1.Columns(7).HeaderText = "ABONO"
                    DataGridView1.Columns(8).HeaderText = "TOTAL"
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de Ordenes de Laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            ElseIf dedonde = 3 Or dedonde = 6 Then
                ' consulta recibos 
                Try
                    conexiongoptics.Open()
                    consulta = "select recibo, serierec, fecha, nombre, Format(valor,2) from recibos where recibo='" & TextBox1.Text & "' and id_agencia='" & dashboard.no_agencia & "'order by recibo desc limit 50  "
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "RECIBO"
                    DataGridView1.Columns(0).Width = 79
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 100
                    DataGridView1.Columns(2).HeaderText = "FECHA"
                    DataGridView1.Columns(2).Width = 100
                    DataGridView1.Columns(3).HeaderText = "NOMBRE"
                    DataGridView1.Columns(3).Width = 500
                    DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"
                    DataGridView1.Columns(4).HeaderText = "TOTAL"
                    DataGridView1.Columns(4).Width = 100
                Catch ex As Exception
                    MsgBox("No fue posible realizar la busquedad de Recibos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
              vbCrLf & vbCrLf & ex.Message,
              MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            ElseIf dedonde = 10 Then
                'busco clientes por numero de DPI
                Try
                    conexion.Open()
                    consulta = "SELECT id_cliente,nombre,telefono,ultima_compr,dpi FROM clientes WHERE dpi like '" & TextBox1.Text & "%%' AND status='A'"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexion.Close()
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(1).HeaderText = "NOMBRE"
                    DataGridView1.Columns(1).Width = 565
                    DataGridView1.Columns(2).HeaderText = "TELEFONO"
                    DataGridView1.Columns(2).Width = 100
                    DataGridView1.Columns(3).HeaderText = "ULTIMA COMPRA"
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).HeaderText = "DPI"
                    DataGridView1.Columns(4).Width = 100
                Catch ex As Exception
                    conexion.Close()
                    MessageBox.Show(ex.ToString)
                End Try
            ElseIf dedonde = 13 Then
                'busco por numero de documento movimientos de kardex  por ingreso 

                Try
                    consulta = "select k.fecha,k.docto,k.serie,c.nombre, k.hechopor,k.id_movi from kardexinven as k left join catkardex as c on c.id_movi=k.id_movi where k.id_agencia='" & dashboard.no_agencia & "'  and k.docto='" & TextBox1.Text & "'  group by k.docto having k.id_movi='1' or k.id_movi='2' or k.id_movi='5';"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexion.Close()
                    DataGridView1.Columns(0).HeaderText = "FECHA"
                    DataGridView1.Columns(0).Width = 140
                    DataGridView1.Columns(1).HeaderText = "DOCUMENTO"
                    DataGridView1.Columns(1).Width = 120
                    DataGridView1.Columns(2).HeaderText = "SERIE"
                    DataGridView1.Columns(2).Width = 120
                    DataGridView1.Columns(3).HeaderText = "TIPO"
                    DataGridView1.Columns(3).Width = 250
                    DataGridView1.Columns(4).HeaderText = "HECHO POR"
                    DataGridView1.Columns(4).Width = 250
                    conexion.Close()
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de documentos operados," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try

            End If





        ElseIf radionombre.Checked = True Then
            'busco por nombre de cliente 
            If dedonde = 1 Or dedonde = 4 Then
                'realizo busquedad de factura
                Try
                    conexion.Open()
                    consulta = "select no_factura,serie, status, fecha,telefono,cliente,nit,Format(total,2),obs from facturas where cliente like '%%" & TextBox1.Text & "%%' and id_agencia='" & dashboard.no_agencia & "'  order by fecha desc "
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexion.Close()
                    DataGridView1.Columns(0).HeaderText = "FACTURA"
                    DataGridView1.Columns(0).Width = 110
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 110
                    DataGridView1.Columns(2).Visible = False
                    DataGridView1.Columns(3).HeaderText = "FECHA"
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).HeaderText = "CLIENTE"
                    DataGridView1.Columns(5).Width = 350
                    DataGridView1.Columns(6).HeaderText = "NIT"
                    DataGridView1.Columns(6).Width = 105
                    DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"
                    DataGridView1.Columns(7).HeaderText = "TOTAL"
                    DataGridView1.Columns(7).Width = 105
                    DataGridView1.Columns(8).HeaderText = "OBS"
                    DataGridView1.Columns(8).Width = 350
                Catch ex As Exception
                    MsgBox("No fue posible realizar la busquedad de Facturas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try

            ElseIf dedonde = 2 Or dedonde = 5 Then
                'realizo la busquedad de orden de trabajo 

                Try
                    conexiongoptics.Open()
                    consulta = "SELECT no_orden,serie,fecha,nombre,telefono,aro,saldo,abono,Format(total,2) FROM orden where nombre like '%%" & TextBox1.Text & "%%' and  id_agencia='" & dashboard.no_agencia & "' order by no_orden desc limit 30"
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "ORDEN LAB."
                    DataGridView1.Columns(0).Width = 60
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 45
                    DataGridView1.Columns(2).HeaderText = "FECHA"
                    DataGridView1.Columns(2).Width = 90
                    DataGridView1.Columns(3).HeaderText = "PACIENTE"
                    DataGridView1.Columns(3).Width = 300
                    DataGridView1.Columns(4).HeaderText = "TELEFONO"
                    DataGridView1.Columns(4).Width = 85
                    DataGridView1.Columns(5).HeaderText = "ARO"
                    DataGridView1.Columns(5).Width = 200
                    DataGridView1.Columns(6).HeaderText = "SALDO"
                    DataGridView1.Columns(6).Width = 80
                    DataGridView1.Columns(7).HeaderText = "ABONO"
                    DataGridView1.Columns(8).HeaderText = "TOTAL"
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de Ordenes de Laboratorio," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                    vbCrLf & vbCrLf & ex.Message,
                    MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            ElseIf dedonde = 3 Or dedonde = 6 Then
                ' consulta recibos 
                Try
                    conexion.Open()
                    consulta = "select recibo, serierec, fecha, nombre, Format(valor,2) from recibos where nombre like '%%" & TextBox1.Text & "%%' and id_agencia='" & dashboard.no_agencia & "'order by fecha desc  "
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexion.Close()
                    DataGridView1.Columns(0).HeaderText = "RECIBO"
                    DataGridView1.Columns(0).Width = 79
                    DataGridView1.Columns(1).HeaderText = "SERIE"
                    DataGridView1.Columns(1).Width = 100
                    DataGridView1.Columns(2).HeaderText = "FECHA"
                    DataGridView1.Columns(2).Width = 100
                    DataGridView1.Columns(3).HeaderText = "NOMBRE"
                    DataGridView1.Columns(3).Width = 500
                    DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"
                    DataGridView1.Columns(4).HeaderText = "TOTAL"
                    DataGridView1.Columns(4).Width = 100
                Catch ex As Exception
                    MsgBox("No fue posible realizar la busquedad de Recibos," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexion.Close()
                    Return
                End Try
            ElseIf dedonde = 8 Then
                'buso por nombre para re imprimir la historia clinica 
                Try
                    conexiongoptics.Open()
                    consulta = "Select no_clinica,fecha,paciente,telefono,email from clinica where paciente like '%" & TextBox1.Text & "%' and  id_agencia='" & dashboard.no_agencia & "' and estado='I' order by fecha desc limit 100"
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                    DataGridView1.Columns(0).Width = 80
                    DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                    DataGridView1.Columns(1).Width = 90
                    DataGridView1.Columns(2).HeaderText = "PACIENTE"
                    DataGridView1.Columns(2).Width = 300
                    DataGridView1.Columns(3).HeaderText = "TELEFONO"
                    DataGridView1.Columns(3).Width = 80
                    DataGridView1.Columns(4).HeaderText = "EMAIL"
                    DataGridView1.Columns(4).Width = 319
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try


            ElseIf dedonde = 10 Then
                'busco clientes por numero de DPI
                Try
                    conexion.Open()
                    consulta = "SELECT id_cliente,nombre,telefono,ultima_compr,dpi FROM clientes WHERE nombre like '%" & TextBox1.Text & "%' AND status='A'"
                    adaptador = New MySqlDataAdapter(consulta, conexion)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexion.Close()
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(1).HeaderText = "NOMBRE"
                    DataGridView1.Columns(1).Width = 565
                    DataGridView1.Columns(2).HeaderText = "TELEFONO"
                    DataGridView1.Columns(2).Width = 100
                    DataGridView1.Columns(3).HeaderText = "ULTIMA COMPRA"
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).HeaderText = "DPI"
                    DataGridView1.Columns(4).Width = 100
                Catch ex As Exception
                    conexion.Close()
                    MessageBox.Show(ex.ToString)
                End Try

            End If
        End If
        If dedonde = 11 Then
            If todas_tiendas.Checked = True Then
                'busco la historia clinica en todas las tiendas por nombre de paciente 
                'busco por nombre la historia clinica 
                Try
                    conexiongoptics.Open()
                    If radionombre.Checked = True Then
                        'busco por nombre de cliente 
                        consulta = "Select h.no_clinica,h.fecha,h.paciente,h.telefono,t.nombre from clinica as h inner join catagencias as t on h.id_agencia=t.id_agencia where h.paciente like '%" & TextBox1.Text & "%' order by fecha desc limit 100"

                    Else
                        'busco por numero de telefono 
                        consulta = "Select h.no_clinica,h.fecha,h.paciente,h.telefono,t.nombre from clinica as h inner join catagencias as t on h.id_agencia=t.id_agencia where h.telefono like '%" & TextBox1.Text & "%' order by fecha desc limit 100"
                    End If
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                    DataGridView1.Columns(0).Width = 80
                    DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                    DataGridView1.Columns(1).Width = 90
                    DataGridView1.Columns(2).HeaderText = "PACIENTE"
                    DataGridView1.Columns(2).Width = 345
                    DataGridView1.Columns(3).HeaderText = "TELEFONO"
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).HeaderText = "TIENDA EXAMINA"
                    DataGridView1.Columns(4).Width = 285
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            ElseIf todas_tiendas.Checked = False Then
                'busco por nombre la historia clinica  pero solo en la tienda seleccionada 
                Try
                    conexiongoptics.Open()
                    If radionombre.Checked = True Then
                        'busco por nombre de cliente 
                        consulta = "Select h.no_clinica,h.fecha,h.paciente,h.telefono,t.nombre from clinica as h inner join catagencias as t on h.id_agencia=t.id_agencia where h.paciente like '%" & TextBox1.Text & "%'  and h.id_agencia='" & dashboard.no_agencia & "' order by fecha desc limit 100"
                    Else
                        'busco por numero de telefono 
                        consulta = "Select h.no_clinica,h.fecha,h.paciente,h.telefono,t.nombre from clinica as h inner join catagencias as t on h.id_agencia=t.id_agencia where h.telefono like '%" & TextBox1.Text & "%'  and h.id_agencia='" & dashboard.no_agencia & "' order by fecha desc limit 100"
                    End If
                    adaptador = New MySqlDataAdapter(consulta, conexiongoptics)
                    Tabladatos = New DataTable
                    adaptador.Fill(Tabladatos)
                    DataGridView1.DataSource = Tabladatos
                    conexiongoptics.Close()
                    DataGridView1.Columns(0).HeaderText = "DOCUMENTO"
                    DataGridView1.Columns(0).Width = 80
                    DataGridView1.Columns(1).HeaderText = "FECHA EXAMEN"
                    DataGridView1.Columns(1).Width = 90
                    DataGridView1.Columns(2).HeaderText = "PACIENTE"
                    DataGridView1.Columns(2).Width = 345
                    DataGridView1.Columns(3).HeaderText = "TELEFONO"
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).HeaderText = "TIENDA EXAMINA"
                    DataGridView1.Columns(4).Width = 285
                Catch ex As Exception
                    MsgBox("No fue posible obtener el listado de Historias Clinicas," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
           MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    conexiongoptics.Close()
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub DataGridView1_CausesValidationChanged(sender As Object, e As EventArgs) Handles DataGridView1.CausesValidationChanged

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        'valido desde donde estoy llamando el doble clic
        If dedonde = 1 Then
            'consulta Factura directa
            facturacion_directa.dedonde = 4
            facturacion_directa.MdiParent = dashboard
            facturacion_directa.Label9.Visible = True
            facturacion_directa.Label9.Text = "Consulta Factura"
            facturacion_directa.correlativo = CStr(row.Cells(0).Value)
            facturacion_directa.serie = CStr(row.Cells(1).Value)
            If CStr(row.Cells(2).Value) = "A" Then
                facturacion_directa.Label9.Text = "FACTURA ANULADA"
                facturacion_directa.Label9.ForeColor = Color.Red
            End If
            facturacion_directa.Button8.Visible = True
            facturacion_directa.anular.Visible = False
            facturacion_directa.Button4.Enabled = False
            facturacion_directa.Show()

        ElseIf dedonde = 2 Then
            'consulta orden de TRABAJO 
            receta.dedonde = 2
            receta.correlativo.Text = CStr(row.Cells(0).Value)
            receta.serie = CStr(row.Cells(1).Value)
            receta.fecha.Text = CStr(row.Cells(2).Value)
            receta.nombre.Text = CStr(row.Cells(3).Value)
            receta.telefono.Text = CStr(row.Cells(4).Value)
            receta.aro.Text = CStr(row.Cells(5).Value)
            receta.txt_vendedor.ReadOnly = True
            receta.obs.ReadOnly = True
            receta.aro.ReadOnly = True
            receta.nombre.ReadOnly = True
            receta.telefono.ReadOnly = True
            receta.dp.ReadOnly = True
            receta.altura.ReadOnly = True
            receta.odadd.ReadOnly = True
            receta.oieje.ReadOnly = True
            receta.oiesfera.ReadOnly = True
            receta.oicilindro.ReadOnly = True
            receta.odcilindro.ReadOnly = True
            receta.odeje.ReadOnly = True
            receta.odesfera.ReadOnly = True
            receta.btn_agg.Visible = False
            receta.Button3.Visible = False
            receta.Button2.Visible = False
            receta.MdiParent = dashboard
            receta.Show()
        ElseIf dedonde = 3 Then
            'consulta recibos de pago 
            recibos_nuevo.dedonde = 3
            recibos_nuevo.documento = CStr(row.Cells(0).Value)
            recibos_nuevo.serie = CStr(row.Cells(1).Value)
            recibos_nuevo.Label8.Text = "//Consulta de Recibo"
            recibos_nuevo.Button1.Visible = False
            recibos_nuevo.MdiParent = dashboard
            recibos_nuevo.Show()
        ElseIf dedonde = 4 Then
            'anulacion factura directa 
            facturacion_directa.dedonde = 4
            facturacion_directa.MdiParent = dashboard
            facturacion_directa.Label9.ForeColor = Color.Red
            facturacion_directa.Label9.Visible = True
            facturacion_directa.Label9.Text = "Anulacion de Factura"
            facturacion_directa.correlativo = CStr(row.Cells(0).Value)
            facturacion_directa.serie = CStr(row.Cells(1).Value)
            facturacion_directa.Button4.Enabled = False
            facturacion_directa.Show()
            facturacion_directa.anular.Visible = True
        ElseIf dedonde = 5 Then
            'anulacion orden de trabajo 
            receta.dedonde = 3
            receta.correlativo.Text = CStr(row.Cells(0).Value)
            receta.serie = CStr(row.Cells(1).Value)
            receta.fecha.Text = CStr(row.Cells(2).Value)
            receta.nombre.Text = CStr(row.Cells(3).Value)
            receta.telefono.Text = CStr(row.Cells(4).Value)
            receta.aro.Text = CStr(row.Cells(5).Value)
            receta.txt_vendedor.ReadOnly = True
            receta.obs.ReadOnly = True
            receta.aro.ReadOnly = True
            receta.nombre.ReadOnly = True
            receta.telefono.ReadOnly = True
            receta.dp.ReadOnly = True
            receta.altura.ReadOnly = True
            receta.odadd.ReadOnly = True
            receta.oieje.ReadOnly = True
            receta.oiesfera.ReadOnly = True
            receta.oicilindro.ReadOnly = True
            receta.odcilindro.ReadOnly = True
            receta.odeje.ReadOnly = True
            receta.odesfera.ReadOnly = True
            receta.btn_agg.Visible = False
            receta.Button3.Visible = False
            receta.Button2.Visible = False
            receta.Button5.Visible = False
            receta.Button4.Visible = True
            receta.MdiParent = dashboard
            receta.Show()
        ElseIf dedonde = 6 Then
            'anulacion de recibo de pago
            recibos_nuevo.dedonde = 2
            recibos_nuevo.documento = CStr(row.Cells(0).Value)
            recibos_nuevo.serie = CStr(row.Cells(1).Value)
            recibos_nuevo.Label8.Text = "Anulacion de Recibo"
            recibos_nuevo.Label8.ForeColor = Color.Red
            recibos_nuevo.Button1.Text = "Anular"
            recibos_nuevo.MdiParent = dashboard
            recibos_nuevo.Show()

        ElseIf dedonde = 8 Then
            'consulto historia clinica
            'Realizo re impresion al momento de darle doble clic a la orden 
            Dim row1 As DataGridViewRow = DataGridView1.CurrentRow
            '  HistoriaClinica_nueva.correlativo.Text = CStr(row1.Cells(0).Value)
            Try
                conexiongoptics.Open()
                consulta = "UPDATE clinica SET estado='P' where no_clinica='" & CStr(row1.Cells(0).Value) & "';"
                com = New MySqlCommand(consulta, conexiongoptics)
                com.ExecuteNonQuery()
                MessageBox.Show("La re impresion saldra en breve")
                conexiongoptics.Close()
                Me.Close()
            Catch ex As Exception
                conexiongoptics.Close()
                MsgBox("No fue posible lanzar el comando de reimpresion, favor intentalo de nuevo si el error persiste contacta a soporte tecnico." &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Return
            End Try
            ' HistoriaClinica_nueva.titulo.Text = "//CONSULTA HISTORIA CLINICA"
            ' HistoriaClinica_nueva.dedonde = 2
            ' HistoriaClinica_nueva.Show()
        ElseIf dedonde = 9 Then
            'consulto historia clinica para modificacion 
            Dim row1 As DataGridViewRow = DataGridView1.CurrentRow
            HistoriaClinica_nueva.correlativo.Text = CStr(row1.Cells(0).Value)
            HistoriaClinica_nueva.titulo.Text = "// MOFICA HISTORIA CLINICA"
            HistoriaClinica_nueva.titulo.ForeColor = Color.Red
            HistoriaClinica_nueva.dedonde = 3
            HistoriaClinica_nueva.Show()
        ElseIf dedonde = 10 Then
            'exporto datos a mantenimiento de expedientes 
            'abro historial de cliente
            mantenimiento_expedientes.dedonde = 2
            mantenimiento_expedientes.no_cliente = CStr(row.Cells(0).Value)
            mantenimiento_expedientes.funcion.PerformClick()
            Me.Dispose()
        ElseIf dedonde = 11 Then
            'consulto historia clinica
            Dim row1 As DataGridViewRow = DataGridView1.CurrentRow
            HistoriaClinica_nueva.correlativo.Text = CStr(row1.Cells(0).Value)
            HistoriaClinica_nueva.tienda_examina = CStr(row1.Cells(0).Value)
            HistoriaClinica_nueva.titulo.Text = "// CONSULTA HISTORIA CLINICA"
            HistoriaClinica_nueva.dedonde = 2
            HistoriaClinica_nueva.sucursal.Text = CStr(row1.Cells(4).Value)
            HistoriaClinica_nueva.ShowDialog()
        ElseIf dedonde = 12 Then
            'abro ventana para emitir recibo de cancelacion/abono
            'consulta recibos de pago 
            recibos_nuevo.dedonde = 4
            recibos_nuevo.Label8.Text = "//Recibo de Abono/Cancelacion"
            recibos_nuevo.Button1.Visible = True
            recibos_nuevo.orden = CStr(row.Cells(0).Value)
            recibos_nuevo.total.Text = CStr(row.Cells(8).Value)

            recibos_nuevo.nombre.Text = CStr(row.Cells(3).Value)
            recibos_nuevo.telefono.Text = CStr(row.Cells(4).Value)
            recibos_nuevo.armazon.Text = CStr(row.Cells(5).Value)
            recibos_nuevo.marca.Text = CStr(row.Cells(9).Value)
            recibos_nuevo.id_vendedor = CStr(row.Cells(10).Value)
            recibos_nuevo.txt_vendedor.Text = CStr(row.Cells(11).Value)
            recibos_nuevo.nit.Text = CStr(row.Cells(12).Value)
            recibos_nuevo.nombrepf.Text = CStr(row.Cells(13).Value)
            recibos_nuevo.MdiParent = dashboard
            recibos_nuevo.orden = CStr(row.Cells(0).Value)
            recibos_nuevo.Show()
        ElseIf dedonde = 13 Or dedonde = 15 Then
            'consulta movimientos de ingreso por ajuste 

            movimientos.dedonde = 4
            If dedonde = 13 Then
                'consulta movimiento ingreso 
                movimientos.Label8.Text = "MOVIMIENTO - " & CStr(row.Cells(3).Value).ToString
            ElseIf dedonde = 15 Then
                'anulacion de movimiento 
                movimientos.Label8.Text = "ANULACION MOVIMIENTO - " & CStr(row.Cells(3).Value).ToString
                movimientos.Label8.ForeColor = Color.Red
            End If
            movimientos.no_factura.Text = CStr(row.Cells(2).Value)
            movimientos.serie.Text = CStr(row.Cells(3).Value)
            movimientos.fecha.Text = CStr(row.Cells(1).Value)
            movimientos.movi = CStr(row.Cells(6).Value)
            movimientos.TextBox1.Text = CStr(row.Cells(7).Value)
            movimientos.hechopor = CStr(row.Cells(5).Value)
            movimientos.operado.Text = "Operado por: " & CStr(row.Cells(5).Value)
            movimientos.operado.Visible = True
            movimientos.TextBox1.ReadOnly = True
            movimientos.cmb_tipo.Visible = False
            movimientos.Label1.Text = "Documento"
            movimientos.no_factura.Visible = True
            '  movimientos.no_factura.ReadOnly = True
            movimientos.serie.ReadOnly = False
            movimientos.Button4.Visible = True
            movimientos.Button1.Visible = False
            movimientos.Button2.Enabled = False
            movimientos.Button5.Visible = True
            movimientos.ShowDialog()
        ElseIf dedonde = 14 Or dedonde = 16 Then
            'consulta movimientos de ingreso por ajuste 

            movimientos.dedonde = 5
            If dedonde = 14 Then
                'consulta movimiento ingreso 
                movimientos.Label8.Text = "MOVIMIENTO - " & CStr(row.Cells(3).Value).ToString
            ElseIf dedonde = 16 Then
                'anulacion de movimiento 
                movimientos.Label8.Text = "ANULACION MOVIMIENTO - " & CStr(row.Cells(3).Value).ToString
                movimientos.Label8.ForeColor = Color.Red
            End If

            movimientos.no_factura.Text = CStr(row.Cells(2).Value)
            movimientos.serie.Text = CStr(row.Cells(3).Value)

            movimientos.fecha.Text = CStr(row.Cells(1).Value)
            movimientos.movi = CStr(row.Cells(6).Value)
            movimientos.TextBox1.Text = CStr(row.Cells(7).Value)
            movimientos.hechopor = CStr(row.Cells(5).Value)
            movimientos.operado.Text = "Operado por: " & CStr(row.Cells(5).Value)
            movimientos.operado.Visible = True
            movimientos.TextBox1.ReadOnly = True
            movimientos.cmb_tipo.Visible = False
            movimientos.Label1.Text = "Documento"
            movimientos.no_factura.Visible = True
            '  movimientos.no_factura.ReadOnly = True
            movimientos.serie.ReadOnly = False
            movimientos.Button4.Visible = True
            movimientos.Button1.Visible = False
            movimientos.Button2.Enabled = False
            movimientos.Button5.Visible = True
            movimientos.ShowDialog()


        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub TextBox1_Move(sender As Object, e As EventArgs) Handles TextBox1.Move

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles DataGridView1.CellContextMenuStripNeeded

    End Sub
End Class