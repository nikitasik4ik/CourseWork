using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }

        [Display(Name = "Продукт")]
        public int? ProductId { get; set; }

        [Display(Name = "Дата продажи")]
        //[Required(ErrorMessage = "Поле 'Дата продажи' обязательно для заполнения")]
        public DateTime? DateSale { get; set; }

        [Display(Name = "Количество")]
        //[Required(ErrorMessage = "Поле 'Количество' обязательно для заполнения")]
        public int? Quantity { get; set; }

        [Display(Name = "Сотрудник")]
        public int? StuffId { get; set; }

        [Display(Name = "Клиент")]
        public int? ClientId { get; set; }

        [Display(Name = "Клиент")]
        //[Required(ErrorMessage = "Поле 'Клиент' обязательно для заполнения")]
        public virtual Client? Client { get; set; }

        [Display(Name = "Продукт")]
        public virtual Product? Product { get; set; }

        [Display(Name = "Сотрудник")]
        public virtual Stuff? Stuff { get; set; }
    }
}