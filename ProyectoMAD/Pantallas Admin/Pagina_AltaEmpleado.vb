Imports System.Data
Imports System.Data.SqlClient

Public Class Pagina_AltaEmpleado

    Private Sub Pagina_AltaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            ComboBox1.Items.Add("ADMIN")
            ComboBox1.Items.Add("EMPLEADO")
        End With

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            Dim comando As SqlCommand = New SqlCommand("insertar_empleado", cn)
            cn.Open()

            Dim num_empleado As Integer = TextBox11.Text
            Dim nombre_empleado As String = TextBox14.Text
            Dim contra_empleado As String = TextBox13.Text
            Dim permiso_empleado As String = ComboBox1.Text
            Dim nombre_pe As String = TextBox4.Text
            Dim apellido_pe As String = TextBox1.Text
            Dim nat_date As String = DateTimePicker1.Text
            Dim rfc_em As String = TextBox10.Text
            Dim curp_em As String = TextBox8.Text
            Dim fecha_in As String = DateTimePicker2.Text



            comando.CommandType = CommandType.StoredProcedure

            comando.Parameters.AddWithValue("@numero_em", num_empleado)
            comando.Parameters.AddWithValue("@nomusuario_em", nombre_empleado)
            comando.Parameters.AddWithValue("@contrasena_em", contra_empleado)
            comando.Parameters.AddWithValue("@permiso_em", permiso_empleado)
            comando.Parameters.AddWithValue("@nombre_em", nombre_pe)
            comando.Parameters.AddWithValue("@apellido_em", apellido_pe)
            comando.Parameters.AddWithValue("@natdate_em", nat_date)
            comando.Parameters.AddWithValue("@rfc_em", rfc_em)
            comando.Parameters.AddWithValue("@curp_em", curp_em)
            comando.Parameters.AddWithValue("@fecha_altaem", fecha_in)

            comando.ExecuteNonQuery()
            comando.Parameters.Clear()
            If MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.YesNo, "Operacion Exitosa") = MsgBoxResult.Yes Then
                Me.Hide()
                TextBox11.Text = " "
                TextBox14.Text = " "
                TextBox13.Text = " "
                TextBox4.Text = " "
                TextBox1.Text = " "
                TextBox10.Text = " "
                TextBox8.Text = " "

                Pagina_InicioAdmin.Show()
            End If

            cn.Close()
        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Operacion Exitosa")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_InicioAdmin.Show()
        End If
    End Sub

    Private Sub Pagina_AltaCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioAdmin.Show()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    End Sub

End Class