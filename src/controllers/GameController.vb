Public Module GameController
    Public Function run()
        '''Essas mensagens devem ser da view, implementar no futuro
        Console.WriteLine("Batalha Naval")
        Console.WriteLine("1 - Jogar")
        Console.WriteLine("2 - Sair")
        Dim playerResposta = Console.ReadLine()

        If playerResposta = 2 Then
            Environment.Exit(2)
        End If


        Console.WriteLine("Informe seu nome:")
        Dim playerNome = Console.ReadLine()
        Console.WriteLine("Largura do tabuleiro:")
        Dim tabuleiroLargura = Console.ReadLine()
        Console.WriteLine("Altura do tabuleiro:")
        Dim tabuleiroAltura = Console.ReadLine()

        Dim jogador As Jogador = New Jogador(playerNome)
        Dim mapa As Mapa = MapaController.criarMapa(tabuleiroLargura, tabuleiroAltura)
        jogador.setTabuleiro(mapa)
        Console.WriteLine("{0}-{1}", jogador.getNome)
        Console.ReadLine()
            '''Continuação seria o player informar os navios e a quantidade de cada um, e posiciona-los
            '''Depois entra em ação o loop de jogadas
            '''

    End Function
End Module
