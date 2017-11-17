<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Semester.aspx.cs" Inherits="Semester" %>

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
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <script type="text/javascript" src="//cdn.jsdelivr.net/jquery/1/jquery.min.js"></script>
        <script type="text/javascript" src="//cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>

        <link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.css" />
        <script type='text/javascript' src='bootstrap/daterangepicker/daterangepicker.js'></script>
        <link rel="stylesheet" type="text/css" href="bootstrap/daterangepicker/daterangepicker.css" />

        <div style="border: 20px solid transparent">
            <p>
                <asp:Label ID="Title" runat="server" Text="New semester enrolment duration:"></asp:Label>
            </p>
            <input id="Sessionval" type="text" name="Sessionval" runat="server" placeholder="Session Name eg:AUG2017" />
            <p>
                <input id="today" type="text" name="daterange" />
            </p>
            <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="Submit_Click" />

        </div>
    </form>
</body>

<script type="text/javascript">
    $(function () {
        $('input[name="daterange"]').daterangepicker();
    });

    n = new Date();
    y = n.getFullYear();
    m = n.getMonth() + 1;
    d = n.getDate();
    document.getElementById("today").value = m + "/" + d + "/" + y;

</script>
</html>
