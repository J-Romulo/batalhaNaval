Imports Microsoft.VisualBasic
Imports System

Public Class Jogador
    Private nome As String
    Private tabuleiro As Mapa

    Public Sub New(n As String)
        nome = n
    End Sub

    Public Function getNome()
        Return nome
    End Function

    Public Function getMapa()
        Return tabuleiro
    End Function

    Public Sub setTabuleiro(t As Mapa)
        tabuleiro = t
    End Sub

    Public Sub setNome(n As String)
        nome = n
    End Sub
End Class



