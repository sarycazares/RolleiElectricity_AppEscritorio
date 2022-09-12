Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_Pago
    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Pagina_Pago_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Me.Hide()
                Pagina_InicioCliente.Show()
                TextBox5.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "
                TextBox8.Text = " "
                TextBox14.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox13.Text = " "
                TextBox7.Text = " "
                TextBox6.Text = " "

            Else
                e.Cancel = True
            End If
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            Dim cliente_encontrado = False
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            Dim comando As SqlCommand = New SqlCommand("realizar_pago", cn)

            Dim comando2 As SqlCommand = New SqlCommand("unpago", cn)
            comando2.CommandType = CommandType.StoredProcedure
            cn.Open()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim efectivo As Boolean = False
            Dim debito As Boolean = False
            Dim credito As Boolean = False
            Dim transferencia As Boolean = False

            Dim tipo_servicio As String = TextBox15.Text
            Dim total_pago As Single = TextBox5.Text
            Dim adeudo As String = TextBox2.Text
            Dim pago_realizado As String = TextBox1.Text
            Dim forma_de_pago As String
            Dim banco As String
            Dim no_servicio As Single = TextBox8.Text
            Dim no_medidor As Integer = TextBox14.Text
            Dim no_recibo As Integer = TextBox4.Text
            Dim validar_faltante As String = FaltanteBox.Text
            Dim periodo As String = TextBox3.Text

            Dim tempo_pago As String
            Dim tem_falta As Boolean = False

            tempo_pago = TextBox2.Text
            If (tempo_pago > 0) Then
                tem_falta = True
            End If

            If (tem_falta = True) Then
                MsgBox("Favor de presionar volver a pagar", MsgBoxStyle.OkOnly, "Aviso")

            Else

                comando.CommandType = CommandType.StoredProcedure

                If (TextBox2.Text > 0) Then
                    MsgBox("Favor de presionar 'Volver a Pagar' para efectuar otro pago", MsgBoxStyle.OkOnly, "Aviso")
                Else

                    If (RadioButton1.Checked) Then
                        efectivo = True
                    End If
                    If (RadioButton3.Checked) Then
                        debito = True
                    End If
                    If (RadioButton4.Checked) Then
                        credito = True
                    End If
                    If (RadioButton2.Checked) Then
                        transferencia = True
                    End If

                    If (efectivo = True) Then
                        forma_de_pago = "Efectivo"
                        banco = "Pago Efectivo"
                        adeudo = TextBox5.Text - TextBox1.Text


                        comando.Parameters.AddWithValue("@pago_total", total_pago)
                        comando.Parameters.AddWithValue("@adeudo", adeudo)
                        comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                        comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                        comando.Parameters.AddWithValue("@banco", banco)
                        comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                        comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                        comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                        comando.Parameters.AddWithValue("@periodo", periodo)
                        comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                        comando.ExecuteNonQuery()

                        comando2.Parameters.AddWithValue("@numero_recibo", no_recibo)
                        comando2.ExecuteNonQuery()

                        MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                        TextBox5.Text = " "
                        TextBox9.Text = " "
                        TextBox10.Text = " "
                        TextBox2.Text = " "
                        TextBox1.Text = " "
                        TextBox8.Text = " "
                        TextBox14.Text = " "
                        TextBox4.Text = " "
                        TextBox11.Text = " "
                        TextBox12.Text = " "
                        TextBox13.Text = " "
                        TextBox7.Text = " "
                        TextBox6.Text = " "
                    End If

                    If (debito = True) Then
                        forma_de_pago = "Tarjeta de Debito"
                        banco = ComboBox1.Text
                        adeudo = TextBox5.Text - TextBox1.Text


                        comando.Parameters.AddWithValue("@pago_total", total_pago)
                        comando.Parameters.AddWithValue("@adeudo", adeudo)
                        comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                        comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                        comando.Parameters.AddWithValue("@banco", banco)
                        comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                        comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                        comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                        comando.Parameters.AddWithValue("@periodo", periodo)
                        comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                        comando.ExecuteNonQuery()

                        comando2.Parameters.AddWithValue("@numero_recibo", no_recibo)
                        comando2.ExecuteNonQuery()

                        MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                        TextBox5.Text = " "
                        TextBox9.Text = " "
                        TextBox10.Text = " "
                        TextBox2.Text = " "
                        TextBox1.Text = " "
                        TextBox8.Text = " "
                        TextBox14.Text = " "
                        TextBox4.Text = " "
                        TextBox11.Text = " "
                        TextBox12.Text = " "
                        TextBox13.Text = " "
                        TextBox7.Text = " "
                        TextBox6.Text = " "
                    End If
                    '' si el pago es igual a cero pagado = true
                    If (credito = True) Then
                        forma_de_pago = "Tarjeta de Credito"
                        banco = ComboBox2.Text
                        adeudo = TextBox5.Text - TextBox1.Text


                        comando.Parameters.AddWithValue("@pago_total", total_pago)
                        comando.Parameters.AddWithValue("@adeudo", adeudo)
                        comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                        comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                        comando.Parameters.AddWithValue("@banco", banco)
                        comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                        comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                        comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                        comando.Parameters.AddWithValue("@periodo", periodo)
                        comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                        comando.ExecuteNonQuery()

                        comando2.Parameters.AddWithValue("@numero_recibo", no_recibo)
                        comando2.ExecuteNonQuery()

                        MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                        TextBox5.Text = " "
                        TextBox9.Text = " "
                        TextBox10.Text = " "
                        TextBox2.Text = " "
                        TextBox1.Text = " "
                        TextBox8.Text = " "
                        TextBox14.Text = " "
                        TextBox4.Text = " "
                        TextBox11.Text = " "
                        TextBox12.Text = " "
                        TextBox13.Text = " "
                        TextBox7.Text = " "
                        TextBox6.Text = " "
                    End If

                    If (transferencia = True) Then
                        forma_de_pago = "Transferencia"
                        banco = ComboBox3.Text
                        adeudo = TextBox5.Text - TextBox1.Text


                        comando.Parameters.AddWithValue("@pago_total", total_pago)
                        comando.Parameters.AddWithValue("@adeudo", adeudo)
                        comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                        comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                        comando.Parameters.AddWithValue("@banco", banco)
                        comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                        comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                        comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                        comando.Parameters.AddWithValue("@periodo", periodo)
                        comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                        comando.ExecuteNonQuery()

                        comando2.Parameters.AddWithValue("@numero_recibo", no_recibo)
                        comando2.ExecuteNonQuery()

                        MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                        TextBox5.Text = " "
                        TextBox9.Text = " "
                        TextBox10.Text = " "
                        TextBox2.Text = " "
                        TextBox1.Text = " "
                        TextBox8.Text = " "
                        TextBox14.Text = " "
                        TextBox4.Text = " "
                        TextBox11.Text = " "
                        TextBox12.Text = " "
                        TextBox13.Text = " "
                        TextBox7.Text = " "
                        TextBox6.Text = " "
                    End If



                    If (TextBox1.Text > TextBox5.Text) Then
                        MsgBox("No se permite realizar un pago mayor al saldo actual", MsgBoxStyle.OkOnly, "Aviso")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, vuelva a interntarlo", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
            Me.Hide()
            TextBox5.Text = " "
            TextBox9.Text = " "
            TextBox10.Text = " "
            TextBox2.Text = " "
            TextBox1.Text = " "
            TextBox8.Text = " "
            TextBox14.Text = " "
            TextBox4.Text = " "
            TextBox11.Text = " "
            TextBox12.Text = " "
            TextBox13.Text = " "
            TextBox7.Text = " "
            TextBox6.Text = " "
            Pagina_InicioCliente.Show()
        End If
    End Sub

    Private Sub Pagina_Pago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = 0
        With ComboBox1
            ComboBox1.Items.Add("Banorte")
            ComboBox1.Items.Add("Bancomer")
            ComboBox1.Items.Add("Santder")
            ComboBox1.Items.Add("Banamex")
        End With

        TextBox11.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = True

        With ComboBox2
            ComboBox2.Items.Add("Banorte")
            ComboBox2.Items.Add("Bancomer")
            ComboBox2.Items.Add("Santder")
            ComboBox2.Items.Add("Banamex")
        End With

        With ComboBox3
            ComboBox3.Items.Add("Banorte")
            ComboBox3.Items.Add("Bancomer")
            ComboBox3.Items.Add("Santder")
            ComboBox3.Items.Add("Banamex")
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()
            '''''proceso set pagado''''''
            Dim comando As SqlCommand = New SqlCommand("set_pagado", cn)
            comando.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    
            Dim ds2 As DataSet = New DataSet()
            Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
            adaptador2 = New SqlDataAdapter("validar_pago", cn)
            Dim numero_buscado1 = TextBox4.Text
            Dim cliente_encontrado1 = False
            Dim validar_pagoC As String
            Dim validar_faltante As String
            Dim tomar_faltante As String
            Dim revisar_pago As String

            adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador2.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.Int, 10).Value = numero_buscado1
            adaptador2.Fill(ds2, "pago")

            If (ds2.Tables("pago").Rows.Count > 0) Then
                cliente_encontrado1 = True
            End If

            If (cliente_encontrado1 = True) Then
                Me.ValidarBox.Text = ds2.Tables("pago").Rows(0).Item(0)
                Me.FaltanteBox.Text = ds2.Tables("pago").Rows(0).Item(2)
                Me.PagoUno.Text = ds2.Tables("pago").Rows(0).Item(3)
                validar_pagoC = ValidarBox.Text
                validar_faltante = FaltanteBox.Text
                revisar_pago = PagoUno.Text

                If (validar_faltante = 0) Then
                    comando.Parameters.AddWithValue("@numero_recibo", numero_buscado1)
                    comando.ExecuteNonQuery()
                End If

            End If

            If (revisar_pago = "True") Then


                If (validar_pagoC = "False") Then
                    TextBox1.ReadOnly = False
                    MsgBox("Recibo sin pago completo, presione 'Volver a Pagar' para efectuar un nuevo pago", MsgBoxStyle.OkOnly, "Aviso")
                    Me.TextBox2.Text = ds2.Tables("pago").Rows(0).Item(2)

                End If

                If (validar_pagoC = "True") Then
                    MsgBox("Este recibo ha sido pagado", MsgBoxStyle.OkOnly, "Aviso")
                    TextBox1.ReadOnly = True
                End If

            End If





            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim numero_buscado As String = TextBox4.Text
            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("mostrar_recibo", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.Int, 10).Value = numero_buscado
            adaptador.Fill(ds, "recibo")

            If (ds.Tables("recibo").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then

                'datos personales
                Me.TextBox9.Text = ds.Tables("recibo").Rows(0).Item(4)
                Me.TextBox10.Text = ds.Tables("recibo").Rows(0).Item(5)
                Me.TextBox14.Text = ds.Tables("recibo").Rows(0).Item(3)
                Me.TextBox8.Text = ds.Tables("recibo").Rows(0).Item(2)
                Me.TextBox7.Text = ds.Tables("recibo").Rows(0).Item(16)
                Me.TextBox6.Text = ds.Tables("recibo").Rows(0).Item(17)
                Me.TextBox5.Text = ds.Tables("recibo").Rows(0).Item(0)
                Me.TextBox3.Text = ds.Tables("recibo").Rows(0).Item(19)
                Me.TextBox15.Text = ds.Tables("recibo").Rows(0).Item(20)

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.OkOnly, "Aviso")
            End If


        Catch ex As Exception
            MsgBox("No se guardarán cambios ¿Desea cancelar la operación?", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox11.ReadOnly = False
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox11.ReadOnly = True
        TextBox12.ReadOnly = False
        TextBox13.ReadOnly = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox11.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox11.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            Dim cliente_encontrado = False
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            Dim comando As SqlCommand = New SqlCommand("volverapagar", cn)
            cn.Open()

            Dim efectivo As Boolean = False
            Dim debito As Boolean = False
            Dim credito As Boolean = False
            Dim transferencia As Boolean = False


            Dim total_pago As Single = TextBox5.Text
            Dim adeudo As String = TextBox2.Text
            Dim pago_realizado As String = TextBox1.Text
            Dim forma_de_pago As String
            Dim banco As String
            Dim no_servicio As Single = TextBox8.Text
            Dim no_medidor As Integer = TextBox14.Text
            Dim no_recibo As Integer = TextBox4.Text
            Dim validar_faltante As String = FaltanteBox.Text
            Dim periodo As String = TextBox3.Text
            Dim tipo_servicio As String = TextBox15.Text
            Dim tempo_pago As String
            Dim tem_falta As Boolean = False



            comando.CommandType = CommandType.StoredProcedure



            If (RadioButton1.Checked) Then
                efectivo = True
            End If
            If (RadioButton3.Checked) Then
                debito = True
            End If
            If (RadioButton4.Checked) Then
                credito = True
            End If
            If (RadioButton2.Checked) Then
                transferencia = True
            End If

            If (efectivo = True) Then
                forma_de_pago = "Efectivo"
                banco = "Pago Efectivo"
                adeudo = TextBox2.Text - TextBox1.Text
                adeudo = Format(adeudo, "0.00")


                comando.Parameters.AddWithValue("@pago_total", total_pago)
                comando.Parameters.AddWithValue("@adeudo", adeudo)
                comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                comando.Parameters.AddWithValue("@banco", banco)
                comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                comando.Parameters.AddWithValue("@periodo", periodo)
                comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                comando.ExecuteNonQuery()
                MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                TextBox5.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "
                TextBox8.Text = " "
                TextBox14.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox13.Text = " "
                TextBox7.Text = " "
                TextBox6.Text = " "
            End If

            If (debito = True) Then
                forma_de_pago = "Tarjeta de Debito"
                banco = ComboBox1.Text
                adeudo = TextBox2.Text - TextBox1.Text
                adeudo = Format(adeudo, "0.00")

                comando.Parameters.AddWithValue("@pago_total", total_pago)
                comando.Parameters.AddWithValue("@adeudo", adeudo)
                comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                comando.Parameters.AddWithValue("@banco", banco)
                comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                comando.Parameters.AddWithValue("@periodo", periodo)
                comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                comando.ExecuteNonQuery()
                MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                TextBox5.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "
                TextBox8.Text = " "
                TextBox14.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox13.Text = " "
                TextBox7.Text = " "
                TextBox6.Text = " "
            End If
            '' si el pago es igual a cero pagado = true
            If (credito = True) Then
                forma_de_pago = "Tarjeta de Credito"
                banco = ComboBox2.Text
                adeudo = TextBox2.Text - TextBox1.Text
                adeudo = Format(adeudo, "0.00")

                comando.Parameters.AddWithValue("@pago_total", total_pago)
                comando.Parameters.AddWithValue("@adeudo", adeudo)
                comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                comando.Parameters.AddWithValue("@banco", banco)
                comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                comando.Parameters.AddWithValue("@periodo", periodo)
                comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                comando.ExecuteNonQuery()
                MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                TextBox5.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "
                TextBox8.Text = " "
                TextBox14.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox13.Text = " "
                TextBox7.Text = " "
                TextBox6.Text = " "
            End If

            If (transferencia = True) Then
                forma_de_pago = "Transferencia"
                banco = ComboBox3.Text
                adeudo = TextBox2.Text - TextBox1.Text
                adeudo = Format(adeudo, "0.00")

                comando.Parameters.AddWithValue("@pago_total", total_pago)
                comando.Parameters.AddWithValue("@adeudo", adeudo)
                comando.Parameters.AddWithValue("@pago_realizado", pago_realizado)
                comando.Parameters.AddWithValue("@forma_pago", forma_de_pago)
                comando.Parameters.AddWithValue("@banco", banco)
                comando.Parameters.AddWithValue("@no_servicio", no_servicio)
                comando.Parameters.AddWithValue("@no_medidor", no_medidor)
                comando.Parameters.AddWithValue("@no_recibo", no_recibo)
                comando.Parameters.AddWithValue("@periodo", periodo)
                comando.Parameters.AddWithValue("@tipo_servicio", tipo_servicio)
                comando.ExecuteNonQuery()
                MsgBox("Operacion exitosa, se ha realizado su pago", MsgBoxStyle.OkOnly, "Exito")
                TextBox5.Text = " "
                TextBox9.Text = " "
                TextBox10.Text = " "
                TextBox2.Text = " "
                TextBox1.Text = " "
                TextBox8.Text = " "
                TextBox14.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox13.Text = " "
                TextBox7.Text = " "
                TextBox6.Text = " "
            End If



            If (TextBox1.Text > TextBox5.Text) Then
                MsgBox("No se permite realizar un pago mayor al saldo actual", MsgBoxStyle.OkOnly, "Aviso")
            End If

        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class