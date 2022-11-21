using MidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class RestaurantController : Controller
    {
        RMSEntities2 db = new RMSEntities2();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayRestaurant()
        {
            List < Restaurant > list = db.Restaurants.OrderByDescending(x => x.id).ToList();
            return View(list);

        }

        [HttpGet] 
        public ActionResult CreateRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRestaurant(Restaurant res)
        {
            db.Restaurants.Add(res);
            db.SaveChanges();
            return RedirectToAction("DisplayRestaurant");
        }

        [HttpGet]
        public ActionResult UpdateRestaurant(int id)
        {
            Restaurant rs = db.Restaurants.Where(x => x.id == id).SingleOrDefault();
            return View(rs);
        }

        [HttpPost]
        public ActionResult UpdateRestaurant(int id, Restaurant res)
        {
            Restaurant rs = db.Restaurants.Where(x =>x.id == id).SingleOrDefault();
            rs.Name = res.Name;
            db.SaveChanges();
            return RedirectToAction("DisplayRestaurant");
        }

        [HttpGet]
        public ActionResult RestaurantDetail(int id)
        {
            Restaurant res = db.Restaurants.Where(x => x.id == id).SingleOrDefault();
            return View(res);
        }

        [HttpGet]
        public ActionResult DeleteRestaurant(int id)
        {
            Restaurant res = db.Restaurants.Where(x => x.id == id).SingleOrDefault();
            return View(res);
        }

        [HttpPost]
        public ActionResult DeleteRestaurant(int id, Restaurant res)
        {
            db.Restaurants.Remove(db.Restaurants.Where(x => x.id==id).SingleOrDefault());
            db.SaveChanges();
            return View("DisplayRestaurant"); 
        }


    }
}