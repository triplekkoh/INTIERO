<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentInfo.aspx.cs" Inherits="StudentInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <h2 style="width: 20%; margin-left: 20px; margin-top: 20px">Student Info</h2>
        <div style="width: 20%; margin-left: 20px; margin-top: 20px">
            <p>
                Student ID:
                <asp:Label ID="IDlbl" runat="server" Text="Unknown"></asp:Label>
            </p>
            <p>
                Name:
                <asp:Label ID="Namelbl" runat="server" Text="Unknown"></asp:Label>
            </p>
            <p>
                Course:
                <asp:Label ID="Courselbl" runat="server" Text="Unknown"></asp:Label>
            </p>
            <p>
                Phone No:
                <asp:TextBox ID="Phonetb" runat="server" Text="Nothing"></asp:TextBox>
            </p>
            <p>
                Address:
                <asp:TextBox ID="Addresstb" runat="server" TextMode="MultiLine" Text="Nothing"></asp:TextBox>
            </p>
            <p>
                Subject:
                <asp:Label ID="Subjectlbl" runat="server" Text="Unknown"></asp:Label>
            </p>
            <div align="right">
                <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" CssClass="btn btn-success" />
            </div>
        </div>
    </form>
</body>
</html>
