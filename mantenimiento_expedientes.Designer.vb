<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mantenimiento_expedientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fecha_nac = New System.Windows.Forms.DateTimePicker()
        Me.edad = New System.Windows.Forms.TextBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.ocupacion = New System.Windows.Forms.TextBox()
        Me.dpi = New System.Windows.Forms.TextBox()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.direccion = New System.Windows.Forms.TextBox()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cargar_historia = New System.Windows.Forms.Button()
        Me.dtv_hclinica = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.historia_completa = New System.Windows.Forms.Button()
        Me.dtv_rx = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.desactivar = New System.Windows.Forms.Button()
        Me.editar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grabar = New System.Windows.Forms.Button()
        Me.NUEVO = New System.Windows.Forms.Button()
        Me.funcion = New System.Windows.Forms.Button()
        Me.ESFERA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CILINDRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EJE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AV_CC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADICION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AV2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DNP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dtv_hclinica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtv_rx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Font = New System.Drawing.Font("Berlin Sans FB Demi", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Location = New System.Drawing.Point(794, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(432, 31)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Control Expedientes //Clientes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.fecha_nac)
        Me.GroupBox1.Controls.Add(Me.edad)
        Me.GroupBox1.Controls.Add(Me.email)
        Me.GroupBox1.Controls.Add(Me.ocupacion)
        Me.GroupBox1.Controls.Add(Me.dpi)
        Me.GroupBox1.Controls.Add(Me.telefono)
        Me.GroupBox1.Controls.Add(Me.direccion)
        Me.GroupBox1.Controls.Add(Me.nombre)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1219, 145)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Paciente"
        '
        'fecha_nac
        '
        Me.fecha_nac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fecha_nac.Font = New System.Drawing.Font("Trebuchet MS", 11.25!)
        Me.fecha_nac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_nac.Location = New System.Drawing.Point(778, 18)
        Me.fecha_nac.Name = "fecha_nac"
        Me.fecha_nac.Size = New System.Drawing.Size(435, 25)
        Me.fecha_nac.TabIndex = 17
        '
        'edad
        '
        Me.edad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.edad.Enabled = False
        Me.edad.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edad.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.edad.Location = New System.Drawing.Point(778, 110)
        Me.edad.Name = "edad"
        Me.edad.Size = New System.Drawing.Size(435, 25)
        Me.edad.TabIndex = 16
        Me.edad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'email
        '
        Me.email.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.email.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.email.Location = New System.Drawing.Point(778, 79)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(435, 25)
        Me.email.TabIndex = 15
        Me.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ocupacion
        '
        Me.ocupacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ocupacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ocupacion.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ocupacion.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.ocupacion.Location = New System.Drawing.Point(778, 48)
        Me.ocupacion.Name = "ocupacion"
        Me.ocupacion.Size = New System.Drawing.Size(435, 25)
        Me.ocupacion.TabIndex = 14
        Me.ocupacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dpi
        '
        Me.dpi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dpi.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpi.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.dpi.Location = New System.Drawing.Point(86, 113)
        Me.dpi.Name = "dpi"
        Me.dpi.Size = New System.Drawing.Size(458, 25)
        Me.dpi.TabIndex = 12
        Me.dpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'telefono
        '
        Me.telefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.telefono.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefono.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.telefono.Location = New System.Drawing.Point(86, 82)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(458, 25)
        Me.telefono.TabIndex = 11
        Me.telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'direccion
        '
        Me.direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.direccion.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.direccion.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.direccion.Location = New System.Drawing.Point(86, 51)
        Me.direccion.Name = "direccion"
        Me.direccion.Size = New System.Drawing.Size(458, 25)
        Me.direccion.TabIndex = 10
        Me.direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nombre
        '
        Me.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombre.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.nombre.Location = New System.Drawing.Point(86, 19)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(458, 25)
        Me.nombre.TabIndex = 9
        Me.nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label8.Location = New System.Drawing.Point(692, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 28)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "EDAD"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(5, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 28)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "DPI"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(692, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 28)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "EMAIL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(692, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 28)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "OCUPACION"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(692, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 28)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "FECHA NAC."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "TELEFONO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 28)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "DIRECCION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NOMBRE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.cargar_historia)
        Me.GroupBox4.Controls.Add(Me.dtv_hclinica)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 369)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1219, 195)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "HISTORIAS CLINICAS"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(1085, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 56)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Cargar Historia Clinica"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cargar_historia
        '
        Me.cargar_historia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cargar_historia.Enabled = False
        Me.cargar_historia.Location = New System.Drawing.Point(1085, 111)
        Me.cargar_historia.Name = "cargar_historia"
        Me.cargar_historia.Size = New System.Drawing.Size(128, 55)
        Me.cargar_historia.TabIndex = 1
        Me.cargar_historia.Text = "Ingresar Historia Clinica"
        Me.cargar_historia.UseVisualStyleBackColor = True
        '
        'dtv_hclinica
        '
        Me.dtv_hclinica.AllowUserToAddRows = False
        Me.dtv_hclinica.AllowUserToDeleteRows = False
        Me.dtv_hclinica.AllowUserToResizeColumns = False
        Me.dtv_hclinica.AllowUserToResizeRows = False
        Me.dtv_hclinica.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtv_hclinica.BackgroundColor = System.Drawing.Color.White
        Me.dtv_hclinica.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Berlin Sans FB", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_hclinica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtv_hclinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_hclinica.GridColor = System.Drawing.Color.White
        Me.dtv_hclinica.Location = New System.Drawing.Point(5, 19)
        Me.dtv_hclinica.MultiSelect = False
        Me.dtv_hclinica.Name = "dtv_hclinica"
        Me.dtv_hclinica.ReadOnly = True
        Me.dtv_hclinica.RowHeadersVisible = False
        Me.dtv_hclinica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_hclinica.Size = New System.Drawing.Size(1074, 170)
        Me.dtv_hclinica.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.historia_completa)
        Me.GroupBox2.Controls.Add(Me.dtv_rx)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 249)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1219, 104)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RX FINAL"
        '
        'historia_completa
        '
        Me.historia_completa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.historia_completa.BackColor = System.Drawing.Color.White
        Me.historia_completa.Enabled = False
        Me.historia_completa.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.historia_completa.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.historia_completa.ForeColor = System.Drawing.SystemColors.Highlight
        Me.historia_completa.Image = Global.OptiVision_2020.My.Resources.Resources.checklist
        Me.historia_completa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.historia_completa.Location = New System.Drawing.Point(1085, 16)
        Me.historia_completa.Name = "historia_completa"
        Me.historia_completa.Size = New System.Drawing.Size(128, 81)
        Me.historia_completa.TabIndex = 32
        Me.historia_completa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.historia_completa.UseVisualStyleBackColor = False
        '
        'dtv_rx
        '
        Me.dtv_rx.AllowUserToAddRows = False
        Me.dtv_rx.AllowUserToDeleteRows = False
        Me.dtv_rx.AllowUserToResizeColumns = False
        Me.dtv_rx.AllowUserToResizeRows = False
        Me.dtv_rx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtv_rx.BackgroundColor = System.Drawing.Color.White
        Me.dtv_rx.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Berlin Sans FB", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_rx.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtv_rx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_rx.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ESFERA, Me.CILINDRO, Me.EJE, Me.AV_CC, Me.ADICION, Me.AV2, Me.DNP})
        Me.dtv_rx.Location = New System.Drawing.Point(100, 19)
        Me.dtv_rx.Name = "dtv_rx"
        Me.dtv_rx.ReadOnly = True
        Me.dtv_rx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_rx.Size = New System.Drawing.Size(979, 76)
        Me.dtv_rx.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.Location = New System.Drawing.Point(6, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "OJO IZQUIERDO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Location = New System.Drawing.Point(6, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "OJO DERECHO"
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Button4.Image = Global.OptiVision_2020.My.Resources.Resources.refresh
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(461, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(69, 60)
        Me.Button4.TabIndex = 44
        Me.Button4.Text = "Refrescar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'desactivar
        '
        Me.desactivar.Enabled = False
        Me.desactivar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.desactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.desactivar.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desactivar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.desactivar.Image = Global.OptiVision_2020.My.Resources.Resources.locationoff
        Me.desactivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.desactivar.Location = New System.Drawing.Point(386, 12)
        Me.desactivar.Name = "desactivar"
        Me.desactivar.Size = New System.Drawing.Size(69, 60)
        Me.desactivar.TabIndex = 43
        Me.desactivar.Text = "Eliminar"
        Me.desactivar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.desactivar.UseVisualStyleBackColor = True
        '
        'editar
        '
        Me.editar.Enabled = False
        Me.editar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editar.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.editar.Image = Global.OptiVision_2020.My.Resources.Resources.lapiz
        Me.editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.editar.Location = New System.Drawing.Point(311, 12)
        Me.editar.Name = "editar"
        Me.editar.Size = New System.Drawing.Size(69, 60)
        Me.editar.TabIndex = 42
        Me.editar.Text = "Editar"
        Me.editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.editar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Button2.Image = Global.OptiVision_2020.My.Resources.Resources.binoculares
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(87, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 60)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Buscar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.Image = Global.OptiVision_2020.My.Resources.Resources.mas
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(162, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 60)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Nuevo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grabar
        '
        Me.grabar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grabar.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grabar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.grabar.Image = Global.OptiVision_2020.My.Resources.Resources.guardar
        Me.grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.grabar.Location = New System.Drawing.Point(237, 12)
        Me.grabar.Name = "grabar"
        Me.grabar.Size = New System.Drawing.Size(69, 60)
        Me.grabar.TabIndex = 36
        Me.grabar.Text = "Grabar"
        Me.grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.grabar.UseVisualStyleBackColor = True
        '
        'NUEVO
        '
        Me.NUEVO.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.NUEVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NUEVO.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUEVO.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.NUEVO.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.NUEVO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.NUEVO.Location = New System.Drawing.Point(12, 12)
        Me.NUEVO.Name = "NUEVO"
        Me.NUEVO.Size = New System.Drawing.Size(69, 60)
        Me.NUEVO.TabIndex = 35
        Me.NUEVO.Text = "Cerrar"
        Me.NUEVO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.NUEVO.UseVisualStyleBackColor = True
        '
        'funcion
        '
        Me.funcion.Location = New System.Drawing.Point(559, 910)
        Me.funcion.Name = "funcion"
        Me.funcion.Size = New System.Drawing.Size(133, 35)
        Me.funcion.TabIndex = 45
        Me.funcion.Text = "Funciones"
        Me.funcion.UseVisualStyleBackColor = True
        '
        'ESFERA
        '
        Me.ESFERA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ESFERA.HeaderText = "ESFERA"
        Me.ESFERA.Name = "ESFERA"
        Me.ESFERA.ReadOnly = True
        '
        'CILINDRO
        '
        Me.CILINDRO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CILINDRO.HeaderText = "CILINDRO"
        Me.CILINDRO.Name = "CILINDRO"
        Me.CILINDRO.ReadOnly = True
        '
        'EJE
        '
        Me.EJE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EJE.HeaderText = "EJE"
        Me.EJE.Name = "EJE"
        Me.EJE.ReadOnly = True
        '
        'AV_CC
        '
        Me.AV_CC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AV_CC.HeaderText = "AV"
        Me.AV_CC.Name = "AV_CC"
        Me.AV_CC.ReadOnly = True
        '
        'ADICION
        '
        Me.ADICION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ADICION.HeaderText = "ADICION"
        Me.ADICION.Name = "ADICION"
        Me.ADICION.ReadOnly = True
        '
        'AV2
        '
        Me.AV2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AV2.HeaderText = "AV"
        Me.AV2.Name = "AV2"
        Me.AV2.ReadOnly = True
        '
        'DNP
        '
        Me.DNP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DNP.HeaderText = "DNP"
        Me.DNP.Name = "DNP"
        Me.DNP.ReadOnly = True
        '
        'mantenimiento_expedientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1238, 944)
        Me.Controls.Add(Me.funcion)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.desactivar)
        Me.Controls.Add(Me.editar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grabar)
        Me.Controls.Add(Me.NUEVO)
        Me.Controls.Add(Me.Label9)
        Me.Name = "mantenimiento_expedientes"
        Me.Text = "Mantenimiento Expedientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dtv_hclinica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtv_rx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grabar As System.Windows.Forms.Button
    Friend WithEvents NUEVO As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents edad As System.Windows.Forms.TextBox
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents ocupacion As System.Windows.Forms.TextBox
    Friend WithEvents dpi As System.Windows.Forms.TextBox
    Friend WithEvents telefono As System.Windows.Forms.TextBox
    Friend WithEvents direccion As System.Windows.Forms.TextBox
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cargar_historia As System.Windows.Forms.Button
    Friend WithEvents dtv_hclinica As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents historia_completa As System.Windows.Forms.Button
    Friend WithEvents dtv_rx As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents desactivar As System.Windows.Forms.Button
    Friend WithEvents editar As System.Windows.Forms.Button
    Friend WithEvents funcion As System.Windows.Forms.Button
    Friend WithEvents fecha_nac As DateTimePicker
    Friend WithEvents ESFERA As DataGridViewTextBoxColumn
    Friend WithEvents CILINDRO As DataGridViewTextBoxColumn
    Friend WithEvents EJE As DataGridViewTextBoxColumn
    Friend WithEvents AV_CC As DataGridViewTextBoxColumn
    Friend WithEvents ADICION As DataGridViewTextBoxColumn
    Friend WithEvents AV2 As DataGridViewTextBoxColumn
    Friend WithEvents DNP As DataGridViewTextBoxColumn
End Class
