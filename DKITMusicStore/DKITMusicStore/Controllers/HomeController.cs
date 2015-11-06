using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKITMusicStore.Migrations;
using DKITMusicStore.Models;

namespace DKITMusicStore.Controllers
{
    //private ApplicationDbContext db = new ApplicationDbContext();
    public class HomeController : Controller

    {
        private DKITMusicStoreEntities db = new DKITMusicStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Browse()
        {
            var genreModel = db.Genres.ToList();
            return View(genreModel);
        }

        public ActionResult BrowseAlbums(string genre)
        {
            // var albumModel = db.Albums.Include("Albums").Single(a => a. == genre);
            // return View(genreModel);
            // Retrieve Genre and its Associated Albums from database
            var genreModel = db.Genres.Include("Albums").Single(a => a.Name == genre);

            return View(genreModel);

        }

        public ActionResult BrowseAlbumDetails(int id)
        {
            ViewBag.Message = "Album Details";
            var album = db.Albums.Find(id);
            return View(album);
        }

    }
}