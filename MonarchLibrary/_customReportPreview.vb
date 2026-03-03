Public Class _customReportPreview

    Private Sub _customReportPreview_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        _ctrlPreview.ZoomPageWidth()
        If MarsTest.Globalvar.isexpiry Or MarsTest.Globalvar.gblisdemo Then
            _ctrlPreview.Buttons = FastReport.PreviewButtons.All - (FastReport.PreviewButtons.Print + FastReport.PreviewButtons.Edit + FastReport.PreviewButtons.Open + FastReport.PreviewButtons.Save + FastReport.PreviewButtons.Watermark + +FastReport.PreviewButtons.Outline + +FastReport.PreviewButtons.Email)
        Else
            '_ctrlPreview.Buttons = FastReport.PreviewButtons.All - (FastReport.PreviewButtons.Open + FastReport.PreviewButtons.Outline)
            _ctrlPreview.Buttons = FastReport.PreviewButtons.All - (FastReport.PreviewButtons.Edit + FastReport.PreviewButtons.Open + FastReport.PreviewButtons.Outline)
        End If
    End Sub

End Class