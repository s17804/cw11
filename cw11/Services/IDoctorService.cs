using System.Collections;
using System.Collections.Generic;
using cw11.DTO.Request;
using cw11.DTO.Response;

namespace cw11.Services
{
    public interface IDoctorService
    {
        public DoctorResponse AddDoctor(AddDoctorRequest addDoctorRequest);

        public DoctorResponse UpdateDoctor(UpdateDoctorRequest updateDoctorRequest);

        public DoctorResponse GetDoctor(int idDoctor);

        public void RemoveDoctor(int idDoctor);
    }
}