using GitLab.Models;
using GitLab.Models.GigModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitLab.Controllers
{
    public class AttendancesController : ApiController
    {
        ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var userId = User.Identity.GetUserId();
            var attendanceExists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId);

            if (attendanceExists)
                return BadRequest("The attendance already exists!");

            var attendance = new Attendance()
            {
                GigId = gigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
