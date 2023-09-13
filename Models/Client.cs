using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Необходимо заполнить поле Имя")]
        public string? FirstNameClient { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Необходимо заполнить поле Фамилия")]
        public string? LastNameClient { get; set; }

        [Display(Name = "Отчество")]
        //[Required(ErrorMessage = "Необходимо заполнить поле Отчество")]
        public string? PatronomykClient { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Необходимо заполнить поле Дата рождения")]
        public DateTime? DateBirth { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Необходимо заполнить поле Телефон")]
        public string? PhoneClient { get; set; }

        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Необходимо заполнить поле Электронная почта")]
        [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
        public string? Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public string FullName
        {
            get { return $"{LastNameClient} {FirstNameClient} {PatronomykClient}"; }
        }
    }
}