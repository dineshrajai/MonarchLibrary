<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCalc
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCalc))
        Me.txtCell1 = New DevExpress.XtraEditors.TextEdit
        Me.BtnC = New DevExpress.XtraEditors.SimpleButton
        Me.BtnDevide = New DevExpress.XtraEditors.SimpleButton
        Me.BtnNine = New DevExpress.XtraEditors.SimpleButton
        Me.BtnMulti = New DevExpress.XtraEditors.SimpleButton
        Me.BtnEight = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSeven = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSix = New DevExpress.XtraEditors.SimpleButton
        Me.btnMinus = New DevExpress.XtraEditors.SimpleButton
        Me.BtnFive = New DevExpress.XtraEditors.SimpleButton
        Me.BtnFour = New DevExpress.XtraEditors.SimpleButton
        Me.BtnThree = New DevExpress.XtraEditors.SimpleButton
        Me.BtnPlus = New DevExpress.XtraEditors.SimpleButton
        Me.BtnTwo = New DevExpress.XtraEditors.SimpleButton
        Me.BtnOne = New DevExpress.XtraEditors.SimpleButton
        Me.BtnDot = New DevExpress.XtraEditors.SimpleButton
        Me.BtnEqual = New DevExpress.XtraEditors.SimpleButton
        Me.BtnZero = New DevExpress.XtraEditors.SimpleButton
        Me.txtCell2 = New DevExpress.XtraEditors.TextEdit
        Me.BtnBack = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCaret = New DevExpress.XtraEditors.SimpleButton
        Me.BtnEsc = New DevExpress.XtraEditors.SimpleButton
        Me.LblSign = New DevExpress.XtraEditors.LabelControl
        CType(Me.txtCell1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCell2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCell1
        '
        Me.txtCell1.Enabled = False
        Me.txtCell1.Location = New System.Drawing.Point(12, 9)
        Me.txtCell1.Name = "txtCell1"
        Me.txtCell1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCell1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCell1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.txtCell1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.txtCell1.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.txtCell1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCell1.Size = New System.Drawing.Size(183, 20)
        Me.txtCell1.TabIndex = 0
        '
        'BtnC
        '
        Me.BtnC.AllowFocus = False
        Me.BtnC.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnC.Appearance.Options.UseFont = True
        Me.BtnC.Location = New System.Drawing.Point(138, 66)
        Me.BtnC.Name = "BtnC"
        Me.BtnC.Size = New System.Drawing.Size(36, 23)
        Me.BtnC.TabIndex = 1
        Me.BtnC.Text = "C"
        '
        'BtnDevide
        '
        Me.BtnDevide.AllowFocus = False
        Me.BtnDevide.Appearance.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDevide.Appearance.Options.UseFont = True
        Me.BtnDevide.Location = New System.Drawing.Point(180, 66)
        Me.BtnDevide.Name = "BtnDevide"
        Me.BtnDevide.Size = New System.Drawing.Size(36, 23)
        Me.BtnDevide.TabIndex = 1
        Me.BtnDevide.Text = "/"
        '
        'BtnNine
        '
        Me.BtnNine.AllowFocus = False
        Me.BtnNine.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNine.Appearance.Options.UseFont = True
        Me.BtnNine.Location = New System.Drawing.Point(97, 66)
        Me.BtnNine.Name = "BtnNine"
        Me.BtnNine.Size = New System.Drawing.Size(36, 23)
        Me.BtnNine.TabIndex = 1
        Me.BtnNine.Text = "9"
        '
        'BtnMulti
        '
        Me.BtnMulti.AllowFocus = False
        Me.BtnMulti.Appearance.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMulti.Appearance.Options.UseFont = True
        Me.BtnMulti.Location = New System.Drawing.Point(180, 95)
        Me.BtnMulti.Name = "BtnMulti"
        Me.BtnMulti.Size = New System.Drawing.Size(36, 23)
        Me.BtnMulti.TabIndex = 1
        Me.BtnMulti.Text = "*"
        '
        'BtnEight
        '
        Me.BtnEight.AllowFocus = False
        Me.BtnEight.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEight.Appearance.Options.UseFont = True
        Me.BtnEight.Location = New System.Drawing.Point(55, 66)
        Me.BtnEight.Name = "BtnEight"
        Me.BtnEight.Size = New System.Drawing.Size(36, 23)
        Me.BtnEight.TabIndex = 1
        Me.BtnEight.Text = "8"
        '
        'BtnSeven
        '
        Me.BtnSeven.AllowFocus = False
        Me.BtnSeven.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeven.Appearance.Options.UseFont = True
        Me.BtnSeven.Location = New System.Drawing.Point(7, 66)
        Me.BtnSeven.Name = "BtnSeven"
        Me.BtnSeven.Size = New System.Drawing.Size(42, 23)
        Me.BtnSeven.TabIndex = 1
        Me.BtnSeven.Text = "7"
        '
        'BtnSix
        '
        Me.BtnSix.AllowFocus = False
        Me.BtnSix.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSix.Appearance.Options.UseFont = True
        Me.BtnSix.Location = New System.Drawing.Point(97, 95)
        Me.BtnSix.Name = "BtnSix"
        Me.BtnSix.Size = New System.Drawing.Size(36, 23)
        Me.BtnSix.TabIndex = 1
        Me.BtnSix.Text = "6"
        '
        'btnMinus
        '
        Me.btnMinus.AllowFocus = False
        Me.btnMinus.Appearance.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinus.Appearance.Options.UseFont = True
        Me.btnMinus.Location = New System.Drawing.Point(180, 124)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(36, 23)
        Me.btnMinus.TabIndex = 1
        Me.btnMinus.Text = "-"
        '
        'BtnFive
        '
        Me.BtnFive.AllowFocus = False
        Me.BtnFive.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFive.Appearance.Options.UseFont = True
        Me.BtnFive.Location = New System.Drawing.Point(55, 95)
        Me.BtnFive.Name = "BtnFive"
        Me.BtnFive.Size = New System.Drawing.Size(36, 23)
        Me.BtnFive.TabIndex = 1
        Me.BtnFive.Text = "5"
        '
        'BtnFour
        '
        Me.BtnFour.AllowFocus = False
        Me.BtnFour.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFour.Appearance.Options.UseFont = True
        Me.BtnFour.Location = New System.Drawing.Point(7, 95)
        Me.BtnFour.Name = "BtnFour"
        Me.BtnFour.Size = New System.Drawing.Size(42, 23)
        Me.BtnFour.TabIndex = 1
        Me.BtnFour.Text = "4"
        '
        'BtnThree
        '
        Me.BtnThree.AllowFocus = False
        Me.BtnThree.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThree.Appearance.Options.UseFont = True
        Me.BtnThree.Location = New System.Drawing.Point(97, 124)
        Me.BtnThree.Name = "BtnThree"
        Me.BtnThree.Size = New System.Drawing.Size(36, 23)
        Me.BtnThree.TabIndex = 1
        Me.BtnThree.Text = "3"
        '
        'BtnPlus
        '
        Me.BtnPlus.AllowFocus = False
        Me.BtnPlus.Appearance.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlus.Appearance.Options.UseFont = True
        Me.BtnPlus.Location = New System.Drawing.Point(180, 153)
        Me.BtnPlus.Name = "BtnPlus"
        Me.BtnPlus.Size = New System.Drawing.Size(36, 23)
        Me.BtnPlus.TabIndex = 1
        Me.BtnPlus.Text = "+"
        '
        'BtnTwo
        '
        Me.BtnTwo.AllowFocus = False
        Me.BtnTwo.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTwo.Appearance.Options.UseFont = True
        Me.BtnTwo.Location = New System.Drawing.Point(55, 124)
        Me.BtnTwo.Name = "BtnTwo"
        Me.BtnTwo.Size = New System.Drawing.Size(36, 23)
        Me.BtnTwo.TabIndex = 1
        Me.BtnTwo.Text = "2"
        '
        'BtnOne
        '
        Me.BtnOne.AllowFocus = False
        Me.BtnOne.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOne.Appearance.Options.UseFont = True
        Me.BtnOne.Location = New System.Drawing.Point(7, 124)
        Me.BtnOne.Name = "BtnOne"
        Me.BtnOne.Size = New System.Drawing.Size(42, 23)
        Me.BtnOne.TabIndex = 1
        Me.BtnOne.Text = "1"
        '
        'BtnDot
        '
        Me.BtnDot.AllowFocus = False
        Me.BtnDot.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDot.Appearance.Options.UseFont = True
        Me.BtnDot.Location = New System.Drawing.Point(55, 153)
        Me.BtnDot.Name = "BtnDot"
        Me.BtnDot.Size = New System.Drawing.Size(36, 23)
        Me.BtnDot.TabIndex = 1
        Me.BtnDot.Text = "."
        '
        'BtnEqual
        '
        Me.BtnEqual.AllowFocus = False
        Me.BtnEqual.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEqual.Appearance.Options.UseFont = True
        Me.BtnEqual.Location = New System.Drawing.Point(97, 153)
        Me.BtnEqual.Name = "BtnEqual"
        Me.BtnEqual.Size = New System.Drawing.Size(36, 23)
        Me.BtnEqual.TabIndex = 1
        Me.BtnEqual.Text = "="
        '
        'BtnZero
        '
        Me.BtnZero.AllowFocus = False
        Me.BtnZero.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnZero.Appearance.Options.UseFont = True
        Me.BtnZero.Location = New System.Drawing.Point(7, 153)
        Me.BtnZero.Name = "BtnZero"
        Me.BtnZero.Size = New System.Drawing.Size(42, 23)
        Me.BtnZero.TabIndex = 1
        Me.BtnZero.Text = "0"
        '
        'txtCell2
        '
        Me.txtCell2.Enabled = False
        Me.txtCell2.Location = New System.Drawing.Point(12, 35)
        Me.txtCell2.Name = "txtCell2"
        Me.txtCell2.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCell2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCell2.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.txtCell2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.txtCell2.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.txtCell2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCell2.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.txtCell2.Properties.AppearanceReadOnly.BorderColor = System.Drawing.Color.Black
        Me.txtCell2.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.txtCell2.Properties.AppearanceReadOnly.Options.UseBorderColor = True
        Me.txtCell2.Properties.Mask.EditMask = "\d+"
        Me.txtCell2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtCell2.Properties.MaxLength = 10
        Me.txtCell2.Properties.ReadOnly = True
        Me.txtCell2.Size = New System.Drawing.Size(183, 20)
        Me.txtCell2.TabIndex = 0
        '
        'BtnBack
        '
        Me.BtnBack.AllowFocus = False
        Me.BtnBack.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBack.Appearance.Options.UseFont = True
        Me.BtnBack.Location = New System.Drawing.Point(138, 95)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(36, 23)
        Me.BtnBack.TabIndex = 1
        Me.BtnBack.Text = "←"
        '
        'BtnCaret
        '
        Me.BtnCaret.AllowFocus = False
        Me.BtnCaret.Appearance.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCaret.Appearance.Options.UseFont = True
        Me.BtnCaret.Location = New System.Drawing.Point(138, 124)
        Me.BtnCaret.Name = "BtnCaret"
        Me.BtnCaret.Size = New System.Drawing.Size(36, 23)
        Me.BtnCaret.TabIndex = 1
        Me.BtnCaret.Text = "^"
        '
        'BtnEsc
        '
        Me.BtnEsc.AllowFocus = False
        Me.BtnEsc.Appearance.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEsc.Appearance.Options.UseFont = True
        Me.BtnEsc.Location = New System.Drawing.Point(138, 153)
        Me.BtnEsc.Name = "BtnEsc"
        Me.BtnEsc.Size = New System.Drawing.Size(36, 23)
        Me.BtnEsc.TabIndex = 1
        Me.BtnEsc.Text = "Esc"
        '
        'LblSign
        '
        Me.LblSign.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblSign.Location = New System.Drawing.Point(201, 12)
        Me.LblSign.Name = "LblSign"
        Me.LblSign.Size = New System.Drawing.Size(14, 13)
        Me.LblSign.TabIndex = 2
        '
        'FormCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 187)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblSign)
        Me.Controls.Add(Me.BtnZero)
        Me.Controls.Add(Me.BtnOne)
        Me.Controls.Add(Me.BtnFour)
        Me.Controls.Add(Me.BtnSeven)
        Me.Controls.Add(Me.BtnTwo)
        Me.Controls.Add(Me.BtnFive)
        Me.Controls.Add(Me.BtnEight)
        Me.Controls.Add(Me.BtnEqual)
        Me.Controls.Add(Me.BtnDot)
        Me.Controls.Add(Me.BtnPlus)
        Me.Controls.Add(Me.BtnThree)
        Me.Controls.Add(Me.btnMinus)
        Me.Controls.Add(Me.BtnSix)
        Me.Controls.Add(Me.BtnMulti)
        Me.Controls.Add(Me.BtnNine)
        Me.Controls.Add(Me.BtnDevide)
        Me.Controls.Add(Me.BtnEsc)
        Me.Controls.Add(Me.BtnCaret)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnC)
        Me.Controls.Add(Me.txtCell2)
        Me.Controls.Add(Me.txtCell1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormCalc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Monarch's Calculator"
        CType(Me.txtCell1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCell2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCell1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDevide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnNine As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMulti As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEight As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSeven As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSix As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMinus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnFive As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnFour As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThree As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPlus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnTwo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOne As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDot As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEqual As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnZero As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCell2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnBack As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCaret As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEsc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblSign As DevExpress.XtraEditors.LabelControl

End Class
