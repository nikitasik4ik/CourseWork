using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Country
    {
        public int CountryId { get; set; }

        [Display(Name = "Название страны")]
        public string? NameCountry { get; set; }

        public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
    }
}