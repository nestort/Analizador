Public Class controlteclado

    
    Public posganchoY As Integer = 0
    Public posganchoX As Integer = 223
    'Dimensiones PosA
    Public posIniPosA As Integer = 223
    Public posFinPosA As Integer = 41
    'Dimesiones PosB
    Public posIniPosB As Integer = 188
    Public posFinPosB As Integer = 370

    'grados giro
    Public grados As Integer = 0

    Public orientacion As String = "PosA"
    Dim giro() As Image = {My.Resources.grua_completaA, My.Resources.grua_completaB}
    Dim imgs() As Image = {My.Resources.gancho1, My.Resources.gancho2, My.Resources.gancho3,
                           My.Resources.gancho4, My.Resources.gancho5, My.Resources.gancho6,
                           My.Resources.gancho7, My.Resources.gancho8, My.Resources.gancho9,
                           My.Resources.gancho10, My.Resources.gancho11, My.Resources.gancho12,
                           My.Resources.gancho13, My.Resources.gancho14, My.Resources.gancho15,
                           My.Resources.gancho16, My.Resources.gancho17, My.Resources.gancho18,
                           My.Resources.gancho19, My.Resources.gancho20, My.Resources.gancho21,
                           My.Resources.gancho22, My.Resources.gancho23
                           }

    Public Sub AccionTecla(ByVal key As Integer)
        If key = Keys.D1 Then
            ' MsgBox("nombre " + gancho.BackgroundImage()=Resources.
            If (grados = 360) Then
                grados = 0
            End If
            grados = grados + 5
            gradosLB.Text = grados.ToString + "°"
            vistaaerearefresh()


        End If

        If key = Keys.Down Then

            If posganchoY >= 0 And posganchoY < 22 Then
                posganchoY = posganchoY + 1
                gancho.BackgroundImage = imgs(posganchoY)
            End If

        End If
        If key = Keys.Up Then
            If posganchoY > 0 And posganchoY <= 22 Then
                posganchoY = posganchoY - 1
                gancho.BackgroundImage = imgs(posganchoY)
            End If
        End If





        If key = Keys.Left Then

            If posganchoX > posFinPosA And posganchoX <= posIniPosA And orientacion.Equals("PosA") Then
                posganchoX = gancho.Left - 1
                gancho.Left = posganchoX

            ElseIf posganchoX > posIniPosB And posganchoX <= posFinPosB And orientacion.Equals("PosB") Then
                posganchoX = gancho.Left - 1
                gancho.Left = posganchoX
            End If

        End If

        If key = Keys.Right Then

            If posganchoX >= posFinPosA And posganchoX < posIniPosA And orientacion.Equals("PosA") Then
                posganchoX = gancho.Left + 1
                gancho.Left = posganchoX
            ElseIf posganchoX >= posIniPosB And posganchoX < posFinPosB And orientacion.Equals("PosB") Then
                posganchoX = gancho.Left + 1
                gancho.Left = posganchoX

            End If
        End If
        If key = Keys.G Then


        End If

    End Sub


    Private Sub controlteclado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.fondo, AudioPlayMode.BackgroundLoop)
        gancho.Left = posIniPosA
    End Sub

    Private Sub controlteclado_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        My.Computer.Audio.Stop()
    End Sub

    Private Sub giro180()
        If orientacion.Equals("PosA") Then
            grua.BackgroundImage = giro(1)
            orientacion = "PosB"

            posganchoX = posIniPosB + (posIniPosA - gancho.Left)
            gancho.Left = posganchoX

        Else
            grua.BackgroundImage = giro(0)
            orientacion = "PosA"

            posganchoX = posIniPosA - (gancho.Left - posIniPosB)
            gancho.Left = posganchoX
        End If
    End Sub

    Private Sub vistaaerearefresh()
        If grados = 0 Then
            vistaaerea.BackgroundImage = My.Resources.arriba1
        ElseIf grados = 45 Then
            vistaaerea.BackgroundImage = My.Resources.arriba2
        ElseIf grados = 90 Then
            vistaaerea.BackgroundImage = My.Resources.arriba3
        ElseIf grados = 135 Then
            vistaaerea.BackgroundImage = My.Resources.arriba4
        ElseIf grados = 180 Then
            vistaaerea.BackgroundImage = My.Resources.arriba5
            giro180()
        ElseIf grados = 225 Then
            vistaaerea.BackgroundImage = My.Resources.arriba6
        ElseIf grados = 270 Then
            vistaaerea.BackgroundImage = My.Resources.arriba7
        ElseIf grados = 315 Then
            vistaaerea.BackgroundImage = My.Resources.arriba8
        ElseIf grados = 360 Then
            vistaaerea.BackgroundImage = My.Resources.arriba1
            giro180()

        End If
    End Sub

    Private Sub controlteclado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        AccionTecla(e.KeyCode)
        
    End Sub


End Class