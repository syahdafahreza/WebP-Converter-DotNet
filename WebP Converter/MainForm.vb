Imports System.IO
Imports System.Drawing.Imaging
Imports System.Diagnostics
Imports System.Reflection

Public Class MainForm
    ' Variabel untuk menyimpan path gambar yang dipilih
    Private selectedImagePath As String = String.Empty

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur item default untuk ComboBox dan PictureBox
        cmbformatselect.SelectedItem = "jpg"
        previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ' Awalnya, nonaktifkan tombol konversi sampai gambar dipilih
        btnconvert.Enabled = False

        ' Aktifkan fungsionalitas Drag & Drop untuk PictureBox
        previewPictureBox.AllowDrop = True

        ' Pastikan Anda sudah mengganti nama TextBox1 menjadi txtboximgdir di Form Designer
        txtboximgdir.Text = "Silahkan pilih gambarnya gan..."
    End Sub

    ''' <summary>
    ''' Memuat gambar dari path file, menampilkannya, dan memperbarui UI.
    ''' Metode ini dipanggil oleh event Klik Jelajahi dan DragDrop.
    ''' </summary>
    ''' <param name="filePath">Path lengkap ke file gambar.</param>
    Private Sub LoadImage(ByVal filePath As String)
        Try
            ' Validasi ekstensi file untuk memastikan itu adalah gambar
            Dim validExtensions As String() = {".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp"}
            Dim fileExtension As String = Path.GetExtension(filePath).ToLower()

            ' Khusus untuk webp, kita perlu cara lain untuk memuatnya karena .NET 3.5 tidak mendukung secara native
            If fileExtension = ".webp" Then
                MessageBox.Show("Pratinjau untuk format WebP belum didukung, namun Anda tetap bisa mengkonversinya ke format lain.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Tampilkan placeholder atau kosongkan gambar
                previewPictureBox.Image = Nothing
            ElseIf Not validExtensions.Contains(fileExtension) Then
                MessageBox.Show("Format file tidak didukung. Silahkan pilih file gambar (jpg, png, gif, bmp).", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                ' Tampilkan gambar di PictureBox untuk format yang didukung
                previewPictureBox.Image = Image.FromFile(filePath)
            End If

            ' Simpan path file dan tampilkan di TextBox
            selectedImagePath = filePath
            txtboximgdir.Text = selectedImagePath ' Menggunakan nama baru: txtboximgdir

            ' Aktifkan tombol konversi setelah path gambar valid
            btnconvert.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Gagal memuat gambar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnconvert.Enabled = False
            previewPictureBox.Image = Nothing
            selectedImagePath = String.Empty
            txtboximgdir.Text = "Gagal memuat gambar." ' Menggunakan nama baru: txtboximgdir
        End Try
    End Sub

    ''' <summary>
    ''' Menangani event klik pada tombol "Jelajahi" untuk memilih gambar.
    ''' </summary>
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Pilih Gambar"
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.webp|Semua File|*.*"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Panggil metode LoadImage yang sudah dibuat
                LoadImage(openFileDialog.FileName)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Menangani event klik pada tombol "Konversikan Sekarang!".
    ''' </summary>
    Private Sub btnconvert_Click(sender As Object, e As EventArgs) Handles btnconvert.Click
        ' Pastikan ada path gambar yang akan dikonversi
        If String.IsNullOrEmpty(selectedImagePath) Then
            MessageBox.Show("Silahkan pilih gambar terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Dapatkan format tujuan dari ComboBox
        Dim targetFormat As String = cmbformatselect.SelectedItem.ToString().ToLower()

        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Title = "Simpan Gambar Hasil Konversi"
            saveFileDialog.Filter = String.Format("{0} File|*.{0}", targetFormat)
            saveFileDialog.DefaultExt = targetFormat
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(selectedImagePath) & "." & targetFormat
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(selectedImagePath)

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim outputPath As String = saveFileDialog.FileName
                Try
                    Dim sourceImage As Image = Nothing
                    If Path.GetExtension(selectedImagePath).ToLower() <> ".webp" Then
                        sourceImage = previewPictureBox.Image
                    End If

                    Select Case targetFormat
                        Case "jpg"
                            SaveAsJpeg(sourceImage, outputPath, CInt(qualityNumericUpDown.Value))
                        Case "png"
                            sourceImage.Save(outputPath, ImageFormat.Png)
                        Case "webp"
                            SaveAsWebP(outputPath, CInt(qualityNumericUpDown.Value))
                    End Select

                    MessageBox.Show("Gambar berhasil dikonversi dan disimpan di:" & vbCrLf & outputPath, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Terjadi kesalahan saat konversi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Event ketika file diseret ke area PictureBox.
    ''' </summary>
    Private Sub previewPictureBox_DragEnter(sender As Object, e As DragEventArgs) Handles previewPictureBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' Event ketika file dijatuhkan (drop) di area PictureBox.
    ''' </summary>
    Private Sub previewPictureBox_DragDrop(sender As Object, e As DragEventArgs) Handles previewPictureBox.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If files IsNot Nothing AndAlso files.Length > 0 Then
            LoadImage(files(0))
        End If
    End Sub

    ''' <summary>
    ''' Menyimpan gambar sebagai format JPEG dengan kualitas tertentu.
    ''' </summary>
    Private Sub SaveAsJpeg(ByVal image As Image, ByVal path As String, ByVal quality As Integer)
        Dim jpegCodec As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        Dim qualityEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        Dim encoderParameters As New EncoderParameters(1)
        encoderParameters.Param(0) = New EncoderParameter(qualityEncoder, CLng(quality))
        image.Save(path, jpegCodec, encoderParameters)
    End Sub

    ''' <summary>
    ''' Salin isi dari satu stream ke stream lain. Pengganti untuk Stream.CopyTo di .NET 3.5.
    ''' </summary>
    Private Sub CopyStream(ByVal input As Stream, ByVal output As Stream)
        Dim buffer(4095) As Byte ' Buffer 4KB
        Dim bytesRead As Integer
        Do
            bytesRead = input.Read(buffer, 0, buffer.Length)
            If bytesRead > 0 Then
                output.Write(buffer, 0, bytesRead)
            End If
        Loop While bytesRead > 0
    End Sub

    ''' <summary>
    ''' Mengekstrak cwebp.exe dari resource, menjalankannya untuk konversi, lalu menghapusnya.
    ''' </summary>
    Private Sub SaveAsWebP(ByVal outputPath As String, ByVal quality As Integer)
        ' Path untuk cwebp.exe di folder sementara pengguna.
        Dim cwebpPath As String = Path.Combine(Path.GetTempPath(), "cwebp.exe")
        ' Nama resource. Sesuaikan "WebP_Converter" dengan nama root namespace proyek Anda.
        Dim resourceName As String = "WebP_Converter.cwebp.exe"

        Try
            ' 1. Ekstrak resource jika belum ada di folder temp
            If Not File.Exists(cwebpPath) Then
                ' Dapatkan stream dari resource yang disematkan
                Using resourceStream As Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
                    If resourceStream Is Nothing Then
                        Throw New Exception("Resource 'cwebp.exe' tidak ditemukan. Pastikan nama resource benar dan Build Action sudah diatur ke 'Embedded Resource'.")
                    End If

                    ' Buat file di folder temp
                    Using fileStream As New FileStream(cwebpPath, FileMode.Create, FileAccess.Write)
                        ' === PERBAIKAN DI SINI ===
                        ' Menggunakan fungsi manual karena .CopyTo() tidak ada di .NET 3.5
                        CopyStream(resourceStream, fileStream)
                    End Using
                End Using
            End If

            ' 2. Jalankan proses konversi menggunakan cwebp.exe dari folder temp
            Dim arguments As String = String.Format("-q {0} ""{1}"" -o ""{2}""", quality, selectedImagePath, outputPath)
            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = cwebpPath
            startInfo.Arguments = arguments
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True
            startInfo.RedirectStandardOutput = True
            startInfo.RedirectStandardError = True

            Using process As Process = Process.Start(startInfo)
                process.WaitForExit()
            End Using

        Finally
            ' 3. (Opsional) Hapus cwebp.exe dari folder temp setelah selesai
            If File.Exists(cwebpPath) Then
                Try
                    File.Delete(cwebpPath)
                Catch ex As Exception
                    ' Abaikan jika gagal dihapus, mungkin masih digunakan.
                End Try
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Helper untuk mendapatkan ImageCodecInfo dari format gambar.
    ''' </summary>
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Menyesuaikan nilai NumericUpDown saat TrackBar digulir.
    ''' </summary>
    Private Sub qualityTrackBar_Scroll(sender As Object, e As EventArgs) Handles qualityTrackBar.Scroll
        qualityNumericUpDown.Value = qualityTrackBar.Value
    End Sub

    ''' <summary>
    ''' Menyesuaikan nilai TrackBar saat nilai NumericUpDown berubah.
    ''' </summary>
    Private Sub qualityNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles qualityNumericUpDown.ValueChanged
        qualityTrackBar.Value = CInt(qualityNumericUpDown.Value)
    End Sub

    ''' <summary>
    ''' Mengaktifkan/menonaktifkan GroupBox kualitas berdasarkan format yang dipilih.
    ''' </summary>
    Private Sub cmbformatselect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbformatselect.SelectedIndexChanged
        If cmbformatselect.SelectedItem.ToString().ToLower() = "png" Then
            GroupBox1.Enabled = False
        Else
            GroupBox1.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Menampilkan kotak "About".
    ''' </summary>
    Private Sub btnabout_Click(sender As Object, e As EventArgs) Handles btnabout.Click
        ' Buat instance baru dari AboutForm
        'Dim frmAbout As New AboutForm()

        AboutForm.Show()

        ' Tampilkan form sebagai modal dialog.
        ' Kode di bawah baris ini tidak akan berjalan sampai frmAbout ditutup.
        ' frmAbout.ShowDialog()
    End Sub
End Class