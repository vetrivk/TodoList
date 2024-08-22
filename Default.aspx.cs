using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TodoList
{
    public partial class Default : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["toDo"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           string email = txtLogin.Text;
            using(MySqlConnection con = new MySqlConnection(conStr))
            {

            con.Open();
                string qry = "select * from login where email = @email";
                MySqlCommand cmd = new MySqlCommand(qry,con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = cmd.ExecuteReader();
            
                
                if (reader.Read())
                {
                    if(email == reader.GetString(2))
                    {
                        
                        Response.Redirect("DashBoard.aspx?email=" + Server.UrlEncode(email));
                    }
                    con.Close();
                }
                

            }
        }

        
    }
}