using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            StudentTab.CssClass = "Clicked";
            MainView.ActiveViewIndex = 0;
            DisplayStudentGridView();
            DisplayLecturerGridView();
            DisplaySubjectGridView();
        }
    }

    protected void StudentTab_Click(object sender, EventArgs e)
    {
        StudentTab.CssClass = "Clicked";
        LecturerTab.CssClass = "Initial";
        SubjectTab.CssClass = "Initial";
        SemesterTab.CssClass = "Initial";
        MainView.ActiveViewIndex = 0;
    }

    protected void LecturerTab_Click(object sender, EventArgs e)
    {
        StudentTab.CssClass = "Initial";
        LecturerTab.CssClass = "Clicked";
        SubjectTab.CssClass = "Initial";
        SemesterTab.CssClass = "Initial";
        MainView.ActiveViewIndex = 1;
    }

    protected void SubjectTab_Click(object sender, EventArgs e)
    {
        StudentTab.CssClass = "Initial";
        LecturerTab.CssClass = "Initial";
        SubjectTab.CssClass = "Clicked";
        SemesterTab.CssClass = "Initial";
        MainView.ActiveViewIndex = 2;
    }
    protected void SemesterTab_Click(object sender, EventArgs e)
    {
        StudentTab.CssClass = "Initial";
        LecturerTab.CssClass = "Initial";
        SubjectTab.CssClass = "Initial";
        SemesterTab.CssClass = "Clicked";
        MainView.ActiveViewIndex = 3;
    }
    //Student
    private void DisplayStudentGridView()
    {
        DataTable dataTableEmpty = new DataTable();
        DataRow dataRowEmpty = null;
        dataTableEmpty.Columns.Add(new DataColumn("RowNumber"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentName"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentID"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentAddress"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentPNumber"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentEAddress"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentCourse"));
        dataTableEmpty.Columns.Add(new DataColumn("StudentPassword"));

        dataRowEmpty = dataTableEmpty.NewRow();
        dataRowEmpty["RowNumber"] = 1;
        dataRowEmpty["StudentName"] = "";
        dataRowEmpty["StudentID"] = "";
        dataRowEmpty["StudentAddress"] = "";
        dataRowEmpty["StudentPNumber"] = "";
        dataRowEmpty["StudentEAddress"] = "";
        dataRowEmpty["StudentCourse"] = "";
        dataRowEmpty["StudentPassword"] = "";
        dataTableEmpty.Rows.Add(dataRowEmpty);

        ViewState["StudentGridView"] = dataTableEmpty;
        StudentGridView.DataSource = dataTableEmpty;
        StudentGridView.DataBind();
    }

    private DataSet GetData(string query)
    {
        string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlCommand sqlCommand = new SqlCommand(query);
        using (SqlConnection sqlConnection = new SqlConnection(mycon))
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter.SelectCommand = sqlCommand;
                using (DataSet dataSet = new DataSet())
                {
                    sqlDataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }
    }

    protected void OnRowDataBoundStudent(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList dropDownListStudent = (e.Row.FindControl("StudentCourse") as DropDownList);
            dropDownListStudent.DataSource = GetData("SELECT COURSEID + ' ' + ' ' + ' ' + COURSENAME AS COURSE1 FROM COURSE;");
            dropDownListStudent.DataTextField = "COURSE1";
            dropDownListStudent.DataValueField = "COURSE1";
            dropDownListStudent.DataBind();

            dropDownListStudent.Items.Insert(0, "-- Select Course --");
        }
    }

    private void SetPreviousDataStudent()
    {
        int rowIndex = 0;
        if (ViewState["StudentGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["StudentGridView"];
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 0; i < dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSName = (TextBox)StudentGridView.Rows[rowIndex].Cells[1].FindControl("StudentName");
                    TextBox textBoxSID = (TextBox)StudentGridView.Rows[rowIndex].Cells[2].FindControl("StudentID");
                    TextBox textBoxSAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[3].FindControl("StudentAddress");
                    TextBox textBoxSPNumber = (TextBox)StudentGridView.Rows[rowIndex].Cells[4].FindControl("StudentPNumber");
                    TextBox textBoxSEAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[5].FindControl("StudentEAddress");
                    DropDownList dropDownListSCourse = (DropDownList)StudentGridView.Rows[rowIndex].Cells[6].FindControl("StudentCourse");
                    TextBox textBoxSPassword = (TextBox)StudentGridView.Rows[rowIndex].Cells[7].FindControl("StudentPassword");

                    StudentGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    textBoxSName.Text = dataTableCurrent.Rows[i]["StudentName"].ToString();
                    textBoxSID.Text = dataTableCurrent.Rows[i]["StudentID"].ToString();
                    textBoxSAdd.Text = dataTableCurrent.Rows[i]["StudentAddress"].ToString();
                    textBoxSPNumber.Text = dataTableCurrent.Rows[i]["StudentPNumber"].ToString();
                    textBoxSEAdd.Text = dataTableCurrent.Rows[i]["StudentEAddress"].ToString();
                    dropDownListSCourse.SelectedValue = dataTableCurrent.Rows[i]["StudentCourse"].ToString();
                    textBoxSPassword.Text = dataTableCurrent.Rows[i]["StudentPassword"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    private void AddNewRowToStudentGV()
    {
        int rowIndex = 0;
        if (ViewState["StudentGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["StudentGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSName = (TextBox)StudentGridView.Rows[rowIndex].Cells[1].FindControl("StudentName");
                    TextBox textBoxSID = (TextBox)StudentGridView.Rows[rowIndex].Cells[2].FindControl("StudentID");
                    TextBox textBoxSAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[3].FindControl("StudentAddress");
                    TextBox textBoxSPNumber = (TextBox)StudentGridView.Rows[rowIndex].Cells[4].FindControl("StudentPNumber");
                    TextBox textBoxSEAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[5].FindControl("StudentEAddress");
                    DropDownList dropDownListSCourse = (DropDownList)StudentGridView.Rows[rowIndex].Cells[6].FindControl("StudentCourse");
                    TextBox textBoxSPassword = (TextBox)StudentGridView.Rows[rowIndex].Cells[7].FindControl("StudentPassword");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["StudentName"] = textBoxSName.Text;
                    dataTableCurrent.Rows[i - 1]["StudentID"] = textBoxSID.Text;
                    dataTableCurrent.Rows[i - 1]["StudentAddress"] = textBoxSAdd.Text;
                    dataTableCurrent.Rows[i - 1]["StudentPNumber"] = textBoxSPNumber.Text;
                    dataTableCurrent.Rows[i - 1]["StudentEAddress"] = textBoxSEAdd.Text;
                    dataTableCurrent.Rows[i - 1]["StudentCourse"] = dropDownListSCourse.SelectedValue;
                    dataTableCurrent.Rows[i - 1]["StudentPassword"] = textBoxSPassword.Text;

                    rowIndex++;
                }

                dataTableCurrent.Rows.Add(dataRowCurrent);
                ViewState["StudentGridView"] = dataTableCurrent;

                StudentGridView.DataSource = dataTableCurrent;
                StudentGridView.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
        SetPreviousDataStudent();
    }

    protected void ButtonAddNewStudent_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AddNewRowToStudentGV();
        }
    }

    private void SetRowDataStudent()
    {
        int rowIndex = 0;
        if (ViewState["StudentGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["StudentGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSName = (TextBox)StudentGridView.Rows[rowIndex].Cells[1].FindControl("StudentName");
                    TextBox textBoxSID = (TextBox)StudentGridView.Rows[rowIndex].Cells[2].FindControl("StudentID");
                    TextBox textBoxSAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[3].FindControl("StudentAddress");
                    TextBox textBoxSPNumber = (TextBox)StudentGridView.Rows[rowIndex].Cells[4].FindControl("StudentPNumber");
                    TextBox textBoxSEAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[5].FindControl("StudentEAddress");
                    DropDownList dropDownListSCourse = (DropDownList)StudentGridView.Rows[rowIndex].Cells[6].FindControl("StudentCourse");
                    TextBox textBoxSPassword = (TextBox)StudentGridView.Rows[rowIndex].Cells[7].FindControl("StudentPassword");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["StudentName"] = textBoxSName.Text;
                    dataTableCurrent.Rows[i - 1]["StudentID"] = textBoxSID.Text;
                    dataTableCurrent.Rows[i - 1]["StudentAddress"] = textBoxSAdd.Text;
                    dataTableCurrent.Rows[i - 1]["StudentPNumber"] = textBoxSPNumber.Text;
                    dataTableCurrent.Rows[i - 1]["StudentEAddress"] = textBoxSEAdd.Text;
                    dataTableCurrent.Rows[i - 1]["StudentCourse"] = dropDownListSCourse.SelectedValue;
                    dataTableCurrent.Rows[i - 1]["StudentPassword"] = textBoxSPassword.Text;

                    rowIndex++;
                }

                ViewState["StudentGridView"] = dataTableCurrent;
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
    }

    protected void StudentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowDataStudent();
        if (ViewState["StudentGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["StudentGridView"];
            DataRow dataRowCurrent = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dataTableCurrent.Rows.Count > 1)
            {
                dataTableCurrent.Rows.Remove(dataTableCurrent.Rows[rowIndex]);
                dataRowCurrent = dataTableCurrent.NewRow();
                ViewState["StudentGridView"] = dataTableCurrent;
                StudentGridView.DataSource = dataTableCurrent;
                StudentGridView.DataBind();

                for (int i = 0; i < StudentGridView.Rows.Count - 1; i++)
                {
                    StudentGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousDataStudent();
            }
        }
    }

    private string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
    }

    private string SaveAllNewStudent(StringCollection stringCollection)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        StringBuilder stringBuilder = new StringBuilder(string.Empty);
        StringBuilder stringBuilder1 = new StringBuilder(string.Empty);
        string[] splitItems = null;
        string[] splitItems1 = null;
        foreach (string item in stringCollection)
        {
            const string sqlQuery = "INSERT INTO STUDENT (NAME, ID, ADDRESS, PHONENUMBER, EMAILADDRESS, COURSE) VALUES";
            if (item.Contains("~"))
            {
                splitItems = item.Split("~".ToCharArray());
                stringBuilder.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}');", sqlQuery, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5]);
            }
        }
        foreach (string item1 in stringCollection)
        {
            const string sqlQuery1 = "INSERT INTO LOGINTB (USERID, PASSWORD, MEMBERSTAT, EMAIL) VALUES";
            if (item1.Contains("~"))
            {
                splitItems1 = item1.Split("~".ToCharArray());
                stringBuilder1.AppendFormat("{0}('{1}','{2}','{3}','{4}');", sqlQuery1, splitItems1[1], splitItems1[6], 4, splitItems1[4]);
            }
        }
        try
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection);
            SqlCommand sqlCommand1 = new SqlCommand(stringBuilder1.ToString(), sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();
            sqlCommand1.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            string message = e.Message.ToString();
            //throw new Exception(message);
            //Response.Write("<script>alert('123456789')</script>");
            return "-1";
        }
        finally
        {
            sqlConnection.Close();
        }
        return "0";
    }

    protected void ButtonSaveNewStudent_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int rowIndex = 0;
            StringCollection stringCollection = new StringCollection();
            String status;
            if (ViewState["StudentGridView"] != null)
            {
                DataTable dataTableCurrent = (DataTable)ViewState["StudentGridView"];
                if (dataTableCurrent.Rows.Count > 0)
                {
                    for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                    {
                        TextBox textBoxSName = (TextBox)StudentGridView.Rows[rowIndex].Cells[1].FindControl("StudentName");
                        TextBox textBoxSID = (TextBox)StudentGridView.Rows[rowIndex].Cells[2].FindControl("StudentID");
                        TextBox textBoxSAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[3].FindControl("StudentAddress");
                        TextBox textBoxSPNumber = (TextBox)StudentGridView.Rows[rowIndex].Cells[4].FindControl("StudentPNumber");
                        TextBox textBoxSEAdd = (TextBox)StudentGridView.Rows[rowIndex].Cells[5].FindControl("StudentEAddress");
                        DropDownList dropDownListSCourse = (DropDownList)StudentGridView.Rows[rowIndex].Cells[6].FindControl("StudentCourse");
                        TextBox textBoxSPassword = (TextBox)StudentGridView.Rows[rowIndex].Cells[7].FindControl("StudentPassword");
                        stringCollection.Add(textBoxSName.Text + "~" + textBoxSID.Text + "~" + textBoxSAdd.Text + "~" + textBoxSPNumber.Text + "~"
                            + textBoxSEAdd.Text + "~" + dropDownListSCourse.SelectedValue.ToString() + "~" + textBoxSPassword.Text);
                        rowIndex++;
                    }
                }
            }
            status = SaveAllNewStudent(stringCollection);
            if (status.Equals("-1"))
            {
                Response.Write("<script>alert('One or more entry already available in the database.')</script>");
            }
            else if (status.Equals("0"))
            {
                Response.Write("<script>alert('All entry for student are successfully saved.')</script>");
                DisplayStudentGridView();
            }
        }
    }

    //Lecturer
    private void DisplayLecturerGridView()
    {
        DataTable dataTableEmpty = new DataTable();
        DataRow dataRowEmpty = null;
        dataTableEmpty.Columns.Add(new DataColumn("RowNumber"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerName"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerID"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerAddress"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerPNumber"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerEAddress"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerCourse"));
        dataTableEmpty.Columns.Add(new DataColumn("LecturerPassword"));

        dataRowEmpty = dataTableEmpty.NewRow();
        dataRowEmpty["RowNumber"] = 1;
        dataRowEmpty["LecturerName"] = "";
        dataRowEmpty["LecturerID"] = "";
        dataRowEmpty["LecturerAddress"] = "";
        dataRowEmpty["LecturerPNumber"] = "";
        dataRowEmpty["LecturerEAddress"] = "";
        dataRowEmpty["LecturerCourse"] = "";
        dataRowEmpty["LecturerPassword"] = "";
        dataTableEmpty.Rows.Add(dataRowEmpty);

        ViewState["LecturerGridView"] = dataTableEmpty;
        LecturerGridView.DataSource = dataTableEmpty;
        LecturerGridView.DataBind();
    }

    protected void OnRowDataBoundLecturer(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBoxList checkBoxListLecturer = (e.Row.FindControl("LecturerCourse") as CheckBoxList);
            checkBoxListLecturer.DataSource = GetData("SELECT COURSEID + ' ' + ' ' + ' ' + COURSENAME AS COURSE1 FROM COURSE;");
            checkBoxListLecturer.DataTextField = "COURSE1";
            checkBoxListLecturer.DataValueField = "COURSE1";
            checkBoxListLecturer.DataBind();

            //listBoxLecturer.Items.Insert(0, "-- Select Course --");
        }
    }

    private void SetPreviousDataLecturer()
    {
        int rowIndex = 0;

        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 0; i < dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                    TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                    TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                    TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                    TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                    CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                    TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");

                    LecturerGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    textBoxLName.Text = dataTableCurrent.Rows[i]["LecturerName"].ToString();
                    textBoxLID.Text = dataTableCurrent.Rows[i]["LecturerID"].ToString();
                    textBoxLAdd.Text = dataTableCurrent.Rows[i]["LecturerAddress"].ToString();
                    textBoxLPNumber.Text = dataTableCurrent.Rows[i]["LecturerPNumber"].ToString();
                    textBoxLEAdd.Text = dataTableCurrent.Rows[i]["LecturerEAddress"].ToString();
                    checkBoxListLCourse.Text = dataTableCurrent.Rows[i]["LecturerCourse"].ToString();
                    string lecturerCourse = dataTableCurrent.Rows[i]["LecturerCourse"].ToString();
                    if (!string.IsNullOrEmpty(lecturerCourse))
                    {
                        for (int j = 0; j < lecturerCourse.Split(',').Length; j++)
                        {
                            checkBoxListLCourse.Items.FindByValue(lecturerCourse.Split(',')[j].ToString()).Selected = true;
                        }
                    }
                    textBoxLPassword.Text = dataTableCurrent.Rows[i]["LecturerPassword"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    private void AddNewRowToLecturerGV()
    {
        int rowIndex = 0;

        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                    TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                    TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                    TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                    TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                    CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                    TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["LecturerName"] = textBoxLName.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerID"] = textBoxLID.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerAddress"] = textBoxLAdd.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerPNumber"] = textBoxLPNumber.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerEAddress"] = textBoxLEAdd.Text;
                    string lecturerCourse = string.Empty;
                    foreach (ListItem item in checkBoxListLCourse.Items)
                    {
                        if (item.Selected)
                        {
                            if (!string.IsNullOrEmpty(lecturerCourse))
                            {
                                lecturerCourse += ",";
                            }
                            lecturerCourse += item.Value;
                        }
                    }
                    dataTableCurrent.Rows[i - 1]["LecturerCourse"] = lecturerCourse;
                    dataTableCurrent.Rows[i - 1]["LecturerPassword"] = textBoxLPassword.Text;
                    rowIndex++;
                }
                dataTableCurrent.Rows.Add(dataRowCurrent);
                ViewState["LecturerGridView"] = dataTableCurrent;

                LecturerGridView.DataSource = dataTableCurrent;
                LecturerGridView.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
        SetPreviousDataLecturer();
    }

    protected void ButtonAddNewLecturer_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AddNewRowToLecturerGV();
        }
    }

    private void SetRowDataLecturer()
    {
        int rowIndex = 0;
        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                    TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                    TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                    TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                    TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                    CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                    TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["LecturerName"] = textBoxLName.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerID"] = textBoxLID.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerAddress"] = textBoxLAdd.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerPNumber"] = textBoxLPNumber.Text;
                    dataTableCurrent.Rows[i - 1]["LecturerEAddress"] = textBoxLEAdd.Text;
                    string lecturerCourse = string.Empty;
                    foreach (ListItem item in checkBoxListLCourse.Items)
                    {
                        if (item.Selected)
                        {
                            if (!string.IsNullOrEmpty(lecturerCourse))
                            {
                                lecturerCourse += ",";
                            }
                            lecturerCourse += item.Value;
                        }
                    }
                    dataTableCurrent.Rows[i - 1]["LecturerCourse"] = lecturerCourse;
                    dataTableCurrent.Rows[i - 1]["LecturerPassword"] = textBoxLPassword.Text;

                    rowIndex++;
                }

                ViewState["LecturerGridView"] = dataTableCurrent;
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
    }

    protected void LecturerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowDataLecturer();
        if (ViewState["LecturerGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
            DataRow dataRowCurrent = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dataTableCurrent.Rows.Count > 1)
            {
                dataTableCurrent.Rows.Remove(dataTableCurrent.Rows[rowIndex]);
                dataRowCurrent = dataTableCurrent.NewRow();
                ViewState["LecturerGridView"] = dataTableCurrent;
                LecturerGridView.DataSource = dataTableCurrent;
                LecturerGridView.DataBind();

                for (int i = 0; i < LecturerGridView.Rows.Count - 1; i++)
                {
                    LecturerGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousDataLecturer();
            }
        }
    }

    protected void ButtonSaveNewLecturer_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int rowIndex = 0;
            string k = "";
            string status = "";
            if (ViewState["LecturerGridView"] != null)
            {
                DataTable dataTableCurrent = (DataTable)ViewState["LecturerGridView"];
                if (dataTableCurrent.Rows.Count > 0)
                {
                    for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                    {
                        TextBox textBoxLName = (TextBox)LecturerGridView.Rows[rowIndex].Cells[1].FindControl("LecturerName");
                        TextBox textBoxLID = (TextBox)LecturerGridView.Rows[rowIndex].Cells[2].FindControl("LecturerID");
                        TextBox textBoxLAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[3].FindControl("LecturerAddress");
                        TextBox textBoxLPNumber = (TextBox)LecturerGridView.Rows[rowIndex].Cells[4].FindControl("LecturerPNumber");
                        TextBox textBoxLEAdd = (TextBox)LecturerGridView.Rows[rowIndex].Cells[5].FindControl("LecturerEAddress");
                        CheckBoxList checkBoxListLCourse = (CheckBoxList)LecturerGridView.Rows[rowIndex].Cells[6].FindControl("LecturerCourse");
                        for (int j = 0; j < checkBoxListLCourse.Items.Count; j++)
                        {
                            if (checkBoxListLCourse.Items[j].Selected)
                            {
                                k = k + checkBoxListLCourse.Items[j].Text + ", ";
                            }
                        }
                        TextBox textBoxLPassword = (TextBox)LecturerGridView.Rows[rowIndex].Cells[7].FindControl("LecturerPassword");

                        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
                        StringBuilder stringBuilder = new StringBuilder(string.Empty);
                        const string sqlQuery = "INSERT INTO LECTURER(NAME, ID, ADDRESS, PHONENUMBER, EMAILADDRESS, COURSE) VALUES";
                        stringBuilder.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}');", sqlQuery, textBoxLName.Text, textBoxLID.Text, textBoxLAdd.Text, textBoxLPNumber.Text, textBoxLEAdd.Text, k);
                        StringBuilder stringBuilder1 = new StringBuilder(string.Empty);
                        const string sqlQuery1 = "INSERT INTO LOGINTB (USERID, PASSWORD, MEMBERSTAT, EMAIL) VALUES";
                        stringBuilder1.AppendFormat("{0}('{1}','{2}','{3}','{4}');", sqlQuery1, textBoxLID.Text, textBoxLPassword.Text, 2, textBoxLEAdd.Text);
                        try
                        {
                            sqlConnection.Open();
                            SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection);
                            SqlCommand sqlCommand1 = new SqlCommand(stringBuilder1.ToString(), sqlConnection);
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand1.CommandType = CommandType.Text;
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand1.ExecuteNonQuery();
                        }
                        catch (System.Data.SqlClient.SqlException error)
                        {
                            string message = error.Message.ToString();
                            //throw new Exception(message);
                            //Response.Write("<script>alert('123456789')</script>");
                            status = "1";
                        }
                        finally
                        {
                            sqlConnection.Close();

                        }
                        rowIndex++;
                    }
                    if (status.Equals("1"))
                    {
                        Response.Write("<script>alert('One or more entry already available in the database.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('All entry for lecturer are successfully saved.')</script>");
                        DisplayLecturerGridView();
                    }
                }
            }
        }
    }

    //Subject
    private void DisplaySubjectGridView()
    {
        DataTable dataTableEmpty = new DataTable();
        DataRow dataRowEmpty = null;
        dataTableEmpty.Columns.Add(new DataColumn("RowNumber"));
        dataTableEmpty.Columns.Add(new DataColumn("SubjectName"));
        dataTableEmpty.Columns.Add(new DataColumn("SubjectID"));
        dataTableEmpty.Columns.Add(new DataColumn("SubjectCreditHour"));
        dataTableEmpty.Columns.Add(new DataColumn("SubjectCourse"));

        dataRowEmpty = dataTableEmpty.NewRow();
        dataRowEmpty["RowNumber"] = 1;
        dataRowEmpty["SubjectName"] = "";
        dataRowEmpty["SubjectID"] = "";
        dataRowEmpty["SubjectCreditHour"] = "";
        dataRowEmpty["SubjectCourse"] = "";
        dataTableEmpty.Rows.Add(dataRowEmpty);

        ViewState["SubjectGridView"] = dataTableEmpty;
        SubjectGridView.DataSource = dataTableEmpty;
        SubjectGridView.DataBind();
    }

    protected void OnRowDataBoundSubject(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList dropDownListSubject = (e.Row.FindControl("SubjectCourse") as DropDownList);
            dropDownListSubject.DataSource = GetData("SELECT COURSEID + ' ' + ' ' + ' ' + COURSENAME AS COURSE1 FROM COURSE;");
            dropDownListSubject.DataTextField = "COURSE1";
            dropDownListSubject.DataValueField = "COURSE1";
            dropDownListSubject.DataBind();

            dropDownListSubject.Items.Insert(0, "-- Select Course --");
        }
    }

    private void SetPreviousDataSubject()
    {
        int rowIndex = 0;
        if (ViewState["SubjectGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["SubjectGridView"];
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 0; i < dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSubName = (TextBox)SubjectGridView.Rows[rowIndex].Cells[1].FindControl("SubjectName");
                    TextBox textBoxSubID = (TextBox)SubjectGridView.Rows[rowIndex].Cells[2].FindControl("SubjectID");
                    TextBox textBoxSubCHour = (TextBox)SubjectGridView.Rows[rowIndex].Cells[3].FindControl("SubjectCreditHour");
                    DropDownList dropDownListSubCourse = (DropDownList)SubjectGridView.Rows[rowIndex].Cells[4].FindControl("SubjectCourse");

                    SubjectGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    textBoxSubName.Text = dataTableCurrent.Rows[i]["SubjectName"].ToString();
                    textBoxSubID.Text = dataTableCurrent.Rows[i]["SubjectID"].ToString();
                    textBoxSubCHour.Text = dataTableCurrent.Rows[i]["SubjectCreditHour"].ToString();
                    dropDownListSubCourse.SelectedValue = dataTableCurrent.Rows[i]["SubjectCourse"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    private void AddNewRowToSubjectGV()
    {
        int rowIndex = 0;
        if (ViewState["SubjectGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["SubjectGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSubName = (TextBox)SubjectGridView.Rows[rowIndex].Cells[1].FindControl("SubjectName");
                    TextBox textBoxSubID = (TextBox)SubjectGridView.Rows[rowIndex].Cells[2].FindControl("SubjectID");
                    TextBox textBoxSubCHour = (TextBox)SubjectGridView.Rows[rowIndex].Cells[3].FindControl("SubjectCreditHour");
                    DropDownList dropDownListSubCourse = (DropDownList)SubjectGridView.Rows[rowIndex].Cells[4].FindControl("SubjectCourse");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["SubjectName"] = textBoxSubName.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectID"] = textBoxSubID.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectCreditHour"] = textBoxSubCHour.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectCourse"] = dropDownListSubCourse.SelectedValue;

                    rowIndex++;
                }

                dataTableCurrent.Rows.Add(dataRowCurrent);
                ViewState["SubjectGridView"] = dataTableCurrent;

                SubjectGridView.DataSource = dataTableCurrent;
                SubjectGridView.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
        SetPreviousDataSubject();
    }

    protected void ButtonAddNewSubject_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AddNewRowToSubjectGV();
        }
    }

    private void SetRowDataSubject()
    {
        int rowIndex = 0;
        if (ViewState["SubjectGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["SubjectGridView"];
            DataRow dataRowCurrent = null;
            if (dataTableCurrent.Rows.Count > 0)
            {
                for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                {
                    TextBox textBoxSubName = (TextBox)SubjectGridView.Rows[rowIndex].Cells[1].FindControl("SubjectName");
                    TextBox textBoxSubID = (TextBox)SubjectGridView.Rows[rowIndex].Cells[2].FindControl("SubjectID");
                    TextBox textBoxSubCHour = (TextBox)SubjectGridView.Rows[rowIndex].Cells[3].FindControl("SubjectCreditHour");
                    DropDownList dropDownListSubCourse = (DropDownList)SubjectGridView.Rows[rowIndex].Cells[4].FindControl("SubjectCourse");

                    dataRowCurrent = dataTableCurrent.NewRow();
                    dataRowCurrent["RowNumber"] = i + 1;
                    dataTableCurrent.Rows[i - 1]["SubjectName"] = textBoxSubName.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectID"] = textBoxSubID.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectCreditHour"] = textBoxSubCHour.Text;
                    dataTableCurrent.Rows[i - 1]["SubjectCourse"] = dropDownListSubCourse.SelectedValue;

                    rowIndex++;
                }

                ViewState["SubjectGridView"] = dataTableCurrent;
            }
        }
        else
        {
            Response.Write("ViewState is null.");
        }
    }

    protected void SubjectGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowDataSubject();
        if (ViewState["SubjectGridView"] != null)
        {
            DataTable dataTableCurrent = (DataTable)ViewState["SubjectGridView"];
            DataRow dataRowCurrent = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dataTableCurrent.Rows.Count > 1)
            {
                dataTableCurrent.Rows.Remove(dataTableCurrent.Rows[rowIndex]);
                dataRowCurrent = dataTableCurrent.NewRow();
                ViewState["SubjectGridView"] = dataTableCurrent;
                SubjectGridView.DataSource = dataTableCurrent;
                SubjectGridView.DataBind();

                for (int i = 0; i < SubjectGridView.Rows.Count - 1; i++)
                {
                    SubjectGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousDataSubject();
            }
        }
    }

    private string SaveAllNewSubject(StringCollection stringCollection)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        StringBuilder stringBuilder = new StringBuilder(string.Empty);
        string[] splitItems = null;
        foreach (string item in stringCollection)
        {
            const string sqlQuery = "INSERT INTO SUBJECT (NAME, ID, CREDITHOUR, COURSE) VALUES";
            if (item.Contains("~"))
            {
                splitItems = item.Split("~".ToCharArray());
                stringBuilder.AppendFormat("{0}('{1}','{2}','{3}','{4}');", sqlQuery, splitItems[0], splitItems[1], splitItems[2], splitItems[3]);
            }
        }
        try
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            string message = e.Message.ToString();
            //throw new Exception(message);
            //Response.Write("<script>alert('123456789')</script>");
            return "-1";
        }
        finally
        {
            sqlConnection.Close();
        }
        return "0";
    }

    protected void ButtonSaveNewSubject_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int rowIndex = 0;
            StringCollection stringCollection = new StringCollection();
            String status;
            if (ViewState["SubjectGridView"] != null)
            {
                DataTable dataTableCurrent = (DataTable)ViewState["SubjectGridView"];
                if (dataTableCurrent.Rows.Count > 0)
                {
                    for (int i = 1; i <= dataTableCurrent.Rows.Count; i++)
                    {
                        TextBox textBoxSubName = (TextBox)SubjectGridView.Rows[rowIndex].Cells[1].FindControl("SubjectName");
                        TextBox textBoxSubID = (TextBox)SubjectGridView.Rows[rowIndex].Cells[2].FindControl("SubjectID");
                        TextBox textBoxSubCHour = (TextBox)SubjectGridView.Rows[rowIndex].Cells[3].FindControl("SubjectCreditHour");
                        DropDownList dropDownListLCourse = (DropDownList)SubjectGridView.Rows[rowIndex].Cells[4].FindControl("SubjectCourse");
                        stringCollection.Add(textBoxSubName.Text + "~" + textBoxSubID.Text + "~" + textBoxSubCHour.Text + "~" + dropDownListLCourse.SelectedValue.ToString());
                        rowIndex++;
                    }
                }
            }
            status = SaveAllNewSubject(stringCollection);
            if (status.Equals("-1"))
            {
                Response.Write("<script>alert('One or more entry already available in the database.')</script>");
            }
            else if (status.Equals("0"))
            {
                Response.Write("<script>alert('All entry for subject are successfully saved.')</script>");
                DisplaySubjectGridView();
            }
        }
    }
}