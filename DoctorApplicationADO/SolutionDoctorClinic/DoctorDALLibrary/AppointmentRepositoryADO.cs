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
    public class AppointmentRepositoryADO : IRepo<Appointment, int>
    {
        SqlConnection conn;
        IDictionary<int, Appointment> Appointments = new Dictionary<int ,Appointment>();
        public AppointmentRepositoryADO()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-GGUGVPR9\SQLEXPRESS;Integrated Security=true;Initial Catalog=doctorAppointment");
        }
        public bool Add(Appointment item)
        {
            SqlCommand cmdInsert = new SqlCommand("proc_AddAppointments", conn);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@dId", item.Did);
            cmdInsert.Parameters.AddWithValue("@pId", item.Pid);
            cmdInsert.Parameters.AddWithValue("@slot", item.slot);
            cmdInsert.Parameters.AddWithValue("@fee", item.fee);
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
                    cmdInsert = new SqlCommand("proc_GetRecentAppId", conn);
                    item.AppointmentId = Convert.ToInt32(cmdInsert.ExecuteScalar().ToString());
                    Appointments.Add(item.AppointmentId, item);
                    conn.Close();
                    status = true;
                    //return item;
                }
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_DelAppointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppId", id);
            bool status = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Appointments.Remove(id);
                status = true;

            }
            catch (SqlException se)
            {
                Console.WriteLine("Duplicate constraints can not be added!!");
                Debug.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public Appointment Get(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_ShowPatientAppointments", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@pid", id);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Appointments");
            Appointment appointment = new Appointment();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                appointment.AppointmentId = (int)dataRow[0];
                appointment.Pid = (int)dataRow[1];
                appointment.Did= (int)dataRow[2];
                appointment.slot = (int)dataRow[3];
                appointment.fee = (double)dataRow[4];
            }
            return appointment;
        }

        public Appointment[] GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_ShowAllAppointments", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //adapter.SelectCommand.Parameters.AddWithValue("@pid", id);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Appointments");
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = (int)dataRow[0];
                appointment.Pid = (int)dataRow[1];
                appointment.Did = (int)dataRow[2];
                appointment.slot = (int)dataRow[3];
                appointment.fee = (double)dataRow[4];
                Appointments[appointment.AppointmentId] = appointment;
            }
            return Appointments.Values.ToArray();
        }

        public bool Update(Appointment item)
        {
            throw new NotImplementedException();
        }
    }
}
