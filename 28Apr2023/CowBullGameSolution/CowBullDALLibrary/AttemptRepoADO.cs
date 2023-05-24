using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CowBullModelLibrary;
namespace CowBullDALLibrary
{
    public class AttemptRepoADO : IRepo<Attempt, int>
    {
        SqlConnection conn;
        static List<Attempt> attempts = new List<Attempt>();
        public AttemptRepoADO() { 
            conn = new SqlConnection(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=CowBullGame");
        }

        public int Add(Attempt item)
        {
            int status = 0;
            SqlCommand cmdInsert = new SqlCommand("proc_AddAttempts", conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@id", item.id);
            cmdInsert.Parameters.AddWithValue("@Gueword", item.Gueword);
            cmdInsert.Parameters.AddWithValue("@Givword", item.Givword);
            cmdInsert.Parameters.AddWithValue("@Attempts", attempts.Count + 1);
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                if (result > 0)
                {
                    item.AttemptNumber = attempts.Count + 1;
                    attempts.Add(item);
                    status = 1;
                }
            }
            catch (SqlException se)
            {
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return status ;
        }

        public ICollection<Attempt> GetAll(int key)
        {
            Attempt attempt = new Attempt();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllAttempts", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    attempt.id = (int)dataRow[0];
                    attempt.Gueword = (string)dataRow[1];
                    attempt.Givword = (string)dataRow[2];
                    attempt.AttemptNumber = (int)dataRow[3];
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
            return attempts;
        }

        public Attempt Get(int key)
        {
            throw new NotImplementedException();
        }
    }
}
