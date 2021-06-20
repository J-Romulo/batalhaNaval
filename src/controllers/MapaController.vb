Public Module MapaController
    Public Function criarMapa(largura As Integer, altura As Integer, qntdNavios As Integer)
        Dim mapaCriado As New Mapa(altura, largura, qntdNavios)

        Return mapaCriado
    End Function

    Public Function setarJogada(mapa As Mapa, posicaoX As Integer, posicaoY As Integer, tipoNavio As Integer)
        If mapa.Item(posicaoX, posicaoY) <> 0 Then
            '''se ja tiver marcado a posição no array, significa que ja houve jogada nessa posicao
            Return False
        Else
            '''1 = Submarino / 2 = Hiate ...
            mapa.Item(posicaoX, posicaoY) = tipoNavio + 1
            Return True
        End If
    End Function

    Public Function setarEmbarcacao(mapa As Mapa, navio As Navio)
        Return mapa.setNavio(navio)
    End Function
End Module
