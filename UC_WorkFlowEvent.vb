Public Class UC_WorkFlowEvent
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

End Class
