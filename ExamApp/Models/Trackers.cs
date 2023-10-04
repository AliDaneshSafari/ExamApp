using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp
{
    public class Trackers
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="ارسال به ")]
        public int? SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        [Display(Name = "دریافت از ")]

        public int? ReciverId { get; set; }

        [ForeignKey(nameof(SenderId))]
       public virtual Department Department { get; set; }

        [Display(Name = "نمبر وارده ")]

        public string? In_Number { get; set; }
        [Display(Name = "نمبر صادره ")]

        public string? Out_Number { get; set; }
        [Display(Name = "تاریخ وارده ")]

        public DateTime? In_Date { get; set; }
        [Display(Name = "تاریخ صادره ")]

        public DateTime? Out_Date { get; set;}

        public DateTime? CreateDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "موضوع مکتوب ")]

        public string? Subject { get; set; }
        [Display(Name = "شرح ")]

        public string Remark { get; set; }

        public int? UserId { get; set; }


        [Display(Name = "وضعیت مکتوب ")]
        public bool? isApprove { get; set; } = false;
       
        public List<AtachFile> atachFiles { get; set; }


        [Display(Name = "کامنت رئیس یا وزیر  ")]

        public string? AssignRemark { get; set; } = null;



        [Display(Name = "نمر ارشیف  ")]

        public string? ArchiveNumber { get; set; } = null;








    }
}
