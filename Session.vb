Public Class Session
    Enum DocumentType
        Text
        Jpeg
        Png
    End Enum
    Public Shared Sub Write(doctype As DocumentType)
        Select Case doctype
            Case DocumentType.Text
                Console.WriteLine(String.Format("Content-type: text/html{0}{0}", ControlChars.CrLf))
            Case DocumentType.Jpeg
                Console.WriteLine(String.Format("Content-type: image/jpeg{0}{0}", ControlChars.CrLf))
            Case DocumentType.Jpeg
                Console.WriteLine(String.Format("Content-type: image/png{0}{0}", ControlChars.CrLf))
        End Select
    End Sub
    Public Shared Sub Write(text As String)
        Console.WriteLine(text)
    End Sub
    Public Shared Sub Write(data() As Byte)

    End Sub
End Class
