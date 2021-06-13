Public Module MapaController
    Public Function criarMapa(largura As Integer, altura As Integer)
        Dim mapaCriado As New Mapa(altura, largura)

        Return mapaCriado
    End Function

    Public Function setarJogada(mapa As Mapa, posicaoX As Integer, posicaoY As Integer)
        If mapa.Item(posicaoX, posicaoY) Then
            '''se ja tiver marcado a posição no array, significa que ja houve jogada nessa posicao
            Return False
        Else
            mapa.Item(posicaoX, posicaoY) = 1
            Return True
        End If
    End Function
End Module
