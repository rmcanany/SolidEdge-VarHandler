Public Class UC_Tracker

    Public Tracker_3D As Boolean = True
    Public NumberOfDecimals As Integer = 2
    Public ClosedCurve As Boolean = False
    Public LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants
    Public Sub New(Name As String, _LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LB_X.Text = "X: "
        LB_Y.Text = "Y: "
        LB_Z.Text = "Z: "

        LengthUnits = _LengthUnits

    End Sub

    Public Shared Function CadToValue(
        Value As Double,
        UnitType As SolidEdgeFramework.UnitTypeConstants,
        LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants
        ) As Double 'Unificare con quello in UC_Slider

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

            If LengthUnits = SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthInch Then

                CadToValue = Value * 1000 / 25.4

            ElseIf LengthUnits = SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants.seLengthMillimeter Then

                CadToValue = Value * 1000

            Else

                MsgBox(String.Format("Unrecognized length units '{0}'", LengthUnits.ToString), MsgBoxStyle.Critical)

                CadToValue = Value

            End If

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

            LB_X.Text = "X: " & Math.Round(CadToValue(objXOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
            LB_Y.Text = "Y: " & Math.Round(CadToValue(objYOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
            LB_Z.Text = "Z: " & Math.Round(CadToValue(objZOffset, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString

        ElseIf Not IsNothing(tmpForm.Tracker_2D) Then

            Dim objX As Double = Nothing
            Dim objY As Double = Nothing
            tmpForm.Tracker_2D.GetOrigin(objX, objY)

            LB_X.Text = "X: " & Math.Round(CadToValue(objX, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
            LB_Y.Text = "Y: " & Math.Round(CadToValue(objY, SolidEdgeFramework.UnitTypeConstants.igUnitDistance, LengthUnits), NumberOfDecimals).ToString
            LB_Z.Text = "Z: -----"

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
