using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public partial class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Поле 'Наименование должности' обязательно для заполнения")]
        [Display(Name = "Наименование должности")]
        public string? NamePost { get; set; }

        public virtual ICollection<Stuff> Stuffs { get; set; } = new List<Stuff>();
    }
}