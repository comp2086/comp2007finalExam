/**
 * Author: Alex Andriishyn, 200296533
 * App: MVC Music Store
 * File: GenresController.cs
 * Descripton: Genres controller class
 * version: 0.1
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2006_S2016_FinalExamV2.Models;

namespace COMP2006_S2016_FinalExamV2.Controllers
{
    public class GenresController : Controller
    {
        private MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: Genres
        public async Task<ActionResult> Index()
        {
            return View(await db.Genres.ToListAsync());
        }

        // GET: Genres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = await db.Genres.FindAsync(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
	
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
