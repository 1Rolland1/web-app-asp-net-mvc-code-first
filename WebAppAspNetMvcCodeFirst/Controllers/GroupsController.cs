using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebAppAspNetMvcCodeFirst.Models;


namespace WebAppAspNetMvcCodeFirst.Controllers
{
    public class GroupsController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new TimetableContext();
            var groups = db.Groups.ToList();
            return View(groups);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var group = new Group();

            return View(group);
        }

        [HttpPost]
        public ActionResult Create(Group model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var db = new TimetableContext();

            db.Groups.Add(model);
            db.SaveChanges();


            return RedirectPermanent("/Groups/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TimetableContext();
            var group = db.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
                return RedirectPermanent("/Groups/Index");

            db.Groups.Remove(group);
            db.SaveChanges();

            return RedirectPermanent("/Groups/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TimetableContext();
            var group = db.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
                return RedirectPermanent("/Groups/Index");

            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(Group model)
        {

            var db = new TimetableContext();
            var group = db.Groups.FirstOrDefault(x => x.Id == model.Id);
            if (group == null)
            {
                ModelState.AddModelError("Id", "Группа не найдена");
            }
            if (!ModelState.IsValid)
                return View(model);

            MappingGroup(model, group);


            db.Entry(group).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectPermanent("/Groups/Index");
        }

        private void MappingGroup(Group sourse, Group destination)
        {
            destination.GroupName = sourse.GroupName;
            destination.NumberOfStudents = sourse.NumberOfStudents;
        }
    }
}