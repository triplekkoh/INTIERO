using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration; // this namespace is add I am adding connection name in web config file config connection name  
using System.Data;
using System.Net.Mail; //email
using System.Net;
using System.Web.Services;

public partial class _Default : Page
{
    protected string toEmail, EmailSubj, EmailMsg;

    /*1 Admin
    2 Lecturer
    3 Parent
    4 Student*/

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["id"] as string))
        {
            Response.Redirect("Menu.aspx");            
        }
    }

    protected void Loginbtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        try
        {
            bool authenticity;
            string memberstat="";
            string uid = Usertb.Text;
            string pass = Passwordtb.Text;
            con.Open();
            string qry = "select * from Logintb where UserId='" + uid + "' and Password='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                authenticity = true;
                memberstat = sdr["MemberStat"].ToString();
                //Response.Write("<script>alert('"+ "Login Sucess! Member Status is: " + sdr["MemberStat"].ToString() + "')</script>");
            }
            else
            {
                authenticity = false;
                Response.Write("<script>alert('Wront Username or Password. Try again.')</script>");
            }
            con.Close();
            if (RememberMe.Checked == true)
            {
                Session["id"] = Usertb.Text;                            
            }
            else
            {
                Session.RemoveAll();                
            }
            if (authenticity)
            {
                switch (memberstat)
                {
                    case "1": //Admin
                        Response.Redirect("AdminPage.aspx?ID="+ uid);
                        break;
                    case "2": //Lecturer
                        Response.Redirect("UpdateResult.aspx?ID=" + uid);
                        break;
                    case "3": //Parent
                        Response.Redirect("ViewResult.aspx?ID=" + uid);
                        break;
                    case "4": //Student
                        Response.Redirect("Menu.aspx?ID=" + uid);
                        break;
                    default:
                        break;
                }                
            }            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Forgetbtn_Click(object sender, EventArgs e)
    {
        string useremail = "", userpwd = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        try
        {
            string uid = Usertb.Text;
            con.Open();
            string qry = "select * from Logintb where UserId='" + uid + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                useremail= sdr["Email"].ToString();
                userpwd = sdr["Password"].ToString();
            }

            con.Close();   

            toEmail = useremail; //receiver fo the amil
            EmailSubj = "Password Retrieval";
            EmailMsg = "Your password is " + userpwd; //content of email
            //passing parameter to Email Method
            SendEmail.Email_Without_Attachment(toEmail, EmailSubj, EmailMsg);
            Response.Write("<script>alert('Password recovery email sent.')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Invalid User. Try agin.')</script>");
            //Response.Write(ex.Message);
        }
    }
}