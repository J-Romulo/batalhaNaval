Public Class Mapa
    Private Altura As Integer
    Private Largura As Integer
    Private TabuleiroMapa(,) As Integer
    Private navios() As Navio

    Public Sub New(altura As Integer, largura As Integer, quantidadeNavios As Integer)
        Me.Altura = altura
        Me.Largura = largura
        TabuleiroMapa = New Integer(altura, largura) {}
        Dim navio(quantidadeNavios) As Navio
        navios = navio
    End Sub

    ''' acessa posicao
    Default Public Property Item(posicaoY As Integer, posicaoX As Integer) As Integer
        Get
            Return TabuleiroMapa(posicaoY, posicaoX)
        End Get

        Set(valor As Integer)
            TabuleiroMapa(posicaoY, posicaoX) = valor
        End Set
    End Property

    Public Function getArray()
        Return TabuleiroMapa
    End Function

    Public Function getAltura()
        Return Altura
    End Function

    Public Function getLargura()
        Return Largura
    End Function

    Public Function setNavio(embarcacao As Navio)
        For i = 0 To navios.Length
            If navios(i) Is Nothing Then
                navios(i) = embarcacao
                Return True
            End If
        Next

        Return False
    End Function

    Public Function getNavio(posicao As Integer)
        Return navios(posicao)
    End Function
    Public Function getNaviosLength()
        Return navios.Length - 1
    End Function
End Class