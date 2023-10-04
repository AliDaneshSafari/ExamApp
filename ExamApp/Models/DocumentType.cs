using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ExamApp
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع مکتوب")]
        [MaxLength(100)]
        public string Title { get; }
    }
}
