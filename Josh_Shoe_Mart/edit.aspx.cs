using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Josh_Shoe_Mart
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
    
        }
        private void BindProducts()
        {

            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);

            con.Open();

            SqlCommand cmd2 = new SqlCommand("sp_fetchProducts", con);
            cmd2.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            con.Close();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = GridView1.SelectedIndex;
            string productId = GridView1.Rows[selectedIndex].Cells[0].Text;
            // You can now use the selected productId to perform further actions

            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);

            con.Open();

            SqlCommand cmd = new SqlCommand("sp_GetProductById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@ProductID", SqlDbType.Int);
            cmd.Parameters.Add(param1).Value = productId;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_eProductName.Text = reader["ProductName"].ToString();
                txt_eDescription.Text = reader["Description"].ToString();
                list_eBrand.SelectedValue = reader["Brand"].ToString();
                list_eCatagory.SelectedValue = reader["Category"].ToString();
                txt_ePrice.Text = reader["Price"].ToString();
            }
            con.Close();
        }

        protected void btn_Editsubmit_Click(object sender, EventArgs e)
        {
            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_UpdateProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            int selectedIndex = GridView1.SelectedIndex;
            string productId = GridView1.Rows[selectedIndex].Cells[0].Text;


            SqlParameter param0 = new SqlParameter("@ProductID", SqlDbType.Int);
            cmd.Parameters.Add(param0).Value = productId;

            SqlParameter param1 = new SqlParameter("@ProductName", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_eProductName.Text;

            SqlParameter param2 = new SqlParameter("@Description", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = txt_eDescription.Text;

            SqlParameter param3 = new SqlParameter("@Brand", SqlDbType.VarChar);
            cmd.Parameters.Add(param3).Value = list_eBrand.SelectedValue;

            SqlParameter param4 = new SqlParameter("@Category", SqlDbType.VarChar);
            cmd.Parameters.Add(param4).Value = list_eCatagory.SelectedValue;

            SqlParameter param5 = new SqlParameter("@Price", SqlDbType.Float);
            cmd.Parameters.Add(param5).Value = txt_ePrice.Text;

            cmd.ExecuteNonQuery();

            BindProducts();

        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            int selectedIndex = GridView1.SelectedIndex;
            string productId = GridView1.Rows[selectedIndex].Cells[0].Text;


            SqlParameter param0 = new SqlParameter("@ProductID", SqlDbType.Int);
            cmd.Parameters.Add(param0).Value = productId;

            cmd.ExecuteNonQuery();

            txt_eProductName.Text = "";
            txt_eDescription.Text = "";
            list_eBrand.SelectedValue = "";
            list_eCatagory.SelectedValue = "";
            txt_ePrice.Text = "";

            BindProducts();
        }

        protected void btn_Products_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
    
}