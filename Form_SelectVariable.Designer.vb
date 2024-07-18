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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox_Variables
        '
        Me.ListBox_Variables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBox_Variables, 2)
        Me.ListBox_Variables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox_Variables.FormattingEnabled = True
        Me.ListBox_Variables.Location = New System.Drawing.Point(0, 50)
        Me.ListBox_Variables.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox_Variables.Name = "ListBox_Variables"
        Me.ListBox_Variables.Size = New System.Drawing.Size(184, 161)
        Me.ListBox_Variables.Sorted = True
        Me.ListBox_Variables.TabIndex = 0
        '
        'BT_Cancel
        '
        Me.BT_Cancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_Cancel.FlatAppearance.BorderSize = 0
        Me.BT_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Cancel.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Cancel
        Me.BT_Cancel.Location = New System.Drawing.Point(92, 211)
        Me.BT_Cancel.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Cancel.Name = "BT_Cancel"
        Me.BT_Cancel.Size = New System.Drawing.Size(92, 30)
        Me.BT_Cancel.TabIndex = 1
        Me.BT_Cancel.UseVisualStyleBackColor = True
        '
        'BT_OK
        '
        Me.BT_OK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_OK.FlatAppearance.BorderSize = 0
        Me.BT_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_OK.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Ok
        Me.BT_OK.Location = New System.Drawing.Point(0, 211)
        Me.BT_OK.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_OK.Name = "BT_OK"
        Me.BT_OK.Size = New System.Drawing.Size(92, 30)
        Me.BT_OK.TabIndex = 1
        Me.BT_OK.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BT_OK, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBox_Variables, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BT_Cancel, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox4, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 241)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 19)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Variables"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(3, 28)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(86, 19)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Dimensions"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(95, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(86, 19)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "User"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(95, 28)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(86, 19)
        Me.CheckBox4.TabIndex = 2
        Me.CheckBox4.Text = "System"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Form_SelectVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 241)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SelectVariable"
        Me.Text = "Variables"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox_Variables As ListBox
    Friend WithEvents BT_OK As Button
    Friend WithEvents BT_Cancel As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
End Class
