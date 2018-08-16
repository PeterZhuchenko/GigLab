using GitLab.Dtos;
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
    public class FollowmentController : ApiController
    {
        ApplicationDbContext _context;

        public FollowmentController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowmentDto dto)
        {
           
            return Ok();
        }


    }
}
