using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AdoDisConApp
{
    internal class Program
    {
        SqlConnection conn;

        public Program()
        {
            conn = new SqlConnection("Data Source=LAPTOP-GGUGVPR9\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbRecruitApr2023");
            //conn.Open();
            //Console.WriteLine("Server connected");
        }

        void AddNewUser()
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

        void AddUsingSP()
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
        void FetchAndDisplayData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tblusers", conn);
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
        void FetchAndDisplayDataUsingSP()
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

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.AddUsingSP();
            //program.FetchAndDisplayDataUsingSP();
            Console.WriteLine("Hello, World!");
        }
    }
}