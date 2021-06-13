Public Class Mapa
  Private Altura As Integer
  Private Largura As Integer
  Private TabuleiroMapa(,) As Integer

  Public Sub New(altura As Integer, largura As Integer)
    Me.Altura = altura
    Me.Largura = largura
    Tabuleiro = new Integer(altura, largura) {}
  End Sub

  ''' acessa posicao
  Default Public Property Item(posicaoX As Integer, posicaoY As Integer) As Integer
    Get 
      Return Tabuleiro(posicaoX, posicaoY)
    End Get

    Set(valor As Integer)
      Tabuleiro(posicaoX, posicaoY) = valor
    End Set
  End Property

End Class