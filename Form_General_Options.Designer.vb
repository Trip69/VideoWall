<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_General_Options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cb_auto_aspect = New System.Windows.Forms.CheckBox()
        Me.b_clearpl = New System.Windows.Forms.Button()
        Me.gb_dd_split_play = New System.Windows.Forms.GroupBox()
        Me.cb_search = New System.Windows.Forms.ComboBox()
        Me.cb_only_these = New System.Windows.Forms.CheckBox()
        Me.cb_rating_filter = New System.Windows.Forms.ComboBox()
        Me.tb_dd_split_play = New System.Windows.Forms.TextBox()
        Me.b_double_mon = New System.Windows.Forms.Button()
        Me.b_jump = New System.Windows.Forms.Button()
        Me.gb_dd_split_play.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_auto_aspect
        '
        Me.cb_auto_aspect.AutoSize = True
        Me.cb_auto_aspect.Location = New System.Drawing.Point(12, 12)
        Me.cb_auto_aspect.Name = "cb_auto_aspect"
        Me.cb_auto_aspect.Size = New System.Drawing.Size(84, 17)
        Me.cb_auto_aspect.TabIndex = 0
        Me.cb_auto_aspect.Text = "Auto Aspect"
        Me.cb_auto_aspect.UseVisualStyleBackColor = True
        '
        'b_clearpl
        '
        Me.b_clearpl.Location = New System.Drawing.Point(12, 35)
        Me.b_clearpl.Name = "b_clearpl"
        Me.b_clearpl.Size = New System.Drawing.Size(84, 23)
        Me.b_clearpl.TabIndex = 1
        Me.b_clearpl.Text = "Clear Playlists"
        Me.b_clearpl.UseVisualStyleBackColor = True
        '
        'gb_dd_split_play
        '
        Me.gb_dd_split_play.Controls.Add(Me.cb_search)
        Me.gb_dd_split_play.Controls.Add(Me.cb_only_these)
        Me.gb_dd_split_play.Controls.Add(Me.cb_rating_filter)
        Me.gb_dd_split_play.Controls.Add(Me.tb_dd_split_play)
        Me.gb_dd_split_play.Location = New System.Drawing.Point(102, 12)
        Me.gb_dd_split_play.Name = "gb_dd_split_play"
        Me.gb_dd_split_play.Size = New System.Drawing.Size(84, 120)
        Me.gb_dd_split_play.TabIndex = 2
        Me.gb_dd_split_play.TabStop = False
        Me.gb_dd_split_play.Text = "DD Split Play"
        '
        'cb_search
        '
        Me.cb_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_search.FormattingEnabled = True
        Me.cb_search.Location = New System.Drawing.Point(6, 46)
        Me.cb_search.Name = "cb_search"
        Me.cb_search.Size = New System.Drawing.Size(72, 21)
        Me.cb_search.TabIndex = 3
        '
        'cb_only_these
        '
        Me.cb_only_these.AutoSize = True
        Me.cb_only_these.Location = New System.Drawing.Point(6, 71)
        Me.cb_only_these.Name = "cb_only_these"
        Me.cb_only_these.Size = New System.Drawing.Size(47, 17)
        Me.cb_only_these.TabIndex = 2
        Me.cb_only_these.Text = "Only"
        Me.cb_only_these.UseVisualStyleBackColor = True
        '
        'cb_rating_filter
        '
        Me.cb_rating_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_rating_filter.FormattingEnabled = True
        Me.cb_rating_filter.Items.AddRange(New Object() {"vvgood", "vgood", "good", "ok", "poor", "unrated", "all"})
        Me.cb_rating_filter.Location = New System.Drawing.Point(6, 19)
        Me.cb_rating_filter.Name = "cb_rating_filter"
        Me.cb_rating_filter.Size = New System.Drawing.Size(72, 21)
        Me.cb_rating_filter.TabIndex = 1
        '
        'tb_dd_split_play
        '
        Me.tb_dd_split_play.AllowDrop = True
        Me.tb_dd_split_play.Location = New System.Drawing.Point(6, 94)
        Me.tb_dd_split_play.Name = "tb_dd_split_play"
        Me.tb_dd_split_play.ReadOnly = True
        Me.tb_dd_split_play.Size = New System.Drawing.Size(72, 20)
        Me.tb_dd_split_play.TabIndex = 0
        Me.tb_dd_split_play.Text = "Drop Here"
        Me.tb_dd_split_play.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'b_double_mon
        '
        Me.b_double_mon.Location = New System.Drawing.Point(12, 64)
        Me.b_double_mon.Name = "b_double_mon"
        Me.b_double_mon.Size = New System.Drawing.Size(84, 23)
        Me.b_double_mon.TabIndex = 3
        Me.b_double_mon.Text = "2x Monitor"
        Me.b_double_mon.UseVisualStyleBackColor = True
        '
        'b_jump
        '
        Me.b_jump.Location = New System.Drawing.Point(12, 93)
        Me.b_jump.Name = "b_jump"
        Me.b_jump.Size = New System.Drawing.Size(84, 23)
        Me.b_jump.TabIndex = 4
        Me.b_jump.Text = "Jump"
        Me.b_jump.UseVisualStyleBackColor = True
        '
        'Form_General_Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 144)
        Me.Controls.Add(Me.b_jump)
        Me.Controls.Add(Me.b_double_mon)
        Me.Controls.Add(Me.gb_dd_split_play)
        Me.Controls.Add(Me.b_clearpl)
        Me.Controls.Add(Me.cb_auto_aspect)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_General_Options"
        Me.Text = "Options"
        Me.gb_dd_split_play.ResumeLayout(False)
        Me.gb_dd_split_play.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_auto_aspect As System.Windows.Forms.CheckBox
    Friend WithEvents b_clearpl As System.Windows.Forms.Button
    Friend WithEvents gb_dd_split_play As System.Windows.Forms.GroupBox
    Friend WithEvents tb_dd_split_play As System.Windows.Forms.TextBox
    Friend WithEvents cb_rating_filter As System.Windows.Forms.ComboBox
    Friend WithEvents b_double_mon As System.Windows.Forms.Button
    Friend WithEvents cb_only_these As System.Windows.Forms.CheckBox
    Friend WithEvents cb_search As System.Windows.Forms.ComboBox
    Friend WithEvents b_jump As System.Windows.Forms.Button
End Class
