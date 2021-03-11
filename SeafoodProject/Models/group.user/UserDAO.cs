using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeafoodProject.Models.group.util;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace SeafoodProject.Models.group.user
{
    public class UserDAO
    {
        public UserDTO CheckLogin(string userName, string password)
        {
            SqlConnection connection = new SqlConnection(DBHelper.getConnectionString());
            string sql = "SELECT * FROM Users WHERE userName=@NAME AND password=@PASS";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@NAME", userName);
            cmd.Parameters.AddWithValue("@PASS", password);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        int userId = int.Parse(sqlDataReader["userId"].ToString());
                        int role = int.Parse(sqlDataReader["roleId"].ToString());
                        string fullName = sqlDataReader["fullName"].ToString();
                        string phoneNumber = sqlDataReader["phoneNumber"].ToString();
                        string address = sqlDataReader["address"].ToString();
                        int status = int.Parse(sqlDataReader["status"].ToString());

                        UserDTO userDTO = new UserDTO(userId, userName, password, role, fullName, phoneNumber, address, status);
                        return userDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return null;
        }
    }
}
