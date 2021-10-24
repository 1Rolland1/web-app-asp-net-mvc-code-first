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
    public class Group
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>    
        [Required]
        [Display(Name = "Название группы", Order = 5)]
        public string GroupName { get; set; }

        // <summary>
        /// Фамилия Имя Отчество студента
        /// </summary>    
        [Required]
        [Display(Name = "Количество студентов", Order = 10)]
        public int? NumberOfStudents { get; set; }

        /// <summary>
        /// Предметы
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}