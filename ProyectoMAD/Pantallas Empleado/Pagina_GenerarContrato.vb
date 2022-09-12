Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_GenerarContrato
    Private Sub Pagina_GenerarContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            ComboBox1.Items.Add("Domestico")
            ComboBox1.Items.Add("Industrial")
        End With
    End Sub

    Private Sub Pagina_GenerarContrato_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioEmpleado.Show()
                TextBox13.Text = " "
                TextBox1.Text = " "
                TextBox2.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox5.Text = " "
                TextBox11.Text = " "
                TextBox6.Text = " "
                TextBox7.Text = " "
                TextBox8.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox12.Text = " "
                TextBox14.Text = " "
                TextBox15.Text = " "
                TextBox16.Text = " "
                TextBox17.Text = " "
                TextBox18.Text = " "

            Else
                e.Cancel = True
            End If
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As String
        conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        Dim cn As New SqlConnection 'establece conexion
        cn.ConnectionString = conexion 'se establece conexion con la cadena 
        Dim comando As SqlCommand = New SqlCommand("insertar_contrato", cn)

        cn.Open()
        'Try
        Dim val1 As String = TextBox14.Text


            Dim numero_servicio As Integer = TextBox13.Text
            Dim numero_medidor As String = TextBox14.Text
            Dim contrato As String = ComboBox1.Text
            Dim tb As String = TextBox15.Text
            Dim ti As String = TextBox16.Text
            Dim te As String = TextBox17.Text

            comando.CommandType = CommandType.StoredProcedure
            If (val1 = "") Then
                MsgBox("No deje campos en blanco", MsgBoxStyle.YesNo, "Aviso")
            Else
                comando.Parameters.AddWithValue("@numero_medidor", numero_medidor)
                comando.Parameters.AddWithValue("@contrato", contrato)
                comando.Parameters.AddWithValue("@numero_servicio", numero_servicio)



                comando.ExecuteNonQuery()

                If MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.YesNo, "Operacion Exitosa") = MsgBoxResult.Yes Then
                    Me.Hide()
                    TextBox13.Text = " "
                    TextBox1.Text = " "
                    TextBox2.Text = " "
                    TextBox3.Text = " "
                    TextBox4.Text = " "
                    TextBox5.Text = " "
                    TextBox11.Text = " "
                    TextBox6.Text = " "
                    TextBox7.Text = " "
                    TextBox8.Text = " "
                    TextBox9.Text = " "
                    TextBox10.Text = " "
                    TextBox12.Text = " "
                    TextBox14.Text = " "
                    TextBox15.Text = " "
                    TextBox16.Text = " "
                    TextBox17.Text = " "
                    TextBox18.Text = " "


                    Pagina_InicioEmpleado.Show()
                End If
            End If
        'Catch ex As Exception
        '    MsgBox("Ha habido un error con su solicitud, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            Pagina_InicioEmpleado.Show()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("se limpiaran todos los campos ¿Desea continuar?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            TextBox13.Text = " "
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox5.Text = " "
            TextBox11.Text = " "
            TextBox6.Text = " "
            TextBox7.Text = " "
            TextBox8.Text = " "
            TextBox9.Text = " "
            TextBox10.Text = " "
            TextBox12.Text = " "
            TextBox14.Text = " "
            TextBox15.Text = " "
            TextBox16.Text = " "
            TextBox17.Text = " "
            TextBox18.Text = " "

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()


            Dim numero_buscado As String = TextBox13.Text

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

                'datos personales
                Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(0)
                Me.TextBox18.Text = ds.Tables("usuario").Rows(0).Item(1)
                Me.TextBox2.Text = ds.Tables("usuario").Rows(0).Item(2)
                Me.TextBox3.Text = ds.Tables("usuario").Rows(0).Item(3)
                Me.TextBox4.Text = ds.Tables("usuario").Rows(0).Item(4)
                Me.TextBox5.Text = ds.Tables("usuario").Rows(0).Item(12)
                'datos domicilio
                Me.TextBox6.Text = ds.Tables("usuario").Rows(0).Item(5)
                Me.TextBox7.Text = ds.Tables("usuario").Rows(0).Item(8)
                Me.TextBox8.Text = ds.Tables("usuario").Rows(0).Item(6)
                Me.TextBox9.Text = ds.Tables("usuario").Rows(0).Item(9)
                Me.TextBox10.Text = ds.Tables("usuario").Rows(0).Item(7)
                Me.TextBox11.Text = ds.Tables("usuario").Rows(0).Item(11)
                Me.TextBox12.Text = ds.Tables("usuario").Rows(0).Item(10)

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)



        'Try
        '    Dim conexion As String
        '    conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        '    Dim cn As New SqlConnection 'establece conexion
        '    cn.ConnectionString = conexion 'se establece conexion con la cadena 

        '    cn.Open()

        '    Dim servicio As String = ComboBox1.Text

        '    Dim ds As DataSet = New DataSet()
        '    Dim ds2 As DataSet = New DataSet()
        '    Dim adaptador As SqlDataAdapter = New SqlDataAdapter
        '    Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
        '    adaptador = New SqlDataAdapter("buscartarifa_domestico", cn)
        '    adaptador2 = New SqlDataAdapter("buscartarifa_industrial", cn)
        '    Dim indiceI_encontrado As Boolean = False
        '    Dim indiceD_encontrado As Boolean = False

        '    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
        '    adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure

        '    adaptador.SelectCommand.Parameters.Add("@numero_indice", SqlDbType.Int, 10).Value = numero_buscado
        '    adaptador2.SelectCommand.Parameters.Add("@numero_indice", SqlDbType.Int, 10).Value = numero_buscado

        '    adaptador.Fill(ds, "tarifa_basica")
        '    adaptador2.Fill(ds2, "tarifa_industrial")

        '    If (ds.Tables("tarifa_basica").Rows.Count > 0) Then
        '        indiceD_encontrado = True
        '    End If

        '    If (indiceD_encontrado = True And servicio = "Domestico") Then

        '        'datos personales
        '        Me.TextBox15.Text = ds.Tables("tarifa_basica").Rows(0).Item(0)
        '        Me.TextBox16.Text = ds.Tables("tarifa_basica").Rows(0).Item(1)
        '        Me.TextBox17.Text = ds.Tables("tarifa_basica").Rows(0).Item(2)

        '    ElseIf (ds2.Tables("tarifa_industrial").Rows.Count > 0) Then

        '        indiceI_encontrado = True


        '        If (indiceD_encontrado = True And servicio = "Industrial") Then

        '            'datos personales
        '            Me.TextBox15.Text = ds2.Tables("tarifa_industrial").Rows(0).Item(0)
        '            Me.TextBox16.Text = ds2.Tables("tarifa_industrial").Rows(0).Item(1)
        '            Me.TextBox17.Text = ds2.Tables("tarifa_industrial").Rows(0).Item(2)

        '        Else
        '        MsgBox("No hay miembros asociados al indice marcado", MsgBoxStyle.YesNo, "Aviso")
        '    End If


        '    Else
        '        MsgBox("No hay miembros asociados al indice marcado", MsgBoxStyle.YesNo, "Aviso")
        '    End If
        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'Catch ex As Exception
        '    MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub
End Class