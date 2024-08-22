using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace TodoList
{
    public partial class DashBoard : System.Web.UI.Page
    {
        string connectionStr = WebConfigurationManager.ConnectionStrings["toDo"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                viewDataMySql();                
                lblWelcome.Text = UserDetails();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionStr))
            {
                con.Open();
                
                string viewQry = "select * from login  where email = @email";
                MySqlCommand cmdView = new MySqlCommand(viewQry, con);
                cmdView.CommandType = CommandType.Text;
                cmdView.Parameters.AddWithValue("@email", UserDetails());
                MySqlDataReader reader = cmdView.ExecuteReader();
                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    con.Close();
                    string insertQry = "insert into userData (item, dataItem, userId) values (@item, @dataItem, @userId)";
                    MySqlCommand cmd = new MySqlCommand(insertQry, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Item", txtInput.Text);
                    cmd.Parameters.AddWithValue("@dataItem", txtDate.Text);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    viewDataMySql();
                }

                con.Close();


            }


        }

        private void viewDataMySql()
        {
            using (MySqlConnection con = new MySqlConnection(connectionStr))
            {
                con.Open();
                string viewQry = "select email,itemID, item, dataItem from login inner join userData on userData.userId = login.userId where email = @email";
                MySqlCommand cmd = new MySqlCommand(viewQry, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email",UserDetails());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                

                string viewCount = "SELECT count(*) from login inner join userData on userData.userId = login.userId where email = @email";
                MySqlCommand cmdCount = new MySqlCommand(viewCount, con);
                cmdCount.CommandType = CommandType.Text;
                cmdCount.Parameters.AddWithValue("@email", UserDetails());
                int i = Convert.ToInt32(cmdCount.ExecuteScalar());
                lblPending.Text = i.ToString();

                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                txtInput.Text = "";
                txtDate.Text = "";
                con.Close();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "DeleteItem")
            {
                int deleteId = int.Parse(e.CommandArgument.ToString());
                deleteItem(deleteId);
                viewDataMySql();
            }
        }
        private void deleteItem(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionStr))
            {
                con.Open();
                string deleteQry = "delete from userData where itemId = @itemId";
                MySqlCommand cmd = new MySqlCommand(deleteQry,con);
                cmd.CommandType = CommandType.Text; 
                cmd.Parameters.AddWithValue("@itemId", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public string UserDetails()
        {
            string emailId = Request.QueryString["email"];
            return emailId;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login or default page
            Response.Redirect("Default.aspx");
        }
    }
}
