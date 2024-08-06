<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Tracker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_Tracker))
        Me.GroupBox_Tracker = New System.Windows.Forms.GroupBox()
        Me.CB_Closed = New System.Windows.Forms.CheckBox()
        Me.BT_Loop = New System.Windows.Forms.Button()
        Me.LB_Z = New System.Windows.Forms.Label()
        Me.LB_X = New System.Windows.Forms.Label()
        Me.LB_Y = New System.Windows.Forms.Label()
        Me.BT_Delete = New System.Windows.Forms.Button()
        Me.BT_Settings = New System.Windows.Forms.Button()
        Me.BT_Play = New System.Windows.Forms.Button()
        Me.BT_Trace = New System.Windows.Forms.Button()
        Me.GroupBox_Tracker.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Tracker
        '
        Me.GroupBox_Tracker.AutoSize = True
        Me.GroupBox_Tracker.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_Tracker.Controls.Add(Me.CB_Closed)
        Me.GroupBox_Tracker.Controls.Add(Me.BT_Loop)
        Me.GroupBox_Tracker.Controls.Add(Me.LB_Z)
        Me.GroupBox_Tracker.Controls.Add(Me.LB_X)
        Me.GroupBox_Tracker.Controls.Add(Me.LB_Y)
        Me.GroupBox_Tracker.Controls.Add(Me.BT_Delete)
        Me.GroupBox_Tracker.Controls.Add(Me.BT_Settings)
        Me.GroupBox_Tracker.Controls.Add(Me.BT_Play)
        Me.GroupBox_Tracker.Controls.Add(Me.BT_Trace)
        Me.GroupBox_Tracker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Tracker.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Tracker.Name = "GroupBox_Tracker"
        Me.GroupBox_Tracker.Size = New System.Drawing.Size(283, 60)
        Me.GroupBox_Tracker.TabIndex = 1
        Me.GroupBox_Tracker.TabStop = False
        Me.GroupBox_Tracker.Text = "Tracker"
        '
        'CB_Closed
        '
        Me.CB_Closed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Closed.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_Closed.AutoSize = True
        Me.CB_Closed.FlatAppearance.BorderSize = 0
        Me.CB_Closed.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CB_Closed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_Closed.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Unchecked
        Me.CB_Closed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CB_Closed.Location = New System.Drawing.Point(139, 7)
        Me.CB_Closed.Name = "CB_Closed"
        Me.CB_Closed.Size = New System.Drawing.Size(97, 23)
        Me.CB_Closed.TabIndex = 4
        Me.CB_Closed.Text = "     Closed curve"
        Me.CB_Closed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CB_Closed.UseVisualStyleBackColor = True
        '
        'BT_Loop
        '
        Me.BT_Loop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Loop.BackColor = System.Drawing.Color.Transparent
        Me.BT_Loop.FlatAppearance.BorderSize = 0
        Me.BT_Loop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Loop.Image = Global.SolidEdge_VarHandler.My.Resources.Resources._Loop
        Me.BT_Loop.Location = New System.Drawing.Point(178, 7)
        Me.BT_Loop.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Loop.Name = "BT_Loop"
        Me.BT_Loop.Size = New System.Drawing.Size(20, 20)
        Me.BT_Loop.TabIndex = 3
        Me.BT_Loop.Tag = "Unchecked"
        Me.BT_Loop.UseVisualStyleBackColor = False
        Me.BT_Loop.Visible = False
        '
        'LB_Z
        '
        Me.LB_Z.AutoSize = True
        Me.LB_Z.Location = New System.Drawing.Point(2, 42)
        Me.LB_Z.Name = "LB_Z"
        Me.LB_Z.Size = New System.Drawing.Size(44, 13)
        Me.LB_Z.TabIndex = 2
        Me.LB_Z.Text = "Z: zzzzz"
        Me.LB_Z.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_X
        '
        Me.LB_X.AutoSize = True
        Me.LB_X.Location = New System.Drawing.Point(2, 16)
        Me.LB_X.Name = "LB_X"
        Me.LB_X.Size = New System.Drawing.Size(44, 13)
        Me.LB_X.TabIndex = 2
        Me.LB_X.Text = "X: xxxxx"
        Me.LB_X.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_Y
        '
        Me.LB_Y.AutoSize = True
        Me.LB_Y.Location = New System.Drawing.Point(2, 29)
        Me.LB_Y.Name = "LB_Y"
        Me.LB_Y.Size = New System.Drawing.Size(43, 13)
        Me.LB_Y.TabIndex = 2
        Me.LB_Y.Text = "Y: yyyyy"
        Me.LB_Y.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BT_Delete
        '
        Me.BT_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Delete.FlatAppearance.BorderSize = 0
        Me.BT_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Delete.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Remove
        Me.BT_Delete.Location = New System.Drawing.Point(262, 7)
        Me.BT_Delete.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Delete.Name = "BT_Delete"
        Me.BT_Delete.Size = New System.Drawing.Size(20, 20)
        Me.BT_Delete.TabIndex = 1
        Me.BT_Delete.UseVisualStyleBackColor = True
        '
        'BT_Settings
        '
        Me.BT_Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Settings.FlatAppearance.BorderSize = 0
        Me.BT_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Settings.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Settings
        Me.BT_Settings.Location = New System.Drawing.Point(241, 7)
        Me.BT_Settings.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Settings.Name = "BT_Settings"
        Me.BT_Settings.Size = New System.Drawing.Size(20, 20)
        Me.BT_Settings.TabIndex = 1
        Me.BT_Settings.Tag = ""
        Me.BT_Settings.UseVisualStyleBackColor = True
        '
        'BT_Play
        '
        Me.BT_Play.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Play.FlatAppearance.BorderSize = 0
        Me.BT_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Play.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Play
        Me.BT_Play.Location = New System.Drawing.Point(199, 7)
        Me.BT_Play.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Play.Name = "BT_Play"
        Me.BT_Play.Size = New System.Drawing.Size(20, 20)
        Me.BT_Play.TabIndex = 1
        Me.BT_Play.Tag = "Play"
        Me.BT_Play.UseVisualStyleBackColor = True
        Me.BT_Play.Visible = False
        '
        'BT_Trace
        '
        Me.BT_Trace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Trace.FlatAppearance.BorderSize = 0
        Me.BT_Trace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Trace.Image = CType(resources.GetObject("BT_Trace.Image"), System.Drawing.Image)
        Me.BT_Trace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Trace.Location = New System.Drawing.Point(139, 27)
        Me.BT_Trace.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Trace.Name = "BT_Trace"
        Me.BT_Trace.Size = New System.Drawing.Size(80, 20)
        Me.BT_Trace.TabIndex = 1
        Me.BT_Trace.Tag = "Unchecked"
        Me.BT_Trace.Text = "Trace"
        Me.BT_Trace.UseVisualStyleBackColor = True
        '
        'UC_Tracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox_Tracker)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UC_Tracker"
        Me.Size = New System.Drawing.Size(283, 60)
        Me.GroupBox_Tracker.ResumeLayout(False)
        Me.GroupBox_Tracker.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox_Tracker As GroupBox
    Friend WithEvents BT_Loop As Button
    Friend WithEvents LB_Z As Label
    Friend WithEvents LB_X As Label
    Friend WithEvents LB_Y As Label
    Friend WithEvents BT_Delete As Button
    Friend WithEvents BT_Settings As Button
    Friend WithEvents BT_Play As Button
    Friend WithEvents BT_Trace As Button
    Friend WithEvents CB_Closed As CheckBox
End Class
