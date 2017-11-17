<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .loader {
            border: 5px solid #f3f3f3;
            border-radius: 50%;
            border-top: 5px solid #3498db;
            width: 50px;
            height: 50px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        .auto-style1 {
            width: 100%;
        }

        tr {
            width: 800px;
        }

        .txtbx {
            background-image: url(images/form_bg.jpg);
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
            width: 230px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
        }
    </style>
    <script type="text/javascript">
        function Showloading() {
            document.getElementById('loading').style.visibility = 'visible';
        }

        function Hideloading() {
            document.getElementById('loading').style.visibility = "hidden";
        }
    </script>
</head>
<body onload="javascript:Hideloading()">
    <form id="form1" runat="server">
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <div align="center">
            <table>
                <tr align="center">
                    <td style="text-align: center; vertical-align: top">
                        <img src="INTI logo.png" alt="Anything" style="width: 600px" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="INTI College Penang Exam Result"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td>&nbsp<asp:TextBox ID="Usertb" runat="server" Font-Size="X-Large" CssClass="txtbx" placeholder="User ID"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td>&nbsp<asp:TextBox ID="Passwordtb" runat="server" Font-Size="X-Large" TextMode="Password" CssClass="txtbx" placeholder="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <div>
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe" Style="font-family: Arial; font-size: 14px; padding-left: 0px" Text="Remember me?"></asp:Label>
                                &nbsp
                                <asp:Button ID="Forgetbtn" runat="server" Text="Forget Password" OnClick="Forgetbtn_Click" OnClientClick="javascript:Showloading()" CssClass="btn btn-danger" Style="height: 28px; font-size: 11px;" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Button ID="Loginbtn" runat="server" CssClass="btn btn-success" Width="100px" Font-Size="X-Large" OnClick="Loginbtn_Click" Text="Log In" />
                    </td>
                </tr>
            </table>
        </div>

        <div id="loading" style="visibility: hidden;" align="center">
            <img src="/images/Ripple.gif" style="height: 100px;" />
        </div>
    </form>
</body>
</html>
