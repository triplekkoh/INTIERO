<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentEnrollment.aspx.cs" Inherits="StudentEnrollment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Enrollment</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Student Enrollment</h1>
        <div>
            <asp:Label ID="StudentName" Text="Student Name: " runat="server" />
            <asp:Label ID="StudentName1" runat="server" />
            <br />
            <br />
            <asp:Label ID="StudentID" Text="Student ID: " runat="server" />
            <asp:Label ID="StudentID1" runat="server" />
            <br />
            <br />
            <asp:Label ID="StudentCourse" Text="Student Course: " runat="server" />
            <asp:Label ID="StudentCourse1" runat="server" />
            <br />
            <br />
            <asp:Label ID="StudentSubject" Text="Student Subject" runat="server" />
            <br />
            <br />
            <asp:Button ID="AddStudentSubjectB" Text="Add Subject" runat="server" OnClick="AddStudentSubjectB_Click" />
            <br />
            <br />
            <asp:DropDownList ID="StudentSubjectDDL" runat="server" Visible="false" />
            <br />
            <br />
            <asp:Button ID="EnrollStudentSubjectB" Text="Enroll This Subject Only" runat="server" Visible="false" OnClick="EnrollStudentSubjectB_Click" />
            <asp:Button ID="CancelEnrollStudentSubjectB" Text="Cancel" runat="server" Visible="false" OnClick="CancelEnrollStudentSubjectB_Click" />
            <br />
            <br />
            <asp:Button ID="AddStudentSubjectB1" Text="Add Subject" runat="server" Visible="false" OnClick="AddStudentSubjectB1_Click" />
            <br />
            <br />
            <asp:DropDownList ID="StudentSubjectDDL1" runat="server" Visible="false" />
            <br />
            <br />
            <asp:Button ID="EnrollStudentSubjectB1" Text="Enroll This 2 Subject Only" runat="server" Visible="false" OnClick="EnrollStudentSubjectB1_Click" />
            <asp:Button ID="CancelEnrollStudentSubjectB1" Text="Cancel" runat="server" Visible="false" OnClick="CancelEnrollStudentSubjectB1_Click" />
            <br />
            <br />
            <asp:Button ID="AddStudentSubjectB2" Text="Add Subject" runat="server" Visible="false" OnClick="AddStudentSubjectB2_Click" />
            <br />
            <br />
            <asp:DropDownList ID="StudentSubjectDDL2" runat="server" Visible="false" />
            <br />
            <br />
            <asp:Button ID="EnrollStudentSubjectB2" Text="Enroll This 3 Subject Only" runat="server" Visible="false" OnClick="EnrollStudentSubjectB2_Click" />
            <asp:Button ID="CancelEnrollStudentSubjectB2" Text="Cancel" runat="server" Visible="false" OnClick="CancelEnrollStudentSubjectB2_Click" />
            <br />
            <br />
            <asp:Button ID="AddStudentSubjectB3" Text="Add Subject" runat="server" Visible="false" OnClick="AddStudentSubjectB3_Click" />
            <br />
            <br />
            <asp:DropDownList ID="StudentSubjectDDL3" runat="server" Visible="false" />
            <br />
            <br />
            <asp:Button ID="EnrollStudentSubjectB3" Text="Enroll This 4 Subject Only" runat="server" Visible="false" OnClick="EnrollStudentSubjectB3_Click" />
            <asp:Button ID="CancelEnrollStudentSubjectB3" Text="Cancel" runat="server" Visible="false" OnClick="CancelEnrollStudentSubjectB3_Click" />
            <br />
            <br />
            <asp:Button ID="AddStudentSubjectB4" Text="Add Subject" runat="server" Visible="false" OnClick="AddStudentSubjectB4_Click" />
            <br />
            <br />
            <asp:DropDownList ID="StudentSubjectDDL4" runat="server" Visible="false" />
            <br />
            <br />
            <asp:Button ID="EnrollStudentSubjectB4" Text="Enroll All Subject" runat="server" Visible="false" OnClick="EnrollStudentSubjectB4_Click" />
            <asp:Button ID="CancelEnrollStudentSubjectB4" Text="Cancel" runat="server" Visible="false" OnClick="CancelEnrollStudentSubjectB4_Click" />
        </div>
    </form>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
