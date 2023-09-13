using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class ProductV
    {
        public int ViewId { get; set; }

        [Display(Name = "Наименование вида")]
        [Required(ErrorMessage = "Поле 'Наименование вида' обязательно для заполнения")]
        public string? NameView { get; set; }

        [Display(Name = "Типа")]
        public int? TypeId { get; set; }

        [Display(Name = "Тип")]
        public virtual ProductT? Type { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}