<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewResult.aspx.cs" Inherits="ViewResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        input[type=text] {
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-shadow: inset 0 1px 3px #ddd;
            border-radius: 4px;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            padding-top: 6px;
            padding-bottom: 6px;
        }

        table th {
            background-color: #4fa8dd;
            color: #ffffff;
            text-align: center;
            padding: 7px;
        }

        table td {
            padding: 5px;
        }

        th {
            font-size: large;
        }

        td {
            font-size: medium;
        }

        body {
            font-family: sans-serif, Verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
            
            <asp:Button ID="View" runat="server" Text="View" OnClick="View_Click" Visible="false" />
            
        </div>
    </form>
</body>
</html>
