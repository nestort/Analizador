Public Class IU
    Dim tipo, estact As Integer
    Dim tipos As Integer
    Dim token As String
    Dim palabra As String
    Dim sig As Integer
    Dim numerotoken As New ArrayList  ' los array donde se van a guardar los tokens con su respectivo numero
    Dim lexema As New ArrayList
    Dim ubicacion As String

    

   

    Private Sub analizar()


        token = "" 'TOKEN ES LA PALABRA QUE CONCATENA LOS CARACTERES SEGUN LO QUE VENGA
        Dim estado As Integer = 0 'ESTADOS ES LA VARIABLE QUE INDICA A QUE ESTADO IR
        Dim numtoken As Integer ' ASIGNA UN NUMERO DE TOKEN CUANDO SE TENGA UN TOKEN COMPLETADO
        Dim arr() As String = TextBox1.Text.Split(ChrW(10)) ' SEPARA LO QUE HAY EN EL TXT POR LINEAS

        Dim IndiceCadena, IndiceCaracter As Integer '
        For IndiceCadena = 0 To arr.Length - 1  ' CICLO QUE VA DE 0 HASTA LA ULTIMA LINEA
            For IndiceCaracter = 0 To Len(arr(IndiceCadena)) - 1  'CICLO QUE VA DE 0 HASTA EL ULTIMO CARACTER DE LA LINEA



                Dim c, d As String

                c = Asc(arr(IndiceCadena).Chars(IndiceCaracter)) ' C ALMACENA EL VALOR ASCII DEL CARACTER QUE VIENE, HACIENDOLO DESDE 0 HASTA EL ULTIMO
                'CARACTER DE LA LINEA

                If (estado = 0) Then ' EVALUA SI ESTAMOS EN EL ESTADIO 0
                    estado = CalcFuncion(c) ' SI ES ASI ESTADIOS ALMACENA EL VALOR QUE DEVULVE LA FUNCION ESTADO AL APLICARSELA A C
                End If

                Try
                    d = Asc(arr(IndiceCadena).Chars(IndiceCaracter + 1)) ' LEE EL CARACTER SIGUIENTE PARA VER QUE ESTADO TOMAR
                Catch
                    d = -4 ' ESTO ES POR SI ESTAMOS EN LA ULTIMA POSICION DEL VECTOR Y NO TIRE ERROR
                    'y tiene un valor arbitrario

                End Try

                sig = d 'ASIGNACION DE SIG = D

                'EMPIEZAN LAS TRANSICIONES

                Select Case estado

                    Case 1 ' SI ESTOY EN EL ESTADO 1 CONCATENO LO QUE VENGA
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter) ' CONCATENACION DONDE ARR(NN).CHARS(MM) ES EL CARACTER QUE SE ESTA LEYENDO
                        If (sig > 64 And sig < 92) Or (sig > 96 And sig < 123) Or (sig < 58 And sig > 47) Then ' SI VIENE LETRA O NUMERO
                            estado = 1 'PASO AL ESTADO 1 
                        Else
                            estado = 0 ' COMO ES ESTADO DE ACEPTACION, SE ACEPTA LO QUE TIENE LA VARIABLE TOKEN
                            numtoken = 1 'SE ASIGNA UN NUMERO ARBITRARIO PARA IDENTIFAR EL TIPO DE TOKEN Q SE RECONOCIO
                        End If


                    Case 2 ' SI ESTOY EN EL ESTADO 2
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter) ' CONCATENO LO QUE VIENE
                        If (sig < 58 And sig > 47) Then ' SI VIENE NUMERO
                            estado = 2 ' PASO AL ESTADO 2
                        ElseIf (sig = 46) Then ' SI VIENE PUNTO

                            estado = 3 ' PASO AL ESTADO 4
                        Else ' SI VIENE CUALQUIER OTRA COSA
                            estado = 0 ' ACEPTO LO QUE TIENE LA VAR TOKEN
                            numtoken = 2 'ASIGNO EL NUMERO 2 PARA RECONOCER ENTEROS
                        End If


                    Case 3 'ESTADO 3
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter)
                        If (sig < 58 And sig > 47) Then ' SI VIENE NUMERO PASO A 4
                            estado = 4
                        Else ' SINO ME VOY AL ESTADO -1 QUE ES ESTADO DE ERROR
                            estado = -1
                        End If
                    Case 4 ' SI ESTOY EN EL ESTADO 5
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter) ' CONCATENO
                        If (sig < 58 And sig > 47) Then 'SI VIENE NUMERO
                            estado = 4 ' ME QUEDO EN 4
                        Else
                            estado = 0 ' ACEPTO LO QUE TIENE TOKEN
                            numtoken = 3 'ASIGNO NUMERO de token
                        End If
                    Case 5 ' SI ESTOY EN EL ESTADO 5
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter) ' CONCATENO
                        
                            estado = 0 ' ACEPTO LO QUE TIENE TOKEN
                        numtoken = 4 'ASIGNO NUMERO de token




                    Case 100  'CASE 1O0 ES PORQUE SI LA FUNCION ESTADO NOS DUVUELVE 1O ES PORQUE VENIA UN CARACTER
                        'QUE SE DEBIA IGNORAR
                        estado = -2 ' PASA A ESTADO -2

                    Case -1 ' SI ESTOY EN ESTADO -1
                        token = token + arr(IndiceCadena).Chars(IndiceCaracter) ' CONCATENO LO QUE HAY
                        numtoken = 10 ' ASIGNO UN NUMERO DE TOKEN

                        estado = 0 ' ACEPTO


                End Select


                '_____________________________________________________________________________

                If estado = 0 Then
                    numerotoken.Add(numtoken)
                    lexema.Add(token)
                    token = ""



                ElseIf estado = -2 Then
                    estado = 0

                ElseIf estado = -1 Then
                    numerotoken.Add(10)
                    lexema.Add(token)
                    token = ""

                ElseIf (sig = -3) Then
                    If estado <> 0 Then
                        numerotoken.Add(-1)
                        lexema.Add(token)


                    End If
                End If


                '_________________________________________________________________________________________________

            Next ' FIN DEL CICLO QUE LEE LOS CARACTERES


        Next ' FIN DEL CICLO QUE LEE LAS LINEAS 

        For ii = 0 To numerotoken.Count - 1 ' CILCLO PARA ANADIR LA LOS LISTBOX LOS TOKEENS


            If (numerotoken(ii) = 1) Then 'SI MI NUMERO DE TOKEN ES 1 ENTONCES ES UN IDENTIFICADOR




                If lexema(ii).Equals("elevar") Or lexema(ii).Equals("descender") Or lexema(ii).Equals("avanzar") Or lexema(ii).Equals("retroceder") Or lexema(ii).Equals("girar") Then
                    ListBox2.Items.Add("Palabra reservada" & "  " & lexema(ii))


                Else
                    ListBox2.Items.Add("identificador" & "  " & lexema(ii))
                End If


            ElseIf (numerotoken(ii) = 10) And (lexema(ii) <> ChrW(13)) And (lexema(ii) <> ChrW(10)) Then
                ListBox1.Items.Add("error" & "  " & lexema(ii))


            ElseIf (numerotoken(ii) = 3) Then
                ListBox2.Items.Add("Decimal" & "  " & lexema(ii))

            ElseIf (numerotoken(ii) = 2) Then
                ListBox2.Items.Add("Entero" & "  " & lexema(ii))
            ElseIf (numerotoken(ii) = 4) Then
                ListBox2.Items.Add("Simbolo especial" & "  " & lexema(ii))


            End If


        Next


    End Sub
    Private Function CalcFuncion(ByVal n As Integer) As Integer

        If (n > 64 And n < 91) Or (n > 96 And n < 123) Then ' POR EJEMPLO SI VIENE UNA LETRA
            Return 1 'RETORNA 1 LO QUE QUIERE DECIR QUE CON UNA LETRA ME VOY DEL ESTADO 0 AL ESTADO 1

        ElseIf (n < 58 And n > 47) Then ' SI VIENE UN NUMERO CUANDO ESTOY EN EL ESTADO CERO

            Return 2 ' ME VOY AL ESTADO 2

        ElseIf ((n = 40) Or (n = 41) Or (n = 59)) Then ' SI VIENE PARENTESIS PUNTO Y COMA

            Return 5 ' ME VOY AL ESTADO 2



        ElseIf (n = 32) Or (n = 9) Then ' SI VIENE tab o espacio en blanco

            Return 100 ' ME VOY AL ESTADO 100
        Else
            Return -1 ' SI VIENE CUALQUIER OTRA COSA DIFERENTE ME VOYA ERROR
        End If
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        numerotoken = New ArrayList  ' los array donde se van a guardar los tokens con su respectivo numero
        lexema = New ArrayList

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        analizar()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        numerotoken = New ArrayList  ' los array donde se van a guardar los tokens con su respectivo numero
        lexema = New ArrayList

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        analizar()
        controlteclado.Show()
        
        AnalisisSintactico()
    End Sub
    Public Sub AnalisisSintactico()
        Dim i As Integer = 0
        For Each num In lexema
            If num.ToString = "avanzar" Then
                Try
                    If (lexema(i + 3) <> ")") And lexema(i + 4) <> ";" Then
                        ListBox1.Items.Add("Hace falta ) o ;")
                    End If
                    For index As Integer = 1 To lexema(i + 2)
                        controlteclado.AccionTecla(Keys.Left)
                        'System.Threading.Thread.Sleep(10)
                        'MsgBox(num.ToString + numerotoken(i).ToString)
                    Next
                Catch ex As Exception
                    ListBox1.Items.Add("Revise su expresion => expresio(valor);")
                End Try

            End If
            If num.ToString = "retroceder" Then
                For index As Integer = 1 To 8
                    controlteclado.AccionTecla(Keys.Right)
                    'MsgBox(num.ToString + numerotoken(i).ToString)
                Next

            End If
            If num.ToString = "girar" Then
                For index As Integer = 1 To 1
                    controlteclado.AccionTecla(Keys.D1)
                    'MsgBox(num.ToString + numerotoken(i).ToString)
                Next

            End If
            'MsgBox(num.ToString + numerotoken(i).ToString)
            i = i + 1
        Next


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        controlteclado.Show()

    End Sub

    Private Sub bttlimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttlimpiar.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        TextBox1.Text = ""
        controlteclado.Close()
    End Sub

    Private Sub IU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'controlteclado.Show()
    End Sub
End Class