Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_ReporteGeneral
    Private Sub Pagina_ReporteGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With ComboBox1
            ComboBox1.Items.Add("Domestico")
            ComboBox1.Items.Add("Industrial")
        End With


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Pagina_InicioEmpleado.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim validar_in As Boolean
        Dim validar_dom As Boolean
        Dim validar_servicio As String = ComboBox1.Text

        If (validar_servicio = "Industrial") Then
            validar_in = True
        End If
        If (validar_servicio = "Domestico") Then
            validar_dom = True
        End If

        If (validar_in = True) Then
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

        If (validar_dom) Then
            With ComboBox2
                ComboBox2.Items.Add("Enero - Marzo")
                ComboBox2.Items.Add("Marzo - Mayo")
                ComboBox2.Items.Add("Mayo - Julio")
                ComboBox2.Items.Add("Julio - Septiembre")
                ComboBox2.Items.Add("Septiembre - Noviembre")
                ComboBox2.Items.Add("Noviembre - Enero")
            End With
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Try
        Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()


        Dim periodo_buscado As String = ComboBox2.Text

            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("reporte_general", cn)

            Dim cliente_encontrado As Boolean = False
            Dim contrato_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure


        adaptador.SelectCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 20).Value = periodo_buscado

        adaptador.Fill(ds, "recibo")


            If (ds.Tables("recibo").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then
                DataGridView1.DataSource = ds.Tables("recibo")
                'datos personales

            Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.YesNo, "Aviso")
            End If
        'Catch ex As Exception
        '    MsgBox("Ha habido un problema con su solicitud, vuelva a intentarlo", MsgBoxStyle.YesNo, "Aviso")
        'End Try
    End Sub


End Class