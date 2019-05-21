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
    public partial class DashBoard : SessionHandler
    {
        #region Page_Load
        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        #endregion

        #region BindGrid
        /// <summary>
        /// BindGrid
        /// </summary>
        private void BindGrid()
        {
            try
            {
                DataTable dt = new DataDAL().GetDepartmentsUsers();
                gdDepartmentUsers.DataSource = dt;
                gdDepartmentUsers.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }
        }
        #endregion

        #region lnkRemove_Click
        /// <summary>
        /// lnkRemove_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int departmentID;
                LinkButton btn = (LinkButton)(sender);
                string id = btn.CommandArgument;
               
                int.TryParse(id, out departmentID);

                if (departmentID > 0)
                {
                    new DataDAL().DeleteDepartment(departmentID);
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }
        }
        #endregion       
    }
}