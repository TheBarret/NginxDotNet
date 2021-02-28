Imports System.Collections.Specialized
Imports System.Drawing
Imports System.IO
Imports System.Web
Imports nginx.net.Session

Module Program

    Sub Main(args() As String)

        'Define our variable container
        Dim vars As New Dictionary(Of String, String)

        'Pass arguments and layout header
        Header(args, vars)

        Try
            Session.Write("<h1>Hello, World!</h1>")

            ' Create a little bit of art
            If (File.Exists("logo.png")) Then
                Session.Write("<font face='Consolas'><pre>")
                Session.Write(Ascii.Convert(Ascii.Resize(New Bitmap("logo.png"), 4, 4), " .,:;'?+=!#$%^&*0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray))
                Session.Write("</pre></font>")
            End If

            If (vars.Any) Then
                For Each pair As KeyValuePair(Of String, String) In vars
                    Session.Write(String.Format("Variable: {0} Value: <strong>{1}</strong><br>", pair.Key, pair.Value))
                Next
            End If

            Session.Write("<form action='index.cgi' method='post'>")
            Session.Write("<input type='text' id='data' name='data' value='This is a test'><br>")
            Session.Write("<input type='submit' value='Submit'>")
            Session.Write("</form>")

        Catch ex As Exception
            Session.Write(String.Format("Error: {0}", ex.Message))
        Finally
            Footer()
        End Try
    End Sub
    Sub Header(args() As String, ByRef vars As Dictionary(Of String, String))
        If (args.Any) Then
            For Each x As String In args
                Dim container As NameValueCollection = HttpUtility.ParseQueryString(String.Concat(x))
                For Each y In container.AllKeys
                    vars.Add(y, container(y))
                Next
            Next
        End If
        Session.Write(DocumentType.Text)
        Session.Write("<html><head>")
        Session.Write("<title>Nginx with dotnet example</title>")
        Session.Write("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>")
        Session.Write("</head><body>")
    End Sub
    Sub Footer()
        Session.Write("</body></html>")
    End Sub
End Module
