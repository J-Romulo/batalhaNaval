Public Module GameController
    Public Function run()
        Dim playerResposta = GameView.menuInicial()                 ''retorna a opção escolhida pelo jogador (jogar ou sair)

        If playerResposta = 2 Then                                  ''Encerra a execução do programa
            Environment.Exit(2)
        End If

        Dim jogador As Jogador = GameView.infoJogador()             ''Cria um jogador com o nome passado pelo usuário

        Dim tabuleiroLargura, tabuleiroAltura, qntdNavios As Integer
        GameView.infoTabuleiro(tabuleiroLargura, tabuleiroAltura, qntdNavios)   ''atribui o tamanho do tabuleiro e a quantidade de navios escolhidos pelo usuário às variáveis passadas como parametro
        Dim mapa As Mapa = MapaController.criarMapa(tabuleiroLargura, tabuleiroAltura, qntdNavios) ''cria um tabuleiro com o tamanho e a quantidade de navios passadas pelo usuário

        jogador.setTabuleiro(mapa)                                  ''atribui o tabuleiro ao jogador
        JogadorController.setarNavios(jogador)                      ''posiciona os navios no tabuleiro

        Dim bot As Jogador = JogadorController.criarBot(jogador.getMapa())  ''cria um bot com um tabuleiro igual ao do jogador
        JogadorController.setarNavios(bot)                          ''posiciona os navios do bot


        Dim resultadoRodada
        Dim vez = 1
        While resultadoRodada <> 2
            Dim linhaAtaque, colunaAtaque As Integer
            Static Gerador As System.Random = New System.Random()

            If vez = 1 Then
                vez = 2
                Console.WriteLine("Sua Vez !")
                Console.WriteLine("Tabuleiro do inimigo:")

                GameView.imprimirTabuleiroInimigo(bot.getMapa)

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
                    vez = 1
                End If
            Else
                vez = 1
                Console.WriteLine("Vez do oponente !")
                Console.WriteLine("Seu tabuleiro:")

                GameView.imprimirTabuleiroInimigo(jogador.getMapa)

                resultadoRodada = MapaController.fazerJogada(jogador.getMapa, Gerador.Next(0, mapa.getLargura + 1), Gerador.Next(0, mapa.getAltura + 1))
                GameView.imprimirTabuleiroInimigo(jogador.getMapa)

                If resultadoRodada = 2 Then
                    Console.WriteLine("O oponente destruiu todas as embarcações inimigas! Você perdeu!")
                ElseIf resultadoRodada = 1 Then
                    Console.WriteLine("O oponente destruiu parte da embarcação! CUIDADO !")
                ElseIf resultadoRodada = 0 Then
                    Console.WriteLine("O oponente acertou na agua!")
                ElseIf resultadoRodada = -1 Then
                    vez = 2
                End If
            End If
        End While

    End Function
End Module
