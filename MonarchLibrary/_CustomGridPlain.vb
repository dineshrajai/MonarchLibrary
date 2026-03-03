Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.IO
Public Class _CustomGridPlain
    Public _Adp As SqlDataAdapter
    Dim _cmb As SqlCommandBuilder
    Dim dt As New DataTable
    Public isql() As String
    Public _controlObj() As Object
    Public _bValid As Boolean
    Public bISExport As Boolean = False
    Public flag As Boolean = False
    Public Sub btngrdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrdSave.Click
        If _bValid = True Then
            For i As Integer = 0 To isql.Length - 1
                dt = _controlObj(i)
                For j As Integer = 0 To dt.Rows.Count - 1
                    Try
                        dt.Rows(j).Item("AssesseeID") = ModGlobalVar.gv_AssesseeId
                        dt.Rows(j).Item("AsstYearID") = ModGlobalVar.gv_asstYearId
                    Catch ex As Exception
                    End Try
                Next
                _Adp = New SqlDataAdapter(isql(i), ModClass.con)
                _cmb = New SqlCommandBuilder(_Adp)
                _Adp.Update(dt)
            Next
            _bValid = False
            ModGlobalVar._writer.WriteLine(My.Computer.Name & "    save  Changes  by " & ModGlobalVar.gv_username & "    " & Me.Name & " for " & ModGlobalVar.gv_fileno)
            ModGlobalVar._writer.Flush()
            flag = False
            btngrdSave.Enabled = False
            If bExit Then
                flag = False
                bExit = False
                Me.Close()
            End If
        End If
    End Sub

    Public Sub btnGrdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrdClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If MarsTest.Globalvar.gblisdemo Or MarsTest.Globalvar.isexpiry Then
            bISExport = False
            MessageBoxEx.Show("Register your software to use this.", "Registration", MessageBoxButtons.OK)
        Else
            bISExport = True
        End If
    End Sub

    Dim bExit As Boolean = False

    Private Sub _CustomGridPlain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If flag = True Then
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
    Private Sub _CustomGridPlain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            SendKeys.Send("%(X)")
        ElseIf e.KeyCode = Keys.F11 Then
            SendKeys.Send("%(E)")
        ElseIf e.KeyCode = Keys.F5 Then
            SendKeys.Send("%(S)")
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            'SendKeys.Send("%(X)")
        End If
    End Sub

    Private Sub save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chilad As New Object
        chilad = Me
        chilad.btngrdSave_Click_1(sender, e)
    End Sub
    Public Sub datachanged()
        flag = True
        btngrdSave.Enabled = True
    End Sub

    Private Sub _CustomGridPlain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        flag = False
        btngrdSave.Enabled = False
    End Sub

End Class