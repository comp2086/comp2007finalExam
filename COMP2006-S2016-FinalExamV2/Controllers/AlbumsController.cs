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
    public class AlbumsController : Controller
    {
        private MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: Albums
        public async Task<ActionResult> Index()
        {
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(await albums.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
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
