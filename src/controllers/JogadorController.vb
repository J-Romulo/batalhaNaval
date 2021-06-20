Public Module JogadorController
    Public Function criarBot(mapaJogador As Mapa)
        Dim bot = New Jogador("Bot")
        Dim tabuleiroBot = New Mapa(mapaJogador.getAltura, mapaJogador.getLargura, mapaJogador.getNaviosLength)
        bot.setTabuleiro(tabuleiroBot)

        Return bot
    End Function

    Public Function setarNaviosBot(bot As Jogador)

    End Function
End Module
