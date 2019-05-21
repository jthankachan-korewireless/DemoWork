#region NameSpaces
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
#endregion NameSpaces

namespace SampleProject
{
    public class DataDAL
    {
        string conncectionStrig;
        public DataDAL()
        {
            conncectionStrig = ConfigurationManager.ConnectionStrings["SampleDBCS"].ConnectionString;
        }

        #region GetDepartments
        /// <summary>
        /// GetDepartments
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartmentsUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("GetAllDepartmentUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                dt.Load(command.ExecuteReader());
                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return dt;
        }
        #endregion

        #region  UserLogin
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable UserLogin(string userName, string password)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("GetUserByCredentials", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("Username", userName);
                SqlParameter params2 = new SqlParameter("Password", password);
                command.Parameters.Add(params1);
                command.Parameters.Add(params2);

                connection.Open();
                dt.Load(command.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return dt;
        }
        #endregion

        #region DeleteDepartment
        /// <summary>
        /// DeleteDepartment
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteDepartment(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("DepartmentUsersDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("ID", id);
                command.Parameters.Add(params1);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region GetDepartments
        /// <summary>
        /// GetDepartments
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartments()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("DepartmentSelect", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                dt.Load(command.ExecuteReader());
                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return dt;
        }
        #endregion

        #region InsertDepartmentUsers
        /// <summary>
        /// InsertDepartmentUsers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void InsertDepartmentUsers(int id, string name)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("DepartmentUsersInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("DepartmntID", id);
                SqlParameter params2 = new SqlParameter("Name", name);
                command.Parameters.Add(params1);
                command.Parameters.Add(params2);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region GetUserDetails
        /// <summary>
        /// GetUserDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetUserDetails(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("DepartmentUserDetailsByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("ID", id);
                command.Parameters.Add(params1);
                connection.Open();

                dt.Load(command.ExecuteReader());
                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return dt;
        }
        #endregion

        #region UpdateDepartmentUsers
        /// <summary>
        /// UpdateDepartmentUsers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="userID"></param>
        public void UpdateDepartmentUsers(int id, string name, int userID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("DepartmentUsersUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("DepartmntID", id);
                SqlParameter params2 = new SqlParameter("Name", name);
                SqlParameter params3 = new SqlParameter("UserID", userID);
                command.Parameters.Add(params1);
                command.Parameters.Add(params2);
                command.Parameters.Add(params3);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region InsertRegisteredUser
        /// <summary>
        /// InsertRegisteredUser
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="emailAddress"></param>
        public void InsertRegisteredUser(string userName, string password, string emailAddress)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("UsersInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("UserName", userName);
                SqlParameter params2 = new SqlParameter("EmailAddress", emailAddress);
                SqlParameter params3 = new SqlParameter("Password", password);
                command.Parameters.Add(params1);
                command.Parameters.Add(params2);
                command.Parameters.Add(params3);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region GetUserByUserName
        /// <summary>
        /// GetUserByUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetUserByUserName(string userName)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection connection = new SqlConnection(conncectionStrig);

                var command = new SqlCommand("GetUserByUserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter params1 = new SqlParameter("Username", userName);
                command.Parameters.Add(params1);

                connection.Open();
                dt.Load(command.ExecuteReader());

                connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return dt;
        }
        #endregion
    }
}