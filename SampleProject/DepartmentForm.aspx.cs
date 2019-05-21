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
    public partial class DepartmentForm : SessionHandler
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
                BindDepartment();

                if (Request["ID"] != null)
                {
                    string id = Request["ID"].ToString();
                    hdnDepartmentUserID.Value = id;

                    GetUserDetails(id);

                    btnSubmit.Text = "Update";
                }
            }
        }
        #endregion

        #region BindDepartment
        /// <summary>
        /// BindDepartment
        /// </summary>
        private void BindDepartment()
        {
            try
            {
                DataTable dt = new DataDAL().GetDepartments();
                ddlDepartment.DataSource = dt;

                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataBind();

                ddlDepartment.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }
        }
        #endregion

        #region btnSubmit_Click
        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int departmentID;
                int userID = 0;
                bool isupdate = false;

                string department = ddlDepartment.Text;
                string name = txtName.Text;

                int.TryParse(department, out departmentID);

                string ID = hdnDepartmentUserID.Value;

                if (!string.IsNullOrEmpty(ID))
                {
                    int.TryParse(ID, out userID);
                    isupdate = true;
                }

                if (departmentID > 0 && !string.IsNullOrEmpty(name))
                {
                    if (isupdate)
                        new DataDAL().UpdateDepartmentUsers(departmentID, name, userID);

                    else
                        new DataDAL().InsertDepartmentUsers(departmentID, name);

                    Response.Redirect("DashBoard.aspx", true);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }
        }
        #endregion

        #region GetUserDetails
        /// <summary>
        /// GetUserDetails
        /// </summary>
        /// <param name="id"></param>
        private void GetUserDetails(string id)
        {
            try
            {
                DataTable dt = new DataDAL().GetUserDetails(Convert.ToInt32(id));

                if (dt.Rows.Count > 0)
                {
                    string departmentID = dt.Rows[0].Field<int>("DepartmentID").ToString();
                    txtName.Text = dt.Rows[0].Field<string>("Name").ToString();

                    ddlDepartment.SelectedValue = departmentID;
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