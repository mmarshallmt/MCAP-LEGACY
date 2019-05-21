Namespace UI

    Public Class CCFormsSubmitMessageBox

        Private WithEvents m_Processor As Processors.QCVehicleImages
        Private m_lastMouseClickTimeStamp As DateTime
        Private m_dataSource As System.Data.DataView

        ''' <summary>
        ''' Instance of class QCVehicleImages
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.QCVehicleImages
            Get
                Return m_Processor
            End Get
        End Property



        ''' <summary>
        ''' Source of Data that will be used to display values for selection help.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property DataSource() As System.Data.DataView
            Get
                Return m_dataSource
            End Get
            Set(ByVal value As System.Data.DataView)
                m_dataSource = value
            End Set
        End Property




        Public Sub Initialize(ByVal dataSource As Integer)
            MessageLabel.Text = dataSource.ToString()

        End Sub


        Private Sub loadVehicleData()



        End Sub

        Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        End Sub

        Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub


        Private Sub QcStatusDisplayScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub


        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            ' Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            'Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
    End Class

End Namespace