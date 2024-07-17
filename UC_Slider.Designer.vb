<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Slider
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox_Slider = New System.Windows.Forms.GroupBox()
        Me.LB_max = New System.Windows.Forms.Label()
        Me.LB_value = New System.Windows.Forms.Label()
        Me.LB_name = New System.Windows.Forms.Label()
        Me.LB_min = New System.Windows.Forms.Label()
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.BG_Play = New System.ComponentModel.BackgroundWorker()
        Me.BT_Delete = New System.Windows.Forms.Button()
        Me.BT_Play = New System.Windows.Forms.Button()
        Me.BT_Pinned = New System.Windows.Forms.Button()
        Me.BT_Loop = New System.Windows.Forms.Button()
        Me.GroupBox_Slider.SuspendLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_Slider
        '
        Me.GroupBox_Slider.AutoSize = True
        Me.GroupBox_Slider.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_Slider.Controls.Add(Me.BT_Loop)
        Me.GroupBox_Slider.Controls.Add(Me.LB_max)
        Me.GroupBox_Slider.Controls.Add(Me.LB_name)
        Me.GroupBox_Slider.Controls.Add(Me.LB_min)
        Me.GroupBox_Slider.Controls.Add(Me.BT_Delete)
        Me.GroupBox_Slider.Controls.Add(Me.BT_Play)
        Me.GroupBox_Slider.Controls.Add(Me.BT_Pinned)
        Me.GroupBox_Slider.Controls.Add(Me.TrackBar)
        Me.GroupBox_Slider.Controls.Add(Me.LB_value)
        Me.GroupBox_Slider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Slider.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Slider.Name = "GroupBox_Slider"
        Me.GroupBox_Slider.Size = New System.Drawing.Size(283, 90)
        Me.GroupBox_Slider.TabIndex = 0
        Me.GroupBox_Slider.TabStop = False
        Me.GroupBox_Slider.Text = "Name"
        '
        'LB_max
        '
        Me.LB_max.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_max.AutoSize = True
        Me.LB_max.Location = New System.Drawing.Point(251, 36)
        Me.LB_max.Name = "LB_max"
        Me.LB_max.Size = New System.Drawing.Size(27, 13)
        Me.LB_max.TabIndex = 2
        Me.LB_max.Text = "max"
        Me.LB_max.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_value
        '
        Me.LB_value.AutoSize = True
        Me.LB_value.ForeColor = System.Drawing.Color.Red
        Me.LB_value.Location = New System.Drawing.Point(51, 16)
        Me.LB_value.Name = "LB_value"
        Me.LB_value.Size = New System.Drawing.Size(34, 13)
        Me.LB_value.TabIndex = 2
        Me.LB_value.Text = "value"
        Me.LB_value.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_name
        '
        Me.LB_name.AutoSize = True
        Me.LB_name.Location = New System.Drawing.Point(6, 16)
        Me.LB_name.Name = "LB_name"
        Me.LB_name.Size = New System.Drawing.Size(39, 13)
        Me.LB_name.TabIndex = 2
        Me.LB_name.Text = "Vxxxxx"
        Me.LB_name.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_min
        '
        Me.LB_min.AutoSize = True
        Me.LB_min.Location = New System.Drawing.Point(6, 36)
        Me.LB_min.Name = "LB_min"
        Me.LB_min.Size = New System.Drawing.Size(26, 13)
        Me.LB_min.TabIndex = 2
        Me.LB_min.Text = "min"
        Me.LB_min.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TrackBar
        '
        Me.TrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar.AutoSize = False
        Me.TrackBar.BackColor = System.Drawing.Color.White
        Me.TrackBar.Location = New System.Drawing.Point(3, 52)
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(277, 35)
        Me.TrackBar.TabIndex = 0
        Me.TrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'BG_Play
        '
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
        'BT_Play
        '
        Me.BT_Play.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Play.FlatAppearance.BorderSize = 0
        Me.BT_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Play.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Play
        Me.BT_Play.Location = New System.Drawing.Point(220, 7)
        Me.BT_Play.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Play.Name = "BT_Play"
        Me.BT_Play.Size = New System.Drawing.Size(20, 20)
        Me.BT_Play.TabIndex = 1
        Me.BT_Play.Tag = "Play"
        Me.BT_Play.UseVisualStyleBackColor = True
        '
        'BT_Pinned
        '
        Me.BT_Pinned.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Pinned.FlatAppearance.BorderSize = 0
        Me.BT_Pinned.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Pinned.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Unchecked
        Me.BT_Pinned.Location = New System.Drawing.Point(241, 7)
        Me.BT_Pinned.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Pinned.Name = "BT_Pinned"
        Me.BT_Pinned.Size = New System.Drawing.Size(20, 20)
        Me.BT_Pinned.TabIndex = 1
        Me.BT_Pinned.Tag = "Unchecked"
        Me.BT_Pinned.UseVisualStyleBackColor = True
        '
        'BT_Loop
        '
        Me.BT_Loop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Loop.BackColor = System.Drawing.Color.Transparent
        Me.BT_Loop.FlatAppearance.BorderSize = 0
        Me.BT_Loop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Loop.Image = Global.SolidEdge_VarHandler.My.Resources.Resources._Loop
        Me.BT_Loop.Location = New System.Drawing.Point(199, 7)
        Me.BT_Loop.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_Loop.Name = "BT_Loop"
        Me.BT_Loop.Size = New System.Drawing.Size(20, 20)
        Me.BT_Loop.TabIndex = 3
        Me.BT_Loop.Tag = "Unchecked"
        Me.BT_Loop.UseVisualStyleBackColor = False
        '
        'UC_Slider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox_Slider)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UC_Slider"
        Me.Size = New System.Drawing.Size(283, 90)
        Me.GroupBox_Slider.ResumeLayout(False)
        Me.GroupBox_Slider.PerformLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox_Slider As GroupBox
    Friend WithEvents BT_Delete As Button
    Friend WithEvents TrackBar As TrackBar
    Friend WithEvents LB_max As Label
    Friend WithEvents LB_value As Label
    Friend WithEvents LB_min As Label
    Friend WithEvents LB_name As Label
    Friend WithEvents BT_Pinned As Button
    Friend WithEvents BT_Play As Button
    Friend WithEvents BG_Play As System.ComponentModel.BackgroundWorker
    Friend WithEvents BT_Loop As Button
End Class
