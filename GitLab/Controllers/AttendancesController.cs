using GitLab.Dtos;
using GitLab.Models;
using GitLab.Models.GigModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GitLab.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var attendanceExists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (attendanceExists)
                return BadRequest("The attendance already exists!");

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
