using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewResult : System.Web.UI.Page
{
    static string mycon = System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlConnection consql = new SqlConnection(mycon);
        consql.Open();
        string qrysql = "SELECT * FROM LOGINTB WHERE USERID='" + Request.QueryString["ID"] + "'";
        SqlCommand cmdsql = new SqlCommand(qrysql, consql);
        SqlDataReader sdrsql = cmdsql.ExecuteReader();
        if (sdrsql.Read())
        {
            if (Convert.ToInt32(sdrsql["MEMBERSTAT"])==3)
            {
                qrysql = "SELECT * FROM STUDENT WHERE PARENTID='" + Request.QueryString["ID"] + "'";
                cmdsql = new SqlCommand(qrysql, consql);
                sdrsql.Close();
                sdrsql = cmdsql.ExecuteReader();
                if (sdrsql.Read())
                {
                    Response.Redirect("ViewResult.aspx?ID=" + sdrsql["ID"].ToString());
                }
            }
          

        }
        consql.Close();














        int rowcounter = 0;
        StringBuilder html = new StringBuilder();
        html.Append("<div>");
        html.Append("<p>Student ID: "+ Request.QueryString["ID"] + "</p>");

        SqlConnection con = new SqlConnection(mycon);


        con.Open();
        string qry = "select * from Student where ID='"+ Request.QueryString["ID"] + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            html.Append("<p>Name: " + sdr["Name"].ToString() + "</p>");
            html.Append("<p>Course: " + sdr["Course"].ToString() + "</p>");
        }
        con.Close();
        
        html.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;float:left\" >");
        html.Append("<tr>");
        html.Append("<th style='text-align: center'>#</th>");
        html.Append("<th style='text-align: center'>Subject</th>");
        html.Append("<th style='text-align: center'>Marks</th>");
        html.Append("</tr>");

        SqlConnection con1 = new SqlConnection(mycon);
        try
        {
            con1.Open();
            string qry1 = "SELECT * FROM Result WHERE ID='"+ Request.QueryString["ID"] + "'";
            SqlCommand cmd1 = new SqlCommand(qry1, con1);
            SqlDataReader sdr1 = cmd1.ExecuteReader();

            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    rowcounter++;
                    html.Append("<tr>");
                    html.Append("<td align='center'>" + rowcounter + "</td>");
                    html.Append("<td align='left'>" + sdr1["Subject"].ToString() + "</td>");
                    html.Append("<td align='center'>" + sdr1["Result"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
            else
            {
                //Response.Write("<script>alert('No result found')</script>");
                Response.Redirect("Menu.aspx?ID=" + Request.QueryString["ID"]);
                //return;
            }
            rowcounter = 0;
            con1.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        html.Append("</table>");
        html.Append("</div>");
        PH1.Controls.Add(new Literal { Text = html.ToString() });
    }

    protected void View_Click(object sender, EventArgs e) //For testing only
    {
        int rowcounter = 0;
        StringBuilder html = new StringBuilder();
        html.Append("<div>");
        html.Append("<p>Student ID: P14004056</p>");

        SqlConnection con = new SqlConnection(mycon);


        con.Open();
        string qry = "select * from Student where ID='P14004056'";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            html.Append("<p>Name: " + sdr["Name"].ToString() + "</p>");
            html.Append("<p>Course: " + sdr["Course"].ToString() + "</p>");
        }
        con.Close();
        
        html.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;float:left\" >");
        html.Append("<tr>");        
        html.Append("<th style='text-align: center'>#</th>");
        html.Append("<th style='text-align: center'>Subject</th>");
        html.Append("<th style='text-align: center'>Marks</th>");
        html.Append("</tr>");

        SqlConnection con1 = new SqlConnection(mycon);
        try
        {
            con1.Open();
            string qry1 = "SELECT * FROM Result WHERE ID='P14004056'";
            SqlCommand cmd1 = new SqlCommand(qry1, con1);
            SqlDataReader sdr1 = cmd1.ExecuteReader();

            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    rowcounter++;
                    html.Append("<tr>");
                    html.Append("<td align='center'>" + rowcounter + "</td>");
                    html.Append("<td align='left'>" + sdr1["Subject"].ToString() + "</td>");
                    html.Append("<td align='center'>" + sdr1["Result"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
            else
            {
                Response.Write("<script>alert('No result found')</script>");
                return;
            }
            rowcounter = 0;
            con1.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        
        html.Append("</table>");
        html.Append("</div>"); 
        PH1.Controls.Add(new Literal { Text = html.ToString() });
    }

}