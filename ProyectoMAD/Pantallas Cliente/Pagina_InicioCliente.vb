Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_InicioCliente
    Private Sub Pagina_InicioCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("¿Desea salir de la aplicacion?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_IniciarSesion.Show()
        End If
    End Sub

    Private Sub Pagina_InicioCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion As String
        conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        Dim cn As New SqlConnection 'establece conexion
        cn.ConnectionString = conexion 'se establece conexion con la cadena 

        cn.Open()
        Dim usuario_buscar As String = My.Settings.usuario_ingress
        Dim ds As DataSet = New DataSet()
        Dim adaptador As SqlDataAdapter = New SqlDataAdapter
        adaptador = New SqlDataAdapter("cliente_inicio", cn)
        Dim cliente_encontrado As Boolean = False

        adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

        adaptador.SelectCommand.Parameters.Add("@nom_usuario", SqlDbType.VarChar, 30).Value = usuario_buscar

        adaptador.Fill(ds, "usuario")

        If (ds.Tables("usuario").Rows.Count > 0) Then
            cliente_encontrado = True
        End If

        If (cliente_encontrado = True) Then


            Me.TextBox13.Text = ds.Tables("usuario").Rows(0).Item(0)
            Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(1)
            Me.TextBox5.Text = ds.Tables("usuario").Rows(0).Item(2)
            Me.TextBox2.Text = ds.Tables("usuario").Rows(0).Item(3)
            Me.TextBox3.Text = ds.Tables("usuario").Rows(0).Item(4)
            Me.TextBox4.Text = ds.Tables("usuario").Rows(0).Item(5)
            Me.TextBox6.Text = ds.Tables("usuario").Rows(0).Item(6)
            Me.TextBox7.Text = ds.Tables("usuario").Rows(0).Item(7)
            Me.TextBox8.Text = ds.Tables("usuario").Rows(0).Item(8)
            Me.TextBox11.Text = ds.Tables("usuario").Rows(0).Item(9)
            Me.TextBox9.Text = ds.Tables("usuario").Rows(0).Item(10)
            Me.TextBox10.Text = ds.Tables("usuario").Rows(0).Item(11)
            Me.TextBox12.Text = ds.Tables("usuario").Rows(0).Item(12)


        End If


    End Sub

    Private Sub PictyreBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Pagina_Pago.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Hide()
        Pagina_Recibo.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Pagina_ReporteHistorico.Show()
    End Sub
End Class