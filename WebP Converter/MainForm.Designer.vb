<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.lblimgpreview = New System.Windows.Forms.Label()
        Me.btnabout = New System.Windows.Forms.Button()
        Me.previewPictureBox = New System.Windows.Forms.PictureBox()
        Me.txtboximgdir = New System.Windows.Forms.TextBox()
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.lblconvertto = New System.Windows.Forms.Label()
        Me.cmbformatselect = New System.Windows.Forms.ComboBox()
        Me.qualityTrackBar = New System.Windows.Forms.TrackBar()
        Me.qualityNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnconvert = New System.Windows.Forms.Button()
        CType(Me.previewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qualityTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qualityNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblimgpreview
        '
        Me.lblimgpreview.AutoSize = True
        Me.lblimgpreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimgpreview.Location = New System.Drawing.Point(11, 16)
        Me.lblimgpreview.Margin = New System.Windows.Forms.Padding(5)
        Me.lblimgpreview.Name = "lblimgpreview"
        Me.lblimgpreview.Size = New System.Drawing.Size(170, 24)
        Me.lblimgpreview.TabIndex = 0
        Me.lblimgpreview.Text = "Pratinjau Gambar"
        '
        'btnabout
        '
        Me.btnabout.BackgroundImage = Global.WebP_Converter.My.Resources.Resources.helpicon23px
        Me.btnabout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnabout.Location = New System.Drawing.Point(244, 15)
        Me.btnabout.Margin = New System.Windows.Forms.Padding(5)
        Me.btnabout.Name = "btnabout"
        Me.btnabout.Size = New System.Drawing.Size(25, 25)
        Me.btnabout.TabIndex = 6
        Me.btnabout.UseVisualStyleBackColor = True
        '
        'previewPictureBox
        '
        Me.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.previewPictureBox.Location = New System.Drawing.Point(15, 50)
        Me.previewPictureBox.Margin = New System.Windows.Forms.Padding(5)
        Me.previewPictureBox.Name = "previewPictureBox"
        Me.previewPictureBox.Size = New System.Drawing.Size(254, 254)
        Me.previewPictureBox.TabIndex = 2
        Me.previewPictureBox.TabStop = False
        '
        'txtboximgdir
        '
        Me.txtboximgdir.Location = New System.Drawing.Point(15, 316)
        Me.txtboximgdir.Margin = New System.Windows.Forms.Padding(5)
        Me.txtboximgdir.Name = "txtboximgdir"
        Me.txtboximgdir.ReadOnly = True
        Me.txtboximgdir.Size = New System.Drawing.Size(165, 20)
        Me.txtboximgdir.TabIndex = 0
        Me.txtboximgdir.TabStop = False
        Me.txtboximgdir.Text = "Silahkan pilih gambarnya gan..."
        '
        'btnbrowse
        '
        Me.btnbrowse.Location = New System.Drawing.Point(194, 314)
        Me.btnbrowse.Margin = New System.Windows.Forms.Padding(5)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowse.TabIndex = 1
        Me.btnbrowse.Text = "Jelajahi"
        Me.btnbrowse.UseVisualStyleBackColor = True
        '
        'lblconvertto
        '
        Me.lblconvertto.AutoSize = True
        Me.lblconvertto.Location = New System.Drawing.Point(12, 350)
        Me.lblconvertto.Margin = New System.Windows.Forms.Padding(5)
        Me.lblconvertto.Name = "lblconvertto"
        Me.lblconvertto.Size = New System.Drawing.Size(122, 13)
        Me.lblconvertto.TabIndex = 5
        Me.lblconvertto.Text = "Konversikan gambar ke:"
        '
        'cmbformatselect
        '
        Me.cmbformatselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbformatselect.FormattingEnabled = True
        Me.cmbformatselect.Items.AddRange(New Object() {"jpg", "png", "webp"})
        Me.cmbformatselect.Location = New System.Drawing.Point(148, 347)
        Me.cmbformatselect.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbformatselect.MaxDropDownItems = 5
        Me.cmbformatselect.Name = "cmbformatselect"
        Me.cmbformatselect.Size = New System.Drawing.Size(121, 21)
        Me.cmbformatselect.TabIndex = 2
        '
        'qualityTrackBar
        '
        Me.qualityTrackBar.Location = New System.Drawing.Point(8, 21)
        Me.qualityTrackBar.Margin = New System.Windows.Forms.Padding(5)
        Me.qualityTrackBar.Maximum = 100
        Me.qualityTrackBar.Minimum = 1
        Me.qualityTrackBar.Name = "qualityTrackBar"
        Me.qualityTrackBar.Size = New System.Drawing.Size(177, 45)
        Me.qualityTrackBar.TabIndex = 3
        Me.qualityTrackBar.Value = 80
        '
        'qualityNumericUpDown
        '
        Me.qualityNumericUpDown.Location = New System.Drawing.Point(195, 21)
        Me.qualityNumericUpDown.Margin = New System.Windows.Forms.Padding(5)
        Me.qualityNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.qualityNumericUpDown.Name = "qualityNumericUpDown"
        Me.qualityNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.qualityNumericUpDown.TabIndex = 4
        Me.qualityNumericUpDown.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.qualityTrackBar)
        Me.GroupBox1.Controls.Add(Me.qualityNumericUpDown)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 378)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 74)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Kualitas Gambar"
        '
        'btnconvert
        '
        Me.btnconvert.Location = New System.Drawing.Point(15, 462)
        Me.btnconvert.Margin = New System.Windows.Forms.Padding(5)
        Me.btnconvert.Name = "btnconvert"
        Me.btnconvert.Size = New System.Drawing.Size(254, 23)
        Me.btnconvert.TabIndex = 5
        Me.btnconvert.Text = "Konversikan Sekarang!"
        Me.btnconvert.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(284, 509)
        Me.Controls.Add(Me.btnconvert)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbformatselect)
        Me.Controls.Add(Me.lblconvertto)
        Me.Controls.Add(Me.btnbrowse)
        Me.Controls.Add(Me.txtboximgdir)
        Me.Controls.Add(Me.previewPictureBox)
        Me.Controls.Add(Me.btnabout)
        Me.Controls.Add(Me.lblimgpreview)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WebP Converter"
        CType(Me.previewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qualityTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qualityNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblimgpreview As Label
    Friend WithEvents btnabout As Button
    Friend WithEvents previewPictureBox As PictureBox
    Friend WithEvents txtboximgdir As TextBox
    Friend WithEvents btnbrowse As Button
    Friend WithEvents lblconvertto As Label
    Friend WithEvents cmbformatselect As ComboBox
    Friend WithEvents qualityTrackBar As TrackBar
    Friend WithEvents qualityNumericUpDown As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnconvert As Button
End Class
