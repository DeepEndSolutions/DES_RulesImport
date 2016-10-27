<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnImport = New System.Windows.Forms.Button()
        Me.pbImportProgress = New System.Windows.Forms.ProgressBar()
        Me.txtInputFile = New System.Windows.Forms.TextBox()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.btnInputFile = New System.Windows.Forms.Button()
        Me.lblOutputFile = New System.Windows.Forms.Label()
        Me.txtOutputFile = New System.Windows.Forms.TextBox()
        Me.btnOutputFile = New System.Windows.Forms.Button()
        Me.lblProgressBar = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(94, 151)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 38)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'pbImportProgress
        '
        Me.pbImportProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImportProgress.Location = New System.Drawing.Point(13, 227)
        Me.pbImportProgress.Name = "pbImportProgress"
        Me.pbImportProgress.Size = New System.Drawing.Size(305, 23)
        Me.pbImportProgress.TabIndex = 1
        '
        'txtInputFile
        '
        Me.txtInputFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputFile.Location = New System.Drawing.Point(13, 48)
        Me.txtInputFile.Name = "txtInputFile"
        Me.txtInputFile.Size = New System.Drawing.Size(280, 20)
        Me.txtInputFile.TabIndex = 2
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Location = New System.Drawing.Point(13, 29)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(47, 13)
        Me.lblInput.TabIndex = 3
        Me.lblInput.Text = "Input file"
        '
        'btnInputFile
        '
        Me.btnInputFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInputFile.Location = New System.Drawing.Point(299, 46)
        Me.btnInputFile.Name = "btnInputFile"
        Me.btnInputFile.Size = New System.Drawing.Size(28, 23)
        Me.btnInputFile.TabIndex = 4
        Me.btnInputFile.Text = "..."
        Me.btnInputFile.UseVisualStyleBackColor = True
        '
        'lblOutputFile
        '
        Me.lblOutputFile.AutoSize = True
        Me.lblOutputFile.Location = New System.Drawing.Point(13, 83)
        Me.lblOutputFile.Name = "lblOutputFile"
        Me.lblOutputFile.Size = New System.Drawing.Size(55, 13)
        Me.lblOutputFile.TabIndex = 6
        Me.lblOutputFile.Text = "Output file"
        '
        'txtOutputFile
        '
        Me.txtOutputFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutputFile.Location = New System.Drawing.Point(13, 102)
        Me.txtOutputFile.Name = "txtOutputFile"
        Me.txtOutputFile.Size = New System.Drawing.Size(280, 20)
        Me.txtOutputFile.TabIndex = 5
        '
        'btnOutputFile
        '
        Me.btnOutputFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOutputFile.Location = New System.Drawing.Point(299, 100)
        Me.btnOutputFile.Name = "btnOutputFile"
        Me.btnOutputFile.Size = New System.Drawing.Size(28, 23)
        Me.btnOutputFile.TabIndex = 7
        Me.btnOutputFile.Text = "..."
        Me.btnOutputFile.UseVisualStyleBackColor = True
        '
        'lblProgressBar
        '
        Me.lblProgressBar.AutoSize = True
        Me.lblProgressBar.Location = New System.Drawing.Point(13, 211)
        Me.lblProgressBar.Name = "lblProgressBar"
        Me.lblProgressBar.Size = New System.Drawing.Size(116, 13)
        Me.lblProgressBar.TabIndex = 8
        Me.lblProgressBar.Text = "Click Import to Begin...."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 262)
        Me.Controls.Add(Me.lblProgressBar)
        Me.Controls.Add(Me.btnOutputFile)
        Me.Controls.Add(Me.lblOutputFile)
        Me.Controls.Add(Me.txtOutputFile)
        Me.Controls.Add(Me.btnInputFile)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.txtInputFile)
        Me.Controls.Add(Me.pbImportProgress)
        Me.Controls.Add(Me.btnImport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rules Import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImport As Button
    Friend WithEvents pbImportProgress As ProgressBar
    Friend WithEvents txtInputFile As TextBox
    Friend WithEvents lblInput As Label
    Friend WithEvents btnInputFile As Button
    Friend WithEvents lblOutputFile As Label
    Friend WithEvents txtOutputFile As TextBox
    Friend WithEvents btnOutputFile As Button
    Friend WithEvents lblProgressBar As Label
End Class
