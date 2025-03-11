<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class recibos_nuevo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.armazon = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.nit = New System.Windows.Forms.TextBox()
        Me.marca = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.f_prometida = New System.Windows.Forms.MaskedTextBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nombrepf = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.t_cobrado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.saldo_pendiente = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.anterior = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tarjeta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.total = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.efectivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.material = New System.Windows.Forms.TextBox()
        Me.enletras = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numero = New System.Windows.Forms.Label()
        Me.dtv_medidas = New System.Windows.Forms.DataGridView()
        Me.fecha_enletras = New System.Windows.Forms.Label()
        Me.print_tiket = New System.Drawing.Printing.PrintDocument()
        Me.Advertencia = New System.Windows.Forms.Label()
        Me.Advertencia1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Berlin Sans FB Demi", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(226, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(478, 33)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "// Recibo de Pago"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.armazon)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.nit)
        Me.GroupBox1.Controls.Add(Me.marca)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.telefono)
        Me.GroupBox1.Controls.Add(Me.f_prometida)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.nombrepf)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.obs)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(686, 459)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.SlateGray
        Me.Label19.Location = New System.Drawing.Point(6, 172)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 18)
        Me.Label19.TabIndex = 83
        Me.Label19.Text = "Asesor"
        '
        'armazon
        '
        Me.armazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.armazon.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.armazon.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.armazon.Location = New System.Drawing.Point(45, 125)
        Me.armazon.Name = "armazon"
        Me.armazon.Size = New System.Drawing.Size(303, 25)
        Me.armazon.TabIndex = 82
        Me.armazon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.SlateGray
        Me.Label18.Location = New System.Drawing.Point(6, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 18)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Aro"
        '
        'nit
        '
        Me.nit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nit.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nit.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.nit.Location = New System.Drawing.Point(84, 83)
        Me.nit.Name = "nit"
        Me.nit.Size = New System.Drawing.Size(129, 25)
        Me.nit.TabIndex = 80
        Me.nit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'marca
        '
        Me.marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.marca.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.marca.Location = New System.Drawing.Point(456, 125)
        Me.marca.Name = "marca"
        Me.marca.Size = New System.Drawing.Size(218, 25)
        Me.marca.TabIndex = 76
        Me.marca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.SlateGray
        Me.Label16.Location = New System.Drawing.Point(6, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 18)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "NIT P/F."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.SlateGray
        Me.Label15.Location = New System.Drawing.Point(372, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 18)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Aro Marca"
        '
        'telefono
        '
        Me.telefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.telefono.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefono.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.telefono.Location = New System.Drawing.Point(90, 49)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(187, 25)
        Me.telefono.TabIndex = 74
        Me.telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'f_prometida
        '
        Me.f_prometida.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_prometida.Location = New System.Drawing.Point(484, 49)
        Me.f_prometida.Mask = "00-00-0000"
        Me.f_prometida.Name = "f_prometida"
        Me.f_prometida.Size = New System.Drawing.Size(190, 25)
        Me.f_prometida.TabIndex = 73
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BackColor = System.Drawing.SystemColors.Info
        Me.txt_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_vendedor.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(66, 167)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(608, 23)
        Me.txt_vendedor.TabIndex = 8
        Me.txt_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SlateGray
        Me.Label14.Location = New System.Drawing.Point(346, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 18)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Fecha Prometida:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.SlateGray
        Me.Label13.Location = New System.Drawing.Point(6, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 18)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Telefono"
        '
        'nombrepf
        '
        Me.nombrepf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombrepf.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrepf.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.nombrepf.Location = New System.Drawing.Point(340, 83)
        Me.nombrepf.Name = "nombrepf"
        Me.nombrepf.ReadOnly = True
        Me.nombrepf.Size = New System.Drawing.Size(334, 25)
        Me.nombrepf.TabIndex = 67
        Me.nombrepf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.t_cobrado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.saldo_pendiente)
        Me.GroupBox3.Font = New System.Drawing.Font("Berlin Sans FB", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(280, 306)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(394, 75)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        '
        't_cobrado
        '
        Me.t_cobrado.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_cobrado.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.t_cobrado.Location = New System.Drawing.Point(7, 42)
        Me.t_cobrado.Name = "t_cobrado"
        Me.t_cobrado.ReadOnly = True
        Me.t_cobrado.Size = New System.Drawing.Size(165, 22)
        Me.t_cobrado.TabIndex = 66
        Me.t_cobrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(42, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 18)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Total Cobrado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Teal
        Me.Label10.Location = New System.Drawing.Point(229, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 18)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Saldo Pendiente Q."
        '
        'saldo_pendiente
        '
        Me.saldo_pendiente.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saldo_pendiente.ForeColor = System.Drawing.Color.Red
        Me.saldo_pendiente.Location = New System.Drawing.Point(217, 40)
        Me.saldo_pendiente.Name = "saldo_pendiente"
        Me.saldo_pendiente.ReadOnly = True
        Me.saldo_pendiente.Size = New System.Drawing.Size(168, 24)
        Me.saldo_pendiente.TabIndex = 63
        Me.saldo_pendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SlateGray
        Me.Label12.Location = New System.Drawing.Point(237, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 18)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Nombre P/F."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.anterior)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.tarjeta)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.total)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.efectivo)
        Me.GroupBox2.Font = New System.Drawing.Font("Berlin Sans FB", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(6, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 238)
        Me.GroupBox2.TabIndex = 63
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Forma de Pago"
        '
        'anterior
        '
        Me.anterior.Font = New System.Drawing.Font("Berlin Sans FB Demi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.anterior.ForeColor = System.Drawing.Color.Red
        Me.anterior.Location = New System.Drawing.Point(133, 193)
        Me.anterior.Name = "anterior"
        Me.anterior.ReadOnly = True
        Me.anterior.Size = New System.Drawing.Size(117, 26)
        Me.anterior.TabIndex = 68
        Me.anterior.Text = "0"
        Me.anterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.anterior.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(10, 178)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 43)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "Abonos Anteriores Q."
        Me.Label20.Visible = False
        '
        'tarjeta
        '
        Me.tarjeta.Font = New System.Drawing.Font("Berlin Sans FB Demi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tarjeta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tarjeta.Location = New System.Drawing.Point(133, 138)
        Me.tarjeta.Name = "tarjeta"
        Me.tarjeta.Size = New System.Drawing.Size(117, 26)
        Me.tarjeta.TabIndex = 66
        Me.tarjeta.Text = "0"
        Me.tarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(10, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 27)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Tarjeta Q."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(10, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 18)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Total Compra  Q."
        '
        'total
        '
        Me.total.Font = New System.Drawing.Font("Berlin Sans FB Demi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.total.Location = New System.Drawing.Point(143, 56)
        Me.total.Name = "total"
        Me.total.Size = New System.Drawing.Size(107, 26)
        Me.total.TabIndex = 61
        Me.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(10, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 24)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Efectivo Q."
        '
        'efectivo
        '
        Me.efectivo.Font = New System.Drawing.Font("Berlin Sans FB Demi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.efectivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.efectivo.Location = New System.Drawing.Point(133, 96)
        Me.efectivo.Name = "efectivo"
        Me.efectivo.Size = New System.Drawing.Size(117, 26)
        Me.efectivo.TabIndex = 0
        Me.efectivo.Text = "0"
        Me.efectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(449, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 18)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "CONCEPTO"
        '
        'nombre
        '
        Me.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombre.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.nombre.Location = New System.Drawing.Point(84, 16)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(587, 25)
        Me.nombre.TabIndex = 5
        Me.nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Paciente"
        '
        'obs
        '
        Me.obs.BackColor = System.Drawing.SystemColors.Info
        Me.obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obs.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obs.Location = New System.Drawing.Point(280, 218)
        Me.obs.MaxLength = 95
        Me.obs.Multiline = True
        Me.obs.Name = "obs"
        Me.obs.Size = New System.Drawing.Size(394, 82)
        Me.obs.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.SlateGray
        Me.Label17.Location = New System.Drawing.Point(850, 418)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 18)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Lente"
        '
        'material
        '
        Me.material.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.material.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.material.Location = New System.Drawing.Point(905, 414)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(368, 25)
        Me.material.TabIndex = 78
        Me.material.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'enletras
        '
        Me.enletras.Enabled = False
        Me.enletras.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enletras.Location = New System.Drawing.Point(538, 706)
        Me.enletras.Name = "enletras"
        Me.enletras.Size = New System.Drawing.Size(332, 23)
        Me.enletras.TabIndex = 6
        Me.enletras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(480, 712)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "En Letras"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(480, 652)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Fecha"
        Me.Label5.Visible = False
        '
        'fecha
        '
        Me.fecha.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.Location = New System.Drawing.Point(523, 646)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(137, 23)
        Me.fecha.TabIndex = 59
        Me.fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.fecha.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(588, 596)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Vendedor"
        Me.Label6.Visible = False
        '
        'numero
        '
        Me.numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero.ForeColor = System.Drawing.Color.Red
        Me.numero.Location = New System.Drawing.Point(506, 35)
        Me.numero.Name = "numero"
        Me.numero.Size = New System.Drawing.Size(185, 23)
        Me.numero.TabIndex = 60
        Me.numero.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtv_medidas
        '
        Me.dtv_medidas.AllowUserToAddRows = False
        Me.dtv_medidas.AllowUserToDeleteRows = False
        Me.dtv_medidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_medidas.Location = New System.Drawing.Point(18, 623)
        Me.dtv_medidas.Name = "dtv_medidas"
        Me.dtv_medidas.ReadOnly = True
        Me.dtv_medidas.Size = New System.Drawing.Size(435, 150)
        Me.dtv_medidas.TabIndex = 61
        '
        'fecha_enletras
        '
        Me.fecha_enletras.AutoSize = True
        Me.fecha_enletras.Location = New System.Drawing.Point(480, 747)
        Me.fecha_enletras.Name = "fecha_enletras"
        Me.fecha_enletras.Size = New System.Drawing.Size(45, 13)
        Me.fecha_enletras.TabIndex = 62
        Me.fecha_enletras.Text = "Label15"
        '
        'print_tiket
        '
        '
        'Advertencia
        '
        Me.Advertencia.AutoSize = True
        Me.Advertencia.BackColor = System.Drawing.Color.White
        Me.Advertencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Advertencia.ForeColor = System.Drawing.Color.Red
        Me.Advertencia.Location = New System.Drawing.Point(19, 41)
        Me.Advertencia.Name = "Advertencia"
        Me.Advertencia.Size = New System.Drawing.Size(0, 15)
        Me.Advertencia.TabIndex = 80
        '
        'Advertencia1
        '
        Me.Advertencia1.AutoSize = True
        Me.Advertencia1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Advertencia1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Advertencia1.Location = New System.Drawing.Point(15, 16)
        Me.Advertencia1.Name = "Advertencia1"
        Me.Advertencia1.Size = New System.Drawing.Size(0, 15)
        Me.Advertencia1.TabIndex = 81
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Optica_Sosa.My.Resources.Resources.qr_atencionalcliente
        Me.PictureBox2.Location = New System.Drawing.Point(769, 276)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox2.TabIndex = 64
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Optica_Sosa.My.Resources.Resources.Logo_Ososa
        Me.PictureBox1.Location = New System.Drawing.Point(823, 180)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.Optica_Sosa.My.Resources.Resources.printer
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(405, 387)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 59)
        Me.Button3.TabIndex = 62
        Me.Button3.Text = "IMPRIMIR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Optica_Sosa.My.Resources.Resources.guardar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(497, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 59)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "GRABAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.Optica_Sosa.My.Resources.Resources.cruzar
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(588, 387)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 59)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "CANCELAR"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'recibos_nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(716, 522)
        Me.ControlBox = False
        Me.Controls.Add(Me.Advertencia1)
        Me.Controls.Add(Me.Advertencia)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.fecha_enletras)
        Me.Controls.Add(Me.dtv_medidas)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.numero)
        Me.Controls.Add(Me.material)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.enletras)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(716, 464)
        Me.Name = "recibos_nuevo"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Recibo"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents efectivo As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents enletras As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obs As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.TextBox
    Friend WithEvents numero As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents saldo_pendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents total As System.Windows.Forms.TextBox
    Friend WithEvents dtv_medidas As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents t_cobrado As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nombrepf As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents f_prometida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents fecha_enletras As System.Windows.Forms.Label
    Friend WithEvents telefono As System.Windows.Forms.TextBox
    Friend WithEvents armazon As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents nit As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents material As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents marca As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents print_tiket As Printing.PrintDocument
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents anterior As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Advertencia As Label
    Friend WithEvents Advertencia1 As Label
End Class
