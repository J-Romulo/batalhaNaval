Imports Microsoft.VisualBasic
Imports GameView

Public Module GameView
    Public Function menuInicial()
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~")
        Console.WriteLine("~~~~Batalha Naval~~~~~")
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~")
        Console.WriteLine("1 - Jogar")
        Console.WriteLine("2 - Sair")
        Console.ResetColor()
        Return Console.ReadLine()
    End Function

    Public Function infoJogador()
        Console.Write("Nome do jogador:")
        Dim playerNome = Console.ReadLine()

        Return New Jogador(playerNome)
    End Function

    Public Function infoTabuleiro(ByRef tabuleiroLargura As Integer, ByRef tabuleiroAltura As Integer, ByRef qntdNavios As Integer)
        Console.Write("Largura do tabuleiro:")
        tabuleiroLargura = Console.ReadLine() - 1
        Console.Write("Altura do tabuleiro:")
        tabuleiroAltura = Console.ReadLine() - 1
        Console.Write("Quantidade de navios:")
        qntdNavios = Console.ReadLine() - 1
    End Function

    Public Function imprimirTabuleiro(tabuleiro As Mapa)
        Dim tabuleiroParaImprimir = tabuleiro.getArray
        Dim altura = tabuleiro.getAltura
        Dim largura = tabuleiro.getLargura

        Console.WriteLine()
        Console.WriteLine("Seu tabuleiro")
        For i = 0 To altura
            Console.Write("{0}- ", i)
            For j = 0 To largura
                If tabuleiroParaImprimir(i, j) = 0 Then
                    Console.BackgroundColor = ConsoleColor.Blue
                    Console.ForegroundColor = ConsoleColor.Black
                Else
                    Console.BackgroundColor = ConsoleColor.Red
                    Console.ForegroundColor = ConsoleColor.Black
                End If
                Console.Write(tabuleiroParaImprimir(i, j))
                Console.ResetColor()
            Next
            Console.WriteLine()
        Next
    End Function
    Public Function imprimirTabuleiroInimigo(tabuleiro As Mapa)
        Dim tabuleiroParaImprimir = tabuleiro.getArray
        Dim altura = tabuleiro.getAltura
        Dim largura = tabuleiro.getLargura

        Console.WriteLine()

        For i = 0 To altura
            Console.Write("{0}- ", i)
            For j = 0 To largura
                If (tabuleiroParaImprimir(i, j) = 6) Then
                    Console.BackgroundColor = ConsoleColor.DarkBlue
                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.Write("X")
                    Console.ResetColor()
                ElseIf (tabuleiroParaImprimir(i, j) = 7) Then
                    Console.BackgroundColor = ConsoleColor.DarkBlue
                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.Write("~")
                    Console.ResetColor()
                Else
                    Console.BackgroundColor = ConsoleColor.Blue
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.Write("~")
                    Console.ResetColor()
                End If
            Next
            Console.WriteLine()
        Next
    End Function

    Public Function escolhaNavios()
        Console.WriteLine()
        Console.WriteLine("1 - Submarino(1 casa)")
        Console.WriteLine("2 - Hiate(2 casas)")
        Console.WriteLine("3 - Barco(3 casas)")
        Console.WriteLine("4 - Navio(4 casas)")
        Console.WriteLine("5 - Cargueiro(5 casas)")
        Console.Write(">>")
        Return Console.ReadLine()
    End Function

    Public Function setarPosicaoNavio(ByRef linha As Integer, ByRef coluna As Integer, ByRef orientacao As Integer)
        Console.WriteLine("Posição da embarcação:")
        Console.Write("Linha: ")
        linha = Console.ReadLine()
        Console.Write("Coluna: ")
        coluna = Console.ReadLine()
        Console.Write("Orienteção: ")
        Console.WriteLine()
        Console.WriteLine("1 - Horizontal")
        Console.WriteLine("2 - Vertical")
        orientacao = Console.ReadLine()
    End Function

    Public Function setarCoordenadasAtaque(ByRef linha As Integer, ByRef coluna As Integer)
        Console.Write("Linha de ataque:")
        linha = Console.ReadLine()
        Console.Write("Coluna de ataque:")
        coluna = Console.ReadLine()
    End Function

End Module