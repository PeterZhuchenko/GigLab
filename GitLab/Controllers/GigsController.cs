using GitLab.Models;
using GitLab.Models.GitModels;
using GitLab.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitLab.Controllers
{
    public class GigsController : Controller
    {
        ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
                        
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime()
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyGigs()
        {
            var artistId = User.Identity.GetUserId();
            var listOfGigs = _context.Gigs.Where(a => a.ArtistId == artistId).ToList();
            
            foreach (var gig in listOfGigs)
            {
                var id = gig.GenreId;
                var genre = _context.Genres.Single(g => g.Id == id).Name;
                gig.Genre.Name = genre;
            }

            return View(listOfGigs);
        }

        public ActionResult MyArtists()
        {
            return View();
        }
    }
}