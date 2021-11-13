using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcCodeFirst.Models;

namespace WebAppAspNetMvcCodeFirst.Controllers
{
    public class LessonsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new TimetableContext();
            var lessons = db.Lessons.ToList();

            return View(lessons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lesson = new Lesson();
            return View(lesson);
        }

        [HttpPost]
        public ActionResult Create(Lesson model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new TimetableContext();
            

            

            if (model.GroupIds != null && model.GroupIds.Any())
            {
                var group = db.Groups.Where(s => model.GroupIds.Contains(s.Id)).ToList();
                model.Groups = group;
            }

            db.Lessons.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Lessons/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TimetableContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                return RedirectPermanent("/Lessons/Index");

            db.Lessons.Remove(lesson);
            db.SaveChanges();

            return RedirectPermanent("/Lessons/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TimetableContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                return RedirectPermanent("/Lessons/Index");

            return View(lesson);
        }

        [HttpPost]
        public ActionResult Edit(Lesson model)
        {
            var db = new TimetableContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == model.Id);
            if (lesson == null)
                ModelState.AddModelError("Id", "Пара не найдена");

            if (!ModelState.IsValid)
                return View(model);

            MappingLesson(model, lesson, db);

            db.Entry(lesson).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Lessons/Index");
        }

        private void MappingLesson(Lesson sourse, Lesson destination, TimetableContext db)
        {
            destination.Number = sourse.Number;
            destination.Name = sourse.Name;          
            destination.TeacherId = sourse.TeacherId;
            destination.Teacher = sourse.Teacher;


            if (destination.Groups != null)
                destination.Groups.Clear();

            if (sourse.GroupIds != null && sourse.GroupIds.Any())
                destination.Groups = db.Groups.Where(s => sourse.GroupIds.Contains(s.Id)).ToList();           
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var db = new TimetableContext();
            var image = db.TeacherImages.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(Server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                return File(new MemoryStream(fileData), "image/jpeg");
            }

            return File(new MemoryStream(image.Data), image.ContentType);
        }
    }
}