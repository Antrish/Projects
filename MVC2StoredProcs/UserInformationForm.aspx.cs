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
    public partial class UserInformationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-VKUTJ8EH; database=Practice; integrated security=SSPI");
                using (SqlCommand cmd = new SqlCommand("sp_AddUserData", con))
                {
                    Random random = new Random();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = random.Next(123456,999999);
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NChar).Value = txtMobile.Text;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Convert.ToInt32(txtAge.Text);
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text;
                    cmd.ExecuteNonQuery();
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