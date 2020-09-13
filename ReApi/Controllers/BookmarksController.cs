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

    public class BookmarksController : Controller
    {
        public IActionResult Index()
        {
            List<Bookmark> bookmarks = HttpContext.Session.GetObject<Bookmark>("bookmark");
            return View(bookmarks);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
