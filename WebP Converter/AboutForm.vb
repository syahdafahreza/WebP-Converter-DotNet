Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblcopyrightabout.Text = "©" & DateTime.Now.Year & " Syahda Fahreza, All Rights Reserved."
    End Sub

    ' Event ini berjalan saat form kehilangan fokus
    Private Sub AboutForm_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        ' Langsung tutup form ini
        Me.Close()
    End Sub
End Class