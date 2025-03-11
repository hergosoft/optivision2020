Imports MySql.Data.MySqlClient
Public Class movimientos_kardex
    Public id_codigo, descripcion, total, entr, sal, dedonde As String
    Dim consulta As String
    Dim adapatador As MySqlDataAdapter
    Dim tabladatos As DataTable
    Private Sub movimientos_kardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = Nothing
        total = 0
        entr = 0
        sal = 0
        Label1.Text = descripcion
        'doy estilo a mi datagridview
        With DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            If dedonde = 2 Then
                .DefaultCellStyle.Font = New Font("time new roman", 10)
            Else
                .DefaultCellStyle.Font = New Font("time new roman", 12)
            End If

        End With
        'realizo la busquedad del kardex del producto cargado

        If dedonde = 2 Then
            'cargo algunos productos al iniciar la ventana para consulta de movimientos general 
            Try
                'consulta = "select  fecha, docto, serie, entrada,salida from kardexinven  where id_codigo='" & id_codigo & "' "
                consulta = "select  k.fecha,k.id_agencia,a.nombre,c.nombre,k.docto, k.serie, k.entrada,k.salida,k.hechopor from kardexinven as k
                            left join catkardex as c on c.id_movi=k.id_movi  left join  catagencias as a on a.id_agencia= k.id_agencia where k.id_codigo='" & id_codigo & "' order by k.nocorrela;"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "FECHA"
                DataGridView1.Columns(0).Width = 90
                DataGridView1.Columns(1).HeaderText = "No. AGE"
                DataGridView1.Columns(1).Width = 45
                DataGridView1.Columns(2).HeaderText = "TIENDA"
                DataGridView1.Columns(2).Width = 130
                DataGridView1.Columns(3).HeaderText = "TIPO DOCTO"
                DataGridView1.Columns(3).Width = 180
                DataGridView1.Columns(4).HeaderText = "DOCTO"
                DataGridView1.Columns(4).Width = 70
                DataGridView1.Columns(5).HeaderText = "SERIE"
                DataGridView1.Columns(5).Width = 70
                DataGridView1.Columns(6).HeaderText = "ENTRADA"
                DataGridView1.Columns(6).Width = 90
                DataGridView1.Columns(7).HeaderText = "SALIDA"
                DataGridView1.Columns(7).Width = 70
                DataGridView1.Columns(8).HeaderText = "OPERA"
                DataGridView1.Columns(8).Width = 130
                conexion.Close()
                Label2.Visible = False
                Label3.Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de productos, si el error persiste contacta con Soporte Tecnico " &
                      vbCrLf & vbCrLf & ex.Message,
                      MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try


        Else

            'cargo algunos productos al iniciar la ventana 
            Try
                consulta = "select  fecha, docto, serie, entrada,salida from kardexinven  where id_codigo='" & id_codigo & "' and id_agencia='" & dashboard.no_agencia & "'"
                adapatador = New MySqlDataAdapter(consulta, conexion)
                tabladatos = New DataTable
                adapatador.Fill(tabladatos)
                DataGridView1.DataSource = tabladatos
                DataGridView1.Columns(0).HeaderText = "FECHA"
                DataGridView1.Columns(0).Width = 148
                DataGridView1.Columns(1).HeaderText = "DOCUMENTO"
                DataGridView1.Columns(1).Width = 120
                DataGridView1.Columns(2).HeaderText = "SERIE"
                DataGridView1.Columns(2).Width = 120
                DataGridView1.Columns(3).HeaderText = "ENTRADAS"
                DataGridView1.Columns(3).Width = 150
                DataGridView1.Columns(4).HeaderText = "SALIDAS"
                DataGridView1.Columns(4).Width = 150
                conexion.Close()
                Dim fila As DataGridViewRow = New DataGridViewRow
                For Each fila In DataGridView1.Rows
                    total += Convert.ToDouble(fila.Cells(3).Value)
                Next
                entr = Convert.ToString(total)
                'verifico si entr esta vacia para igualar a cero 
                If entr = "" Then
                    entr = 0
                End If
                'obtengo el resultado de la segunda columna (salida)
                Dim total1 As Double = 0
                Dim fila1 As DataGridViewRow = New DataGridViewRow()
                For Each fila1 In DataGridView1.Rows
                    total1 += Convert.ToDouble(fila1.Cells(4).Value)
                Next
                sal = Convert.ToString(total1)
                If sal = "" Then
                    sal = 0
                End If
                total = Val(entr) - Val(sal)
                Label3.Text = total
            Catch ex As Exception
                MsgBox("No fue posible obtener el listado de productos, si el error persiste contacta con Soporte Tecnico " &
                      vbCrLf & vbCrLf & ex.Message,
                      MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub
End Class