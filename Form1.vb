Imports System.Runtime.InteropServices

Public Class Form1
#Region "Const&Struct"
    '<Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    'Private Shared Function GetForegroundWindow() As IntPtr
    'End Function
    Private Const KEYEVENTF_KEYDOWN As Integer = &H0
    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Private Const KEYEVENTF_SCANCODE As Integer = &H8
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const INPUT_MOUSE As Integer = 0
    Private Const INPUT_KEYBOARD As Integer = 1
    Private Const INPUT_HARDWARE As Integer = 2

    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    <StructLayout(LayoutKind.Explicit)> _
    Private Structure INPUT
        <FieldOffset(0)> _
        Public type As Integer
        <FieldOffset(8)> _
        Public mi As MOUSEINPUT
        <FieldOffset(8)> _
        Public ki As KEYBDINPUT
        <FieldOffset(8)> _
        Public hi As HARDWAREINPUT
    End Structure

    ''' <summary>The set of valid MapTypes used in MapVirtualKey
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MapVirtualKeyMapTypes As UInt32
        ''' <summary>uCode is a virtual-key code and is translated into a scan code.
        ''' If it is a virtual-key code that does not distinguish between left- and 
        ''' right-hand keys, the left-hand scan code is returned. 
        ''' If there is no translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        MAPVK_VK_TO_VSC = &H0

        ''' <summary>uCode is a scan code and is translated into a virtual-key code that
        ''' does not distinguish between left- and right-hand keys. If there is no 
        ''' translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        MAPVK_VSC_TO_VK = &H1

        ''' <summary>uCode is a virtual-key code and is translated into an unshifted
        ''' character value in the low-order word of the return value. Dead keys (diacritics)
        ''' are indicated by setting the top bit of the return value. If there is no
        ''' translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        MAPVK_VK_TO_CHAR = &H2

        ''' <summary>Windows NT/2000/XP: uCode is a scan code and is translated into a
        ''' virtual-key code that distinguishes between left- and right-hand keys. If
        ''' there is no translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        MAPVK_VSC_TO_VK_EX = &H3

        ''' <summary>The uCode parameter is a virtual-key code and is translated into a
        ''' scan code. If it is a virtual-key code that does not distinguish between 
        ''' left- and right-hand keys, the left-hand scan code is returned. If the scan 
        ''' code is an extended scan code, the high byte of the uCode value can contain 
        ''' either 0xe0 or 0xe1 to specify the extended scan code. If there is no 
        ''' translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        MAPVK_VK_TO_VSC_EX = &H4
    End Enum
#End Region
    
    Private Declare Function ShowWindow Lib "user32.dll" (hwnd As IntPtr, showcmd As Integer) As Boolean
    Private Declare Function BringWindowToTop Lib "user32.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal handle As IntPtr, ByRef pid As Integer) As Integer
    Private Declare Auto Function RegisterHotKey Lib "user32.dll" (ByVal handle As IntPtr, ByVal id As Integer, ByVal fsModifier As UInt32, ByVal vk As UInt32) As Boolean
    Private Declare Auto Function UnregisterHotKey Lib "user32.dll" (ByVal handle As IntPtr, ByVal id As Integer) As Boolean
    Private Declare Auto Function SendInput Lib "user32.dll" (ByVal nInputs As Integer, ByVal pInputs() As INPUT, ByVal cbSize As Integer) As Integer
    Private Declare Auto Function MapVirtualKeyEx Lib "user32.dll" (ByVal uCode As UInteger, ByVal uMapType As MapVirtualKeyMapTypes, ByVal locale As IntPtr) As UInteger
    'Private Declare Function AttachThreadInput Lib "user32" (ByVal idAttach As IntPtr, ByVal idAttachTo As IntPtr, ByVal fAttach As Boolean) As Boolean
    'Declare Auto Function PostMessage Lib "user32.dll" (ByVal handle As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    Private thrd As Threading.Thread
    Private Shared mode As String
    'Private Shared cID As Integer
    'Private Shared tID As Integer
    Private proceed As Boolean = True
    Private preset As String = ""


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        UnregisterHotKey(Me.Handle, 0)

        Dim config As XElement = XElement.Load("config.xml")
        config.Element("LastProcess").Value = CB_Process.Text
        config.Element("LastMode").Value = CbB_Mode.Text
        config.Element("LastPreset").Value = CbB_Preset.Text
        config.Save("config.xml")
        'If DGV.Rows.Count > 1 Then
        '    My.Settings.Sequence = ""

        'End If
    End Sub
    'Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    'End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim a = ""
        'For Each key As Keys In [Enum].GetValues(GetType(Keys))
        '    Debug.Print(key.GetHashCode.ToString & ", " & MapVirtualKeyEx(key.GetHashCode, MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC_EX, IntPtr.Zero).ToString & vbCrLf)
        'Next

        'Stop

        'initialize keys
        C_Key.Items.AddRange([Enum].GetNames(GetType(Keys)))

        'initialize process list
        For Each p In Process.GetProcesses
            CB_Process.Items.Add(p.ProcessName)
        Next
        CB_Process.Sorted = True

        'load settings
        If Not My.Computer.FileSystem.FileExists("config.xml") Then
            Dim config As New XElement("CfgRoot")
            config.Add(New XElement("Presets"))
            config.Add(New XElement("LastProcess"))
            config.Add(New XElement("LastMode"))
            config.Add(New XElement("LastPreset"))
            config.Save("config.xml")
        Else
            Dim config As XElement = XElement.Load("config.xml")
            If Not config.Elements("Presets").Any Then
                config.Add(New XElement("Presets"))
            Else
                For Each p In config.Element("Presets").Elements
                    CbB_Preset.Items.Add(p.Name.LocalName)
                Next
            End If
            If config.Elements("LastProcess").Any Then CB_Process.Text = config.Element("LastProcess").Value
            If config.Elements("LastMode").Any Then CbB_Mode.Text = config.Element("LastMode").Value
            If config.Elements("LastPreset").Any Then CbB_Preset.Text = config.Element("LastPreset").Value
        End If

        If RegisterHotKey(Me.Handle, 0, 1, Keys.S) = False Then
            MsgBox("Hotkey Alt+S register failed. You can continue but you will have to switch on and off manually.", MsgBoxStyle.Exclamation)
        End If
        'third para: 0=nothing 1 -alt 2-ctrl 3-ctrl+alt 4-shift 5-alt+shift 6-ctrl+shift 7-ctrl+shift+alt 8-win
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 786 Then '786 means a WM_HOTKEY message
            Dim windowpid As Integer
            GetWindowThreadProcessId(GetForegroundWindow, windowpid)
            Dim windowpn = Process.GetProcessById(windowpid).ProcessName
            If CB_Process.Items.Contains(windowpn) Then
                CB_Process.Text = windowpn
            Else
                CB_Process.Items.Add(windowpn)
                CB_Process.Text = windowpn
            End If
            Button1.PerformClick()
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If mode.StartsWith("Automatic") Then
            If Button1.Text = "Start" Then
                Dim diablo = Process.GetProcessesByName(CB_Process.Text)
                If diablo.Length = 0 Then
                    MsgBox("Specified process does not exist.", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    proceed = True
                    DGV.Enabled = False
                    Button3.Enabled = False
                    Button4.Enabled = False
                    CbB_Mode.Enabled = False
                    CB_Process.Enabled = False
                    Btn_Refresh.Enabled = False
                    CbB_Preset.Enabled = False
                    Button1.Text = "Stop"
                    Dim diablohandle = diablo(0).MainWindowHandle
                    ShowWindow(diablohandle, 9)
                    BringWindowToTop(diablohandle)
                    'tID = diablo(0).Id
                    thrd = New Threading.Thread(
                        Sub()
                            Threading.Thread.Sleep(2000)
                            'Dim kc As New KeysConverter
                            Do While proceed
                                If diablohandle = GetForegroundWindow() Then
                                    For i = 0 To DGV.Rows.Count - 2
                                        Send(DGV.Rows(i).Cells("C_Key").FormattedValue.ToString, mode)
                                        Threading.Thread.Sleep(DGV.Rows(i).Cells("C_Delay").Value)
                                    Next
                                Else
                                    Threading.Thread.Sleep(1000)
                                End If
                            Loop
                        End Sub)
                    thrd.IsBackground = True
                    thrd.Start()
                End If
            Else
                If Button1.Text = "Stop" Then
                    If Not IsNothing(thrd) Then
                        Button1.Enabled = False
                        proceed = False
                        thrd.Join()
                        Button1.Text = "Start"
                        DGV.Enabled = True
                        CB_Process.Enabled = True
                        Btn_Refresh.Enabled = True
                        CbB_Preset.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        CbB_Mode.Enabled = True
                        Button1.Enabled = True
                    End If
                End If
            End If
        Else 'manual
            Dim diablo = Process.GetProcessesByName(CB_Process.Text)
            If diablo.Length = 0 Then
                MsgBox("Specified process does not exist.", MsgBoxStyle.Critical)
                Exit Sub
            Else
                Dim diablohandle = diablo(0).MainWindowHandle
                ShowWindow(diablohandle, 9)
                BringWindowToTop(diablohandle)
                'tID = diablo(0).Id
                Task.Run(Sub()
                             If diablohandle = GetForegroundWindow() Then
                                 For i = 0 To DGV.Rows.Count - 2
                                     Send(DGV.Rows(i).Cells("C_Key").FormattedValue.ToString, mode)
                                     Threading.Thread.Sleep(DGV.Rows(i).Cells("C_Delay").Value)
                                 Next
                             End If
                         End Sub)
            End If
        End If
    End Sub

    Private Sub Send(k As String, mode As String)
        If mode.EndsWith("(v2)") Then
            'cID = Threading.Thread.CurrentThread.ManagedThreadId
            Dim GInput(0) As INPUT
            Dim keycode As Short = [Enum].Parse(GetType(Keys), k, True).GetHashCode
            Dim scancode As Short = MapVirtualKeyEx([Enum].Parse(GetType(Keys), k, True).GetHashCode, MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC_EX, IntPtr.Zero)
            'press the key
            Dim shift As Integer
            If IsExtendedKey(keycode) Then shift = KEYEVENTF_EXTENDEDKEY Else shift = 0
            GInput(0).type = INPUT_KEYBOARD
            GInput(0).ki.wScan = scancode
            GInput(0).ki.time = 0
            GInput(0).ki.dwFlags = KEYEVENTF_KEYDOWN Or KEYEVENTF_SCANCODE Or shift
            GInput(0).ki.dwExtraInfo = IntPtr.Zero
            SendInput(1, GInput, Marshal.SizeOf(GetType(INPUT)))
            Threading.Thread.Sleep(50)
            'release the key
            GInput(0).ki.dwFlags = KEYEVENTF_KEYUP Or KEYEVENTF_SCANCODE Or shift
            SendInput(1, GInput, Marshal.SizeOf(GetType(INPUT)))
        Else
            Dim GInput(0) As INPUT
            Dim keycode As Short = [Enum].Parse(GetType(Keys), k, True).GetHashCode
            'press the key
            Dim shift As Integer
            If IsExtendedKey(keycode) Then shift = KEYEVENTF_EXTENDEDKEY Else shift = 0
            GInput(0).type = INPUT_KEYBOARD
            GInput(0).ki.wVk = keycode
            GInput(0).ki.wScan = 0
            GInput(0).ki.time = 0
            GInput(0).ki.dwFlags = KEYEVENTF_KEYDOWN Or shift
            GInput(0).ki.dwExtraInfo = IntPtr.Zero
            SendInput(1, GInput, Marshal.SizeOf(GetType(INPUT)))
            Threading.Thread.Sleep(50)
            'release the key
            GInput(0).ki.dwFlags = KEYEVENTF_KEYUP Or shift
            SendInput(1, GInput, Marshal.SizeOf(GetType(INPUT)))
        End If
        'SendKeys.SendWait(k)
    End Sub

    Private Function IsExtendedKey(kc As Short) As Boolean
        If {Keys.Menu, Keys.LMenu, Keys.RMenu,
            Keys.ControlKey, Keys.LControlKey, Keys.RControlKey,
            Keys.Insert, Keys.Delete, Keys.Home, Keys.End, Keys.Prior, Keys.Next,
            Keys.Right, Keys.Left, Keys.Up, Keys.Down,
            Keys.NumLock, Keys.Cancel, Keys.Snapshot, Keys.Divide}.Contains(kc) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DGV.CurrentRow.Index > 0 Then
            Dim tmprow As DataGridViewRow = DGV.CurrentRow
            Dim tmprowi = tmprow.Index
            DGV.Rows.Remove(tmprow)
            DGV.Rows.Insert(tmprowi - 1, tmprow)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If DGV.CurrentRow.Index < DGV.Rows.Count - 2 Then
            Dim tmprow As DataGridViewRow = DGV.CurrentRow
            Dim tmprowi = tmprow.Index
            DGV.Rows.Remove(tmprow)
            DGV.Rows.Insert(tmprowi + 1, tmprow)
        End If
    End Sub

    Private Sub Btn_Refresh_Click(sender As Object, e As EventArgs) Handles Btn_Refresh.Click
        CB_Process.Items.Clear()
        For Each p In Process.GetProcesses
            CB_Process.Items.Add(p.ProcessName)
        Next
    End Sub

    Private Sub Btn_Help_Click(sender As Object, e As EventArgs) Handles Btn_Help.Click
        Dim helpmsg =
            "Press Alt+S to switch start and stop. Only working when the main window of the target process is in foreground. Alt+S will set target process to the process of the foreground window." & vbCrLf & _
            "For a list of keys and formats to use under ""Key"" column, click OK and refer to the MSDN website opened." & vbCrLf & _
            "Please do not contact author for support. He will update it when he updates it. LOOOOOOOOOL"
        If MsgBox(helpmsg, MsgBoxStyle.Information + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Process.Start("iexplore", "https://msdn.microsoft.com/zh-cn/library/system.windows.forms.sendkeys.send.aspx#mt17")
        End If
    End Sub

    'Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
    '    If e.ColumnIndex = 1 Then
    '        DGV.CurrentCell.Value = DGV.CurrentCell.Value.ToString.ToUpper
    '    End If
    'End Sub

    Private Sub CbB_Mode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbB_Mode.SelectedIndexChanged
        mode = CbB_Mode.Text
        If CbB_Mode.Text.StartsWith("Manual") Then
            Button1.Text = "Send"
        Else
            Button1.Text = "Start"
        End If
    End Sub

    Private Sub CbB_Preset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbB_Preset.SelectedIndexChanged
        If CbB_Preset.SelectedIndex > -1 Then
            If CbB_Preset.Text = "* Save" Then
                Dim process = CB_Process.Text
                If process = "" Then process = preset

                If CbB_Preset.Items.Contains(process) Then
                    If MsgBox("There is already a preset with name " & process & ". Overwrite?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End If

                Dim pset As New XElement(process)
                Dim seq As String = ""
                For i = 0 To DGV.Rows.Count - 2
                    seq += DGV.Rows(i).Cells("C_Name").FormattedValue.ToString & "," & _
                        DGV.Rows(i).Cells("C_Key").FormattedValue.ToString & "," & _
                        DGV.Rows(i).Cells("C_Delay").FormattedValue.ToString & ";"
                Next
                pset.Value = seq

                Dim config As XElement = XElement.Load("config.xml")
                If config.Element("Presets").Elements(process).Any Then
                    config.Element("Presets").Element(process).Remove()
                    CbB_Preset.Items.Remove(process)
                End If

                config.Element("Presets").Add(pset)
                CbB_Preset.Items.Add(process)
                config.Save("config.xml")
                CbB_Preset.Text = process
            ElseIf CbB_Preset.Text = "* Delete" Then
                If preset <> "" AndAlso MsgBox("The preset named " & preset & " will be deleted. Proceed?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim config As XElement = XElement.Load("config.xml")
                    If config.Element("Presets").Elements(preset).Any Then
                        config.Element("Presets").Element(preset).Remove()
                        config.Save("config.xml")
                        CbB_Preset.Items.Remove(preset)
                        CbB_Preset.SelectedIndex = -1
                        preset = ""
                    End If
                End If
            Else
                preset = CbB_Preset.Text
                If CB_Process.Items.Contains(preset) Then
                    CB_Process.Text = preset
                Else
                    CB_Process.SelectedIndex = -1
                End If
                Dim config As XElement = XElement.Load("config.xml")
                DGV.Rows.Clear()
                For Each key In config.Element("Presets").Element(preset).Value.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)
                    Dim sp = key.Split({","c})
                    Dim i = DGV.Rows.Add(New DataGridViewRow)
                    DGV.Rows(i).Cells("C_Name").Value = sp(0)
                    DGV.Rows(i).Cells("C_Key").Value = sp(1)
                    DGV.Rows(i).Cells("C_Delay").Value = sp(2)
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEnter
        If DGV(e.ColumnIndex, e.RowIndex).EditType.ToString() = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
            SendKeys.Send("{F4}")
        End If
    End Sub
End Class
