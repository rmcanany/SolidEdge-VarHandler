Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel

Public Class UC_WorkFlowEvent

    Public steps As Integer = 20

    Private Sub DG_Variables_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG_Variables.CellClick, DG_Variables.CellDoubleClick

        If e.ColumnIndex <> 2 Then DG_Variables.ClearSelection()

    End Sub

    Private Sub BT_Close_Click(sender As Object, e As EventArgs) Handles BT_Close.Click

        Dim tmpParent As Form_WorkFlow = Me.ParentForm

        For Each item In tmpParent.FLP_Events.Controls

            If item Is Me Then

                tmpParent.FLP_Events.Controls.Remove(item)
                Exit For

            End If

        Next

        tmpParent.ReNumber()

    End Sub

    Private Sub BT_Steps_Click(sender As Object, e As EventArgs) Handles BT_Steps.Click
        Try
            steps = InputBox("Set number of steps",, steps)
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub






    Public Sub PlayEvent(ReverseStep As Boolean, UpdateDoc As Boolean, SaveImages As Boolean, CheckInterference As Boolean, LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants, objDoc As SolidEdgeFramework.SolidEdgeDocument)


        BW_PlayEvent.RunWorkerAsync(New Object() {ReverseStep, UpdateDoc, SaveImages, CheckInterference, LengthUnits, objDoc})


    End Sub

    Private Sub SetSteps(stepEvent As UC_WorkFlowEvent, LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants)

        Dim tmpSteps = stepEvent.steps

        For Each tmpRow As DataGridViewRow In stepEvent.DG_Variables.Rows

            Dim tmpVariable As Object = tmpRow.Cells("objVar").Value
            'Dim stepValue As Double = (CDbl(tmpRow.Cells("Value").Value) - UC_Slider.CadToValue(tmpVariable.Value, tmpVariable.UnitsType, LengthUnits)) / 20
            Dim stepValue As Double = (CDbl(tmpRow.Cells("Value").Value) - UC_Slider.CadToValue(tmpVariable.Value, tmpVariable.UnitsType, LengthUnits)) / tmpSteps

            tmpRow.Tag = stepValue

        Next

    End Sub

    Private Sub BW_PlayEvent_DoWork(sender As Object, e As DoWorkEventArgs) Handles BW_PlayEvent.DoWork

        'System.Windows.Forms.Application.DoEvents()

        'If Abort Then
        '    BT_Skip.Text = "Skip"
        '    BT_Skip.Image = My.Resources.skip
        '    Abort = False
        '    Exit Sub
        'End If

        Dim StepNumber As Integer = CInt(Me.LB_SEQ.Text)

        'If IsSingleStep Then
        '    If StepNumber < CurrentEvent Then
        '        Continue For
        '    End If
        '    If StepNumber > CurrentEvent Then
        '        Exit For
        '    End If
        'Else
        '    If StepNumber < StartEvent Then
        '        Continue For
        '    End If
        'End If

        Me.LB_SEQ.ForeColor = Color.DarkGreen

        SetSteps(Me, e.Argument(4))

        'For i = 1 To 20
        For j = 1 To Me.steps

            Dim i As Integer = j

            If e.Argument(0) Then
                i = Me.steps + 1 - j
            End If

            'LabelStatus.Text = String.Format("Event {0}, Step {1}", Me.LB_SEQ.Text, i)

            Dim IsFirstStep As Boolean

            If Not e.Argument(0) Then
                IsFirstStep = (Me.LB_SEQ.Text = "1") And (i = 1)
            Else
                IsFirstStep = (Me.LB_SEQ.Text = CStr(Me.steps)) And (i = Me.steps)
            End If

            ' Process first step before incrementing variables
            If IsFirstStep Then
                If e.Argument(1) Then UC_Slider.DoUpdateDoc(Form_VarHandler.objDoc)

                e.Argument(5).Parent.DoIdle()

                If e.Argument(2) Then UC_Slider.DoSaveImage(Form_VarHandler.objDoc)

                'If CheckInterference Then
                '    If Not UC_Slider.DoCheckInterference(Form_VarHandler.objDoc) Then
                '        If InterferenceMessage = "" Then
                '            InterferenceMessage = String.Format("Interference first detected in Event {0}, Step {1}", Me.LB_SEQ.Text, i)
                '        End If
                '    End If
                'End If

                'If Export Then DoUpdateExports(ExportList, Me)

            End If



            e.Argument(5).Parent.DelayCompute = True

            For Each tmpRow As DataGridViewRow In Me.DG_Variables.Rows

                Dim tmpVariable As Object = tmpRow.Cells("objVar").Value

                ' ###### TODO The variable is sometimes getting out of range in SE. ######
                ' Need a min/max check somewhere.  Not sure this is the place to do it.

                tmpVariable.Value += UC_Slider.ValueToCad(tmpRow.Tag, tmpVariable.UnitsType, e.Argument(4))

            Next

            e.Argument(5).Parent.DelayCompute = False

            If e.Argument(1) Then UC_Slider.DoUpdateDoc(Form_VarHandler.objDoc)

            e.Argument(5).Parent.DoIdle()

            If e.Argument(2) Then UC_Slider.DoSaveImage(Form_VarHandler.objDoc)

            'If CheckInterference Then
            '    If Not UC_Slider.DoCheckInterference(Form_VarHandler.objDoc) Then
            '        If InterferenceMessage = "" Then
            '            InterferenceMessage = String.Format("Interference first detected in Event {0}, Step {1}", Me.LB_SEQ.Text, i)
            '        End If
            '    End If
            'End If

            'If Export Then DoUpdateExports(ExportList, Me)

        Next

        Me.LB_SEQ.ForeColor = Color.DarkGray

    End Sub

End Class
