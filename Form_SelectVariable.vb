Imports SolidEdgeConstants

Public Class Form_SelectVariable

    Public objDoc As SolidEdgeFramework.SolidEdgeDocument
    Public objVarName As String

    Private Sub Form_SelectVariable_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objVars As SolidEdgeFramework.Variables = objDoc.Variables
        Dim FindVars = objVars.Query("*", 0, 2)

        If FindVars.count > 0 Then

            ListBox_Variables.Items.Clear()

            For Each item In FindVars
                ListBox_Variables.Items.Add(item.name)
            Next

        End If

    End Sub

    Private Sub BT_OK_Click(sender As Object, e As EventArgs) Handles BT_OK.Click

        If Not IsNothing(ListBox_Variables.SelectedItem) Then

            objVarName = ListBox_Variables.SelectedItem

        End If

        Me.Close()

    End Sub

    Private Sub BT_Cancel_Click(sender As Object, e As EventArgs) Handles BT_Cancel.Click

        objVarName = ""

        Me.Close()

    End Sub

End Class