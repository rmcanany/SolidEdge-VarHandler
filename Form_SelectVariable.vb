Imports SolidEdgeConstants

Public Class Form_SelectVariable

    Public objDoc As SolidEdgeFramework.SolidEdgeDocument
    Public objVarName As String

    Private Sub Form_SelectVariable_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objVars As SolidEdgeFramework.Variables = objDoc.Variables
        Dim FindVars = objVars.Query("*", 0, 2)

        If FindVars.count > 0 Then

            ListBox_Variables.Items.Clear()
            ListBox_Variables.DisplayMember = "Name"

            For Each item In FindVars

                Dim tmpVar As New VarListItem(item)
                ListBox_Variables.Items.Add(tmpVar)

            Next

        End If

    End Sub

    Private Sub BT_OK_Click(sender As Object, e As EventArgs) Handles BT_OK.Click

        If Not IsNothing(ListBox_Variables.SelectedItem) Then

            objVarName = ListBox_Variables.SelectedItem.VarName

        End If

        Me.Close()

    End Sub

    Private Sub BT_Cancel_Click(sender As Object, e As EventArgs) Handles BT_Cancel.Click

        objVarName = ""

        Me.Close()

    End Sub

End Class

Public Class VarListItem

    Public Property Name As String
    Public Property VarName As String
    Public Property Value As String
    Public Property Formula As String

    Public Sub New(objVar As SolidEdgeFramework.variable)

        VarName = objVar.Name
        Formula = objVar.Formula

        Dim UnitType = objVar.UnitsType

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

            Value = CInt(objVar.Value * 1000).ToString

        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then

            Value = CInt(objVar.Value * 180 / Math.PI).ToString

        Else

            Value = CInt(objVar.Value).ToString

        End If


        If Formula = "" Then
            Name = objVar.Name & " = " & Value
        Else
            Name = objVar.Name & " = " & objVar.Formula
        End If

    End Sub


End Class