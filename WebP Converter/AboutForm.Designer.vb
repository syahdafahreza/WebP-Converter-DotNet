<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.lblappnameabout = New System.Windows.Forms.Label()
        Me.separator01 = New System.Windows.Forms.Label()
        Me.lblappaboutdesc = New System.Windows.Forms.Label()
        Me.kyrocodelogo = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblcopyrightnoticeabout = New System.Windows.Forms.Label()
        Me.lblcopyrightabout = New System.Windows.Forms.Label()
        CType(Me.kyrocodelogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblappnameabout
        '
        Me.lblappnameabout.AutoSize = True
        Me.lblappnameabout.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblappnameabout.Location = New System.Drawing.Point(14, 14)
        Me.lblappnameabout.Margin = New System.Windows.Forms.Padding(5)
        Me.lblappnameabout.Name = "lblappnameabout"
        Me.lblappnameabout.Size = New System.Drawing.Size(369, 42)
        Me.lblappnameabout.TabIndex = 0
        Me.lblappnameabout.Text = "WebP Converter 1.0"
        '
        'separator01
        '
        Me.separator01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.separator01.Location = New System.Drawing.Point(21, 66)
        Me.separator01.Margin = New System.Windows.Forms.Padding(5)
        Me.separator01.Name = "separator01"
        Me.separator01.Size = New System.Drawing.Size(355, 2)
        Me.separator01.TabIndex = 1
        '
        'lblappaboutdesc
        '
        Me.lblappaboutdesc.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblappaboutdesc.Location = New System.Drawing.Point(18, 78)
        Me.lblappaboutdesc.Margin = New System.Windows.Forms.Padding(5)
        Me.lblappaboutdesc.Name = "lblappaboutdesc"
        Me.lblappaboutdesc.Size = New System.Drawing.Size(365, 72)
        Me.lblappaboutdesc.TabIndex = 2
        Me.lblappaboutdesc.Text = resources.GetString("lblappaboutdesc.Text")
        '
        'kyrocodelogo
        '
        Me.kyrocodelogo.BackgroundImage = Global.WebP_Converter.My.Resources.Resources.KyroCode
        Me.kyrocodelogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.kyrocodelogo.Location = New System.Drawing.Point(21, 172)
        Me.kyrocodelogo.Margin = New System.Windows.Forms.Padding(5)
        Me.kyrocodelogo.Name = "kyrocodelogo"
        Me.kyrocodelogo.Size = New System.Drawing.Size(190, 47)
        Me.kyrocodelogo.TabIndex = 3
        Me.kyrocodelogo.TabStop = False
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(21, 160)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(355, 2)
        Me.Label2.TabIndex = 1
        '
        'lblcopyrightnoticeabout
        '
        Me.lblcopyrightnoticeabout.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblcopyrightnoticeabout.Location = New System.Drawing.Point(18, 229)
        Me.lblcopyrightnoticeabout.Margin = New System.Windows.Forms.Padding(5)
        Me.lblcopyrightnoticeabout.Name = "lblcopyrightnoticeabout"
        Me.lblcopyrightnoticeabout.Size = New System.Drawing.Size(365, 28)
        Me.lblcopyrightnoticeabout.TabIndex = 2
        Me.lblcopyrightnoticeabout.Text = "KyroCode, Umarkov Website, and UG Enterprise are subsidiary of Syahda Fahreza." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblcopyrightabout
        '
        Me.lblcopyrightabout.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblcopyrightabout.Location = New System.Drawing.Point(18, 267)
        Me.lblcopyrightabout.Margin = New System.Windows.Forms.Padding(5)
        Me.lblcopyrightabout.Name = "lblcopyrightabout"
        Me.lblcopyrightabout.Size = New System.Drawing.Size(365, 28)
        Me.lblcopyrightabout.TabIndex = 2
        Me.lblcopyrightabout.Text = "©0000 Syahda Fahreza, All Rights Reserved."
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(424, 316)
        Me.Controls.Add(Me.kyrocodelogo)
        Me.Controls.Add(Me.lblcopyrightabout)
        Me.Controls.Add(Me.lblcopyrightnoticeabout)
        Me.Controls.Add(Me.lblappaboutdesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.separator01)
        Me.Controls.Add(Me.lblappnameabout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tentang"
        Me.TopMost = True
        CType(Me.kyrocodelogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblappnameabout As Label
    Friend WithEvents separator01 As Label
    Friend WithEvents lblappaboutdesc As Label
    Friend WithEvents kyrocodelogo As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblcopyrightnoticeabout As Label
    Friend WithEvents lblcopyrightabout As Label
End Class
