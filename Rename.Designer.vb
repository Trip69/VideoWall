<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RenameForm
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
        Me.b_rename = New System.Windows.Forms.Button()
        Me.clb_cats = New System.Windows.Forms.CheckedListBox()
        Me.cb_rating = New System.Windows.Forms.ComboBox()
        Me.b_cancel = New System.Windows.Forms.Button()
        Me.l_filename = New System.Windows.Forms.Label()
        Me.tb_changeto = New System.Windows.Forms.TextBox()
        Me.b_delete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'b_rename
        '
        Me.b_rename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.b_rename.Location = New System.Drawing.Point(212, 251)
        Me.b_rename.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.b_rename.Name = "b_rename"
        Me.b_rename.Size = New System.Drawing.Size(87, 26)
        Me.b_rename.TabIndex = 5
        Me.b_rename.Text = "Rename"
        Me.b_rename.UseVisualStyleBackColor = True
        '
        'clb_cats
        '
        Me.clb_cats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clb_cats.CheckOnClick = True
        Me.clb_cats.ColumnWidth = 70
        Me.clb_cats.FormattingEnabled = True
        Me.clb_cats.Items.AddRange(New Object() {"toedit", "odd", "comp", "pov", "funny", "sm", "-", "amt", "asian", "indian", "teen", "hot", "star", "milf", "-", "blonde", "brun", "redhead", "small tits", "big tits", "-", "solo", "couple", "3 some", "group", "gang", "party", "-", "anal", "les", "dp", "rim", "v and a", "cp", "bj", "-", "girl porn", "ladyboy", "dog", "horse", "animal", "-", "hd", "low res"})
        Me.clb_cats.Location = New System.Drawing.Point(9, 34)
        Me.clb_cats.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.clb_cats.MultiColumn = True
        Me.clb_cats.Name = "clb_cats"
        Me.clb_cats.Size = New System.Drawing.Size(290, 184)
        Me.clb_cats.TabIndex = 4
        '
        'cb_rating
        '
        Me.cb_rating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_rating.FormattingEnabled = True
        Me.cb_rating.Items.AddRange(New Object() {"vvgood", "vgood", "good", "ok", "poor"})
        Me.cb_rating.Location = New System.Drawing.Point(9, 10)
        Me.cb_rating.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cb_rating.Name = "cb_rating"
        Me.cb_rating.Size = New System.Drawing.Size(83, 21)
        Me.cb_rating.TabIndex = 3
        '
        'b_cancel
        '
        Me.b_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.b_cancel.Location = New System.Drawing.Point(9, 251)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(87, 26)
        Me.b_cancel.TabIndex = 6
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = True
        '
        'l_filename
        '
        Me.l_filename.AutoSize = True
        Me.l_filename.Location = New System.Drawing.Point(95, 12)
        Me.l_filename.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.l_filename.Name = "l_filename"
        Me.l_filename.Size = New System.Drawing.Size(39, 13)
        Me.l_filename.TabIndex = 7
        Me.l_filename.Text = "Label1"
        '
        'tb_changeto
        '
        Me.tb_changeto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_changeto.Location = New System.Drawing.Point(9, 222)
        Me.tb_changeto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tb_changeto.Name = "tb_changeto"
        Me.tb_changeto.Size = New System.Drawing.Size(290, 20)
        Me.tb_changeto.TabIndex = 8
        '
        'b_delete
        '
        Me.b_delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.b_delete.Location = New System.Drawing.Point(100, 251)
        Me.b_delete.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.b_delete.Name = "b_delete"
        Me.b_delete.Size = New System.Drawing.Size(87, 26)
        Me.b_delete.TabIndex = 9
        Me.b_delete.Text = "Delete"
        Me.b_delete.UseVisualStyleBackColor = True
        '
        'RenameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 287)
        Me.Controls.Add(Me.b_delete)
        Me.Controls.Add(Me.tb_changeto)
        Me.Controls.Add(Me.l_filename)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_rename)
        Me.Controls.Add(Me.clb_cats)
        Me.Controls.Add(Me.cb_rating)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "RenameForm"
        Me.Text = "Rename"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_rename As System.Windows.Forms.Button
    Friend WithEvents clb_cats As System.Windows.Forms.CheckedListBox
    Friend WithEvents cb_rating As System.Windows.Forms.ComboBox
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents l_filename As System.Windows.Forms.Label
    Friend WithEvents tb_changeto As System.Windows.Forms.TextBox
    Friend WithEvents b_delete As System.Windows.Forms.Button
End Class
