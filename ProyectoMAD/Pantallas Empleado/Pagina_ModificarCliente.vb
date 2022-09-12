Imports System.Data
Imports System.Data.SqlClient

Public Class Pagina_ModificarCliente
    Private Sub Pagina_ModificarCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
            adaptador = New SqlDataAdapter("buscar_cliente", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand.Parameters.Add("@numero_servicio", SqlDbType.Int, 10).Value = numero_buscado

            adaptador.Fill(ds, "usuario")

            If (ds.Tables("usuario").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then


                Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(0)
                Me.TextBox2.Text = ds.Tables("usuario").Rows(0).Item(1)
                Me.TextBox3.Text = ds.Tables("usuario").Rows(0).Item(2)
                Me.TextBox4.Text = ds.Tables("usuario").Rows(0).Item(3)
                Me.ComboBox1.Text = ds.Tables("usuario").Rows(0).Item(12)
                Me.DateTimePicker1.Text = ds.Tables("usuario").Rows(0).Item(4)
                Me.TextBox6.Text = ds.Tables("usuario").Rows(0).Item(5)
                Me.TextBox7.Text = ds.Tables("usuario").Rows(0).Item(6)
                Me.TextBox8.Text = ds.Tables("usuario").Rows(0).Item(7)
                Me.TextBox9.Text = ds.Tables("usuario").Rows(0).Item(8)
                Me.TextBox10.Text = ds.Tables("usuario").Rows(0).Item(9)
                Me.TextBox11.Text = ds.Tables("usuario").Rows(0).Item(10)
                Me.TextBox13.Text = ds.Tables("usuario").Rows(0).Item(11)

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If
            'TextBox1.Text = " "
            'TextBox2.Text = " "
            'TextBox3.Text = " "
            'TextBox4.Text = " "
            'TextBox6.Text = " "
            'TextBox7.Text = " "
            'TextBox8.Text = " "
            'TextBox9.Text = " "
            'TextBox10.Text = " "
            'TextBox11.Text = " "
            'TextBox13.Text = " "
        Catch ex As Exception
            MsgBox("Ocurrio un error, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()
            Dim comando As SqlCommand = New SqlCommand("modificar_cliente", cn)
            comando.CommandType = CommandType.StoredProcedure
            Dim val As String = TextBox1.Text
            Dim val2 As String = TextBox2.Text
            Dim val3 As String = TextBox3.Text
            Dim val4 As String = TextBox4.Text
            Dim val5 As String = TextBox6.Text
            Dim val6 As String = TextBox7.Text
            Dim val7 As String = TextBox8.Text
            Dim val8 As String = TextBox9.Text
            Dim val9 As String = TextBox10.Text
            Dim val10 As String = TextBox11.Text
            Dim val11 As String = TextBox13.Text

            Dim nombre_mod As String = TextBox1.Text
            Dim apellido_mod As String = TextBox2.Text
            Dim correo_mod As String = TextBox3.Text
            Dim curp_mod As String = TextBox4.Text
            Dim gen_mod As String = ComboBox1.Text
            Dim fecha_mod As String = DateTimePicker1.Text
            Dim calle_mod As String = TextBox6.Text
            Dim colonia_mod As String = TextBox7.Text
            Dim estado_mod As String = TextBox8.Text
            Dim numero_mod As String = TextBox9.Text
            Dim municipio_mod As String = TextBox10.Text
            Dim pais_mod As String = TextBox11.Text
            Dim codigo_mod As String = TextBox13.Text

            If (val = "" Or val2 = "" Or val3 = "" Or val4 = "" Or val5 = "" Or val6 = "" Or val7 = "" Or val8 = "" Or val9 = "" Or val10 = "" Or val11 = "") Then
                MsgBox("Llene todos los campos para poder continuar", MsgBoxStyle.YesNo, "Aviso")

            Else

                comando.Parameters.AddWithValue("@nombre_mod", nombre_mod)
                comando.Parameters.AddWithValue("@apellido_mod", apellido_mod)
                comando.Parameters.AddWithValue("@emil_mod", correo_mod)
                comando.Parameters.AddWithValue("@curp", curp_mod)
                comando.Parameters.AddWithValue("@fecha_mod", fecha_mod)
                comando.Parameters.AddWithValue("@calle_mod", calle_mod)
                comando.Parameters.AddWithValue("@colonia_mod", colonia_mod)
                comando.Parameters.AddWithValue("@estado_mod", estado_mod)
                comando.Parameters.AddWithValue("@numero_mod", numero_mod)
                comando.Parameters.AddWithValue("@municipio_mod", municipio_mod)
                comando.Parameters.AddWithValue("@pais_mod", pais_mod)
                comando.Parameters.AddWithValue("@codigo_mod", codigo_mod)
                comando.Parameters.AddWithValue("@genero_mod", gen_mod)
                comando.ExecuteNonQuery()


                MsgBox("Los cambios han sido guardados", MsgBoxStyle.YesNo, "Operacion exitosa")
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox11.Text = " "
                TextBox13.Text = " "
                cn.Close()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Se limpiaran todos los campos ¿Desea continuar?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox6.Text = " "
            TextBox7.Text = " "
            TextBox8.Text = " "
            TextBox9.Text = " "
            TextBox10.Text = " "
            TextBox11.Text = " "
            TextBox13.Text = " "
        End If

    End Sub

    Private Sub Pagina_ModificarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            ComboBox1.Items.Add("Masculino")
            ComboBox1.Items.Add("Femenino")
        End With
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class