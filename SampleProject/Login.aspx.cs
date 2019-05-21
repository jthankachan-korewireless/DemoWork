#region NameSpaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion NameSpaces

namespace SampleProject
{
    public partial class Login : System.Web.UI.Page
    {
        #region Page_Load
        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }
        #endregion

        #region btnLogin_Click
        /// <summary>
        /// btnLogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    DataTable dt = new DataDAL().UserLogin(userName, password);

                    if(dt.Rows.Count > 0)
                    {
                        Session["UserID"] = dt.Rows[0].Field<int>("UserID");
                        Session["UserName"] = userName;

                        
                        Response.Redirect("DashBoard.aspx",false);
                    }
                    else
                    {
                        lblMessage.Visible = true;
                    }

                }
            }
            catch(Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }
        }
        #endregion
    }
}