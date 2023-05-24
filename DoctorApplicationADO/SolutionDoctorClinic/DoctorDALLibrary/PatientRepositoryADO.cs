using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using doctorModelLibrary;
using System.Diagnostics;

namespace DoctorDALLibrary
{
    public class PatientRepositoryADO : IRepo<Patient, int>
    {
        public static IDictionary<int, Patient> patients = new Dictionary<int, Patient>();
        SqlConnection conn;
        public PatientRepositoryADO()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=doctorAppointment"); 
            
        }
        public bool Add(Patient item)
        {
            Console.WriteLine(item);
            SqlCommand cmdInsert = new SqlCommand("proc_addPatients", conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@name", item.name);
            cmdInsert.Parameters.AddWithValue("@age", item.age);
            cmdInsert.Parameters.AddWithValue("@phn", item.phone);
            bool status = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    conn.Open();
                    cmdInsert = new SqlCommand("proc_GetRecentPid", conn);
                    item.pid = Convert.ToInt32(cmdInsert.ExecuteScalar().ToString());
                    patients.Add(item.pid, item);
                    conn.Close();
                    status = true;
                }
                else
                    Console.WriteLine("data insertion failed");
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
            return status;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_delPatients", conn);
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
                    patients.Remove(id);
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

        public Patient Get(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetSinglePatient", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            Patient patient = new Patient();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                patient.pid = (int)dataRow[0];
                patient.name = (string)dataRow[1];
                patient.age = (int)dataRow[2];
                patient.phone = (string)dataRow[3];
            }
            return patient;
        }

        public Patient[] GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_showPatients", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                Patient patient = new Patient();
                patient.pid = (int)dataRow[0];
                patient.name = (string)dataRow[1];
                patient.age = (int)dataRow[2];
                patient.phone = (string)dataRow[3];
                patients[patient.pid] = patient;
            }
            return patients.Values.ToArray();
        }

        public bool Update(Patient item)
        {
            throw new NotImplementedException();
        }
    }
}
