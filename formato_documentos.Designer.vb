<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formato_documentos
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
        Me.titulo = New System.Windows.Forms.Label()
        Me.dtv_medidas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cerrar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'titulo
        '
        Me.titulo.BackColor = System.Drawing.Color.White
        Me.titulo.Font = New System.Drawing.Font("Berlin Sans FB Demi", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.titulo.Location = New System.Drawing.Point(225, 13)
        Me.titulo.Name = "titulo"
        Me.titulo.Size = New System.Drawing.Size(321, 24)
        Me.titulo.TabIndex = 15
        Me.titulo.Text = "Formato Orden Laboratorio"
        Me.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtv_medidas
        '
        Me.dtv_medidas.AllowUserToAddRows = False
        Me.dtv_medidas.AllowUserToDeleteRows = False
        Me.dtv_medidas.AllowUserToResizeColumns = False
        Me.dtv_medidas.AllowUserToResizeRows = False
        Me.dtv_medidas.BackgroundColor = System.Drawing.Color.White
        Me.dtv_medidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_medidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtv_medidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_medidas.Location = New System.Drawing.Point(8, 73)
        Me.dtv_medidas.MultiSelect = False
        Me.dtv_medidas.Name = "dtv_medidas"
        Me.dtv_medidas.ReadOnly = True
        Me.dtv_medidas.RowHeadersVisible = False
        Me.dtv_medidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_medidas.Size = New System.Drawing.Size(538, 308)
        Me.dtv_medidas.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(294, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Por favor ingrese las medidas en milimetros"
        '
        'cerrar
        '
        Me.cerrar.BackColor = System.Drawing.Color.White
        Me.cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cerrar.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.cerrar.Location = New System.Drawing.Point(469, 387)
        Me.cerrar.Name = "cerrar"
        Me.cerrar.Size = New System.Drawing.Size(72, 51)
        Me.cerrar.TabIndex = 17
        Me.cerrar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(579, 72)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'formato_documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(553, 443)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cerrar)
        Me.Controls.Add(Me.dtv_medidas)
        Me.Controls.Add(Me.titulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "formato_documentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.dtv_medidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents titulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtv_medidas As System.Windows.Forms.DataGridView
    Friend WithEvents cerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
