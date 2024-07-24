<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_VarHandler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_VarHandler))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FLP_Vars = New System.Windows.Forms.FlowLayoutPanel()
        Me.BT_Reload = New System.Windows.Forms.ToolStripButton()
        Me.BT_Aggiungi = New System.Windows.Forms.ToolStripButton()
        Me.BT_Export = New System.Windows.Forms.ToolStripButton()
        Me.BT_Tracker = New System.Windows.Forms.ToolStripButton()
        Me.BT_Workflow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BT_Reload, Me.BT_Aggiungi, Me.ToolStripSeparator1, Me.BT_Export, Me.BT_Tracker, Me.BT_Workflow})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(269, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'FLP_Vars
        '
        Me.FLP_Vars.AutoScroll = True
        Me.FLP_Vars.BackColor = System.Drawing.Color.White
        Me.FLP_Vars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FLP_Vars.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP_Vars.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FLP_Vars.Location = New System.Drawing.Point(0, 25)
        Me.FLP_Vars.Name = "FLP_Vars"
        Me.FLP_Vars.Size = New System.Drawing.Size(269, 456)
        Me.FLP_Vars.TabIndex = 1
        Me.FLP_Vars.WrapContents = False
        '
        'BT_Reload
        '
        Me.BT_Reload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BT_Reload.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Reload
        Me.BT_Reload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BT_Reload.Name = "BT_Reload"
        Me.BT_Reload.Size = New System.Drawing.Size(23, 22)
        Me.BT_Reload.Text = "Reload"
        '
        'BT_Aggiungi
        '
        Me.BT_Aggiungi.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.Add
        Me.BT_Aggiungi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BT_Aggiungi.Name = "BT_Aggiungi"
        Me.BT_Aggiungi.Size = New System.Drawing.Size(93, 22)
        Me.BT_Aggiungi.Text = "Add Variable"
        '
        'BT_Export
        '
        Me.BT_Export.CheckOnClick = True
        Me.BT_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BT_Export.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.export
        Me.BT_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BT_Export.Name = "BT_Export"
        Me.BT_Export.Size = New System.Drawing.Size(23, 22)
        Me.BT_Export.Text = "Export"
        Me.BT_Export.ToolTipText = "Export variables during the play"
        '
        'BT_Tracker
        '
        Me.BT_Tracker.CheckOnClick = True
        Me.BT_Tracker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BT_Tracker.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.cog
        Me.BT_Tracker.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BT_Tracker.Name = "BT_Tracker"
        Me.BT_Tracker.Size = New System.Drawing.Size(23, 22)
        Me.BT_Tracker.Text = "Add Tracker"
        Me.BT_Tracker.ToolTipText = "Adds a tracker that trace a polyline on its movement"
        '
        'BT_Workflow
        '
        Me.BT_Workflow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BT_Workflow.Image = Global.SolidEdge_VarHandler.My.Resources.Resources.program
        Me.BT_Workflow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BT_Workflow.Name = "BT_Workflow"
        Me.BT_Workflow.Size = New System.Drawing.Size(23, 22)
        Me.BT_Workflow.Text = "Workflow"
        Me.BT_Workflow.ToolTipText = "Execute a sequence of variable changes"
        '
        'Form_VarHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 481)
        Me.Controls.Add(Me.FLP_Vars)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_VarHandler"
        Me.Text = "Solid Edge VarHandler v0.4"
        Me.TopMost = True
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BT_Aggiungi As ToolStripButton
    Friend WithEvents FLP_Vars As FlowLayoutPanel
    Friend WithEvents BT_Reload As ToolStripButton
    Friend WithEvents BT_Tracker As ToolStripButton
    Friend WithEvents BT_Workflow As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BT_Export As ToolStripButton
End Class
