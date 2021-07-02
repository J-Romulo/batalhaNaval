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


        For j = 0 To mapa.getNaviosLength
            Dim navioEscolha = GameView.escolhaNavios() - 1
            Dim embarcacao = New Navio(navioEscolha)

            For i = 0 To navioEscolha
                GameView.imprimirTabuleiro(jogador.getMapa())
                Dim linha, coluna As Integer
                GameView.setarPosicaoNavio(linha, coluna)
                embarcacao.setPosicao(linha, coluna, i)

                MapaController.setarJogada(jogador.getMapa, linha, coluna, embarcacao.getTipo)
                MapaController.setarJogada(bot.getMapa, linha, coluna, embarcacao.getTipo)
            Next

            MapaController.setarEmbarcacao(jogador.getMapa, embarcacao)
            MapaController.setarEmbarcacao(bot.getMapa, embarcacao)

            GameView.imprimirTabuleiro(jogador.getMapa())
        Next

        Dim resultadoRodada
        While resultadoRodada <> 2
            GameView.imprimirTabuleiroInimigo(bot.getMapa)

            Dim linhaAtaque, colunaAtaque As Integer
            GameView.setarCoordenadasAtaque(linhaAtaque, colunaAtaque)
            resultadoRodada = MapaController.fazerJogada(bot.getMapa, linhaAtaque, colunaAtaque)
            GameView.imprimirTabuleiroInimigo(bot.getMapa)
            If resultadoRodada = 2 Then
                Console.WriteLine("Destruiu todas as embarcações inimigas! Você ganhou!")
            ElseIf resultadoRodada = 1 Then
                Console.WriteLine("Destruiu parte da embarcação! Continue assim!")
            ElseIf resultadoRodada = 0 Then
                Console.WriteLine("Acertou na agua!")
            ElseIf resultadoRodada = -1 Then
                Console.WriteLine("Você ja atacou aqui, tente em outro lugar.")
            End If
        End While

    End Function
End Module
