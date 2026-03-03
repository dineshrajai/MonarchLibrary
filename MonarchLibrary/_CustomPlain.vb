Public Class _CustomPlain
    Private Sub btnSubClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubClose.Click
        Me.Hide()
    End Sub

    Private Sub _CustomPlain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.KeyPreview = True
    End Sub

    Private Sub _CustomPlain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Or e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F11 Then
            ModClass.MCalc.show()
            ModClass.MCalc.BringToFront()

        End If
    End Sub
End Class