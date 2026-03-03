Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient
Public Class ModClass
    '  System.Diagnostics.Process.Start("http://www.desaisoftware.com") to open website
    Public Shared con As SqlConnection
    Public Shared constr As String '= "Data source=192.168.1.79;Initial Catalog=MasterdB;persist security info=true;Uid=SA;Pwd=tax;"
    Private Shared cmd As New SqlCommand
    Public Shared adp As New SqlDataAdapter
    Shared tempDt As New DataTable
    Public Shared Trans As SqlTransaction = Nothing
    Public Shared Cmb As New SqlCommandBuilder
    Public Shared ODt As DataTable
    Public Shared MCalc As Object
    ''for date
    Public Const LOCALE_SSHORTDATE As Integer = &H1FS
    Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer
    Public Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Integer
    Public Shared Sub SetVisualItaxINIValue(ByVal section As String, ByVal element As String, ByVal value As String)
        Dim ini As New IniFile
        Dim sfilename As String
        sfilename = Application.StartupPath & "\Awesome.ini"
        ini.Save(sfilename, section, element, value)
    End Sub
    Public Shared Function GetVisualItaxINIValue(ByVal section As String, ByVal element As String) As String
        Dim ini As New IniFile
        Dim sfilename As String
        sfilename = Application.StartupPath & "\Awesome.ini"
        GetVisualItaxINIValue = ini.fetchkey(sfilename, section, element)
    End Function
    Public Shared Sub ConnectionOpen()
        If Not Directory.Exists(Application.StartupPath & "\log") Then
            Directory.CreateDirectory(Application.StartupPath & "\log")
        End If
        Dim i As Integer = 0
        Try
            ''Start Microsoft Sql Server
            Shell("CMD /C NET START MSSQL$MONARCH", AppWinStyle.Hide, True)
            ''''''''''''''''''''''''''''
            If Not File.Exists(Application.StartupPath & "\Awesome.ini") Then
                Dim sText As New StreamWriter(Application.StartupPath & "\Awesome.ini")
                sText.Close()
                SetVisualItaxINIValue("Connection", "Server", "")
            End If
Start:
            ChConnDb()
            constr = "Data source=" + GetVisualItaxINIValue("Connection", "server") + ";Initial Catalog=Awesome;persist security info=true;Uid=SA;Pwd=monarch@1;Connect Timeout=0"
            con = New SqlConnection(constr)
            con.Open()
            NExcuteQuery("ALTER DATABASE awesome SET READ_WRITE")
        Catch e As Exception
            MsgBox(e.ToString)
            constr = "Data source=" + GetVisualItaxINIValue("Connection", "server") + ";Initial Catalog=master;persist security info=true;Uid=SA;Pwd=monarch@1;Connect Timeout=0"
            con = New SqlConnection(constr)
            con.Open()
            cmd = New SqlClient.SqlCommand("USE master EXEC sp_detach_db @dbname = 'Awesome',@skipchecks = 'true',@KeepFulltextIndexFile = 'true'", con)
            cmd.ExecuteNonQuery()
            If i = 0 Then
                i = 1
                GoTo Start
            End If
            MessageBoxEx.Show("Database Connection Not Intialized.Check Awesome.ini file.", "Awesome", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Environment.Exit(0)
        End Try
        ' End Try
        ''
        MCalc = New FormCalc
    End Sub
    Public Shared Function Encode(ByVal str As String) As String
        Dim enc As New System.Text.UnicodeEncoding
        Dim Buffer As Byte() = enc.GetBytes(str)
        Encode = Convert.ToBase64String(Buffer)
    End Function

    Public Shared Function Decode(ByVal str As String) As String
        Dim enc As New System.Text.UnicodeEncoding
        Dim Buffer As Byte() = Convert.FromBase64String(str)
        Decode = enc.GetString(Buffer)
    End Function

    Private Shared Sub ChConnDb()
        Dim SqlStr As String = ""
        Try
            If GetVisualItaxINIValue("connection", "Server") = "" Then
                SetVisualItaxINIValue("connection", "server", My.Computer.Name + "\Monarch")
            End If
        Catch ex As Exception
        End Try
        Dim chstr As New String("Data source=" + GetVisualItaxINIValue("Connection", "server") + ";Initial Catalog=Master;persist security info=true;Uid=SA;Pwd=monarch@1;")
        con = New SqlConnection(chstr)
        Try
            Try
                con.Open()
            Catch ex As SqlException
                If ex.Number = 18456 Then
                    con.ConnectionString = "Data source=" + GetVisualItaxINIValue("Connection", "server") + ";Initial Catalog=Master;persist security info=true;Uid=SA;Pwd=Monarch@1;"
                    con.Open()
                    NExcuteQuery("ALTER LOGIN [sa] WITH PASSWORD=N'monarch@1' ")
                    '          NExcuteQuery("")
                End If
            End Try
            adp = New SqlDataAdapter("SELECT * FROM MASTER..SYSDATABASES WHERE NAME ='Awesome'", con)
            adp.Fill(tempDt)
            ' MsgBox(tempDt.Rows.Count)
            If Not tempDt.Rows.Count > 0 Then
                Dim path As String = Application.StartupPath
                'MsgBox(path + "\database\Awesome_data.mdf")
                If System.IO.File.Exists(path + "\database\Awesome.mdf") Then
                    ' MsgBox("Database")
                    SqlStr = "sp_attach_db 'Awesome', " _
                    + "'" + Application.StartupPath + "\DataBase\Awesome.mdf'," _
                    + "'" + Application.StartupPath + "\DataBase\Awesome_log.Ldf'"
                    ' MsgBox(SqlStr)
                    cmd = New SqlCommand(SqlStr, con) : cmd.ExecuteNonQuery()
                    ' MsgBox("success")
                Else
                    MessageBoxEx.Show("Database Is Missing.", "Awesome", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Environment.Exit(0)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MessageBoxEx.Show("Database server not found.", "Awesome", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Environment.Exit(0)
        End Try
    End Sub

    Public Shared Sub ConnectionClose()
        con.Close()
    End Sub

    Public Shared Sub NExcuteQuery(ByVal str As String)
        cmd = New SqlCommand(str, con)
        cmd.Transaction = Trans
        cmd.ExecuteNonQuery()

    End Sub
    Public Shared Function FormatDate(ByVal dat As Date) As String
        FormatDate = Format(dat, "yyyyMMdd")
    End Function
    Public Shared Sub FillDevLookUp(ByVal str As String, ByVal Pvaluemember As String, ByVal Pdisplaymember As String, ByVal PEditvalue As String, ByVal ctrl As DevExpress.XtraEditors.LookUpEdit)
        ctrl.Properties.NullText = ""
        ctrl.Properties.DataSource = NFetchDatatable(str)
        ctrl.Properties.DisplayMember = Pdisplaymember
        ctrl.Properties.ValueMember = Pvaluemember
        ctrl.Properties.ShowFooter = False
        Try
            ctrl.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function NFetchDataset(ByVal Query As String) As DataTable
        ODt = New DataTable
        Try
            'cmd.Connection = con
            'cmd.Transaction = Trans
            'cmd.CommandText = Query
            'adp = New OleDbDataAdapter(cmd)
            adp = New SqlDataAdapter(Query, con)
            Cmb = New SqlCommandBuilder(adp)
            adp.Fill(ODt)
            NFetchDataset = ODt
        Catch ex As Exception
            NFetchDataset = Nothing
        End Try
    End Function

    Public Shared Function NExcuteScaler(ByVal str As String) As String
        cmd = New SqlCommand(str, con)
        cmd.Transaction = Trans
        Try
            NExcuteScaler = cmd.ExecuteScalar()
        Catch
            NExcuteScaler = 0
        End Try
    End Function

    Public Shared Function NFetchDatatable(ByVal Query As String) As DataTable
        Dim dtp As New DataTable
        cmd = New SqlCommand(Query, con)
        cmd.Transaction = Trans
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dtp)
        NFetchDatatable = dtp
    End Function

    Public Shared Function NAutoNumber(ByVal str As String) As Double
        'Select max(id) from Id_master
        Dim Id As Double
        Try
            cmd = New SqlCommand(str, con)
            cmd.Transaction = Trans
            If IsDBNull(cmd.ExecuteScalar()) Then
                Id = 1
            Else
                Id = cmd.ExecuteScalar() + 1
            End If
            NAutoNumber = Id
        Catch
            NAutoNumber = 1
        End Try
    End Function

    Public Shared Sub NFillCombo(ByVal str As String, ByVal Nvalue As String, ByVal NDisplay As String, ByVal ctrl As ComboBox)
        Dim dtp As New DataSet
        cmd = New SqlCommand(str, con)
        cmd.Transaction = Trans
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dtp)
        ctrl.DataSource = dtp.Tables(0)
        ctrl.ValueMember = Nvalue
        ctrl.DisplayMember = NDisplay
        ctrl.SelectedIndex = -1
        ctrl.Text = ""
    End Sub

    Public Shared Function NCheckRecord(ByVal str As String) As Boolean
        'select count(pd) from PAPAda
        Dim r As Integer
        NCheckRecord = False
        cmd = New SqlCommand(str, con)
        cmd.Transaction = Trans
        r = cmd.ExecuteScalar
        If r > 0 Then
            NCheckRecord = True
        Else
            NCheckRecord = False
        End If
    End Function

    Public Shared Function NFetchDataB(ByVal STR As String) As Boolean
        cmd = New SqlCommand(STR, con)
        cmd.Transaction = Trans
        If IsDBNull(cmd.ExecuteScalar()) Then
            NFetchDataB = False
        Else
            NFetchDataB = cmd.ExecuteScalar()
        End If
    End Function

    Public Shared Function NFetchData(ByVal STR As String) As String
        cmd = New SqlCommand(STR, con)
        cmd.Transaction = Trans
        If IsDBNull(cmd.ExecuteScalar()) Or cmd.ExecuteScalar() Is Nothing Then
            NFetchData = ""
        Else
            NFetchData = cmd.ExecuteScalar()
        End If
    End Function
    Public Shared Function NFetchDataN(ByVal STR As String) As Double
        cmd = New SqlCommand(STR, con)
        cmd.Transaction = Trans
        If IsDBNull(cmd.ExecuteScalar()) Then
            NFetchDataN = 0
        Else
            NFetchDataN = cmd.ExecuteScalar()
        End If
    End Function
    Public Shared Function NFetchDataD(ByVal STR As String) As Date
        cmd = New SqlCommand(STR, con)
        cmd.Transaction = Trans
        If IsDBNull(cmd.ExecuteScalar()) Then
            NFetchDataD = Nothing
        Else
            NFetchDataD = cmd.ExecuteScalar()
        End If
    End Function
    Public Shared Sub NSystemDateFormat(ByVal str As String)
        Dim xCID As Integer
        Dim xChangedFormat As String

        xCID = GetSystemDefaultLCID()
        xChangedFormat = CStr(str)

        If xChangedFormat <> "" Then
            Call SetLocaleInfo(xCID, LOCALE_SSHORTDATE, xChangedFormat)
        End If
    End Sub
    Public Shared Sub DisableAllControls(ByVal g As Object)
        For Each cnt As Object In g.Controls
            If (TypeOf cnt Is DevExpress.XtraEditors.ComboBoxEdit) Or TypeOf cnt Is DevExpress.XtraEditors.LookUpEdit Or TypeOf cnt Is DevExpress.XtraEditors.RadioGroup Then
                cnt.Properties.ReadOnly = True
                GoTo skip
            End If
            If (TypeOf cnt Is DevExpress.XtraEditors.TextEdit And TypeOf cnt Is DevExpress.XtraEditors.ButtonEdit = False) Or TypeOf cnt Is DevExpress.XtraEditors.CheckEdit Then
                cnt.Properties.ReadOnly = True
                GoTo skip
            End If
            If TypeOf cnt Is DevExpress.XtraEditors.DateEdit Then
                cnt.Properties.ReadOnly = True
                GoTo skip
            End If
            If TypeOf cnt Is DevExpress.XtraEditors.ButtonEdit Then
                cnt.Properties.ReadOnly = True
                GoTo skip
            End If

            If (cnt.Controls.Count > 0) Then
                DisableAllControls(cnt)
                ' Else

                '    If Not (TypeOf cnt Is DevExpress.XtraEditors.SimpleButton Or TypeOf cnt Is LabelX Or TypeOf cnt Is Label Or TypeOf cnt Is DevExpress.XtraEditors.LabelControl) Then
                '        Try
                '            cnt.Properties.ReadOnly = True
                '        Catch ex As Exception

                '        End Try

                '    End If
            End If
skip:
        Next
    End Sub
    Public Shared Sub UpperAll(ByVal frm As Object)
        For Each obj As Object In frm.Controls
            If TypeOf obj Is DevExpress.XtraEditors.LookUpEdit Or TypeOf obj Is DevExpress.XtraEditors.TextEdit Then
                obj.Properties.CharacterCasing = CharacterCasing.Upper
                obj.EnterMoveNextControl = True
            End If
            If TypeOf obj Is DevExpress.XtraEditors.DateEdit Then
                obj.Properties.Mask.masktype = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            End If
            If obj.Controls.Count > 0 Then
                UpperAll(obj)
            End If
        Next
    End Sub

    Public Shared Sub EnableAllControls(ByVal g As Object)

        For Each cnt As Object In g.Controls
            If TypeOf cnt Is DevExpress.XtraEditors.ComboBoxEdit Or TypeOf cnt Is DevExpress.XtraEditors.LookUpEdit Or TypeOf cnt Is DevExpress.XtraEditors.RadioGroup Then
                cnt.Properties.ReadOnly = False
                GoTo skip
            End If
            If (TypeOf cnt Is DevExpress.XtraEditors.TextEdit And TypeOf cnt Is DevExpress.XtraEditors.ButtonEdit = False) Or TypeOf cnt Is DevExpress.XtraEditors.CheckEdit Then
                cnt.Properties.ReadOnly = False
                cnt.Properties.AppearanceReadOnly.BackColor = Color.Gainsboro
                cnt.Properties.AppearanceReadOnly.forecolor = Color.White
                cnt.Properties.AppearanceDisabled.BackColor = Color.LightYellow
                cnt.Properties.AppearanceDisabled.forecolor = Color.Black
                GoTo skip
            End If
            If TypeOf cnt Is DevExpress.XtraEditors.DateEdit Then
                cnt.Properties.ReadOnly = False
                GoTo skip
            End If
            If TypeOf cnt Is DevExpress.XtraEditors.ButtonEdit Then
                Try : cnt.Properties.Buttons(0).Shortcut = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Insert) : Catch : End Try
                cnt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
                If cnt.Properties.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
                    cnt.Properties.Buttons(0).Appearance.BackColor = Color.RosyBrown
                End If
                cnt.Properties.ReadOnly = True
                cnt.Properties.AppearanceReadOnly.BackColor = Color.LightYellow
                cnt.Properties.AppearanceReadOnly.forecolor = Color.Black
                cnt.Properties.AppearanceDisabled.BackColor = Color.Gainsboro
                cnt.Properties.AppearanceDisabled.forecolor = Color.White
                GoTo skip
            End If

            If cnt.Controls.Count > 0 Then
                EnableAllControls(cnt)
                'Else
                '    If Not (TypeOf cnt Is DevExpress.XtraEditors.SimpleButton Or TypeOf cnt Is LabelX Or TypeOf cnt Is Label Or TypeOf cnt Is DevExpress.XtraEditors.LabelControl) Then
                '        Try
                '            cnt.Properties.ReadOnly = False
                '        Catch ex As Exception

                '        End Try
                '    End If
            End If
skip:
        Next
    End Sub


    Public Shared Sub NSetFocus(ByVal e As Integer)
        If e = 13 Or e = 9 Then
            SendKeys.Send("{TAB}")
        ElseIf e = 27 Then
            SendKeys.Send("+{TAB}")
        Else
        End If
    End Sub

    Public Shared Sub NShowInMdi(ByVal frm As Form, ByVal mdi As Form)
        '   Dim found As Boolean = False
        Try
            'For Each ChildForm As Form In mdi.MdiChildren
            '    ChildForm.Close()
            '    found = True
            'Next
            'If found = False Then
            frm.MdiParent = mdi
            frm.WindowState = FormWindowState.Maximized
            frm.MaximizeBox = False
            frm.MinimizeBox = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowIcon = False
            frm.Show()
            frm.BringToFront()
            ' End If
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub NShowInMdiDialog(ByVal frm As Form)
        Dim found As Boolean = False
        Try
            'For Each ChildForm As Form In mdi.MdiChildren
            '    'ChildForm.Close()
            '    found = True
            'Next
            'If found = False Then
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            ' frm.FormBorderStyle = FormBorderStyle.FixedSingle
            frm.StartPosition = FormStartPosition.CenterScreen
            'frm.ShowIcon = False
            frm.ShowInTaskbar = False
            frm.ShowDialog()
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Shared Function GetString(ByVal ival As Double, Optional ByVal retun0 As String = "Nil", Optional ByVal frmt As String = "0.00", Optional ByVal isNegative As Boolean = False) As String
        If ival <= 0 Then
            If isNegative And ival < 0 Then
                GetString = ival
            Else
                GetString = retun0
            End If
        Else
            GetString = Format(ival, frmt)
        End If
    End Function
    Shared Function GetAmountInWord(ByVal X As String) As String

        Dim one(10) As String, two(10) As String, Three(10) As String, Hundred As String, Thousand As String, lakh As String, Crore As String, Billion As String
        one(0) = "Zero" : one(1) = "One" : one(2) = "Two" : one(3) = "Three" : one(4) = "Four" : one(5) = "Five" : one(6) = "Six" : one(7) = "Seven" : one(8) = "Eight" : one(9) = "Nine"
        two(0) = "Ten" : two(1) = "Eleven" : two(2) = "Twelve" : two(3) = "Thirteen" : two(4) = "Fourteen" : two(5) = "Fifteen" : two(6) = "Sixteen" : two(7) = "Seventeen" : two(8) = "Eightteen" : two(9) = "Nineteen"
        Three(2) = "Twenty" : Three(3) = "Thirty" : Three(4) = "Fourty" : Three(5) = "Fifty" : Three(6) = "Sixty" : Three(7) = "Seventy" : Three(8) = "Eighty" : Three(9) = "Ninety"
        Hundred = "Hundred" : Thousand = "Thousand" : lakh = "Lacs" : Crore = "Crore" : Billion = "Billion"

        Dim inp As String, RetVal As String = ""

        inp = Math.Abs(Val(X))


        Select Case Len(inp)
            Case 1
                RetVal = one(X)

            Case 2

                If Int(Right(inp, 1)) > 0 And Left(inp, 1) > 1 Then RetVal = GetAmountInWord(Int(Right(inp, 1))) ' from 20 to 90 step 10

                If Left(inp, 1) > 1 Then RetVal = Three(Left(inp, 1)) + RetVal ' from 20-99
                If Left(inp, 1) = 1 Then RetVal = two(Right(inp, 1)) ' from 11-19 range

            Case 3
                If Int(Right(inp, 2)) > 0 Then RetVal = GetAmountInWord(Int(Right(inp, 2)))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + Hundred + RetVal

            Case 4
                If Int(Right(inp, 3)) > 0 Then RetVal = GetAmountInWord(Int(Right(inp, 3)))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + Thousand + RetVal

            Case 5
                If Int(Right(inp, 3)) > 0 Then RetVal = GetAmountInWord(Int(Right(inp, 3)))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + Thousand + RetVal

            Case 6
                If CLng(Right(inp, 5)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 5)))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + lakh + RetVal

            Case 7
                If CLng(Right(inp, 5)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 5)))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + lakh + RetVal

            Case 8
                If CLng(Right(inp, 7)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 7)))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + Crore + RetVal

            Case 9
                If CLng(Right(inp, 7)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 7)))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + Crore + RetVal

            Case 10
                If CLng(Right(inp, 9)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 9)))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + Billion + RetVal

            Case 11
                If CLng(Right(inp, 9)) > 0 Then RetVal = GetAmountInWord(CLng(Right(inp, 9)))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + Billion + RetVal

            Case 12
                If Val(Right(inp, 11)) > 0 Then RetVal = GetAmountInWord(Right(inp, 11))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + "Million" + RetVal

            Case 13
                If Val(Right(inp, 11)) > 0 Then RetVal = GetAmountInWord(Right(inp, 11))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + "Million" + RetVal

            Case 14
                If Val(Right(inp, 13)) > 0 Then RetVal = GetAmountInWord(Right(inp, 13))
                RetVal = GetAmountInWord(Int(Left(inp, 1))) + "Trillion" + RetVal

            Case 15
                If Val(Right(inp, 13)) > 0 Then RetVal = GetAmountInWord(Right(inp, 13))
                RetVal = GetAmountInWord(Int(Left(inp, 2))) + "Trillion" + RetVal

        End Select

        GetAmountInWord = " " + RetVal + " "

        GetAmountInWord = Replace(GetAmountInWord, "  ", " ")
    End Function
    Public Shared Sub InvalidMessage(ByVal msg As String)
        MessageBoxEx.Show(msg & " Required..", "Invalid Opration", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub NAllreadyMessage(ByVal msg As String)
        MessageBoxEx.Show(msg + " is already exists..", "Invalid Opration", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Function ExitMessage() As Boolean
        If MessageBoxEx.Show("Are you sure quit this application..", "Exit T.D.S.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ExitMessage = True
        Else
            ExitMessage = False
        End If
    End Function
    Public Shared Sub Warning(ByVal msg As String)
        MessageBoxEx.Show(Nothing, "Tax Must Grater than Claimed.", "Visual I-TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, True)
    End Sub
    Public Shared Function FormatAmt(ByVal ival As Double, Optional ByVal sType As String = "O") As String
        Dim sstr() As String = Math.Abs(ival).ToString.Split(".")
        Dim res As String = sstr(0)
        If res.Length > 3 Then
            If sType = "O" Then
                For i As Integer = res.Length To 1 Step -2
                    If i = res.Length Then
                        i = i - 3
                        res = res.Insert(i, ",")
                    Else
                        res = res.Insert(i, ",")
                    End If
                Next
            ElseIf sType = "I" Then
                For i As Integer = res.Length To 1 Step -2
                    If i = res.Length Then
                        i = i - 3
                        res = res.Insert(i, ",")
                    Else
                        res = res.Insert(i, ",")
                    End If
                Next
            ElseIf sType = "F" Then
                res = Format(Val(res), "##,###")
            ElseIf sType = "N" Then
                res = Format(Val(res), "##")
            End If
        End If
        If sType <> "O" Then
            If sstr.Length > 1 Then
                res = res & "." & sstr(1)
            Else
                res = res & ".00"
            End If
        End If
        If ival > 0 Then
            FormatAmt = res
        ElseIf ival < 0 Then
            FormatAmt = "(" & res & ")"
        Else
            FormatAmt = "Nil"
        End If
    End Function

    Public Shared Function FormatNagAmt(ByVal ival As Double) As String
        If ival > 0 Then
            FormatNagAmt = ival
        ElseIf ival < 0 Then
            FormatNagAmt = "(" & Math.Abs(ival) & ")"
        ElseIf ival = 0 Then
            FormatNagAmt = ""
        End If
    End Function

    Public Shared Function isalpahanum(ByVal ch As Char) As Boolean
        If Asc(ch) >= 65 And Asc(ch) <= 90 Then
            isalpahanum = True
        ElseIf Asc(ch) >= 97 And Asc(ch) <= 122 Then
            isalpahanum = True
        ElseIf Asc(ch) >= 48 And Asc(ch) <= 57 Then
            isalpahanum = True
        Else
            isalpahanum = False
        End If
    End Function
    Public Shared Sub GridViewRowIndicator(ByVal Gridview As DevExpress.XtraGrid.Views.Grid.GridView, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        If e.Info.IsRowIndicator Then
            If e.RowHandle > -1 Then
                e.Info.DisplayText = e.RowHandle + 1
            End If
        End If
    End Sub

    Public Shared Sub GridExportPreview(ByVal Rep As Object, ByVal grid As DevExpress.XtraGrid.GridControl, ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim wcn As New DevExpress.XtraReports.UI.WinControlContainer
        wcn.Name = "WindowsControl1"
        ' wcn.SizeF = Rep.defaultPageSize
        wcn.WinControl = grid
        Rep.detail.controls.add(wcn)
        view.SaveLayoutToXml(Application.StartupPath & "\gridExport.xml")
        view.BestFitColumns()
        view.RestoreLayoutFromXml(Application.StartupPath & "\gridExport.xml")
        File.Delete(Application.StartupPath & "\gridExport.xml")
        Dim rpt As New _CustomGridExportPreview
        rpt.PrintControl1.PrintingSystem = Rep.printingSystem
        Rep.createDocument()
        rpt.ShowDialog()
    End Sub

    Public Shared Sub GridFormat(ByVal Gridview As DevExpress.XtraGrid.Views.Grid.GridView)
        Gridview.OptionsCustomization.AllowColumnMoving = False
        Gridview.OptionsCustomization.AllowColumnResizing = False
        Gridview.OptionsCustomization.AllowFilter = False
        Gridview.OptionsCustomization.AllowGroup = False
        Gridview.OptionsCustomization.AllowQuickHideColumns = False
        Gridview.OptionsCustomization.AllowRowSizing = False
        Gridview.OptionsCustomization.AllowSort = False
        Gridview.OptionsView.AllowCellMerge = False
        Gridview.OptionsView.ColumnAutoWidth = False
        Gridview.OptionsView.RowAutoHeight = False
        Gridview.OptionsMenu.EnableColumnMenu = False
        Gridview.OptionsMenu.EnableFooterMenu = False
        Gridview.OptionsMenu.EnableGroupPanelMenu = False
        Gridview.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False
        Gridview.OptionsMenu.ShowAutoFilterRowItem = False
        Gridview.OptionsMenu.ShowDateTimeGroupIntervalItems = False
        Gridview.OptionsMenu.ShowGroupSortSummaryItems = False
        Gridview.OptionsMenu.ShowGroupSummaryEditorItem = False
        Gridview.OptionsNavigation.EnterMoveNextColumn = True
        Gridview.IndicatorWidth = 60
        Gridview.RowHeight = 25
        Gridview.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown
        Gridview.OptionsView.ShowGroupPanel = False
        Gridview.Appearance.Row.Font = New System.Drawing.Font("Verdana", 9.0!)
    End Sub
    Public Shared Sub VerticalGridFormat(ByRef VGrid As DevExpress.XtraVerticalGrid.VGridControl, Optional ByVal FontSize As Byte = 9)
        With VGrid.Appearance.FocusedCell
            .BackColor = Color.White
            .BackColor2 = Color.SkyBlue
            .BorderColor = Color.Silver
            .GradientMode = Drawing2D.LinearGradientMode.Vertical
        End With
        With VGrid.Appearance.FocusedRow
            .BackColor = Color.White
            .BackColor2 = Color.SkyBlue
            .BorderColor = Color.Silver
            .GradientMode = Drawing2D.LinearGradientMode.Vertical
            ' .ForeColor = Color.Black
        End With
        With VGrid.Appearance.ReadOnlyRecordValue
            .ForeColor = Color.Black
            .Font = New Font("Verdana", FontSize)
        End With
        With VGrid.Appearance.DisabledRow
            .BackColor = Color.Gainsboro
            .BackColor2 = Color.DarkGray
            .GradientMode = Drawing2D.LinearGradientMode.Vertical
        End With
        With VGrid.Appearance.DisabledRecordValue
            .BackColor = Color.Gainsboro
            .BackColor2 = Color.DarkGray
            .GradientMode = Drawing2D.LinearGradientMode.Vertical
        End With
        With VGrid.Appearance.ReadOnlyRow
            .ForeColor = Color.Black
        End With

        With VGrid.Appearance.RowHeaderPanel
            .Font = New Font("Verdana", FontSize)
            .ForeColor = Color.Black
        End With
    End Sub
End Class
