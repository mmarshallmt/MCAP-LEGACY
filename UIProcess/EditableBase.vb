Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Public Class EditableBase(Of T)
    Implements INotifyPropertyChanged

    Public Sub New()
        MarkNew()
    End Sub

    Private _isDirty As Boolean = True
    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return _isDirty
        End Get
    End Property

    Protected Friend Sub MarkDirty()
        _isDirty = True
    End Sub

    Protected Friend Sub MarkClean()
        _isDirty = False
    End Sub

    Private _isNew As Boolean = True
    Public ReadOnly Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
    End Property

    Protected Friend Sub MarkNew()
        _isNew = True
    End Sub

    Protected Friend Sub MarkOld()
        _isNew = False
    End Sub

    Public Overridable Sub Save()

    End Sub

#Region "INotifyPropertyChanged Members"

    ''' <summary>
    ''' Event raised when a property changes.
    ''' </summary>
    Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' Raise the PropertyChanged event.
    ''' </summary>
    ''' <param name="propertyName">Name of the changed property.</param>
    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        MarkDirty()

        RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
    End Sub

#End Region
End Class