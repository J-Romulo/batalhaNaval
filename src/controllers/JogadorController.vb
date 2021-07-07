Public Module JogadorController

    Public Function setarNavios(jogador As Jogador)
        For j = 0 To jogador.getMapa().getNaviosLength()            ''para cada navio do jogador
            Dim linha, coluna, orientacao As Integer
            Dim navioEscolha As Integer

            If jogador.getNome() = "Bot" Then
                Static Gerador As System.Random = New System.Random()
                navioEscolha = Gerador.Next(0, 5)                       ''escolhe um barco aleatorio
                linha = Gerador.Next(jogador.getMapa().getLargura)      ''escolhe uma linha aleatoria
                coluna = Gerador.Next(jogador.getMapa().getAltura)      ''escolhe uma coluna aleatoria
                orientacao = Gerador.Next(1, 3)                         ''escolhe uma orientação aleatoria
            Else
                navioEscolha = GameView.escolhaNavios() - 1             ''retorna a opção de navio escolhida pelo usuário
                GameView.imprimirTabuleiro(jogador.getMapa())           ''exibe o tabuleiro atual do usuário
                GameView.setarPosicaoNavio(linha, coluna, orientacao)   ''atribui os valores de linha, coluna e orientação escolhidos pelo usuário para as variáveis 
            End If

            Dim embarcacao = New Navio(navioEscolha)                    ''cria um navio escolhido pelo usuário ou pelo bot

            If jogador.getNome = "Bot" Then
                Console.WriteLine(navioEscolha)
                Console.WriteLine(linha)
                Console.WriteLine(coluna)
                Console.WriteLine(orientacao)
            End If


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
