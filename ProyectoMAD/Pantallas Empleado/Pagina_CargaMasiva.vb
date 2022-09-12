Imports System.IO
Imports ExcelDataReader
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_CargaMasiva
    Dim tables As DataTableCollection
    Private Sub Pagina_CargaMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox2.Text
            ComboBox2.Items.Add("Domestico")
            ComboBox2.Items.Add("Industrial")
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Hoja de cálculo de Microsoft Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*"}
            If ofd.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = ofd.FileName
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                     .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                     .UseHeaderRow = True}})
                        tables = result.Tables
                        ComboBox1.Items.Clear()
                        For Each table As DataTable In tables
                            ComboBox1.Items.Add(table.TableName)
                        Next
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dt As DataTable = tables(ComboBox1.SelectedItem.ToString())
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Pagina_InicioEmpleado.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 
            'Dim comando As SqlCommand = New SqlCommand("tarfia_masiva_in", cn)
            'Dim comando2 As SqlCommand = New SqlCommand("tarifa_masiva_dom", cn)

            cn.Open()

            Dim copiar As SqlBulkCopy = New SqlBulkCopy(cn)
            Dim DT As DataTable = New DataTable

            Dim resultado As Boolean = False
            Dim servicio As String = ComboBox2.Text
            Dim fila As DataGridViewRow = New DataGridViewRow()
            Dim datos As DataGridView = DataGridView1

            'comando.CommandType = CommandType.StoredProcedure
            '    comando2.CommandType = CommandType.StoredProcedure
            DT = datos.DataSource

            If (servicio = "Industrial") Then
                'comando.Parameters.AddWithValue("@servicio", servicio)
                'comando.ExecuteNonQuery()
                'MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.OkOnly, "Operacion Exitosa")
                copiar.ColumnMappings.Add("tarifa_basica", "tarifa_basica")
                copiar.ColumnMappings.Add("tarifa_intermedia", "tarifa_intermedia")
                copiar.ColumnMappings.Add("tarifa_excedente", "tarifa_excedente")
                copiar.ColumnMappings.Add("numero_medidor", "numero_medidor")

                copiar.DestinationTableName = "tarifa_in"
                copiar.BulkCopyTimeout = 1500
                MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.OkOnly, "Operacion Exitosa")
                copiar.WriteToServer(DT)

            ElseIf (servicio = "Domestico") Then
                'comando2.Parameters.AddWithValue("@tb", Convert.ToString(fila.Cells("Column1").Value))
                'comando2.Parameters.AddWithValue("@ti", Convert.ToString(fila.Cells("Column2").Value))
                'comando2.Parameters.AddWithValue("@te", Convert.ToString(fila.Cells("Column3").Value))
                'comando2.Parameters.AddWithValue("@no_medidor", Convert.ToString(fila.Cells("Column4").Value))

                'comando2.ExecuteNonQuery()
                copiar.ColumnMappings.Add("tarifa_basica", "tarifa_basica")
                copiar.ColumnMappings.Add("tarifa_intermedia", "tarifa_intermedia")
                copiar.ColumnMappings.Add("tarifa_excedente", "tarifa_excedente")
                copiar.ColumnMappings.Add("numero_medidor", "numero_medidor")
                copiar.DestinationTableName = "tarifa_dom"
                copiar.BulkCopyTimeout = 1500
                MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.OkOnly, "Operacion Exitosa")
                copiar.WriteToServer(DT)

            End If




        Catch ex As Exception
            MsgBox("Ha ocurrido un error con su solicitud", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub
End Class