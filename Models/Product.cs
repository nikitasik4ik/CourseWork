using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "Бренд")]
        [Required(ErrorMessage = "Поле 'Бренд' обязательно для заполнения")]
        public string? Brand { get; set; }

        [Display(Name = "Вид")]
        public int? ViewId { get; set; }

        [Display(Name = "Поставщик")]
        public int? ProviderId { get; set; }

        [Display(Name = "Поставщик")]
        public virtual Provider? Provider { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        [Display(Name = "Вид")]
        public virtual ProductV? View { get; set; }
    }
}