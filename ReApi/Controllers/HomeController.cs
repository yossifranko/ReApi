using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReApi.Models;
using ReApi.Extensions;

namespace ReApi.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public IActionResult Bookmark([FromBody]Bookmark bookmark)
        {
            if(bookmark == null)
            {
                return BadRequest("item was null");
            }
            List<Bookmark> bookmarks = HttpContext.Session.GetObject<Bookmark>("bookmark") ?? new List<Bookmark>();
            if (bookmarks.Any(x => x.ID == bookmark.ID))
                return Ok("Allready Exist");
            bookmarks.Add(bookmark);

            HttpContext.Session.SetObject("bookmark", bookmarks);

            bookmarks = HttpContext.Session.GetObject<Bookmark>("bookmark");
            return Ok("item was added");

        }

        public IActionResult BookmarkList()
        {
            List<Bookmark> bookmarks  = HttpContext.Session.GetObject<Bookmark>("bookmark");
            return Ok(bookmarks);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
