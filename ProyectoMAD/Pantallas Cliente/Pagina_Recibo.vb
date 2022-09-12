Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Pagina_Recibo

    Private Sub Pagina_Recibo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Pagina_InicioCliente.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Pagina_InicioCliente.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conexion As String
            conexion = "Data Source=LAPTOP-6BEIGBHR;Initial Catalog=RolleiDB3;Persist Security Info=True;User ID=sa;Password=zelda050395"
            Dim cn As New SqlConnection 'establece conexion
            cn.ConnectionString = conexion 'se establece conexion con la cadena 

            cn.Open()
            Dim numero_buscado As String = TextBox1.Text
            Dim tempo_servicio As String = TextBox14.Text
            'String numString = New StringBuilder().Append(num).ToString()
            Dim ds2 As DataSet = New DataSet()
            Dim adaptador2 As SqlDataAdapter = New SqlDataAdapter
        adaptador2 = New SqlDataAdapter("mostrar_recibo", cn)
        Dim servicio_encontrado As Boolean = False

            'Dim numString As StringFormat = New StringFormat(numero_buscado)
            Dim ds As DataSet = New DataSet()
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter
            adaptador = New SqlDataAdapter("mostrar_recibo", cn)
            Dim cliente_encontrado As Boolean = False

            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure
            adaptador.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.Int, 10).Value = numero_buscado
        adaptador.Fill(ds, "recibo")

        adaptador2.SelectCommand.CommandType = CommandType.StoredProcedure
        adaptador2.SelectCommand.Parameters.Add("@numero_recibo", SqlDbType.VarChar, 10).Value = numero_buscado
        adaptador2.Fill(ds2, "usuario")

        If (ds.Tables("recibo").Rows.Count > 0) Then
                cliente_encontrado = True
            End If

            If (cliente_encontrado = True) Then

            'datos personales
            Me.TextBox2.Text = ds.Tables("recibo").Rows(0).Item(18)
            Me.TextBox5.Text = ds.Tables("recibo").Rows(0).Item(0)
                Me.TextBox6.Text = ds.Tables("recibo").Rows(0).Item(1)
                Me.TextBox14.Text = ds.Tables("recibo").Rows(0).Item(2)
                Me.TextBox17.Text = ds.Tables("recibo").Rows(0).Item(3)
                Me.TextBox15.Text = ds.Tables("recibo").Rows(0).Item(4)
                Me.TextBox16.Text = ds.Tables("recibo").Rows(0).Item(5)
                Me.TextBox18.Text = ds.Tables("recibo").Rows(0).Item(6)
                Me.TextBox24.Text = ds.Tables("recibo").Rows(0).Item(7)
                Me.TextBox23.Text = ds.Tables("recibo").Rows(0).Item(8)
                Me.TextBox22.Text = ds.Tables("recibo").Rows(0).Item(9)
                Me.TextBox27.Text = ds.Tables("recibo").Rows(0).Item(10)
                Me.TextBox26.Text = ds.Tables("recibo").Rows(0).Item(11)
                Me.TextBox25.Text = ds.Tables("recibo").Rows(0).Item(12)
                Me.TextBox30.Text = ds.Tables("recibo").Rows(0).Item(13)
                Me.TextBox29.Text = ds.Tables("recibo").Rows(0).Item(14)
                Me.TextBox28.Text = ds.Tables("recibo").Rows(0).Item(15)
                Me.TextBox31.Text = ds.Tables("recibo").Rows(0).Item(16)
                Me.TextBox33.Text = ds.Tables("recibo").Rows(0).Item(16)
                Me.TextBox32.Text = ds.Tables("recibo").Rows(0).Item(17)
            Me.TextBox36.Text = ds.Tables("recibo").Rows(0).Item(0)

            Dim t1 As Integer = TextBox24.Text
            Dim t2 As Integer = TextBox23.Text
            Dim t3 As Integer = TextBox22.Text

            TextBox21.Text = t1 + t2 + t3

            Me.TextBox3.Text = ds2.Tables("usuario").Rows(0).Item(21)
            Me.TextBox4.Text = ds2.Tables("usuario").Rows(0).Item(22)
            Me.TextBox7.Text = ds2.Tables("usuario").Rows(0).Item(23)
            Me.TextBox8.Text = ds2.Tables("usuario").Rows(0).Item(24)
            Me.TextBox9.Text = ds2.Tables("usuario").Rows(0).Item(25)
            Me.TextBox10.Text = ds2.Tables("usuario").Rows(0).Item(26)
            Me.TextBox13.Text = ds2.Tables("usuario").Rows(0).Item(27)
            Me.TextBox11.Text = ds2.Tables("usuario").Rows(0).Item(28)
            Me.TextBox12.Text = ds2.Tables("usuario").Rows(0).Item(29)

        Else
                MsgBox("No hay miembros asociados al numero de empleado ingresado", MsgBoxStyle.OkOnly, "Aviso")
            End If



            'If (ds2.Tables("usuario").Rows.Count > 0) Then
            '    servicio_encontrado = True
            'End If

            'If (servicio_encontrado = True) Then
            '    Me.TextBox3.Text = ds2.Tables("usuario").Rows(0).Item(0)
            '    Me.TextBox4.Text = ds2.Tables("usuario").Rows(0).Item(1)
            '    Me.TextBox7.Text = ds2.Tables("usuario").Rows(0).Item(5)
            '    Me.TextBox8.Text = ds2.Tables("usuario").Rows(0).Item(8)
            '    Me.TextBox9.Text = ds2.Tables("usuario").Rows(0).Item(6)
            '    Me.TextBox10.Text = ds2.Tables("usuario").Rows(0).Item(9)
            '    Me.TextBox13.Text = ds2.Tables("usuario").Rows(0).Item(11)
            '    Me.TextBox11.Text = ds2.Tables("usuario").Rows(0).Item(7)
            '    Me.TextBox12.Text = ds2.Tables("usuario").Rows(0).Item(10)

            'End If
        Catch ex As Exception
            MsgBox("Ha habido un problema con su solicitud, intente nuevamente", MsgBoxStyle.OkOnly, "Aviso")
        End Try
    End Sub

    Private Sub Pagina_Recibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox19.Text =
           System.IO.Path.Combine(System.Environment.GetFolderPath(
               Environment.SpecialFolder.Desktop), "ReciboRollei.pdf")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*"
        SaveFileDialog1.Title = "Fichero PDF destino"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox19.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            MsgBox("Debe introducir su numero de recibo a convertir a PDF.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TextBox1.Focus()
        Else
            If TextBox19.Text = "" Then
                MsgBox("Debe indicar el fichero PDF destino de la conversión del texto.",
                       MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                TextBox19.Focus()
            Else
                Try
                    'Creamos el objeto documento PDF
                    Dim documentoPDF As New Document
                    PdfWriter.GetInstance(documentoPDF,
                        New FileStream(TextBox19.Text, FileMode.Create))
                    documentoPDF.Open()

                    Dim Font12N As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
                    Dim Font12B As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD))
                    Dim CVacio As PdfPCell = New PdfPCell(New Phrase(" ",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 5,
                              iTextSharp.text.Font.NORMAL)))
                    CVacio.Border = 0


                    Dim Table1 As PdfPTable = New PdfPTable(4)
                    Dim Columna01 As PdfPCell
                    Dim Columna02 As PdfPCell
                    Dim Columna03 As PdfPCell
                    Dim Columna04 As PdfPCell
                    Dim Columna05 As PdfPCell
                    Dim Columna06 As PdfPCell
                    Dim Columna07 As PdfPCell
                    Dim Columna08 As PdfPCell
                    Table1.WidthPercentage = 80

                    Dim widths As Single() = New Single() {4.0F, 3.0F, 1.0F, 4.0F}
                    Table1.SetWidths(widths)

                    ' TABLA 01 ///////////////////////////////////////////////////////

                    Dim ImagenEncabezado As Image = Image.GetInstance(ProyectoMAD.My.Resources.Resources.EncabezadoRecibo, System.Drawing.Imaging.ImageFormat.Jpeg)
                    'IMAGEN.ScalePercent(16.7)
                    'recibo_pdf.My.Resources.Resources.CodigoQR
                    ImagenEncabezado.ScaleAbsoluteWidth(500)
                    ImagenEncabezado.ScaleAbsoluteHeight(100)
                    documentoPDF.Add(ImagenEncabezado)

                    Table1.AddCell(CVacio)
                    Columna02 = New PdfPCell(New Phrase("NÚMERO DE RECIBO:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table1.AddCell(Columna02)

                    Columna02 = New PdfPCell(New Phrase(TextBox2.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table1.AddCell(Columna02)
                    Table1.AddCell(CVacio)
                    documentoPDF.Add(Table1)

                    ' TABLA 02 ///////////////////////////////////////////////////////
                    Dim Table2 As PdfPTable = New PdfPTable(8)
                    Table2.WidthPercentage = 100
                    Dim widths02 As Single() = New Single() {1.5F, 1.5F, 1.5F, 1.5F, 1.5F, 2.5F, 1.0F, 1.0F}
                    Table2.SetWidths(widths02)

                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("NOMBRE COMPLETO:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Columna05 = New PdfPCell(New Phrase("TOTAL A PAGAR:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.BOLD)))
                    Columna05.Border = 0
                    Table2.AddCell(Columna05)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase(TextBox3.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase(TextBox4.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Columna05 = New PdfPCell(New Phrase(TextBox5.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                              iTextSharp.text.Font.BOLD)))
                    Columna05.Border = 0
                    Table2.AddCell(Columna05)
                    Columna06 = New PdfPCell(New Phrase(TextBox6.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                              iTextSharp.text.Font.BOLD)))
                    Columna06.Border = 0
                    Table2.AddCell(Columna06)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("DIRECCIÓN:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase(TextBox7.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox8.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)

                    Columna03 = New PdfPCell(New Phrase(TextBox9.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna03.Border = 0
                    Table2.AddCell(Columna03)

                    Columna04 = New PdfPCell(New Phrase(TextBox10.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna04.Border = 0
                    Table2.AddCell(Columna04)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase(TextBox13.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox11.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)

                    Columna03 = New PdfPCell(New Phrase(TextBox12.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna03.Border = 0
                    Table2.AddCell(Columna03)

                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("NO.SERVICIO:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox14.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("NO.MEDIDOR:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox17.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("FECHA LIMITE DE PAGO:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox15.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("CORTE A PARTIR DE:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox16.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("PERIODO FACTURADO:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table2.AddCell(Columna01)

                    Columna02 = New PdfPCell(New Phrase(TextBox18.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table2.AddCell(Columna02)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)
                    Table2.AddCell(CVacio)

                    documentoPDF.Add(Table2)

                    ' TABLA 03 ///////////////////////////////////////////////////////

                    Dim Table3 As PdfPTable = New PdfPTable(4)
                    Table3.WidthPercentage = 100
                    Dim widths03 As Single() = New Single() {5.0F, 1.5F, 1.5F, 1.5F}
                    Table3.SetWidths(widths03)


                    Columna01 = New PdfPCell(New Phrase("RECUERDA NO PROPORCIAR TUS DATOS A DESCONOCIDOS, ROLLEI ELECTRICITY JAMÁS TE PEDIRÁ ESE TIPO DE DATOS ¡CUIDALOS MUCHO!",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                              iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                    Columna01.Border = 0
                    Table3.AddCell(Columna01)
                    Table3.AddCell(CVacio)
                    Table3.AddCell(CVacio)
                    Table3.AddCell(CVacio)
                    documentoPDF.Add(Table3)


                    Dim ImagenLinea As Image = Image.GetInstance(ProyectoMAD.My.Resources.Resources.Linea, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ImagenLinea.ScaleAbsoluteWidth(500)
                    ImagenLinea.ScaleAbsoluteHeight(25)
                    documentoPDF.Add(ImagenLinea)

                    ' TABLA 04 ///////////////////////////////////////////////////////

                    Dim Table4 As PdfPTable = New PdfPTable(7)
                    Table4.WidthPercentage = 100
                    Dim widths04 As Single() = New Single() {2.0F, 2.0F, 1.0F, 2.0F, 1.0F, 2.0F, 2.0F}
                    Table4.SetWidths(widths04)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("CONCEPTO",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table4.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase("LECTURA ACTUAL",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table4.AddCell(Columna02)
                    Table4.AddCell(CVacio)
                    Columna04 = New PdfPCell(New Phrase("TOTAL PERIODO",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna04.Border = 0
                    Table4.AddCell(Columna04)
                    Table4.AddCell(CVacio)
                    Columna06 = New PdfPCell(New Phrase("PRECIO (MXN)",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna06.Border = 0
                    Table4.AddCell(Columna06)
                    Columna07 = New PdfPCell(New Phrase("SUBTOTAL (MXN)",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna07.Border = 0
                    Table4.AddCell(Columna07)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("BASICO",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table4.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase(TextBox21.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table4.AddCell(Columna02)
                    Columna03 = New PdfPCell(New Phrase("KW",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna03.Border = 0
                    Table4.AddCell(Columna03)
                    Columna04 = New PdfPCell(New Phrase(TextBox24.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna04.Border = 0
                    Table4.AddCell(Columna04)
                    Columna05 = New PdfPCell(New Phrase("KW",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna05.Border = 0
                    Table4.AddCell(Columna05)
                    Columna06 = New PdfPCell(New Phrase(TextBox27.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna06.Border = 0
                    Table4.AddCell(Columna06)
                    Columna07 = New PdfPCell(New Phrase(TextBox30.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna07.Border = 0
                    Table4.AddCell(Columna07)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("INTERMEDIO",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table4.AddCell(Columna01)
                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Columna04 = New PdfPCell(New Phrase(TextBox23.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna04.Border = 0
                    Table4.AddCell(Columna04)
                    Columna05 = New PdfPCell(New Phrase("KW",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna05.Border = 0
                    Table4.AddCell(Columna05)
                    Columna06 = New PdfPCell(New Phrase(TextBox26.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna06.Border = 0
                    Table4.AddCell(Columna06)
                    Columna07 = New PdfPCell(New Phrase(TextBox29.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna07.Border = 0
                    Table4.AddCell(Columna07)

                    ' OTRA COLUMNA
                    Columna01 = New PdfPCell(New Phrase("SUMA",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table4.AddCell(Columna01)
                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Columna04 = New PdfPCell(New Phrase(TextBox22.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna04.Border = 0
                    Table4.AddCell(Columna04)
                    Columna05 = New PdfPCell(New Phrase("KW",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna05.Border = 0
                    Table4.AddCell(Columna05)
                    Columna06 = New PdfPCell(New Phrase(TextBox25.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna06.Border = 0
                    Table4.AddCell(Columna06)
                    Columna07 = New PdfPCell(New Phrase(TextBox28.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna07.Border = 0
                    Table4.AddCell(Columna07)

                    ' OTRA COLUMNA


                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Table4.AddCell(CVacio)
                    Columna06 = New PdfPCell(New Phrase("SUBTOTAL",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.BOLD)))
                    Columna06.Border = 0
                    Table4.AddCell(Columna06)
                    Columna07 = New PdfPCell(New Phrase(TextBox31.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                              iTextSharp.text.Font.BOLD)))
                    Columna07.Border = 0
                    Table4.AddCell(Columna07)

                    documentoPDF.Add(Table4)

                    Dim ImagenLinea02 As Image = Image.GetInstance(ProyectoMAD.My.Resources.Resources.Linea, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ImagenLinea02.ScaleAbsoluteWidth(500)
                    ImagenLinea02.ScaleAbsoluteHeight(25)
                    documentoPDF.Add(ImagenLinea02)

                    ' TABLA 05 ///////////////////////////////////////////////////////

                    Dim Table5 As PdfPTable = New PdfPTable(7)
                    Table5.WidthPercentage = 100
                    Dim widths05 As Single() = New Single() {2.0F, 2.0F, 2.0F, 2.0F, 1.0F, 2.0F, 1.0F}
                    Table5.SetWidths(widths05)

                    ' OTRA COLUMNA

                    Columna01 = New PdfPCell(New Phrase("DESGLOSE DE IMPORTE A PAGAR",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table5.AddCell(Columna01)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)

                    ' OTRA COLUMNA

                    Columna01 = New PdfPCell(New Phrase("CONCEPTO",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table5.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase("IMPORTE (MXN)",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table5.AddCell(Columna02)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)



                    ' OTRA COLUMNA

                    Columna01 = New PdfPCell(New Phrase("SUBTOTAL:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table5.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase(TextBox33.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table5.AddCell(Columna02)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)

                    ' OTRA COLUMNA

                    Columna01 = New PdfPCell(New Phrase("IVA 16%:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.NORMAL)))
                    Columna01.Border = 0
                    Table5.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase(TextBox32.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA, 12,
                              iTextSharp.text.Font.NORMAL)))
                    Columna02.Border = 0
                    Table5.AddCell(Columna02)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)

                    ' OTRA COLUMNA



                    Columna01 = New PdfPCell(New Phrase("TOTAL:",
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                              iTextSharp.text.Font.BOLD)))
                    Columna01.Border = 0
                    Table5.AddCell(Columna01)
                    Columna02 = New PdfPCell(New Phrase(TextBox36.Text,
                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                              iTextSharp.text.Font.BOLD)))
                    Columna02.Border = 0
                    Table5.AddCell(Columna02)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)
                    Table5.AddCell(CVacio)

                    documentoPDF.Add(Table5)

                    Dim ImagenPieDePagina As Image = Image.GetInstance(ProyectoMAD.My.Resources.Resources.codigoBarras01, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ImagenPieDePagina.ScaleAbsoluteWidth(500)
                    ImagenPieDePagina.ScaleAbsoluteHeight(100)
                    documentoPDF.Add(ImagenPieDePagina)


                    Dim ImagenPromocional As Image = Image.GetInstance(ProyectoMAD.My.Resources.Resources.CodigoQR, System.Drawing.Imaging.ImageFormat.Jpeg)
                    ImagenPromocional.ScaleAbsoluteWidth(150)
                    ImagenPromocional.ScaleAbsoluteHeight(150)
                    ImagenPromocional.SetAbsolutePosition(350, 450)
                    documentoPDF.Add(ImagenPromocional)


                    'Añadimos los metadatos para el fichero PDF
                    documentoPDF.AddAuthor("Rollei Electricity Recibo")
                    documentoPDF.AddCreator("Rollei Electricity Company")
                    documentoPDF.AddSubject(TextBox3.Text)
                    documentoPDF.AddTitle("Recibo Rollei Electricity")
                    documentoPDF.AddCreationDate()
                    'Cerramos el objeto documento, guardamos y creamos el PDF
                    documentoPDF.Close()
                    'Comprobamos si se ha creado el fichero PDF
                    If System.IO.File.Exists(TextBox19.Text) Then
                        If MsgBox("Su recibo se ha convertido a fichero PDF correctamente " +
                               "¿desea abrir el fichero PDF resultante?",
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            'Abrimos el fichero PDF con la aplicación asociada
                            System.Diagnostics.Process.Start(TextBox19.Text)
                        End If
                    Else
                        MsgBox("El fichero PDF no se ha generado, " +
                               "compruebe que tiene permisos en la carpeta de destino.",
                               MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                    End If
                Catch ex As Exception
                    MsgBox("Se ha producido un error al intentar convertir el texto a PDF: " +
                        vbCrLf + vbCrLf + ex.Message,
                        MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End Try
            End If
        End If
    End Sub
End Class