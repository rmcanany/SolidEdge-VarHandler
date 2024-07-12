Public Class UC_Slider

    Dim VarName As String = ""

    Dim min As Double = 0
    Dim max As Double = 0
    Dim steps As Integer = 20

    Dim UnitType As SolidEdgeFramework.UnitTypeConstants
    Dim objDoc As SolidEdgeFramework.SolidEdgeDocument
    Dim objVar As SolidEdgeFramework.variable

    Public Function Valid() As Boolean

        If IsNothing(objVar) Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub New(Name As String, objDocV As SolidEdgeFramework.SolidEdgeDocument)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objDoc = objDocV
        objVar = FindVar(objDoc, Name)

        If IsNothing(objVar) Then
            Exit Sub
        End If

        UnitType = objVar.UnitsType

        If objVar.ExposeName <> "" Then VarName = objVar.ExposeName Else VarName = Name

        Dim minV As Double
        Dim maxV As Double

        objVar.GetValueRangeHighValue(maxV)
        objVar.GetValueRangeLowValue(minV)

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            maxV = maxV * 1000
            minV = minV * 1000
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            maxV = maxV * 180 / Math.PI
            minV = minV * 180 / Math.PI
        Else
            'Scalar value do not need conversions
        End If

        If CInt(maxV) <> 0 Then max = CInt(maxV)
        If CInt(minV) <> 0 Then min = CInt(minV)

        If min = 0 And max = 0 Then
            min = CInt(objVar.Value * 0.9)
            max = CInt(objVar.Value * 1.1)
        End If
        'If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
        '    min = CInt(objVar.Value * 1000 * 0.9)
        '    max = CInt(objVar.Value * 1000 * 1.1)
        'ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
        '    min = (objVar.Value * 180 / Math.PI) * 0.9
        '    max = (objVar.Value * 180 / Math.PI) * 1.1
        'Else
        '    min = CInt(objVar.Value * 0.9)
        '    max = CInt(objVar.Value * 1.1)
        'End If

        If objVar.IsReadOnly Or objVar.Formula <> "" Then
            TrackBar.Visible = False
            LB_max.Visible = False
            LB_min.Visible = False
            Me.Height = Me.Height / 2
        End If

        SetTrackBar()

    End Sub

    Private Sub SetTrackBar()

        TrackBar.Minimum = CInt(min)
        TrackBar.Maximum = CInt(max)
        TrackBar.TickFrequency = CInt((max - min) / steps)

        GroupBox_Slider.Text = VarName
        LB_min.Text = CInt(min).ToString
        LB_max.Text = CInt(max).ToString

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            If CInt(objVar.Value * 1000) < TrackBar.Minimum Then
                TrackBar.Value = TrackBar.Minimum
                objVar.Value = TrackBar.Value / 1000
            ElseIf CInt(objVar.Value * 1000) > TrackBar.Maximum Then
                TrackBar.Value = TrackBar.Maximum
                objVar.Value = TrackBar.Value / 1000
            Else
                TrackBar.Value = CInt(objVar.Value * 1000)
            End If
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            If CInt(objVar.Value * 180 / Math.PI) < TrackBar.Minimum Then
                TrackBar.Value = TrackBar.Minimum
                objVar.Value = TrackBar.Value * Math.PI / 180
            ElseIf CInt(objVar.Value * 180 / Math.PI) > TrackBar.Maximum Then
                TrackBar.Value = TrackBar.Maximum
                objVar.Value = TrackBar.Value * Math.PI / 180
            Else
                TrackBar.Value = CInt(objVar.Value * 180 / Math.PI)
            End If
        Else
            If CInt(objVar.Value) < TrackBar.Minimum Then
                TrackBar.Value = TrackBar.Minimum
                objVar.Value = TrackBar.Value
            ElseIf CInt(objVar.Value) > TrackBar.Maximum Then
                TrackBar.Value = TrackBar.Maximum
                objVar.Value = TrackBar.Value
            Else
                TrackBar.Value = CInt(objVar.Value)
            End If
        End If

        LB_value.Text = TrackBar.Value.ToString
        LB_name.Text = objVar.Name  '<-- Eliminare

        If objVar.GetComment = "Autotune" Then
            BT_Pinned.Tag = "Checked"
            BT_Pinned.Image = My.Resources.Checked
        End If

        LB_value.Visible = False

        UpdateLabel()

    End Sub

    Private Sub BT_Delete_Click(sender As Object, e As EventArgs) Handles BT_Delete.Click

        Dim tmpFLP As FlowLayoutPanel = Me.Parent
        If tmpFLP.Controls.Contains(Me) Then tmpFLP.Controls.Remove(Me)

    End Sub

    Private Sub TrackBar_Scroll(sender As Object, e As EventArgs) Handles TrackBar.Scroll

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            objVar.Value = TrackBar.Value / 1000
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            objVar.Value = TrackBar.Value * Math.PI / 180
        Else
            objVar.Value = TrackBar.Value
        End If

        LB_value.Text = TrackBar.Value.ToString '<---- da eliminare

        UpdateLabel()

    End Sub

    Public Sub UpdateLabel()

        If objVar.IsReadOnly Or objVar.Formula <> "" Then

            If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

                LB_value.Text = CInt(objVar.Value * 1000)

            ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then

                LB_value.Text = CInt(objVar.Value * 180 / Math.PI)

            Else

                LB_value.Text = CInt(objVar.Value)

            End If

            LB_name.Text = objVar.Name & " = " & LB_value.Text

        Else

            LB_name.Text = objVar.Name & " = " & TrackBar.Value.ToString

        End If

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            LB_name.Text = LB_name.Text & " mm"
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            LB_name.Text = LB_name.Text & " °"
        End If

    End Sub

    Private Function FindVar(objDoc As SolidEdgeFramework.SolidEdgeDocument, VarNameV As String) As Object

        Dim tmpVars As SolidEdgeFramework.Variables = objDoc.Variables

        Dim tmpVar = tmpVars.Query(VarNameV)

        If tmpVar.count > 0 Then Return tmpVar.item(1)

    End Function

    Private Sub LB_min_Click(sender As Object, e As EventArgs) Handles LB_min.Click

        Try
            min = CInt(InputBox("Minimum value"))
        Catch ex As Exception
            Exit Sub
        End Try

        '15 for conditions is (=> ; <=)
        objVar.SetValueRangeValues(min, 15, max)

        SetTrackBar()

    End Sub

    Private Sub LB_max_Click(sender As Object, e As EventArgs) Handles LB_max.Click

        Try
            max = CInt(InputBox("Maximum value"))
        Catch ex As Exception
            Exit Sub
        End Try

        '15 for conditions is (=> ; <=)
        objVar.SetValueRangeValues(min, 15, max)

        SetTrackBar()

    End Sub


    Private Sub GroupBox_Slider_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GroupBox_Slider.MouseDoubleClick

        Try
            VarName = InputBox("Control name",, objVar.ExposeName)
        Catch ex As Exception
            Exit Sub
        End Try

        Dim tmpExposed As Integer = objVar.Expose

        objVar.ExposeName = VarName
        objVar.Expose = tmpExposed

        SetTrackBar()

    End Sub

    Private Sub BT_Pinned_Click(sender As Object, e As EventArgs) Handles BT_Pinned.Click

        If BT_Pinned.Tag = "Unchecked" Then

            BT_Pinned.Tag = "Checked"
            BT_Pinned.Image = My.Resources.Checked
            objVar.SetComment("Autotune")

        Else

            BT_Pinned.Tag = "Unchecked"
            BT_Pinned.Image = My.Resources.Unchecked
            objVar.SetComment("")

        End If

    End Sub

End Class
