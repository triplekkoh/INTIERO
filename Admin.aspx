<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>340CT INTI ERO</title>
    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../Picture/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: White;
                background: url("../Picture/SelectedButton.png") no-repeat right top;
            }

        .Clicked {
            float: left;
            display: block;
            background: url("../Picture/SelectedButton.png") no-repeat right top;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: White;
        }
    </style>
</head>
<body>
    <h1>340CT INTI ERO</h1>

    <script type="text/javascript" lang="javascript">
        function CheckCheck() {
            var chkBoxCount = this.getElementsByTagName("input");
            var max = 5;
            var i = 0;
            var tot = 0;
            for (i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked) {
                    tot = tot + 1;
                }
            }

            if (tot > max) {
                var k = 0;
                for (i = 0; i < chkBoxCount.length; i++) {
                    if (chkBoxCount[i].checked) {
                        k++;
                        if (k > max) {
                            chkBoxCount[i].checked = false;
                            alert('Cannot pick more than ' + max + ' courses.');
                        }
                    }
                }
            }
        }
    </script>
    <form id="form1" runat="server">
        <asp:Button Text="Student" BorderStyle="None" ID="StudentTab" CssClass="Initial" runat="server" OnClick="StudentTab_Click" />
        <asp:Button Text="Lecturer" BorderStyle="None" ID="LecturerTab" CssClass="Initial" runat="server" OnClick="LecturerTab_Click" />
        <asp:Button Text="Subject" BorderStyle="None" ID="SubjectTab" CssClass="Initial" runat="server" OnClick="SubjectTab_Click" />
        <asp:Button Text="Semester" BorderStyle="None" ID="SemesterTab" CssClass="Initial" runat="server" OnClick="SemesterTab_Click" />
        <asp:MultiView ID="MainView" runat="server">

            <asp:View ID="StudentView" runat="server">
                <div>
                    <h2>Student Registration</h2>
                </div>
                <div>
                    <asp:GridView ID="StudentGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBoundStudent" ShowFooter="true" OnRowDeleting="StudentGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="#" />
                            <asp:TemplateField HeaderText="Student Name" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentName" runat="server" Text='<%# Eval("StudentName") %>' />
                                    <asp:RequiredFieldValidator ID="StudentNameValidator" runat="server" ControlToValidate="StudentName" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentNameValidator1" runat="server" ControlToValidate="StudentName" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student ID" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentID" runat="server" Text='<%# Eval("StudentID") %>' />
                                    <asp:RequiredFieldValidator ID="StudentIDValidator" runat="server" ControlToValidate="StudentID" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentIDValidator1" runat="server" ControlToValidate="StudentID" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Address" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentAddress" runat="server" Text='<%# Eval("StudentAddress") %>' Width="200" Height="50px" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ID="StudentAddressValidator" runat="server" ControlToValidate="StudentAddress" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentAddressValidator1" runat="server" ControlToValidate="StudentAddress" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Phone Number" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentPNumber" runat="server" Text='<%# Eval("StudentPNumber") %>' />
                                    <asp:RequiredFieldValidator ID="StudentPNumberValidator" runat="server" ControlToValidate="StudentPNumber" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentPNumberValidator1" runat="server" ControlToValidate="StudentPNumber" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Email Address" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentEAddress" runat="server" Text='<%# Eval("StudentEAddress") %>' />
                                    <asp:RequiredFieldValidator ID="StudentEAddressValidator" runat="server" ControlToValidate="StudentEAddress" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentEAddressValidator1" runat="server" ControlToValidate="StudentEAddress" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                    <asp:RegularExpressionValidator ID="StudentEAddressValidator2" runat="server" ControlToValidate="StudentEAddress" ErrorMessage="Email format incorrect." ValidationGroup="StudentGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Course" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:DropDownList ID="StudentCourse" runat="server" Width="200" />
                                    <asp:RequiredFieldValidator ID="StudentCourseValidator" runat="server" ControlToValidate="StudentCourse" ErrorMessage="*" InitialValue="-- Select Course --" ValidationGroup="StudentGroup" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Password" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="StudentPassword" runat="server" Text='<%# Eval("StudentPassword") %>' />
                                    <asp:RequiredFieldValidator ID="StudentPasswordValidator" runat="server" ControlToValidate="StudentPassword" ErrorMessage="*" ValidationGroup="StudentGroup" />
                                    <asp:RegularExpressionValidator ID="StudentPasswordValidator1" runat="server" ControlToValidate="StudentPassword" ErrorMessage="Cannot contain '." ValidationGroup="StudentGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ValidationGroup="StudentGroup" />
                        </Columns>
                    </asp:GridView>
                    <asp:ImageButton ID="ButtonSaveNewStudent" runat="server" OnClick="ButtonSaveNewStudent_Click" ValidationGroup="StudentGroup" ImageUrl="Picture\Save.jpg" ImageAlign="Right" Width="50px" Height="50px" />
                    <asp:ImageButton ID="ButtonAddNewStudent" runat="server" OnClick="ButtonAddNewStudent_Click" ValidationGroup="StudentGroup" ImageUrl="Picture\Student_Add.jpg" ImageAlign="Right" Width="50px" Height="50px" />
                </div>
            </asp:View>

            <asp:View ID="LecturerView" runat="server">
                <div>
                    <h2>Lecturer Registration</h2>
                </div>
                <div>
                    <asp:GridView ID="LecturerGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBoundLecturer" ShowFooter="true" OnRowDeleting="LecturerGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="#" />
                            <asp:TemplateField HeaderText="Lecturer Name" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerName" runat="server" Text='<%# Eval("LecturerName") %>' />
                                    <asp:RequiredFieldValidator ID="LecturerNameValidator" runat="server" ControlToValidate="LecturerName" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerNameValidator1" runat="server" ControlToValidate="LecturerName" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer ID" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerID" runat="server" Text='<%# Eval("LecturerID") %>' />
                                    <asp:RequiredFieldValidator ID="LecturerIDValidator" runat="server" ControlToValidate="LecturerID" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerIDValidator1" runat="server" ControlToValidate="LecturerID" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer Address" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerAddress" runat="server" Text='<%# Eval("LecturerAddress") %>' Width="200" Height="50px" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ID="LecturerAddressValidator" runat="server" ControlToValidate="LecturerAddress" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerAddressValidator1" runat="server" ControlToValidate="LecturerAddress" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer Phone Number" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerPNumber" runat="server" Text='<%# Eval("LecturerPNumber") %>' />
                                    <asp:RequiredFieldValidator ID="LecturerPNumberValidator" runat="server" ControlToValidate="LecturerPNumber" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerPNumberValidator1" runat="server" ControlToValidate="LecturerPNumber" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer Email Address" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerEAddress" runat="server" Text='<%# Eval("LecturerEAddress") %>' />
                                    <asp:RequiredFieldValidator ID="LecturerEAddressValidator" runat="server" ControlToValidate="LecturerEAddress" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerEAddressValidator1" runat="server" ControlToValidate="LecturerEAddress" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                    <asp:RegularExpressionValidator ID="LecturerEAddressValidator2" runat="server" ControlToValidate="LecturerEAddress" ErrorMessage="Email format incorrect." ValidationGroup="LecturerGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer Course" ItemStyle-Width="250">
                                <ItemTemplate>
                                    <div style="width: 250px; height: 50px; overflow-y: auto">
                                        <asp:CheckBoxList ID="LecturerCourse" runat="server" SelectionMode="Multiple" Width="200" RepeatLayout="OrderedList" Font-Size="X-Small" onclick="javascript:CheckCheck.call(this);" AutoPostBack="true" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lecturer Password" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:TextBox ID="LecturerPassword" runat="server" Text='<%# Eval("LecturerPassword") %>' />
                                    <asp:RequiredFieldValidator ID="LecturerPasswordValidator" runat="server" ControlToValidate="LecturerPassword" ErrorMessage="*" ValidationGroup="LecturerGroup" />
                                    <asp:RegularExpressionValidator ID="LecturerPasswordValidator1" runat="server" ControlToValidate="LecturerPassword" ErrorMessage="Cannot contain '." ValidationGroup="LecturerGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ValidationGroup="LecturerGroup" />
                        </Columns>
                    </asp:GridView>
                    <asp:ImageButton ID="ButtonSaveNewLecturer" runat="server" OnClick="ButtonSaveNewLecturer_Click" ValidationGroup="LecturerGroup" ImageUrl="~/Picture/Save.jpg" ImageAlign="Right" Width="50px" Height="50px" />
                    <asp:ImageButton ID="ButtonAddNewLecturer" runat="server" OnClick="ButtonAddNewLecturer_Click" ValidationGroup="LecturerGroup" ImageUrl="~/Picture/Lecturer_Add.jpg" ImageAlign="Right" Width="50px" Height="50px" />
                </div>
            </asp:View>

            <asp:View ID="SubjectView" runat="server">
                <div>
                    <h2>Subject Registration</h2>
                </div>
                <div>
                    <asp:GridView ID="SubjectGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBoundSubject" ShowFooter="true" OnRowDeleting="SubjectGridView_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="#" />
                            <asp:TemplateField HeaderText="Subject Name" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:TextBox ID="SubjectName" runat="server" Text='<%# Eval("SubjectName") %>' />
                                    <asp:RequiredFieldValidator ID="SubjectNameValidator" runat="server" ControlToValidate="SubjectName" ErrorMessage="*" ValidationGroup="SubjectGroup" />
                                    <asp:RegularExpressionValidator ID="SubjectNameValidator1" runat="server" ControlToValidate="SubjectName" ErrorMessage="Cannot contain '." ValidationGroup="SubjectGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject ID" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:TextBox ID="SubjectID" runat="server" Text='<%# Eval("SubjectID") %>' />
                                    <asp:RequiredFieldValidator ID="SubjectIDValidator" runat="server" ControlToValidate="SubjectID" ErrorMessage="*" ValidationGroup="SubjectGroup" />
                                    <asp:RegularExpressionValidator ID="SubjectIDValidator1" runat="server" ControlToValidate="SubjectID" ErrorMessage="Cannot contain '." ValidationGroup="SubjectGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Credit Hour" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:TextBox ID="SubjectCreditHour" runat="server" Text='<%# Eval("SubjectCreditHour") %>' />
                                    <asp:RequiredFieldValidator ID="SubjectCreditHourValidator" runat="server" ControlToValidate="SubjectCreditHour" ErrorMessage="*" ValidationGroup="SubjectGroup" />
                                    <asp:CompareValidator ID="SubjectCreditHourValidator1" runat="server" ControlToValidate="SubjectCreditHour" ErrorMessage="Must be number." Operator="DataTypeCheck" Type="Integer" ValidationGroup="SubjectGroup" />
                                    <asp:RegularExpressionValidator ID="SubjectCreditHourValidator2" runat="server" ControlToValidate="SubjectCreditHour" ErrorMessage="Cannot contain '." ValidationGroup="SubjectGroup" ValidationExpression="[^']*" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Course" ItemStyle-Width="200">
                                <ItemTemplate>
                                    <asp:DropDownList ID="SubjectCourse" runat="server" Width="200" />
                                    <asp:RequiredFieldValidator ID="SubjectCourseValidator" runat="server" ControlToValidate="SubjectCourse" ErrorMessage="*" InitialValue="-- Select Course --" ValidationGroup="SubjectGroup" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ValidationGroup="SubjectGroup" />
                        </Columns>
                    </asp:GridView>
                    <div align="center" style="width: 1500px">
                        <asp:ImageButton ID="ButtonAddNewSubject" runat="server" OnClick="ButtonAddNewSubject_Click" ValidationGroup="SubjectGroup" ImageUrl="Picture\Add.ico" Style="position: relative; top: 2px" Width="50px" Height="50px" />
                        <asp:ImageButton ID="ButtonSaveNewSubject" runat="server" OnClick="ButtonSaveNewSubject_Click" ValidationGroup="SubjectGroup" ImageUrl="Picture\Save.jpg" Style="position: relative; top: 2px" Width="50px" Height="50px" />
                    </div>
                </div>
            </asp:View>

            <asp:View ID="SemesterView" runat="server">
                </asp:View>

        </asp:MultiView>
    </form>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
