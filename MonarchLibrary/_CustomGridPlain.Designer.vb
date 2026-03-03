Imports DevComponents.DotNetBar
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _CustomGridPlain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_CustomGridPlain))
        Me.pnlBtn = New DevExpress.XtraEditors.PanelControl
        Me.lbldelmsg = New DevExpress.XtraEditors.LabelControl
        Me.btnGrdClose = New DevExpress.XtraEditors.SimpleButton
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton
        Me.btngrdSave = New DevExpress.XtraEditors.SimpleButton
        CType(Me.pnlBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.lbldelmsg)
        Me.pnlBtn.Controls.Add(Me.btnGrdClose)
        Me.pnlBtn.Controls.Add(Me.btnDelete)
        Me.pnlBtn.Controls.Add(Me.btnExport)
        Me.pnlBtn.Controls.Add(Me.btngrdSave)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtn.Location = New System.Drawing.Point(575, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(148, 482)
        Me.pnlBtn.TabIndex = 1
        '
        'lbldelmsg
        '
        Me.lbldelmsg.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldelmsg.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lbldelmsg.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbldelmsg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbldelmsg.Location = New System.Drawing.Point(2, 110)
        Me.lbldelmsg.Name = "lbldelmsg"
        Me.lbldelmsg.Size = New System.Drawing.Size(129, 13)
        Me.lbldelmsg.TabIndex = 51
        Me.lbldelmsg.Text = "Ctrl+Del =All Delete"
        '
        'btnGrdClose
        '
        Me.btnGrdClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrdClose.Appearance.Options.UseFont = True
        Me.btnGrdClose.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGrdClose.Image = CType(resources.GetObject("btnGrdClose.Image"), System.Drawing.Image)
        Me.btnGrdClose.Location = New System.Drawing.Point(2, 83)
        Me.btnGrdClose.Name = "btnGrdClose"
        Me.btnGrdClose.Size = New System.Drawing.Size(144, 27)
        Me.btnGrdClose.TabIndex = 3
        Me.btnGrdClose.Text = "E&xit [F10]"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(2, 56)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(144, 27)
        Me.btnDelete.TabIndex = 52
        Me.btnDelete.Text = "&Delete [F9]"
        '
        'btnExport
        '
        Me.btnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Appearance.Options.UseFont = True
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Location = New System.Drawing.Point(2, 29)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(144, 27)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "&Export [F11]"
        Me.btnExport.Visible = False
        '
        'btngrdSave
        '
        Me.btngrdSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngrdSave.Appearance.Options.UseFont = True
        Me.btngrdSave.Dock = System.Windows.Forms.DockStyle.Top
        Me.btngrdSave.Image = CType(resources.GetObject("btngrdSave.Image"), System.Drawing.Image)
        Me.btngrdSave.Location = New System.Drawing.Point(2, 2)
        Me.btngrdSave.Name = "btngrdSave"
        Me.btngrdSave.Size = New System.Drawing.Size(144, 27)
        Me.btngrdSave.TabIndex = 1
        Me.btngrdSave.Text = "&Save [F5]"
        '
        '_CustomGridPlain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 482)
        Me.Controls.Add(Me.pnlBtn)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "_CustomGridPlain"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "_CG"
        Me.Text = "_CustomGridPlain"
        CType(Me.pnlBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtn.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btngrdSave As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnGrdClose As DevExpress.XtraEditors.SimpleButton
    Public WithEvents lbldelmsg As DevExpress.XtraEditors.LabelControl
    Public WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Public WithEvents pnlBtn As DevExpress.XtraEditors.PanelControl
End Class
