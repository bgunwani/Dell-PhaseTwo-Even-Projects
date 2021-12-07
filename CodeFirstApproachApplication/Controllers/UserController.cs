using CodeFirstApproachApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproachApplication.Controllers
{
    public class UserController : Controller
    {

        ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var user = context.Users.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(int id, User user)
        {
            var userObj = context.Users.Find(id);
            context.Users.Remove(userObj);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
