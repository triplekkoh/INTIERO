<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="css/style.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <asp:Label ID="IDlbl" runat="server" Text="Student ID: "></asp:Label>

        <div class='btn-cont'>
            <a class='btn' href='/StudentInfo.aspx?ID=<%= Convert.ToString(Request.QueryString["ID"]) %>'>Student Info   
                <span class='line-1'></span>
                <span class='line-2'></span>
                <span class='line-3'></span>
                <span class='line-4'></span>
            </a>
        </div>

        <div class='btn-cont'>
            <a class='btn' href='/ViewResult.aspx?ID=<%= Convert.ToString(Request.QueryString["ID"]) %>'>View Result   
                <span class='line-1'></span>
                <span class='line-2'></span>
                <span class='line-3'></span>
                <span class='line-4'></span>
            </a>
        </div>

        <div class='btn-cont'>
            <a class='btn' href='/StudentEnrollment.aspx?ID=<%= Convert.ToString(Request.QueryString["ID"]) %>'>Register Subject   
                <span class='line-1'></span>
                <span class='line-2'></span>
                <span class='line-3'></span>
                <span class='line-4'></span>
            </a>
        </div>

        <div class='btn-cont'>
            <a class='btn' href='/Login.aspx'>Logout   
                <span class='line-1'></span>
                <span class='line-2'></span>
                <span class='line-3'></span>
                <span class='line-4'></span>
            </a>
        </div>



        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>


        <%--        <div>
            <p>
                <asp:Button ID="Logoutbtn" runat="server" Height="47px" OnClick="Logoutbtn_Click" Text="Logout" Width="92px" />
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" Height="47px" OnClick="Logoutbtn_Click" Text="Student Info" Width="92px" />
            </p>
            <p>
                <asp:Button ID="Button3" runat="server" Height="47px" OnClick="Logoutbtn_Click" Text="View Result" Width="92px" />
            </p>
            <p>
                <asp:Button ID="Button4" runat="server" Height="47px" OnClick="Logoutbtn_Click" Text="Register Subject" Width="92px" />
            </p>
        </div>--%>
    </form>
</body>
</html>
