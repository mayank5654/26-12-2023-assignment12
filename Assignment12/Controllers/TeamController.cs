
using Assignment12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment12.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        static List<Team> listTeams = new List<Team>()
        {
            new Team(){TeamId=1,TeamName="India",NOWC=2},
            new Team(){TeamId=2,TeamName="Australia",NOWC=4},
            new Team(){TeamId=3,TeamName="West Indies",NOWC=2},
             new Team(){TeamId=4,TeamName="England",NOWC=1}
        };
        public ActionResult Index()
        {
            ViewBag.msg = "Welcome to Employee";
            ViewBag.noTeam = listTeams.Count;
            ViewData["message"] = "I am from View Data";
            return View(listTeams);
        }
        public ActionResult Display()
        {
            ViewBag.msg = "We can display students details from here.";
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.msg = "We can register Student from here.";
            return View(new Team());
        }
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                listTeams.Add(team);
            }
            return RedirectToAction("Index");
        }
        public ActionResult TempDataEx()
        {
            Session["teamCount"] = listTeams.Count;
            TempData["teamCount"] = listTeams.Count;
            return RedirectToAction("Display");
        }
        public ActionResult PAction()
        {
            return PartialView("PView");
        }
    }
}