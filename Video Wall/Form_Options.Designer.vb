<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        'Console.WriteLine("Disposing " & Me.Video)
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOptions))
        Me.b_select_file = New System.Windows.Forms.Button()
        Me.b_select_directory = New System.Windows.Forms.Button()
        Me.b_close = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lb_playlist = New System.Windows.Forms.ListBox()
        Me.cms_listbox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenameTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFileTSTB = New System.Windows.Forms.ToolStripTextBox()
        Me.MoveFileTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.RandListTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.b_fullscreen = New System.Windows.Forms.Button()
        Me.b_video_fullscreen = New System.Windows.Forms.Button()
        Me.b_clear_playlist = New System.Windows.Forms.Button()
        Me.gb_split = New System.Windows.Forms.GroupBox()
        Me.l_split = New System.Windows.Forms.Label()
        Me.cb_split = New System.Windows.Forms.ComboBox()
        Me.b_split_list = New System.Windows.Forms.Button()
        Me.b_random = New System.Windows.Forms.Button()
        Me.b_remove = New System.Windows.Forms.Button()
        Me.b_next_opt = New System.Windows.Forms.Button()
        Me.b_prev_opt = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.b_savefolders = New System.Windows.Forms.Button()
        Me.b_load_pl = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.n_save = New System.Windows.Forms.NumericUpDown()
        Me.b_save_files = New System.Windows.Forms.Button()
        Me.b_delete = New System.Windows.Forms.Button()
        Me.b_skip_time = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.b_refreshdirs = New System.Windows.Forms.Button()
        Me.l_playlist_count = New System.Windows.Forms.Label()
        Me.b_remover = New System.Windows.Forms.Button()
        Me.r_moveall = New System.Windows.Forms.Button()
        Me.cms_listbox.SuspendLayout()
        Me.gb_split.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.n_save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'b_select_file
        '
        Me.b_select_file.Location = New System.Drawing.Point(16, 15)
        Me.b_select_file.Margin = New System.Windows.Forms.Padding(4)
        Me.b_select_file.Name = "b_select_file"
        Me.b_select_file.Size = New System.Drawing.Size(125, 28)
        Me.b_select_file.TabIndex = 0
        Me.b_select_file.Text = "Select File"
        Me.b_select_file.UseVisualStyleBackColor = True
        '
        'b_select_directory
        '
        Me.b_select_directory.Location = New System.Drawing.Point(16, 48)
        Me.b_select_directory.Margin = New System.Windows.Forms.Padding(4)
        Me.b_select_directory.Name = "b_select_directory"
        Me.b_select_directory.Size = New System.Drawing.Size(125, 28)
        Me.b_select_directory.TabIndex = 1
        Me.b_select_directory.Text = "Select Directory"
        Me.b_select_directory.UseVisualStyleBackColor = True
        '
        'b_close
        '
        Me.b_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_close.Location = New System.Drawing.Point(655, 554)
        Me.b_close.Margin = New System.Windows.Forms.Padding(4)
        Me.b_close.Name = "b_close"
        Me.b_close.Size = New System.Drawing.Size(116, 32)
        Me.b_close.TabIndex = 2
        Me.b_close.Text = "Close"
        Me.b_close.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lb_playlist
        '
        Me.lb_playlist.AllowDrop = True
        Me.lb_playlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_playlist.ContextMenuStrip = Me.cms_listbox
        Me.lb_playlist.FormattingEnabled = True
        Me.lb_playlist.ItemHeight = 16
        Me.lb_playlist.Location = New System.Drawing.Point(152, 4)
        Me.lb_playlist.Margin = New System.Windows.Forms.Padding(4)
        Me.lb_playlist.Name = "lb_playlist"
        Me.lb_playlist.Size = New System.Drawing.Size(617, 516)
        Me.lb_playlist.TabIndex = 3
        '
        'cms_listbox
        '
        Me.cms_listbox.AutoSize = False
        Me.cms_listbox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cms_listbox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameTSMI, Me.RenameFileTSTB, Me.MoveFileTSMI, Me.RandListTSMI})
        Me.cms_listbox.Name = "cms_listbox"
        Me.cms_listbox.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cms_listbox.ShowImageMargin = False
        Me.cms_listbox.Size = New System.Drawing.Size(116, 92)
        '
        'RenameTSMI
        '
        Me.RenameTSMI.Enabled = False
        Me.RenameTSMI.Name = "RenameTSMI"
        Me.RenameTSMI.Padding = New System.Windows.Forms.Padding(0)
        Me.RenameTSMI.ShowShortcutKeys = False
        Me.RenameTSMI.Size = New System.Drawing.Size(153, 22)
        Me.RenameTSMI.Text = "Rename"
        '
        'RenameFileTSTB
        '
        Me.RenameFileTSTB.AutoSize = False
        Me.RenameFileTSTB.Name = "RenameFileTSTB"
        Me.RenameFileTSTB.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.RenameFileTSTB.ShortcutsEnabled = False
        Me.RenameFileTSTB.Size = New System.Drawing.Size(100, 23)
        '
        'MoveFileTSMI
        '
        Me.MoveFileTSMI.Name = "MoveFileTSMI"
        Me.MoveFileTSMI.Padding = New System.Windows.Forms.Padding(0)
        Me.MoveFileTSMI.ShowShortcutKeys = False
        Me.MoveFileTSMI.Size = New System.Drawing.Size(153, 22)
        Me.MoveFileTSMI.Text = "Move File"
        '
        'RandListTSMI
        '
        Me.RandListTSMI.Name = "RandListTSMI"
        Me.RandListTSMI.Size = New System.Drawing.Size(153, 24)
        Me.RandListTSMI.Text = "Randomise List"
        '
        'b_fullscreen
        '
        Me.b_fullscreen.Location = New System.Drawing.Point(16, 84)
        Me.b_fullscreen.Margin = New System.Windows.Forms.Padding(4)
        Me.b_fullscreen.Name = "b_fullscreen"
        Me.b_fullscreen.Size = New System.Drawing.Size(125, 28)
        Me.b_fullscreen.TabIndex = 4
        Me.b_fullscreen.Text = "App Full Screen"
        Me.ToolTip1.SetToolTip(Me.b_fullscreen, "Make Application Fullscreen")
        Me.b_fullscreen.UseVisualStyleBackColor = True
        '
        'b_video_fullscreen
        '
        Me.b_video_fullscreen.Location = New System.Drawing.Point(16, 119)
        Me.b_video_fullscreen.Margin = New System.Windows.Forms.Padding(4)
        Me.b_video_fullscreen.Name = "b_video_fullscreen"
        Me.b_video_fullscreen.Size = New System.Drawing.Size(125, 28)
        Me.b_video_fullscreen.TabIndex = 5
        Me.b_video_fullscreen.Text = "Video Fullscreen"
        Me.b_video_fullscreen.UseVisualStyleBackColor = True
        '
        'b_clear_playlist
        '
        Me.b_clear_playlist.Location = New System.Drawing.Point(16, 277)
        Me.b_clear_playlist.Margin = New System.Windows.Forms.Padding(4)
        Me.b_clear_playlist.Name = "b_clear_playlist"
        Me.b_clear_playlist.Size = New System.Drawing.Size(125, 28)
        Me.b_clear_playlist.TabIndex = 8
        Me.b_clear_playlist.Text = "Clear Playlist"
        Me.b_clear_playlist.UseVisualStyleBackColor = True
        '
        'gb_split
        '
        Me.gb_split.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb_split.Controls.Add(Me.l_split)
        Me.gb_split.Controls.Add(Me.cb_split)
        Me.gb_split.Controls.Add(Me.b_split_list)
        Me.gb_split.Location = New System.Drawing.Point(5, 544)
        Me.gb_split.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_split.Name = "gb_split"
        Me.gb_split.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_split.Size = New System.Drawing.Size(343, 50)
        Me.gb_split.TabIndex = 10
        Me.gb_split.TabStop = False
        '
        'l_split
        '
        Me.l_split.AutoSize = True
        Me.l_split.Location = New System.Drawing.Point(211, 18)
        Me.l_split.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_split.Name = "l_split"
        Me.l_split.Size = New System.Drawing.Size(129, 17)
        Me.l_split.TabIndex = 12
        Me.l_split.Text = "additional player(s)"
        '
        'cb_split
        '
        Me.cb_split.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_split.FormattingEnabled = True
        Me.cb_split.Location = New System.Drawing.Point(141, 15)
        Me.cb_split.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_split.Name = "cb_split"
        Me.cb_split.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cb_split.Size = New System.Drawing.Size(60, 24)
        Me.cb_split.TabIndex = 11
        '
        'b_split_list
        '
        Me.b_split_list.Location = New System.Drawing.Point(8, 12)
        Me.b_split_list.Margin = New System.Windows.Forms.Padding(4)
        Me.b_split_list.Name = "b_split_list"
        Me.b_split_list.Size = New System.Drawing.Size(125, 28)
        Me.b_split_list.TabIndex = 10
        Me.b_split_list.Text = "Split List Into"
        Me.ToolTip1.SetToolTip(Me.b_split_list, "Splits the list on this player overwritting the playlists on the floo")
        Me.b_split_list.UseVisualStyleBackColor = True
        '
        'b_random
        '
        Me.b_random.Location = New System.Drawing.Point(16, 226)
        Me.b_random.Margin = New System.Windows.Forms.Padding(4)
        Me.b_random.Name = "b_random"
        Me.b_random.Size = New System.Drawing.Size(125, 43)
        Me.b_random.TabIndex = 11
        Me.b_random.Tag = "Rand"
        Me.b_random.Text = "&Randomize Playlist"
        Me.b_random.UseVisualStyleBackColor = True
        '
        'b_remove
        '
        Me.b_remove.Location = New System.Drawing.Point(16, 155)
        Me.b_remove.Margin = New System.Windows.Forms.Padding(4)
        Me.b_remove.Name = "b_remove"
        Me.b_remove.Size = New System.Drawing.Size(125, 28)
        Me.b_remove.TabIndex = 12
        Me.b_remove.Text = "Remove Item"
        Me.ToolTip1.SetToolTip(Me.b_remove, "Remove selected from playlist")
        Me.b_remove.UseVisualStyleBackColor = True
        '
        'b_next_opt
        '
        Me.b_next_opt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_next_opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_next_opt.Location = New System.Drawing.Point(716, 529)
        Me.b_next_opt.Margin = New System.Windows.Forms.Padding(0)
        Me.b_next_opt.Name = "b_next_opt"
        Me.b_next_opt.Size = New System.Drawing.Size(53, 23)
        Me.b_next_opt.TabIndex = 15
        Me.b_next_opt.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.b_next_opt, "Options for next player")
        Me.b_next_opt.UseVisualStyleBackColor = True
        '
        'b_prev_opt
        '
        Me.b_prev_opt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_prev_opt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_prev_opt.Location = New System.Drawing.Point(655, 529)
        Me.b_prev_opt.Margin = New System.Windows.Forms.Padding(0)
        Me.b_prev_opt.Name = "b_prev_opt"
        Me.b_prev_opt.Size = New System.Drawing.Size(53, 23)
        Me.b_prev_opt.TabIndex = 16
        Me.b_prev_opt.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.b_prev_opt, "Options for previous player")
        Me.b_prev_opt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.b_savefolders)
        Me.GroupBox1.Controls.Add(Me.b_load_pl)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.n_save)
        Me.GroupBox1.Controls.Add(Me.b_save_files)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 382)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(142, 158)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Playlists (All)"
        '
        'b_savefolders
        '
        Me.b_savefolders.Location = New System.Drawing.Point(8, 123)
        Me.b_savefolders.Margin = New System.Windows.Forms.Padding(4)
        Me.b_savefolders.Name = "b_savefolders"
        Me.b_savefolders.Size = New System.Drawing.Size(125, 28)
        Me.b_savefolders.TabIndex = 24
        Me.b_savefolders.Text = "Save Folders"
        Me.ToolTip1.SetToolTip(Me.b_savefolders, "Save the directories the files are in, to be searched on load.")
        Me.b_savefolders.UseVisualStyleBackColor = True
        '
        'b_load_pl
        '
        Me.b_load_pl.Location = New System.Drawing.Point(5, 52)
        Me.b_load_pl.Margin = New System.Windows.Forms.Padding(4)
        Me.b_load_pl.Name = "b_load_pl"
        Me.b_load_pl.Size = New System.Drawing.Size(125, 28)
        Me.b_load_pl.TabIndex = 23
        Me.b_load_pl.Text = "Load Playlists"
        Me.ToolTip1.SetToolTip(Me.b_load_pl, "Loads all players playlist numbered #")
        Me.b_load_pl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Save #"
        '
        'n_save
        '
        Me.n_save.Location = New System.Drawing.Point(84, 22)
        Me.n_save.Margin = New System.Windows.Forms.Padding(4)
        Me.n_save.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.n_save.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.n_save.Name = "n_save"
        Me.n_save.Size = New System.Drawing.Size(47, 22)
        Me.n_save.TabIndex = 21
        Me.n_save.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'b_save_files
        '
        Me.b_save_files.Location = New System.Drawing.Point(8, 87)
        Me.b_save_files.Margin = New System.Windows.Forms.Padding(4)
        Me.b_save_files.Name = "b_save_files"
        Me.b_save_files.Size = New System.Drawing.Size(125, 28)
        Me.b_save_files.TabIndex = 19
        Me.b_save_files.Text = "Save Files"
        Me.ToolTip1.SetToolTip(Me.b_save_files, "Save playlistd as a file list")
        Me.b_save_files.UseVisualStyleBackColor = True
        '
        'b_delete
        '
        Me.b_delete.Location = New System.Drawing.Point(16, 191)
        Me.b_delete.Margin = New System.Windows.Forms.Padding(4)
        Me.b_delete.Name = "b_delete"
        Me.b_delete.Size = New System.Drawing.Size(125, 28)
        Me.b_delete.TabIndex = 21
        Me.b_delete.Text = "Delete Video"
        Me.ToolTip1.SetToolTip(Me.b_delete, "Delete Item from Playlist and computer")
        Me.b_delete.UseVisualStyleBackColor = True
        '
        'b_skip_time
        '
        Me.b_skip_time.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_skip_time.Location = New System.Drawing.Point(547, 554)
        Me.b_skip_time.Margin = New System.Windows.Forms.Padding(4)
        Me.b_skip_time.Name = "b_skip_time"
        Me.b_skip_time.Size = New System.Drawing.Size(100, 32)
        Me.b_skip_time.TabIndex = 22
        Me.b_skip_time.Text = "Skip Time"
        Me.b_skip_time.UseVisualStyleBackColor = True
        '
        'b_refreshdirs
        '
        Me.b_refreshdirs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_refreshdirs.Location = New System.Drawing.Point(378, 557)
        Me.b_refreshdirs.Margin = New System.Windows.Forms.Padding(4)
        Me.b_refreshdirs.Name = "b_refreshdirs"
        Me.b_refreshdirs.Size = New System.Drawing.Size(161, 28)
        Me.b_refreshdirs.TabIndex = 23
        Me.b_refreshdirs.Text = "Refresh Directories"
        Me.b_refreshdirs.UseVisualStyleBackColor = True
        '
        'l_playlist_count
        '
        Me.l_playlist_count.AutoSize = True
        Me.l_playlist_count.Location = New System.Drawing.Point(375, 524)
        Me.l_playlist_count.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_playlist_count.Name = "l_playlist_count"
        Me.l_playlist_count.Size = New System.Drawing.Size(109, 17)
        Me.l_playlist_count.TabIndex = 24
        Me.l_playlist_count.Text = "Playlist Items : 0"
        '
        'b_remover
        '
        Me.b_remover.Location = New System.Drawing.Point(13, 313)
        Me.b_remover.Margin = New System.Windows.Forms.Padding(4)
        Me.b_remover.Name = "b_remover"
        Me.b_remover.Size = New System.Drawing.Size(125, 28)
        Me.b_remover.TabIndex = 25
        Me.b_remover.Text = "Remove Rated"
        Me.b_remover.UseVisualStyleBackColor = True
        '
        'r_moveall
        '
        Me.r_moveall.Location = New System.Drawing.Point(16, 349)
        Me.r_moveall.Margin = New System.Windows.Forms.Padding(4)
        Me.r_moveall.Name = "r_moveall"
        Me.r_moveall.Size = New System.Drawing.Size(125, 28)
        Me.r_moveall.TabIndex = 26
        Me.r_moveall.Text = "Move all to PL 1"
        Me.r_moveall.UseVisualStyleBackColor = True
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 598)
        Me.Controls.Add(Me.r_moveall)
        Me.Controls.Add(Me.b_remover)
        Me.Controls.Add(Me.l_playlist_count)
        Me.Controls.Add(Me.b_refreshdirs)
        Me.Controls.Add(Me.b_skip_time)
        Me.Controls.Add(Me.b_delete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.b_prev_opt)
        Me.Controls.Add(Me.b_next_opt)
        Me.Controls.Add(Me.b_remove)
        Me.Controls.Add(Me.b_random)
        Me.Controls.Add(Me.gb_split)
        Me.Controls.Add(Me.b_clear_playlist)
        Me.Controls.Add(Me.b_video_fullscreen)
        Me.Controls.Add(Me.b_fullscreen)
        Me.Controls.Add(Me.lb_playlist)
        Me.Controls.Add(Me.b_close)
        Me.Controls.Add(Me.b_select_directory)
        Me.Controls.Add(Me.b_select_file)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(799, 485)
        Me.Name = "FormOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nothing"
        Me.cms_listbox.ResumeLayout(False)
        Me.cms_listbox.PerformLayout()
        Me.gb_split.ResumeLayout(False)
        Me.gb_split.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.n_save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_select_file As System.Windows.Forms.Button
    Friend WithEvents b_select_directory As System.Windows.Forms.Button
    Friend WithEvents b_close As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lb_playlist As System.Windows.Forms.ListBox
    Friend WithEvents b_fullscreen As System.Windows.Forms.Button
    Friend WithEvents b_video_fullscreen As System.Windows.Forms.Button
    Friend WithEvents b_clear_playlist As System.Windows.Forms.Button
    Friend WithEvents gb_split As System.Windows.Forms.GroupBox
    Friend WithEvents l_split As System.Windows.Forms.Label
    Friend WithEvents cb_split As System.Windows.Forms.ComboBox
    Friend WithEvents b_split_list As System.Windows.Forms.Button
    Friend WithEvents b_random As System.Windows.Forms.Button
    Friend WithEvents b_remove As System.Windows.Forms.Button
    Friend WithEvents b_next_opt As System.Windows.Forms.Button
    Friend WithEvents b_prev_opt As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents n_save As System.Windows.Forms.NumericUpDown
    Friend WithEvents b_save_files As System.Windows.Forms.Button
    Friend WithEvents RenameTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFileTSTB As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents b_delete As System.Windows.Forms.Button
    Friend WithEvents b_skip_time As System.Windows.Forms.Button
    Friend WithEvents b_load_pl As System.Windows.Forms.Button
    Friend WithEvents b_savefolders As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MoveFileTSMI As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cms_listbox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents b_refreshdirs As System.Windows.Forms.Button
    Friend WithEvents l_playlist_count As System.Windows.Forms.Label
    Friend WithEvents RandListTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents b_remover As System.Windows.Forms.Button
    Friend WithEvents r_moveall As System.Windows.Forms.Button
End Class
