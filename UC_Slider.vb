
Imports System.ComponentModel
Imports Microsoft.Office.Interop
Imports SolidEdgeConstants
Imports SolidEdgeFramework

Public Class UC_Slider

    Dim VarName As String = ""

    Dim min As Integer = 0
    Dim max As Integer = 0

    Dim steps As Integer = 20
    Dim TrackbarStep As Integer

    Dim UnitType As SolidEdgeFramework.UnitTypeConstants
    Dim objVar As Object 'SolidEdgeFramework.variable

    Dim Multiplier As Integer = 10
    Dim PlayLoop As Boolean = False
    Dim Forward As Boolean = True
    Dim Export As Boolean = False
    Dim ExportSteps As List(Of Object)

    Public Function Valid() As Boolean

        If IsNothing(objVar) Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub New(objVarV As Object) 'SolidEdgeFramework.variable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objVar = objVarV

        UnitType = CType(objVar.UnitsType, SolidEdgeFramework.UnitTypeConstants)

        If objVar.ExposeName <> "" Then VarName = objVar.ExposeName Else VarName = objVar.Name

        Dim minV As Double
        Dim maxV As Double

        objVar.GetValueRangeHighValue(maxV)
        objVar.GetValueRangeLowValue(minV)

        maxV = CadToValue(maxV, UnitType)
        minV = CadToValue(minV, UnitType)

        If CInt(maxV) <> 0 Or CInt(minV) <> 0 Then
            max = CInt(maxV)
            min = CInt(minV)
        End If

        If min = 0 And max = 0 Then
            min = CInt(CadToValue(objVar.Value, UnitType)) - 10
            max = CInt(CadToValue(objVar.Value, UnitType)) + 10
        End If

        If objVar.IsReadOnly Or objVar.Formula <> "" Then
            TrackBar.Visible = False
            LB_max.Visible = False
            LB_min.Visible = False
            Me.Height = CInt(Me.Height / 2)
            BT_Play.Visible = False
            BT_Loop.Visible = False
        End If

        SetTrackBar()

    End Sub

    Private Sub SetTrackBar()

        TrackBar.Minimum = min
        TrackBar.Maximum = max

        TrackbarStep = CInt((max - min) / steps)
        TrackBar.TickFrequency = TrackbarStep 'CInt((max - min) / steps)

        TrackBar.SmallChange = TrackBar.TickFrequency / 5
        TrackBar.LargeChange = TrackBar.TickFrequency

        GroupBox_Slider.Text = VarName
        LB_min.Text = min.ToString
        LB_max.Text = max.ToString

        If CadToValue(objVar.Value, UnitType) < TrackBar.Minimum Then
            TrackBar.Value = TrackBar.Minimum
            objVar.Value = ValueToCad(TrackBar.Value, UnitType)
        ElseIf CadToValue(objVar.Value, UnitType) > TrackBar.Maximum Then
            TrackBar.Value = TrackBar.Maximum
            objVar.Value = ValueToCad(TrackBar.Value, UnitType)
        Else
            TrackBar.Value = CInt(CadToValue(objVar.Value, UnitType))
        End If

        LB_value.Text = CadToValue(objVar.Value, UnitType).ToString  'TrackBar.Value.ToString

        LB_name.Text = objVar.Name

        If objVar.GetComment = "Autotune" Then
            BT_Pinned.Tag = "Checked"
            BT_Pinned.Image = My.Resources.Checked
        End If

        LB_value.ForeColor = Color.Transparent

        UpdateLabel()

    End Sub

    Private Sub BT_Delete_Click(sender As Object, e As EventArgs) Handles BT_Delete.Click

        Dim tmpFLP As FlowLayoutPanel = CType(Me.Parent, FlowLayoutPanel)
        If tmpFLP.Controls.Contains(Me) Then tmpFLP.Controls.Remove(Me)

    End Sub

    Private Sub TrackBar_Scroll(sender As Object, e As EventArgs) Handles TrackBar.Scroll

        objVar.Value = ValueToCad(TrackBar.Value, UnitType)

        LB_value.Text = TrackBar.Value.ToString

        UpdateLabel()

    End Sub

    Public Sub UpdateLabel()

        LB_value.Text = CadToValue(objVar.Value, UnitType).ToString

        LB_name.Text = objVar.Name & " = " & LB_value.Text

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            LB_name.Text = LB_name.Text & " mm"
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            LB_name.Text = LB_name.Text & " °"
        End If

    End Sub

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

        If BT_Pinned.Tag.ToString = "Unchecked" Then

            BT_Pinned.Tag = "Checked"
            BT_Pinned.Image = My.Resources.Checked
            objVar.SetComment("Autotune")

        Else

            BT_Pinned.Tag = "Unchecked"
            BT_Pinned.Image = My.Resources.Unchecked
            objVar.SetComment("")

        End If

    End Sub

    Public Shared Function CadToValue(Value As Double, UnitType As SolidEdgeFramework.UnitTypeConstants) As Double

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

            CadToValue = Value * 1000

        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then

            CadToValue = Value * 180 / Math.PI

        Else

            CadToValue = Value

        End If

    End Function

    Public Shared Function ValueToCad(Value As Double, UnitType As SolidEdgeFramework.UnitTypeConstants) As Double

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then

            ValueToCad = Value / 1000

        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then

            ValueToCad = Value * Math.PI / 180

        Else

            ValueToCad = Value

        End If

    End Function

    Private Sub BT_Play_Click(sender As Object, e As EventArgs) Handles BT_Play.Click

        If BT_Play.Tag = "Play" Then

            Export = CheckExport()

            BT_Play.Image = My.Resources._Stop
            BT_Play.Tag = "Stop"

            BG_Play.WorkerSupportsCancellation = True
            BG_Play.WorkerReportsProgress = True

            BG_Play.RunWorkerAsync(TrackBar.Value)

            For Each item As UC_Slider In Me.Parent.Controls

                If item IsNot Me Then item.BT_Play.Enabled = False

            Next

        Else

            BT_Play.Image = My.Resources.Play
            BT_Play.Tag = "Play"

            If BG_Play.IsBusy Then BG_Play.CancelAsync()

        End If

    End Sub

    Private Function CheckExport() As Boolean

        Dim tmpMe As Form_VarHandler = Me.Parent.Parent

        If tmpMe.BT_Export.Checked Then

            For Each item As UC_Slider In Me.Parent.Controls

                If item.BT_Loop.Tag = "Checked" Then

                    item.BT_Loop_Click(Me, Nothing)

                End If

            Next

            Return True

        Else

            Return False

        End If

    End Function

    Private Sub BG_Play_DoWork(sender As Object, e As DoWorkEventArgs) Handles BG_Play.DoWork

        Dim ProgressValue As Integer = CInt(e.Argument)

        ExportSteps = New List(Of Object) From {
            GenerateStep()
        }

        Do 'Until ProgressValue = max

            If Forward Then

                If ProgressValue + TrackbarStep >= max Then
                    ProgressValue = max
                Else
                    ProgressValue += TrackbarStep
                End If

            Else

                If ProgressValue - TrackbarStep <= min Then
                    ProgressValue = min
                Else
                    ProgressValue -= TrackbarStep
                End If

            End If

            objVar.Value = ValueToCad(ProgressValue, UnitType)



            'Example for future point tracking ################################################
            If Export Then

                ExportSteps.Add(GenerateStep)

            End If




            BG_Play.ReportProgress((ProgressValue - min / max - min) * 100, ProgressValue.ToString)

            If BG_Play.CancellationPending Then

                e.Cancel = True
                Return

            End If

            If Forward Then

                If ProgressValue = max Then
                    Forward = False
                    If Not PlayLoop Then Return
                End If

            Else

                If ProgressValue = min Then
                    Forward = True
                    If Not PlayLoop Then Return
                End If

            End If

        Loop

    End Sub

    Private Function GenerateStep() As List(Of (Nome As String, Valore As Double))

        Dim tmpStep As New List(Of (Nome As String, Valore As Double))

        For Each item As UC_Slider In Me.Parent.Controls

            Dim tmpValue As (Nome As String, Valore As Double)
            tmpValue.Nome = item.objVar.name.ToString
            tmpValue.Valore = CadToValue(item.objVar.value, item.UnitType)

            tmpStep.Add(tmpValue)

        Next

        Return tmpStep

    End Function

    Private Sub BG_Play_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BG_Play.RunWorkerCompleted

        BT_Play.Image = My.Resources.Play
        BT_Play.Tag = "Play"

        UpdateLabel() '<-- A lavoro completato scateniamo l'aggiornamento di tutta l'interfaccia. I valori restituiti da Solid Edge dovrebbero essere tutti corretti

        For Each item As UC_Slider In Me.Parent.Controls

            If item IsNot Me Then item.BT_Play.Enabled = True

        Next

        If Export Then

            ExportResult()

            Dim i = 1

            For Each item In ExportSteps

                Console.Write(i)

                For Each stepItem As (Nome As String, Valore As Double) In item

                    Console.Write(" - " & stepItem.Nome & " = " & stepItem.Valore.ToString)

                Next
                Console.WriteLine()

                i += 1

            Next

        End If

    End Sub

    Private Sub ExportResult()

        Me.Cursor = Cursors.WaitCursor

        Dim objApp As Excel.Application
        Dim objBook As Excel._Workbook
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet

        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        objSheet = objSheets(1)

        Dim Riga = 2
        For Each item In ExportSteps

            Dim Colonna = 2
            For Each stepItem As (Nome As String, Valore As Double) In item

                objSheet.Cells(1, Colonna).value = stepItem.Nome
                objSheet.Cells(Riga, 1).value = Riga - 1
                objSheet.Cells(Riga, Colonna).value = stepItem.Valore

                Colonna += 1

            Next

            Riga += 1

        Next

        'objSheet.Range("A1:X1").EntireColumn.AutoFit()
        objSheet.Cells.Select()

        'With objApp.Selection.Font
        '    .Name = "Calibri"
        '    .Size = 10
        'End With

        objSheet.Range("A1").Select()

        objApp.Visible = True
        objBook.Activate()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BG_Play_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BG_Play.ProgressChanged

        TrackBar.Value = CInt(e.UserState)

        'LB_value.Text = "" <--- questo causa l'evento nel form principale che scatena l'aggiornamento di tutti gli Slider e rende l'interfaccia non responsiva.

        LB_name.Text = objVar.Name & " = " & e.UserState

        If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
            LB_name.Text = LB_name.Text & " mm"
        ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
            LB_name.Text = LB_name.Text & " °"
        End If

    End Sub



    Public Function GetMin() As Integer

        Return min

    End Function

    Public Function GetMax() As Integer

        Return max

    End Function

    Public Function GetSteps() As Integer

        Return steps

    End Function

    Private Sub BT_Loop_Click(sender As Object, e As EventArgs) Handles BT_Loop.Click

        If BT_Loop.Tag = "Checked" Then

            BT_Loop.Tag = "Unchecked"
            BT_Loop.BackColor = Color.Transparent
            PlayLoop = False

        Else

            BT_Loop.Tag = "Checked"
            BT_Loop.BackColor = Color.Gainsboro
            PlayLoop = True

        End If

    End Sub

    Private Sub LB_name_Click(sender As Object, e As EventArgs) Handles LB_name.Click

        If objVar.IsReadOnly Or objVar.Formula <> "" Then Return

        Try
            TrackBar.Value = InputBox("Set current value",, LB_value.Text)
        Catch ex As Exception
            Exit Sub
        End Try

        objVar.Value = ValueToCad(TrackBar.Value, UnitType)

        LB_value.Text = TrackBar.Value.ToString

        UpdateLabel()

    End Sub

    Private Sub LB_MouseHover(sender As Object, e As EventArgs) Handles LB_min.MouseHover, LB_max.MouseHover, LB_name.MouseHover

        If objVar.IsReadOnly Or objVar.Formula <> "" Then Return
        sender.ForeColor = Color.DarkBlue
        sender.font = New Font(LB_min.Font, FontStyle.Bold)

    End Sub

    Private Sub LB_MouseLeave(sender As Object, e As EventArgs) Handles LB_min.MouseLeave, LB_max.MouseLeave, LB_name.MouseLeave

        If objVar.IsReadOnly Or objVar.Formula <> "" Then Return
        sender.ForeColor = Color.Black
        sender.font = New Font(LB_min.Font, FontStyle.Regular)

    End Sub

    Private Sub BT_Settings_Click(sender As Object, e As EventArgs) Handles BT_Settings.Click

        If objVar.IsReadOnly Or objVar.Formula <> "" Then Return

        Try
            steps = InputBox("Set number of steps",, steps)
        Catch ex As Exception
            Exit Sub
        End Try

        SetTrackBar()

    End Sub

End Class
