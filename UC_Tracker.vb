Public Class UC_Tracker

    Public Tracker_3D As Boolean = True
    Public NumberOfDecimals As Integer = 2
    Public ClosedCurve As Boolean = False
    Public Sub New(Name As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LB_X.Text = "X: "
        LB_Y.Text = "Y: "
        LB_Z.Text = "Z: "

    End Sub

    Public Shared Function CadToValue(Value As Double, UnitType As SolidEdgeFramework.UnitTypeConstants) As Double 'Unificare con quello in UC_Slider

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

            CadToValue = Value * 1000

        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then

            CadToValue = Value * 180 / Math.PI

        Else

            CadToValue = Value

        End If

    End Function

    Public Sub UpdateLabel()

        If Not Tracker_3D Then LB_Z.Enabled = False

        Dim tmpForm = CType(Me.Parent.Parent, Form_VarHandler)

        If Not IsNothing(tmpForm.Tracker_3D) Then

            Dim objXOffset As Double = Nothing
            Dim objYOffset As Double = Nothing
            Dim objZOffset As Double = Nothing
            Dim objXRotation As Double = Nothing
            Dim objYRotation As Double = Nothing
            Dim objZRotation As Double = Nothing
            Dim objRtP As Boolean = Nothing
            Dim objZFirstRot As Double = Nothing
            tmpForm.Tracker_3D.GetOrientation(objXOffset, objYOffset, objZOffset, objXRotation, objYRotation, objZRotation, objRtP, objZFirstRot)

            LB_X.Text = "X: " & Math.Round(CadToValue(objXOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
            LB_Y.Text = "Y: " & Math.Round(CadToValue(objYOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
            LB_Z.Text = "Z: " & Math.Round(CadToValue(objZOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString

        ElseIf Not IsNothing(tmpForm.Tracker_2D) Then

            Dim objX As Double = Nothing
            Dim objY As Double = Nothing
            tmpForm.Tracker_2D.GetOrigin(objX, objY)

            LB_X.Text = "X: " & Math.Round(CadToValue(objX, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
            LB_Y.Text = "Y: " & Math.Round(CadToValue(objY, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
            LB_Z.Text = "Z: -----"

        End If

    End Sub

    Private Sub BT_Delete_Click(sender As Object, e As EventArgs) Handles BT_Delete.Click

        Dim tmpFLP As FlowLayoutPanel = CType(Me.Parent, FlowLayoutPanel)
        If tmpFLP.Controls.Contains(Me) Then tmpFLP.Controls.Remove(Me)

    End Sub

    Private Sub BT_Settings_Click(sender As Object, e As EventArgs) Handles BT_Settings.Click

        Try
            NumberOfDecimals = InputBox("Set number of decimals",, NumberOfDecimals)
            If NumberOfDecimals > 15 Then NumberOfDecimals = 15
            If NumberOfDecimals < 0 Then NumberOfDecimals = 0

        Catch ex As Exception
            Exit Sub
        End Try

        UpdateLabel()

    End Sub

    Private Sub BT_Trace_Click(sender As Object, e As EventArgs) Handles BT_Trace.Click

        Dim tmpForm = CType(Me.Parent.Parent, Form_VarHandler)

        If BT_Trace.Tag.ToString = "Unchecked" Then

            BT_Trace.Tag = "Checked"
            BT_Trace.Image = My.Resources.TraceSelected
            tmpForm.Trace = True

        Else

            BT_Trace.Tag = "Unchecked"
            BT_Trace.Image = My.Resources.Trace
            tmpForm.Trace = False

        End If

    End Sub

    Private Sub CB_Closed_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Closed.CheckedChanged

        ClosedCurve = CB_Closed.Checked

        If CB_Closed.Checked Then
            CB_Closed.Image = My.Resources.Checked
        Else
            CB_Closed.Image = My.Resources.Unchecked
        End If

    End Sub

End Class
