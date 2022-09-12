Imports System.Data
Imports System.Data.SqlClient

Public Class Pagina_EliminarCliente
    Private Sub Pagina_EliminarCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_GestionDeClientes.Show()
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

            Dim numero_buscado As String = TextBox12.Text

            'String numString = New StringBuilder().Append(num).ToString()

            'Dim numString As StringFormat = New StringFormat(numero_buscado)
            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("eliminarcliente_buscar", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand.Parameters.Add("@numero_servicio", SqlDbType.Int, 10).Value = numero_buscado

            adaptador.Fill(ds, "usuario")

            If (ds.Tables("usuario").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then


                Me.TextBox11.Text = ds.Tables("usuario").Rows(0).Item(0)
                Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(1)
                Me.TextBox2.Text = ds.Tables("usuario").Rows(0).Item(2)

            Else
                MsgBox("No hay miembros asociados al numero de servicio ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_GestionDeClientes.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            Dim comando As SqlCommand = New SqlCommand("eliminar_cliente", cn)
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            Dim numero_buscado As Integer = TextBox12.Text
            cn.Open()

            comando.CommandType = CommandType.StoredProcedure
            If MsgBox("Desea eliminar este cliente? (esta operacion no puede revertirse)", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

                comando.Parameters.AddWithValue("@numero_servicio", numero_buscado)
                comando.ExecuteNonQuery()

                MsgBox("El cliente ha sido eliminado", MsgBoxStyle.OkOnly, "Aviso")

                TextBox11.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "

                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un error, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        End Try
    End Sub

    Private Sub Pagina_EliminarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class