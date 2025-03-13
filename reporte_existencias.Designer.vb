<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reporte_existencias
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtv_temporal = New System.Windows.Forms.DataGridView()
        Me.dtv_final = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Fechar = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Resumidocodigos = New System.Windows.Forms.RadioButton()
        Me.Detalladocodigos = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.descrip_marca = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.familia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.existencias = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.general = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtv_temporal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtv_final, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Berlin Sans FB Demi", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(19, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(589, 37)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "// Reporte de Existencias"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 461)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(204, 150)
        Me.DataGridView1.TabIndex = 16
        '
        'dtv_temporal
        '
        Me.dtv_temporal.AllowUserToAddRows = False
        Me.dtv_temporal.AllowUserToDeleteRows = False
        Me.dtv_temporal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_temporal.Location = New System.Drawing.Point(228, 458)
        Me.dtv_temporal.Name = "dtv_temporal"
        Me.dtv_temporal.ReadOnly = True
        Me.dtv_temporal.Size = New System.Drawing.Size(204, 150)
        Me.dtv_temporal.TabIndex = 17
        '
        'dtv_final
        '
        Me.dtv_final.AllowUserToAddRows = False
        Me.dtv_final.AllowUserToDeleteRows = False
        Me.dtv_final.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_final.Location = New System.Drawing.Point(446, 458)
        Me.dtv_final.Name = "dtv_final"
        Me.dtv_final.ReadOnly = True
        Me.dtv_final.Size = New System.Drawing.Size(204, 150)
        Me.dtv_final.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Fechar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Resumidocodigos)
        Me.GroupBox1.Controls.Add(Me.Detalladocodigos)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 278)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'Fechar
        '
        Me.Fechar.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.Fechar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fechar.Location = New System.Drawing.Point(484, 240)
        Me.Fechar.Name = "Fechar"
        Me.Fechar.Size = New System.Drawing.Size(116, 21)
        Me.Fechar.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Existencias a la fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Lista de Productos:"
        '
        'Resumidocodigos
        '
        Me.Resumidocodigos.AutoSize = True
        Me.Resumidocodigos.Checked = True
        Me.Resumidocodigos.Location = New System.Drawing.Point(146, 241)
        Me.Resumidocodigos.Name = "Resumidocodigos"
        Me.Resumidocodigos.Size = New System.Drawing.Size(82, 19)
        Me.Resumidocodigos.TabIndex = 17
        Me.Resumidocodigos.TabStop = True
        Me.Resumidocodigos.Text = "Resumido"
        Me.Resumidocodigos.UseVisualStyleBackColor = True
        '
        'Detalladocodigos
        '
        Me.Detalladocodigos.AutoSize = True
        Me.Detalladocodigos.Location = New System.Drawing.Point(234, 241)
        Me.Detalladocodigos.Name = "Detalladocodigos"
        Me.Detalladocodigos.Size = New System.Drawing.Size(78, 19)
        Me.Detalladocodigos.TabIndex = 16
        Me.Detalladocodigos.Text = "Detallado"
        Me.Detalladocodigos.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.descrip_marca)
        Me.GroupBox4.Location = New System.Drawing.Point(144, 168)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(447, 45)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        '
        'descrip_marca
        '
        Me.descrip_marca.FormattingEnabled = True
        Me.descrip_marca.Location = New System.Drawing.Point(59, 18)
        Me.descrip_marca.Name = "descrip_marca"
        Me.descrip_marca.Size = New System.Drawing.Size(359, 23)
        Me.descrip_marca.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Selecciona Marca :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.familia)
        Me.GroupBox3.Location = New System.Drawing.Point(144, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(447, 45)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'familia
        '
        Me.familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.familia.FormattingEnabled = True
        Me.familia.Location = New System.Drawing.Point(59, 15)
        Me.familia.Name = "familia"
        Me.familia.Size = New System.Drawing.Size(359, 24)
        Me.familia.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Selecciona Familia : "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.existencias)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Controls.Add(Me.general)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(158, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(427, 45)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'existencias
        '
        Me.existencias.AutoSize = True
        Me.existencias.Checked = True
        Me.existencias.Location = New System.Drawing.Point(99, 15)
        Me.existencias.Name = "existencias"
        Me.existencias.Size = New System.Drawing.Size(73, 20)
        Me.existencias.TabIndex = 7
        Me.existencias.TabStop = True
        Me.existencias.Text = "General"
        Me.existencias.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(200, 15)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(69, 20)
        Me.RadioButton4.TabIndex = 10
        Me.RadioButton4.Text = "Familia"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'general
        '
        Me.general.AutoSize = True
        Me.general.Location = New System.Drawing.Point(302, 15)
        Me.general.Name = "general"
        Me.general.Size = New System.Drawing.Size(63, 20)
        Me.general.TabIndex = 8
        Me.general.Text = "Marca"
        Me.general.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(585, 46)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tenga en cuenta que el reporte puede tardar algunos minutos  dependiendo la canti" &
    "dad de movimientos de cada codigo."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reporte a generar por :"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(491, 370)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 57)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.OptiVision_2020.My.Resources.Resources.excel_n
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(124, 370)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 57)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Exportar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.OptiVision_2020.My.Resources.Resources.binoculares
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(12, 370)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 57)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'reporte_existencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(620, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtv_final)
        Me.Controls.Add(Me.dtv_temporal)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(636, 325)
        Me.Name = "reporte_existencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ";"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtv_temporal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtv_final, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtv_temporal As System.Windows.Forms.DataGridView
    Friend WithEvents dtv_final As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents existencias As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents general As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents familia As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents descrip_marca As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Resumidocodigos As RadioButton
    Friend WithEvents Detalladocodigos As RadioButton
    Friend WithEvents Fechar As DateTimePicker
    Friend WithEvents Label6 As Label
End Class
