using CowBullModelLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Numerics;

namespace CowBullDALLibrary
{
    public class UserRepoADO: IRepo<User, int>
    {
        static IDictionary<int , User> users = new Dictionary<int , User>();    
        SqlConnection conn;
        public UserRepoADO()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=CowBullGame");
        }
        public int Add(User item)
        {
            bool status = false;
            SqlCommand cmdInsert = new SqlCommand("proc_AddUsers" , conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@age", item.age);
            cmdInsert.Parameters.AddWithValue("@name", item.Name);
            cmdInsert.Parameters.AddWithValue("@password", item.Password);
            try
            {
                if(conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                conn.Close();
                if (result>0)
                {
                    conn.Open();
                    cmdInsert = new SqlCommand("proc_GetRecentUserid", conn);
                    item.id = Convert.ToInt32(cmdInsert.ExecuteScalar().ToString());
                    users.Add(item.id, item);
                    status = true;
                    conn.Close();
                }
            }
            catch (SqlException se)
            {
                Debug.WriteLine(se.StackTrace);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return item.id;
        }

        public User Get(int key)
        {
            User user = new User();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("proc_GetUsers", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@id", key);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "users");
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    user.id = (int)dataRow[0];
                    user.Name = (string)dataRow[1];
                    user.age = (int)dataRow[2];
                    user.Password = (string)dataRow[3];
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                Debug.WriteLine(se.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            return user;
        }

        public ICollection<User> GetAll(int key)
        {
            return users.Values.ToList();
        }
    }
}