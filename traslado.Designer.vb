<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class traslado
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(traslado))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.obs = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.documento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.agencia_recibe = New System.Windows.Forms.TextBox()
        Me.no_agencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtv_traslado = New System.Windows.Forms.DataGridView()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_agrega = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.buscar = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtv_traslado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Font = New System.Drawing.Font("Berlin Sans FB Demi", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Location = New System.Drawing.Point(256, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(355, 31)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Ingreso Traslado"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureBox1.Location = New System.Drawing.Point(-5, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(630, 72)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.obs)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.documento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.agencia_recibe)
        Me.GroupBox1.Controls.Add(Me.no_agencia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 73)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'obs
        '
        Me.obs.BackColor = System.Drawing.SystemColors.Info
        Me.obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obs.Location = New System.Drawing.Point(210, 42)
        Me.obs.Name = "obs"
        Me.obs.Size = New System.Drawing.Size(392, 21)
        Me.obs.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Obs."
        '
        'fecha
        '
        Me.fecha.Location = New System.Drawing.Point(54, 45)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(111, 21)
        Me.fecha.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha"
        '
        'documento
        '
        Me.documento.AutoSize = True
        Me.documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.documento.ForeColor = System.Drawing.Color.Red
        Me.documento.Location = New System.Drawing.Point(583, 16)
        Me.documento.Name = "documento"
        Me.documento.Size = New System.Drawing.Size(15, 15)
        Me.documento.TabIndex = 7
        Me.documento.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(477, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Documento No."
        '
        'agencia_recibe
        '
        Me.agencia_recibe.Enabled = False
        Me.agencia_recibe.Location = New System.Drawing.Point(172, 13)
        Me.agencia_recibe.Name = "agencia_recibe"
        Me.agencia_recibe.Size = New System.Drawing.Size(299, 21)
        Me.agencia_recibe.TabIndex = 5
        '
        'no_agencia
        '
        Me.no_agencia.BackColor = System.Drawing.SystemColors.Info
        Me.no_agencia.Location = New System.Drawing.Point(127, 13)
        Me.no_agencia.Name = "no_agencia"
        Me.no_agencia.Size = New System.Drawing.Size(38, 21)
        Me.no_agencia.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Agencia Recibe No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtv_traslado)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 153)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 199)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'dtv_traslado
        '
        Me.dtv_traslado.AllowUserToAddRows = False
        Me.dtv_traslado.AllowUserToDeleteRows = False
        Me.dtv_traslado.AllowUserToResizeColumns = False
        Me.dtv_traslado.AllowUserToResizeRows = False
        Me.dtv_traslado.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dtv_traslado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Corbel", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_traslado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtv_traslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_traslado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidad, Me.codigo, Me.descripcion})
        Me.dtv_traslado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtv_traslado.Location = New System.Drawing.Point(3, 16)
        Me.dtv_traslado.MultiSelect = False
        Me.dtv_traslado.Name = "dtv_traslado"
        Me.dtv_traslado.ReadOnly = True
        Me.dtv_traslado.RowHeadersVisible = False
        Me.dtv_traslado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_traslado.Size = New System.Drawing.Size(602, 180)
        Me.dtv_traslado.TabIndex = 0
        '
        'cantidad
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle8
        Me.cantidad.HeaderText = "CANTIDAD"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'codigo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle9
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        '
        'descripcion
        '
        Me.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.btn_agrega)
        Me.GroupBox3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 355)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(608, 83)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Acciones"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(257, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(513, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 55)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Salir"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Image = Global.OptiVision_2020.My.Resources.Resources.guardar
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(410, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 55)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Grabar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = Global.OptiVision_2020.My.Resources.Resources.locationoff
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(85, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 56)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Eliminar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_agrega
        '
        Me.btn_agrega.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_agrega.ForeColor = System.Drawing.Color.Black
        Me.btn_agrega.Image = Global.OptiVision_2020.My.Resources.Resources.mas
        Me.btn_agrega.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agrega.Location = New System.Drawing.Point(9, 18)
        Me.btn_agrega.Name = "btn_agrega"
        Me.btn_agrega.Size = New System.Drawing.Size(70, 56)
        Me.btn_agrega.TabIndex = 0
        Me.btn_agrega.Text = "Agregar"
        Me.btn_agrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agrega.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'buscar
        '
        Me.buscar.Location = New System.Drawing.Point(670, 279)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(75, 23)
        Me.buscar.TabIndex = 5
        Me.buscar.Text = "buscar"
        Me.buscar.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowCurrentPage = True
        Me.PrintDialog1.ShowNetwork = False
        Me.PrintDialog1.UseEXDialog = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 26
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.OptiVision_2020.My.Resources.Resources.printer
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripButton1.Text = "Imprimir"
        '
        'traslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(617, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(633, 481)
        Me.Name = "traslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslados"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtv_traslado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents obs As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents documento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents agencia_recibe As System.Windows.Forms.TextBox
    Friend WithEvents no_agencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtv_traslado As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_agrega As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buscar As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
