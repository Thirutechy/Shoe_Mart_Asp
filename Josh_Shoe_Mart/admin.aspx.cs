using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Josh_Shoe_Mart
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridshow();
                calculatequantity();
            }
           



        }

        protected void btn_AddProduct_Click(object sender, EventArgs e)
        {

            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);


            if (string.IsNullOrEmpty(txt_ProductName.Text) || string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(txt_Price.Text) || string.IsNullOrEmpty(list_Brand.SelectedValue) || string.IsNullOrEmpty(list_Catagory.SelectedValue))
            {
                // Display error message
                Response.Write("<script>alert('Please fill in all required fields.')</script>");
            }
            else
            {
                // Process form submission
                // Your code here
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_ShoeAddProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@ProductName", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = txt_ProductName.Text;

                SqlParameter param2 = new SqlParameter("@Description", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = txt_Description.Text;

                SqlParameter param3 = new SqlParameter("@Brand", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = list_Brand.SelectedValue;

                SqlParameter param4 = new SqlParameter("@Category", SqlDbType.VarChar);
                cmd.Parameters.Add(param4).Value = list_Catagory.SelectedValue;

                SqlParameter param5 = new SqlParameter("@Price", SqlDbType.Float);
                cmd.Parameters.Add(param5).Value = txt_Price.Text;

                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i > 0)
                {
                    Productadded.Text = "Product Added Done";


                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("sp_fetchProductID", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    SqlParameter param11 = new SqlParameter("@ProductName", SqlDbType.VarChar);
                    cmd1.Parameters.Add(param11).Value = txt_ProductName.Text;

                    SqlParameter param21 = new SqlParameter("@Description", SqlDbType.VarChar);
                    cmd1.Parameters.Add(param21).Value = txt_Description.Text;

                    SqlParameter param31 = new SqlParameter("@Brand", SqlDbType.VarChar);
                    cmd1.Parameters.Add(param31).Value = list_Brand.SelectedValue;

                    SqlParameter param41 = new SqlParameter("@Category", SqlDbType.VarChar);
                    cmd1.Parameters.Add(param41).Value = list_Catagory.SelectedValue;

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    txt_ProductID.Text = ds.Tables[0].Rows[0][0].ToString();

                    con.Close();

                }
                else
                {
                    Response.Write("added failed");
                }
            }

        }

        protected void btn_sqadded_Click(object sender, EventArgs e)
        {
            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);


            if (string.IsNullOrEmpty(txt_ProductID.Text) || string.IsNullOrEmpty(txt_quantity.Text) || string.IsNullOrEmpty(list_size.SelectedValue) )
            {
                // Display error message
                Response.Write("<script>alert('Please fill in all required fields.')</script>");
            }
            else
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_sizeandquantity", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add(param1).Value = txt_ProductID.Text;

                SqlParameter param2 = new SqlParameter("@Size", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = list_size.SelectedValue;

                SqlParameter param3 = new SqlParameter("@Quantity", SqlDbType.Int);
                cmd.Parameters.Add(param3).Value = txt_quantity.Text;

                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i > 0)
                {
                    lblsqadded.Text = "Added";

                    joinadd();
                    gridshow();
                    calculatequantity();

                }
                else
                {
                    Response.Write("added failed");
                }
            }
        }
        private void calculatequantity()
        {
            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);
            con.Open();

            SqlCommand cmd2 = new SqlCommand("sp_calculatequantity", con);
            cmd2.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);

            grid_final.DataSource = ds;
            grid_final.DataBind();

            con.Close();
        }

        private void gridshow()
        {

            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);

            con.Open();

            SqlCommand cmd2 = new SqlCommand("sp_showjointb", con);
            cmd2.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);

            grid_PSQ.DataSource = ds;
            grid_PSQ.DataBind();

            con.Close();

        }
        private void joinadd()
        {

            string fetchDBData = ConfigurationManager.ConnectionStrings["ThiruConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(fetchDBData);

            con.Open();

            SqlCommand cmd2 = new SqlCommand("sp_joinproductwithsizequantity_and_store", con);
            cmd2.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cmd2.ExecuteNonQuery();
            con.Close();

        }

        protected void btn_done_Click(object sender, EventArgs e)
        {
            txt_ProductName.Text = "";
            txt_Description.Text = "";
            list_Brand.SelectedValue = "";
            list_Catagory.SelectedValue = "";
            txt_Price.Text = "";
            txt_quantity.Text = "";
            list_size.SelectedValue = "";
            txt_ProductID.Text = "";
        }

        protected void btn_edit_Click1(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }
    }
}
            


        
    
    
