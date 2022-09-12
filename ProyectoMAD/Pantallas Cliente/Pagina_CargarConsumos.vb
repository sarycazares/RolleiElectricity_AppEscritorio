Imports System.IO
Imports ExcelDataReader
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Data.SqlClient
Public Class Pagina_CargarConsumos
    Dim tables As DataTableCollection
    Private Sub Pagina_CargarConsumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Try
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

        Dim fila As DataGridViewRow = New DataGridViewRow()
            Dim datos As DataGridView = DataGridView1

            'comando.CommandType = CommandType.StoredProcedure
            '    comando2.CommandType = CommandType.StoredProcedure
            DT = datos.DataSource

        copiar.ColumnMappings.Add("codigo_reporte", "codigo_reporte")
        copiar.ColumnMappings.Add("consumo_basico", "consumo_basico")
        copiar.ColumnMappings.Add("consumo_intermedio", "consumo_intermedio")
        copiar.ColumnMappings.Add("consumo_excedente", "consumo_excedente")
        copiar.ColumnMappings.Add("numero_medidor", "numero_medidor")
        copiar.ColumnMappings.Add("tipo_consumo", "tipo_consumo")

        copiar.DestinationTableName = "consumo"
                copiar.BulkCopyTimeout = 1500
                MsgBox("Se ha realizado el registro exitosamente", MsgBoxStyle.OkOnly, "Operacion Exitosa")
                copiar.WriteToServer(DT)



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Pagina_GestionCarga.Show()
        Me.Hide()
    End Sub
End Class