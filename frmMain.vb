Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmMain
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim oExcel As Excel.Application
        'Start an excel object
        oExcel = CreateObject("Excel.Application")

        Dim oWorkbook As Excel.Workbook
        Dim oWorksheet As Excel.Worksheet = Nothing

        oWorkbook = oExcel.Workbooks.Open(txtInputFile.Text)

        Cursor = Cursors.WaitCursor

        For Each oWorksheet In oWorkbook.Sheets
            InsertRules(oWorksheet)
        Next

        lblProgressBar.Text = "Rules import Complete!"

        'Close and exit Excel
        oWorkbook.Close(True)
        oExcel.Quit()

        'release all COM objects
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
        oWorksheet = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
        oWorkbook = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel)
        oExcel = Nothing

        GC.Collect()

        Cursor = Cursors.Default
    End Sub

    Public Function InsertRules(ByVal oWorksheet As Excel.Worksheet) As Integer
        Try
            Dim oCell As Excel.Range
            Dim intFor As Integer = 2
            Dim intRows As Integer = 0
            Dim NumberOfRowsUpdated As Integer = 0
            Dim strRuleInsert As String = ""
            Dim strRule As String = ""
            Dim strRuleDescription As String = ""
            Dim strRuleSubSection As String = ""
            Dim strRuleSubSectionDescription As String = ""
            Dim strTOCRulesScreen As String = ""
            Dim arrTOCRules As String() = Nothing

            'make sure there is at least on row of data but skip first row since it should be header
            If oWorksheet.Range("A" & oWorksheet.Rows.Count).End(Excel.XlDirection.xlUp).Row >= 2 Then
                intRows = oWorksheet.Range("B" & oWorksheet.Rows.Count).End(Excel.XlDirection.xlUp).Row

                pbImportProgress.Minimum = 0
                pbImportProgress.Maximum = intRows
                pbImportProgress.Value = 0
                pbImportProgress.Step = 1
                lblProgressBar.Text = "Begin Rules import......."

                'Write each section name as a comment
                WriteToRuleInsert("-- " & oWorksheet.Name)

                'loop through all rows but use "A" as guide since that field cannot be empty
                For intFor = 2 To intRows

                    'clear these each time
                    strRuleSubSection = ""

                    'get each cell and put into field for the Section
                    oCell = oWorksheet.Range("A" & intFor)
                    'Check if row is hidden.  Skip if hidden
                    If oCell.EntireRow.Hidden = False Then
                        If oCell.Value IsNot Nothing Then
                            strRule = oCell.Value.ToString.Substring(0, oCell.Value.ToString.IndexOf(" "))
                            strRuleDescription = oCell.Value.ToString.Substring(oCell.Value.ToString.IndexOf(" ") + 1)
                            strRuleInsert = "INSERT INTO RuleSection VALUES ('" & strRule & "','" & strRuleDescription & "')"
                            'Writeline
                            WriteToRuleInsert(strRuleInsert)
                        End If

                        'get each cell and put into field for the SubSection and description
                        oCell = oWorksheet.Range("B" & intFor)
                        If oCell.Value IsNot Nothing Then
                            strRuleSubSection = oCell.Value.ToString
                            oCell = oWorksheet.Range("C" & intFor)
                            If oCell.Value IsNot Nothing Then
                                strRuleSubSectionDescription = oCell.Value
                                'Replace " with blank char and replace newlines (char(10) and char(13)) with a space
                                strRuleSubSectionDescription = strRuleSubSectionDescription.Replace(Chr(34), "").Replace(Chr(10), " ").Replace(Chr(13), " ")
                                strRuleInsert = "INSERT INTO RuleSubSection VALUES ('" & strRule & "','" & strRuleSubSection & "','" & strRuleSubSectionDescription & "')"
                                'Writeline
                                WriteToRuleInsert(strRuleInsert)
                                'Create line for TOCRules that will need to add TOCID later.  Grab OSM screen for now and replace with TOCID
                                oCell = oWorksheet.Range("E" & intFor)
                                If oCell.Value IsNot Nothing Then
                                    strTOCRulesScreen = oCell.Value
                                    strTOCRulesScreen = strTOCRulesScreen.Replace(Chr(34), "").Replace(Chr(10), " ").Replace(Chr(13), " ")
                                    arrTOCRules = strTOCRulesScreen.Split(",")
                                    For Each TOCRuleScreen As String In arrTOCRules
                                        strRuleInsert = "INSERT INTO TOCRules VALUES ('" & strRule & "','" & strRuleSubSection & "','" & Trim(TOCRuleScreen) & "')"
                                        WriteToRuleInsert(strRuleInsert)
                                    Next

                                End If
                            End If
                        End If
                    End If

                    pbImportProgress.PerformStep()

                Next
            End If

            'Add new line with SQL "GO" command
            WriteToRuleInsert("GO" & vbCrLf)
            lblProgressBar.Text = "Finished " & oWorksheet.Name
            pbImportProgress.Value = pbImportProgress.Maximum

            Return NumberOfRowsUpdated


        Catch ex As Exception

            Return 0
        End Try
    End Function

    Private Sub WriteToRuleInsert(ByRef strInfo As String)
        Try
            Dim strOutputPath As String = txtOutputFile.Text

            Dim objSW As StreamWriter = New StreamWriter(txtOutputFile.Text, True)

            objSW.WriteLine(strInfo)

            objSW.Close()

        Catch ex As Exception
            MessageBox.Show("An error has occured in the Procedure: WriteToRuleInsert " & vbCrLf &
                ex.Message, "Unexpected Program Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnInputFile_Click(sender As Object, e As EventArgs) Handles btnInputFile.Click

        'open dialog file
        Dim oFileDialog As New OpenFileDialog
        Dim oFileInfo As FileInfo

        If txtInputFile.Text <> "" Then
            oFileInfo = New FileInfo(txtInputFile.Text)
            oFileDialog.InitialDirectory = oFileInfo.Directory.ToString
        End If

        oFileDialog.Filter = "MS EXCEL files (*.xls;*.xlsx)|*.xls;*.xlsx"

        oFileDialog.ShowDialog()

        'Open import file unless cancelled
        If oFileDialog.FileName = "" Then
            Exit Sub
        Else
            txtInputFile.Text = oFileDialog.FileName
        End If

    End Sub

    Private Sub btnOutputFile_Click(sender As Object, e As EventArgs) Handles btnOutputFile.Click
        'open dialog file
        Dim oFileDialog As New SaveFileDialog


        oFileDialog.Filter = "SQL Server (*.sql)|*.sql"

        oFileDialog.ShowDialog()

        'Open import file unless cancelled
        If oFileDialog.FileName = "" Then
            Exit Sub
        Else
            If File.Exists(oFileDialog.FileName) Then
                File.Delete(oFileDialog.FileName)
            End If
            txtOutputFile.Text = oFileDialog.FileName
        End If
    End Sub
End Class