Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.IO

Public Class _CustomDetail
    Public _sTablename As String = ""
    Public _sSql As String = ""
    Public _sPrimaryKey As String = ""
    Public _bindDatasourceProcess As New BindingSource
    Public _bindDatasourceList As New BindingSource
    Public _bDeleteDone As Boolean = False
    Public _bValid As Boolean = False
    Dim _currentRecord As Integer = 0
    Public _Adp As SqlDataAdapter
    Dim _cmb As SqlCommandBuilder
    Dim dt As DataTable
    Public _currentdeletedRecord As Integer = 0
    Public isql() As String
    Public _controlObj() As Object
    Public _SCflag As Boolean = False
    Public gv_View As String
    Dim startflag As Boolean = False
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        '    isql = Nothing
        '    _controlObj = Nothing
        ' Add any initialization after the InitializeComponent() call.
        AddHandler _bindDatasourceProcess.BindingComplete, AddressOf DataChanged

    End Sub
    Sub DataChanged()
        _SCflag = True
        btnSave.Enabled = True
        'btncancel.Enabled = True
    End Sub
    Public Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _Adp = New SqlDataAdapter("select * from " + _sTablename + "  where " + _sPrimaryKey + " = 0 ", ModClass.con)
        _cmb = New SqlCommandBuilder()
        _cmb.DataAdapter = _Adp
        dt = New DataTable
        _Adp.Fill(dt)
        dt.Rows.Add()
        _bindDatasourceProcess.DataSource = dt
        ModClass.EnableAllControls(PanelControl2)
        _currentRecord = GridView1.RowCount
        '  PanelControl2.Enabled = True
        _SCflag = False
        btnSave.Enabled = False
        'btncancel.Enabled = False
        btnEdit.Enabled = False
        btnAdd.Enabled = False
        btnDelete.Enabled = False
        PanelControl2.Focus()
        ModGlobalVar._writer.WriteLine(My.Computer.Name & "    add by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
        ModGlobalVar._writer.Flush()

    End Sub
    Public Sub fillgrid()
        GridView1.ClearSorting()
        _bindDatasourceList.DataSource = ModClass.NFetchDatatable(_sSql)
        grdList.DataSource = _bindDatasourceList
        '  _bindDatasourceProcess.DataSource = _bindDatasourceList
        If File.Exists(Application.StartupPath & "\" & Me.Name & ".xml") Then
            GridView1.RestoreLayoutFromXml(Application.StartupPath & "\" & Me.Name & ".xml")
        End If
        GridView1.Columns(_sPrimaryKey).Visible = False
        GridView1.OptionsView.ShowAutoFilterRow = False
        ' GridView1.Columns(1).Group()
        '  GridView1.Columns(_sPrimaryKey).Visible = False
        Try
            If GridView1.DataRowCount > 0 And _currentRecord <= 0 Then
                _currentRecord = 0
            End If
            ' GridView1.SelectRow(_currentRecord)
            GridView1.FocusedRowHandle = _currentRecord
        Catch ex As Exception
        End Try
        If GridView1.IsDataRow(GridView1.FocusedRowHandle) Then
            fillProcess()
        ElseIf GridView1.DataRowCount = 0 Or _bindDatasourceProcess.DataSource Is Nothing Then
            fillProcess()
        End If
        If GridView1.DataRowCount > 0 Then
            GridView1.Focus()
        Else
            btnAdd.Focus()
        End If
        GridView1.FocusedRowHandle = _currentRecord
        _BtnEnableDisable()
    End Sub

    Sub fillProcess(Optional ByVal key As Long = 0)
        If key = 0 Then
            If GridView1.DataRowCount > 0 Then
                _Adp = New SqlDataAdapter("select * from " + _sTablename + "  where " + _sPrimaryKey + " = " + GridView1.GetRowCellValue(GridView1.GetSelectedRows()(0), _sPrimaryKey).ToString + "", ModClass.con)
            Else
                _Adp = New SqlDataAdapter("select * from " + _sTablename + "  where " + _sPrimaryKey + " = 0", ModClass.con)
            End If
        Else
            _Adp = New SqlDataAdapter("select * from " & _sTablename & "  where " & _sPrimaryKey & " = " & key & "", ModClass.con)
        End If
        _cmb = New SqlCommandBuilder()
        _cmb.DataAdapter = _Adp
        dt = New DataTable
        _Adp.Fill(dt)
        _bindDatasourceProcess.DataSource = dt
        _SCflag = False
        btnSave.Enabled = False
        'btncancel.Enabled = False
    End Sub
    Sub _BtnEnableDisable()
        btnEdit.Enabled = GridView1.DataRowCount > 0
        btnDelete.Enabled = GridView1.DataRowCount > 0
    End Sub

    Public Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        GridView1.SaveLayoutToXml(Application.StartupPath & "\" & Me.Name & ".xml")
        Me.Close()
    End Sub

    Public Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If GridView1.IsDataRow(GridView1.FocusedRowHandle) Then
            If MessageBoxEx.Show("Sure to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                fillProcess()
                If _sTablename.ToLower() = "mst_assessee" Then
                    If _bindDatasourceProcess.List.Item(_bindDatasourceProcess.List.Count - 1)("LockFile") = True Then
                        MessageBoxEx.Show("Demo assessee Can not delete.", "Asseessee", MessageBoxButtons.OK)
                        _bDeleteDone = False
                        Exit Sub
                    ElseIf _bindDatasourceProcess.List.Item(_bindDatasourceProcess.List.Count - 1)("AssesseeID") = ModGlobalVar.gv_AssesseeId Then
                        MessageBoxEx.Show("Assessee in Use.", "Asseessee", MessageBoxButtons.OK)
                        _bDeleteDone = False
                        Exit Sub
                    End If
                End If
                'Dim sSql As String
                'sSql = "Delete from " + _sTablename + " where " + _sPrimaryKey + " = " + GridView1.GetRowCellValue(GridView1.GetSelectedRows()(0), _sPrimaryKey).ToString
                Try
                    ' NExcuteQuery(sSql)
                    _currentdeletedRecord = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, _sPrimaryKey)
                    _bindDatasourceProcess.RemoveCurrent()
                    '_bindDatasourceList.EndEdit()
                    _bDeleteDone = True
                    _Adp.Update(dt)
                    ModGlobalVar._writer.WriteLine(My.Computer.Name & "    Delete record " & _currentdeletedRecord & "  by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
                    ModGlobalVar._writer.Flush()
                    Try
                        _currentRecord = IIf(GridView1.FocusedRowHandle - 1 > 0, GridView1.FocusedRowHandle - 1, 0)
                    Catch ex As Exception

                    End Try
                    fillgrid()
                    '   PanelControl2.Enabled = False
                Catch ex As Exception
                End Try
            Else
                _bDeleteDone = False
            End If
        End If
    End Sub

    Public Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If _bValid = True Then
            _bindDatasourceProcess.EndEdit()
            _Adp.Update(dt)
            'Catch ex As SqlException
            '    MsgBox(ex.ErrorCode)
            'End Try
            Dim _key As Integer
            _key = Val(dt.Rows(dt.Rows.Count - 1).Item(0).ToString)
            If _key = 0 Then
                _key = ModClass.NExcuteScaler("select distinct @@identity from " & _sTablename & "")
                '_bindDatasourceProcess.List.Item(0)(_sPrimaryKey) = _key
                '_bindDatasourceProcess.EndEdit()
                '_Adp.Update(dt)
            End If
            Dim dt1 As New DataTable
            Try
                For i As Integer = 0 To isql.Length - 1
                    dt1 = _controlObj(i)
                    For j As Integer = 0 To dt1.Rows.Count - 1
                        Try
                            dt1.Rows(j).Item(_sPrimaryKey) = _key
                        Catch ex As Exception

                        End Try
                    Next
                    _Adp = New SqlDataAdapter(isql(i), ModClass.con)
                    _cmb = New SqlCommandBuilder(_Adp)
                    '   _bindDatasourceProcess.DataSource = dt1
                    _Adp.Update(dt1)
                Next
            Catch ex As Exception

            End Try
            _bValid = False
            _SCflag = False
            ModGlobalVar._writer.WriteLine(My.Computer.Name & "    save record " & _key & "  by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
            ModGlobalVar._writer.Flush()
            fillgrid()
            ' _currentRecord = GridView1.GetFocusedDataSourceRowIndex()
            If bExit Then
                bExit = False
                Me.Close()
            Else
                fillProcess(_key)
            End If
            '     PanelControl2.Enabled = False
            btnSave.Enabled = False
            'btncancel.Enabled = False
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Public Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If GridView1.IsDataRow(GridView1.FocusedRowHandle) Then
            fillProcess()
            ModGlobalVar._writer.WriteLine(My.Computer.Name & "    Edit record " & _bindDatasourceProcess.List(0)(_sPrimaryKey).ToString & "  by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
            ModGlobalVar._writer.Flush()
            ModClass.EnableAllControls(PanelControl2)
            _currentRecord = GridView1.GetFocusedDataSourceRowIndex()
            btnEdit.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            PanelControl2.Focus()
        End If
    End Sub

    Public Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        _bindDatasourceProcess.CancelEdit()
        If _bindDatasourceProcess.List.Count = 0 Then
        Else
            fillProcess(Val(_bindDatasourceProcess.List.Item(0)(_sPrimaryKey).ToString))
        End If
        GridView1.Focus()
        btnAdd.Enabled = True
        _BtnEnableDisable()
        'btncancel.Enabled = False
        btnSave.Enabled = False
        _SCflag = False
    End Sub

    Private Sub _customMasterForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.KeyPreview = True
    End Sub

    Private Sub _customMasterForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _SCflag = True Then
            Dim reasult As Windows.Forms.DialogResult
            reasult = MessageBoxEx.Show("Do you want to save changes?", "Save..", MessageBoxButtons.YesNoCancel)
            If reasult = Windows.Forms.DialogResult.Yes Then
                e.Cancel = True
                bExit = True
                save(Nothing, Nothing)
            ElseIf reasult = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
                '_SCflag = False
                'GridView1.Focus()
            Else
                _SCflag = False
            End If
        End If
    End Sub

    Private Sub _customMasterForm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        InitializeProcess()
    End Sub
    Public Sub InitializeProcess()
        Me.Text = ""
        fillgrid()
        grdList.Focus()
        ModClass.UpperAll(Me)
    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        If _SCflag = False And btnEdit.Enabled = True Then
            Edit(Nothing, Nothing)
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If _SCflag = False Then
            If GridView1.FocusedRowHandle >= 0 Then
                ' GridView1.SelectRow(GridView1.FocusedRowHandle)
                If GridView1.IsDataRow(GridView1.FocusedRowHandle) Then
                    fillProcess()
                End If
            End If
            btnAdd.Enabled = True
            _BtnEnableDisable()
            btnSave.Enabled = False
            'btncancel.Enabled = False
        Else

        End If
    End Sub

    Private Sub GridView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.GotFocus
        If _SCflag = True Then
            btnSave.Focus()
        Else
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = False
            'btncancel.Enabled = False
            _BtnEnableDisable()
        End If
    End Sub

    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If _SCflag = False And btnEdit.Enabled = True Then
                Edit(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub GridView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseWheel
        If e.Delta = -120 Then
            Try : GridView1.FocusedRowHandle = GridView1.FocusedRowHandle + 1 : Catch : End Try
        ElseIf e.Delta = 120 Then
            Try : GridView1.FocusedRowHandle = GridView1.FocusedRowHandle - 1 : Catch : End Try
        End If
    End Sub

    Private Sub _customMasterForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 And btnAdd.Enabled = True Then
            Add(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 And btnEdit.Enabled = True Then
            Edit(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 And btnSave.Enabled = True Then
            save(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F7 Then
            SendKeys.Send("%(B)")
        ElseIf e.KeyCode = Keys.F8 Then
            SendKeys.Send("%(U)")
        ElseIf e.KeyCode = Keys.F9 And btnDelete.Enabled = True Then
            SendKeys.Send("%(D)")
        ElseIf e.KeyCode = Keys.F10 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F11 Then
            ModClass.MCalc.show()
            ModClass.MCalc.BringToFront()

        End If
    End Sub
    Dim bExit As Boolean = False

    Private Sub _customMasterForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        btnAdd.Enabled = True
        _BtnEnableDisable()
        btnSave.Enabled = False
        'btncancel.Enabled = False
        If GridView1.DataRowCount > 0 Then
            GridView1.Focus()
        Else
            btnAdd.Focus()
        End If
        startflag = True
        '  PanelControl2.Enabled = False
    End Sub

    Private Sub Add(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnAdd_Click(sender, e)
        Dim chilad As New Object
        chilad = Me
        chilad.btnAdd_Click_1(sender, e)
    End Sub
    Private Sub save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chilad As New Object
        chilad = Me
        chilad.btnSave_Click_1(sender, e)
    End Sub
    Private Sub Edit(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnEdit_Click(sender, e)
        Dim chilad As New Object
        chilad = Me
        chilad.btnEdit_Click_1(sender, e)
    End Sub
    Private Sub PanelControl2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelControl2.Enter
        If startflag Then
            If btnAdd.Enabled = True And btnEdit.Enabled = True Then
                Edit(sender, e)
            ElseIf btnEdit.Enabled = False And btnAdd.Enabled = True Then
                Add(sender, e)
            End If
        End If
    End Sub
End Class
