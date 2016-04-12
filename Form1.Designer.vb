<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CB_Process = New System.Windows.Forms.ComboBox()
        Me.Btn_Help = New System.Windows.Forms.Button()
        Me.CbB_Mode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbB_Preset = New System.Windows.Forms.ComboBox()
        Me.Btn_Refresh = New System.Windows.Forms.Button()
        Me.C_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Key = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.C_Delay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToOrderColumns = True
        Me.DGV.AllowUserToResizeRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_Name, Me.C_Key, Me.C_Delay})
        Me.DGV.Location = New System.Drawing.Point(12, 13)
        Me.DGV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RowTemplate.Height = 23
        Me.DGV.Size = New System.Drawing.Size(378, 349)
        Me.DGV.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(396, 108)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 104)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(454, 296)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 66)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(396, 220)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Move Up"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(396, 258)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(149, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Move Down"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CB_Process
        '
        Me.CB_Process.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Process.FormattingEnabled = True
        Me.CB_Process.Location = New System.Drawing.Point(396, 13)
        Me.CB_Process.Name = "CB_Process"
        Me.CB_Process.Size = New System.Drawing.Size(118, 25)
        Me.CB_Process.TabIndex = 5
        '
        'Btn_Help
        '
        Me.Btn_Help.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Help.Location = New System.Drawing.Point(396, 296)
        Me.Btn_Help.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Help.Name = "Btn_Help"
        Me.Btn_Help.Size = New System.Drawing.Size(52, 66)
        Me.Btn_Help.TabIndex = 7
        Me.Btn_Help.Text = "Help"
        Me.Btn_Help.UseVisualStyleBackColor = True
        '
        'CbB_Mode
        '
        Me.CbB_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbB_Mode.FormattingEnabled = True
        Me.CbB_Mode.Items.AddRange(New Object() {"Automatic", "Manual", "Automatic (v2)", "Manual (v2)"})
        Me.CbB_Mode.Location = New System.Drawing.Point(442, 44)
        Me.CbB_Mode.Name = "CbB_Mode"
        Me.CbB_Mode.Size = New System.Drawing.Size(103, 25)
        Me.CbB_Mode.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(393, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Mode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Preset"
        '
        'CbB_Preset
        '
        Me.CbB_Preset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbB_Preset.FormattingEnabled = True
        Me.CbB_Preset.Items.AddRange(New Object() {"* Save", "* Delete"})
        Me.CbB_Preset.Location = New System.Drawing.Point(443, 75)
        Me.CbB_Preset.Name = "CbB_Preset"
        Me.CbB_Preset.Size = New System.Drawing.Size(102, 25)
        Me.CbB_Preset.TabIndex = 11
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Refresh.Image = Global.Key_Sequence_Generator.My.Resources.Resources.refresh
        Me.Btn_Refresh.Location = New System.Drawing.Point(520, 13)
        Me.Btn_Refresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(25, 25)
        Me.Btn_Refresh.TabIndex = 6
        Me.Btn_Refresh.UseVisualStyleBackColor = True
        '
        'C_Name
        '
        Me.C_Name.HeaderText = "Name (Opt)"
        Me.C_Name.Name = "C_Name"
        Me.C_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'C_Key
        '
        Me.C_Key.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.C_Key.HeaderText = "Key"
        Me.C_Key.Name = "C_Key"
        '
        'C_Delay
        '
        Me.C_Delay.HeaderText = "Delay (ms)"
        Me.C_Delay.Name = "C_Delay"
        Me.C_Delay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Form1
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 375)
        Me.Controls.Add(Me.CbB_Preset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbB_Mode)
        Me.Controls.Add(Me.Btn_Help)
        Me.Controls.Add(Me.Btn_Refresh)
        Me.Controls.Add(Me.CB_Process)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Key Sequence Generator"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CB_Process As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Refresh As System.Windows.Forms.Button
    Friend WithEvents Btn_Help As System.Windows.Forms.Button
    Friend WithEvents CbB_Mode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CbB_Preset As System.Windows.Forms.ComboBox
    Friend WithEvents C_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents C_Key As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents C_Delay As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
