<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class muestra_agencia
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtv_agencia = New System.Windows.Forms.DataGridView()
        CType(Me.dtv_agencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtv_agencia
        '
        Me.dtv_agencia.AllowUserToAddRows = False
        Me.dtv_agencia.AllowUserToDeleteRows = False
        Me.dtv_agencia.AllowUserToResizeColumns = False
        Me.dtv_agencia.AllowUserToResizeRows = False
        Me.dtv_agencia.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dtv_agencia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtv_agencia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtv_agencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtv_agencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtv_agencia.Location = New System.Drawing.Point(0, 0)
        Me.dtv_agencia.Name = "dtv_agencia"
        Me.dtv_agencia.ReadOnly = True
        Me.dtv_agencia.RowHeadersVisible = False
        Me.dtv_agencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtv_agencia.Size = New System.Drawing.Size(421, 197)
        Me.dtv_agencia.TabIndex = 0
        '
        'muestra_agencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtv_agencia)
        Me.Name = "muestra_agencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.dtv_agencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtv_agencia As System.Windows.Forms.DataGridView
End Class
