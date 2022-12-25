using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectES.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50,ErrorMessage = "Over the MaxLength")]
        [Display(Name = "Subject Type")]
        public string SubjectType { get; set; }

        public ICollection<Assay> Assays { get; set; }
    }
}
