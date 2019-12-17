using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Exam2.Controllers;

namespace Exam2.Controllers
{
    public class UserController : Controller
    {
        private MyContext dbContext;
        public UserController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult RegLog()
        {
            return View();
        }

        [HttpPost]
        [Route("ProcessRegistration")]

        // LogRegViewModel comes from the Models LogRegViewModel.cs file name
        // NewUser is one instance of LogRegViewModel. This makes a new user
        public IActionResult ProcessRegistration(LogRegViewModel NewUser)
        {

            if (ModelState.IsValid)
            {
                // RegisterUser comes from LogRegViewModel. Email comes from the .cshtml file in RegLog
                // The if statement down below checks that the Email provided is unique, if not then return an error and redirect to 
                if (dbContext.Users.Any(u => u.Email == NewUser.RegisterUser.Email))
                {
                    ModelState.AddModelError("RegisterUser.Email", "Email already in use!");
                    return View("RegLog");
                }
                // the next two lines hash the new users Password
                var Hasher = new PasswordHasher<User>();
                NewUser.RegisterUser.Password = Hasher.HashPassword(NewUser.RegisterUser, NewUser.RegisterUser.Password);
                dbContext.Users.Add(NewUser.RegisterUser);
                dbContext.SaveChanges();

                // Here I set "userid" as the id of the user registering
                HttpContext.Session.SetInt32("userid", NewUser.RegisterUser.UserId);
                // return RedirectToAction("Dashboard");
                return Redirect("Dashboard");
            }
            return View("RegLog", NewUser);
        }

        [HttpPost("ProcessLogin")]
        public IActionResult ProcessLogin(LogRegViewModel LoggingUser)
        {
            if (ModelState.IsValid)
            {
                User UserInDb = dbContext.Users.FirstOrDefault(u => u.Email == LoggingUser.LoginUser.LoginEmail);
                var LoginHasher = new PasswordHasher<LoginUser>();
                if (UserInDb == null)
                {
                    // if there is no user provided then go nowhere
                    ModelState.AddModelError("LoginEmail", "Email or Password is Invalid!");
                    return View("RegLog", LoggingUser);
                }
                else if (LoginHasher.VerifyHashedPassword(LoggingUser.LoginUser, UserInDb.Password, LoggingUser.LoginUser.LoginPassword) == 0)
                {

                    ModelState.AddModelError("LoginEmail", "Email or Password is Invalid!");
                    return View("RegLog");
                }

                else
                {
                    // Show this and take the problem user back to RegLog
                    HttpContext.Session.SetInt32("userid", UserInDb.UserId);
                    return Redirect("Dashboard");
                }
            }
            return View("RegLog");
        }
    }
}