Imports Microsoft.VisualBasic
Imports GameView

Public Module GameView
    Public Function menuInicial()
        Console.WriteLine("Batalha Naval")
        Console.WriteLine("1 - Jogar")
        Console.WriteLine("2 - Sair")
        Return Console.ReadLine()
    End Function

    Public Function infoJogador()
        Console.WriteLine("Informe seu nome:")
        Dim playerNome = Console.ReadLine()

        Return New Jogador(playerNome)
    End Function

    Public Function infoTabuleiro(ByRef tabuleiroLargura As Integer, ByRef tabuleiroAltura As Integer, ByRef qntdNavios As Integer)
        Console.WriteLine("Largura do tabuleiro:")
        tabuleiroLargura = Console.ReadLine() - 1
        Console.WriteLine("Altura do tabuleiro:")
        tabuleiroAltura = Console.ReadLine() - 1
        Console.WriteLine("Quantidade de navios:")
        qntdNavios = Console.ReadLine() - 1
    End Function

    Public Function imprimirTabuleiro(tabuleiro As Mapa)
        Dim tabuleiroParaImprimir = tabuleiro.getArray
        Dim altura = tabuleiro.getAltura
        Dim largura = tabuleiro.getLargura

        For i = 0 To altura
            Console.Write("{0}- ", i)
            For j = 0 To largura
                Console.Write(tabuleiroParaImprimir(i, j))
            Next
            Console.WriteLine()
        Next
    End Function

    Public Function escolhaNavios()
        Console.WriteLine("1 - Submarino(1 casa)")
        Console.WriteLine("2 - Hiate(2 casas)")
        Console.WriteLine("3 - Barco(3 casas)")
        Console.WriteLine("4 - Navio(4 casas)")
        Console.WriteLine("5 - Cargueiro(5 casas)")
        Return Console.ReadLine()
    End Function

    Public Function setarPosicaoNavio(ByRef linha As Integer, ByRef coluna As Integer)
        Console.WriteLine("Posição da embarcação:")
        Console.WriteLine("Linha: ")
        linha = Console.ReadLine()
        Console.WriteLine("Coluna: ")
        coluna = Console.ReadLine()
    End Function
End Module