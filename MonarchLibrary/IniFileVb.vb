'  Programmer: Ludvik Jerabek
'        Date: 08\23\2010
'     Purpose: Allow INI manipulation in .NET

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Diagnostics

' IniFile class used to read and write ini files by loading the file into memory
Public Class IniFile
    ' List of IniSection objects keeps track of all the sections in the INI file
    Private m_sections As Hashtable
    Public name, value As String
    Public issecavailable As Boolean = False
    Public iskeyavailable As Boolean = False
    ' Public constructor
    Public Sub New()
        m_sections = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
    End Sub

    ' Loads the Reads the data in the ini file into the IniFile object
    Public Sub Load(ByVal sFileName As String)
        '  Clear the object... 
        Dim tempsection As IniSection = Nothing
        Dim oReader As New StreamReader(sFileName)
        Dim regexcomment As New Regex("^([\s]*#.*)", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        ' Broken but left for history
        'Dim regexsection As New Regex("\[[\s]*([^\[\s].*[^\s\]])[\s]*\]", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        Dim regexsection As New Regex("^[\s]*\[[\s]*([^\[\s].*[^\s\]])[\s]*\][\s]*$", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        Dim regexkey As New Regex("^\s*([^=\s]*)[^=]*=(.*)", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        While Not oReader.EndOfStream
            Dim line As String = oReader.ReadLine()
            If line <> String.Empty Then
                Dim m As Match = Nothing
                If regexcomment.Match(line).Success Then
                    m = regexcomment.Match(line)
                    Trace.WriteLine(String.Format("Skipping Comment: {0}", m.Groups(0).Value))
                ElseIf regexsection.Match(line).Success Then
                    m = regexsection.Match(line)
                    Trace.WriteLine(String.Format("Adding section [{0}]", m.Groups(1).Value))
                    tempsection = AddSection(m.Groups(1).Value)
                ElseIf regexkey.Match(line).Success AndAlso tempsection IsNot Nothing Then
                    m = regexkey.Match(line)
                    Trace.WriteLine(String.Format("Adding Key [{0}]=[{1}]", m.Groups(1).Value, m.Groups(2).Value))
                    tempsection.AddKey(m.Groups(1).Value).Value = m.Groups(2).Value
                ElseIf tempsection IsNot Nothing Then
                    '  Handle Key without value
                    Trace.WriteLine(String.Format("Adding Key [{0}]", line))
                    tempsection.AddKey(line)
                Else
                    '  This should not occur unless the tempsection is not created yet...
                    Trace.WriteLine(String.Format("Skipping unknown type of data: {0}", line))
                End If
            End If
        End While
        oReader.Close()
    End Sub
    Public Function fetchkey(ByVal sFileName As String, ByVal sec As String, ByVal key1 As String) As String
        Load(sFileName)
        For Each element As IniSection In Sections
            If UCase(element.Name) = UCase(sec) Then
                '  MsgBox(element.Name)
                For Each s As IniSection.IniKey In element.Keys
                    If UCase(s.Name) = UCase(key1) Then
                        '   MsgBox(s.Name)
                        '  MsgBox(s.Value)
                        fetchkey = s.Value
                    End If
                Next
            End If
        Next
    End Function

    ' Used to save the data back to the file or your choice
    Public Sub Save(ByVal sFileName As String, ByVal sec As String, ByVal key1 As String, ByVal val1 As String)
        Load(sFileName)
        Dim oWriter As New StreamWriter(sFileName, False)
        For Each s As IniSection In Sections
            Trace.WriteLine(String.Format("Writing Section: [{0}]", s.Name))
            oWriter.WriteLine(String.Format("[{0}]", s.Name))
            If UCase(s.Name) = UCase(sec) Then
                For Each k As IniSection.IniKey In s.Keys
                    If UCase(k.Name) = UCase(key1) Then
                        Trace.WriteLine(String.Format("Writing Key: {0}={1}", k.Name, val1))
                        oWriter.WriteLine(String.Format("{0}={1}", k.Name, val1))
                        iskeyavailable = True
                    Else
                        Trace.WriteLine(String.Format("Writing Key: {0}={1}", k.Name, k.Value))
                        oWriter.WriteLine(String.Format("{0}={1}", k.Name, k.Value))
                    End If
                Next
                If iskeyavailable = False Then
                    Trace.WriteLine(String.Format("Writing Key: {0}={1}", key1, val1))
                    oWriter.WriteLine(String.Format("{0}={1}", key1, val1))
                End If
                issecavailable = True
                iskeyavailable = False
            Else
                For Each k As IniSection.IniKey In s.Keys
                    'If k.Value <> String.Empty Then
                    Trace.WriteLine(String.Format("Writing Key: {0}={1}", k.Name, k.Value))
                    oWriter.WriteLine(String.Format("{0}={1}", k.Name, k.Value))
                Next
            End If
            'Next
        Next
        If issecavailable = False Then
            Trace.WriteLine(String.Format("Writing Section: [{0}]", sec))
            oWriter.WriteLine(String.Format("[{0}]", sec))
            Trace.WriteLine(String.Format("Writing Key: {0}={1}", key1, val1))
            oWriter.WriteLine(String.Format("{0}={1}", key1, val1))
        End If
        oWriter.Close()
        issecavailable = False
    End Sub

    ' Gets all the sections
    Public ReadOnly Property Sections() As System.Collections.ICollection
        Get
            Return m_sections.Values
        End Get
    End Property

    ' Adds a section to the IniFile object, returns a IniSection object to the new or existing object
    Public Function AddSection(ByVal sSection As String) As IniSection
        Dim s As IniSection = Nothing
        sSection = sSection.Trim()
        ' Trim spaces
        If m_sections.ContainsKey(sSection) Then
            s = DirectCast(m_sections(sSection), IniSection)
        Else
            s = New IniSection(Me, sSection)
            m_sections(sSection) = s
        End If
        Return s
    End Function

    ' Sets a KeyValuePair in a certain section
    Public Function SetKeyValue(ByVal sSection As String, ByVal sKey As String, ByVal sValue As String) As Boolean
        Dim s As IniSection = AddSection(sSection)
        If s IsNot Nothing Then
            Dim k As IniSection.IniKey = s.AddKey(sKey)
            If k IsNot Nothing Then
                k.Value = sValue
                Return True
            End If
        End If
        Return False
    End Function

    ' IniSection class 
    Public Class IniSection
        '  IniFile IniFile object instance
        Private m_pIniFile As IniFile
        '  Name of the section
        Private m_sSection As String
        '  List of IniKeys in the section
        Private m_keys As Hashtable

        ' Constuctor so objects are internally managed
        Protected Friend Sub New(ByVal parent As IniFile, ByVal sSection As String)
            m_pIniFile = parent
            m_sSection = sSection
            m_keys = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
        End Sub

        ' Returns all the keys in a section
        Public ReadOnly Property Keys() As System.Collections.ICollection
            Get
                Return m_keys.Values
            End Get
        End Property

        ' Returns the section name
        Public ReadOnly Property Name() As String
            Get
                Return m_sSection
            End Get
        End Property

        ' Adds a key to the IniSection object, returns a IniKey object to the new or existing object
        Public Function AddKey(ByVal sKey As String) As IniKey
            sKey = sKey.Trim()
            Dim k As IniSection.IniKey = Nothing
            If sKey.Length <> 0 Then
                If m_keys.ContainsKey(sKey) Then
                    k = DirectCast(m_keys(sKey), IniKey)
                Else
                    k = New IniSection.IniKey(Me, sKey)
                    m_keys(sKey) = k
                End If
            End If
            Return k
        End Function

        ' IniKey class
        Public Class IniKey
            '  Name of the Key
            Private m_sKey As String
            '  Value associated
            Private m_sValue As String
            '  Pointer to the parent CIniSection
            Private m_section As IniSection

            ' Constuctor so objects are internally managed
            Protected Friend Sub New(ByVal parent As IniSection, ByVal sKey As String)
                m_section = parent
                m_sKey = sKey
            End Sub

            ' Returns the name of the Key
            Public ReadOnly Property Name() As String
                Get
                    Return m_sKey
                End Get
            End Property

            ' Sets or Gets the value of the key
            Public Property Value() As String
                Get
                    Return m_sValue
                End Get
                Set(ByVal value As String)
                    m_sValue = value
                End Set
            End Property

            ' Sets the value of the key
            Public Sub SetValue(ByVal sValue As String)
                m_sValue = sValue
            End Sub
            ' Returns the value of the Key
            Public Function GetValue() As String
                Return m_sValue
            End Function

            ' Returns the name of the Key
            Public Function GetName() As String
                Return m_sKey
            End Function
        End Class
        ' End of IniKey class
    End Class
    ' End of IniSection class
End Class
' End of IniFile class