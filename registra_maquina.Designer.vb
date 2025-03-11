<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registra_maquina
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
        Me.components = New System.ComponentModel.Container()
        Me.agencia = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.version = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SO = New System.Windows.Forms.TextBox()
        Me.serial1 = New System.Windows.Forms.TextBox()
        Me.equipo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.sucursal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'agencia
        '
        Me.agencia.AutoSize = True
        Me.agencia.ForeColor = System.Drawing.Color.Red
        Me.agencia.Location = New System.Drawing.Point(8, 34)
        Me.agencia.Name = "agencia"
        Me.agencia.Size = New System.Drawing.Size(39, 13)
        Me.agencia.TabIndex = 15
        Me.agencia.Text = "Label7"
        Me.agencia.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Berlin Sans FB Demi", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(303, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 24)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "//REGISTRA EQUIPO"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(15, 161)
        Me.ProgressBar.Maximum = 5
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(489, 21)
        Me.ProgressBar.TabIndex = 13
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.Optica_Sosa.My.Resources.Resources.guardar
        Me.Button3.Location = New System.Drawing.Point(206, 209)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 56)
        Me.Button3.TabIndex = 12
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.Optica_Sosa.My.Resources.Resources.inbox
        Me.Button2.Location = New System.Drawing.Point(12, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 56)
        Me.Button2.TabIndex = 11
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.Optica_Sosa.My.Resources.Resources.cruzar
        Me.Button1.Location = New System.Drawing.Point(376, 206)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 56)
        Me.Button1.TabIndex = 10
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.version)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.SO)
        Me.GroupBox1.Controls.Add(Me.serial1)
        Me.GroupBox1.Controls.Add(Me.equipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.sucursal)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 93)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'version
        '
        Me.version.Location = New System.Drawing.Point(141, 67)
        Me.version.Name = "version"
        Me.version.ReadOnly = True
        Me.version.Size = New System.Drawing.Size(131, 20)
        Me.version.TabIndex = 9
        Me.version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(178, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "VERSION"
        '
        'SO
        '
        Me.SO.Location = New System.Drawing.Point(290, 67)
        Me.SO.Name = "SO"
        Me.SO.ReadOnly = True
        Me.SO.Size = New System.Drawing.Size(196, 20)
        Me.SO.TabIndex = 7
        Me.SO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'serial1
        '
        Me.serial1.Location = New System.Drawing.Point(6, 67)
        Me.serial1.Name = "serial1"
        Me.serial1.ReadOnly = True
        Me.serial1.Size = New System.Drawing.Size(113, 20)
        Me.serial1.TabIndex = 6
        Me.serial1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'equipo
        '
        Me.equipo.Location = New System.Drawing.Point(361, 17)
        Me.equipo.Name = "equipo"
        Me.equipo.ReadOnly = True
        Me.equipo.Size = New System.Drawing.Size(125, 20)
        Me.equipo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(301, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "EQUIPO"
        '
        'sucursal
        '
        Me.sucursal.Location = New System.Drawing.Point(86, 17)
        Me.sucursal.Name = "sucursal"
        Me.sucursal.ReadOnly = True
        Me.sucursal.Size = New System.Drawing.Size(186, 20)
        Me.sucursal.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(328, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SISTEMA OPERATIVO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(36, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SERIAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SUCURSAL"
        '
        'Timer1
        '
        '
        'registra_maquina
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(529, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.agencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "registra_maquina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents agencia As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents version As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents SO As TextBox
    Friend WithEvents serial1 As TextBox
    Friend WithEvents equipo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents sucursal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
End Class
