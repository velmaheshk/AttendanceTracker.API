using AttendanceTracker.Application.Interfaces.IServices;
using AttendanceTracker.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this._attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _attendanceService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _attendanceService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Add(Attendance attendance)
        {
            try
            {
                var result = _attendanceService.Add(attendance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Update(Attendance attendance)
        {
            try
            {
                var result = _attendanceService.Update(attendance);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _attendanceService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
