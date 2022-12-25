using System.ComponentModel.DataAnnotations;

namespace ProjectES.Models
{
    public class Assay
    {
        [Key]
        public int AssayId { get; set; }
        public string AssayTitle { get; set; }
        public int SubjectId { get; set; }
        public Subject Subj { get; set; }
    }
}
