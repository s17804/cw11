using System.Linq;
using cw11.DTO.Request;
using cw11.DTO.Response;
using cw11.Exceptions;
using cw11.Models;

namespace cw11.Services.Impl
{
    public class DoctorDbService : IDoctorService
    {

        private readonly DoctorsDbContext _context;

        public DoctorDbService(DoctorsDbContext context)
        {
            _context = context;
        }

        public DoctorResponse AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            _context.Doctors.Add(new Doctor
            {
                FirstName = addDoctorRequest.FirstName,
                LastName = addDoctorRequest.LastName,
                Email = addDoctorRequest.Email
            });
            
            return new DoctorResponse
            {
                IdDoctor = _context.SaveChanges(),
                FirstName = addDoctorRequest.FirstName,
                LastName =  addDoctorRequest.LastName,
                Email = addDoctorRequest.Email
            };
        }

        public DoctorResponse UpdateDoctor(UpdateDoctorRequest updateDoctorRequest)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc =>
                updateDoctorRequest.IdDoctor.Equals(doc.IdDoctor));

            if (doctor == null)
            {
                throw new ResourceNotFoundException("404");
            }

            doctor.FirstName = updateDoctorRequest.FirstName;
            doctor.LastName = updateDoctorRequest.LastName;
            doctor.Email = updateDoctorRequest.Email;

            _context.SaveChanges();
            
            return new DoctorResponse
            {
                IdDoctor = updateDoctorRequest.IdDoctor,
                FirstName = updateDoctorRequest.FirstName,
                LastName =  updateDoctorRequest.LastName,
                Email = updateDoctorRequest.Email
            };
        }

        public DoctorResponse GetDoctor(int idDoctor)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => idDoctor.Equals(doc.IdDoctor));
            if (doctor == null)
            {
                throw new ResourceNotFoundException("404");
            }
            return new DoctorResponse
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName =  doctor.LastName,
                Email = doctor.Email
            };
        }

        public void RemoveDoctor(int idDoctor)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => idDoctor.Equals(doc.IdDoctor));
            if (doctor == null)
            {
                throw new ResourceNotFoundException("404");
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}