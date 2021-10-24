using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcCodeFirst.Models;

namespace WebAppAspNetMvcCodeFirst.Controllers
{
    public class TeachersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new TimetableContext();
            var teachers = db.Teachers.ToList();

            return View(teachers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var teacher = new Teacher();
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Create(Teacher model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new TimetableContext();

            db.Teachers.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Teachers/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TimetableContext();
            var teacher = db.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
                return RedirectPermanent("/Teachers/Index");

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            return RedirectPermanent("/Teachers/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TimetableContext();
            var teacher = db.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
                return RedirectPermanent("/Teachers/Index");

            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher model)
        {
            var db = new TimetableContext();
            var teacher = db.Teachers.FirstOrDefault(x => x.Id == model.Id);
            if (teacher == null)
                ModelState.AddModelError("Id", "Преподаватель не найден");

            if (!ModelState.IsValid)
                return View(model);

            MappingTeacher(model, teacher);

            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Teachers/Index");
        }

        private void MappingTeacher(Teacher sourse, Teacher destination)
        {
            destination.Name = sourse.Name;
            destination.Sex = sourse.Sex;
        }
    }
}