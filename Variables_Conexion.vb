Imports MySql.Data.MySqlClient
Imports MySql.Data.Types

Module Variables_Conexion
    Public servidor As String
    Public usuario As String
    Public pass As String
    'creo conexion
    'estsa variable esta declara publica ya que la llamo en todos los forms para no repetir lineas de codigo 

    'Public conexiongoptics As New MySqlConnection("server=" & "192.168.0.253" & ";" & "user id=" & "g-optics" & ";" & "password=" & "UnaClave*123" & ";database=g-optics;port=3306;charset=utf8;Convert Zero Datetime=True")
    Public conexiongoptics As New MySqlConnection("server=" & "217.196.49.177" & ";" & "user id=" & "goptics" & ";" & "password=" & "Omega_Sigma1215" & ";database=o_sosa;port=3306;charset=utf8;Convert Zero Datetime=True")
    Public conexiongopticsh As New MySqlConnection("server=" & "217.196.49.177" & ";" & "user id=" & "goptics" & ";" & "password=" & "Omega_Sigma1215" & ";database=o_sosa;port=3306;charset=utf8;Convert Zero Datetime=True")
    Public conexion As New MySqlConnection("server=" & "217.196.49.177" & ";" & "user id=" & "goptics" & ";" & "password=" & "Omega_Sigma1215" & ";database=o_sosa;port=3306;charset=utf8;Convert Zero Datetime=True")
    'colocare este comentario de prueba y comprobare el push 
    ';Pooling=false;Connection Lifetime=1; Max Pool Size=1
End Module
