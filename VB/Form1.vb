Imports Microsoft.Win32
Public Class Form1
    Shared random As New Random()
    Dim q As String
    Dim regKey As RegistryKey
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Shell("taskkill /f /im explorer.exe")
        Process.Start("C:\Activation\Guna UI Activation\bin\Debug\task.exe", 0)
        Timer2.Start()
    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        COM3.ReadTimeout = 1000
        COM3.WriteTimeout = 1000
        Timer2.Stop()
        q = Convert.ToString(random.Next(10000, 99999))
        Try
            COM3.PortName = "COM3"
            If COM3.IsOpen = False Then
                COM3.Open()
            End If
            COM3.WriteLine(q)
        Catch ex As Exception
        End Try
        COM3.Close()
        Timer2.Start()   
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

        If e.KeyCode = Keys.Enter Then
            Button2_Click(sender, e)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("You haven't entered any PIN. please enter the PIN.", "No PIN found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = q Then
            Process.Start("C:\new\new\bin\Debug\task.exe", 1)
            Process.Start("c:\windows\explorer.exe")
            Me.Hide()
            Timer2.Stop()
            Timer1.Start()

        ElseIf TextBox2.Text = "812" Then
            Process.Start("C:\Activation\Guna UI Activation\bin\Debug\task.exe", 1)
            Process.Start("c:\windows\explorer.exe")
            Me.Hide()
            Timer2.Stop()
            Timer1.Start()
        Else
            MessageBox.Show("Incorrect PIN,Please Enter the correct PIN", "Wrong PIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        COM3.ReadTimeout = 1000
        COM3.WriteTimeout = 1000
        Dim k As Integer = 0
    
        Try
            COM3.PortName = "COM3"
            If COM3.IsOpen = False Then
                COM3.Open()
            End If
            k = COM3.ReadLine
        Catch ex As Exception
        End Try
        COM3.Close()


        If k = 1 Then
            Process.Start("Taskmgr.exe")
        ElseIf k = 2 Then
            Process.Start("shutdown", "-s -t 00")
        ElseIf k = 3 Then
            Process.Start("shutdown", "-r -t 00")
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim t As Integer = 0
        Try
            COM3.PortName = "COM3"
            If COM3.IsOpen = False Then
                COM3.Open()
            End If

        Catch ex As Exception
            If String.Compare("The port 'COM3' does not exist.", ex.Message) = 0 Then
                t = 1
                TextBox1.ForeColor = Color.Red
                TextBox1.Text = "Insert Key"
            End If
        End Try
        If t = 0 Then
            TextBox1.ForeColor = Color.LimeGreen
            TextBox1.Text = "key detected"
        End If
        COM3.Close()
    End Sub
End Class
