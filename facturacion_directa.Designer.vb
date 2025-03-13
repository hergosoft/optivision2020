<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class facturacion_directa
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChDPI = New System.Windows.Forms.RadioButton()
        Me.ChNIT = New System.Windows.Forms.RadioButton()
        Me.Telefonocliente = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.correo = New System.Windows.Forms.TextBox()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.direccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.TextBox()
        Me.dtv_facturacion = New System.Windows.Forms.DataGridView()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciounitotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuentodt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtv_facturacionsinf = New System.Windows.Forms.DataGridView()
        Me.cantidadsinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigosinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcionsinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuentosinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciosinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtotalsinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiposinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciotsinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalsinIVAsinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tivasinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costosinf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaLinea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.observaciones = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numero = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.dtv_medidas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.grabar1 = New System.Windows.Forms.Label()
        Me.anular = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PrintFactura = New System.Drawing.Printing.PrintDocument()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtv_facturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtv_facturacionsinf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChDPI)
        Me.GroupBox1.Controls.Add(Me.ChNIT)
        Me.GroupBox1.Controls.Add(Me.Telefonocliente)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.correo)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.nit)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nombre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Cliente"
        '
        'ChDPI
        '
        Me.ChDPI.AutoSize = True
        Me.ChDPI.Location = New System.Drawing.Point(61, 21)
        Me.ChDPI.Name = "ChDPI"
        Me.ChDPI.Size = New System.Drawing.Size(44, 19)
        Me.ChDPI.TabIndex = 79
        Me.ChDPI.TabStop = True
        Me.ChDPI.Text = "DPI"
        Me.ChDPI.UseVisualStyleBackColor = True
        '
        'ChNIT
        '
        Me.ChNIT.AutoSize = True
        Me.ChNIT.Checked = True
        Me.ChNIT.Location = New System.Drawing.Point(12, 21)
        Me.ChNIT.Name = "ChNIT"
        Me.ChNIT.Size = New System.Drawing.Size(43, 19)
        Me.ChNIT.TabIndex = 78
        Me.ChNIT.TabStop = True
        Me.ChNIT.Text = "NIT"
        Me.ChNIT.UseVisualStyleBackColor = True
        '
        'Telefonocliente
        '
        Me.Telefonocliente.BackColor = System.Drawing.Color.White
        Me.Telefonocliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Telefonocliente.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Telefonocliente.Location = New System.Drawing.Point(88, 104)
        Me.Telefonocliente.Name = "Telefonocliente"
        Me.Telefonocliente.Size = New System.Drawing.Size(262, 23)
        Me.Telefonocliente.TabIndex = 77
        Me.Telefonocliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Franklin Gothic Demi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Button7.Location = New System.Drawing.Point(473, 40)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(197, 31)
        Me.Button7.TabIndex = 21
        Me.Button7.Text = "CARGAR ORDEN TRAB..."
        Me.Button7.UseVisualStyleBackColor = True
        '
        'correo
        '
        Me.correo.BackColor = System.Drawing.Color.White
        Me.correo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.correo.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.correo.Location = New System.Drawing.Point(421, 104)
        Me.correo.MaxLength = 150
        Me.correo.Name = "correo"
        Me.correo.Size = New System.Drawing.Size(249, 23)
        Me.correo.TabIndex = 20
        Me.correo.Text = "."
        Me.correo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BackColor = System.Drawing.SystemColors.Info
        Me.txt_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_vendedor.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(264, 46)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.ReadOnly = True
        Me.txt_vendedor.Size = New System.Drawing.Size(201, 23)
        Me.txt_vendedor.TabIndex = 17
        Me.txt_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(182, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "VENDEDOR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(356, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "CORREO"
        '
        'nit
        '
        Me.nit.BackColor = System.Drawing.Color.White
        Me.nit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nit.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nit.Location = New System.Drawing.Point(44, 46)
        Me.nit.Name = "nit"
        Me.nit.Size = New System.Drawing.Size(120, 23)
        Me.nit.TabIndex = 3
        Me.nit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NIT"
        '
        'nombre
        '
        Me.nombre.BackColor = System.Drawing.Color.White
        Me.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombre.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.Location = New System.Drawing.Point(75, 75)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(595, 23)
        Me.nombre.TabIndex = 1
        Me.nombre.Text = "CONSUMIDOR FINAL"
        Me.nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(6, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TELEFONO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(6, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOMBRE"
        '
        'direccion
        '
        Me.direccion.BackColor = System.Drawing.Color.White
        Me.direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.direccion.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.direccion.Location = New System.Drawing.Point(1034, 365)
        Me.direccion.Name = "direccion"
        Me.direccion.Size = New System.Drawing.Size(262, 23)
        Me.direccion.TabIndex = 5
        Me.direccion.Text = "CIUDAD"
        Me.direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SlateGray
        Me.Label7.Location = New System.Drawing.Point(174, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "FECHA"
        Me.Label7.Visible = False
        '
        'fecha
        '
        Me.fecha.BackColor = System.Drawing.Color.White
        Me.fecha.Enabled = False
        Me.fecha.Location = New System.Drawing.Point(235, 12)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(137, 20)
        Me.fecha.TabIndex = 18
        Me.fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtv_facturacion
        '
        Me.dtv_facturacion.AllowUserToAddRows = False
        Me.dtv_facturacion.AllowUserToDeleteRows = False
        Me.dtv_facturacion.AllowUserToResizeColumns = False
        Me.dtv_facturacion.AllowUserToResizeRows = False
        Me.dtv_facturacion.BackgroundColor = System.Drawing.Color.White
        Me.dtv_facturacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.dtv_facturacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_facturacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtv_facturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_facturacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidad, Me.codigo, Me.descripcion, Me.PRECIO, Me.preciounitotal, Me.descuentodt, Me.subtotal, Me.costo})
        Me.dtv_facturacion.Location = New System.Drawing.Point(11, 180)
        Me.dtv_facturacion.Name = "dtv_facturacion"
        Me.dtv_facturacion.ReadOnly = True
        Me.dtv_facturacion.RowHeadersVisible = False
        Me.dtv_facturacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtv_facturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_facturacion.Size = New System.Drawing.Size(685, 192)
        Me.dtv_facturacion.TabIndex = 0
        '
        'cantidad
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.cantidad.HeaderText = "CANT."
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 50
        '
        'codigo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 60
        '
        'descripcion
        '
        Me.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        '
        'PRECIO
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.PRECIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRECIO.HeaderText = "PRECIO U."
        Me.PRECIO.Name = "PRECIO"
        Me.PRECIO.ReadOnly = True
        Me.PRECIO.Width = 85
        '
        'preciounitotal
        '
        Me.preciounitotal.HeaderText = "SUBTOTAL"
        Me.preciounitotal.Name = "preciounitotal"
        Me.preciounitotal.ReadOnly = True
        Me.preciounitotal.Width = 85
        '
        'descuentodt
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.descuentodt.DefaultCellStyle = DataGridViewCellStyle5
        Me.descuentodt.HeaderText = "DESCUENTO"
        Me.descuentodt.Name = "descuentodt"
        Me.descuentodt.ReadOnly = True
        Me.descuentodt.Width = 85
        '
        'subtotal
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.subtotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.subtotal.HeaderText = "TOTAL"
        Me.subtotal.Name = "subtotal"
        Me.subtotal.ReadOnly = True
        Me.subtotal.Width = 80
        '
        'costo
        '
        Me.costo.HeaderText = "COSTO"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Berlin Sans FB Demi", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(533, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 31)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Facturacion"
        Me.Label8.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.Font = New System.Drawing.Font("Berlin Sans FB Demi", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox4.Location = New System.Drawing.Point(186, 430)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(132, 35)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Berlin Sans FB Demi", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label5.Location = New System.Drawing.Point(208, 408)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "TOTAL    Q."
        '
        'dtv_facturacionsinf
        '
        Me.dtv_facturacionsinf.AllowUserToAddRows = False
        Me.dtv_facturacionsinf.AllowUserToDeleteRows = False
        Me.dtv_facturacionsinf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_facturacionsinf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidadsinf, Me.codigosinf, Me.descripcionsinf, Me.descuentosinf, Me.preciosinf, Me.subtotalsinf, Me.tiposinf, Me.preciotsinf, Me.TotalsinIVAsinf, Me.tivasinf, Me.costosinf, Me.CuentaLinea})
        Me.dtv_facturacionsinf.Location = New System.Drawing.Point(10, 614)
        Me.dtv_facturacionsinf.Name = "dtv_facturacionsinf"
        Me.dtv_facturacionsinf.ReadOnly = True
        Me.dtv_facturacionsinf.Size = New System.Drawing.Size(1227, 150)
        Me.dtv_facturacionsinf.TabIndex = 17
        '
        'cantidadsinf
        '
        Me.cantidadsinf.HeaderText = "cantidad"
        Me.cantidadsinf.Name = "cantidadsinf"
        Me.cantidadsinf.ReadOnly = True
        '
        'codigosinf
        '
        Me.codigosinf.HeaderText = "codigo"
        Me.codigosinf.Name = "codigosinf"
        Me.codigosinf.ReadOnly = True
        '
        'descripcionsinf
        '
        Me.descripcionsinf.HeaderText = "descripcion"
        Me.descripcionsinf.Name = "descripcionsinf"
        Me.descripcionsinf.ReadOnly = True
        '
        'descuentosinf
        '
        Me.descuentosinf.HeaderText = "descuento"
        Me.descuentosinf.Name = "descuentosinf"
        Me.descuentosinf.ReadOnly = True
        '
        'preciosinf
        '
        Me.preciosinf.HeaderText = "precio"
        Me.preciosinf.Name = "preciosinf"
        Me.preciosinf.ReadOnly = True
        '
        'subtotalsinf
        '
        Me.subtotalsinf.HeaderText = "subtotal"
        Me.subtotalsinf.Name = "subtotalsinf"
        Me.subtotalsinf.ReadOnly = True
        '
        'tiposinf
        '
        Me.tiposinf.HeaderText = "Tipo"
        Me.tiposinf.Name = "tiposinf"
        Me.tiposinf.ReadOnly = True
        '
        'preciotsinf
        '
        Me.preciotsinf.HeaderText = "PrecioTotal"
        Me.preciotsinf.Name = "preciotsinf"
        Me.preciotsinf.ReadOnly = True
        '
        'TotalsinIVAsinf
        '
        Me.TotalsinIVAsinf.HeaderText = "Totalsiniva"
        Me.TotalsinIVAsinf.Name = "TotalsinIVAsinf"
        Me.TotalsinIVAsinf.ReadOnly = True
        '
        'tivasinf
        '
        Me.tivasinf.HeaderText = "TotalIVA"
        Me.tivasinf.Name = "tivasinf"
        Me.tivasinf.ReadOnly = True
        '
        'costosinf
        '
        Me.costosinf.HeaderText = "COSTO"
        Me.costosinf.Name = "costosinf"
        Me.costosinf.ReadOnly = True
        '
        'CuentaLinea
        '
        Me.CuentaLinea.HeaderText = "Contador"
        Me.CuentaLinea.Name = "CuentaLinea"
        Me.CuentaLinea.ReadOnly = True
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.CornflowerBlue
        Me.TextBox5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.White
        Me.TextBox5.Location = New System.Drawing.Point(407, 525)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(132, 32)
        Me.TextBox5.TabIndex = 18
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Berlin Sans FB Demi", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Location = New System.Drawing.Point(270, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(427, 31)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Facturacion Nueva"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Visible = False
        '
        'observaciones
        '
        Me.observaciones.BackColor = System.Drawing.SystemColors.Info
        Me.observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.observaciones.Location = New System.Drawing.Point(126, 378)
        Me.observaciones.Name = "observaciones"
        Me.observaciones.Size = New System.Drawing.Size(570, 20)
        Me.observaciones.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SlateGray
        Me.Label10.Location = New System.Drawing.Point(7, 379)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "OBSERVACIONES"
        '
        'numero
        '
        Me.numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numero.ForeColor = System.Drawing.Color.Red
        Me.numero.Location = New System.Drawing.Point(9, 9)
        Me.numero.Name = "numero"
        Me.numero.Size = New System.Drawing.Size(148, 23)
        Me.numero.TabIndex = 22
        Me.numero.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.CornflowerBlue
        Me.TextBox6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.White
        Me.TextBox6.Location = New System.Drawing.Point(177, 438)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(132, 32)
        Me.TextBox6.TabIndex = 25
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox6.Visible = False
        '
        'dtv_medidas
        '
        Me.dtv_medidas.AllowUserToAddRows = False
        Me.dtv_medidas.AllowUserToDeleteRows = False
        Me.dtv_medidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_medidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dtv_medidas.Location = New System.Drawing.Point(758, 39)
        Me.dtv_medidas.Name = "dtv_medidas"
        Me.dtv_medidas.ReadOnly = True
        Me.dtv_medidas.Size = New System.Drawing.Size(354, 150)
        Me.dtv_medidas.TabIndex = 26
        '
        'Column1
        '
        Me.Column1.HeaderText = "Valor"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Servicio"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 491)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(86, 59)
        Me.Button6.TabIndex = 64
        Me.Button6.Text = "Agregar"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'grabar1
        '
        Me.grabar1.AutoSize = True
        Me.grabar1.Location = New System.Drawing.Point(608, 537)
        Me.grabar1.Name = "grabar1"
        Me.grabar1.Size = New System.Drawing.Size(13, 13)
        Me.grabar1.TabIndex = 65
        Me.grabar1.Text = "0"
        '
        'anular
        '
        Me.anular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.anular.Image = Global.OptiVision_2020.My.Resources.Resources.cancel
        Me.anular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.anular.Location = New System.Drawing.Point(407, 406)
        Me.anular.Name = "anular"
        Me.anular.Size = New System.Drawing.Size(93, 59)
        Me.anular.TabIndex = 67
        Me.anular.Text = "Anular"
        Me.anular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.anular.UseVisualStyleBackColor = True
        Me.anular.Visible = False
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = Global.OptiVision_2020.My.Resources.Resources.printer
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(407, 406)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(93, 59)
        Me.Button8.TabIndex = 66
        Me.Button8.Text = "Re - Imprimir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = Global.OptiVision_2020.My.Resources.Resources.printer
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(758, 415)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(93, 59)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "IMPRIMIR"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Franklin Gothic Demi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.OptiVision_2020.My.Resources.Resources.guardar
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(506, 406)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(93, 59)
        Me.Button4.TabIndex = 27
        Me.Button4.Text = "GRABAR"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Franklin Gothic Demi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(605, 407)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 59)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "CANCELAR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Franklin Gothic Demi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.OptiVision_2020.My.Resources.Resources.registradora
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(407, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 59)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "COBRAR"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Demi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.OptiVision_2020.My.Resources.Resources.mas
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(12, 410)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 59)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "AGREGAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(371, 491)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 69
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(611, 514)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(93, 59)
        Me.Button11.TabIndex = 70
        Me.Button11.Text = "GRABAR"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(892, 208)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(395, 150)
        Me.DataGridView1.TabIndex = 71
        '
        'PrintFactura
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.OptiVision_2020.My.Resources.Resources.Optivision2020_logo
        Me.PictureBox1.Location = New System.Drawing.Point(871, 475)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 59)
        Me.PictureBox1.TabIndex = 72
        Me.PictureBox1.TabStop = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(858, 400)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(92, 40)
        Me.Button9.TabIndex = 73
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(1029, 423)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 74
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1167, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Label13"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1167, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Label14"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1058, 500)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Label15"
        '
        'facturacion_directa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(708, 473)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.dtv_facturacion)
        Me.Controls.Add(Me.direccion)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.anular)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.grabar1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.dtv_medidas)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.numero)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.observaciones)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.dtv_facturacionsinf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(708, 471)
        Me.Name = "facturacion_directa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Documento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtv_facturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtv_facturacionsinf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtv_facturacion As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents correo As System.Windows.Forms.TextBox
    Friend WithEvents dtv_facturacionsinf As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numero As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents dtv_medidas As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents grabar1 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents anular As Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents PRECIO As DataGridViewTextBoxColumn
    Friend WithEvents preciounitotal As DataGridViewTextBoxColumn
    Friend WithEvents descuentodt As DataGridViewTextBoxColumn
    Friend WithEvents subtotal As DataGridViewTextBoxColumn
    Friend WithEvents costo As DataGridViewTextBoxColumn
    Friend WithEvents cantidadsinf As DataGridViewTextBoxColumn
    Friend WithEvents codigosinf As DataGridViewTextBoxColumn
    Friend WithEvents descripcionsinf As DataGridViewTextBoxColumn
    Friend WithEvents descuentosinf As DataGridViewTextBoxColumn
    Friend WithEvents preciosinf As DataGridViewTextBoxColumn
    Friend WithEvents subtotalsinf As DataGridViewTextBoxColumn
    Friend WithEvents tiposinf As DataGridViewTextBoxColumn
    Friend WithEvents preciotsinf As DataGridViewTextBoxColumn
    Friend WithEvents TotalsinIVAsinf As DataGridViewTextBoxColumn
    Friend WithEvents tivasinf As DataGridViewTextBoxColumn
    Friend WithEvents costosinf As DataGridViewTextBoxColumn
    Friend WithEvents CuentaLinea As DataGridViewTextBoxColumn
    Friend WithEvents PrintFactura As Printing.PrintDocument
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Telefonocliente As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ChDPI As RadioButton
    Friend WithEvents ChNIT As RadioButton
End Class
