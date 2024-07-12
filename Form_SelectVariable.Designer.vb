<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SelectVariable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SelectVariable))
        Me.ListBox_Variables = New System.Windows.Forms.ListBox()
        Me.BT_Cancel = New System.Windows.Forms.Button()
        Me.BT_OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox_Variables
        '
        Me.ListBox_Variables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox_Variables.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListBox_Variables.FormattingEnabled = True
        Me.ListBox_Variables.Location = New System.Drawing.Point(0, 0)
        Me.ListBox_Variables.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox_Variables.Name = "ListBox_Variables"
        Me.ListBox_Variables.Size = New System.Drawing.Size(184, 130)
        Me.ListBox_Variables.Sorted = True
        Me.ListBox_Variables.TabIndex = 0
        '
        'BT_Cancel
        '
        Me.BT_Cancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_Cancel.FlatAppearance.BorderSize = 0
        Me.BT_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Cancel.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Cancel
        Me.BT_Cancel.Location = New System.Drawing.Point(92, 130)
        Me.BT_Cancel.Name = "BT_Cancel"
        Me.BT_Cancel.Size = New System.Drawing.Size(92, 31)
        Me.BT_Cancel.TabIndex = 1
        Me.BT_Cancel.UseVisualStyleBackColor = True
        '
        'BT_OK
        '
        Me.BT_OK.Dock = System.Windows.Forms.DockStyle.Left
        Me.BT_OK.FlatAppearance.BorderSize = 0
        Me.BT_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_OK.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Ok
        Me.BT_OK.Location = New System.Drawing.Point(0, 130)
        Me.BT_OK.Name = "BT_OK"
        Me.BT_OK.Size = New System.Drawing.Size(92, 31)
        Me.BT_OK.TabIndex = 1
        Me.BT_OK.UseVisualStyleBackColor = True
        '
        'Form_SelectVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 161)
        Me.Controls.Add(Me.BT_Cancel)
        Me.Controls.Add(Me.BT_OK)
        Me.Controls.Add(Me.ListBox_Variables)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SelectVariable"
        Me.Text = "Variables"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox_Variables As ListBox
    Friend WithEvents BT_OK As Button
    Friend WithEvents BT_Cancel As Button
End Class
