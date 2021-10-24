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
    public class Teacher
    {
        ///<summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        ///<summary>
        /// Имя преподавателя
        /// </summary> 
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        [ScaffoldColumn(false)]
        public Sex Sex { get; set; }

        [Display(Name = "Пол", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("Sex")]
        [NotMapped]
        public IEnumerable<SelectListItem> SexDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (Sex type in Enum.GetValues(typeof(Sex)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == Sex
                    });
                }

                return dictionary;
            }
        }

        ///<summary>
        /// Список предметов, которые ведет преподаватель
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}