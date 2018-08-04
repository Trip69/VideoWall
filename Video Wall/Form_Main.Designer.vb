<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AxVLCPlugin21 = New AxAXVLC.AxVLCPlugin2()
        Me.AxVLCPlugin22 = New AxAXVLC.AxVLCPlugin2()
        Me.AxVLCPlugin23 = New AxAXVLC.AxVLCPlugin2()
        Me.AxVLCPlugin24 = New AxAXVLC.AxVLCPlugin2()
        Me.AxVLCPlugin25 = New AxAXVLC.AxVLCPlugin2()
        Me.AxVLCPlugin26 = New AxAXVLC.AxVLCPlugin2()
        Me.t_checkplaying = New System.Windows.Forms.Timer(Me.components)
        Me.b_options = New System.Windows.Forms.Button()
        Me.b_app_full = New System.Windows.Forms.Button()
        Me.b_forward = New System.Windows.Forms.Button()
        Me.b_big = New System.Windows.Forms.Button()
        Me.b_pause_play = New System.Windows.Forms.Button()
        Me.l_playing = New System.Windows.Forms.Label()
        Me.b_loop = New System.Windows.Forms.Button()
        Me.b_fullscreen = New System.Windows.Forms.Button()
        Me.b_back = New System.Windows.Forms.Button()
        Me.b_bigger = New System.Windows.Forms.Button()
        Me.t_hide_toolbar = New System.Windows.Forms.Timer(Me.components)
        Me.t_check_loop = New System.Windows.Forms.Timer(Me.components)
        Me.gb_hidden = New System.Windows.Forms.GroupBox()
        Me.t_mouse = New System.Windows.Forms.Timer(Me.components)
        Me.b_quit = New System.Windows.Forms.Button()
        Me.tp_controls = New System.Windows.Forms.TableLayoutPanel()
        Me.b_aspect = New System.Windows.Forms.Button()
        Me.cb_change_player = New System.Windows.Forms.ComboBox()
        Me.tt_various = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.AxVLCPlugin21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVLCPlugin22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVLCPlugin23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVLCPlugin24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVLCPlugin25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVLCPlugin26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin21, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin22, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin23, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin24, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin25, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.AxVLCPlugin26, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 730)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'AxVLCPlugin21
        '
        Me.AxVLCPlugin21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin21.Enabled = True
        Me.AxVLCPlugin21.Location = New System.Drawing.Point(0, 0)
        Me.AxVLCPlugin21.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.AxVLCPlugin21.Name = "AxVLCPlugin21"
        Me.AxVLCPlugin21.OcxState = CType(resources.GetObject("AxVLCPlugin21.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin21.Size = New System.Drawing.Size(334, 365)
        Me.AxVLCPlugin21.TabIndex = 16
        '
        'AxVLCPlugin22
        '
        Me.AxVLCPlugin22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin22.Enabled = True
        Me.AxVLCPlugin22.Location = New System.Drawing.Point(335, 0)
        Me.AxVLCPlugin22.Margin = New System.Windows.Forms.Padding(0)
        Me.AxVLCPlugin22.Name = "AxVLCPlugin22"
        Me.AxVLCPlugin22.OcxState = CType(resources.GetObject("AxVLCPlugin22.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin22.Size = New System.Drawing.Size(336, 365)
        Me.AxVLCPlugin22.TabIndex = 17
        '
        'AxVLCPlugin23
        '
        Me.AxVLCPlugin23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin23.Enabled = True
        Me.AxVLCPlugin23.Location = New System.Drawing.Point(672, 0)
        Me.AxVLCPlugin23.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.AxVLCPlugin23.Name = "AxVLCPlugin23"
        Me.AxVLCPlugin23.OcxState = CType(resources.GetObject("AxVLCPlugin23.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin23.Size = New System.Drawing.Size(336, 365)
        Me.AxVLCPlugin23.TabIndex = 18
        '
        'AxVLCPlugin24
        '
        Me.AxVLCPlugin24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin24.Enabled = True
        Me.AxVLCPlugin24.Location = New System.Drawing.Point(0, 366)
        Me.AxVLCPlugin24.Margin = New System.Windows.Forms.Padding(0, 1, 1, 0)
        Me.AxVLCPlugin24.Name = "AxVLCPlugin24"
        Me.AxVLCPlugin24.OcxState = CType(resources.GetObject("AxVLCPlugin24.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin24.Size = New System.Drawing.Size(334, 364)
        Me.AxVLCPlugin24.TabIndex = 19
        '
        'AxVLCPlugin25
        '
        Me.AxVLCPlugin25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin25.Enabled = True
        Me.AxVLCPlugin25.Location = New System.Drawing.Point(335, 366)
        Me.AxVLCPlugin25.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.AxVLCPlugin25.Name = "AxVLCPlugin25"
        Me.AxVLCPlugin25.OcxState = CType(resources.GetObject("AxVLCPlugin25.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin25.Size = New System.Drawing.Size(336, 364)
        Me.AxVLCPlugin25.TabIndex = 20
        '
        'AxVLCPlugin26
        '
        Me.AxVLCPlugin26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxVLCPlugin26.Enabled = True
        Me.AxVLCPlugin26.Location = New System.Drawing.Point(672, 366)
        Me.AxVLCPlugin26.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.AxVLCPlugin26.Name = "AxVLCPlugin26"
        Me.AxVLCPlugin26.OcxState = CType(resources.GetObject("AxVLCPlugin26.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVLCPlugin26.Size = New System.Drawing.Size(336, 364)
        Me.AxVLCPlugin26.TabIndex = 21
        '
        't_checkplaying
        '
        Me.t_checkplaying.Enabled = True
        Me.t_checkplaying.Interval = 2500
        '
        'b_options
        '
        Me.b_options.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_options.Location = New System.Drawing.Point(253, 20)
        Me.b_options.Margin = New System.Windows.Forms.Padding(0)
        Me.b_options.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_options.Name = "b_options"
        Me.b_options.Size = New System.Drawing.Size(36, 21)
        Me.b_options.TabIndex = 5
        Me.b_options.Text = "O"
        Me.tt_various.SetToolTip(Me.b_options, "Options and Playlist")
        Me.b_options.UseVisualStyleBackColor = True
        '
        'b_app_full
        '
        Me.b_app_full.Location = New System.Drawing.Point(1, 0)
        Me.b_app_full.Margin = New System.Windows.Forms.Padding(0)
        Me.b_app_full.Name = "b_app_full"
        Me.b_app_full.Size = New System.Drawing.Size(25, 20)
        Me.b_app_full.TabIndex = 12
        Me.b_app_full.Text = "fs"
        Me.tt_various.SetToolTip(Me.b_app_full, "Application Full Screen")
        Me.b_app_full.UseVisualStyleBackColor = True
        '
        'b_forward
        '
        Me.b_forward.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_forward.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_forward.Location = New System.Drawing.Point(289, 20)
        Me.b_forward.Margin = New System.Windows.Forms.Padding(0)
        Me.b_forward.MinimumSize = New System.Drawing.Size(52, 21)
        Me.b_forward.Name = "b_forward"
        Me.b_forward.Size = New System.Drawing.Size(52, 21)
        Me.b_forward.TabIndex = 0
        Me.b_forward.Text = ">>"
        Me.tt_various.SetToolTip(Me.b_forward, "Next in Playlist")
        Me.b_forward.UseVisualStyleBackColor = True
        '
        'b_big
        '
        Me.b_big.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_big.Location = New System.Drawing.Point(145, 20)
        Me.b_big.Margin = New System.Windows.Forms.Padding(0)
        Me.b_big.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_big.Name = "b_big"
        Me.b_big.Size = New System.Drawing.Size(36, 21)
        Me.b_big.TabIndex = 7
        Me.b_big.Tag = "False"
        Me.b_big.Text = "1x2"
        Me.tt_various.SetToolTip(Me.b_big, "Display Video 1x2")
        Me.b_big.UseVisualStyleBackColor = True
        '
        'b_pause_play
        '
        Me.b_pause_play.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_pause_play.Location = New System.Drawing.Point(37, 20)
        Me.b_pause_play.Margin = New System.Windows.Forms.Padding(0)
        Me.b_pause_play.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_pause_play.Name = "b_pause_play"
        Me.b_pause_play.Size = New System.Drawing.Size(36, 21)
        Me.b_pause_play.TabIndex = 6
        Me.b_pause_play.Tag = "Pause"
        Me.b_pause_play.Text = "P&&P"
        Me.tt_various.SetToolTip(Me.b_pause_play, "Pause and Play")
        Me.b_pause_play.UseVisualStyleBackColor = True
        '
        'l_playing
        '
        Me.l_playing.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l_playing.BackColor = System.Drawing.SystemColors.Control
        Me.tp_controls.SetColumnSpan(Me.l_playing, 7)
        Me.l_playing.ForeColor = System.Drawing.SystemColors.ControlText
        Me.l_playing.Location = New System.Drawing.Point(37, 0)
        Me.l_playing.Margin = New System.Windows.Forms.Padding(0)
        Me.l_playing.Name = "l_playing"
        Me.l_playing.Size = New System.Drawing.Size(252, 20)
        Me.l_playing.TabIndex = 4
        Me.l_playing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'b_loop
        '
        Me.b_loop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_loop.Location = New System.Drawing.Point(73, 20)
        Me.b_loop.Margin = New System.Windows.Forms.Padding(0)
        Me.b_loop.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_loop.Name = "b_loop"
        Me.b_loop.Size = New System.Drawing.Size(36, 21)
        Me.b_loop.TabIndex = 3
        Me.b_loop.Text = "A"
        Me.tt_various.SetToolTip(Me.b_loop, "Loop from A to B")
        Me.b_loop.UseVisualStyleBackColor = True
        '
        'b_fullscreen
        '
        Me.b_fullscreen.AutoSize = True
        Me.b_fullscreen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_fullscreen.Location = New System.Drawing.Point(109, 20)
        Me.b_fullscreen.Margin = New System.Windows.Forms.Padding(0)
        Me.b_fullscreen.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_fullscreen.Name = "b_fullscreen"
        Me.b_fullscreen.Size = New System.Drawing.Size(36, 21)
        Me.b_fullscreen.TabIndex = 2
        Me.b_fullscreen.Text = "Full Screen"
        Me.tt_various.SetToolTip(Me.b_fullscreen, "Full Screen")
        Me.b_fullscreen.UseVisualStyleBackColor = True
        '
        'b_back
        '
        Me.b_back.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_back.Location = New System.Drawing.Point(1, 20)
        Me.b_back.Margin = New System.Windows.Forms.Padding(0)
        Me.b_back.MinimumSize = New System.Drawing.Size(52, 21)
        Me.b_back.Name = "b_back"
        Me.b_back.Size = New System.Drawing.Size(52, 21)
        Me.b_back.TabIndex = 1
        Me.b_back.Text = "<<"
        Me.tt_various.SetToolTip(Me.b_back, "Previous in Playlist")
        Me.b_back.UseVisualStyleBackColor = True
        '
        'b_bigger
        '
        Me.b_bigger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_bigger.Location = New System.Drawing.Point(181, 20)
        Me.b_bigger.Margin = New System.Windows.Forms.Padding(0)
        Me.b_bigger.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_bigger.Name = "b_bigger"
        Me.b_bigger.Size = New System.Drawing.Size(36, 21)
        Me.b_bigger.TabIndex = 9
        Me.b_bigger.Tag = "False"
        Me.b_bigger.Text = "2x2"
        Me.tt_various.SetToolTip(Me.b_bigger, "Display Video 2x2")
        Me.b_bigger.UseVisualStyleBackColor = True
        '
        't_hide_toolbar
        '
        Me.t_hide_toolbar.Enabled = True
        '
        't_check_loop
        '
        Me.t_check_loop.Interval = 1000
        '
        'gb_hidden
        '
        Me.gb_hidden.Location = New System.Drawing.Point(1, 1)
        Me.gb_hidden.Name = "gb_hidden"
        Me.gb_hidden.Size = New System.Drawing.Size(50, 50)
        Me.gb_hidden.TabIndex = 5
        Me.gb_hidden.TabStop = False
        Me.gb_hidden.Text = "Hidden VLC"
        Me.gb_hidden.Visible = False
        '
        't_mouse
        '
        Me.t_mouse.Enabled = True
        Me.t_mouse.Interval = 200
        '
        'b_quit
        '
        Me.b_quit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_quit.BackColor = System.Drawing.Color.Tomato
        Me.b_quit.ForeColor = System.Drawing.Color.White
        Me.b_quit.Location = New System.Drawing.Point(981, 2)
        Me.b_quit.Margin = New System.Windows.Forms.Padding(0)
        Me.b_quit.Name = "b_quit"
        Me.b_quit.Size = New System.Drawing.Size(25, 20)
        Me.b_quit.TabIndex = 6
        Me.b_quit.Text = "?"
        Me.b_quit.UseVisualStyleBackColor = False
        Me.b_quit.Visible = False
        '
        'tp_controls
        '
        Me.tp_controls.ColumnCount = 9
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.tp_controls.Controls.Add(Me.b_aspect, 6, 1)
        Me.tp_controls.Controls.Add(Me.b_bigger, 5, 1)
        Me.tp_controls.Controls.Add(Me.b_app_full, 0, 0)
        Me.tp_controls.Controls.Add(Me.b_big, 4, 1)
        Me.tp_controls.Controls.Add(Me.l_playing, 1, 0)
        Me.tp_controls.Controls.Add(Me.b_pause_play, 1, 1)
        Me.tp_controls.Controls.Add(Me.b_fullscreen, 3, 1)
        Me.tp_controls.Controls.Add(Me.b_loop, 2, 1)
        Me.tp_controls.Controls.Add(Me.b_back, 0, 1)
        Me.tp_controls.Controls.Add(Me.b_options, 7, 1)
        Me.tp_controls.Controls.Add(Me.b_forward, 8, 1)
        Me.tp_controls.Controls.Add(Me.cb_change_player, 4, 0)
        Me.tp_controls.Location = New System.Drawing.Point(0, 295)
        Me.tp_controls.Margin = New System.Windows.Forms.Padding(0)
        Me.tp_controls.Name = "tp_controls"
        Me.tp_controls.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.tp_controls.RowCount = 2
        Me.tp_controls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tp_controls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tp_controls.Size = New System.Drawing.Size(334, 41)
        Me.tp_controls.TabIndex = 7
        '
        'b_aspect
        '
        Me.b_aspect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b_aspect.Location = New System.Drawing.Point(217, 20)
        Me.b_aspect.Margin = New System.Windows.Forms.Padding(0)
        Me.b_aspect.MinimumSize = New System.Drawing.Size(25, 20)
        Me.b_aspect.Name = "b_aspect"
        Me.b_aspect.Size = New System.Drawing.Size(36, 21)
        Me.b_aspect.TabIndex = 8
        Me.b_aspect.Text = "Aspect"
        Me.tt_various.SetToolTip(Me.b_aspect, "Toggle Auto Aspect")
        Me.b_aspect.UseVisualStyleBackColor = True
        '
        'cb_change_player
        '
        Me.cb_change_player.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_change_player.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_change_player.FormattingEnabled = True
        Me.cb_change_player.Location = New System.Drawing.Point(295, 0)
        Me.cb_change_player.Margin = New System.Windows.Forms.Padding(0)
        Me.cb_change_player.Name = "cb_change_player"
        Me.cb_change_player.Size = New System.Drawing.Size(38, 21)
        Me.cb_change_player.TabIndex = 13
        Me.tt_various.SetToolTip(Me.cb_change_player, "Send Video To Player")
        '
        'tt_various
        '
        Me.tt_various.AutomaticDelay = 1000
        '
        'Form_Main
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.b_quit)
        Me.Controls.Add(Me.tp_controls)
        Me.Controls.Add(Me.gb_hidden)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 599)
        Me.Name = "Form_Main"
        Me.Text = "Video Wall v1.2"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.AxVLCPlugin21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVLCPlugin22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVLCPlugin23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVLCPlugin24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVLCPlugin25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVLCPlugin26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_controls.ResumeLayout(False)
        Me.tp_controls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AxVLCPlugin21 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents AxVLCPlugin23 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents AxVLCPlugin24 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents AxVLCPlugin25 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents AxVLCPlugin26 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents t_checkplaying As System.Windows.Forms.Timer
    Friend WithEvents b_back As System.Windows.Forms.Button
    Friend WithEvents b_forward As System.Windows.Forms.Button
    Friend WithEvents t_hide_toolbar As System.Windows.Forms.Timer
    Friend WithEvents b_loop As System.Windows.Forms.Button
    Friend WithEvents b_fullscreen As System.Windows.Forms.Button
    Friend WithEvents t_check_loop As System.Windows.Forms.Timer
    Friend WithEvents l_playing As System.Windows.Forms.Label
    Friend WithEvents b_options As System.Windows.Forms.Button
    Friend WithEvents b_pause_play As System.Windows.Forms.Button
    Friend WithEvents b_big As System.Windows.Forms.Button
    Friend WithEvents AxVLCPlugin22 As AxAXVLC.AxVLCPlugin2
    Friend WithEvents gb_hidden As System.Windows.Forms.GroupBox
    Friend WithEvents b_bigger As System.Windows.Forms.Button
    Friend WithEvents t_mouse As System.Windows.Forms.Timer
    Friend WithEvents b_app_full As System.Windows.Forms.Button
    Friend WithEvents b_quit As System.Windows.Forms.Button
    Friend WithEvents tp_controls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tt_various As System.Windows.Forms.ToolTip
    Friend WithEvents cb_change_player As System.Windows.Forms.ComboBox
    Friend WithEvents b_aspect As System.Windows.Forms.Button

End Class
