<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class consulta_documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(consulta_documento))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.titulo = New System.Windows.Forms.Label()
        Me.subtitulo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioTelefono = New System.Windows.Forms.RadioButton()
        Me.todas_tiendas = New System.Windows.Forms.CheckBox()
        Me.radionombre = New System.Windows.Forms.RadioButton()
        Me.radionumero = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'titulo
        '
        Me.titulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titulo.Font = New System.Drawing.Font("Berlin Sans FB Demi", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.titulo.Location = New System.Drawing.Point(306, 9)
        Me.titulo.Name = "titulo"
        Me.titulo.Size = New System.Drawing.Size(584, 31)
        Me.titulo.TabIndex = 2
        Me.titulo.Text = "Consulta de Facturas"
        Me.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'subtitulo
        '
        Me.subtitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subtitulo.Font = New System.Drawing.Font("Berlin Sans FB", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitulo.ForeColor = System.Drawing.Color.SlateGray
        Me.subtitulo.Location = New System.Drawing.Point(490, 40)
        Me.subtitulo.Name = "subtitulo"
        Me.subtitulo.Size = New System.Drawing.Size(400, 21)
        Me.subtitulo.TabIndex = 3
        Me.subtitulo.Text = "Doble Click sobre la Factura a Consultar"
        Me.subtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioTelefono)
        Me.GroupBox1.Controls.Add(Me.todas_tiendas)
        Me.GroupBox1.Controls.Add(Me.radionombre)
        Me.GroupBox1.Controls.Add(Me.radionumero)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 50)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por"
        '
        'RadioTelefono
        '
        Me.RadioTelefono.AutoSize = True
        Me.RadioTelefono.Enabled = False
        Me.RadioTelefono.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioTelefono.ForeColor = System.Drawing.Color.SlateGray
        Me.RadioTelefono.Location = New System.Drawing.Point(253, 18)
        Me.RadioTelefono.Name = "RadioTelefono"
        Me.RadioTelefono.Size = New System.Drawing.Size(90, 20)
        Me.RadioTelefono.TabIndex = 4
        Me.RadioTelefono.TabStop = True
        Me.RadioTelefono.Text = "TELEFONO"
        Me.RadioTelefono.UseVisualStyleBackColor = True
        Me.RadioTelefono.Visible = False
        '
        'todas_tiendas
        '
        Me.todas_tiendas.AutoSize = True
        Me.todas_tiendas.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.todas_tiendas.ForeColor = System.Drawing.Color.SlateGray
        Me.todas_tiendas.Location = New System.Drawing.Point(6, 18)
        Me.todas_tiendas.Name = "todas_tiendas"
        Me.todas_tiendas.Size = New System.Drawing.Size(137, 17)
        Me.todas_tiendas.TabIndex = 3
        Me.todas_tiendas.Text = "TODAS LAS TIENDAS"
        Me.todas_tiendas.UseVisualStyleBackColor = True
        Me.todas_tiendas.Visible = False
        '
        'radionombre
        '
        Me.radionombre.AutoSize = True
        Me.radionombre.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radionombre.ForeColor = System.Drawing.Color.SlateGray
        Me.radionombre.Location = New System.Drawing.Point(168, 18)
        Me.radionombre.Name = "radionombre"
        Me.radionombre.Size = New System.Drawing.Size(79, 20)
        Me.radionombre.TabIndex = 1
        Me.radionombre.TabStop = True
        Me.radionombre.Text = "NOMBRE"
        Me.radionombre.UseVisualStyleBackColor = True
        '
        'radionumero
        '
        Me.radionumero.AutoSize = True
        Me.radionumero.Checked = True
        Me.radionumero.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radionumero.ForeColor = System.Drawing.Color.SlateGray
        Me.radionumero.Location = New System.Drawing.Point(7, 18)
        Me.radionumero.Name = "radionumero"
        Me.radionumero.Size = New System.Drawing.Size(140, 20)
        Me.radionumero.TabIndex = 2
        Me.radionumero.TabStop = True
        Me.radionumero.Text = "NUMERO FACTURA"
        Me.radionumero.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TextBox1.Location = New System.Drawing.Point(358, 94)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(442, 24)
        Me.TextBox1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(806, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 50)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "BUSCAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Berlin Sans FB", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 129)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(901, 402)
        Me.DataGridView1.TabIndex = 7
        '
        'consulta_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(908, 528)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.subtitulo)
        Me.Controls.Add(Me.titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(885, 500)
        Me.Name = "consulta_documento"
        Me.Text = "Consulta Documento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents titulo As System.Windows.Forms.Label
    Friend WithEvents subtitulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radionombre As System.Windows.Forms.RadioButton
    Friend WithEvents radionumero As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents todas_tiendas As CheckBox
    Friend WithEvents RadioTelefono As RadioButton
End Class
