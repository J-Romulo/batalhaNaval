Public Class Navio
    Private Enum tiposNavio
        Submarino '''1 casa
        Hiate '''2 casas
        Barco ''' 3 casas
        Navio ''' 4 casas
        Cargueiro ''' 5 casas
    End Enum

    Private tipo As tiposNavio
    Private posicoes(,) As Integer

    '''tipo seria o tipo enum do navio e posicoes é uma matriz com os valores x,y de cada casa do navio
    Public Sub New(tipoNavio As Integer)
        Me.tipo = tipoNavio
        posicoes = New Integer(tipoNavio, 1) {}
    End Sub


    Public Function getTipo()
        Return tipo
    End Function

    '''ordemPosicao seria
    Public Function setPosicao(valorY As Integer, valorX As Integer, ordemPosicao As Integer)
        posicoes(ordemPosicao, 0) = valorY
        posicoes(ordemPosicao, 1) = valorX
    End Function

    Public Function getPosicao(ordemPosicao As Integer)
        Dim coordenadasPosicao(2) As Integer
        coordenadasPosicao(0) = posicoes(ordemPosicao, 0)
        coordenadasPosicao(1) = posicoes(ordemPosicao, 1)

        Return coordenadasPosicao
    End Function

    Public Function getQntdCasas()
        If Me.tipo = tiposNavio.Submarino Then
            Return 1
        ElseIf Me.tipo = tiposNavio.Hiate Then
            Return 2
        ElseIf Me.tipo = tiposNavio.Barco Then
            Return 3
        ElseIf Me.tipo = tiposNavio.Navio Then
            Return 4
        ElseIf Me.tipo = tiposNavio.Cargueiro Then
            Return 5
        End If
    End Function
End Class