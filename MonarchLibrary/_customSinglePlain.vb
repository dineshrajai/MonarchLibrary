Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.IO
Public Class _customSinglePlain
    Public _sTablename As String = ""
    Public _sWhere As String = ""
    'Public _sSql As String = ""
    Public _sPrimaryKey As String = ""
    Public _bindDatasourceProcess As New BindingSource
    Public _bValid As Boolean = False
    Public _Adp As SqlDataAdapter
    Dim _cmb As SqlCommandBuilder
    Dim dt As DataTable
    Dim _cmd As New SqlCommand
    Public isql() As String
    Public _controlObj() As Object
    Public _sflag As Boolean = False
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AddHandler _bindDatasourceProcess.BindingComplete, AddressOf DataChanged
    End Sub
    Sub DataChanged()
        _sflag = True
        btnSave.Enabled = True
    End Sub
    Public Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If _bValid = True Then
            'Dim test As DataTable = CType(_bindDatasourceProcess.DataSource, DataTable)
            'If CType(_bindDatasourceProcess.DataSource, DataTable).GetChanges Is Nothing Then
            '    MsgBox("1")
            'Else
            '    MsgBox("2")
            'End If
            Try
                _bindDatasourceProcess.List.Item(_bindDatasourceProcess.Count - 1)("AssesseeID") = ModGlobalVar.gv_AssesseeId
            Catch ex As Exception

            End Try
            Try
                _bindDatasourceProcess.List.Item(_bindDatasourceProcess.Count - 1)("AsstYearID") = ModGlobalVar.gv_asstYearId
            Catch ex As Exception
            End Try

            Try
                _bindDatasourceProcess.EndEdit()
                _Adp.Update(dt)
            Catch ex As Exception
                _bindDatasourceProcess.EndEdit()
                _Adp.Update(dt)
            End Try

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
            ModGlobalVar._writer.WriteLine(My.Computer.Name & "    save  Changes " & _key & "  by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
            ModGlobalVar._writer.Flush()
            InitializeProcess()
            If bExit Then
                bExit = False
                _sflag = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub _customSinglePlain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.KeyPreview = True
    End Sub
 
    Private Sub _customSinglePlain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _sflag = True Then
            Dim reasult As Windows.Forms.DialogResult
            reasult = MessageBoxEx.Show("Do you want to save changes?", "Save..", MessageBoxButtons.YesNoCancel)
            If reasult = Windows.Forms.DialogResult.Yes Then
                e.Cancel = True
                bExit = True
                save(Nothing, Nothing)
            ElseIf reasult = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub _customSinglePlain_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        InitializeProcess()
    End Sub

    Public Sub InitializeProcess()
        Me.Text = ""
        _cmd.Connection = ModClass.con
        _cmd.Transaction = ModClass.Trans
        _cmd.CommandText = "select * from " + _sTablename + "  where " + _sWhere + " "
        _Adp = New SqlDataAdapter(_cmd)
        _cmb = New SqlCommandBuilder()
        _cmb.DataAdapter = _Adp
        dt = New DataTable
        _Adp.Fill(dt)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add()
        End If
        _bindDatasourceProcess.DataSource = dt
        ModClass.EnableAllControls(Me)
        ModClass.UpperAll(Me)
        _sflag = False
        btnSave.Enabled = False
    End Sub

    Public Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Dim bExit As Boolean = False
    Private Sub _customSinglePlain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            My.Computer.Keyboard.SendKeys("%(S)")
        ElseIf e.Modifiers = Keys.Alt Then
            If e.KeyCode = Keys.F11 Then
                My.Computer.Keyboard.SendKeys("%(P)")
            ElseIf e.KeyCode = Keys.F12 Then
                My.Computer.Keyboard.SendKeys("%(B)")
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            My.Computer.Keyboard.SendKeys("%(E)")
        ElseIf e.KeyCode = Keys.F11 Then
            ModClass.MCalc.show()
            ModClass.MCalc.BringToFront()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chilad As New Object
        chilad = Me
        chilad.btnSave_Click_1(sender, e)
    End Sub

End Class