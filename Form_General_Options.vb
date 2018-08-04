Public Class Form_General_Options

    Private Sub cb_auto_aspect_CheckedChanged(sender As Object, e As EventArgs) Handles cb_auto_aspect.CheckedChanged
        Form_Main.AutoAspect = Me.cb_auto_aspect.Checked
    End Sub

    Private Sub Form_General_Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cb_auto_aspect.Checked = Form_Main.AutoAspect
        cb_rating_filter.SelectedIndex = 2
        Me.Location = New Point(Form_Main.Width / 2 + Form_Main.Location.X - (Me.Width / 2), Form_Main.Height / 2 + Form_Main.Location.Y - (Me.Height / 2))

        cb_search.Items.Add("")
        For Each cb In RenameForm.clb_cats.Items
            If cb <> "" AndAlso cb <> "-" Then cb_search.Items.Add(cb)
        Next
        cb_search.SelectedIndex = 0
    End Sub

    Private Sub b_clearpl_Click(sender As Object, e As EventArgs) Handles b_clearpl.Click
        For Each Player As AxAXVLC.AxVLCPlugin2 In Form_Main.Controls.OfType(Of AxAXVLC.AxVLCPlugin2)()
            Player.playlist.stop()
        Next
        For a = 1 To 6
            Form_Main.options_list(a).b_clear_playlist_Click(Nothing, Nothing)
        Next
    End Sub

    Private Sub tb_dd_split_play_DragEnter(sender As Object, e As DragEventArgs) Handles tb_dd_split_play.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tb_dd_split_play_DragDrop(sender As Object, e As DragEventArgs) Handles tb_dd_split_play.DragDrop
        Dim s() As String = e.Data.GetData(DataFormats.FileDrop, False)

        best_filter = New List(Of String)
        If cb_only_these.Checked = True Then
            best_filter.Add(cb_rating_filter.Items(cb_rating_filter.SelectedIndex))
        Else
            For a = cb_rating_filter.SelectedIndex To 0 Step -1
                best_filter.Add(cb_rating_filter.Items(a))
            Next
        End If

        For Each fh In s
            If System.IO.Directory.Exists(fh) Then
                AddFolder(fh, Form_Main.options_list(1))
            ElseIf System.IO.File.Exists(fh) Then
                AddFile(fh, Form_Main.options_list(1))
            End If
        Next

        Form_Main.options_list(1).PopulatePlayList()
        Form_Main.options_list(1).b_random_Click(Nothing, Nothing)
        Form_Main.options_list(1).b_split_list_Click(Nothing, Nothing)
        For a = 1 To 6
            If Form_Main.options_list(a).lb_playlist.Items.Count > 0 Then
                Form_Main.options_list(a).lb_playlist.SelectedIndex = 0
            End If
        Next

    End Sub

    Private Sub AddFolder(fh As String, fo As FormOptions)
        For Each fs In System.IO.Directory.EnumerateDirectories(fh)
            AddFolder(fs, Form_Main.options_list(1))
        Next
        For Each fs In System.IO.Directory.EnumerateFiles(fh)
            AddFile(fs, fo)
        Next
    End Sub

    Private ratings() As String = {"vvgood", "vgood", "good", "ok", "poor", "Vvgood", "Vgood", "Good", "Ok", "Poor"}
    Private best_filter As List(Of String)
    Private cat_filter As String = ""

    Private Sub AddFile(fh As String, fo As FormOptions)
        Dim name As String = fh.Substring(fh.LastIndexOf("\") + 1)
        Dim rating As String = ""
        Dim valid_rating As Boolean = False
        If name.IndexOf(" "c) > 0 Then
            rating = name.Substring(0, name.IndexOf(" "c))
            valid_rating = ratings.Contains(rating)
        End If

        If cb_search.SelectedItem <> "" AndAlso Not name.Split(" "c).Contains(cb_search.SelectedItem) Then
            Exit Sub
        End If

        If cb_rating_filter.SelectedIndex = 6 Then
            fo.AddFile(fh)
        ElseIf Not valid_rating AndAlso cb_rating_filter.SelectedIndex = 5 Then
            fo.AddFile(fh)
        ElseIf valid_rating AndAlso best_filter.Contains(rating) Then
            fo.AddFile(fh)
        End If

    End Sub

    Private Sub b_double_mon_Click(sender As Object, e As EventArgs) Handles b_double_mon.Click
        Form_Main.Location = New Point(-10, -30)
        Form_Main.Size = New Size(2900, 1080)

        Me.Close()
    End Sub

    Private Sub b_jump_Click(sender As Object, e As EventArgs) Handles b_jump.Click
        For Each Player In Form_Main.TableLayoutPanel1.Controls.OfType(Of AxAXVLC.AxVLCPlugin2)()
            If Player.input.length > 0 Then
                Player.input.time = Player.input.time + Player.input.length / 5
            End If
        Next
    End Sub
End Class