Public Class FormOptions

    Friend Video As Integer
    Friend VideoToEffect As AxAXVLC.AxVLCPlugin2
    Friend Playlist As New List(Of String)
    Friend LBIgnoreIndexChange As Boolean
    Friend FullScreen As Boolean = False
    Friend OpenNextOptions As Integer = -1
    Private firstclick As Boolean = True
    Private ListBoxRightClickChange As Boolean

    Public WriteOnly Property VideoNumber As Integer
        Set(value As Integer)
            Me.Video = value

            If Me.Text = "Nothing" Then
                Me.Text = "Options for Video " & Me.Video
                Me.VideoToEffect = Form_Main.Controls.Find("AxVLCPlugin2" & Video, True)(0)
                If Me.Video = 6 Then
                    gb_split.Enabled = False
                Else
                    For a = 5 To Me.Video Step -1
                        cb_split.Items.Add(a + 1 - Me.Video)
                    Next
                    cb_split.SelectedIndex = 0
                End If
            End If
        End Set
    End Property

    'Events

    Public Sub FormOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ChangePlaylistIndex()
    End Sub

    Private Sub FormOptions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        lb_playlist.Focus()
    End Sub

    Private Sub FormOptions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
#If DEBUG Then
        Debugger.Break()
#End If
    End Sub

    Private Sub FormOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Visible = False
    End Sub

    Private Sub lb_playlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_playlist.SelectedIndexChanged
        If Me.lb_playlist.SelectedIndex <> -1 AndAlso Me.cms_listbox.Items.Count > 0 Then
            Dim Filename() As String = Me.lb_playlist.SelectedItem.Split("\"c)
            'Me.tstb1.Text = Me.lb_playlist.SelectedItem.ToString.Substring(Me.lb_playlist.SelectedItem.ToString.LastIndexOf("\") + 1)
            Me.RenameFileTSTB.Text = Filename.Last
            Me.RenameFileTSTB.Text = Me.RenameFileTSTB.Text.Substring(0, Me.RenameFileTSTB.Text.Length - 4)
            Me.firstclick = True
        End If

        If VideoToEffect.playlist.isPlaying AndAlso VideoToEffect.mediaDescription.title = lb_playlist.SelectedItem Then
            Exit Sub
        ElseIf Not sender Is Nothing AndAlso TypeOf sender Is ListBox Then
            Me.VideoToEffect.playlist.playItem(Me.lb_playlist.SelectedIndex)
        ElseIf Me.LBIgnoreIndexChange Then
            Me.LBIgnoreIndexChange = False
        Else
            Me.VideoToEffect.playlist.playItem(Me.lb_playlist.SelectedIndex)
        End If

    End Sub

    '  >> Clicks

    Private Sub b_select_file_Click(sender As System.Object, e As System.EventArgs) Handles b_select_file.Click
        Dim res As DialogResult = Me.OpenFileDialog1.ShowDialog
        Me.PopulatePlayList()
        Form_Main.PlayIfNot(Me.VideoToEffect)
        If res = 1 Then
            Me.AddFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub b_select_directory_Click(sender As System.Object, e As System.EventArgs) Handles b_select_directory.Click
        Dim res = Me.FolderBrowserDialog1.ShowDialog
        If res = 1 Then
            Dim FilesWithin As String() = System.IO.Directory.GetFiles(Me.FolderBrowserDialog1.SelectedPath)
            Dim Count As Integer = Me.VideoToEffect.playlist.items.count
            For Each file In FilesWithin
                Me.VideoToEffect.playlist.add(file)
                Me.Playlist.Add(Me.VLCFormatFilePath(file))
                Count = Count + 1
            Next
            Me.PopulatePlayList()
            Form_Main.PlayIfNot(Me.VideoToEffect)
            Me.b_close_Click(Nothing, Nothing)
        End If
    End Sub

    Friend Sub b_random_Click(sender As Object, e As EventArgs) Handles b_random.Click
        If Me.lb_playlist.Items.Count < 2 Then Exit Sub

        Dim Files(Me.lb_playlist.Items.Count - 1) As String
        Dim SelectedText As String = Me.lb_playlist.SelectedValue
        Me.lb_playlist.Items.CopyTo(Files, 0)

        Me.b_clear_playlist_Click(Nothing, Nothing)

        If Me.b_random.Tag = "Rand" Then
            'Rand The List

            Dim TheNames As New List(Of String)
            TheNames.InsertRange(0, Files)
            Dim ran As New Random()
            Dim TheWinner As Integer
            For a = 0 To TheNames.Count - 1
                TheWinner = ran.Next(TheNames.Count - 1)
                Me.AddFile(TheNames.Item(TheWinner))
                TheNames.RemoveAt(TheWinner)
            Next
            Me.b_random.Text = "Order Playlist"
            Me.b_random.Tag = "Order"
        Else
            'Order the list
            System.Array.Sort(Of String)(Files)
            For Each f In Files
                Me.AddFile(f)
            Next
            Me.b_random.Text = "Randomize Playlist"
            Me.b_random.Tag = "Rand"
        End If
        Me.PopulatePlayList()
        Me.lb_playlist.SelectedIndex = 0

    End Sub

    Friend Sub b_fullscreen_Click(sender As System.Object, e As System.EventArgs) Handles b_fullscreen.Click
        If Form_Main.MaximizeBox = False Then
            Form_Main.MaximizeBox = True
            Form_Main.MinimizeBox = True
            Form_Main.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Form_Main.WindowState = FormWindowState.Normal
            Form_Main.b_quit.Text = "?"
            Form_Main.b_quit.Visible = False
        Else
            Form_Main.MaximizeBox = False
            Form_Main.MinimizeBox = False
            Form_Main.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Form_Main.WindowState = FormWindowState.Maximized
            Form_Main.b_quit.Text = "X"
            Form_Main.b_quit.Visible = True

        End If

        If Form_Main.AutoAspect Then
            Form_Main.ChangeAspect()
        End If
        Me.b_close_Click(Nothing, Nothing)
    End Sub

    Private Sub b_skip_time_Click(sender As Object, e As EventArgs) Handles b_skip_time.Click
        If Me.VideoToEffect.playlist.isPlaying Then
            Me.VideoToEffect.input.Position = Me.VideoToEffect.input.Position + 0.01

        End If
    End Sub

    Friend Sub b_video_fullscreen_Click(sender As System.Object, e As System.EventArgs) Handles b_video_fullscreen.Click
        TogglePauseAllVideos(Me.VideoToEffect)
        Me.VideoToEffect.video.toggleFullscreen()
        Form_Main.RemoveAspect(Me.VideoToEffect)
        Me.FullScreen = True
    End Sub

    Friend Sub b_clear_playlist_Click(sender As System.Object, e As System.EventArgs) Handles b_clear_playlist.Click
        Me.VideoToEffect.playlist.items.clear()
        Me.lb_playlist.Items.Clear()
        Me.Playlist.Clear()
        If Me.VideoToEffect.playlist.isPlaying Then Me.VideoToEffect.playlist.stop()
    End Sub

    Friend Sub b_split_list_Click(sender As System.Object, e As System.EventArgs) Handles b_split_list.Click
        If lb_playlist.Items.Count < cb_split.SelectedItem Then Exit Sub
        Dim splitinto As Integer = cb_split.SelectedItem + 1
        Dim temp(lb_playlist.Items.Count - 1) As String
        lb_playlist.Items.CopyTo(temp, 0)
        Dim PathList As New List(Of String)
        PathList.AddRange(temp)

        Dim start As Integer = Me.Video
        Dim finish As Integer = splitinto
        Form_Main.options_list.Item(Me.Video).b_clear_playlist_Click(Nothing, Nothing)

        Dim current As Integer = start
        Do While PathList.Count > 0
            Form_Main.options_list.Item(current).AddFile(PathList(0))
            PathList.RemoveAt(0)
            current = current + 1
            If current > finish Then
                current = start
            End If
        Loop
        For a = start To finish
            Form_Main.options_list.Item(a).PopulatePlayList(Nothing, Nothing)
            If Form_Main.options_list.Item(a).lb_playlist.Items.Count = 0 Then
                Exit For
            End If
            Form_Main.options_list.Item(a).lb_playlist.SelectedIndex = 0
        Next
        Application.DoEvents()


    End Sub

    Private Sub r_moveall_Click(sender As Object, e As EventArgs) Handles r_moveall.Click
        For Each Player As AxAXVLC.AxVLCPlugin2 In Form_Main.Controls.OfType(Of AxAXVLC.AxVLCPlugin2)()
            Player.playlist.stop()
        Next
        For a = 2 To 6
            For Each file As String In Form_Main.options_list(a).lb_playlist.Items
                Form_Main.options_list(1).AddFile(file)
            Next
            Form_Main.options_list(a).b_clear_playlist_Click(Nothing, Nothing)
        Next
        If Me.Video = 1 Then
            Form_Main.options_list(1).PopulatePlayList()
            If Form_Main.options_list(1).lb_playlist.Items.Count > 1 Then
                Form_Main.options_list(1).lb_playlist.SelectedIndex = 0
            End If
        End If
    End Sub

    Friend Sub b_remove_Click(sender As Object, e As EventArgs) Handles b_remove.Click
        If lb_playlist.SelectedIndex = -1 Then Exit Sub
        Me.VideoToEffect.playlist.stop()
        Dim RemoveNo As Integer = Me.lb_playlist.SelectedIndex

        Me.Playlist.Remove(lb_playlist.SelectedItem.ToString)
        Me.VideoToEffect.playlist.items.remove(RemoveNo)
        Me.lb_playlist.Items.Remove(Me.lb_playlist.SelectedItem)

        If Playlist.Count = 0 Then
            Me.b_clear_playlist_Click(Nothing, Nothing)
        ElseIf Me.lb_playlist.Items.Count > RemoveNo Then
            Me.lb_playlist.SelectedIndex = RemoveNo
        End If
    End Sub

    Private Sub b_remover_Click(sender As Object, e As EventArgs) Handles b_remover.Click
        Me.VideoToEffect.playlist.stop()
        Dim filename As String
        Dim a As Integer = 0
        While a < Me.lb_playlist.Items.Count
            filename = IO.Path.GetFileName(Me.lb_playlist.Items(a))
            For Each rating In RenameForm.cb_rating.Items
                If filename.ToLower.StartsWith(rating) Then
                    Me.lb_playlist.SelectedIndex = a
                    Me.b_remove.PerformClick()
                    a = a - 1
                    Exit For
                End If
            Next
            a = a + 1
            If a >= Me.lb_playlist.Items.Count Then
                Exit While
            End If

        End While
    End Sub

    Friend Sub b_delete_Click(sender As Object, e As EventArgs) Handles b_delete.Click
        If lb_playlist.SelectedIndex = -1 Then Exit Sub
        Dim msgboxres = MsgBox("Sure you want to delete this file?", MsgBoxStyle.YesNo, "Confirm")
        If msgboxres = MsgBoxResult.No Then Exit Sub
        Dim DelFile As String = lb_playlist.SelectedItem
        Try
            Me.VideoToEffect.playlist.stop()
            System.IO.File.Delete(DelFile)
            b_remove_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("Error Deleting file")
        End Try

    End Sub

    Friend Sub b_savefiles_Click(sender As Object, e As EventArgs) Handles b_save_files.Click
        Dim SearchFilePath As String
        Dim Prefrix As String = "Save" & n_save.Value
        Dim Player As AxAXVLC.AxVLCPlugin2

        For Index = 1 To 6
            Player = Form_Main.Controls.Find("AxVLCPlugin2" & Index, True)(0)
            If Form_Main.options_list(Index).Playlist.Count > 0 Then
                My.Settings.Item(Prefrix & "Player" & Index) = Form_Main.options_list(Index).ConvertPlayList()
                SearchFilePath = Player.mediaDescription.title
                My.Settings.Item(Prefrix & "Index" & Index) = Form_Main.options_list(Index).lb_playlist.FindString(SearchFilePath)
            End If
        Next
        My.Settings.Save()
        Form_Main.LastSaveLoad = n_save.Value
        Dim msg As New MessageBox
        msg.Label1.Text = "Saved to Playlist"
        msg.StartPosition = FormStartPosition.CenterParent
        msg.ShowDialog()
    End Sub

    Private Sub b_savefolders_Click(sender As Object, e As EventArgs) Handles b_savefolders.Click
        Dim Prefrix As String = "Save" & n_save.Value
        Dim Player As AxAXVLC.AxVLCPlugin2
        Dim SearchFilePath As String

        For Index = 1 To 6
            Player = Form_Main.Controls.Find("AxVLCPlugin2" & Index, True)(0)
            If Form_Main.options_list(Index).Playlist.Count > 0 Then
                My.Settings.Item(Prefrix & "Player" & Index) = Form_Main.options_list(Index).ConvertPlayListToFolders()
                If Player.input.state = Form_Main.PlayerState.Playing Or Form_Main.PlayerState.Paused Then
                    SearchFilePath = Player.mediaDescription.title
                    My.Settings.Item(Prefrix & "Index" & Index) = Form_Main.options_list(Index).lb_playlist.FindString(SearchFilePath)

                End If
            End If
        Next
        My.Settings.Save()
        Form_Main.LastSaveLoad = n_save.Value
        Dim msg As New MessageBox
        msg.Label1.Text = "Saved Folders to Playlist"
        msg.ShowDialog()
    End Sub

    Private Sub b_load_pl_Click(sender As Object, e As EventArgs) Handles b_load_pl.Click
        Form_Main.LastSaveLoad = n_save.Value
        Form_Main.LoadPlaylists(Me.n_save.Value)
    End Sub

    Private Sub b_nav_opt_Click(sender As Object, e As EventArgs) Handles b_prev_opt.Click, b_next_opt.Click
        If sender Is b_prev_opt Then
            If Me.Video = 1 Then
                Me.OpenNextOptions = 6
            Else
                Me.OpenNextOptions = Me.Video - 1
            End If
        ElseIf sender Is b_next_opt Then
            If Me.Video = 6 Then
                Me.OpenNextOptions = 1
            Else
                Me.OpenNextOptions = Me.Video + 1
            End If
        End If
        Me.Visible = False
        Form_Main.OptionsClosed(Me, Nothing)
    End Sub

    Private Sub cms_listbox_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_listbox.Opening
        If VideoToEffect.input.state = Form_Main.PlayerState.Playing Then
            Form_Main.ContextPausedPlayer = Me.Video
            VideoToEffect.playlist.togglePause()
        End If
        'Dim PlayerUnder = Me.TableLayoutPanel1.GetChildAtPoint(Me.TableLayoutPanel1.PointToClient(MousePosition), GetChildAtPointSkip.None)
        If Me.lb_playlist.SelectedItem Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        If Me.Visible Then
            If Me.lb_playlist.SelectedIndex <> Me.lb_playlist.IndexFromPoint(Me.lb_playlist.PointToClient(MousePosition)) Then
                Me.lb_playlist.SelectedIndex = Me.lb_playlist.IndexFromPoint(Me.lb_playlist.PointToClient(MousePosition))
                e.Cancel = True
                Exit Sub
            End If
        Else
        End If

        If Me.RenameFileTSTB.Text.Length > 20 Then
            Me.cms_listbox.Width = Me.RenameFileTSTB.Text.Length * 7 + 16
            Me.RenameFileTSTB.Width = Me.RenameFileTSTB.Text.Length * 7
        Else
            Me.cms_listbox.Width = 116
            Me.RenameFileTSTB.Width = 100
        End If
    End Sub

    'Right Click playlist
    Private Sub cms_listbox_Opened(sender As Object, e As EventArgs) Handles cms_listbox.Opened
        If Not Me.Visible Then Exit Sub
        'HACK! Otherwise the options modal is lost under the videos
        'Form_Main.SuspendLayout()
        Form_Main.SendToBack()
        cms_listbox.BringToFront()
        'Form_Main.ResumeLayout()
    End Sub

    Private Sub RenamePlayItem()
        If RenameFileTSTB.Text = "" Then
            cms_listbox.Visible = False
            MsgBox("File name can not be blank.")
            Exit Sub
        End If
        Dim NewFilename() As String = Me.lb_playlist.SelectedItem.Split("\"c)
        Dim Exten As String = NewFilename(NewFilename.Length - 1).Substring(NewFilename(NewFilename.Length - 1).Length - 4)
        If RenameFileTSTB.Text = NewFilename(NewFilename.Length - 1).Substring(0, NewFilename(NewFilename.Length - 1).Length - 4) Then
            MsgBox("New and old Filenames are the same")
            Exit Sub
        End If
        NewFilename(NewFilename.Length - 1) = RenameFileTSTB.Text & Exten
        Dim sNewFN As String = Join(NewFilename, "\")
        If System.IO.File.Exists(sNewFN) Then
            MsgBox("Filename Already Exists")
        Else
            Me.VideoToEffect.playlist.stop()
            Try
                System.IO.File.Move(Me.lb_playlist.SelectedItem, sNewFN)
                Me.AddFile(sNewFN)
            Catch ex As Exception
                MsgBox("Error, file not renamed.")
                Exit Sub
            End Try
            Dim NextPlay As Integer = Me.lb_playlist.SelectedIndex
            If NextPlay >= lb_playlist.Items.Count + 1 Then
                NextPlay = -1
            End If
            Me.VideoToEffect.playlist.items.remove(Me.lb_playlist.SelectedIndex)
            Me.Playlist.Remove(Me.lb_playlist.SelectedItem)
            Me.lb_playlist.Items.Remove(Me.lb_playlist.SelectedItem)
            Me.lb_playlist.Items.Add(Me.Playlist.Last())
            Me.lb_playlist.SelectedIndex = NextPlay
            cms_listbox.Visible = False
        End If
    End Sub

    Private Sub RenameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles RenameFileTSTB.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.RenamePlayItem()
        End If
    End Sub

    Private Sub RenameTextBox_Click(sender As Object, e As EventArgs) Handles RenameFileTSTB.Click
        If Me.firstclick Then
            RenameFileTSTB.SelectAll()
            Me.firstclick = False
        End If
    End Sub

    Private Sub Move_Click(sender As Object, e As EventArgs) Handles MoveFileTSMI.Click
        Dim File As String = Me.lb_playlist.SelectedItem
        'Me.b_remove.PerformClick()
        Me.b_remove_Click(Nothing, Nothing)
        Process.Start("explorer.exe", "/select," & File)
    End Sub

    Private Sub RemoveMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, ToolStripMenuItem2.Click, ToolStripMenuItem3.Click, ToolStripMenuItem4.Click, ToolStripMenuItem5.Click
        'not completley working
        Dim Remove As String = DirectCast(sender, ToolStripMenuItem).Text
        Dim split() As String = Nothing
        Dim a As Integer = 0
        Do While a < Me.lb_playlist.Items.Count - 1
            split = Me.lb_playlist.Items.Item(a).ToString.Split("\")
            If split.Last.StartsWith(Remove) Then
                Me.Playlist.Remove(Me.lb_playlist.Items.Item(a).ToString)
                Me.VideoToEffect.playlist.items.remove(a)
                Me.lb_playlist.Items.RemoveAt(a)
            Else
                a = a + 1
            End If
        Loop
        If Me.lb_playlist.SelectedIndex = -1 And Me.lb_playlist.Items.Count > 0 Then
            Me.lb_playlist.SelectedIndex = 0
        End If
    End Sub

    'close

    Friend Sub b_close_Click(sender As System.Object, e As System.EventArgs) Handles b_close.Click
        If Me.FullScreen Then
            Me.FullScreen = False
            Form_Main.ChangeAspect(Me.VideoToEffect)
            TogglePauseAllVideos(Me.VideoToEffect)
        End If

        Me.VideoToEffect.Toolbar = False
        Me.VideoToEffect.Toolbar = True

        If Not sender Is Nothing Then
            Me.Close()
        End If
    End Sub

    '  >> Drags

    Friend Sub lb_playlist_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lb_playlist.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Friend Sub lb_playlist_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lb_playlist.DragDrop
        Dim formats() As String = e.Data.GetFormats()
        Dim s() As String = Nothing
        If (formats.Contains("FileDrop")) Then
            s = e.Data.GetData(DataFormats.FileDrop, False)
        ElseIf (formats.Contains("Text")) Then
            ReDim s(0)
            s(0) = e.Data.GetData(DataFormats.StringFormat, True)
        End If
        For Each fh In s
            If System.IO.Directory.Exists(fh) Then
                AddFolder(fh)
            ElseIf System.IO.File.Exists(fh) Then
                Me.AddFile(fh)
            End If
        Next
        Me.PopulatePlayList(Nothing, True)
    End Sub

    '  >> Subroutines

    Friend Sub TogglePauseAllVideos(Optional Exception As AxAXVLC.AxVLCPlugin2 = Nothing)
        Dim Vid As AxAXVLC.AxVLCPlugin2
        For a = 1 To 6
            Vid = DirectCast(Form_Main.Controls.Find("AxVLCPlugin2" & a, True)(0), AxAXVLC.AxVLCPlugin2)
            If Not Exception Is Nothing Then
                If Exception Is Vid Then Continue For
                If Vid.input.state = Form_Main.PlayerState.Paused AndAlso Me.FullScreen Then Continue For
                Vid.playlist.togglePause()
            End If
        Next
    End Sub

    Public Sub AddFolder(Path As String)
        For Each fs In System.IO.Directory.EnumerateFiles(Path)
            Me.AddFile(fs)
        Next
        For Each fs In System.IO.Directory.EnumerateDirectories(Path)
            AddFolder(fs)
        Next

    End Sub

    Public Sub AddFile(Path As String)
        If Form_Main.ExtInclude.Contains(Path.Substring(Path.LastIndexOf(".") + 1).ToLower) Then
            Me.VideoToEffect.playlist.add(Me.VLCFormatFilePath(Path))
            Me.Playlist.Add(Path)
        End If
    End Sub

    Friend Sub PopulatePlayList(Optional PlayItem As String = Nothing, Optional Play As Boolean = False)
        Me.lb_playlist.Items.Clear()

        '''''
        If Me.Playlist.Count = 0 Then
            Me.VideoToEffect.playlist.items.clear()
            Me.l_playlist_count.Text = "Playlist Items : 0"
            Exit Sub
        End If
        '''''

        For Each aFile As String In Me.Playlist
            lb_playlist.Items.Add(aFile)
        Next

        Me.l_playlist_count.Text = "Playlist Items : " & Me.Playlist.Count

        If PlayItem Is Nothing AndAlso Not Play Then
            Exit Sub
        ElseIf PlayItem Is Nothing AndAlso Play Then
            Console.WriteLine("Playing First In List")
            Me.LBIgnoreIndexChange = False
            Me.lb_playlist.SelectedIndex = 0
        ElseIf Not PlayItem Is Nothing AndAlso Me.lb_playlist.Items.Contains(PlayItem) Then
            Me.LBIgnoreIndexChange = Not Play
            Me.lb_playlist.SelectedItem = PlayItem
        End If
    End Sub

    Friend Function ConvertPlayList() As Specialized.StringCollection
        If Me.Playlist.Count = 0 Then Return Nothing

        Dim Result As New Specialized.StringCollection
        Dim Paths(Me.Playlist.Count) As String
        Dim a As Integer = 0
        For Each File As String In Me.Playlist
            Paths(a) = File
            a = a + 1
        Next
        Result.AddRange(Paths)
        Return Result
    End Function

    Friend Function ConvertPlayListToFolders() As Specialized.StringCollection
        If Me.Playlist.Count = 0 Then Return Nothing

        Dim Result As New Specialized.StringCollection
        Dim Folders As New List(Of String)
        For Each File As String In Me.Playlist
            If Not Folders.Contains(DirectCast(System.IO.Directory.GetParent(File), System.IO.DirectoryInfo).FullName) Then
                Folders.Add(DirectCast(System.IO.Directory.GetParent(File), System.IO.DirectoryInfo).FullName)
            End If
        Next
        Result.AddRange(Folders.ToArray)
        Return Result
    End Function

    Friend Function VLCFormatFilePath(FileName As String) As String
        Return "file:///" & FileName.Replace("/", "\")
    End Function

    Friend Sub ChangePlaylistIndex()
        Dim NowPlaying As String
        Try
            NowPlaying = Me.VideoToEffect.mediaDescription.title
            If Me.lb_playlist.SelectedItem <> NowPlaying Then
                Me.LBIgnoreIndexChange = True
                Me.lb_playlist.SelectedItem = NowPlaying
            End If
        Catch ex As Exception
            NowPlaying = Nothing
        End Try
        If Me.Playlist.Count <> Me.lb_playlist.Items.Count <> Me.VideoToEffect.playlist.items.count Then
            Me.PopulatePlayList(NowPlaying, False)
        End If
    End Sub

    'Test

    Private Sub b_refreshdirs_Click(sender As Object, e As EventArgs) Handles b_refreshdirs.Click
        If Me.Playlist.Count = 0 Then Exit Sub
        Dim Dirs As New List(Of String)
        Dim NewDir As String
        For Each File In Me.Playlist
            NewDir = System.IO.Directory.GetParent(File).FullName
            If Not Dirs.Contains(NewDir) Then Dirs.Add(NewDir)
        Next
        Me.b_clear_playlist.PerformClick()
        Dim Files As New List(Of String)
        For Each sDir In Dirs
            Files.AddRange(System.IO.Directory.EnumerateFiles(sDir))
        Next
        For Each File In Files
            Me.AddFile(File)
        Next
        Me.PopulatePlayList(, True)
    End Sub

    Private Sub lb_playlist_KeyDown(sender As Object, e As KeyEventArgs) Handles lb_playlist.KeyDown
        If e.KeyData = Keys.F2 Then
            If Me.lb_playlist.SelectedIndex > -1 Then
                Me.cms_listbox.Show(PointToScreen(Me.lb_playlist.Location))
                Me.RenameFileTSTB.Focus()
            End If
        End If
    End Sub

    Private Sub cms_listbox_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles cms_listbox.Closing
        If Form_Main.ContextPausedPlayer > 0 Then
            Form_Main.options_list(Form_Main.ContextPausedPlayer).VideoToEffect.playlist.togglePause()
            Form_Main.ContextPausedPlayer = 0
        End If
    End Sub

    Private Sub RandListTSMI_Click(sender As Object, e As EventArgs) Handles RandListTSMI.Click
        Me.b_random.Tag = "Rand"
        Me.b_random_Click(Nothing, Nothing)
    End Sub

End Class