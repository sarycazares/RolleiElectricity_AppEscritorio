Public Class Pagina_GestionCarga

    Private Sub Pagina_GestionCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Pagina_GenerarTarifa.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Pagina_CargaMasiva.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Pagina_InicioEmpleado.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Pagina_CargarConsumos.Show()
        Me.Hide()
    End Sub
End Class