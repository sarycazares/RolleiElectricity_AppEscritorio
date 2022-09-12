Imports System.Data.SqlClient
Imports System.Data

Public Class Pagina_IniciarSesion
    Public contador As Integer = 0
    Public contador_c As Integer = 0

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Pagina_Informacion.Show()
    End Sub

    Private Sub Pagina_IniciarSesion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("¿Desea salir de la aplicacion?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try

        'Dim temporal_admin_us As String
        'Dim temporal_admin_pas As String

        'temporal_admin_us = TextBox1.Text
        'temporal_admin_us = TextBox2.Text
        'If (temporal_admin_us = "admin" And temporal_admin_us = "admin" Or temporal_admin_us = "ADMIN" And temporal_admin_us = "ADMIN") Then

        '    Pagina_InicioAdmin.Show()
        '    'Else
        '    '    Pagina_InicioCliente.Show()
        'End If

        Dim conexion As String
        conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
        Dim cn As New SqlConnection 'establece conexion
        cn.ConnectionString = conexion 'se establece conexion con la cadena 
        cn.Open()

        Dim nombre_usuario As String = TextBox1.Text
        Dim contra_usuario As String = TextBox2.Text

        Dim valida_us As String
        Dim valida_con As String
        Dim valida_block As String

        Dim us_cliente As String
        Dim con_cliente As String

        Dim permiso As String

        Dim permiso_admin As String = "ADMIN"
        Dim permiso_empleado As String = "EMPLEADO"

        Dim ds As DataSet = New DataSet()
        Dim ds2 As DataSet = New DataSet()
        Dim ds3 As DataSet = New DataSet()
        Dim ds4 As DataSet = New DataSet()

        Dim dataSet1 As DataSet = New DataSet()

        Dim adaptador_empleado_usuario As SqlDataAdapter = New SqlDataAdapter
        Dim adaptador_cliente_usuario As SqlDataAdapter = New SqlDataAdapter
        Dim comando As SqlCommand = New SqlCommand("bloquear_c", cn)
        Dim comando2 As SqlCommand = New SqlCommand("bloquear_e", cn)


        adaptador_empleado_usuario = New SqlDataAdapter("login_empleado", cn)
        adaptador_cliente_usuario = New SqlDataAdapter("login_cliente", cn)


        Dim empleado_encontrado As Boolean = False
        Dim usuario_encontrado As Boolean = False

        adaptador_empleado_usuario.SelectCommand.CommandType = CommandType.StoredProcedure
        adaptador_cliente_usuario.SelectCommand.CommandType = CommandType.StoredProcedure
        comando.CommandType = CommandType.StoredProcedure
        comando2.CommandType = CommandType.StoredProcedure


        adaptador_empleado_usuario.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 10).Value = nombre_usuario
        adaptador_empleado_usuario.SelectCommand.Parameters.Add("@pass", SqlDbType.VarChar, 10).Value = contra_usuario

        adaptador_cliente_usuario.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 10).Value = nombre_usuario
        adaptador_cliente_usuario.SelectCommand.Parameters.Add("@pass", SqlDbType.VarChar, 10).Value = contra_usuario

        adaptador_empleado_usuario.Fill(ds, "usuario_empleado")
        adaptador_cliente_usuario.Fill(ds2, "usuario")

        'adaptador_empleado_contra.Fill(ds3, "usuario_empleado")
        'adaptador_cliente_contra.Fill(ds4, "usuario_cliente")

        'Dim FindRow As DataRow = dataSet1.Tables("usuario_empleado").Rows.Find("ADMIN")
        'Dim FindRow2 As DataRow = dataSet1.Tables("usuario_empleado").Rows.Find("EMPLEADO")
        'encontar forma de tomar variable y ver is es igual a admin


        If (ds.Tables("usuario_empleado").Rows.Count > 0) Then
            Me.TextBox4.Text = ds.Tables("usuario_empleado").Rows(0).Item(0)
            Me.TextBox5.Text = ds.Tables("usuario_empleado").Rows(0).Item(1)
            Me.TextBox6.Text = ds.Tables("usuario_empleado").Rows(0).Item(3)
            Me.TextBox3.Text = ds.Tables("usuario_empleado").Rows(0).Item(2)
            permiso = TextBox3.Text
            empleado_encontrado = True
            valida_us = TextBox1.Text
            valida_con = TextBox2.Text
            valida_block = TextBox6.Text

        End If

        If (ds2.Tables("usuario").Rows.Count > 0) Then
            usuario_encontrado = True
            Me.TextBox4.Text = ds2.Tables("usuario").Rows(0).Item(0)
            Me.TextBox5.Text = ds2.Tables("usuario").Rows(0).Item(1)
            Me.TextBox6.Text = ds2.Tables("usuario").Rows(0).Item(2)
            us_cliente = TextBox4.Text
            con_cliente = TextBox5.Text
            valida_block = TextBox6.Text
        End If


        'hay que hacer un cambio, se tomaran los vlores de los textbox en una variable para comparar si dichos registro existen
        If (empleado_encontrado = True And TextBox4.Text = valida_us And TextBox5.Text = valida_con And permiso = "EMPLEADO" And valida_block = "False") Then
            Me.Hide()
            Pagina_InicioEmpleado.Show()


        ElseIf (empleado_encontrado = True And TextBox4.Text <> valida_us Or TextBox5.Text <> valida_con And permiso = "EMPLEADO" And valida_block = "False") Then
            MsgBox("Usuario o contraseña incorrectas", MsgBoxStyle.OkOnly, "Aviso")
            contador = contador + 1

        ElseIf (empleado_encontrado = True And TextBox4.Text = valida_us And TextBox5.Text = valida_con And permiso = "EMPLEADO" And valida_block = "True") Then
            MsgBox("Usuario bloqueado, contacte con administrador", MsgBoxStyle.OkOnly, "Aviso")

        ElseIf (empleado_encontrado = True And TextBox4.Text <> valida_us Or TextBox5.Text <> valida_con And permiso = "EMPLEADO" And valida_block = "True") Then
            MsgBox("Usuario bloqueado, contacte con administrador", MsgBoxStyle.OkOnly, "Aviso")

        ElseIf (empleado_encontrado = True And TextBox4.Text = valida_us And TextBox5.Text = valida_con And permiso = "ADMIN" And valida_block = "False") Then
            Me.Hide()
            Pagina_InicioAdmin.Show()


        ElseIf (empleado_encontrado = True And TextBox4.Text <> valida_us Or TextBox5.Text <> valida_con And permiso = "ADMIN" And valida_block = "False") Then
            MsgBox("Usuario o contraseña incorrectas", MsgBoxStyle.OkOnly, "Aviso")


        ElseIf (usuario_encontrado = True And TextBox4.Text = us_cliente And TextBox5.Text = con_cliente And valida_block = "False") Then
            Me.Hide()
            Pagina_InicioCliente.Show()


        ElseIf (usuario_encontrado = True And TextBox4.Text <> us_cliente And TextBox5.Text <> con_cliente And valida_block = "False") Then
            MsgBox("Usuario o contraseña incorrectas", MsgBoxStyle.OkOnly, "Aviso")
            contador_c = contador_c + 1

        ElseIf (usuario_encontrado = True And TextBox4.Text = us_cliente And TextBox5.Text = con_cliente And valida_block = "True") Then
            MsgBox("Usuario bloqueado, contacte con soporte tecnico", MsgBoxStyle.OkOnly, "Aviso")

        ElseIf (usuario_encontrado = True And TextBox4.Text <> us_cliente Or TextBox5.Text <> con_cliente And valida_block = "True") Then
            MsgBox("Usuario bloqueado, contacte con soporte tecnico", MsgBoxStyle.OkOnly, "Aviso")

        Else
            MsgBox("Usuario o contraseña no existen", MsgBoxStyle.OkOnly, "Aviso")
        End If

        If (contador >= 3) Then

            comando2.Parameters.AddWithValue("@nom_usuario", nombre_usuario)
            comando2.ExecuteNonQuery()
        End If

        If (contador_c >= 3) Then

            comando.Parameters.AddWithValue("@nom_usuario", nombre_usuario)
            comando.ExecuteNonQuery()
        End If

        'Catch ex As Exception
        '    MsgBox("Ocurrio un error, vuelva a intentarlo ", MsgBoxStyle.OkOnly, "Aviso")
        'End Try
    End Sub

    Private Sub Pagina_IniciarSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.usuario <> "" Then
            TextBox1.Text = My.Settings.usuario

        Else
            TextBox1.Text = ""
        End If

        If My.Settings.contrasena <> "" Then
            TextBox2.Text = My.Settings.contrasena
        Else
            TextBox2.Text = ""
        End If

        My.Settings.usuario_ingress = TextBox1.Text


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Pagina_OlvideContraseña.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.usuario = TextBox1.Text
        My.Settings.contrasena = TextBox2.Text
        My.Settings.Save()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Pagina_InicioAdmin.Show()
        Me.Hide()

    End Sub
End Class