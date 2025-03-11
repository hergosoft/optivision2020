<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busca_hclinica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busca_hclinica))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.buscar = New System.Windows.Forms.Button()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radionombre = New System.Windows.Forms.RadioButton()
        Me.subtitulo = New System.Windows.Forms.Label()
        Me.CheckOperadas = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 122)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(648, 267)
        Me.DataGridView1.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Berlin Sans FB Demi", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label9.Location = New System.Drawing.Point(6, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(300, 31)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Historia Clinica"
        '
        'buscar
        '
        Me.buscar.Font = New System.Drawing.Font("Franklin Gothic Demi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscar.Image = CType(resources.GetObject("buscar.Image"), System.Drawing.Image)
        Me.buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.buscar.Location = New System.Drawing.Point(565, 66)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(95, 50)
        Me.buscar.TabIndex = 25
        Me.buscar.Text = "BUSCAR"
        Me.buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.buscar.UseVisualStyleBackColor = True
        '
        'nombre
        '
        Me.nombre.BackColor = System.Drawing.Color.White
        Me.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.nombre.Location = New System.Drawing.Point(197, 85)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(362, 24)
        Me.nombre.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckOperadas)
        Me.GroupBox1.Controls.Add(Me.radionombre)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 50)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por"
        '
        'radionombre
        '
        Me.radionombre.AutoSize = True
        Me.radionombre.Checked = True
        Me.radionombre.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radionombre.ForeColor = System.Drawing.Color.SlateGray
        Me.radionombre.Location = New System.Drawing.Point(103, 21)
        Me.radionombre.Name = "radionombre"
        Me.radionombre.Size = New System.Drawing.Size(80, 20)
        Me.radionombre.TabIndex = 1
        Me.radionombre.TabStop = True
        Me.radionombre.Text = "NOMBRE"
        Me.radionombre.UseVisualStyleBackColor = True
        '
        'subtitulo
        '
        Me.subtitulo.Font = New System.Drawing.Font("Berlin Sans FB", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitulo.ForeColor = System.Drawing.Color.SlateGray
        Me.subtitulo.Location = New System.Drawing.Point(12, 34)
        Me.subtitulo.Name = "subtitulo"
        Me.subtitulo.Size = New System.Drawing.Size(400, 21)
        Me.subtitulo.TabIndex = 27
        Me.subtitulo.Text = "Doble click sobre el registro para agregar"
        '
        'CheckOperadas
        '
        Me.CheckOperadas.AutoSize = True
        Me.CheckOperadas.Font = New System.Drawing.Font("Berlin Sans FB Demi", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckOperadas.ForeColor = System.Drawing.Color.SlateGray
        Me.CheckOperadas.Location = New System.Drawing.Point(5, 22)
        Me.CheckOperadas.Name = "CheckOperadas"
        Me.CheckOperadas.Size = New System.Drawing.Size(93, 20)
        Me.CheckOperadas.TabIndex = 2
        Me.CheckOperadas.Text = "OPERADAS"
        Me.CheckOperadas.UseVisualStyleBackColor = True
        '
        'busca_hclinica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(669, 397)
        Me.Controls.Add(Me.subtitulo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busca_hclinica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busca Historia Clinica"
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents buscar As System.Windows.Forms.Button
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radionombre As System.Windows.Forms.RadioButton
    Friend WithEvents subtitulo As System.Windows.Forms.Label
    Friend WithEvents CheckOperadas As CheckBox
End Class
