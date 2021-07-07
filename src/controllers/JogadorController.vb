Public Module JogadorController

    Public Function setarNavios(jogador As Jogador)
        For j = 0 To jogador.getMapa().getNaviosLength()            ''para cada navio do jogador
            Dim linha, coluna, orientacao As Integer
            Dim navioEscolha = GameView.escolhaNavios() - 1         ''retorna a opção de navio escolhida pelo usuário
            Dim embarcacao = New Navio(navioEscolha)                ''cria um navio escolhido pelo usuário


            GameView.imprimirTabuleiro(jogador.getMapa())           ''exibe o tabuleiro atual do usuário
            GameView.setarPosicaoNavio(linha, coluna, orientacao)   ''atribui os valores de linha, coluna e orientação escolhidos pelo usuário para as variáveis 

            If (MapaController.posicaoValida(embarcacao, jogador.getMapa(), linha, coluna, orientacao)) Then    ''caso os valores sejam válidos para o tabuleiro
                For k = 0 To embarcacao.getQntdCasas - 1
                    If orientacao = 1 Then
                        embarcacao.setPosicao(linha, coluna + k, 0)     ''seta a posição que o navio está no tabuleiro
                        MapaController.setarJogada(jogador.getMapa, linha, coluna + k, embarcacao.getTipo) ''coloca o navio no tabuleiro
                    ElseIf orientacao = 2 Then
                        embarcacao.setPosicao(linha + k, coluna, 0)     ''seta a posição que o navio está no tabuleiro
                        MapaController.setarJogada(jogador.getMapa, linha + k, coluna, embarcacao.getTipo) ''coloca o navio no tabuleiro
                    End If
                Next
            Else
                Console.WriteLine("Não é possivel posicionar esse navio nesta posição do tabuleiro")
                j -= 1          ''decrementa o indice para que o for continue do indice atual
                Continue For
            End If


            MapaController.setarEmbarcacao(jogador.getMapa, embarcacao) ''adiciona o navio ao vetor de navios do mapa

            GameView.imprimirTabuleiro(jogador.getMapa())   ''exibe o mapa atualizado para o usuário
        Next
    End Function

    Public Function criarBot(mapaJogador As Mapa)
        Dim bot = New Jogador("Bot")
        Dim tabuleiroBot = New Mapa(mapaJogador.getAltura, mapaJogador.getLargura, mapaJogador.getNaviosLength)
        bot.setTabuleiro(tabuleiroBot)

        Return bot
    End Function

    Public Function setarNaviosBot(bot As Jogador, quantidadeNavios As Integer)

    End Function
End Module
