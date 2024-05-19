using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Josh_Shoe_Mart
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);

            con .Open();    

            SqlCommand cmd= new SqlCommand("sp_userLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param1 = new SqlParameter("@Username", SqlDbType.VarChar);
            cmd.Parameters.Add(Param1).Value=txt_loginUserName.Text.Trim();

            SqlParameter Param2 = new SqlParameter("@Password",SqlDbType.VarChar);
            cmd.Parameters.Add(Param2).Value=txt_loginPassword.Text.Trim();


            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string role = result.ToString();

                if(role == "Admin")
                {
                    Response.Redirect("admin.aspx");
                }
                else if(role == "User")
                {
                    Response.Redirect("shop.aspx");
                }

                else
                {
                    loginfailed.Text = "Invalid username or password";
                }

            }


        }
    }
}