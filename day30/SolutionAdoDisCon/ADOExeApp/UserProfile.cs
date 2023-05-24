using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOExerciseApp
{
    public class UserProfile
    {
        SqlConnection conn;

        public UserProfile()
        {
            conn = new SqlConnection("Data Source=LAPTOP-GGUGVPR9\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbRecruitApr2023");
            //conn.Open();
            //Console.WriteLine("Server connected");
        }

        public void AddNewUser()
        {
            string username = "", password = "", role = "";
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            Console.WriteLine("Please enter the role");
            role = Console.ReadLine();
            string insertQuery = "insert into tblUsers values(@un,@pass,@ur)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            //cmd.Parameters.Add("@un", SqlDbType.VarChar, 20);
            //cmd.Parameters[0].Value = username;
            cmd.Parameters.AddWithValue("@un", username);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@ur", role);
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User inserted");
                }
                else
                    Console.WriteLine("User registration failed");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Sql is not working as expected");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddUsingSP()
        {
            string username = "", password = "", role = "";
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            Console.WriteLine("Please enter the role");
            role = Console.ReadLine();
            string insertQuery = "proc_create_profile";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            //cmd.Parameters.Add("@un", SqlDbType.VarChar, 20);
            //cmd.Parameters[0].Value = username;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            cmd.Parameters.AddWithValue("@role", role);
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User inserted");
                }
                else
                    Console.WriteLine("User registration failed");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Sql is not working as expected");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        //public void FetchAndDisplayData()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter("select * from tblusers", conn);
        //    DataSet ds = new DataSet();
        //    adapter.Fill(ds, "users");
        //    foreach (DataRow dataRow in ds.Tables[0].Rows)
        //    {
        //        Console.WriteLine("User name : " + dataRow[0]);
        //        Console.WriteLine("Password  : " + dataRow["password"]);
        //        Console.WriteLine("Role      : " + dataRow[2]);
        //        Console.WriteLine("------------------------------------------");
        //    }
        //}
        public void FetchAndDisplayDataUsingSP()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_FetchUsers", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                Console.WriteLine("User name : " + dataRow[0]);
                Console.WriteLine("Password  : " + dataRow["password"]);
                Console.WriteLine("Role      : " + dataRow[2]);
                Console.WriteLine("------------------------------------------");
            }
        }

        public void UpdateDataUsingSP()
        {
            string username = "", role = "";
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the role");
            role = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("proc_UpdateRole", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", username);
            cmd.Parameters.AddWithValue("@role", role);
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User data updated successfully");
                }
                else
                    Console.WriteLine("data updation failed");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Sql is not working as expected");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteDataUsingSP()
        {
            string username = "";
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("proc_DeleteUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", username);
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User data deleted successfully");
                }
                else
                    Console.WriteLine("data deletion failed");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Sql is not working as expected");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        public virtual void FetchProfiles()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_FetchProfiles", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "profiles");
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                Console.WriteLine($"Id : {dataRow[0]}");
                Console.WriteLine("Name : " + dataRow[1]);
                Console.WriteLine($"Age  :  {dataRow[2]}");
                Console.WriteLine($"Qualification  :  {dataRow[3]}");
                Console.WriteLine($"IsEmployeed  : {dataRow[4]}");
                Console.WriteLine($"Notice Period  :  {dataRow[5]}");
                Console.WriteLine($"CurrentCTC  :  {dataRow[6]}");
                Console.WriteLine($"User name   :  {dataRow[7]}");
                //Console.WriteLine(" : " + dataRow[8]);
                Console.WriteLine("------------------------------------------");
            }
        }

        public void UpdatePasswordUsingSP()
        {
            string username = "", password = "";
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("proc_UpdatePassword", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            cmd.Parameters.Add("@role", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;

            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {

                    var role = cmd.Parameters["@role"].Value.ToString();
                    Console.WriteLine("User data updated successfully");
                    Console.WriteLine($"Employee {username}'s password has been updated. and his role is {role}");
                }
                else
                    Console.WriteLine("data updation failed");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Sql is not working as expected");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {

                conn.Close();
            }

        }
    }

}

