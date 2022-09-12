Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_DesbloquearEmpleado
    Private Sub Pagina_DesbloquearEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()
            Dim comando As SqlCommand = New SqlCommand("desbloquear_e", cn)
            comando.CommandType = CommandType.StoredProcedure

            Dim validar_estado As String = TextBox1.Text
            Dim nombre As String = TextBox12.Text

            If (validar_estado = "Bloqueado") Then
                comando.Parameters.AddWithValue("@nom_usuario", nombre)
                comando.ExecuteNonQuery()
                MsgBox("El usuario ha sido desbloqueado", MsgBoxStyle.OkOnly, "Aviso")
                TextBox11.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
            Else
                MsgBox("El usuario ingresado no se encuentra bloqueado", MsgBoxStyle.OkOnly, "Aviso")
            End If

        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_InicioAdmin.Show()
            TextBox11.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "

        End If
    End Sub

    Private Sub Pagina_DesbloquearEmpleado_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioAdmin.Show()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()

            Dim nombre_buscado As String = TextBox12.Text
            Dim validar_bloqueo As String = TextBox4.Text

            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("buscardesbloquear_e", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand.Parameters.Add("@nom_usuario", SqlDbType.VarChar, 10).Value = nombre_buscado

            adaptador.Fill(ds, "usuario_empleado")

            If (ds.Tables("usuario_empleado").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then


                Me.TextBox11.Text = ds.Tables("usuario_empleado").Rows(0).Item(0)
                Me.TextBox2.Text = ds.Tables("usuario_empleado").Rows(0).Item(1)
                Me.TextBox3.Text = ds.Tables("usuario_empleado").Rows(0).Item(2)
                Me.TextBox4.Text = ds.Tables("usuario_empleado").Rows(0).Item(3)
                validar_bloqueo = TextBox4.Text
                If (validar_bloqueo = "True") Then
                    TextBox1.Text = "Bloqueado"
                Else
                    TextBox1.Text = "Activo"
                End If

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If

        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

End Class