<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class controlteclado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controlteclado))
        Me.gancho = New System.Windows.Forms.PictureBox()
        Me.grua = New System.Windows.Forms.PictureBox()
        Me.vistaaerea = New System.Windows.Forms.PictureBox()
        Me.gradosLB = New System.Windows.Forms.Label()
        CType(Me.gancho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vistaaerea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gancho
        '
        Me.gancho.BackColor = System.Drawing.Color.Transparent
        Me.gancho.BackgroundImage = CType(resources.GetObject("gancho.BackgroundImage"), System.Drawing.Image)
        Me.gancho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.gancho.Location = New System.Drawing.Point(54, 147)
        Me.gancho.Name = "gancho"
        Me.gancho.Size = New System.Drawing.Size(25, 212)
        Me.gancho.TabIndex = 1
        Me.gancho.TabStop = False
        '
        'grua
        '
        Me.grua.BackColor = System.Drawing.Color.Transparent
        Me.grua.BackgroundImage = CType(resources.GetObject("grua.BackgroundImage"), System.Drawing.Image)
        Me.grua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.grua.Location = New System.Drawing.Point(12, 21)
        Me.grua.Name = "grua"
        Me.grua.Size = New System.Drawing.Size(419, 336)
        Me.grua.TabIndex = 0
        Me.grua.TabStop = False
        '
        'vistaaerea
        '
        Me.vistaaerea.BackColor = System.Drawing.Color.Transparent
        Me.vistaaerea.BackgroundImage = Global.Lexico1.My.Resources.Resources.arriba1
        Me.vistaaerea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.vistaaerea.Location = New System.Drawing.Point(466, 44)
        Me.vistaaerea.Name = "vistaaerea"
        Me.vistaaerea.Size = New System.Drawing.Size(94, 90)
        Me.vistaaerea.TabIndex = 2
        Me.vistaaerea.TabStop = False
        '
        'gradosLB
        '
        Me.gradosLB.AutoSize = True
        Me.gradosLB.BackColor = System.Drawing.Color.Transparent
        Me.gradosLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gradosLB.Location = New System.Drawing.Point(489, 9)
        Me.gradosLB.Name = "gradosLB"
        Me.gradosLB.Size = New System.Drawing.Size(48, 37)
        Me.gradosLB.TabIndex = 3
        Me.gradosLB.Text = "0°"
        '
        'controlteclado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Lexico1.My.Resources.Resources.h
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(605, 360)
        Me.Controls.Add(Me.gradosLB)
        Me.Controls.Add(Me.vistaaerea)
        Me.Controls.Add(Me.gancho)
        Me.Controls.Add(Me.grua)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(650, 200)
        Me.Name = "controlteclado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "control "
        CType(Me.gancho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vistaaerea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grua As System.Windows.Forms.PictureBox
    Friend WithEvents gancho As System.Windows.Forms.PictureBox
    Friend WithEvents vistaaerea As System.Windows.Forms.PictureBox
    Friend WithEvents gradosLB As System.Windows.Forms.Label
End Class
