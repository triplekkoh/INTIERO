<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateResult.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
    <form id="form1" runat="server" style="margin-left:1%;margin-top:1%">
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <h2>Student Exam Result</h2>
        <div>
            
        </div>
        <div>
            <asp:DropDownList ID="Subjectddl" runat="server"></asp:DropDownList>
            <asp:Button ID="Selectbtn" runat="server" Text="Select" CssClass="btn btn-primary" OnClick="Selectbtn_Click" Style="height: 28px; font-size: 11px;"/>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" >
                <Columns>


                    <asp:TemplateField HeaderText="Subject" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Subject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NAME">
                        <ItemTemplate>
                            <asp:Label ID="lbl_NAME" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    


                    <asp:TemplateField HeaderText="Result">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Result" runat="server" Text='<%#Eval("Result") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>            
            <br />
                <asp:Button ID="Updatebtn" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Updatebtn_Click"/>
            
            

        </div>
    </form>
</body>
</html>
