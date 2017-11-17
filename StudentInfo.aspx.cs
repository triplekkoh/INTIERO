using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentInfo : System.Web.UI.Page
{
    static string mycon = System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(mycon);
            try
            {
                con.Open();
                string qry = "SELECT * FROM STUDENT WHERE ID='" + Request.QueryString["ID"] + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    IDlbl.Text = sdr["ID"].ToString();
                    Namelbl.Text = sdr["NAME"].ToString();
                    Courselbl.Text = sdr["COURSE"].ToString();
                    Phonetb.Text = sdr["PHONENUMBER"].ToString();
                    Addresstb.Text = sdr["ADDRESS"].ToString();
                    Subjectlbl.Text = sdr["SUBJECT"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlConn = new SqlConnection(mycon))
        {
            sqlConn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET PHONENUMBER='" + Phonetb.Text + "',ADDRESS='" + Addresstb.Text + "' WHERE ID='"+ Request.QueryString["ID"] + "'", sqlConn))
            {
                cmd.ExecuteNonQuery();
            }
                
            sqlConn.Close();
        }
    }
}