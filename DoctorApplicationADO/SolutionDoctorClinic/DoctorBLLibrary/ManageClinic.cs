using System.Security.AccessControl;
using DoctorDALLibrary;
using doctorModelLibrary;

namespace DoctorBLLibrary
{
    public class ManageClinic : IAdmin<Doctor, Patient,Appointment, int>, IPatient<Doctor, Patient,Appointment, int> , IAppointment<Doctor, Patient,Appointment, int>
    {
        IRepo<Doctor,int> _doctor;
        IRepo<Patient,int> _patient;
        IRepo<Appointment,int> _appointment;

        public ManageClinic()
        {
        }
        public ManageClinic(IRepo<Doctor, int> repo , IRepo<Patient, int> repo1 , IRepo<Appointment , int> _repo2)
        {
            _doctor = repo;
            _patient = repo1;
            _appointment = _repo2;
        }

        public bool CheckPatient(int patientId)
        {
            bool status = false;
            foreach (var p in _patient.GetAll())
            {
                if(p.pid == patientId)
                    status = true;
            }
            return status;
        }
        public bool AddDoctors(Doctor item)
        {
            return _doctor.Add(item);
        }

        public bool AddPatient(Patient p)
        {
            return _patient.Add(p);
        }

        public Appointment GetAppointment(int id)
        {
            return _appointment.Get(id); throw new NoValueException("No such appointment is booked");
        }

        public Patient GetPatient(int id)
        {
            return _patient.Get(id); throw new NoValueException("No such a patient is available");
        }

        public bool RemoveAppointments(int id)
        {
            return _appointment.Delete(id); throw new NoValueException("No appointments are booked");
        }

        public bool RemoveDoctors(int id)
        {
            return _doctor.Delete(id); throw new NoValueException("No such doctor is available to delete");
        }

        public bool RemovePatients(int id)
        {
          return _patient.Delete(id); throw new NoValueException("No such patient availeble to delete");
        }

        public Appointment[] ShowAppointments()
        {
            return _appointment.GetAll(); throw new NoValueException("No appointments are booked");
        }

        public Doctor[] ShowDoctors()
        {
            return _doctor.GetAll().ToArray();throw new NoValueException("No doctor data available");

        }

        public Patient[] ShowPatients()
        {
            return _patient.GetAll().ToArray();throw new NoValueException("No Patient data available");
        }

        public Doctor GetDoctor(int id)
        {
            return _doctor.Get(id); throw new NoValueException("No such patient available");
        }

        public bool AddAppointments(Appointment item)
        {
            if(CheckAppointment(item.Pid , item.Did , item.slot))
                return false;
            return _appointment.Add(item);
        }

        public bool CheckAppointment(int pid,int id , int slot)
        {
            bool status = false;
            Appointment appointment = _appointment.Get(pid);
            if(appointment.Did == id && appointment.slot == slot)
            {
                status = true;
            }
            return status;
        }
    }
}
