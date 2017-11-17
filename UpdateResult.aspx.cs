using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    //Connection String from web.config File  
    string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
    SqlConnection con;
    SqlDataAdapter adapt;
    DataTable dt;
    static String gridviewsubject="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string lecsubject = "";
            con = new SqlConnection(cs);
            con.Open();
            string qry = "SELECT * FROM LECTURER WHERE ID='" + Request.QueryString["ID"] + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                lecsubject = sdr["SUBJECT"].ToString();

            }
            con.Close();

            string[] subarr;
            char[] delimiterChars = { ',' };
            subarr = lecsubject.Split(delimiterChars);

            foreach (string i in subarr)
            {
                Subjectddl.Items.Add(new ListItem(i));
            }
            gridviewsubject = subarr[0];

            ShowData();
        }


        try
        {
            con.Open();
            string qry = "select * from Semester order by Startdate DESC";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                DateTime today = DateTime.Today;
                DateTime Cutoffdate = Convert.ToDateTime(sdr["ENDDATE"]);
                Cutoffdate = Cutoffdate.AddDays(14);
                if (today > Cutoffdate)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        GridViewRow row = GridView1.Rows[i];

                        ((TextBox)row.FindControl("txt_Result")).Enabled = false;
                        Updatebtn.Enabled = false;
                    }
                }

            }            

            con.Close();
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }




    }
    //ShowData method for Displaying Data in Gridview  
    protected void ShowData()
    {
        dt = new DataTable();
        con = new SqlConnection(cs);
        con.Open();
        adapt = new SqlDataAdapter
            ("SELECT RESULT.ID, STUDENT.Name, RESULT.SUBJECT, RESULT.RESULT FROM RESULT INNER JOIN STUDENT ON RESULT.ID = STUDENT.ID WHERE RESULT.SUBJECT LIKE( '"+ gridviewsubject + "%'); ", con);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        con.Close();
    }

    protected void Updatebtn_Click(object sender, EventArgs e)
    {
        StringBuilder query = new StringBuilder();

        string subjectname = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            GridViewRow row = GridView1.Rows[i];

            string Subject = ((Label)row.FindControl("lbl_Subject")).Text;

            subjectname = Subject;

            string Result = ((TextBox)row.FindControl("txt_Result")).Text;

            if (Result=="")
            {
                Response.Write("<script>alert('Invalid result entered.')</script>");
                ShowData();
                return;
            }

            if (Convert.ToInt32(Result) > 100|| Convert.ToInt32(Result) < 0)
            {
                Response.Write("<script>alert('Invalid result entered.')</script>");
                ShowData();
                return;
            }
            string ID = ((Label)row.Cells[1].FindControl("lbl_ID")).Text;

            query.Append("UPDATE [Result] SET [Result] = ")

            .Append(Result).Append(" WHERE [ID] = '")

            .Append(ID).Append("' AND [SUBJECT] = '")

            .Append(Subject).Append("'\n");
            
        }

        con = new SqlConnection(cs);
        con.Open();
        SqlCommand cmd = new SqlCommand(query.ToString(), con);
        cmd.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        Response.Write("<script>alert('" + subjectname + " updated.')</script>");
        ShowData();

    }

    protected void Selectbtn_Click(object sender, EventArgs e)
    {
        gridviewsubject = Subjectddl.SelectedValue.ToString();
        ShowData();
        try
        {
            con.Open();
            string qry = "select * from Semester order by Startdate DESC";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                DateTime today = DateTime.Today;
                DateTime Cutoffdate = Convert.ToDateTime(sdr["ENDDATE"]);
                Cutoffdate = Cutoffdate.AddDays(14);
                if (today > Cutoffdate)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        GridViewRow row = GridView1.Rows[i];

                        ((TextBox)row.FindControl("txt_Result")).Enabled = false;

                    }
                }

            }

            con.Close();
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }
}