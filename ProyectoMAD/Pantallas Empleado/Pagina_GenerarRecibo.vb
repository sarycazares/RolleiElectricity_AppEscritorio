Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_GenerarRecibo
    Private Sub Pagina_GenerarRecibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pagina_GnerarRecibo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioEmpleado.Show()
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
        Dim comando As SqlCommand = New SqlCommand("guardar_recibo", cn)

        cn.Open()
        'Try
        Dim val1 As String = TextBox24.Text
        Dim val2 As String = TextBox26.Text
        Dim val5 As String = TextBox18.Text
        Dim val6 As String = TextBox19.Text
        Dim val7 As String = TextBox20.Text
        Dim val8 As String = TextBox14.Text
        Dim val9 As String = TextBox27.Text
        Dim val10 As String = TextBox13.Text
        Dim val11 As String = TextBox15.Text
        Dim val12 As String = TextBox16.Text
        Dim val13 As String = TextBox17.Text
        Dim val14 As String = TextBox25.Text



        Dim t_subtotal As String = TextBox24.Text
        Dim total As String = TextBox26.Text

        Dim emi_date As String = DateTimePicker1.Text
        Dim pago_date As String = DateTimePicker2.Text
        Dim corte_date As String = DateTimePicker3.Text

        Dim c_basico As String = TextBox18.Text
        Dim c_medio As String = TextBox19.Text
        Dim c_excedente As String = TextBox20.Text

        Dim tipo_servicio As String = TextBox14.Text
        Dim no_recibo As String = TextBox27.Text
        Dim servicio As String = TextBox13.Text
        Dim t_basico As String = TextBox15.Text
        Dim t_medio As String = TextBox16.Text
        Dim t_excedente As String = TextBox17.Text
        Dim impuesto = TextBox25.Text
        Dim pago_letra = TextBox31.Text
        Dim periodo = ComboBox2.Text
        Dim numero_medidor = ComboBox1.Text
        Dim sub_b = TextBox21.Text
        Dim sub_i = TextBox22.Text
        Dim sub_e = TextBox23.Text

        comando.CommandType = CommandType.StoredProcedure
        If (val1 = "" Or val2 = "" Or val5 = "" Or val6 = "" Or val7 = "" Or val8 = "" Or val9 = "" Or val10 = "" Or val11 = "" Or val12 = "" Or val13 = "" Or val14 = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.YesNo, "Aviso")
        Else
            comando.Parameters.AddWithValue("@t_subtotal", t_subtotal)
            comando.Parameters.AddWithValue("@total", total)
            comando.Parameters.AddWithValue("@emi_date", emi_date)
            comando.Parameters.AddWithValue("@pago_date", pago_date)
            comando.Parameters.AddWithValue("@corte_date", corte_date)
            comando.Parameters.AddWithValue("@c_basico", c_basico)
            comando.Parameters.AddWithValue("@c_medio", c_medio)
            comando.Parameters.AddWithValue("@c_excedente", c_excedente)
            comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
            comando.Parameters.AddWithValue("@no_recibo", no_recibo)
            comando.Parameters.AddWithValue("@servicio", servicio)
            comando.Parameters.AddWithValue("@t_basico", t_basico)
            comando.Parameters.AddWithValue("@t_medio", t_medio)
            comando.Parameters.AddWithValue("@t_excedente", t_excedente)
            comando.Parameters.AddWithValue("@impuesto", impuesto)
            comando.Parameters.AddWithValue("@precio_letra", pago_letra)
            comando.Parameters.AddWithValue("@periodo", periodo)
            comando.Parameters.AddWithValue("@no_medidor", numero_medidor)
            comando.Parameters.AddWithValue("@sub_b", sub_b)
            comando.Parameters.AddWithValue("@sub_i", sub_i)
            comando.Parameters.AddWithValue("@sub_e", sub_e)


            comando.ExecuteNonQuery()

            If MsgBox("Se ha registrado el recibo exitosamente", MsgBoxStyle.YesNo, "Operacion Exitosa") = MsgBoxResult.Yes Then
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
                TextBox19.Text = " "
                TextBox31.Text = " "

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
            TextBox1.Text = " "
            TextBox30.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
            TextBox5.Text = " "
            'datos domicilio
            TextBox6.Text = " "
            TextBox7.Text = " "
            TextBox8.Text = " "
            TextBox9.Text = " "
            TextBox10.Text = " "
            TextBox11.Text = " "
            TextBox12.Text = " "
            TextBox14.Text = " "
            TextBox15.Text = " "
            TextBox16.Text = " "
            TextBox18.Text = " "
            TextBox19.Text = " "
            TextBox20.Text = " "
            TextBox17.Text = " "
            TextBox21.Text = " "
            TextBox22.Text = " "
            TextBox23.Text = " "
            TextBox24.Text = " "
            TextBox25.Text = " "
            TextBox26.Text = " "
            TextBox27.Text = " "

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Try
        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()


            Dim numero_buscado As String = TextBox13.Text

            'String numString = New StringBuilder().Append(num).ToString()

            'Dim numString As StringFormat = New StringFormat(numero_buscado)
            Dim ds As DataSet = New DataSet()
            Dim ds2 As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("buscar_cliente", cn)
            adaptador2 = New SqlDataAdapter("buscar_contratos", cn)
            Dim cliente_encontrado As Boolean = False
            Dim contrato_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand.Parameters.Add("@numero_servicio", SqlDbType.Int, 10).Value = numero_buscado

            adaptador.Fill(ds, "usuario")

            adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure

        adaptador2.SelectCommand.Parameters.Add("@numero_servicio", SqlDbType.Int, 10).Value = numero_buscado

        adaptador2.Fill(ds2, "contrato")

            If (ds.Tables("usuario").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (ds2.Tables("contrato").Rows.Count > 0) Then
                contrato_encontrado = True
            End If

            If (cliente_encontrado = True) Then

                'datos personales
                Me.TextBox1.Text = ds.Tables("usuario").Rows(0).Item(0)
                Me.TextBox30.Text = ds.Tables("usuario").Rows(0).Item(1)
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

                If (contrato_encontrado = True) Then
                    ComboBox1.DataSource = ds2.Tables(0)
                    ComboBox1.DisplayMember = "numero_medidor"

                Else
                    MsgBox("No hay contratos asociados al numero de servicio ingresado", MsgBoxStyle.YesNo, "Aviso")
                End If

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If
        'Catch ex As Exception
        '    MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Todos los cmapos quedaran en blanco ¿Desea continuar?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            TextBox6.Text = " "
            TextBox7.Text = " "
            TextBox8.Text = " "
            TextBox9.Text = " "
            TextBox10.Text = " "
            TextBox11.Text = " "
            TextBox12.Text = " "
            TextBox14.Text = " "
            TextBox15.Text = " "
            TextBox16.Text = " "
            TextBox18.Text = " "
            TextBox19.Text = " "
            TextBox20.Text = " "
            TextBox17.Text = " "
            TextBox21.Text = " "
            TextBox22.Text = " "
            TextBox23.Text = " "
            TextBox24.Text = " "
            TextBox25.Text = " "
            TextBox26.Text = " "
            TextBox27.Text = " "
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Try
        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()
            Dim verificar_i As Boolean = False
        Dim verificar_d As Boolean = False
        Dim val_serv As String = TextBox28.Text

        Dim hay_tarifa As Boolean = False
            Dim tarifa_i As Boolean = False
            Dim tarifa_d As Boolean = False

            Dim numero_buscado As String = ComboBox1.Text
        Dim validar_contrato As String = TextBox14.Text
        ''carga y verifica si hay medidor''
        Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("cargar_contrato", cn)
            Dim numero_encontrado As Boolean = False
            ''carga y verifica coicnidencia de tarifa domestica
            Dim ds2 As DataSet = New DataSet()
            Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
        adaptador2 = New SqlDataAdapter("buscart_domestico", cn)
        Dim numero_encontrado2 As Boolean = False
            ''carga y verifica coicnidencia de tarifa industrial
            Dim ds3 As DataSet = New DataSet()
            Dim adaptador3 As SqlDataAdapter = New SqlDataAdapter
            adaptador3 = New SqlDataAdapter("buscartarifa_industrial", cn)
            Dim numero_encontrado3 As Boolean = False

            ''para contrat0
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@numero_medidor", SqlDbType.Int, 15).Value = numero_buscado
            adaptador.Fill(ds, "contrato")
        ''para industrial
        adaptador3.SelectCommand.CommandType = CommandType.StoredProcedure
        adaptador3.SelectCommand.Parameters.Add("@numero_medidor", SqlDbType.Int, 15).Value = numero_buscado
        adaptador3.Fill(ds3, "tarifa_in")
        ''para domestico
        adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
        adaptador2.SelectCommand.Parameters.Add("@numero_medidor", SqlDbType.Int, 15).Value = numero_buscado
        adaptador2.Fill(ds2, "tarifa_dom")

        If (ds.Tables("contrato").Rows.Count > 0) Then
            numero_encontrado = True
            ''busca si hay t industrial
            'If (numero_encontrado = True) Then
            If (ds3.Tables("tarifa_in").Rows.Count > 0) Then
                    tarifa_i = True
                End If
                ''sino, busca que haya t domestica
                'If (numero_encontrado = True) Then
                If (ds2.Tables("tarifa_dom").Rows.Count > 0) Then
                        tarifa_d = True
                    End If
                'End If
                'End If
            End If


        ''el cliente existe y encontro tarifa industrial
        If (numero_encontrado = True And tarifa_i = True And tarifa_d = False) Then

            'datos personales
            Me.TextBox14.Text = ds.Tables("contrato").Rows(0).Item(0)
            Me.TextBox15.Text = ds3.Tables("tarifa_in").Rows(0).Item(0)
            Me.TextBox16.Text = ds3.Tables("tarifa_in").Rows(0).Item(1)
            Me.TextBox17.Text = ds3.Tables("tarifa_in").Rows(0).Item(2)

        ElseIf (numero_encontrado = True And tarifa_i = False And tarifa_d = True) Then

            Me.TextBox14.Text = ds.Tables("contrato").Rows(0).Item(0)
            Me.TextBox15.Text = ds2.Tables("tarifa_dom").Rows(0).Item(0)
            Me.TextBox16.Text = ds2.Tables("tarifa_dom").Rows(0).Item(1)
            Me.TextBox17.Text = ds2.Tables("tarifa_dom").Rows(0).Item(2)

        ElseIf (numero_encontrado = True And tarifa_i = False And tarifa_d = False) Then

            MsgBox("El contrato no cuenta con tarifa cargada, genere tarifa unitaria o contacte con administrador", MsgBoxStyle.YesNo, "Aviso")

        ElseIf (numero_encontrado = False And tarifa_i = False And tarifa_d = False) Then

            MsgBox("No existe contrato o tarifa asociados a numero de servicio", MsgBoxStyle.YesNo, "Aviso")

            End If


        If (validar_contrato = "Industrial") Then
                verificar_i = True

            End If

            If (validar_contrato = "Domestico") Then
                verificar_d = True

            End If

            '' carga los combos de acuerdo al tipo de contrato 
            If (verificar_i = True) Then
                With ComboBox2
                    ComboBox2.Items.Add("Enero - Febrero")
                    ComboBox2.Items.Add("Febrero - Marzo")
                    ComboBox2.Items.Add("Marzo - Abril")
                    ComboBox2.Items.Add("Abril - Mayo")
                    ComboBox2.Items.Add("Mayo - Junio")
                    ComboBox2.Items.Add("Junio - Julio")
                    ComboBox2.Items.Add("Julio - Agosto")
                    ComboBox2.Items.Add("Agosto - Septiembre")
                    ComboBox2.Items.Add("Septiembre - Octubre")
                    ComboBox2.Items.Add("Octubre - Noviembre")
                    ComboBox2.Items.Add("Novimebre - Diciembre")
                    ComboBox2.Items.Add("Diciembre - Enero")
                End With
            End If
            If (verificar_d = True) Then
                With ComboBox2
                    ComboBox2.Items.Add("Enero - Marzo")
                    ComboBox2.Items.Add("Marzo - Mayo")
                    ComboBox2.Items.Add("Mayo - Julio")
                    ComboBox2.Items.Add("Julio - Septiembre")
                    ComboBox2.Items.Add("Septiembre - Noviembre")
                    ComboBox2.Items.Add("Noviembre - Enero")
                End With
            End If




        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim c_basica As Single = TextBox18.Text
            Dim c_intermedia As Single = TextBox19.Text
            Dim c_excedente As Single = TextBox20.Text
            Dim t_basica As Single = TextBox15.Text
            Dim t_intermedia As Single = TextBox16.Text
            Dim t_excedente As Single = TextBox17.Text
            Dim sub_basica As Single
            Dim sub_intermedia As Single
            Dim sub_excedente As Single
            Dim sumatoria_sub As Single
            Dim impuesto As Single = 0.16
            Dim impuesto_ap As Single
            Dim total As Single


            sub_basica = c_basica * t_basica
            sub_intermedia = c_intermedia * t_intermedia
            sub_excedente = c_excedente * t_excedente
            sumatoria_sub = sub_basica + sub_intermedia + sub_excedente
            impuesto_ap = sumatoria_sub * impuesto
            total = sumatoria_sub + impuesto_ap

            TextBox21.Text = sub_basica
            TextBox22.Text = sub_intermedia
            TextBox23.Text = sub_excedente
            TextBox24.Text = sumatoria_sub
            impuesto_ap = Format(impuesto_ap, "0.00")
            TextBox25.Text = impuesto_ap

            total = Format(total, "0.00")
            'total = Math.Round(total)

            TextBox26.Text = total


            TextBox31.Text = Letras.Letras(total)
            'TextBox31.Text = Format(conversion, "/100 M.N")

        Catch ex As Exception

        End Try
    End Sub

End Class