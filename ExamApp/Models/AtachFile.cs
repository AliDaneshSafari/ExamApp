using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ExamApp
{
    public class AtachFile
    {
        [Key] 
        public  int id { get; set; }

        public  string FilePath { get; set; }


        public int TrackerId { get; set; }
        [ForeignKey(nameof(TrackerId))]
        public virtual Trackers Trackers { get; set; }

    }
}
