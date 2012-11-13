Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'read
        Dim file As String
        Dim oRead As System.IO.StreamReader
        oRead = System.IO.File.OpenText("C:\OrderRequest.xsd")
        file = oRead.ReadToEnd

        Dim ref As String = ""
        Dim i As Integer = 0

        While file.IndexOf("ref=""", i) > 0
            ref = file.Substring(file.IndexOf("ref=""", i) + Len("ref="""), file.IndexOf("""", file.IndexOf("ref=""", i) + Len("ref=""") + 1) - file.IndexOf("ref=""", i) - Len("ref="""))
            i = file.IndexOf("ref=""" + ref + """") + 1
            file = file.Replace("ref=""" + ref + """", "name=""" + ref + """" + " type=""" + ref + """")
            'file = file.Replace("<xsd:element name=""" + ref + """ type=""" + ref + """/>", "")
        End While

        'write
        Dim FILENAME As String = "d:\OrderRequest2.xsd"
        Dim objStreamWriter As System.IO.StreamWriter
        objStreamWriter = System.IO.File.AppendText(FILENAME)
        objStreamWriter.Write(file)
        objStreamWriter.Close()

    End Sub
End Class
