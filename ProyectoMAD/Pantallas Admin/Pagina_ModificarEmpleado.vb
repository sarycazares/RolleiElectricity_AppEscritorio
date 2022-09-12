Imports System.Data
Imports System.Data.SqlClient

Public Class Pagina_ModificarEmpleado
    Private Sub Pagina_ModificarEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            ComboBox1.Items.Add("ADMIN")
            ComboBox1.Items.Add("EMPLEADO")
        End With
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
            adaptador = New SqlDataAdapter("buscar_empleado", cn)
            Dim empleado_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand.Parameters.Add("@numero_em", SqlDbType.Int, 10).Value = numero_buscado

            adaptador.Fill(ds, "usuario_empleado")

            If (ds.Tables("usuario_empleado").Rows.Count > 0) Then
                empleado_encontrado = True
            End If

            If (empleado_encontrado = True) Then


                Me.TextBox6.Text = ds.Tables("usuario_empleado").Rows(0).Item(1)
                Me.TextBox5.Text = ds.Tables("usuario_empleado").Rows(0).Item(2)
                Me.ComboBox1.Text = ds.Tables("usuario_empleado").Rows(0).Item(3)
                Me.TextBox1.Text = ds.Tables("usuario_empleado").Rows(0).Item(4)
                Me.TextBox4.Text = ds.Tables("usuario_empleado").Rows(0).Item(5)
                Me.TextBox2.Text = ds.Tables("usuario_empleado").Rows(0).Item(8)
                Me.TextBox3.Text = ds.Tables("usuario_empleado").Rows(0).Item(7)
                Me.DateTimePicker1.Text = ds.Tables("usuario_empleado").Rows(0).Item(6)
            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If


        Catch ex As Exception
            MsgBox("Ha habido problemas con su solicitud, intentelo nuevamente", MsgBoxStyle.OkOnly, "Aviso")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As String
        conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        Dim cn As New SqlConnection 'establece conexion
        cn.ConnectionString = conexion 'se establece conexion con la cadena 

        Dim comando As SqlCommand = New SqlCommand("modificar_empleado", cn)
        comando.CommandType = CommandType.StoredProcedure



        cn.Open()
        'validadores de textbox vacios
        Dim val1 As String = TextBox6.Text
        Dim val2 As String = TextBox5.Text
        Dim val3 As String = TextBox1.Text
        Dim val4 As String = TextBox4.Text
        Dim val5 As String = TextBox2.Text
        Dim val6 As String = TextBox3.Text
        'toma de datos de un textbox
        Dim nomus_p As String = TextBox6.Text
        Dim contra_p As String = TextBox5.Text
        Dim permiso_p As String = ComboBox1.Text
        Dim nombre_p As String = TextBox1.Text
        Dim apex_p As String = TextBox4.Text
        Dim nat_p As String = DateTimePicker1.Text
        Dim rfc_p As String = TextBox2.Text
        Dim curp_p As String = TextBox3.Text


        If (val1 = "" Or val2 = "" Or val3 = "" Or val4 = "" Or val5 = "" Or val6 = "") Then
            MsgBox("Llene todos los campos para poder continuar", MsgBoxStyle.YesNo, "Aviso")

        Else

            comando.Parameters.AddWithValue("@nomusuario_mod", nomus_p)
            comando.Parameters.AddWithValue("@contrasena_mod", contra_p)
            comando.Parameters.AddWithValue("@permiso_mod", permiso_p)
            comando.Parameters.AddWithValue("@nombre_mod", nombre_p)
            comando.Parameters.AddWithValue("@apellido_mod", apex_p)
            comando.Parameters.AddWithValue("@natdate_mod", nat_p)
            comando.Parameters.AddWithValue("@rfc_mod", rfc_p)
            comando.Parameters.AddWithValue("@curp_mod", curp_p)
            comando.ExecuteNonQuery()


            MsgBox("Los cambios han sido guardados", MsgBoxStyle.YesNo, "Operacion exitosa")
            TextBox6.Text = " "
            TextBox5.Text = " "
            TextBox1.Text = " "
            TextBox4.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            cn.Close()
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_InicioAdmin.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Se limpiaran todos los campos ¿Acepta?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

            TextBox6.Text = " "
            TextBox5.Text = " "
            TextBox1.Text = " "
            TextBox4.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
        End If
    End Sub

    Private Sub Pagina_ModificarEmpleado_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioAdmin.Show()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

End Class