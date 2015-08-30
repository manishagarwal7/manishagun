﻿Namespace Manishagun.Data

    Public Class GuestBookDirector : Implements IDisposable
        Private _dataContext As New ManiShagunDBMLDataContext

        Public Sub New()
            _dataContext = New ManiShagunDBMLDataContext
        End Sub

        Public Sub InsertMessage(name As String, msg As String)
            _dataContext.MSGuestBooks.InsertOnSubmit(New MSGuestBook With {.Name = name, .Message = msg, .DateCreated = Now})
            _dataContext.SubmitChanges()
        End Sub

        Public Function GetGuestBookMessages() As IEnumerable(Of MSGuestBook)
            Return _dataContext.MSGuestBooks
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    _dataContext.Dispose()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace


