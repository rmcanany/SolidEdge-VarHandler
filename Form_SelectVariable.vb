Imports SolidEdgeConstants

Public Class Form_SelectVariable

    Public ObjDoc As SolidEdgeFramework.SolidEdgeDocument
    Public Valid As Boolean = False
    Public LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants

    Private Sub Form_SelectVariable_Load(sender As Object, e As EventArgs) Handles Me.Load

        RefreshList()

    End Sub

    Private Sub RefreshList()

        ListBox_Variables.Items.Clear()

        Dim _FindVars = FindVars()

        If Not IsNothing(_FindVars) Then

            ListBox_Variables.DisplayMember = "Name"

            Dim UU As New UtilsUnits(ObjDoc)

            For Each item In _FindVars

                Dim UnitString = UU.GetUnitReadout(item)

                Dim tmpVar As New VarListItem(item, LengthUnits, ObjDoc)

                'tmpVar.LengthUnits = LengthUnits   '<---- This has to be set before the VarListItem is created
                ListBox_Variables.Items.Add(tmpVar)

            Next

        End If

    End Sub

    Private Function FindVars() As Object

        Dim NameBy As Object = Nothing
        If CB_Users.Checked And CB_System.Checked Then NameBy = 2
        If Not CB_Users.Checked And CB_System.Checked Then NameBy = 1
        If CB_Users.Checked And Not CB_System.Checked Then NameBy = 0
        If Not CB_Users.Checked And Not CB_System.Checked Then Return Nothing

        Dim _VarType As Object = Nothing
        If CB_Variables.Checked And CB_Dimensions.Checked Then _VarType = 3
        If CB_Variables.Checked And Not CB_Dimensions.Checked Then _VarType = 2
        If Not CB_Variables.Checked And CB_Dimensions.Checked Then _VarType = 1
        If Not CB_Variables.Checked And Not CB_Dimensions.Checked Then Return Nothing

        If Not IsNothing(ObjDoc) Then

            Dim objVars As SolidEdgeFramework.Variables = ObjDoc.Variables
            Dim _FindVars = objVars.Query("*", NameBy, _VarType)

            Return _FindVars

        End If

        Return Nothing

    End Function

    Private Sub BT_OK_Click(sender As Object, e As EventArgs) Handles BT_OK.Click

        If ListBox_Variables.SelectedItems.Count > 0 Then
            Valid = True
        Else
            Valid = False
        End If

        Me.Close()

    End Sub

    Private Sub BT_Cancel_Click(sender As Object, e As EventArgs) Handles BT_Cancel.Click

        Valid = False

        Me.Close()

    End Sub

    Private Sub CB_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Users.CheckedChanged, CB_System.CheckedChanged, CB_Variables.CheckedChanged, CB_Dimensions.CheckedChanged

        refreshList()

    End Sub

End Class

Public Class VarListItem

    Public Property Name As String
    Public Property VarName As String
    Public Property Value As String
    Public Property Formula As String
    Public Property ObjVariable As Object 'SolidEdgeFramework.variable
    'Public Property objDimension As SolidEdgeFrameworkSupport.Dimension
    Public Property ExName As String
    Public Property LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants

    Public Property NewWay As Boolean = True
    Public Property ObjDoc As SolidEdgeFramework.SolidEdgeDocument

    Public Sub New(
        objVar As Object,
        _LengthUnits As SolidEdgeConstants.UnitOfMeasureLengthReadoutConstants,
        _ObjDoc As SolidEdgeFramework.SolidEdgeDocument) 'SolidEdgeFramework.variable)

        'If TypeOf (objVar) Is SolidEdgeFramework.variable Then
        ObjVariable = objVar
        'Else
        '    objDimension = objVar
        'End If

        LengthUnits = _LengthUnits
        ObjDoc = _ObjDoc

        VarName = objVar.Name
        Formula = objVar.Formula
        ExName = objVar.ExposeName

        If ExName <> "" Then ExName = " -->(" & ExName & ")"

        Dim UnitType = objVar.UnitsType

        Dim UU As New UtilsUnits(ObjDoc)

        If NewWay Then
            Dim tmpValue As Double
            objVar.GetValueEx(tmpValue, SolidEdgeFramework.seUnitsTypeConstants.seUnitsType_Document)

            Value = CStr(tmpValue)

            Dim UnitReadout As String = UU.GetUnitReadout(objVar)

            If Not UnitReadout = "" Then Value = String.Format("{0} {1}", Value, UnitReadout)

        Else
            Value = UC_Slider.CadToValue(objVar.Value, UnitType, LengthUnits).ToString

            If UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance Then
                If LengthUnits = UnitOfMeasureLengthReadoutConstants.seLengthInch Then
                    Value = Value & " in"
                ElseIf LengthUnits = UnitOfMeasureLengthReadoutConstants.seLengthMillimeter Then
                    Value = Value & " mm"
                End If
            ElseIf UnitType = SolidEdgeFramework.UnitTypeConstants.igUnitAngle Then
                Value = Value & " °"
            End If
        End If

        If Formula = "" Then
            Name = objVar.Name & ExName & " = " & Value
        Else
            Name = objVar.Name & ExName & " = " & objVar.Formula
        End If

    End Sub

End Class