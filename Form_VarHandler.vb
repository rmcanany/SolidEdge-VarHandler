Imports System.ComponentModel
Imports System.Net.WebRequestMethods
Imports SolidEdgeFramework

Public Class Form_VarHandler

    Dim objApp As SolidEdgeFramework.Application
    Dim objDoc As SolidEdgeFramework.SolidEdgeDocument

    Private Sub BT_Aggiungi_Click(sender As Object, e As EventArgs) Handles BT_Aggiungi.Click

        Dim tmpForm As New Form_SelectVariable
        tmpForm.objDoc = objDoc
        tmpForm.ShowDialog(Me)

        If tmpForm.objVarName <> "" Then

            Dim tmpSlider As New UC_Slider(tmpForm.objVar)

            If tmpSlider.Valid Then

                AddHandler tmpSlider.LB_value.TextChanged, AddressOf Slider_Click

                FLP_Vars.Controls.Add(tmpSlider)

                SetupAnchors()

            End If

        End If


    End Sub

    Private Sub Slider_Click(sender As Object, e As EventArgs)

        For Each tmpSlider As UC_Slider In FLP_Vars.Controls

            tmpSlider.UpdateLabel()

        Next

    End Sub

    Private Sub SetupAnchors()

        FLP_Vars.SuspendLayout()

        If FLP_Vars.Controls.Count > 0 Then
            For i = 0 To FLP_Vars.Controls.Count - 1
                Dim c As Control = FLP_Vars.Controls(i)
                If i = 0 Then
                    ' Its the first control, all subsequent controls follow
                    ' the anchor behavior of this control.

                    c.Width = FLP_Vars.Width - 8
                    c.Anchor = AnchorStyles.Left + AnchorStyles.Top

                    If FLP_Vars.VerticalScroll.Visible Then c.Width += -SystemInformation.VerticalScrollBarWidth + 0

                Else

                    ' It is not the first control. Set its anchor to
                    ' copy the width of the first control in the list.
                    c.Anchor = AnchorStyles.Left + AnchorStyles.Right

                End If
            Next
        End If

        FLP_Vars.ResumeLayout()

    End Sub

    Private Sub Form_VarHandler_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetupAnchors()
    End Sub

    Private Sub Form_VarHandler_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            objApp = GetObject(, "SolidEdge.Application")
        Catch ex As Exception
            MsgBox("Solid Edge must be open", MsgBoxStyle.Critical)
            End
        End Try

        Try
            objDoc = objApp.ActiveDocument
        Catch ex As Exception
            MsgBox("A Solid Edge Document must be open", MsgBoxStyle.Critical)
            End
        End Try

        Autotune()

    End Sub

    Private Sub Autotune()

        Dim tmpVars As SolidEdgeFramework.Variables = objDoc.Variables

        Dim tmpVar = tmpVars.Query("*",, 2)

        Dim variables As SolidEdgeFramework.Variables = CType(objDoc.Variables, SolidEdgeFramework.Variables)


        Dim pFindCriterium As String = "*"
        Dim NamedBy As Object = SolidEdgeConstants.VariableNameBy.seVariableNameByBoth
        Dim CaseInsensitive As Object = False
        Dim VarType As Object = SolidEdgeConstants.VariableVarType.SeVariableVarTypeVariable
        Dim variableList As SolidEdgeFramework.VariableList = CType(variables.Query(pFindCriterium, NamedBy, VarType, CaseInsensitive), SolidEdgeFramework.VariableList)

        If variableList.Count > 0 Then

            Dim tmpList As New List(Of variable)

            For Each item As SolidEdgeFramework.variable In variableList

                Console.WriteLine(item.Name & " - " & item.GetComment)

                If item.GetComment = "Autotune" Then

                    tmpList.Add(item)

                End If

            Next

            For Each item In tmpList

                Dim tmpSlider As New UC_Slider(item)
                AddHandler tmpSlider.LB_value.TextChanged, AddressOf Slider_Click

                FLP_Vars.Controls.Add(tmpSlider)

            Next

            SetupAnchors()

        End If

    End Sub

    Private Sub FLP_Vars_ControlRemoved(sender As Object, e As ControlEventArgs) Handles FLP_Vars.ControlRemoved
        SetupAnchors()
    End Sub

    Private Sub BT_Reload_Click(sender As Object, e As EventArgs) Handles BT_Reload.Click

        FLP_Vars.Controls.Clear()
        Autotune()

    End Sub

    Private Sub BT_Tracker_Click(sender As Object, e As EventArgs) Handles BT_Tracker.Click

        MsgBox("Not implemented yet! :)", MsgBoxStyle.Information)

    End Sub
End Class
