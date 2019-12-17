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


namespace Exam2.Controllers
{
    public class IdeaController : Controller
    {
        private MyContext dbContext;
        public IdeaController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {   
            // if the user does not have an id then it gets thrown out
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                return RedirectToAction("RegLog", "User");
            }
            
            // Gets a single activity from all the activity then deletes it
            List<Idea> DeleteIdea = dbContext.Ideas.ToList();
            
            // Locates a all guests from a activity list 
            List<Idea> AllIdeaGuests = dbContext.Ideas.Include(g => g.Creator).Include(g => g.PeopleLikingIdeas).ThenInclude(a => a.AGuest).OrderByDescending(i => i.PeopleLikingIdeas.Count).ToList();
            // GuestsAttending comes from activity.cs in Models
            // AGuest comes from Association.cs in Models

            // if a user is logged in and is not the creator then it can be invited to the acttivity
            // LoggedUserId is used in Dashboard.cshtml
            int? LoggedUserId = HttpContext.Session.GetInt32("userid");
            List<Idea> GuestList = new List<Idea>();
            foreach(Idea guest in AllIdeaGuests)
            {
                if(LoggedUserId != guest.CreatorId)
                {
                    // to add the user's name on the guest list. 
                    GuestList.Add(guest);
                }
            }

            // this is to pass data to the cshtml because I used two models
            User Logged = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedUserId);
            // ViewBag.firstName will be used in Dashboard.cshtml while FirstName comes from The User.cs file
            // LoggedUserId comes from line 50
            ViewBag.firstName = Logged.FirstName;
            ViewBag.lastName = Logged.LastName;
            ViewBag.LoggedUserId = LoggedUserId;
            return View(AllIdeaGuests);
        }

        [HttpGet("ProcessLoggingOut")]
        public IActionResult ProcessLoggingOut()
        {
            HttpContext.Session.GetInt32("userid");
            HttpContext.Session.Clear();
            return RedirectToAction("RegLog", "User");
        }

        [HttpGet("PlanIdea")]
        public IActionResult PlanIdea()
        {
            // if there is an actual user logged in then proceed. if not then get booted out
            if(HttpContext.Session.GetInt32("userid") != null)
            {
                return View("PlanIdea");
            }
            return RedirectToAction("RegLog", "User");
        }

        [HttpPost("ProcessPlanIdea")]
        public IActionResult ProcessPlanIdea(Idea submission)
        {
            // if the user is valid then it can create a Activity
            int? LogUser = HttpContext.Session.GetInt32("userid");

            submission.CreatorId = (int)LogUser;
            if(ModelState.IsValid)
            {
                dbContext.Add(submission);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("PlanIdea", submission);
            }
        }

        [HttpGet("ViewIdea/{ideaId}")]
        public IActionResult ViewIdea(int ideaId)
        {
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                // if the user is not valid then kick it out
                HttpContext.Session.GetInt32("userid");
                HttpContext.Session.Clear();
                return RedirectToAction("RegLog", "User");
            }

            // from all the Activity created, pick a single Activity to view it. The same code appears on 220 and 221
            dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).Include(u => u.Creator).Where(g => g.IdeaId == ideaId);
            // The code below is almost exactly the same as the code above. ThisActivity is a random word that I chose.
            Idea ThisIdea = dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).Include(u => u.Creator).FirstOrDefault(w => w.IdeaId == ideaId);
            if(ThisIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            return View(ThisIdea);
        }

        [HttpGet("PersonsIdea/{ideaId}")]
        public IActionResult PersonsIdea(int ideaId)
        {
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                // if the user is not valid then kick it out
                HttpContext.Session.GetInt32("userid");
                HttpContext.Session.Clear();
                return RedirectToAction("RegLog", "User");
            }

            // from all the Activity created, pick a single Activity to view it. The same code appears on 220 and 221
            dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).Include(u => u.Creator).Where(g => g.IdeaId == ideaId);
            // The code below is almost exactly the same as the code above. ThisActivity is a random word that I chose.
            Idea ThisIdea = dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).Include(u => u.Creator).FirstOrDefault(w => w.IdeaId == ideaId);
            if(ThisIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            return View(ThisIdea);
        }

        [HttpGet("/ProcessLikeIdea/{IdeaId}")]
        public IActionResult ProcessLikeIdea(int IdeaId)
        {
            // if the user is not valid then kick it out
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("RegLog", "User");
            }

            // if the user logged in then. LoggedUser is a random word that I chose
            int? LoggedUser = HttpContext.Session.GetInt32("userid");

            // this locates the logged in user
            User LogUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedUser);
            // this locates the first or default Activity with a particular ID
            Idea ThisIdea = dbContext.Ideas.FirstOrDefault(w => w.IdeaId == IdeaId);
            if(ThisIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            // locates one person who is not the creator to be able be invited to a Activity
            Association NewGuest = new Association();
            
            // enables the logged in user to be invited to a specific Activity
            // NewGuest comes from the Association on line 144 and LogUser comes from line 137
            NewGuest.UserId = LogUser.UserId;
            // ActivityId comes from Activity.cs and ThisActivity comes from line 142
            NewGuest.IdeaId = ThisIdea.IdeaId;

            // locates the logged in user so it can be able to join a Activity and never to able to join it multiple times
            // I created JoinActivityUser randomly. It doesn't belong anywhere else besides lines 154 and 155
            int? JoinIdeaUser = HttpContext.Session.GetInt32("userid");
            if(!dbContext.Associations.Any(a => a.UserId == JoinIdeaUser && a.IdeaId == IdeaId))
            {
                dbContext.Associations.Add(NewGuest);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("ProcessUnLikeIdea/{ideaId}")]
        public IActionResult ProcessUnLikeIdea(int ideaId)
        {
            // if the user is not valid then kick it out
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                HttpContext.Session.GetInt32("userid");
                HttpContext.Session.Clear();
                return RedirectToAction("RegLog", "User");
            }

            // locates the logged in user and makes it able to unjoin a Idea
            int? LoggedUser = HttpContext.Session.GetInt32("userid");
            // ThisIdea i made randomly. I only use it one lines 178 and 179
            Association ThisIdea = dbContext.Associations.FirstOrDefault(u => u.IdeaId == ideaId && u.UserId == (int) LoggedUser);
            dbContext.Remove(ThisIdea);
            dbContext.SaveChanges();
            if(ThisIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("Delete/{ideaId}")]
        public IActionResult Delete(int ideaId)
        {
            // locates a logged in user and if that user is not logged in then...
            // LoggedUser is a random word I chose. I only use it on lines 189 and 190
            int? LoggedUser = HttpContext.Session.GetInt32("userid");
            if(LoggedUser == null)
            {
                return RedirectToAction("RegLog", "User");
            }

            // locates a single Activity to be delete it only if that user is the creator
            // DeleteActivity is a random word I chose. I only use it on lines 197, 198, and 200
            Idea DeleteIdea = dbContext.Ideas.FirstOrDefault(w => w.IdeaId == ideaId);
            if(DeleteIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            if(DeleteIdea.CreatorId == LoggedUser)
            {
                dbContext.Remove(DeleteIdea);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("EditIdea/{ideaId}")]
        public IActionResult EditIdea(int ideaId)
        {
            // if a user is not logged in then kick it out
            if(HttpContext.Session.GetInt32("userid") == null)
            {
                HttpContext.Session.GetInt32("userid");
                HttpContext.Session.Clear();
                return RedirectToAction("RegLog", "User");
            }

            // from all the Activity created, pick a single Activity so the user can edit it. The same code on lines 120 and 122 in ViewActivity
            dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).Where(w => w.IdeaId == ideaId);
            // The code below is almost exactly the same as the code above. ThisActivity is a random word that I chose.
            Idea ThisIdea = dbContext.Ideas.Include(w => w.PeopleLikingIdeas).ThenInclude(a => a.AGuest).FirstOrDefault(w => w.IdeaId == ideaId);
            if(ThisIdea == null)
            {
                return RedirectToAction("Dashboard");
            }
            return View("EditIdea", ThisIdea);

        }

        [HttpPost("EditingIdea/{ideaId}")]
        public IActionResult EditingIdea(int ideaId, Idea EditIdea)
        {
            // if everything is Ok then allow the user to edit or else not allow it to edit
            if(ModelState.IsValid)
            {
                // ActivityoEdit is a random word I chose  
                Idea IdeaToEdit = dbContext.Ideas.FirstOrDefault(w => w.IdeaId == ideaId);
                IdeaToEdit.IdeaDescription = EditIdea.IdeaDescription;


                IdeaToEdit.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", IdeaToEdit);
            }
            else
            {
                return View("EditActivity", EditIdea);
            }
        }
    }
}