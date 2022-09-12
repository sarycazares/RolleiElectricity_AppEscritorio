Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Public conexion_base As String = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
    Public cnn As New SqlConnection

    Public Sub Crear_conexion()
        cnn = New SqlConnection(conexion_base)
        cnn.Open()
    End Sub

    Public Sub Cerarra_conexion()
        cnn.Close()
    End Sub

End Class
