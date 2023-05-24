using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorDALLibrary;
using doctorModelLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DoctorDALLibrary
{
    public class DoctorRepositoryADO : IRepo<Doctor, int>
    {
        public static IDictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();
        SqlConnection conn;

        public DoctorRepositoryADO()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=doctorAppointment");

        }

        public bool Add(Doctor item)
        {
            
            SqlCommand cmdInsert = new SqlCommand("proc_addDoctors", conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@name", item.name);
            cmdInsert.Parameters.AddWithValue("@exp", item.exp);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            int result = cmdInsert.ExecuteNonQuery();
            conn.Close();
            bool status = false;
            if (result > 0)
            {
                conn.Open();
                cmdInsert = new SqlCommand("proc_GetRecentId", conn);
                item.Id = Convert.ToInt32(cmdInsert.ExecuteScalar().ToString());
                doctors.Add(item.Id, item);
                conn.Close();
                status = true;
                //return item;
            }
            return status;

        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_delDoctors", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            bool status = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    doctors.Remove(id);
                    status = true;
                  
            }
            catch (SqlException se)
            {
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public Doctor Get(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetSingleDoctor", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            Doctor doctor = new Doctor();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                    doctor.Id = (int)dataRow[0];
                    doctor.name = (string)dataRow[1];
                    doctor.exp = (int)dataRow[2];

            }
            return doctor;
        }

        public Doctor[] GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_showDoctors", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                Doctor doctor = new Doctor();
                doctor.Id = (int)dataRow[0];
                doctor.name = (string)dataRow[1];
                doctor.exp = (int)dataRow[2];
                doctors[doctor.Id] = doctor;
            }
            return doctors.Values.ToArray();

        }

        public bool Update(Doctor item)
        {
            throw new NotImplementedException();
        }
    }
}
