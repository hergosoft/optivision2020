Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class imprimir_historia
    Dim consulta, m_nombre(2), m_motivoconsulta(2), m_rx2odesf(2), m_rx2odcil(2), m_rx2odeje(2), m_rx2oiesf(2), m_rx2oicil(2), m_rx2oieje(2), m_rx2adicion(2), m_rx2dp(2), m_obs(2), m_fecha(2) As String
    Dim nombre, motivo_consulta, rx2odesf, rx2odcil, rx2odeje, rx2oiesf, rx2oicil, rx2oieje, rx2adicion, rx2dp, obs, fecha, dia1, mes1, ano1 As String
    Public documento As String
    Dim adaptador As MySqlDataAdapter
    Dim rs As MySqlDataReader
    Dim com As MySqlCommand
    Dim tabla_medidas As DataTable

    Private Sub imprimir_historia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtengo las coordenadas de impresion
        Try
            consulta = "SELECT linea,columna FROM visformatos WHERE formato='historia_c' and id_agencia='" & dashboard.no_agencia & "'"
            adaptador = New MySqlDataAdapter(consulta, conexion)
            tabla_medidas = New DataTable
            adaptador.Fill(tabla_medidas)
            dtv_medidas.DataSource = tabla_medidas
            conexion.Close()
            m_nombre(1) = dtv_medidas.Item(0, 0).Value.ToString
            m_nombre(2) = dtv_medidas.Item(1, 0).Value.ToString
            m_motivoconsulta(1) = dtv_medidas.Item(0, 1).Value.ToString
            m_motivoconsulta(2) = dtv_medidas.Item(1, 1).Value.ToString
            m_rx2odesf(1) = dtv_medidas.Item(0, 2).Value.ToString
            m_rx2odesf(2) = dtv_medidas.Item(1, 2).Value.ToString
            m_rx2odcil(1) = dtv_medidas.Item(0, 3).Value.ToString
            m_rx2odcil(2) = dtv_medidas.Item(1, 3).Value.ToString
            m_rx2odeje(1) = dtv_medidas.Item(0, 4).Value.ToString
            m_rx2odeje(2) = dtv_medidas.Item(1, 4).Value.ToString
            m_rx2oiesf(1) = dtv_medidas.Item(0, 5).Value.ToString
            m_rx2oiesf(2) = dtv_medidas.Item(1, 5).Value.ToString
            m_rx2oicil(1) = dtv_medidas.Item(0, 6).Value.ToString
            m_rx2oicil(2) = dtv_medidas.Item(1, 6).Value.ToString
            m_rx2oieje(1) = dtv_medidas.Item(0, 7).Value.ToString
            m_rx2oieje(2) = dtv_medidas.Item(1, 7).Value.ToString
            m_rx2adicion(1) = dtv_medidas.Item(0, 8).Value.ToString
            m_rx2adicion(2) = dtv_medidas.Item(1, 8).Value.ToString
            m_rx2dp(1) = dtv_medidas.Item(0, 9).Value.ToString
            m_rx2dp(2) = dtv_medidas.Item(1, 9).Value.ToString
            m_obs(1) = dtv_medidas.Item(0, 10).Value.ToString
            m_obs(2) = dtv_medidas.Item(1, 10).Value.ToString
            m_fecha(1) = dtv_medidas.Item(0, 11).Value.ToString
            m_fecha(2) = dtv_medidas.Item(1, 11).Value.ToString
            conexion.Close()
            ' MessageBox.Show(m_rx2ao(1) & m_rx2ao(2))
        Catch ex As Exception
            MsgBox("No fue posible obtener los parametros de impresion, " & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Me.Close()
        End Try
        'obtengo los datos de la historia clinica
        Try
            conexion.Open()
            consulta = "SELECT nombre,motivo_c,rx2_od_esf,rx2_od_cil,rx2_od_eje,rx2_oi_esf,rx2_oi_cil,rx2_oi_eje,rx2_adicion,rx2_dp,obs,fecha from clinica where no_clinica='" & documento & "' and id_agencia='" & dashboard.no_agencia & "'"
            com = New MySqlCommand(consulta, conexion)
            rs = com.ExecuteReader
            rs.Read()
            nombre = rs(0)
            motivo_consulta = rs(1)
            rx2odesf = rs(2)
            rx2odcil = rs(3)
            rx2odeje = rs(4)
            rx2oiesf = rs(5)
            rx2oicil = rs(6)
            rx2oieje = rs(7)
            rx2adicion = rs(8)
            rx2dp = rs(9)
            obs = rs(10)
            fecha = rs(11)
            ano1 = Mid(fecha, 1, Len(fecha) - 6)
            mes1 = Mid(fecha, 6, Len(fecha) - 8)
            dia1 = Mid(fecha, 9, Len(fecha) - 8)
            rs.Close()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible obtener el detalle de la historia clinica, " & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                 MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        
        'actualizo el estatus de la historia clinica que imprimi
        Try
            'actualizo el status de la historia clinica
            conexion.Open()
            consulta = "UPDATE clinica set status='I'  where no_clinica='" & documento & "' and id_agencia='" & dashboard.no_agencia & "'"
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible actualizar el status de la historia clinica, " & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Return
        End Try
        'realizo la impresion 
        Try
            Dim PrintDoc As New PrintDocument
            AddHandler PrintDoc.PrintPage, AddressOf Me.Print_historia_nuevo
            PrintDoc.Print()
            MessageBox.Show("Impresion Realizada ")
            h_clinicas.Close()
            ' h_clinicas.MdiParent = dashboard
            ' h_clinicas.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("La Impresion ha fallado", ex.ToString())
        End Try
    End Sub
    Private Sub Print_historia_nuevo(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim fuente As Font
        Dim margenEsq As Single = ev.MarginBounds.Left ' defino margen a impresion de la grilla
        ev.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 11)
        'funcion para imprimir 
        'primera coordenada alinea en horizontal
        'segunda coordenada alinea en vertical 
        'Imprimo encabezado
        ev.Graphics.DrawString(nombre, New Font(fuente, FontStyle.Regular), Brushes.Black, m_nombre(1), m_nombre(2))
        ev.Graphics.DrawString("Motivo de la consulta:  " & motivo_consulta, New Font(fuente, FontStyle.Regular), Brushes.Black, m_motivoconsulta(1), m_motivoconsulta(2))
        ev.Graphics.DrawString("ESFERA", New Font(fuente, FontStyle.Bold), Brushes.Black, m_rx2odesf(1) + 38, m_rx2odesf(2) - 10)
        ev.Graphics.DrawString("OJO DERECHO        " & rx2odesf, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2odesf(1), m_rx2odesf(2))
        ev.Graphics.DrawString("CILINDRO", New Font(fuente, FontStyle.Bold), Brushes.Black, m_rx2odcil(1) - 4, m_rx2odcil(2) - 10)
        ev.Graphics.DrawString(rx2odcil, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2odcil(1), m_rx2odcil(2))
        ev.Graphics.DrawString("EJE", New Font(fuente, FontStyle.Bold), Brushes.Black, m_rx2odeje(1) + 1, m_rx2odeje(2) - 10)
        ev.Graphics.DrawString(rx2odeje, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2odeje(1), m_rx2odeje(2))
        ev.Graphics.DrawString("OJO IZQUIERDO       " & rx2oiesf, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2oiesf(1), m_rx2oiesf(2))
        ev.Graphics.DrawString(rx2oicil, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2oicil(1), m_rx2oicil(2))
        ev.Graphics.DrawString(rx2oieje, New Font(fuente, FontStyle.Regular), Brushes.Black, m_rx2oieje(1), m_rx2oieje(2))
        ev.Graphics.DrawString("ADD     " & rx2adicion, New Font(fuente, FontStyle.Bold), Brushes.Black, m_rx2adicion(1), m_rx2adicion(2))
        ev.Graphics.DrawString("DP       " & rx2dp, New Font(fuente, FontStyle.Bold), Brushes.Black, m_rx2dp(1), m_rx2dp(2))
        ev.Graphics.DrawString("Observaciones:      " & obs, New Font(fuente, FontStyle.Bold), Brushes.Black, m_obs(1), m_obs(2))
        ev.Graphics.DrawString("Fecha examen:  " & dia1 & "-" & mes1 & "-" & ano1, New Font(fuente, FontStyle.Regular), Brushes.Black, m_fecha(1), m_fecha(2))
        ev.HasMorePages = False

    End Sub
End Class