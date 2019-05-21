using SampleProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Http;
using SampleUtility;

namespace AngularJSSample
{
    #region SampleData
    /// <summary>
    /// Summary description for SampleData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    #endregion
    public class SampleData : System.Web.Services.WebService
    {

        #region GetLoginDetails
        /// <summary>
        /// GetLoginDetails
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetLoginDetails(string userName, string password)
        {
            bool data = false;
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    DataTable dt = new DataDAL().UserLogin(userName, password);

                    if (dt.Rows.Count > 0)
                    {
                        Session["UserID"] = dt.Rows[0].Field<int>("UserID");
                        Session["UserName"] = userName;

                        data = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            string jsonData = js.Serialize(data);
            return jsonData;
        }
        #endregion

        #region GetDataForAngularGrid
        /// <summary>
        /// GetDataForAngularGrid
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetDataForAngularGrid()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DataDAL().GetDepartmentsUsers();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            return Utility.DataTableToJSONWithJSONNet(dt);
        }
        #endregion

        #region DeleteDepartment
        /// <summary>
        /// DeleteDepartment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteDepartment(string id)
        {
            int departmentID;
            bool data = false;
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                int.TryParse(id, out departmentID);

                if (departmentID > 0)
                {
                    new DataDAL().DeleteDepartment(departmentID);
                    data = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            string jsonData = js.Serialize(data);
            return jsonData;
        }
        #endregion

        #region GetDataForDepartment
        /// <summary>
        /// GetDataForDepartment
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetDataForDepartment()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DataDAL().GetDepartments();

                //DataRow dr = dt.NewRow();
                //dr["DepartmentName"] = "Select";
                //dr["DepartmentID"] = "0";
                //dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            return Utility.DataTableToJSONWithJSONNet(dt);
        }
        #endregion

        #region DepartmentUsersInsert
        /// <summary>
        /// DepartmentUsersInsert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [WebMethod]
        public string DepartmentUsersInsert(string name, string department)
        {
            bool data = false;
            int departmentID;
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                int.TryParse(department, out departmentID);

                if (!string.IsNullOrEmpty(name) && departmentID > 0)
                {
                    new DataDAL().InsertDepartmentUsers(departmentID, name);
                    data = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            string jsonData = js.Serialize(data);
            return jsonData;
        }
        #endregion

        #region DepartmentUsersUpdate
        /// <summary>
        /// DepartmentUsersUpdate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [WebMethod]
        public string DepartmentUsersUpdate(string id ,string name, string department)
        {
            bool data = false;
            int departmentID;
            int userID = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                int.TryParse(department, out departmentID);
                int.TryParse(id, out userID);

                if (!string.IsNullOrEmpty(name) && departmentID > 0)
                {
                    new DataDAL().UpdateDepartmentUsers(departmentID, name, userID);
                    data = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            string jsonData = js.Serialize(data);
            return jsonData;
        }
        #endregion

        #region UserRegisetration
        /// <summary>
        /// UserRegisetration
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string UserRegisetration(string userName, string password, string emailAddress)
        {
            bool data = false;
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(password))
                {
                    DataTable dt = new DataDAL().GetUserByUserName(userName);

                    if (dt.Rows.Count == 0)
                    {
                        new DataDAL().InsertRegisteredUser(userName, password, emailAddress);

                        data = true;
                    }                  
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SaveException(ex);
            }

            string jsonData = js.Serialize(data);
            return jsonData;
        }
        #endregion
    }
}
