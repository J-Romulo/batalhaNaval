Public Module MapaController
    Public Function criarMapa(largura As Integer, altura As Integer, qntdNavios As Integer)
        Dim mapaCriado As New Mapa(altura, largura, qntdNavios)

        Return mapaCriado
    End Function

    Public Function setarJogada(mapa As Mapa, posicaoY As Integer, posicaoX As Integer, tipoNavio As Integer)
        If mapa.Item(posicaoY, posicaoX) <> 0 Then
            '''se ja tiver marcado a posição no array, significa que ja houve jogada nessa posicao
            Return False
        Else
            '''1 = Submarino / 2 = Hiate ...
            mapa.Item(posicaoY, posicaoX) = tipoNavio + 1
            Return True
        End If
    End Function

    Public Function setarEmbarcacao(mapa As Mapa, navio As Navio)
        Return mapa.setNavio(navio)
    End Function

    Public Function fazerJogada(mapa As Mapa, posicaoY As Integer, posicaoX As Integer)
        If mapa.Item(posicaoY, posicaoX) <> 0 And mapa.Item(posicaoY, posicaoX) <> 6 Then
            '''7 no mapa = posicao navio ja jogada
            mapa.Item(posicaoY, posicaoX) = 6

            If destruirNavio(mapa, posicaoY, posicaoX) = True Then
                '''2 = acertou e acabou o jogo
                Return 2
            Else
                '''1 = acertou mas nao acabou o jogo
                Return 1
            End If

        ElseIf mapa.Item(posicaoY, posicaoX) = 0 Then
            '''7 no mapa = posicao agua ja jogada
            mapa.Item(posicaoY, posicaoX) = 7

            '''0 = agua
            Return 0
        ElseIf mapa.Item(posicaoY, posicaoX) = 6 Or mapa.Item(posicaoY, posicaoX) = 7 Then

            '''-1 = refazer jogada
            Return -1
        End If
    End Function

    Public Function destruirNavio(mapa As Mapa, posicaoY As Integer, posicaoX As Integer)
        Dim qntdNavios = mapa.getNaviosLength
        Dim naviosDestruidos = 0

        For i = 0 To qntdNavios
            Dim navio As Navio = mapa.getNavio(i)
            Dim qntdPosicoesNavio As Integer = navio.getQntdCasas

            If checkNavioDestruido(navio, qntdPosicoesNavio) = False Then
                For j = 0 To qntdPosicoesNavio - 1
                    Dim coordenadasPosicao = navio.getPosicao(j)

                    If coordenadasPosicao(0) = posicaoY And coordenadasPosicao(1) = posicaoX Then
                        navio.setPosicao(-1, -1, j)
                    End If

                Next
            End If

            If checkNavioDestruido(navio, qntdPosicoesNavio) = True Then
                naviosDestruidos += 1
            End If
        Next

        If naviosDestruidos = (qntdNavios + 1) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function checkNavioDestruido(navio As Navio, qntdPosicoes As Integer)
        Dim casasDestruidas = 0

        For i = 0 To qntdPosicoes - 1
            Dim coordenadasPosicao = navio.getPosicao(i)

            If coordenadasPosicao(0) = -1 And coordenadasPosicao(1) = -1 Then
                casasDestruidas += 1
            End If
        Next

        If casasDestruidas = qntdPosicoes Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function posicaoValida(embarcacao As Navio, mapa As Mapa, linha As Integer, coluna As Integer, orientacao As Integer)
        If orientacao = 1 Then
            If coluna + embarcacao.getQntdCasas <= mapa.getLargura + 1 And linha < mapa.getAltura + 1 Then Return True
        ElseIf orientacao = 2 Then
            If linha + embarcacao.getQntdCasas <= mapa.getAltura + 1 And coluna < mapa.getLargura + 1 Then Return True
        End If

        Return False
    End Function

End Module
