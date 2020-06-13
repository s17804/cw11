using cw11.DTO.Request;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        [Route("addDoctor")]
        public IActionResult AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            return Ok(_doctorService.AddDoctor(addDoctorRequest));
        }

        [HttpGet]
        [Route("getDoctor")]
        public IActionResult GetDoctor(int idDoctor)
        {
            return Ok(_doctorService.GetDoctor(idDoctor));
        }

        [HttpPut]
        [Route("updateDoctor")]
        public IActionResult UpdateDoctor(UpdateDoctorRequest updateDoctorRequest)
        {
            return Ok(_doctorService.UpdateDoctor(updateDoctorRequest));
        }

        [HttpDelete]
        [Route("deleteDoctor")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            _doctorService.RemoveDoctor(idDoctor);
            return Ok("Doctor with id " + idDoctor + " was removed");
        }
        
    }
}