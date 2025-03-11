Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class HistoriaClinica_nueva
    Dim rs As MySqlDataReader
    Dim consulta, pregunta, ch(17), rxfinal(32), tipolente, antirreflejo, tipo_lente, luz_azul, foto, material As String
    Dim com As MySqlCommand
    Public dedonde, no_cliente, tienda_examina As String
    'declaro las variables que me sirven para centrar  la impresion de tiket 
    Dim TopCenter As StringFormat = New StringFormat()
    Dim TopLeft As StringFormat = New StringFormat()
    Dim sf As StringFormat = New StringFormat

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub HistoriaClinica_nueva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'limpio las variables que me sirven para la impresion de tiket al cargar el formulario 
        TopCenter.LineAlignment = StringAlignment.Near
        TopCenter.Alignment = StringAlignment.Center

        fecha.Text = Date.Now.ToString("yyyy-MM-dd")
        If dedonde = 2 Then
            'abro desde consulta historia clinica
            Try
                'realizo la busquedad de la historia clinica grabada 
                conexion.Open()
                consulta = "SELECT * FROM clinica where no_clinica='" & correlativo.Text & "' "
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                correlativo.Text = rs(0)
                fecha.Text = rs(1)
                tienda_examina = rs(2)
                nombre.Text = rs(3)
                telefono.Text = rs(4)
                edad.Text = rs(5)
                profesion.Text = rs(6)
                anaminesis.Text = rs(7)
                email.Text = rs(10)
                motivo.Text = rs(9)

                If rs(8) = "x" Then
                    CheckBox17.Checked = True
                End If
                If rs(11) = "x" Then
                    CheckBox1.Checked = True
                End If
                'If rs(12) = "x" Then
                '    CheckBox1.Checked = True
                'End If
                'If rs(13) = "x" Then
                '    CheckBox2.Checked = True
                'End If

                'agudeza visual 
                ultimo_cheq.Text = rs(14)

                TextBox44.Text = rs(15)
                TextBox43.Text = rs(16)
                rx1_tipolente.Text = rs(17)
                TextBox38.Text = rs(18)
                TextBox37.Text = rs(19)
                rx2_pantoscopico.Text = rs(20)
                rx1_od_esf.Text = rs(21)
                rx1_od_cil.Text = rs(22)
                rx1_od_eje.Text = rs(23)
                rx1_od_av1.Text = rs(24)
                rx1_od_add.Text = rs(25)
                rx1_od_av2.Text = rs(26)
                rx1_oi_esf.Text = rs(27)
                rx1_oi_cil.Text = rs(28)
                rx1_oi_eje.Text = rs(29)
                rx1_oi_av1.Text = rs(30)
                rx1_oi_add.Text = rs(31)
                rx1_oi_av2.Text = rs(32)
                TextBox36.Text = rs(33)
                TextBox32.Text = rs(34)
                TextBox31.Text = rs(35)
                TextBox30.Text = rs(36)
                TextBox29.Text = rs(37)
                DateTimePicker1.Value = rs(38)
                TextBox26.Text = rs(40)
                TextBox25.Text = rs(41)
                TextBox24.Text = rs(42)
                TextBox23.Text = rs(43)

                rx2_panoramico.Text = rs(46)
                ao.Text = rs(47)
                TextBox42.Text = rs(48)
                rx2_od_esf.Text = rs(79)
                rx2_od_cil.Text = rs(80)
                rx2_od_eje.Text = rs(81)
                rx2_od_av1.Text = rs(82)
                rx2_od_add.Text = rs(83)
                rx2_od_av2.Text = rs(84)
                rx2_oi_esf.Text = rs(85)
                rx2_oi_cil.Text = rs(86)
                rx2_oi_eje.Text = rs(87)
                rx2_oi_av1.Text = rs(88)
                rx2_oi_add.Text = rs(89)
                rx2_oi_av2.Text = rs(90)
                TextBox2.Text = rs(91)
                TextBox1.Text = rs(92)

                TextBox20.Text = rs(55)
                TextBox19.Text = rs(56)
                TextBox18.Text = rs(57)
                TextBox17.Text = rs(58)

                TextBox14.Text = rs(61)
                TextBox13.Text = rs(62)
                TextBox12.Text = rs(63)
                TextBox11.Text = rs(64)

                TextBox3.Text = rs(94)
                TextBox4.Text = rs(104)

                ' rx2_panoramico.Text = rs(103)
                'rx2_vertice.Text = rs(104)
                rx2_obs.Text = rs(105)
                opto.Text = rs(106)
                rs.Close()
                conexion.Close()
                grabar.Visible = False
                imprime.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MsgBox("No fue posible obtener la informacion de la historia clinica ," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
          MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 3 Then
            'abro desde modificacion historia clinica 
            Try
                'realizo la busquedad de la historia clinica grabada 
                conexion.Open()
                consulta = "SELECT * FROM clinica where no_clinica='" & correlativo.Text & "' and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                rs = com.ExecuteReader
                rs.Read()
                nombre.Text = rs(3)
                oi_oftal2.Text = rs(4)
                email.Text = rs(5)
                edad.Text = rs(7)
                telefono.Text = rs(8)
                profesion.Text = rs(9)
                motivo.Text = rs(10)
                anaminesis.Text = rs(11)
                od_oftal1.Text = rs(12)
                od_oftal2.Text = rs(13)
                od_oftal3.Text = rs(14)
                ao.Text = rs(15)
                rx1_od_esf.Text = rs(16)
                rx1_od_cil.Text = rs(17)
                rx1_od_eje.Text = rs(18)
                rx1_od_av1.Text = rs(19)
                rx1_od_add.Text = rs(20)
                rx1_od_av2.Text = rs(21)
                rx1_oi_esf.Text = rs(22)
                rx1_oi_cil.Text = rs(23)
                rx1_oi_eje.Text = rs(24)
                rx1_oi_av1.Text = rs(25)
                rx1_oi_add.Text = rs(26)
                rx1_oi_av2.Text = rs(27)
                rx1_tipolente.Text = rs(28)
                oi_oftal5.Text = rs(29)
                od_oftal4.Text = rs(30)
                od_oftal5.Text = rs(31)
                od_oftal6.Text = rs(32)
                biomi_obs.Text = rs(33)
                lc_od_esf.Text = rs(34)
                lc_od_cil.Text = rs(35)
                lc_od_eje.Text = rs(36)
                lc_od_av.Text = rs(37)
                lc_oi_esf.Text = rs(38)
                lc_oi_cil.Text = rs(39)
                ' lc_oi_eje.Text = rs(40)
                ' lc_oi_av.Text = rs(41)
                oftal_obs.Text = rs(42)
                lc_diametro.Text = rs(43)
                lc_marca.Text = rs(44)
                rx2_od_esf.Text = rs(45)
                rx2_od_cil.Text = rs(46)
                rx2_od_eje.Text = rs(47)
                rx2_od_av1.Text = rs(48)
                rx2_od_add.Text = rs(49)
                rx2_od_av2.Text = rs(50)
                rx2_oi_esf.Text = rs(51)
                rx2_oi_cil.Text = rs(52)
                rx2_oi_eje.Text = rs(53)
                rx2_oi_av1.Text = rs(54)
                rx2_oi_add.Text = rs(55)
                rx2_oi_av2.Text = rs(56)
                rx2_pantoscopico.Text = rs(57)
                rx2_panoramico.Text = rs(58)
                rx2_vertice.Text = rs(59)
                rx2_obs.Text = rs(60)
                oi_oftal1.Text = rs(63)
                ultimo_cheq.Text = rs(64)
                If rs(65) = "X" Then
                    CheckBox17.Checked = True
                End If
                If rs(66) = "X" Then
                    CheckBox16.Checked = True
                End If
                If rs(67) = "X" Then
                    CheckBox18.Checked = True
                End If
                If rs(68) = "X" Then
                    CheckBox1.Checked = True
                End If
                If rs(69) = "X" Then
                    CheckBox2.Checked = True
                End If
                If rs(70) = "X" Then
                    CheckBox3.Checked = True
                End If
                If rs(71) = "X" Then
                    CheckBox4.Checked = True
                End If
                If rs(72) = "X" Then
                    CheckBox5.Checked = True
                End If
                If rs(73) = "X" Then
                    CheckBox10.Checked = True
                End If
                If rs(74) = "X" Then
                    CheckBox9.Checked = True
                End If
                If rs(75) = "X" Then
                    CheckBox8.Checked = True
                End If
                If rs(76) = "X" Then
                    CheckBox7.Checked = True
                End If
                If rs(77) = "X" Then
                    CheckBox6.Checked = True
                End If
                If rs(78) = "X" Then
                    CheckBox15.Checked = True
                End If
                If rs(79) = "X" Then
                    CheckBox14.Checked = True
                End If
                If rs(80) = "X" Then
                    CheckBox13.Checked = True
                End If
                If rs(81) = "X" Then
                    CheckBox12.Checked = True
                End If
                If rs(82) = "X" Then
                    CheckBox11.Checked = True
                End If
                TextBox44.Text = rs(83)
                TextBox43.Text = rs(84)
                TextBox42.Text = rs(85)
                oi_oftal3.Text = rs(86)
                TextBox38.Text = rs(87)
                TextBox37.Text = rs(88)
                TextBox36.Text = rs(89)
                oi_oftal4.Text = rs(90)
                rs.Close()
                conexion.Close()
                grabar.Visible = Enabled
                imprime.Visible = False
            Catch ex As Exception
                MsgBox("No fue posible obtener la informacion de la historia clinica ," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
           vbCrLf & vbCrLf & ex.Message,
          MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 1 Then
            'abro desde nueva historia clinica 
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
            sucursal.Text = dashboard.agencia.Text
            opto.Text = dashboard.nombre_usuario

        End If
    End Sub

    Private Sub nombre_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            oi_oftal2.Focus()
        End If
    End Sub

    Private Sub nombre_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub direccion_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub direccion_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub
    Private Sub grabar_Click(sender As Object, e As EventArgs) Handles grabar.Click
        'alguna cirugia
        If CheckBox17.Checked = True Then
            ch(0) = "X"
        Else : ch(0) = "."
        End If
        'utiliza lentes
        If CheckBox16.Checked = True Then
            ch(1) = "X"
        Else : ch(1) = "."
        End If
        'tolera
        If CheckBox18.Checked = True Then
            ch(2) = "X"
        Else : ch(2) = "."
        End If
        'presion alta
        If CheckBox1.Checked = True Then
            ch(3) = "X"
        Else : ch(3) = "."
        End If
        'presion baja
        If CheckBox2.Checked = True Then
            ch(4) = "X"
        Else : ch(4) = "."
        End If
        'diabetes
        If CheckBox3.Checked = True Then
            ch(5) = "X"
        Else : ch(5) = "."
        End If
        'tiroides
        If CheckBox4.Checked = True Then
            ch(6) = "X"
        Else : ch(6) = "."
        End If
        'emabarazo
        If CheckBox5.Checked = True Then
            ch(7) = "X"
        Else : ch(7) = "."
        End If
        'presionalta
        If CheckBox10.Checked = True Then
            ch(8) = "X"
        Else : ch(8) = "."
        End If
        'presion baja
        If CheckBox9.Checked = True Then
            ch(9) = "X"
        Else : ch(9) = "."
        End If
        'diabetes
        If CheckBox8.Checked = True Then
            ch(10) = "X"
        Else : ch(10) = "."
        End If
        'tiroides
        If CheckBox7.Checked = True Then
            ch(11) = "X"
        Else : ch(11) = "."
        End If
        'embarazo
        If CheckBox6.Checked = True Then
            ch(12) = "X"
        Else : ch(12) = "."
        End If

        'cefelea
        If CheckBox15.Checked = True Then
            ch(13) = "X"
        Else : ch(13) = "."
        End If
        'lagrimeo
        If CheckBox14.Checked = True Then
            ch(14) = "X"
        Else : ch(14) = "."
        End If
        'dolor ocular
        If CheckBox13.Checked = True Then
            ch(15) = "X"
        Else : ch(15) = "."
        End If
        'vision borrosa
        If CheckBox12.Checked = True Then
            ch(16) = "X"
        Else : ch(16) = "."
        End If
        'secrecion
        If CheckBox11.Checked = True Then
            ch(17) = "X"
        Else : ch(17) = "."
        End If
        If dedonde = 3 Then
            'modifico historia clinica
            Try
                conexion.Open()
                consulta = " UPDATE clinica set nombre='" & nombre.Text & "',direccion='" & oi_oftal2.Text & "',email='" & email.Text & "',edad='" & edad.Text & "',telefono='" & telefono.Text & "',profesion='" & profesion.Text & "',hobbies='" & motivo.Text & "',anaminesis='" & anaminesis.Text & "',avsc='" & od_oftal1.Text & "',od='" & od_oftal2.Text & "',oi='" & od_oftal3.Text & "',ao='" & ao.Text & "',rx1_od_esf='" & rx1_od_esf.Text & "',rx1_od_cil='" & rx1_od_cil.Text & "',rx1_od_eje='" & rx1_od_eje.Text & "',rx1_od_av1='" & rx1_od_av1.Text & "',rx1_od_add='" & rx1_od_add.Text & "',rx1_od_av2='" & rx1_od_av2.Text & "',rx1_oi_esf='" & rx1_oi_esf.Text & "',rx1_oi_cil='" & rx1_oi_cil.Text & "',rx1_oi_eje='" & rx1_oi_eje.Text & "',rx1_oi_av1='" & rx1_oi_av1.Text & "',rx1_oi_add='" & rx1_oi_add.Text & "',rx1_oi_av2='" & rx1_oi_av2.Text & "',rx1_tipo_lente='" & rx1_tipolente.Text & "',rx1_material='" & oi_oftal5.Text & "',biomicroscopia='" & od_oftal4.Text & "',bio_od='" & od_oftal5.Text & "',bio_oi='" & od_oftal6.Text & "',bio_obs='" & biomi_obs.Text & "',lc_od_esf='" & lc_od_esf.Text & "',lc_od_cil='" & lc_od_cil.Text & "',lc_od_eje='" & lc_od_eje.Text & "',lc_od_av='" & lc_od_av.Text & "',lc_oi_esf='" & lc_oi_esf.Text & "',lc_oi_cil='" & lc_oi_cil.Text & "',lc_curva_base='" & oftal_obs.Text & "',lc_diametro='" & lc_diametro.Text & "',lc_marca='" & lc_marca.Text & "',rx2_od_esf='" & rx2_od_esf.Text & "',rx2_od_cil='" & rx2_od_cil.Text & "',rx2_od_eje='" & rx2_od_eje.Text & "',rx2_od_av1='" & rx2_od_av1.Text & "',rx2_od_add='" & rx2_od_add.Text & "',rx2_od_av2='" & rx2_od_av2.Text & "',rx2_oi_esf='" & rx2_oi_esf.Text & "',rx2_oi_cil='" & rx2_oi_cil.Text & "',rx2_oi_eje='" & rx2_oi_eje.Text & "',rx2_oi_av1='" & rx2_oi_av1.Text & "',rx2_oi_add='" & rx2_oi_add.Text & "',rx2_oi_av2='" & rx2_oi_av2.Text & "',rx2_pantoscopio='" & rx2_pantoscopico.Text & "',rx2_panoramico='" & rx2_panoramico.Text & "',rx2_vertice='" & rx2_vertice.Text & "',rx2_obs='" & rx2_obs.Text & "',dpi='" & oi_oftal1.Text & "',ultimo_ch='" & ultimo_cheq.Text & "',cx1='" & ch(0) & "',cx2='" & ch(1) & "',cx3='" & ch(2) & "',cx4='" & ch(3) & "',cx5='" & ch(4) & "',cx6='" & ch(5) & "',cx7='" & ch(6) & "',cx8='" & ch(7) & "',cx9='" & ch(8) & "',cx10='" & ch(9) & "',cx11='" & ch(10) & "',cx12='" & ch(11) & "',cx13='" & ch(12) & "',cx14='" & ch(13) & "',cx15='" & ch(14) & "',cx16='" & ch(15) & "',cx17='" & ch(16) & "',cx18='" & ch(17) & "',rx3_odesf='" & TextBox44.Text & "',rx3_odcil='" & TextBox43.Text & "',rx3_odeje='" & TextBox42.Text & "',rx3_odav='" & oi_oftal3.Text & "',rx3_oiesf='" & TextBox38.Text & "',rx3_oicil='" & TextBox37.Text & "',rx3_oieje='" & TextBox36.Text & "',rx3_oiav='" & oi_oftal4.Text & "'  where no_clinica='" & correlativo.Text & "' and id_agencia='" & dashboard.no_agencia & "'"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                pregunta = MsgBox("Historia clinica modificada con exito." & vbCrLf & vbCrLf & "¿Desea Imprimirla?", vbYesNo + vbInformation + vbDefaultButton2, "Grabada.")
                If pregunta = vbYes Then
                    imprime.Visible = True
                    imprime.PerformClick()
                    Me.Dispose()
                Else
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("No fue posible grabar los cambios en la historia clinica," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                vbCrLf & vbCrLf & ex.Message,
               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        ElseIf dedonde = 1 Then
            'creacion de nueva historia clinica 
            Try
                conexion.Open()
                consulta = "INSERT INTO clinica(fecha,id_agencia,paciente,telefono,edad,ocupacion,email,motivo,esfu_visual,ant,ciruo,bio_od,tiro,bio_oi,rx1_od_vlsc,rx1_od_vpsc,rx1_oi_vlsc,rx1_oi_vpsc,rx1_od_ao,rx1_oi_ao,rx2_od_esf,rx2_od_cil,rx2_od_eje,rx2_od_av,rx2_od_add,rx2_od_av1,rx2_oi_esf,rx2_oi_cil,rx2_oi_eje,rx2_oi_av,rx2_oi_add,rx2_oi_av1,rx2_tipolente,oftal_od,oftal_od_exc,oftal_od_bordes,oftal_od_papila,oftal_oi,oftal_oi_exc,oftal_oi_bodes,oftal_oi_papila,oftal_obs,rx3_od_esf,rx3_od_cil,rx3_od_eje,rx3_od_av,rx3_oi_esf,rx3_oi_cil,rx3_oi_eje,rx3_oi_av,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_av,rx5_od_add,rx5_od_av1,rx5_od_dnp,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_av,rx5_oi_add,rx5_oi_av1,rx5_oi_dnp,distancia,dx,obs,optometra,oftal_od_rav,id_cliente) values('" & fecha.Text & "','" & dashboard.no_agencia.ToString & "','" & nombre.Text & "','" & telefono.Text & "','" & edad.Text & "','" & profesion.Text & "','" & email.Text & "','" & motivo.Text & "','" & anaminesis.Text & "','" & ultimo_cheq.Text & "','" & ch(0) & "','" & ao.Text & "','" & ch(3) & "','" & TextBox42.Text & "','" & TextBox44.Text & "','" & TextBox43.Text & "','" & TextBox38.Text & "','" & TextBox37.Text & "','" & rx1_tipolente.Text & "','" & rx2_pantoscopico.Text & "','" & rx1_od_esf.Text & "','" & rx1_od_cil.Text & "','" & rx1_od_eje.Text & "','" & rx1_od_av1.Text & "','" & rx1_od_add.Text & "','" & rx1_od_av2.Text & "','" & rx1_oi_esf.Text & "','" & rx1_oi_cil.Text & "','" & rx1_oi_eje.Text & "','" & rx1_oi_av1.Text & "','" & rx1_oi_add.Text & "','" & rx1_oi_av2.Text & "','" & TextBox36.Text & "','" & TextBox32.Text & "','" & TextBox31.Text & "','" & TextBox30.Text & "','" & TextBox29.Text & "','" & TextBox26.Text & "','" & TextBox25.Text & "','" & TextBox24.Text & "','" & TextBox23.Text & "','" & rx2_panoramico.Text & "','" & TextBox20.Text & "','" & TextBox19.Text & "','" & TextBox18.Text & "','" & TextBox17.Text & "','" & TextBox14.Text & "','" & TextBox13.Text & "','" & TextBox12.Text & "','" & TextBox11.Text & "','" & rx2_od_esf.Text & "','" & rx2_od_cil.Text & "','" & rx2_od_eje.Text & "','" & rx2_od_av1.Text & "','" & rx2_od_add.Text & "','" & rx2_od_av2.Text & "','" & TextBox2.Text & "','" & rx2_oi_esf.Text & "','" & rx2_oi_cil.Text & "','" & rx2_oi_eje.Text & "','" & rx2_oi_av1.Text & "','" & rx2_oi_add.Text & "','" & rx2_oi_av2.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & rx2_obs.Text & "','" & opto.Text & "','" & DateTimePicker1.Value.ToShortDateString & "','" & no_cliente & "' )"
                com = New MySqlCommand(consulta, conexion)
                com.ExecuteNonQuery()
                conexion.Close()
                pregunta = MsgBox("Historia clinica grabada con exito." & vbCrLf & vbCrLf & "¿Desea Imprimirla?", vbYesNo + vbInformation + vbDefaultButton2, "Grabada.")
                If pregunta = vbYes Then
                    imprime.Visible = True
                    imprime.PerformClick()
                    Me.Dispose()
                Else
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                MsgBox("No fue posible grabar la historia clinica," & vbCrLf & "Si el error persiste contacta con Soporte Tecnico " &
                 vbCrLf & vbCrLf & ex.Message,
                MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                conexion.Close()
                Return
            End Try
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles imprime.Click
        ''realizo la re impresion de la historia clinica 
        'Try
        '    conexion.Open()
        '    consulta = "SELECT no_clinica,fecha,id_agencia,paciente,telefono,edad,ocupacion,rx5_od_esf,rx5_od_cil,rx5_od_eje,rx5_od_av,rx5_od_add,rx5_od_av1,rx5_oi_esf,rx5_oi_cil,rx5_oi_eje,rx5_oi_av,rx5_oi_add,rx5_oi_av1,motivo,chk1,chk5,chk9,chk11,chk12,obs,optometra,email,rx5_od_dnp,rx5_oi_dnp,rx5_dp,distancia,dx
        '        FROM clinica where id_agencia='" & tienda_examina & "' and no_clinica='" & correlativo.Text & "'"
        '    com = New MySqlCommand(consulta, conexion)
        '    'verifico si la consulta me dio algun resultado, si no tengo no muestro nada
        '    rs = com.ExecuteReader
        '    rs.Read()
        '    rxfinal(0) = rs(0)
        '    rxfinal(1) = rs(1)
        '    rxfinal(2) = rs(2)
        '    rxfinal(3) = rs(3)
        '    rxfinal(4) = rs(4)
        '    rxfinal(5) = rs(5)
        '    rxfinal(6) = rs(6)
        '    'rx5 od
        '    rxfinal(7) = rs(7)
        '    '  rxfinal(8) = rs(8)
        '    rxfinal(9) = rs(9)
        '    rxfinal(10) = rs(10)
        '    rxfinal(11) = rs(11)
        '    rxfinal(12) = rs(12)
        '    'rx5oi
        '    rxfinal(13) = rs(13)
        '    rxfinal(14) = rs(14)
        '    rxfinal(15) = rs(15)
        '    rxfinal(16) = rs(16)
        '    rxfinal(17) = rs(17)
        '    rxfinal(18) = rs(18)
        '    'motivo
        '    rxfinal(19) = rs(19)
        '    'TRATAMIENTO
        '    'rxfinal(20) = rs(20)
        '    'rxfinal(21) = rs(21)
        '    'rxfinal(22) = rs(22)
        '    'rxfinal(23) = rs(23)
        '    'rxfinal(24) = rs(24)
        '    'optometra
        '    rxfinal(25) = rs(25)
        '    'correo
        '    rxfinal(26) = rs(26)
        '    'distancias
        '    rxfinal(27) = rs(27)
        '    rxfinal(28) = rs(28)
        '    rxfinal(29) = rs(29)
        '    rxfinal(30) = rs(30)
        '    rxfinal(31) = rs(31)
        '    rxfinal(32) = rs(32)
        '    rs.Close()
        '    conexion.Close()
        '    'REALIZO LA VALIDACION PARA VER QUE TIPO DE LENTE ESCOGIERON
        '    'Select Case rxfinal(20)
        '    '    Case 1
        '    '        tipo_lente = "VISION SENCILLA"
        '    '    Case 2
        '    '        tipo_lente = "VISION SENCILLA DIGITAL"
        '    '    Case 3
        '    '        tipo_lente = "PROGRESIVO"
        '    '    Case 4
        '    '        tipo_lente = "BIFOCAL"
        '    'End Select
        '    'REALIZO VALIDACION PARA TIPO DE MATERIAL
        '    'Select Case rxfinal(21)
        '    '    Case 1
        '    '        material = "POLICARBONATO"
        '    '    Case 2
        '    '        material = "THIN & LITE"
        '    '    Case 3
        '    '        material = "CR39"
        '    '    Case 4
        '    '        material = "VIDRIO"
        '    'End Select


        '    'REALIZO VALIDACION DEL ANTIREFLEJANTE
        '    'Select Case rxfinal(22)
        '    '    Case 1
        '    '        antirreflejo = "CLEAR - "
        '    '    Case 2
        '    '        antirreflejo = " CLEAR PLUS - "
        '    'End Select
        '    'If rxfinal(23) = "1" Then
        '    '    luz_azul = "SPEKTRA"
        '    'End If

        '    'REALIZO VALIDACION DE FOTOCROMATICO
        '    'Select Case rxfinal(24)
        '    '    Case 1
        '    '        foto = "FOTOCROMATICO: BROWN"
        '    '    Case 2
        '    '        foto = "FOTOCROMATICO: GRAY"
        '    '    Case 3
        '    '        foto = "FOTOCROMATICO: GREEN"
        '    '    Case 4
        '    '        foto = "POLARIZADO: BR"
        '    '    Case 5
        '    '        foto = "POLARIZADO: GRAY"
        '    '    Case 6
        '    '        foto = "POLARIZADO: GREEN"
        '    'End Select

        '    conexion.Close()
        'REALIZO LA IMPRESION 
        Try
                Dim PrintDoc As New PrintDocument
                AddHandler PrintDoc.PrintPage, AddressOf Me.Print_recetatemp
                PrintDoc.PrinterSettings.PrinterName = "TICKET"
                PrintDoc.Print()
            Catch ex As Exception
                'MUESTRO ERROR DE IMPRESION
                MessageBox.Show("La Impresion de historia clinica ha fallado, contacta con soporte tecnico", ex.ToString())
            End Try
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try


    End Sub
    Private Sub Print_recetatemp(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim fuente, fuente1, fuente2, fuente3 As Font
        'e.Graphics.PageUnit = GraphicsUnit.Millimeter
        fuente = New Font("Arial", 9)
        fuente1 = New Font("Consolas", 8)
        fuente2 = New Font("consolas", 7)
        fuente3 = New Font("Arial", 12, FontStyle.Regular)
        Dim prFont As New Font("Consolas", 7, FontStyle.Bold)
        'defino coordenada en horizontal 
        Dim CurX As Integer = 0
        'defino coordenada en vertical 
        Dim CurY As Integer = 0
        'defino ancho del rectangulo que tomo como base para imprimir centrado 
        Dim iWidth As Integer = 298
        Dim cellRect As RectangleF
        cellRect = New RectangleF()
        cellRect.Location = New Point(CurX, CurY)
        cellRect.Size = New Size(iWidth, CurY + 1050)
        'imprimo nombre de la empresa 
        'imprimo tipo de documento 
        'Imprimo Fecha
        cellRect.Location = New Point(CurX, CurY)
        ev.Graphics.DrawString("HISTORIA CLINICA", fuente3, Brushes.Black, cellRect, TopCenter)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 20)
        ev.Graphics.DrawString("H:.. " & correlativo.Text, fuente, Brushes.Black, cellRect, TopLeft)
        'imprimo no de docto 
        cellRect.Location = New Point(CurX, CurY + 25)
        ev.Graphics.DrawString("---------   SUCURSAL   --------- ", fuente, Brushes.Black, cellRect, TopCenter)
        'imprimo direccion
        cellRect.Location = New Point(CurX, CurY + 45)
        ev.Graphics.DrawString(sucursal.Text, fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 60)
        '  ev.Graphics.DrawString("**ESTE NO ES COMPROBANTE DE PAGO**", fuente, Brushes.Black, cellRect, TopCenter)

        cellRect.Location = New Point(CurX, CurY + 75)
        ev.Graphics.DrawString(dashboard.correotienda, fuente, Brushes.Black, cellRect, TopCenter)
        'IMPRIMO DATOS DEL CLIENTE
        cellRect.Location = New Point(CurX, CurY + 100)
        ev.Graphics.DrawString("------   DATOS DEL CLIENTE   ------ ", fuente, Brushes.Black, cellRect, TopCenter)
        cellRect.Location = New Point(CurX, CurY + 120)
        ev.Graphics.DrawString("FECHA: " & fecha.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 136)
        ev.Graphics.DrawString("CLIENTE:  " & nombre.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 162)
        ev.Graphics.DrawString("TELEFONO:  " & telefono.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 177)
        ev.Graphics.DrawString("DIRECCION:  " & email.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 202)
        ev.Graphics.DrawString("EDAD:  " & edad.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 217)
        ev.Graphics.DrawString("OCUPACION:  " & profesion.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 242)
        ev.Graphics.DrawString("MOTIVO: " & motivo.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 270)
        '  ev.Graphics.DrawString("**ESTE NO ES COMPROBANTE DE PAGO**", fuente, Brushes.Black, cellRect, TopCenter)
        '////////********************
        ev.Graphics.DrawString("ESF.", New Font(fuente, FontStyle.Bold), Brushes.Black, 55, 285)
        ev.Graphics.DrawString("CIL.", New Font(fuente, FontStyle.Bold), Brushes.Black, 104, 285)
        ev.Graphics.DrawString("EJE.", New Font(fuente, FontStyle.Bold), Brushes.Black, 153, 285)
        ev.Graphics.DrawString("ADD.", New Font(fuente, FontStyle.Bold), Brushes.Black, 202, 285)
        '/////////*********************
        ev.Graphics.DrawString("OD", New Font(fuente, FontStyle.Bold), Brushes.Black, 10, 305)
        ev.Graphics.DrawString(rx2_od_esf.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 50, 305)
        ev.Graphics.DrawString(rx2_od_cil.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 99, 305)
        ev.Graphics.DrawString(rx2_od_eje.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 147, 305)
        ev.Graphics.DrawString(rx2_od_add.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 197, 305)
        '/////////********************
        ev.Graphics.DrawString("OI", New Font(fuente, FontStyle.Bold), Brushes.Black, 10, 328)
        ev.Graphics.DrawString(rx2_oi_esf.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 50, 328)
        ev.Graphics.DrawString(rx2_oi_cil.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 99, 328)
        ev.Graphics.DrawString(rx2_oi_eje.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 147, 328)
        ev.Graphics.DrawString(rx2_oi_add.Text, New Font(fuente, FontStyle.Bold), Brushes.Black, 197, 328)
        '//////**********************
        cellRect.Location = New Point(CurX, CurY + 350)
        ev.Graphics.DrawString("DNP Derecho:  " & TextBox2.Text & "                 Izquierdo:  " & TextBox1.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 370)
        ev.Graphics.DrawString("DIP: " & TextBox3.Text, fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 385)
        ev.Graphics.DrawString("LENTE Y TX: " & TextBox4.Text, fuente, Brushes.Black, cellRect, TopLeft)
        '///************************
        ' cellRect.Location = New Point(CurX, CurY + 400)
        ' ev.Graphics.DrawString("TEST DE COLOR: " & tipo_lente, fuente, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 420)
        'ev.Graphics.DrawString("MATERIAL: " & material, fuente, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 435)
        'ev.Graphics.DrawString("TRATAMIENTO: " & antirreflejo & " " & luz_azul, fuente, Brushes.Black, cellRect, TopLeft)
        'cellRect.Location = New Point(CurX, CurY + 450)
        'ev.Graphics.DrawString(foto, fuente, Brushes.Black, cellRect, TopLeft)
        'ellRect.Location = New Point(CurX, CurY + 425)
        'ev.Graphics.DrawString("OFTALMOLOGIA: " & rx2_vertice.Text, fuente, Brushes.Black, cellRect, TopLeft)
        ' cellRect.Location = New Point(CurX, CurY + 460)
        'ev.Graphics.DrawString("OPTM: " & opto.Text, fuente, Brushes.Black, cellRect, TopLeft)

        cellRect.Location = New Point(CurX, CurY + 500)
        ev.Graphics.DrawString("OBS: " & rx2_obs.Text, fuente, Brushes.Black, cellRect, TopLeft)
        '////////*******************
        cellRect.Location = New Point(CurX, CurY + 555)
        ' ev.Graphics.DrawString("**ESTE NO ES COMPROBANTE DE PAGO** ", fuente, Brushes.Black, cellRect, TopLeft)
        cellRect.Location = New Point(CurX, CurY + 560)
        ev.Graphics.DrawString("*", fuente, Brushes.Black, cellRect, TopLeft)
        ev.HasMorePages = False
    End Sub

    Private Sub nombre_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles nombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            edad.Focus()
        End If
    End Sub

    Private Sub nombre_TextChanged_1(sender As Object, e As EventArgs) Handles nombre.TextChanged

    End Sub




    Private Sub direccion_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles oi_oftal2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            email.Focus()
        End If
    End Sub

    Private Sub direccion_TextChanged_1(sender As Object, e As EventArgs) Handles oi_oftal2.TextChanged

    End Sub

    Private Sub email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles email.KeyPress
        If Asc(e.KeyChar) = 13 Then
            telefono.Focus()
        End If
    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles telefono.KeyPress
        If Asc(e.KeyChar) = 13 Then
            profesion.Focus()

        End If
    End Sub

    Private Sub telefono_TextChanged(sender As Object, e As EventArgs) Handles telefono.TextChanged

    End Sub

    Private Sub profesion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles profesion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            motivo.Focus()
        End If
    End Sub

    Private Sub profesion_TextChanged(sender As Object, e As EventArgs) Handles profesion.TextChanged

    End Sub

    Private Sub dpi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oi_oftal1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            motivo.Focus()
        End If
    End Sub

    Private Sub dpi_TextChanged(sender As Object, e As EventArgs) Handles oi_oftal1.TextChanged

    End Sub

    Private Sub hobbies_KeyPress(sender As Object, e As KeyPressEventArgs) Handles motivo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            anaminesis.Focus()
        End If
    End Sub

    Private Sub hobbies_TextChanged(sender As Object, e As EventArgs) Handles motivo.TextChanged

    End Sub

    Private Sub anaminesis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles anaminesis.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ultimo_cheq.Focus()
        End If
    End Sub

    Private Sub anaminesis_TextChanged(sender As Object, e As EventArgs) Handles anaminesis.TextChanged

    End Sub

    Private Sub avsc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles od_oftal1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            od_oftal2.Focus()
        End If
    End Sub

    Private Sub avsc_TextChanged(sender As Object, e As EventArgs) Handles od_oftal1.TextChanged

    End Sub

    Private Sub od_KeyPress(sender As Object, e As KeyPressEventArgs) Handles od_oftal2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            od_oftal3.Focus()
        End If
    End Sub

    Private Sub od_TextChanged(sender As Object, e As EventArgs) Handles od_oftal2.TextChanged

    End Sub

    Private Sub oi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles od_oftal3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ao.Focus()
        End If
    End Sub

    Private Sub oi_TextChanged(sender As Object, e As EventArgs) Handles od_oftal3.TextChanged

    End Sub

    Private Sub ao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ao.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_esf.Focus()
        End If
    End Sub

    Private Sub ao_TextChanged(sender As Object, e As EventArgs) Handles ao.TextChanged

    End Sub

    Private Sub rx1_od_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_cil.Focus()
        End If
    End Sub

    Private Sub rx1_od_esf_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_esf.TextChanged

    End Sub

    Private Sub rx1_od_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_eje.Focus()
        End If
    End Sub

    Private Sub rx1_od_cil_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_cil.TextChanged

    End Sub

    Private Sub rx1_od_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_av1.Focus()
        End If
    End Sub

    Private Sub rx1_od_eje_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_eje.TextChanged

    End Sub

    Private Sub rx1_od_av1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_av1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_add.Focus()
        End If
    End Sub

    Private Sub rx1_od_av1_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_av1.TextChanged

    End Sub

    Private Sub rx1_od_add_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_add.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_av2.Focus()
        End If
    End Sub

    Private Sub rx1_od_add_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_add.TextChanged

    End Sub

    Private Sub rx1_od_av2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_od_av2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_esf.Focus()
        End If
    End Sub

    Private Sub rx1_od_av2_TextChanged(sender As Object, e As EventArgs) Handles rx1_od_av2.TextChanged

    End Sub

    Private Sub rx1_oi_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_cil.Focus()
        End If
    End Sub

    Private Sub rx1_oi_esf_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_esf.TextChanged

    End Sub

    Private Sub rx1_oi_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_eje.Focus()
        End If
    End Sub

    Private Sub rx1_oi_cil_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_cil.TextChanged

    End Sub

    Private Sub rx1_oi_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_av1.Focus()
        End If
    End Sub

    Private Sub rx1_oi_eje_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_eje.TextChanged

    End Sub

    Private Sub rx1_oi_av1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_av1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_add.Focus()
        End If
    End Sub

    Private Sub rx1_oi_av1_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_av1.TextChanged

    End Sub

    Private Sub rx1_oi_add_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_add.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_oi_av2.Focus()
        End If
    End Sub

    Private Sub rx1_oi_add_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_add.TextChanged

    End Sub

    Private Sub rx1_oi_av2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_oi_av2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox36.Focus()
        End If
    End Sub

    Private Sub rx1_oi_av2_TextChanged(sender As Object, e As EventArgs) Handles rx1_oi_av2.TextChanged

    End Sub

    Private Sub rx1_tipolente_TextChanged(sender As Object, e As EventArgs) Handles rx1_tipolente.TextChanged

    End Sub

    Private Sub rx1_material_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oi_oftal5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            od_oftal5.Focus()
        End If
    End Sub

    Private Sub rx1_material_TextChanged(sender As Object, e As EventArgs) Handles oi_oftal5.TextChanged

    End Sub

    Private Sub biomi_od_KeyPress(sender As Object, e As KeyPressEventArgs) Handles od_oftal5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            od_oftal6.Focus()
        End If
    End Sub

    Private Sub biomi_od_TextChanged(sender As Object, e As EventArgs) Handles od_oftal5.TextChanged

    End Sub

    Private Sub TextBox44_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox44.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox38.Focus()
        End If
    End Sub

    Private Sub TextBox44_TextChanged(sender As Object, e As EventArgs) Handles TextBox44.TextChanged

    End Sub

    Private Sub biomi_oi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles od_oftal6.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox44.Focus()
        End If
    End Sub

    Private Sub biomi_oi_TextChanged(sender As Object, e As EventArgs) Handles od_oftal6.TextChanged

    End Sub

    Private Sub TextBox43_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox43.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox37.Focus()
        End If
    End Sub

    Private Sub TextBox43_TextChanged(sender As Object, e As EventArgs) Handles TextBox43.TextChanged

    End Sub

    Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox42.KeyPress
        If Asc(e.KeyChar) = 13 Then
            oi_oftal3.Focus()
        End If
    End Sub

    Private Sub TextBox42_TextChanged(sender As Object, e As EventArgs) Handles TextBox42.TextChanged

    End Sub

    Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oi_oftal3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox38.Focus()
        End If
    End Sub

    Private Sub TextBox41_TextChanged(sender As Object, e As EventArgs) Handles oi_oftal3.TextChanged

    End Sub

    Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox38.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox43.Focus()
        End If
    End Sub

    Private Sub TextBox38_TextChanged(sender As Object, e As EventArgs) Handles TextBox38.TextChanged

    End Sub

    Private Sub TextBox37_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox37.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_tipolente.Focus()
        End If
    End Sub

    Private Sub TextBox37_TextChanged(sender As Object, e As EventArgs) Handles TextBox37.TextChanged

    End Sub

    Private Sub TextBox36_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox36.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox32.Focus()
        End If
    End Sub

    Private Sub TextBox36_TextChanged(sender As Object, e As EventArgs) Handles TextBox36.TextChanged

    End Sub

    Private Sub lc_od_esf_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_od_cil.Focus()
        End If
    End Sub

    Private Sub lc_od_esf_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_od_cil_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_od_eje.Focus()
        End If
    End Sub

    Private Sub lc_od_cil_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_od_eje_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_od_av.Focus()
        End If
    End Sub

    Private Sub lc_od_eje_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_od_av_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_oi_esf.Focus()
        End If
    End Sub

    Private Sub lc_od_av_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_oi_esf_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_oi_cil.Focus()
        End If
    End Sub

    Private Sub lc_oi_esf_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub lc_oi_cil_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub lc_oi_eje_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_oi_av_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub lc_oi_av_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            oftal_obs.Focus()
        End If
    End Sub

    Private Sub lc_oi_av_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lc_curvabase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles oftal_obs.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lc_diametro.Focus()
        End If
    End Sub

    Private Sub lc_curvabase_MouseClick(sender As Object, e As MouseEventArgs) Handles oftal_obs.MouseClick

    End Sub

    Private Sub lc_curvabase_TextChanged(sender As Object, e As EventArgs) Handles oftal_obs.TextChanged

    End Sub

    Private Sub lc_diametro_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            lc_marca.Focus()
        End If
    End Sub

    Private Sub lc_diametro_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub rx2_od_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_cil.Focus()
        End If
    End Sub

    Private Sub rx2_od_esf_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_esf.TextChanged

    End Sub

    Private Sub rx2_od_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_eje.Focus()
        End If
    End Sub

    Private Sub rx2_od_cil_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_cil.TextChanged

    End Sub

    Private Sub rx2_od_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_av1.Focus()
        End If
    End Sub

    Private Sub rx2_od_eje_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_eje.TextChanged

    End Sub

    Private Sub rx2_od_av1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_av1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_add.Focus()
        End If
    End Sub

    Private Sub rx2_od_av1_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_av1.TextChanged

    End Sub

    Private Sub rx2_od_add_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_add.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_av2.Focus()
        End If
    End Sub

    Private Sub rx2_od_add_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_add.TextChanged

    End Sub

    Private Sub rx2_od_av2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_od_av2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub rx2_od_av2_TextChanged(sender As Object, e As EventArgs) Handles rx2_od_av2.TextChanged

    End Sub

    Private Sub rx2_oi_cil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_cil.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_eje.Focus()
        End If
    End Sub

    Private Sub rx2_oi_cil_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_cil.TextChanged

    End Sub

    Private Sub edad_TextChanged(sender As Object, e As EventArgs) Handles edad.TextChanged

    End Sub

    Private Sub rx2_oi_esf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_esf.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_cil.Focus()
        End If
    End Sub

    Private Sub rx2_oi_esf_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_esf.TextChanged

    End Sub

    Private Sub rx2_oi_eje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_eje.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_av1.Focus()
        End If
    End Sub

    Private Sub rx2_pantoscopico_TextChanged(sender As Object, e As EventArgs) Handles rx2_pantoscopico.TextChanged

    End Sub

    Private Sub rx2_oi_eje_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_eje.TextChanged

    End Sub

    Private Sub TextBox32_TextChanged(sender As Object, e As EventArgs) Handles TextBox32.TextChanged

    End Sub

    Private Sub rx2_oi_av1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_av1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_add.Focus()
        End If
    End Sub

    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged

    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged

    End Sub

    Private Sub TextBox30_TextChanged(sender As Object, e As EventArgs) Handles TextBox30.TextChanged

    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged

    End Sub

    Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs) Handles TextBox29.TextChanged

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter


    End Sub

    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles TextBox26.TextChanged

    End Sub

    Private Sub rx2_oi_av1_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_av1.TextChanged

    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged

    End Sub

    Private Sub rx2_oi_add_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_add.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_av2.Focus()
        End If
    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged

    End Sub

    Private Sub rx2_oi_add_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_add.TextChanged

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged

    End Sub

    Private Sub edad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            email.Focus()

        End If
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged

    End Sub

    Private Sub edad_KeyUp(sender As Object, e As KeyEventArgs) Handles edad.KeyUp

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged

    End Sub

    Private Sub rx1_tipolente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx1_tipolente.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_pantoscopico.Focus()
        End If
    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub rx2_pantoscopico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_pantoscopico.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx1_od_esf.Focus()
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

    End Sub

    Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox32.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox31.Focus()

        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox31.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox30.Focus()

        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox30.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox29.Focus()

        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox29.KeyPress
        If Asc(e.KeyChar) = 13 Then

            TextBox26.Focus()
        End If


    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox26.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox25.Focus()

        End If
    End Sub

    Private Sub rx2_oi_av2_TextChanged(sender As Object, e As EventArgs) Handles rx2_oi_av2.TextChanged

    End Sub

    Private Sub TextBox25_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox25.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox24.Focus()

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox24_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox24.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox23.Focus()

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox23.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_panoramico.Focus()

        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox20.KeyPress
        If Asc(e.KeyChar) = 13 Then

            TextBox19.Focus()


        End If

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox19.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox18.Focus()

        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox18.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox17.Focus()

        End If
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox17.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox14.Focus()

        End If
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox13.Focus()

        End If
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox12.Focus()

        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox11.Focus()

        End If
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_od_esf.Focus()

        End If
    End Sub

    Private Sub rx2_oi_av2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rx2_oi_av2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox1.Focus()

        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_oi_esf.Focus()

        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()

        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox4.Focus()

        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            rx2_obs.Focus()

        End If
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown

    End Sub

    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'realizo el calculo para obtener la edad del paciente 
            'Dim FechaNacimientoString = DateTimePicker1.Value.ToShortDateString
            ''  MessageBox.Show(FechaNacimientoString)
            'Dim FechaNacimientoDate = DateTime.ParseExact(FechaNacimientoString, "dd/MM/yyyy", Nothing)
            'Dim FechaHoy = DateTime.Now
            'Dim Diferencia = FechaHoy - FechaNacimientoDate
            'Dim Dias = Diferencia.TotalDays
            'Dim Anos = Math.Floor(Dias / 365)
            'edad.Text = Anos

            Dim fecha As Date = DateTimePicker1.Value
            Dim edadpx As Integer = CalcularEdad(fecha)
            edad.Text = edadpx
        End If
    End Sub
    Public Function CalcularEdad(ByVal fechaNacimiento As Date) As Integer

        Dim date1 As Date = CDate(DateTimePicker1.Value)
        Dim date2 As Date = CDate(DateTime.Now)

        Dim edadpx As Integer
        edadpx = date2.Year - date1.Year
        If (fechaNacimiento > Today.AddYears(-edadpx)) Then
            edadpx -= 1
        End If
        Return edadpx
    End Function
End Class