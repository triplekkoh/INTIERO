using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Semester : System.Web.UI.Page
{
    static string mycon = System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string date = Request.Form["daterange"];
        string[] datearr;
        char[] delimiterChars = { '-' };
        datearr = date.Split(delimiterChars);

        SqlConnection con = new SqlConnection(mycon);
        try
        {
            con.Open();
            string qry = "select * from Semester where Session='" + Sessionval.Value + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Write("<script>alert('Duplicate Session Name')</script>");
                return;
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        using (SqlConnection sqlConn = new SqlConnection(mycon))
        {
            sqlConn.Open();
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Semester values ('" + Sessionval.Value + "','"+ datearr[0] + "','" + datearr[1] + "')"
                , sqlConn))
            {
                cmd.ExecuteNonQuery();
            }
            sqlConn.Close();
        }
        
        //Response.Write("<script>alert('" + datearr[0] + "')</script>");
    }
}