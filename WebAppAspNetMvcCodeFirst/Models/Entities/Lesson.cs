using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcCodeFirst.Extensions;
using WebAppAspNetMvcCodeFirst.Models.Attributes;

namespace WebAppAspNetMvcCodeFirst.Models
{
    public class Lesson
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Порядковый номер пары в расписании
        /// </summary>    
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Группа, у которой будет пара
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Group> Groups { get; set; }

        [ScaffoldColumn(false)]
        public List<int> GroupIds { get; set; }

        [Display(Name = "Группы", Order = 70)]
        [UIHint("MultipleDropDownList")]
        [TargetProperty("GroupIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> GroupDictionary
        {
            get
            {
                var db = new TimetableContext();
                var query = db.Groups;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Lessons.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.GroupName}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }



        /// <summary>
        /// Фото преподавателя
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual TeacherImage TeacherImage { get; set; }
       
        [Display(Name = "Фото преподавателя", Order = 60)]
        [NotMapped]
        public HttpPostedFileBase TeacherImageFile { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary> 
        [ScaffoldColumn(false)]
        public int TeacherId { get; set; }
        [ScaffoldColumn(false)]
        public virtual Teacher Teacher { get; set; }
        [Display(Name = "Преподаватель", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("TeacherId")]
        [NotMapped]
        public IEnumerable<SelectListItem> TeacherDictionary
        {
            get
            {
                var db = new TimetableContext();
                var query = db.Teachers;

                if (query != null)
                {
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.OrderBy(d => d.Name).ToSelectList(c => c.Id, c => c.Name, c => c.Id == TeacherId));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }







    }
}