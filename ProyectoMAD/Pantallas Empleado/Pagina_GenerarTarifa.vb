Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_GenerarTarifa
    Private Sub Pagina_GenerarTarifa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
        Dim comando As SqlCommand = New SqlCommand("osito_domestico", cn)
        Dim comando2 As SqlCommand = New SqlCommand("cargartarifa_industrial", cn)

            Dim t_servicio As String = TextBox5.Text
            cn.Open()

            Dim val1 As String = TextBox1.Text
            Dim val2 As String = TextBox2.Text
            Dim val3 As String = TextBox3.Text
            Dim val4 As String = TextBox4.Text

            Dim basica_t As String = TextBox1.Text
            Dim inter_t As String = TextBox2.Text
            Dim exce_t As String = TextBox3.Text
            Dim servicio As String = TextBox5.Text
            Dim medidor As Integer = TextBox4.Text

            comando.CommandType = CommandType.StoredProcedure
            comando2.CommandType = CommandType.StoredProcedure






            If (val1 = "" Or val2 = "" Or val3 = " " Or val3 = " ") Then
                    MsgBox("No deje campos en blanco", MsgBoxStyle.YesNo, "Aviso")
                Else
                    If (t_servicio = "Domestico") Then
                        comando.Parameters.AddWithValue("@basico_in", basica_t)
                        comando.Parameters.AddWithValue("@intermedio_in", inter_t)
                        comando.Parameters.AddWithValue("@excedente_in", exce_t)
                        comando.Parameters.AddWithValue("@medidor", medidor)
                        comando.Parameters.AddWithValue("@tipo_servicio", servicio)

                        comando.ExecuteNonQuery()
                        comando.Parameters.Clear()
                    End If

                    If (t_servicio = "Industrial") Then
                        comando2.Parameters.AddWithValue("@basico_in", basica_t)
                        comando2.Parameters.AddWithValue("@intermedio_in", inter_t)
                        comando2.Parameters.AddWithValue("@excedente_in", exce_t)
                        comando.Parameters.AddWithValue("@medidor", medidor)
                        comando.Parameters.AddWithValue("@tipo_servicio", servicio)

                        comando2.ExecuteNonQuery()
                        comando2.Parameters.Clear()
                    End If

                    If MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.YesNo, "Operacion Exitosa") = MsgBoxResult.Yes Then
                        Me.Hide()

                        TextBox1.Text = " "
                        TextBox2.Text = " "
                        TextBox3.Text = " "


                        Pagina_InicioEmpleado.Show()
                    End If
                End If

            cn.Close()
        'Catch ex As Exception
        '    MsgBox("Ha ocurrido un error, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_InicioEmpleado.Show()
        End If
    End Sub

    Private Sub Pagina_GenerarTarifa_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioEmpleado.Show()
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Try


        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()

            Dim medidor As String = TextBox4.Text

            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
        adaptador = New SqlDataAdapter("buscar_medidor", cn)
        Dim contrato_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

        adaptador.SelectCommand.Parameters.Add("@numero_medidor", SqlDbType.VarChar, 15).Value = medidor

        adaptador.Fill(ds, "contrato")
            If (ds.Tables("contrato").Rows.Count > 0) Then
                contrato_encontrado = True
            End If

            If (contrato_encontrado = True) Then
            Me.TextBox5.Text = ds.Tables("contrato").Rows(0).Item(1)
        Else
                MsgBox("El numero ingresado no pertenece a ningun contrato existente", MsgBoxStyle.YesNo, "Aviso")
            End If

        'Catch ex As Exception
        '    MsgBox("Ha ocurrido un problema con su solicitud, intente nuevamente", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub
End Class