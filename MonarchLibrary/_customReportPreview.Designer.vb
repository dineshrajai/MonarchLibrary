Imports DevComponents.DotNetBar
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _customReportPreview
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_customReportPreview))
        Me._ctrlPreview = New FastReport.Preview.PreviewControl
        Me.SuspendLayout()
        '
        '_ctrlPreview
        '
        Me._ctrlPreview.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me._ctrlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me._ctrlPreview.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me._ctrlPreview.Location = New System.Drawing.Point(0, 0)
        Me._ctrlPreview.Name = "_ctrlPreview"
        Me._ctrlPreview.Size = New System.Drawing.Size(607, 454)
        Me._ctrlPreview.TabIndex = 0
        '
        '_customReportPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 454)
        Me.Controls.Add(Me._ctrlPreview)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "_customReportPreview"
        Me.ShowInTaskbar = False
        Me.Text = "_customReportPreview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents _ctrlPreview As FastReport.Preview.PreviewControl
End Class
