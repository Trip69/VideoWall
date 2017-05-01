Imports System.Threading

Public Class Form_Main

    'TODO

    Public Enum PlayerState
        Idle = 0
        Opening = 1
        Buffering = 2
        Playing = 3
        Paused = 4
        Stopping = 5
        Ended = 6
        SomeError = 7
    End Enum

    Private Class EventRecord
        Public EventName As String
        Public From As AxVLCPlugin2
        Public Time As Integer
    End Class

    Private Class LoopInfo
        Public Enum States
            Disabled = 0
            TagA = 1
            TagB = 2
        End Enum

        Public Video As AxVLCPlugin2
        Private eState As States = States.Disabled
        Public PositionA As Double
        Public PositionB As Double
        Public Property State As States
            Set(value As States)
                Me.eState = value
                If value = States.Disabled Then
                    Form_Main.b_loop.Text = "A"
                End If
            End Set
            Get
                Return Me.eState
            End Get
        End Property
    End Class

    Private Class PlayItem
        Public Player As AxVLCPlugin2
        Public PlayIndex As Integer
    End Class

    Private Class LoadList
        Private oPlayer As AxVLCPlugin2
        Public Property Player As AxVLCPlugin2
            Get
                Return Me.oPlayer
            End Get
            Set(value As AxVLCPlugin2)
                Me.oPlayer = value
                Me.PlayerIndex = oPlayer.Name.Last.ToString
                Me.PlayerOptions = Form_Main.options_list(PlayerIndex)
            End Set
        End Property

        Public PlayerIndex As Integer
        Public PlayIndex As Integer
        Public SaveIndex As Integer
        Public PlayerOptions As FormOptions
        Public FileList As New List(Of String)
        Public DirList As New List(Of String)
        Public SplitInto As Boolean
        Private oOwner As Form_Main
        Public ReadOnly Property SingleDirectoryOnly As String
            Get
                If DirList.Count = 1 Then
                    Return DirList(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub New(Owner As Form_Main)
            Me.oOwner = Owner
        End Sub

        Public Sub LoadFileList()
            Me.PlayerOptions.b_clear_playlist_Click(Nothing, Nothing)
            'If My.Settings.Item("Save" & SaveIndex & "Player" & PlayerIndex) Is Nothing Then Exit Sub
            Dim Files(DirectCast(My.Settings.Item("Save" & SaveIndex & "Player" & PlayerIndex), System.Collections.Specialized.StringCollection).Count) As String
            DirectCast(My.Settings.Item("Save" & SaveIndex & "Player" & PlayerIndex), System.Collections.Specialized.StringCollection).CopyTo(Files, 0)
            If Files Is Nothing Then Exit Sub
            For Each File In Files
                If File Is Nothing Then Continue For
                If System.IO.File.Exists(File) Then
                    FileList.Add(File)
                ElseIf System.IO.Directory.Exists(File) AndAlso Not DirList.Contains(File) Then
                    FileList.AddRange(System.IO.Directory.EnumerateFiles(File))
                    DirList.Add(File)
                End If
            Next
            Me.PlayIndex = My.Settings.Item("Save" & SaveIndex & "Index" & PlayerIndex)
            FileList.RemoveAll(Function(x) Not ExtInclude.Contains(x.Substring(x.Length - 3)))
            FileList.ForEach(Sub(x) Me.PlayerOptions.AddFile(x))
            Me.PlayerOptions.PopulatePlayList()
            'If Me.PlayerIndex = 6 Then Debugger.Break()
            If Me.PlayIndex > Me.PlayerOptions.Playlist.Count - 1 Then
                Me.PlayIndex = Me.PlayerOptions.Playlist.Count - 1
            End If
        End Sub
        Public Sub Play()
            If Me.PlayIndex < 0 Then Exit Sub
            Dim pi As New PlayItem
            pi.Player = Me.oPlayer
            pi.PlayIndex = Me.PlayIndex
            Dim StartPlay As New Thread(AddressOf DelayedStart)
            StartPlay.Name = "Start Player " & Me.oPlayer.Name
            StartPlay.Start(pi)
        End Sub

        Private Sub DelayedStart(Info As PlayItem)
            Thread.Sleep(Info.Player.Name.Last().ToString * 500)
            If Me.oOwner.Disposing Or Me.oOwner.IsDisposed Or Info.Player.IsDisposed Then
                Thread.CurrentThread.Abort()
            End If
            Info.Player.playlist.playItem(Info.PlayIndex)
            'Me.PlayerOptions.FormOptions_Load(Nothing, Nothing)
            Thread.CurrentThread.Abort()
        End Sub
    End Class

    Friend Shared ExtInclude() As String = {"flv", "mp4", "avi", "mpg", "mpeg", "mov", "wmv", "mkv"}

    'Local Variables

    Friend options_list As New List(Of FormOptions)
    Private LoopState As New List(Of LoopInfo)
    Private PlayersForcedPause As New List(Of String)
    Private Big As New List(Of Boolean)
    Private Bigger As New List(Of Boolean)
    Private Aspect As New List(Of Boolean)

    Private LastEvent As EventRecord
    Private WasMaximized As Boolean
    Private PlayControl As AxVLCPlugin2
    Private ControlsEffect As AxVLCPlugin2
    Friend Shared LastSaveLoad As Integer = 1
    Private ToolDisplay As Long
    Private DoingDropDown As Boolean = False
    Friend Shared ContextPausedPlayer As Integer

    Private MousePos As System.Drawing.Point
    Private DropMenuCheck As Boolean

    Friend AutoAspect As Boolean = False

    '  >> Events

    Private Sub Form_Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.LastEvent = New EventRecord
        Me.LastEvent.EventName = ""
        Me.LastEvent.From = AxVLCPlugin21
        Me.LastEvent.Time = (Now.Minute * 60000) + (Now.Second * 1000) + (Now.Millisecond)

        Me.options_list.Add(Nothing)
        Me.LoopState.Add(New LoopInfo)
        Me.Big.Add(Nothing)
        Me.Bigger.Add(Nothing)
        Me.Aspect.Add(Nothing)
        Dim Player As AxVLCPlugin2

        For Each Player In TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
            Player.audio.toggleMute()
            Player.AutoPlay = True
            Me.Big.Add(False)
            Me.Bigger.Add(False)
            Me.Aspect.Add(True)

            Me.LoopState.Add(New LoopInfo)
            Me.LoopState.Last.Video = Player

            Me.options_list.Add(New FormOptions)
            Me.options_list.Last().VideoNumber = Player.Name.Last.ToString
        Next

        LoadPlaylists(1)
        Me.t_check_loop.Enabled = True

    End Sub

    Public Sub LoadPlaylists(LoadIndex As Integer)
        Dim lLoadLists As New List(Of LoadList)
        For a = 1 To 6
            Dim Player = Me.Controls.Find("AxVLCPlugin2" & a, True)(0)
            Dim NewList As New LoadList(Me)
            NewList.Player = Player
            NewList.SaveIndex = LoadIndex
            NewList.LoadFileList()
            lLoadLists.Add(NewList)
        Next
        For Each l In lLoadLists
            If l.SplitInto Then Continue For
            Dim DirOnly As String = l.SingleDirectoryOnly
            If DirOnly Is Nothing Then Continue For
            Dim SplitCol As List(Of LoadList) = lLoadLists.FindAll(Function(x) x.SingleDirectoryOnly = DirOnly)
            If SplitCol.Count = 1 Then Continue For
            SplitCol(0).PlayerOptions.cb_split.SelectedItem = SplitCol.Count - 1
            SplitCol(0).PlayerOptions.b_split_list_Click(Nothing, Nothing)
            SplitCol.ForEach(Sub(x) x.SplitInto = True)
            'SplitCol(0).Play()
        Next
        lLoadLists.ForEach(Sub(x) x.Play())
    End Sub

    Private Sub Form_Main_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.t_check_loop.Enabled = False
        Me.t_checkplaying.Enabled = False
        Me.t_mouse.Enabled = False
        Me.tp_controls.Visible = False

        'Try to kill players
        Me.SuspendLayout()

        Dim Vid As AxVLCPlugin2
        Dim Threads As New List(Of Thread)
        Me.Cursor = Cursors.WaitCursor
        For Each Vid In Me.Controls.OfType(Of AxVLCPlugin2)()
            Dim KillThread As New Thread(AddressOf KillPlayer)
            Threads.Add(KillThread)
            KillThread.Name = "Kill " & Vid.Name
            KillThread.Start(Vid)
        Next

        Dim StopWatch As New Stopwatch
        StopWatch.Start()
        Do While StopWatch.ElapsedMilliseconds < 3000
            If Threads.Count = 0 Then Exit Do
            Thread.Yield()
            Threads.RemoveAll(Function(x) Not x.IsAlive)
            If Threads.Count = 0 Then
                Console.WriteLine("Form Closing: All Kill Threads Finished exiting")
                Exit Sub
            End If
            'Application.DoEvents()
        Loop

        Console.WriteLine("Form Closing: " & Threads.Count & " still alive")

        For Each Zombie In Me.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
            Zombie.BeginInvoke(Sub(x) x.close())
        Next
    End Sub

    Private Sub KillPlayer(Player As AxVLCPlugin2)
        Try
            SyncLock (Player)
                Player.playlist.stop()
                Thread.Yield()
                Player.BeginInvoke(Sub(x) x.close())
                'Application.DoEvents()
                'Console.WriteLine("Kill Thread: Exit OK")
            End SyncLock
        Catch ex As Exception
            Console.WriteLine("Kill Thread: Exception in Disposal")
        Finally
            Thread.CurrentThread.Abort()
        End Try
    End Sub

    Private Sub VLC_play(sender As System.Object, e As System.EventArgs) Handles AxVLCPlugin21.play, AxVLCPlugin22.play, AxVLCPlugin23.play, AxVLCPlugin24.play, AxVLCPlugin25.play, AxVLCPlugin26.play
        Dim Debug = False

        If Debug Then Console.WriteLine("INFO: Play Event on " & DirectCast(sender, AxVLCPlugin2).Name & ". State : " & DirectCast(sender, AxVLCPlugin2).input.state)

        Dim Player As AxVLCPlugin2 = sender
        Dim DoAspectChange As Boolean

        If Not Me.LastEvent.From Is Player Then
            DoAspectChange = True
        ElseIf Me.LastEvent.EventName <> "play" Then
            DoAspectChange = True
        ElseIf ((Now.Minute * 60000) + (Now.Second * 1000) + (Now.Millisecond) - Me.LastEvent.Time) > 200 Then
            DoAspectChange = True
        ElseIf Debug Then
            Console.WriteLine("Spam of Play from {0}", Player.Name)
        End If

        Me.LastEvent.From = Player
        Me.LastEvent.EventName = "play"
        Me.LastEvent.Time = (Now.Minute * 60000) + (Now.Second * 1000) + (Now.Millisecond)

        If DoAspectChange Then
            'If Player.input.state < PlayerState.Playing Then
            'If Debug Then Console.WriteLine("INFO: Waiting For Playing state")
            'Me.WaitForStateChange(Player)
            'End If
            Me.ChangeAspect(Player)
        End If
    End Sub

    'Makes the control panel the correct size and relevant
    Private Sub FormatControls()
        Dim loc = Me.ControlsEffect.Location
        Me.tp_controls.Width = Me.ControlsEffect.Width
        If TypeOf Me.ControlsEffect Is AxVLCPlugin2 Then
            loc.Y = Me.ControlsEffect.Location.Y + (Me.ControlsEffect.Height - 71)
            'Console.WriteLine("DEBUG: Ax Control X: " & ControlUnder.Location.X & " Y: " & ControlUnder.Location.Y)
        End If

        Me.tp_controls.Location = loc
        Me.tp_controls.Visible = True
        Me.ToolDisplay = 0

        If Me.ControlsEffect.playlist.isPlaying Or Me.ControlsEffect.input.state = PlayerState.Paused Then
            Me.UpdatePlayingLabel()
        Else
            Me.l_playing.Text = ""
        End If

        For a = 1 To 6
            If Me.options_list(a).FullScreen Then
                Me.options_list(a).FullScreen = False
                Me.ChangeAspect(Me.options_list(a).VideoToEffect)
                Me.options_list(a).TogglePauseAllVideos(Me.options_list(a).VideoToEffect)
                Exit For
            End If
            If Not options_list(a).Visible AndAlso Me.options_list(a).cms_listbox.Visible Then
                Me.DropMenuCheck = True
            End If
        Next

        'Loop
        Select Case Me.LoopState(Me.ControlsEffect.Name.Last.ToString).State
            Case LoopInfo.States.Disabled
                Me.b_loop.Text = "A"
            Case LoopInfo.States.TagA
                Me.b_loop.Text = "B"
            Case LoopInfo.States.TagB
                Me.b_loop.Text = "X"
        End Select

        Dim Index As Integer = Me.ControlsEffect.Name.Last.ToString

        If Me.WindowState <> FormWindowState.Maximized Then
            If Index = 3 Then
                Me.b_quit.Visible = True
            Else
                Me.b_quit.Visible = False
            End If
        End If

        'Big Button
        If Me.Big(Index) Then
            Me.b_big.Text = "Small"
            Me.b_big.Enabled = True
        Else
            Me.b_big.Text = "1x2"
            If Bigger.Contains(True) Then
                Me.b_big.Enabled = False
            ElseIf Me.ControlsEffect.Name.Last.ToString <= 3 AndAlso (Big(1) Or Big(2) Or Big(3)) Then
                Me.b_big.Enabled = False
            ElseIf Me.ControlsEffect.Name.Last.ToString >= 4 AndAlso (Big(4) Or Big(5) Or Big(6)) Then
                Me.b_big.Enabled = False
            Else
                Me.b_big.Enabled = True
            End If
        End If

        'Bigger Button
        If Me.Bigger(Index) Then
            Me.b_bigger.Text = "Smaller"
            Me.b_bigger.Enabled = True
        Else
            Me.b_bigger.Text = "2x2"
            Me.b_bigger.Enabled = Not (Bigger.Contains(True) Or Big.Contains(True))
        End If

        cb_change_player.Items.Clear()
        For a = 1 To 6
            If Index = a Then Continue For
            cb_change_player.Items.Add(a)
        Next

        'Label
        Me.l_playing.ContextMenuStrip = Me.options_list(Index).cms_listbox
    End Sub

    Private Sub UpdatePlayingLabel()
        If Not Me.tp_controls.Visible Or Me.ControlsEffect Is Nothing Then Exit Sub
        If Me.ControlsEffect.playlist.items.count = 0 Then
            Me.l_playing.Text = "Playlist Empty"
            Exit Sub
        ElseIf Me.ControlsEffect.input.state = PlayerState.Idle Then
            Me.l_playing.Text = ""
            Exit Sub
        End If
        'If Me.ControlsEffect.Name.Last = "6" Then Debugger.Break()
        Try
            Dim Chuncks() As String = Me.ControlsEffect.mediaDescription.title.Split("\"c)
            Dim time As String = FormatPosition(Me.ControlsEffect.input.Time) & "/" & FormatVideoLength(Me.ControlsEffect.input.Length)
            'Dim other As String = Me.ControlsEffect.input.
            Me.l_playing.Text = time & " | " & Chuncks(Chuncks.Length - 1)
            Me.tt_various.SetToolTip(Me.l_playing, Me.ControlsEffect.mediaDescription.title)
        Catch ex As Exception
            Me.l_playing.Text = "Unknown: VLC generated an error"
        End Try
    End Sub

    Private Sub cb_change_player_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_change_player.SelectedIndexChanged
        If ControlsEffect Is Nothing Then Exit Sub
        If cb_change_player.SelectedIndex = -1 Then Exit Sub
        If Not ControlsEffect.mediaDescription.title Is Nothing Then
            Me.options_list.Item(cb_change_player.Text).AddFile(ControlsEffect.mediaDescription.title)
            Me.options_list.Item(cb_change_player.Text).VideoToEffect.playlist.playItem(Me.options_list.Item(cb_change_player.Text).VideoToEffect.playlist.items.count - 1)
        End If
    End Sub

    'Mouse tick enable hide for menu
    Private Sub t_mouse_Tick(sender As Object, e As EventArgs) Handles t_mouse.Tick
        If Me.MousePos = MousePosition Or Not Me.Visible Or Me.DoingDropDown Then Exit Sub
        Me.MousePos = MousePosition
        Dim PlayerUnder = Me.TableLayoutPanel1.GetChildAtPoint(Me.TableLayoutPanel1.PointToClient(MousePosition), GetChildAtPointSkip.None)
        If PlayerUnder Is Nothing Then
            Exit Sub
        Else
            Me.t_hide_toolbar.Enabled = Me.tp_controls.GetChildAtPoint(Me.tp_controls.PointToClient(MousePosition), GetChildAtPointSkip.None) Is Nothing
            If Me.ControlsEffect Is Nothing Or Not Me.ControlsEffect Is PlayerUnder Then
                Me.ControlsEffect = PlayerUnder
                Me.FormatControls()
            ElseIf Me.DropMenuCheck Then
                For a = 1 To 6
                    If Me.options_list(a).cms_listbox.Visible AndAlso Not Me.options_list(a).cms_listbox.Bounds.Contains(MousePosition) Then
                        Me.options_list(a).cms_listbox.Visible = False
                        Me.DropMenuCheck = False
                        'Console.WriteLine("Hit on " & a)
                        Exit For
                    End If
                Next
            End If
            ToolDisplay = 0
        End If
    End Sub

    Private Sub t_hide_toolbar_Tick(sender As Object, e As EventArgs) Handles t_hide_toolbar.Tick
        Me.tp_controls.Visible = Me.ToolDisplay < 1799
        Me.ToolDisplay = Me.ToolDisplay + t_hide_toolbar.Interval
        If Me.tp_controls.Visible Then UpdatePlayingLabel()
    End Sub

    Private Sub cb_change_player_DropDown(sender As Object, e As EventArgs) Handles cb_change_player.DropDown, cb_change_player.DropDownClosed
        Me.DoingDropDown = Not Me.DoingDropDown
    End Sub

    '  >>  CLICKS

    Private Sub b_options_Click(sender As Object, e As EventArgs) Handles b_options.Click
        If Me.ControlsEffect Is Nothing Then Exit Sub
        Me.tp_controls.Visible = False
        If Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).IsDisposed Then
            Debugger.Break()
        Else
            'ElseIf Not Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).Visible Then
            Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).n_save.Value = LastSaveLoad
            'Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).Show(Me)
            Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).ShowDialog()
        End If

    End Sub

    Private Sub l_playing_Click(sender As Object, e As EventArgs) Handles l_playing.Click
        If Me.ControlsEffect Is Nothing Then Exit Sub
        RenameForm.PlayerNumber = Int(Me.ControlsEffect.Name.Last.ToString)
        RenameForm.ShowDialog()
    End Sub

    Private Sub l_playing_DoubleClick(sender As Object, e As EventArgs) Handles l_playing.DoubleClick
        If ControlsEffect.playlist.isPlaying Or ControlsEffect.input.state = PlayerState.Paused Then
            Process.Start("explorer.exe", "/select," & Me.ControlsEffect.mediaDescription.title)
        End If
    End Sub

    'Private Sub l_playing_Click(sender As Object, e As EventArgs) Handles l_playing.Click
    '    If DirectCast(e, MouseEventArgs).Button = Windows.Forms.MouseButtons.Right Then
    'Dim Index As Integer = Me.ControlsEffect.Name.Last.ToString
    '        Me.options_list(Int(Index)).cms_listbox.Show(Me.l_playing, New Point(0, 0 - Me.options_list(Int(Index)).cms_listbox.Size.Height))
    '    End If
    'End Sub

    Private Sub b_back_Click(sender As Object, e As EventArgs) Handles b_back.Click
        If Me.ControlsEffect Is Nothing Or ControlsEffect.playlist.items.count < 1 Then Exit Sub
        Me.ControlsEffect.playlist.prev()
        Me.LoopState(Int(Me.ControlsEffect.Name.Last.ToString)).State = LoopInfo.States.Disabled
        UpdatePlayingLabel()
    End Sub

    Private Sub b_forward_Click(sender As Object, e As EventArgs) Handles b_forward.Click
        If Me.ControlsEffect Is Nothing Or ControlsEffect.playlist.items.count < 1 Then Exit Sub
        Me.ControlsEffect.playlist.next()
        Me.LoopState(Int(Me.ControlsEffect.Name.Last.ToString)).State = LoopInfo.States.Disabled
        Me.UpdatePlayingLabel()
    End Sub

    Private Sub b_fullscreen_Click(sender As Object, e As EventArgs) Handles b_fullscreen.Click
        Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).b_video_fullscreen_Click(Nothing, Nothing)
        'Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).ShowDialog()
    End Sub

    Private Sub b_loop_Click(sender As Object, e As EventArgs) Handles b_loop.Click
        'Try
        '    If Me.ControlsEffect.mediaDescription.title Is Nothing Then Exit Sub
        'Catch ex As Exception
        '    Exit Sub
        'End Try
        If Not (Me.ControlsEffect.input.state = PlayerState.Paused Or Me.ControlsEffect.input.state = PlayerState.Playing) Then
            Exit Sub
        End If
        Dim LoopS As LoopInfo = Me.LoopState(Int(Me.ControlsEffect.Name.Last.ToString))
        Select Case LoopS.State
            Case LoopInfo.States.TagB
                LoopS.State = LoopInfo.States.Disabled
                Me.b_loop.Text = "A"
            Case LoopInfo.States.Disabled
                LoopS.PositionA = Me.ControlsEffect.input.Position
                LoopS.State = LoopInfo.States.TagA
                Me.b_loop.Text = "B"
            Case LoopInfo.States.TagA
                LoopS.PositionB = Me.ControlsEffect.input.Position
                LoopS.State = LoopInfo.States.TagB
                Me.b_loop.Text = "X"
        End Select

    End Sub

    Private Sub b_pause_play_Click(sender As Object, e As EventArgs) Handles b_pause_play.Click
        Dim Player As AxVLCPlugin2
        If Me.b_pause_play.Tag = "Pause" Then
            Me.b_pause_play.Tag = "Play"
            For Each Player In Me.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
                If Player.playlist.isPlaying AndAlso Not Player.input.state = PlayerState.Paused Then
                    Player.playlist.togglePause()
                End If
            Next
        Else
            Me.b_pause_play.Tag = "Pause"
            For Each Player In Me.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
                If Player.input.state = PlayerState.Paused Then
                    Player.playlist.togglePause()
                Else
                    Player.playlist.play()
                End If
            Next
        End If
    End Sub

    Private Sub b_big_Click(sender As Object, e As EventArgs) Handles b_big.Click
        If Me.ControlsEffect Is Nothing Then Exit Sub
        Me.TableLayoutPanel1.SuspendLayout()
        Dim BigChangeIndex As Integer = Me.ControlsEffect.Name.Last.ToString
        Dim Modifier As Integer
        Select Case BigChangeIndex
            Case 1, 2, 4, 5
                Modifier = 1
            Case 3, 6
                Modifier = -1
        End Select

        Me.tp_controls.Visible = False
        If Me.Big(BigChangeIndex) Then
            'Make Small
            Dim ControlToShow As AxVLCPlugin2 = Nothing
            Me.TableLayoutPanel1.SetColumnSpan(Me.ControlsEffect, 1)
            Select Case BigChangeIndex
                Case 3, 6
                    Me.TableLayoutPanel1.SetColumn(Me.ControlsEffect, 2)
            End Select
            ControlToShow = DirectCast(Me.gb_hidden.Controls.Find("AxVLCPlugin2" & BigChangeIndex + Modifier, False)(0), AxVLCPlugin2)
            Dim ColumnForControl As Integer = ControlToShow.Name.Last.ToString
            ColumnForControl = IIf(ColumnForControl < 3, ColumnForControl - 1, ColumnForControl - 4)
            ControlToShow.Parent = Me.TableLayoutPanel1
            'Columns start at index 0
            Me.TableLayoutPanel1.SetCellPosition(ControlToShow, New TableLayoutPanelCellPosition(ColumnForControl, Int(BigChangeIndex > 3)))
            If ControlToShow.input.state = PlayerState.Paused Then ControlToShow.playlist.togglePause()
            'Me.Aspect(BigChangeIndex) = True
            Application.DoEvents()
            Me.ChangeAspect(Me.ControlsEffect)
            Me.Big(BigChangeIndex) = False
            Me.b_big.Text = "Big"
        Else
            'Make Big
            Dim ControlToHide As AxVLCPlugin2 = Nothing
            ControlToHide = DirectCast(Me.TableLayoutPanel1.Controls.Find("AxVLCPlugin2" & BigChangeIndex + Modifier, False)(0), AxVLCPlugin2)
            If ControlToHide.input.state = PlayerState.Playing Then ControlToHide.playlist.togglePause()
            ControlToHide.Parent = Me.gb_hidden
            Application.DoEvents()
            Select Case BigChangeIndex
                Case 3, 6
                    Me.TableLayoutPanel1.SetColumn(Me.ControlsEffect, 1)
            End Select
            Me.TableLayoutPanel1.SetColumnSpan(Me.ControlsEffect, 2)
            Application.DoEvents()
            Me.ChangeAspect(Me.ControlsEffect)
            'Me.Aspect(BigChangeIndex) = False
            'Me.RemoveAspect(Me.ControlsEffect)
            Me.Big(BigChangeIndex) = True
            Me.b_big.Text = "Small"
        End If
        Me.TableLayoutPanel1.ResumeLayout()
        Me.FormatControls()
    End Sub

    Private Sub b_Bigger_Click(sender As Object, e As EventArgs) Handles b_bigger.Click
        If Me.ControlsEffect Is Nothing Then Exit Sub

        Me.TableLayoutPanel1.SuspendLayout()
        Dim BigChangeIndex As Integer = Me.ControlsEffect.Name.Last.ToString
        Dim Location As Integer = 0
        Dim Items As New List(Of Integer)
        Select Case BigChangeIndex
            Case 1, 4
                Items.Add(1)
                Items.Add(2)
                Items.Add(4)
                Items.Add(5)
                Location = 1
            Case 2, 5, 3, 6
                Items.Add(2)
                Items.Add(3)
                Items.Add(5)
                Items.Add(6)
                Location = 2
        End Select
        Items.Remove(BigChangeIndex)
        Dim ControlsHide As List(Of AxVLCPlugin2) = GetPlayersToHide_Bigger(Items)

        Me.tp_controls.Visible = False
        If Me.Bigger(BigChangeIndex) Then
            'Make Small
            Me.TableLayoutPanel1.SetColumnSpan(Me.ControlsEffect, 1)
            Me.TableLayoutPanel1.SetRowSpan(Me.ControlsEffect, 1)
            Application.DoEvents()

            Dim Col As Integer = IIf(Me.ControlsEffect.Name.Last.ToString <= 3, Me.ControlsEffect.Name.Last.ToString - 1, Me.ControlsEffect.Name.Last.ToString - 4)
            Dim Row As Integer = Math.Floor((Me.ControlsEffect.Name.Last.ToString - 1) / 3)
            Me.TableLayoutPanel1.SetCellPosition(Me.ControlsEffect, New TableLayoutPanelCellPosition(Col, Row))
            Application.DoEvents()

            Me.ChangeAspect(Me.ControlsEffect)
            For Each Player In ControlsHide
                Player.Parent = Me.TableLayoutPanel1
                Application.DoEvents()
                If Player.input.state = PlayerState.Paused Then Player.playlist.togglePause()
            Next
            Me.Bigger(BigChangeIndex) = False
            Me.b_big.Text = "Bigger"
        Else
            'MakeBig
            For Each Player In ControlsHide
                If Player.input.state = PlayerState.Playing Then Player.playlist.togglePause()
                Player.Parent = gb_hidden
                Application.DoEvents()
            Next
            Me.TableLayoutPanel1.SetCellPosition(Me.ControlsEffect, New TableLayoutPanelCellPosition(0, 0))
            Me.TableLayoutPanel1.SetColumnSpan(Me.ControlsEffect, 2)
            Me.TableLayoutPanel1.SetRowSpan(Me.ControlsEffect, 2)
            Application.DoEvents()

            Me.ChangeAspect(Me.ControlsEffect)
            Me.Bigger(BigChangeIndex) = True
            Me.b_big.Text = "Small"
        End If
        Me.TableLayoutPanel1.ResumeLayout()
        Me.FormatControls()
    End Sub

    'Helper function for Bigger
    Private Function GetPlayersToHide_Bigger(Keys As List(Of Integer)) As List(Of AxVLCPlugin2)
        Dim Result As New List(Of AxVLCPlugin2)
        For Each Key As Integer In Keys
            Result.Add(Me.Controls.Find("AxVLCPlugin2" & Key, True)(0))
        Next
        Return Result
    End Function

    Private Sub b_aspect_Click(sender As Object, e As EventArgs) Handles b_aspect.Click
        Dim Index As Integer = Me.ControlsEffect.Name.Last.ToString
        If Me.Aspect(Index) Then
            'Turn Off Auto Aspect
            Me.Aspect(Index) = False
            Me.RemoveAspect(Me.ControlsEffect)
        Else
            'Turn On Auto Aspect
            Me.Aspect(Index) = True
            Me.ChangeAspect(Me.ControlsEffect)
        End If

    End Sub

    Private Sub b_app_full_Click(sender As Object, e As EventArgs) Handles b_app_full.Click
        Me.options_list(1).b_fullscreen_Click(Nothing, Nothing)
        Me.FormatControls()
    End Sub

    Private Sub b_quit_Click(sender As Object, e As EventArgs) Handles b_quit.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.Close()
        ElseIf Not Form_General_Options.Visible Then
            Form_General_Options.Show(Me)
        End If

    End Sub

    '  >> TICKS

    Private Sub t_checkplaying_Tick(sender As Object, e As EventArgs) Handles t_checkplaying.Tick
        If Me.Disposing Or Me.IsDisposed Then Exit Sub
#If DEBUG Then
        For Each op In Me.options_list
            If op Is Nothing Then Continue For
            If op.IsDisposed Then Console.WriteLine(op.Name & " is dead")
        Next
#End If

        Dim Players = Me.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
        Dim Index As Integer

        For Each Player In Players

            Index = Player.Name.Last.ToString
            If Player.playlist.isPlaying AndAlso Player.Tag = Player.mediaDescription.title Then
                Continue For
            ElseIf Player.playlist.isPlaying Then

                Player.Tag = Player.mediaDescription.title

                If AutoAspect Then
                    Me.Aspect(Index) = True
                    Me.ChangeAspect(Player)
                End If

                Me.LoopState(Index).State = LoopInfo.States.Disabled
                Me.b_loop.Text = "A"

                Me.options_list(Index).LBIgnoreIndexChange = True
                Me.options_list(Index).lb_playlist.SelectedItem = Player.mediaDescription.title
                'Console.WriteLine("DEBUG: Aspect on: " & a)

            End If

        Next

    End Sub

    Private Sub t_check_loop_Tick(sender As Object, e As EventArgs) Handles t_check_loop.Tick
        For Each VideoToLoop In Me.LoopState.FindAll(Function(x) x.State = LoopInfo.States.TagB)
            If VideoToLoop.Video.input.Position > VideoToLoop.PositionB Then
                VideoToLoop.Video.input.Position = VideoToLoop.PositionA
            End If
        Next
    End Sub

    '  >>  DRAGS

    Private Sub Button_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs)
        'MsgBox(Me.ControlsEffect.Name.Last.ToString)
    End Sub

    Friend Sub Button_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs)

    End Sub

    '  >>  RESIZES

    Private Sub Form_Main_ResizeBegin(sender As System.Object, e As System.EventArgs) Handles MyBase.ResizeBegin
        Me.tp_controls.Visible = False
        Me.SuspendLayout()
    End Sub

    Private Sub Form_Main_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        Me.tp_controls.Visible = False
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WasMaximized = True
            If AutoAspect Then
                Me.ChangeAspect()
            End If
        ElseIf Me.WindowState = FormWindowState.Normal And Me.WasMaximized Then
            Me.WasMaximized = False
            If AutoAspect Then
                Me.ChangeAspect()
            End If
        End If
        Application.DoEvents()
    End Sub

    Private Sub Form_Main_ResizeEnd(sender As System.Object, e As System.EventArgs) Handles MyBase.ResizeEnd
        'Console.WriteLine("Resizse on Main_Form")
        Me.ResumeLayout()
        If AutoAspect Then
            Me.ChangeAspect()
        End If
    End Sub

    ' >> Sub Routinues

    Friend Sub PlayIfNot(Player As AxVLCPlugin2)
        'Console.WriteLine("PlayIfNot")
        If Player.input.state <> PlayerState.Playing AndAlso Player.playlist.items.count > 0 Then
            Player.playlist.play()
        End If
    End Sub

    Public Sub WaitForStateChange(Player As AxVLCPlugin2, Optional StateToWaitFor As PlayerState = PlayerState.Playing)
        Dim CurrentState As Integer = Player.input.state
        Dim Sanity As Integer = 0
        Do While Sanity < 200
            If CurrentState <> Player.input.state Or StateToWaitFor = Player.input.state Then Exit Do
            Threading.Thread.Sleep(10)
            Sanity = Sanity + 1
        Loop
    End Sub

    Private Function FormatVideoLength(Length As Double) As String
        Dim Result As String = ""
        Length = CInt(Length / 1000)
        If Length > 216000 Then
            Result = CInt(Length / 216000) & ":"
            Length = Length - (CInt(Length / 216000) * 216000)
        End If
        If Length / 60 < 10 Then Result = Result & "0"
        Result = Result & CInt(Length / 60) & ":"
        Length = Length - (CInt(Length / 60) * 60)
        If Length < 0 Then Length = Length * -1
        If Length < 10 Then Result = Result & "0"
        Result = Result & CInt(Length)
        Return Result
    End Function

    Private Function FormatPosition(Length As Double) As String
        Dim seconds As Integer = Length / 1000
        If seconds < 60 Then
            Return "00:" & Format(seconds, "00")
        Else
            Return Format(Math.Floor(seconds / 60), "00") & ":" & Format(seconds - Math.Floor(seconds / 60) * 60, "00")
        End If
    End Function

    Friend Sub OptionsClosed(sender As Object, e As FormClosedEventArgs)
        Dim th As New Thread(AddressOf WaitingThread)
        th.Start(sender)
    End Sub

    Private Sub WaitingThread(sender As Video_Wall.FormOptions)
        Dim Waiting As Boolean = True
        Do While Waiting
            Thread.Sleep(100)
            If sender.Visible = False AndAlso Parent Is Nothing Then
                Thread.Sleep(100)
                Waiting = False
            End If
        Loop
        If sender.OpenNextOptions > 0 Then
            Dim temp As Integer = sender.OpenNextOptions
            sender.OpenNextOptions = -1
            Me.options_list(Int(Me.ControlsEffect.Name.Last.ToString)).n_save.Value = LastSaveLoad
            Me.Invoke(Sub() Me.options_list(temp).ShowDialog())
        End If
        Thread.CurrentThread.Abort()
    End Sub

    '  >>  ASPECT

    Friend Sub ChangeAspect(Optional Player As AxVLCPlugin2 = Nothing)

        If Player Is Nothing Then
            For Each Player In Me.TableLayoutPanel1.Controls.OfType(Of AxVLCPlugin2)()
                Me.ChangeAspect(Player)
            Next
            Exit Sub
        End If

        If Player.input.state = PlayerState.Idle Then Exit Sub
        If Player.input.state = Form_Main.PlayerState.SomeError Then Exit Sub
        Dim WriteDebug As Boolean
#If DEBUG Then
        WriteDebug = False
#End If
        Dim ForcedPause As Boolean
        Dim sanity As New Stopwatch
        Dim Index As Integer = Player.Name.Last.ToString

        sanity.Start()
        Try
            Thread.BeginCriticalRegion()
            Do Until Player.input.state >= Form_Main.PlayerState.Playing AndAlso Player.input.state < Form_Main.PlayerState.SomeError
                Application.DoEvents()
                Thread.Yield()
                'Threading.Thread.Sleep(10)
                If sanity.ElapsedMilliseconds > 5000 Then
                    Console.WriteLine(Player.Name & " being slow changing state from " & Player.input.state)
                ElseIf sanity.ElapsedMilliseconds > 1500 AndAlso Player.input.state = Form_Main.PlayerState.SomeError Then
                    Console.WriteLine(Player.Name & " has an error while changing aspect")
                    Exit Sub
                ElseIf Player.IsDisposed Then
                    Console.WriteLine(Player.Name & " has an error while changing aspect")
                    Exit Sub
                End If
            Loop

            'Ditch Playing or Paused
            If Not ((Player.input.state > PlayerState.Idle) AndAlso (Player.input.state < PlayerState.SomeError)) Then
                Console.WriteLine("INFO: Either Doing nothing or Error for " & Player.Name & ". State is : " & Player.input.state.ToString)
                If Me.PlayersForcedPause.Contains(Player.Name) Then Me.PlayersForcedPause.Remove(Player.Name)
                Exit Sub
            ElseIf Player.input.state = PlayerState.Playing Then
                Player.playlist.togglePause()
                While Player.input.state <> PlayerState.Paused
                    If Player Is Nothing Or Player.IsDisposed Or sanity.ElapsedMilliseconds > 5000 Then Exit Sub
                    Application.DoEvents()
                End While
                ForcedPause = True
                Me.PlayersForcedPause.Add(Player.Name)
            End If

#If Debug AndAlso WriteDebug Then
        Console.WriteLine()
        Console.WriteLine("INFO: Video x,y = " & Player.video.width & "," & Player.video.height)
        Console.WriteLine("INFO: Window x,y = " & Player.Width & "," & Player.Height)
#End If

            If (Me.options_list.Item(Index).FullScreen Or Me.Big(Index) Or (Not Me.Aspect(Index)) = False) Then

                'Crops
                If Player.Height < Player.video.height Or Player.Width < Player.video.width Then
                    If WriteDebug Then Console.WriteLine(Player.Name & ", Cropping")
                    Player.video.crop = Player.Width & ":" & Player.Height
                End If

                'Enlarges
                Dim x = Player.Width - Player.video.width
                Dim y = Player.Height - Player.video.height

                If x > 0 Or y > 0 Then
                    If WriteDebug Then Console.WriteLine(Player.Name & ", Enlarging: x:" & x & " y:" & y)
                    'Player.video.crop = "-1:-1"
                    Player.video.crop = Player.Width & ":" & Player.Height
                    'Player.video.aspectRatio = Player.Width & ":" & Player.Height
                    'Player.video.aspectRatio = (Player.Height / Player.video.height * Player.video.width) & ":" & Player.Height
                End If
            End If

            If ForcedPause And Player.input.state = PlayerState.Paused Then
                Player.playlist.play()
            End If

        Catch ex As Exception

        Finally
            Thread.EndCriticalRegion()
        End Try

    End Sub

    Friend Sub RemoveAspect(Player As AxVLCPlugin2)
        Player.video.crop = Player.video.width & ":" & Player.video.height
        Player.video.aspectRatio = Player.video.width & ":" & Player.video.height
    End Sub

    'Test

    Private Sub b_test_code_Click(sender As Object, e As EventArgs)
    End Sub


End Class
