Public Class FormCalc

    Private Sub BtnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZero.Click, _
            BtnOne.Click, BtnTwo.Click, BtnThree.Click, BtnFour.Click, BtnFive.Click, BtnSix.Click, BtnSeven.Click, _
            BtnEight.Click, BtnNine.Click
        txtCell2.EditValue = Val(txtCell2.Text) & Val(sender.text)
    End Sub

    Private Sub BtnDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDot.Click
        txtCell2.EditValue = txtCell2.EditValue + sender.text
    End Sub

    Private Sub BtnDevide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevide.Click, _
            BtnMulti.Click, btnMinus.Click, BtnPlus.Click, BtnCaret.Click
        If LblSign.Text <> "" Then
            '    LblSign.Text = sender.text
            BtnEqual_Click(Nothing, Nothing)
            LblSign.Text = sender.text
        Else
            If txtCell1.Text = "" Then
                txtCell1.Text = Val(txtCell2.Text)
                txtCell2.Text = ""
                LblSign.Text = sender.text
            Else
                LblSign.Text = sender.text
            End If
        End If

    End Sub

    Private Sub BtnEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEqual.Click
        If Trim(LblSign.Text) = "/" Then
            If Val(txtCell2.Text) <> 0 Then
                txtCell1.Text = Val(txtCell1.Text) / Val(txtCell2.Text)
                txtCell2.Text = ""
            Else
                txtCell1.Text = ""
                txtCell2.Text = ""
            End If
            LblSign.Text = ""
        ElseIf Trim(LblSign.Text) = "*" Then
            txtCell1.Text = Val(txtCell1.Text) * Val(txtCell2.Text)
            txtCell2.Text = ""
            LblSign.Text = ""
        ElseIf Trim(LblSign.Text) = "-" Then
            txtCell1.Text = Val(txtCell1.Text) - Val(txtCell2.Text)
            txtCell2.Text = ""
            LblSign.Text = ""
        ElseIf Trim(LblSign.Text) = "+" Then
            txtCell1.Text = Val(txtCell1.Text) + Val(txtCell2.Text)
            txtCell2.Text = ""
            LblSign.Text = ""
        ElseIf Trim(LblSign.Text) = "^" Then
            txtCell1.EditValue = Math.Pow(txtCell1.EditValue, txtCell2.EditValue)
            txtCell2.Text = ""
            LblSign.Text = ""
        End If
    End Sub


    Private Sub txtCell2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCell2.KeyDown
        'If e.KeyCode = Keys.Divide Then
        '    BtnDevide_Click(BtnDevide, Nothing)
        'ElseIf e.KeyCode = Keys.Multiply Then
        '    BtnDevide_Click(BtnMulti, Nothing)
        'ElseIf e.KeyCode = Keys.Subtract Then
        '    BtnDevide_Click(btnMinus, Nothing)
        'ElseIf e.KeyCode = Keys.Add Then
        '    BtnDevide_Click(BtnPlus, Nothing)
        'End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEqual_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Divide Then
            BtnDevide_Click(BtnDevide, Nothing)
        ElseIf e.KeyCode = Keys.Multiply Then
            BtnDevide_Click(BtnMulti, Nothing)
        ElseIf e.KeyCode = Keys.Subtract Then
            BtnDevide_Click(btnMinus, Nothing)
        ElseIf e.KeyCode = Keys.Add Then
            BtnDevide_Click(BtnPlus, Nothing)
        ElseIf e.Modifiers = Keys.Shift Then
            If e.KeyCode = Keys.D6 Then
                BtnDevide_Click(BtnCaret, Nothing)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Hide()
        ElseIf e.KeyCode = Keys.C Then
            BtnC_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Back Then
            BtnBack_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Len(txtCell2.Text) <= 10 Then
            If (e.KeyChar >= Chr(48) And e.KeyChar <= Chr(57)) Or e.KeyChar = Chr(46) Then
                If txtCell2.Text.Contains(".") And e.KeyChar = Chr(46) Then
                    txtCell2.EditValue = txtCell2.Text
                Else
                    txtCell2.EditValue = txtCell2.Text & e.KeyChar
                End If
            End If
        End If
    End Sub

    Private Sub BtnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnC.Click
        txtCell1.EditValue = ""
        txtCell2.EditValue = ""
        LblSign.Text = ""
    End Sub


    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        txtCell2.EditValue = Strings.Left(txtCell2.Text, Math.Max(Len(txtCell2.Text) - 1, 0))
    End Sub


    'Private Sub BtnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEsc.Click
    '    txtCell2.SelectAll()
    '    txtCell2.Copy()
    '    TextEdit1.Focus()
    '    TextEdit1.Paste()
    '    'Me.Hide()
    'End Sub
End Class
