using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class ProductT
    {
        public int TypeId { get; set; }

        [Display(Name = "Название типа")]
        [Required(ErrorMessage = "Поле 'Название типа' обязательно для заполнения")]
        public string? NameType { get; set; }

        public virtual ICollection<ProductV> ProductVs { get; set; } = new List<ProductV>();
    }
}