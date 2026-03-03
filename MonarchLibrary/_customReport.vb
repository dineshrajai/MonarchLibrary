Public Class _customReport

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub _customReport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.KeyPreview = True
    End Sub

    Private Sub _customReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            SendKeys.Send("%(X)")
        ElseIf e.KeyCode = Keys.F5 Then
            SendKeys.Send("%(P)")
        ElseIf e.KeyCode = Keys.F8 Then
            SendKeys.Send("%(C)")
        End If
    End Sub
End Class