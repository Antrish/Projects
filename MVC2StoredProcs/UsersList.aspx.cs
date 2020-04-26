using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC2StoredProcs
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-VKUTJ8EH; database=Practice; integrated security=SSPI");
                using (SqlCommand cmd = new SqlCommand("sp_GetUserData",con))
                {
                    cmd.Connection = con;
                   
                   cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    grdUserList.DataSource = dt;
                    grdUserList.DataBind();
                    con.Close();

                }
            }
            catch (SqlException sqe)
            {
                throw sqe;
            }
        }
    }
}