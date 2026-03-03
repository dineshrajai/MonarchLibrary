Imports DevComponents.DotNetBar
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _customSinglePlain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_customSinglePlain))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrintBlank = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEFilling = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LblTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(772, 32)
        Me.PanelControl1.TabIndex = 2
        '
        'LblTitle
        '
        Me.LblTitle.Appearance.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LblTitle.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTitle.Location = New System.Drawing.Point(2, 2)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(130, 24)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "LabelControl1"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnClose)
        Me.PanelControl2.Controls.Add(Me.btnPrint)
        Me.PanelControl2.Controls.Add(Me.btnPrintBlank)
        Me.PanelControl2.Controls.Add(Me.btnEFilling)
        Me.PanelControl2.Controls.Add(Me.btnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(664, 32)
        Me.PanelControl2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(108, 432)
        Me.PanelControl2.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(2, 110)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "E&xit [F10]"
        '
        'btnPrint
        '
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(2, 83)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 27)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "&Preview (Alt+F11)"
        Me.btnPrint.Visible = False
        '
        'btnPrintBlank
        '
        Me.btnPrintBlank.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintBlank.Appearance.Options.UseFont = True
        Me.btnPrintBlank.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPrintBlank.Image = CType(resources.GetObject("btnPrintBlank.Image"), System.Drawing.Image)
        Me.btnPrintBlank.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnPrintBlank.Location = New System.Drawing.Point(2, 56)
        Me.btnPrintBlank.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnPrintBlank.Name = "btnPrintBlank"
        Me.btnPrintBlank.Size = New System.Drawing.Size(104, 27)
        Me.btnPrintBlank.TabIndex = 2
        Me.btnPrintBlank.Text = "&Blank (Alt+F12)"
        Me.btnPrintBlank.Visible = False
        '
        'btnEFilling
        '
        Me.btnEFilling.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEFilling.Appearance.Options.UseFont = True
        Me.btnEFilling.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEFilling.Image = CType(resources.GetObject("btnEFilling.Image"), System.Drawing.Image)
        Me.btnEFilling.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnEFilling.Location = New System.Drawing.Point(2, 29)
        Me.btnEFilling.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnEFilling.Name = "btnEFilling"
        Me.btnEFilling.Size = New System.Drawing.Size(104, 27)
        Me.btnEFilling.TabIndex = 1
        Me.btnEFilling.Text = "&E-Filling [F12]"
        Me.btnEFilling.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(2, 2)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 27)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save [F5]"
        '
        'PanelControl3
        '
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 32)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(664, 432)
        Me.PanelControl3.TabIndex = 0
        '
        '_customSinglePlain
        '
        Me.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 464)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "_customSinglePlain"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "_CS"
        Me.Text = "_customSinglePlain"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LblTitle As DevExpress.XtraEditors.LabelControl
    Public WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnPrintBlank As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnEFilling As DevExpress.XtraEditors.SimpleButton
    Public WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Public WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
