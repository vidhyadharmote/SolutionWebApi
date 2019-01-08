using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEntityFramework.Models
{
    public class Db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public void AddUser(user usr)
        {
            SqlCommand com = new SqlCommand("Login_User", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@uname", usr.Name);
            com.Parameters.AddWithValue("@Pass", usr.passwd);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public List<user> Login_User(user usr)
        {
            List<user> lstUsers = new List<user>();
            user info= new user();
            SqlCommand com = new SqlCommand("Login_User", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@uname", usr.Name);
            com.Parameters.AddWithValue("@pass", usr.passwd);
            con.Open();

            //DataSet dataSet = ExecuteSPSelect(procName, list);

            //if (dataSet.Tables[0].Rows.Count > 0)
            //{

            //    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            //    {

            //        // inputdate = dataSet.Tables[0].Rows[i].Field<DateTime>("Date");
            //        info = new user()
            //        {
            //            Id = dataSet.Tables[0].Rows[i].Field<int>("Id"),
            //            UserId = dataSet.Tables[0].Rows[i].Field<string>("UserId"),
            //            Name = dataSet.Tables[0].Rows[i].Field<string>("Name"),
            //            passwd = dataSet.Tables[0].Rows[i].Field<string>("Passwd"),
            //            IsActive = dataSet.Tables[0].Rows[i].Field<bool>("IsActive"),                       
            //            CreatedDate = dataSet.Tables[0].Rows[i].Field<DateTime>("CreatedDate"),                        
            //            UpdatedDate = dataSet.Tables[0].Rows[i].Field<DateTime>("UpdatedDate"),
            //            UserType = dataSet.Tables[0].Rows[i].Field<int>("UserType")


            //        };
            //        lstUsers.Add(info);
            //    }
            //    return lstUsers;
            //}


            using (SqlDataReader sdr = com.ExecuteReader())
            {
                while (sdr.Read())
                {
                    lstUsers.Add(new user
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        UserId = Convert.ToString(sdr["UserId"]),
                        Name = Convert.ToString(sdr["Name"]),
                        passwd = Convert.ToString(sdr["Passwd"]),
                        IsActive = Convert.ToBoolean(sdr["IsActive"]),
                        CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]),
                        UpdatedDate = Convert.ToDateTime(sdr["UpdatedDate"]),
                        UserType = Convert.ToInt32(sdr["UserType"])
                    });
                    //var eid = Convert.ToInt32(sdr["EnrolleeID"]);
                    //var MealID = Convert.ToInt32(sdr["MealID"]);
                }
            }
            con.Close();
            return lstUsers;
        }
    }
}