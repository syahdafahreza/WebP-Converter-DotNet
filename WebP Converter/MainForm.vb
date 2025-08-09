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

        ' Atur teks awal
        txtboximgdir.Text = "Pilih gambar atau jatuhkan di sini..."
    End Sub

    ''' <summary>
    ''' Memuat gambar dari path file, menampilkannya, dan memperbarui UI.
    ''' </summary>
    ''' <param name="filePath">Path lengkap ke file gambar.</param>
    Private Sub LoadImage(ByVal filePath As String)
        Try
            ' Validasi ekstensi file
            Dim validExtensions As String() = {".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp"}
            Dim fileExtension As String = Path.GetExtension(filePath).ToLower()

            If Not validExtensions.Contains(fileExtension) Then
                MessageBox.Show("Format file tidak didukung.", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim imageToPreview As Image = Nothing

            ' Jika file adalah WebP, dekode dulu untuk pratinjau
            If fileExtension = ".webp" Then
                imageToPreview = DecodeWebPToImage(filePath)
            Else
                ' Untuk format lain, muat langsung
                imageToPreview = Image.FromFile(filePath)
            End If

            ' Tampilkan gambar di PictureBox
            previewPictureBox.Image = imageToPreview

            ' Simpan path file lengkap secara internal
            selectedImagePath = filePath
            ' === PERUBAHAN DI SINI ===
            ' Tampilkan hanya nama file di TextBox
            txtboximgdir.Text = Path.GetFileName(filePath)

            ' Aktifkan tombol konversi setelah gambar berhasil dimuat
            btnconvert.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Gagal memuat gambar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnconvert.Enabled = False
            previewPictureBox.Image = Nothing
            selectedImagePath = String.Empty
            txtboximgdir.Text = "Gagal memuat gambar."
        End Try
    End Sub

    ''' <summary>
    ''' Mendekode file WebP menjadi objek Image untuk pratinjau.
    ''' </summary>
    ''' <param name="webpPath">Path ke file WebP.</param>
    ''' <returns>Objek Image dari file WebP yang sudah didekode.</returns>
    Private Function DecodeWebPToImage(ByVal webpPath As String) As Image
        ' Path untuk dwebp.exe dan output sementara di folder temp
        Dim dwebpPath As String = Path.Combine(Path.GetTempPath(), "dwebp.exe")
        Dim tempOutputPath As String = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() & ".png")
        ' Nama resource. Sesuaikan "WebP_Converter" dengan nama root namespace proyek Anda.
        Dim resourceName As String = "WebP_Converter.dwebp.exe"

        Try
            ' 1. Ekstrak dwebp.exe dari resource
            ExtractResource(resourceName, dwebpPath)

            ' 2. Jalankan proses untuk mendekode WebP ke PNG sementara
            Dim arguments As String = String.Format("""{0}"" -o ""{1}""", webpPath, tempOutputPath)
            RunProcess(dwebpPath, arguments)

            ' 3. Muat file PNG sementara ke dalam objek Image
            ' Gunakan MemoryStream untuk menghindari file lock
            Using fs As New FileStream(tempOutputPath, FileMode.Open, FileAccess.Read)
                Dim ms As New MemoryStream()
                CopyStream(fs, ms)
                Return Image.FromStream(ms)
            End Using

        Finally
            ' 4. Hapus file sementara setelah selesai
            If File.Exists(dwebpPath) Then File.Delete(dwebpPath)
            If File.Exists(tempOutputPath) Then File.Delete(tempOutputPath)
        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' Menangani event klik pada tombol "Jelajahi" untuk memilih gambar.
    ''' </summary>
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Pilih Gambar"
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.webp|Semua File|*.*"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                LoadImage(openFileDialog.FileName)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Menangani event klik pada tombol "Konversikan Sekarang!".
    ''' </summary>
    Private Sub btnconvert_Click(sender As Object, e As EventArgs) Handles btnconvert.Click
        If previewPictureBox.Image Is Nothing OrElse String.IsNullOrEmpty(selectedImagePath) Then
            MessageBox.Show("Silahkan pilih gambar terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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
                    Select Case targetFormat
                        Case "jpg"
                            SaveAsJpeg(previewPictureBox.Image, outputPath, CInt(qualityNumericUpDown.Value))
                        Case "png"
                            previewPictureBox.Image.Save(outputPath, ImageFormat.Png)
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
    ''' Mengekstrak cwebp.exe dari resource dan menjalankannya untuk konversi.
    ''' </summary>
    Private Sub SaveAsWebP(ByVal outputPath As String, ByVal quality As Integer)
        Dim cwebpPath As String = Path.Combine(Path.GetTempPath(), "cwebp.exe")
        Dim resourceName As String = "WebP_Converter.cwebp.exe"

        Try
            ExtractResource(resourceName, cwebpPath)
            Dim arguments As String = String.Format("-q {0} ""{1}"" -o ""{2}""", quality, selectedImagePath, outputPath)
            RunProcess(cwebpPath, arguments)
        Finally
            If File.Exists(cwebpPath) Then File.Delete(cwebpPath)
        End Try
    End Sub

    ''' <summary>
    ''' Helper untuk mengekstrak file resource yang disematkan ke path tujuan.
    ''' </summary>
    Private Sub ExtractResource(ByVal resourceName As String, ByVal outputPath As String)
        If File.Exists(outputPath) Then Return ' Tidak perlu ekstrak jika sudah ada

        Using resourceStream As Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
            If resourceStream Is Nothing Then
                Throw New Exception(String.Format("Resource '{0}' tidak ditemukan.", resourceName))
            End If
            Using fileStream As New FileStream(outputPath, FileMode.Create, FileAccess.Write)
                CopyStream(resourceStream, fileStream)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Helper untuk menjalankan proses eksternal secara tersembunyi.
    ''' </summary>
    Private Sub RunProcess(ByVal filePath As String, ByVal arguments As String)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = filePath
        startInfo.Arguments = arguments
        startInfo.UseShellExecute = False
        startInfo.CreateNoWindow = True
        Using process As Process = Process.Start(startInfo)
            process.WaitForExit()
        End Using
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

    Private Sub qualityTrackBar_Scroll(sender As Object, e As EventArgs) Handles qualityTrackBar.Scroll
        qualityNumericUpDown.Value = qualityTrackBar.Value
    End Sub

    Private Sub qualityNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles qualityNumericUpDown.ValueChanged
        qualityTrackBar.Value = CInt(qualityNumericUpDown.Value)
    End Sub

    Private Sub cmbformatselect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbformatselect.SelectedIndexChanged
        If cmbformatselect.SelectedItem.ToString().ToLower() = "png" Then
            GroupBox1.Enabled = False
        Else
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub btnabout_Click(sender As Object, e As EventArgs) Handles btnabout.Click
        AboutForm.ShowDialog()
    End Sub
End Class