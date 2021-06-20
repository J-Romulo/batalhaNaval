Public Module GameController
    Public Function run()
        Dim playerResposta = GameView.menuInicial()

        If playerResposta = 2 Then
            Environment.Exit(2)
        End If

        Dim jogador As Jogador = GameView.infoJogador()

        Dim tabuleiroLargura, tabuleiroAltura, qntdNavios As Integer
        GameView.infoTabuleiro(tabuleiroLargura, tabuleiroAltura, qntdNavios)
        Dim mapa As Mapa = MapaController.criarMapa(tabuleiroLargura, tabuleiroAltura, qntdNavios)

        jogador.setTabuleiro(mapa)

        Dim bot As Jogador = JogadorController.criarBot(jogador.getMapa())


        For j = 0 To mapa.getNaviosLength - 1
            Dim navioEscolha = GameView.escolhaNavios() - 1
            Dim embarcacao = New Navio(navioEscolha)

            For i = 0 To navioEscolha
                GameView.imprimirTabuleiro(jogador.getMapa())
                Dim linha, coluna As Integer
                GameView.setarPosicaoNavio(linha, coluna)
                embarcacao.setPosicao(linha, coluna, i)

                MapaController.setarJogada(jogador.getMapa, coluna, linha, embarcacao.getTipo)
                MapaController.setarJogada(bot.getMapa, coluna, linha, embarcacao.getTipo)
            Next

            MapaController.setarEmbarcacao(jogador.getMapa, embarcacao)
            MapaController.setarEmbarcacao(bot.getMapa, embarcacao)

            GameView.imprimirTabuleiro(jogador.getMapa())
        Next


        Console.WriteLine("{0}")
    End Function
End Module
