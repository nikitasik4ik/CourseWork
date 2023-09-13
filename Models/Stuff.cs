using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Stuff
    {
        public int StuffId { get; set; }

        [Required(ErrorMessage = "Поле 'ФИО сотрудника' обязательно для заполнения")]
        [Display(Name = "ФИО сотрудника")]
        public string FullNameStuff { get; set; }

        [Display(Name = "Должность")]
        public int? PostId { get; set; }

        [Display(Name = "Должность")]
        public virtual Post? Post { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}