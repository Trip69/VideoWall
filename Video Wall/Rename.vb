Public Class RenameForm

    Friend PlayerNumber As Integer
    Friend PlayerControl As AxVLCPlugin2
    'Private VideoFile As System.IO.File

    Private Sub RenameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.PlayerControl = Me.PlayerPanel.Controls.OfType(Of AxVLCPlugin2)().First
        For Each Player In Form_Main.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
            If Player.Name = "AxVLCPlugin2" & Me.PlayerNumber Then
                PlayerControl = Player
                Exit For
            End If
        Next
        Me.PlayerControl.playlist.pause()

        Dim a As Integer = 0
        For a = 0 To Me.clb_cats.Items.Count - 1
            Me.clb_cats.SetItemChecked(a, False)
        Next
        Me.cb_rating.SelectedIndex = -1

        Me.l_filename.Text = System.IO.Path.GetFileName(Form_Main.options_list(Me.PlayerNumber).lb_playlist.Text)
        Me.tb_changeto.Text = Me.l_filename.Text
        'TODO this doesn't work 
        'Dim x As Integer = Me.PlayerControl.Location.X * 1.2
        'Dim y As Integer = Me.PlayerControl.Location.Y * 1.2
        'Me.Location = New Point(x, y)
        Me.Location = Me.PlayerControl.Location
    End Sub

    '>> Clicks

    Private Sub b_rename_Click(sender As Object, e As EventArgs) Handles b_rename.Click

        Dim invalids() As Char = IO.Path.GetInvalidFileNameChars
        Dim fn As String = Me.tb_changeto.Text
        Dim a As Integer = 0
        While a < fn.Length
            If invalids.Contains(fn(a)) Then
                fn.Remove(a, 1)
            Else
                a = a + 1
            End If
        End While
        Me.tb_changeto.Text = fn

        Dim File As String = Form_Main.options_list(Me.PlayerNumber).lb_playlist.Text
        Try
            Form_Main.options_list(Me.PlayerNumber).b_remove_Click(Nothing, Nothing)
            FileSystem.Rename(File, System.IO.Path.GetDirectoryName(File) & "\" & Me.tb_changeto.Text)
        Catch ex As Exception
            MsgBox("Error renaming file")
        End Try
        Me.Close()
    End Sub

    Private Sub b_cancel_Click(sender As Object, e As EventArgs) Handles b_cancel.Click
        Me.PlayerControl.playlist.play()
        Me.Close()
    End Sub

    Private Sub cb_rating_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_rating.SelectedIndexChanged
        Me.UpdateName()
    End Sub

    Private Sub clb_cats_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clb_cats.SelectedIndexChanged
        Me.UpdateName()
    End Sub

    Private Sub UpdateName()
        Dim ChangeTo As String = " "
        Dim orig As String = Me.l_filename.Text
        For Each rating As String In Me.cb_rating.Items
            If orig.StartsWith(rating & " ") Then
                orig = orig.Substring(rating.Length + 1)
                Exit For
            End If
        Next
        If Me.cb_rating.SelectedItem <> "" Then
            ChangeTo = Me.cb_rating.SelectedItem & " "
            orig = orig.ToLower.Replace(Me.cb_rating.SelectedItem, "")
            orig = orig.Replace("  ", " ")
        End If

        For Each cat As String In Me.clb_cats.CheckedItems
            ChangeTo &= cat & " "
            orig = orig.ToLower.Replace(cat, "")
            orig = orig.Replace("  ", " ")
        Next
        orig = orig.Replace("  ", " ")
        If ChangeTo.Length > 0 Then
            ChangeTo &= orig
        Else
            ChangeTo = orig
        End If
        Me.tb_changeto.Text = ChangeTo
        Me.tb_changeto.Text = Me.tb_changeto.Text.Replace("  ", " ").Trim
    End Sub

    Private Sub b_delete_Click(sender As Object, e As EventArgs) Handles b_delete.Click
        Form_Main.options_list(Me.PlayerNumber).b_delete_Click(Nothing, Nothing)
        Me.Close()
    End Sub

    Private Sub tb_changeto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_changeto.KeyPress
        If e.KeyChar = vbCr Then
            Me.b_rename.PerformClick()
        End If
    End Sub
End Class