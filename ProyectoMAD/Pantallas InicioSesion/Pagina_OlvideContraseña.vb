Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_OlvideContraseña
    Private Sub Pagina_OlvideContraseña_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_IniciarSesion.Show()
                TextBox1.Text = " "
                TextBox2.Text = " "
            Else
                e.Cancel = True
            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        Pagina_IniciarSesion.Show()
        TextBox1.Text = " "
        TextBox2.Text = " "
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_IniciarSesion.Show()
            TextBox1.Text = " "
            TextBox2.Text = " "
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Try
        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()
            Dim us_buscado As String = TextBox4.Text
            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("olvide_usuario", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 10).Value = us_buscado
        adaptador.Fill(ds, "usuario")

        Dim us_buscado2 As String = TextBox4.Text
        Dim ds2 As DataSet = New DataSet()
        Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
        adaptador2 = New SqlDataAdapter("olvide_empleado", cn)
        Dim cliente_encontrado2 As Boolean = False

        adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
        adaptador2.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 10).Value = us_buscado
        adaptador2.Fill(ds2, "usuario_empleado")

        If (ds.Tables("usuario").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

        If (cliente_encontrado = True) Then

            'datos personales
            Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(0)
            Me.TextBox2.Text = ds.Tables("usuario").Rows(0).Item(1)

        ElseIf (ds2.Tables("usuario_empleado").Rows.Count > 0) Then
            cliente_encontrado2 = True

            If (cliente_encontrado2 = True) Then

                'datos personales
                Me.TextBox1.Text = ds2.Tables("usuario_empleado").Rows(0).Item(0)
                Me.TextBox2.Text = ds2.Tables("usuario_empleado").Rows(0).Item(1)
            Else
                MsgBox("Usuario no encontrado", MsgBoxStyle.OkOnly, "Aviso")
            End If
        End If


        'Catch ex As Exception
        '    MsgBox("Ha ocurrido un error con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Aviso")

        'End Try
    End Sub
End Class