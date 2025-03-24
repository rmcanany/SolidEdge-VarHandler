Public Class UC_Tracker

    Public Tracker_3D As Boolean = True
    Public NumberOfDecimals As Integer = 2
    Public ClosedCurve As Boolean = False
    Public LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants

    Public NewWay As Boolean = True
    Public ObjDoc As SolidEdgeFramework.SolidEdgeDocument

    Public Sub New(
         Name As String,
         _LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants,
         _ObjDoc As SolidEdgeFramework.SolidEdgeDocument)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LB_X.Text = "X: "
        LB_Y.Text = "Y: "
        LB_Z.Text = "Z: "

        LengthUnits = _LengthUnits
        ObjDoc = _ObjDoc

    End Sub

    Public Sub UpdateLabel()

        If Not Tracker_3D Then LB_Z.Enabled = False

        Dim tmpForm = CType(Me.Parent.Parent, Form_VarHandler)

        Dim UU As New UtilsUnits(ObjDoc)

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

            If NewWay Then
                LB_X.Text = "X: " & Math.Round(UU.CadToValue(objXOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
                LB_Y.Text = "Y: " & Math.Round(UU.CadToValue(objYOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
                LB_Z.Text = "Z: " & Math.Round(UU.CadToValue(objZOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
            Else
                LB_X.Text = "X: " & Math.Round(UC_Slider.CadToValue(objXOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
                LB_Y.Text = "Y: " & Math.Round(UC_Slider.CadToValue(objYOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
                LB_Z.Text = "Z: " & Math.Round(UC_Slider.CadToValue(objZOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
            End If

        ElseIf Not IsNothing(tmpForm.Tracker_2D) Then

            Dim objX As Double = Nothing
            Dim objY As Double = Nothing
            tmpForm.Tracker_2D.GetOrigin(objX, objY)

            If NewWay Then
                LB_X.Text = "X: " & Math.Round(UU.CadToValue(objX, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
                LB_Y.Text = "Y: " & Math.Round(UU.CadToValue(objY, SolidEdgeFramework.UnitTypeConstants.igUnitDistance), NumberOfDecimals).ToString
                LB_Z.Text = "Z: -----"
            Else
                LB_X.Text = "X: " & Math.Round(UC_Slider.CadToValue(objX, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
                LB_Y.Text = "Y: " & Math.Round(UC_Slider.CadToValue(objY, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
                LB_Z.Text = "Z: -----"
            End If

        End If

    End Sub

    Private Sub BT_Delete_Click(sender As Object, e As EventArgs) Handles BT_Delete.Click

        Dim tmpForm = CType(Me.Parent.Parent, Form_VarHandler)
        tmpForm.BT_Tracker.Checked = False
        tmpForm.Trace = False

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

    Private Sub CB_Trace_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Trace.CheckedChanged

        Dim tmpForm = CType(Me.Parent.Parent, Form_VarHandler)
        tmpForm.Trace = CB_Trace.Checked

        If CB_Trace.Checked Then
            CB_Trace.Image = My.Resources.TraceSelected
        Else
            CB_Trace.Image = My.Resources.Trace
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
