Imports Microsoft.VisualBasic
Imports System

Public Class Jogador
    Private nome As String
    Private tabuleiro As Tabuleiro

    Public Sub New(n As String)
        nome = n
    End Sub

    Public Function getNome()
        Return nome
    End Function

    Public Function getTabuleiro()
        Return tabuleiro
    End Function

    Public Sub setTabuleiro(t As Tabuleiro)
        tabuleiro = t
    End Sub

    Public Sub setNome(n As String)
        nome = n
    End Sub
End Class



