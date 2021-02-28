Imports System.Drawing
Imports System.Text

Public Class Ascii
    Public Shared Function Resize(image As Bitmap, x As Integer, y As Integer) As Bitmap
        Return New Bitmap(image, New Size(image.Width \ x, image.Height \ y))
    End Function
    Public Shared Function Convert(image As Bitmap, chars() As Char) As String
        Dim state As Boolean = False, sb As StringBuilder = New StringBuilder
        For h As Integer = 0 To image.Height - 1
            For w As Integer = 0 To image.Width - 1
                Dim pixelColor As Color = image.GetPixel(w, h)
                Dim red As Integer = (CInt(pixelColor.R) + CInt(pixelColor.G) + CInt(pixelColor.B)) \ 3
                Dim green As Integer = (CInt(pixelColor.R) + CInt(pixelColor.G) + CInt(pixelColor.B)) \ 3
                Dim blue As Integer = (CInt(pixelColor.R) + CInt(pixelColor.G) + CInt(pixelColor.B)) \ 3
                Dim grayColor As Color = Color.FromArgb(red, green, blue)

                If (Not state) Then
                    Dim index As Integer = (CInt(grayColor.R) * (chars.Length - 1)) \ 255
                    sb.Append(chars(index))
                End If
            Next
            If (Not state) Then
                sb.Append("<br>")
                state = True
            Else
                state = False
            End If
        Next
        Return sb.ToString()
    End Function
End Class
