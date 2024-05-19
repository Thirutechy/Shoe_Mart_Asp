using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Josh_Shoe_Mart
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           btn_register.Click += btn_register_Click;
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {


            try
            {

                if (string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrEmpty(txt_MobileNumber.Text) || string.IsNullOrEmpty(txt_Email.Text) || string.IsNullOrEmpty(txt_Address.Text) || string.IsNullOrEmpty(txt_Password.Text))
                {
                    // Display error message
                    Response.Write("<script>alert('Please fill in all required fields.')</script>");
                }
                else
                {
                    // Process form submission
                    // Your code here

                    string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(fetchDBData);

                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_registerUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter("@UserName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_UserName.Text;

                    SqlParameter param2 = new SqlParameter("@MobileNumber", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_MobileNumber.Text;

                    SqlParameter param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_Email.Text;

                    SqlParameter param4 = new SqlParameter("@Address", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = txt_Address.Text;

                    SqlParameter param5 = new SqlParameter("@Pswd ", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = txt_Password.Text;

                    int i = cmd.ExecuteNonQuery();

                    con.Close();

                    if (i > 0)
                    {
                        Response.Write("register successfully");
                        txt_UserName.Text = "";
                        txt_MobileNumber.Text = "";
                        txt_Email.Text = "";
                        txt_Password.Text = "";
                        txt_Address.Text = "";

                        Response.Redirect("login.aspx");

                    }
                    else
                    {
                        Response.Write("register failed");
                    }
                }

            }
            catch
            {
                Response.Write("please contact support team");
            }


        }
    }
}