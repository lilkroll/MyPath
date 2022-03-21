using Microsoft.AspNetCore.Mvc;
using MyPath.Data;
using MyPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPath.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Post>  objList = _db.Posts;
            return View(objList);
        }
        //GET-CREATE
        public IActionResult Create()
        {
            
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post obj)
        {
            obj.Date = DateTime.Now;
            _db.Posts.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
