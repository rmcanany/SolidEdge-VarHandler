<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_WorkFlowEvent
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TLP = New System.Windows.Forms.TableLayoutPanel()
        Me.DG_Variables = New System.Windows.Forms.DataGridView()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VarName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VarValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LB_SEQ = New System.Windows.Forms.Label()
        Me.TLP.SuspendLayout()
        CType(Me.DG_Variables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TLP
        '
        Me.TLP.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TLP.ColumnCount = 2
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP.Controls.Add(Me.DG_Variables, 1, 0)
        Me.TLP.Controls.Add(Me.LB_SEQ, 0, 0)
        Me.TLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP.Location = New System.Drawing.Point(0, 0)
        Me.TLP.Name = "TLP"
        Me.TLP.RowCount = 1
        Me.TLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP.Size = New System.Drawing.Size(283, 150)
        Me.TLP.TabIndex = 0
        '
        'DG_Variables
        '
        Me.DG_Variables.AllowUserToAddRows = False
        Me.DG_Variables.AllowUserToDeleteRows = False
        Me.DG_Variables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DG_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG_Variables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.VarName, Me.VarValue})
        Me.DG_Variables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG_Variables.Location = New System.Drawing.Point(32, 1)
        Me.DG_Variables.Margin = New System.Windows.Forms.Padding(0)
        Me.DG_Variables.Name = "DG_Variables"
        Me.DG_Variables.RowHeadersVisible = False
        Me.DG_Variables.Size = New System.Drawing.Size(250, 148)
        Me.DG_Variables.TabIndex = 0
        '
        'Check
        '
        Me.Check.DataPropertyName = "Check"
        Me.Check.Frozen = True
        Me.Check.HeaderText = "C"
        Me.Check.Name = "Check"
        Me.Check.Width = 25
        '
        'VarName
        '
        Me.VarName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.VarName.DataPropertyName = "Name"
        Me.VarName.HeaderText = "Name"
        Me.VarName.Name = "VarName"
        '
        'VarValue
        '
        Me.VarValue.DataPropertyName = "Value"
        Me.VarValue.HeaderText = "Value"
        Me.VarValue.Name = "VarValue"
        Me.VarValue.Width = 50
        '
        'LB_SEQ
        '
        Me.LB_SEQ.AutoSize = True
        Me.LB_SEQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_SEQ.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_SEQ.Location = New System.Drawing.Point(4, 1)
        Me.LB_SEQ.Name = "LB_SEQ"
        Me.LB_SEQ.Size = New System.Drawing.Size(24, 148)
        Me.LB_SEQ.TabIndex = 1
        Me.LB_SEQ.Text = "1"
        Me.LB_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UC_WorkFlowEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TLP)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.Name = "UC_WorkFlowEvent"
        Me.Size = New System.Drawing.Size(283, 150)
        Me.TLP.ResumeLayout(False)
        Me.TLP.PerformLayout()
        CType(Me.DG_Variables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TLP As TableLayoutPanel
    Friend WithEvents DG_Variables As DataGridView
    Friend WithEvents LB_SEQ As Label
    Friend WithEvents Check As DataGridViewCheckBoxColumn
    Friend WithEvents VarName As DataGridViewTextBoxColumn
    Friend WithEvents VarValue As DataGridViewTextBoxColumn
End Class
