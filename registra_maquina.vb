Imports System.Management
Imports MySql.Data.MySqlClient
Public Class registra_maquina
    Dim Second, consulta As String
    Dim serialBoard As String
    Dim com As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'actualizo el registro de la maquina
        Try
            conexion.Open()
            consulta = ("UPDATE catagencias set serial='" & serial1.Text & "', registro='" & dashboard.usuario.Text & "' where id_agencia='" & agencia.Text & "'")
            com = New MySqlCommand(consulta, conexion)
            com.ExecuteNonQuery()
            MessageBox.Show("Equipo registrado con exito, por favor cierre el sistema y vuelva a abrirlo!")
            conexion.Close()
            usuarios.Button4.Enabled = True
            Me.Dispose()
        Catch ex As Exception
            MsgBox("No fue posible registrar este equipo, si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            conexion.Close()
            Me.Dispose()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'mensaje pago sistema
        Timer1.Interval = 1000
        Timer1.Start() 'Timer starts functioning
        ProgressBar.Enabled = True
    End Sub

    Private Sub registra_maquina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Second = Val(Second) + 1
        'set position
        ProgressBar.Value = ProgressBar.Value + 1
        'add the progress bar to the form
        If Second >= 5 Then
            Timer1.Stop() 'Timer stops functioning
            Second = 0
            Informacion()
            MessageBox.Show("Serial del equipo listo  " & serial1.Text & " se registrara como punto de venta " & agencia.Text)
            Button2.Enabled = False
            Button3.Enabled = True
        End If

    End Sub

    Sub Informacion()
        ':::Obtenemos la informacion del Sistema operativo
        SO.Text = My.Computer.Info.OSFullName
        version.Text = My.Computer.Info.OSVersion

        Dim consultaSQLArquitectura As String = "SELECT * FROM Win32_Processor"
        Dim objArquitectura As New ManagementObjectSearcher(consultaSQLArquitectura)
        Dim ArquitecturaSO As String = ""
        For Each info As ManagementObject In objArquitectura.Get()
            ArquitecturaSO = info.Properties("AddressWidth").Value.ToString()
        Next info
        'LblArquitecturaSO.Text = "Arquitectura del SO: " + ArquitecturaSO + " Bits"

        ':::Obtenemos la informacion del Equipo
        equipo.Text = My.Computer.Name
        '  LblNombreUsuario.Text = "Nombre del Usuario: " + Security.Principal.WindowsIdentity.GetCurrent().Name

        ':::Obtenemos el serial del Disco Duro
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        serial1.Text = serialDD.Properties("SerialNumber").Value.ToString

        ':::Obtenemos el serial de la Board
        Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
        Dim serialBoard As String = ""
        For Each serialB As ManagementObject In serial.Get()
            serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
        Next
        ' version.Text = serialBoard
    End Sub
End Class