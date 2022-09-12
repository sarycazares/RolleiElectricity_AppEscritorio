Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_AltaCliente

    Private Sub Pagina_AltaCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
        If MsgBox("Se limpiaran todos los campos ¿Desea continuar?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            TextBox12.Text = " "
            TextBox13.Text = " "
            TextBox14.Text = " "
            TextBox1.Text = " "
            TextBox11.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox6.Text = " "
            TextBox8.Text = " "
            TextBox10.Text = " "
            TextBox5.Text = " "
            TextBox7.Text = " "
            TextBox9.Text = " "
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As String
        conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        Dim cn As New SqlConnection 'establece conexion
        cn.ConnectionString = conexion 'se establece conexion con la cadena 
        Dim comando As SqlCommand = New SqlCommand("insertar_cliente", cn)
        cn.Open()
        Try


            Dim val1 As String = TextBox12.Text
            Dim val2 As String = TextBox13.Text
            Dim val3 As String = TextBox14.Text
            Dim val4 As String = TextBox1.Text
            Dim val5 As String = TextBox11.Text
            Dim val6 As String = TextBox2.Text
            Dim val7 As String = TextBox3.Text
            Dim val8 As String = TextBox4.Text
            Dim val9 As String = TextBox6.Text
            Dim val10 As String = TextBox8.Text
            Dim val11 As String = TextBox10.Text
            Dim val12 As String = TextBox5.Text
            Dim val13 As String = TextBox7.Text
            Dim val14 As String = TextBox9.Text

            Dim numero_servicio As Integer = TextBox12.Text
            Dim usuario_c As String = TextBox13.Text
            Dim contra_c As String = TextBox14.Text
            Dim nombre_c As String = TextBox1.Text
            Dim apellido_c As String = TextBox11.Text
            Dim email_c As String = TextBox2.Text
            Dim curp_c As String = TextBox3.Text
            Dim nat_c As String = DateTimePicker1.Text
            Dim alta_c As String = DateTimePicker2.Text
            Dim genero_c As String = ComboBox1.Text
            Dim calle_c As String = TextBox4.Text
            Dim colonia_c As String = TextBox6.Text
            Dim estado_c As String = TextBox8.Text
            Dim codigo_c As String = TextBox10.Text
            Dim numero_dom As String = TextBox5.Text
            Dim municipio_c As String = TextBox7.Text
            Dim pais_c As String = TextBox9.Text

            comando.CommandType = CommandType.StoredProcedure

            If (val1 = "" Or val2 = "" Or val3 = "" Or val4 = "" Or val5 = "" Or val6 = "" Or val7 = "" Or val8 = "" Or val9 = "" Or val10 = "" Or val11 = "" Or val12 = "" Or val13 = "" Or val14 = "") Then
                MsgBox("No deje campos en blanco", MsgBoxStyle.YesNo, "Aviso")
            Else
                comando.Parameters.AddWithValue("@nombre_usuario", usuario_c)
                comando.Parameters.AddWithValue("@contrasena_p", contra_c)
                comando.Parameters.AddWithValue("@no_servicio", numero_servicio)
                comando.Parameters.AddWithValue("@nombre_persona", nombre_c)
                comando.Parameters.AddWithValue("@apellido_persona", apellido_c)
                comando.Parameters.AddWithValue("@email_p", email_c)
                comando.Parameters.AddWithValue("@curp_p", curp_c)
                comando.Parameters.AddWithValue("@datenat", nat_c)
                comando.Parameters.AddWithValue("@datein", alta_c)
                comando.Parameters.AddWithValue("@calle_p", calle_c)
                comando.Parameters.AddWithValue("@colonia_p", colonia_c)
                comando.Parameters.AddWithValue("@estado_p", estado_c)
                comando.Parameters.AddWithValue("@numero_dom", numero_dom)
                comando.Parameters.AddWithValue("@municipio_p", municipio_c)
                comando.Parameters.AddWithValue("@pais_p", pais_c)
                comando.Parameters.AddWithValue("@codigo_p", codigo_c)
                comando.Parameters.AddWithValue("@genero_p", genero_c)


                comando.ExecuteNonQuery()
                comando.Parameters.Clear()
                If MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.YesNo, "Operacion Exitosa") = MsgBoxResult.Yes Then
                    Me.Hide()
                    TextBox12.Text = " "
                    TextBox13.Text = " "
                    TextBox14.Text = " "
                    TextBox1.Text = " "
                    TextBox11.Text = " "
                    TextBox2.Text = " "
                    TextBox3.Text = " "
                    TextBox4.Text = " "
                    TextBox6.Text = " "
                    TextBox8.Text = " "
                    TextBox10.Text = " "
                    TextBox5.Text = " "
                    TextBox7.Text = " "
                    TextBox9.Text = " "

                    Pagina_InicioEmpleado.Show()
                End If
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un error vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        End Try

        cn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_GestionDeClientes.Show()
        End If
    End Sub

    Private Sub Pagina_AltaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            ComboBox1.Items.Add("Masculino")
            ComboBox1.Items.Add("Femenino")
        End With
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class