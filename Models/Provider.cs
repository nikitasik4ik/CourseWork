using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Provider
    {
        public int ProviderId { get; set; }

        [Display(Name = "Наименование поставщика")]
        [Required(ErrorMessage = "Поле 'Наименование поставщика' обязательно для заполнения")]
        public string? NameProvider { get; set; }

        [Display(Name = "Cтрана")]
        public int? CountryId { get; set; }

        [Display(Name = "Телефон поставщика")]
        [Required(ErrorMessage = "Поле 'Телефон поставщика' обязательно для заполнения")]
        public string? PhoneProvider { get; set; }

        [Display(Name = "Email поставщика")]
        [Required(ErrorMessage = "Поле 'Email поставщика' обязательно для заполнения")]
        public string? EmailProvider { get; set; }

        [Display(Name = "Страна")]
        public virtual Country? Country { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}