<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reporte_receta
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.fecha_inicial = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtv_general = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtv_general, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Berlin Sans FB Demi", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(135, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(421, 33)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "// Reporte Orden Trabajo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.fecha_final)
        Me.GroupBox1.Controls.Add(Me.fecha_inicial)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 85)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(291, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Al"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Del"
        '
        'fecha_final
        '
        Me.fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_final.Location = New System.Drawing.Point(331, 45)
        Me.fecha_final.Name = "fecha_final"
        Me.fecha_final.Size = New System.Drawing.Size(200, 24)
        Me.fecha_final.TabIndex = 2
        '
        'fecha_inicial
        '
        Me.fecha_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_inicial.Location = New System.Drawing.Point(73, 45)
        Me.fecha_inicial.Name = "fecha_inicial"
        Me.fecha_inicial.Size = New System.Drawing.Size(200, 24)
        Me.fecha_inicial.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(159, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Por favor seleccione un rago de fechas "
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.OptiVision_2020.My.Resources.Resources.cruzar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(453, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 61)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "CERRAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.OptiVision_2020.My.Resources.Resources.excel_n
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(125, 150)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 61)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "EXPORTAR"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.OptiVision_2020.My.Resources.Resources.binoculares
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(9, 151)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 60)
        Me.Button3.TabIndex = 57
        Me.Button3.Text = "GENERAR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtv_general
        '
        Me.dtv_general.AllowUserToAddRows = False
        Me.dtv_general.AllowUserToDeleteRows = False
        Me.dtv_general.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_general.Location = New System.Drawing.Point(12, 235)
        Me.dtv_general.Name = "dtv_general"
        Me.dtv_general.ReadOnly = True
        Me.dtv_general.Size = New System.Drawing.Size(639, 259)
        Me.dtv_general.TabIndex = 58
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 500)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(639, 139)
        Me.DataGridView1.TabIndex = 59
        '
        'reporte_receta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(549, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dtv_general)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "reporte_receta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte General"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtv_general, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtv_general As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As DataGridView
End Class
