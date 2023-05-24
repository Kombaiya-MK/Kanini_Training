using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOExerciseApp
{
    public class UserProfileChild : UserProfile
    {
        SqlConnection conn;
        public UserProfileChild()
        {
            conn = new SqlConnection("Data Source=LAPTOP-GGUGVPR9\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbRecruitApr2023");
        }
        public override void FetchProfiles()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tblprofile", conn);
            //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    }
}
