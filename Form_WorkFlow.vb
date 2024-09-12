Imports System.ComponentModel

Public Class Form_WorkFlow

    Public Variables As List(Of Object)

    Private Sub Add_Event_Click(sender As Object, e As EventArgs) Handles Add_Event.Click

        Dim list = New List(Of EventVariable)
        For Each tmpVar In Variables

            If Not (tmpVar.IsReadOnly Or tmpVar.Formula <> "") Then
                Dim tmpVariable As New EventVariable
                tmpVariable.Check = True
                tmpVariable.Name = tmpVar.DisplayName
                tmpVariable.Value = Math.Round(UC_Slider.CadToValue(tmpVar.value, tmpVar.UnitsType), 2)
                tmpVariable.objVar = tmpVar

                list.Add(tmpVariable)
            End If

        Next

        Dim bindinfList = New BindingList(Of EventVariable)(list)
        Dim source = New BindingSource(bindinfList, Nothing)

        Dim tmpStep As New UC_WorkFlowEvent

        tmpStep.DG_Variables.AutoGenerateColumns = False
        tmpStep.DG_Variables.DataSource = source
        tmpStep.LB_SEQ.Text = FLP_Events.Controls.Count + 1

        tmpStep.Height = 23 + tmpStep.DG_Variables.RowTemplate.Height * tmpStep.DG_Variables.Rows.Count

        FLP_Events.Controls.Add(tmpStep)

        SetupAnchors()

    End Sub

    Private Sub SetupAnchors()

        FLP_Events.SuspendLayout()

        If FLP_Events.Controls.Count > 0 Then
            For i = 0 To FLP_Events.Controls.Count - 1
                Dim c As Control = FLP_Events.Controls(i)
                If i = 0 Then
                    ' Its the first control, all subsequent controls follow
                    ' the anchor behavior of this control.
                    c.Width = FLP_Events.Width - 0
                    c.Anchor = AnchorStyles.Left + AnchorStyles.Top

                    If FLP_Events.VerticalScroll.Visible Then c.Width += -SystemInformation.VerticalScrollBarWidth + 0

                Else

                    ' It is not the first control. Set its anchor to
                    ' copy the width of the first control in the list.
                    c.Anchor = AnchorStyles.Left + AnchorStyles.Right

                End If
            Next
        End If

        FLP_Events.ResumeLayout()

    End Sub

    Private Sub Form_WorkFlow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetupAnchors()
    End Sub

End Class

Public Class EventVariable

    Public Property Check As Boolean = True
    Public Property Name As String = ""
    Public Property Value As Double = 0
    Public Property objVar As Object

End Class