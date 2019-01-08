using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Crud_Mvc.Models;

namespace Crud_Mvc.DataAccessLayer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public void AddStudent(Student stud)
        {
            SqlCommand com = new SqlCommand("Add_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name",stud.StudentName);
            com.Parameters.AddWithValue("@Address", stud.Address);
            com.Parameters.AddWithValue("@City",stud.City);
            com.Parameters.AddWithValue("@EmailId",stud.EmailId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_Record(Student stud)
        {
            SqlCommand com = new SqlCommand("Update_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", stud.Id);
           // com.Parameters.AddWithValue("@StudentId", stud.StudentId);
            com.Parameters.AddWithValue("@Name", stud.StudentName);            
            com.Parameters.AddWithValue("@Address", stud.Address);
            com.Parameters.AddWithValue("@City", stud.City);
            com.Parameters.AddWithValue("@EmailId", stud.EmailId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ShowRecorById(int id)
        {
            SqlCommand com = new SqlCommand("Get_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void DeleteRecord(int id)
        {
            SqlCommand com = new SqlCommand("Delete_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public bool DeleteStudent(int id)
        {
            SqlCommand com = new SqlCommand("Delete_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public DataSet ShowAllStudentRecords()
        {
            SqlCommand com = new SqlCommand("Get_All_Student", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}