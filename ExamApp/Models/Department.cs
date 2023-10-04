using System.ComponentModel.DataAnnotations;

namespace ExamApp
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public List<Trackers> Trackers { get; set; }    
    }
}
