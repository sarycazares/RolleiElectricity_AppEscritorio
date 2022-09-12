Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_ReporteHistorico
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()

            Dim numero_buscado As String = TextBox1.Text
            Dim numerobase As String

            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("mostrar_historico", cn)
            Dim cliente_encontrado As Boolean = False

            Dim ds2 As DataSet = New DataSet()
            Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
            adaptador2 = New SqlDataAdapter("mostrar_historico", cn)
            Dim servicio_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@numero_servicio", SqlDbType.VarChar, 10).Value = numero_buscado
            adaptador.Fill(ds, "recibo")

            'adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
            'adaptador2.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.VarChar, 10).Value = numero_buscado
            'adaptador2.Fill(ds2, "pago")

            If (ds.Tables("recibo").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then
                Me.TextBox2.Text = ds.Tables("recibo").Rows(0).Item(0)
                numerobase = TextBox2.Text
                If (numero_buscado = numerobase) Then
                    DataGridView1.DataSource = ds.Tables("recibo")
                Else
                    MsgBox("El numero de servicio ingresado no coincide con su contrato", MsgBoxStyle.OkOnly, "Aviso")
                End If

            End If
        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Pagina_InicioCliente.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            cn.Open()

            Dim numero_buscado As String = TextBox3.Text

            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("mostrar_historico_medidor", cn)
            Dim cliente_encontrado As Boolean = False

            'Dim ds2 As DataSet = New DataSet()
            'Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
            'adaptador2 = New SqlDataAdapter("mostrar_historico_medidor", cn)
            'Dim servicio_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@numero_medidor", SqlDbType.VarChar, 30).Value = numero_buscado
            adaptador.Fill(ds, "recibo")

            'adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
            'adaptador2.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.VarChar, 10).Value = numero_buscado
            'adaptador2.Fill(ds2, "pago")

            If (ds.Tables("recibo").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then

                DataGridView1.DataSource = ds.Tables("recibo")

            End If
        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Pagina_ReporteHistorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        With ComboBox1
            ComboBox1.Items.Add("Enero - Marzo")
            ComboBox1.Items.Add("Marzo - Mayo")
            ComboBox1.Items.Add("Mayo - Julio")
            ComboBox1.Items.Add("Julio - Septiembre")
            ComboBox1.Items.Add("Septiembre - Noviembre")
            ComboBox1.Items.Add("Noviembre - Enero")
        End With
    End Sub
End Class