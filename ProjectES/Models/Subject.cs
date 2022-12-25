namespace ProjectES.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public ICollection<Assay> Assays { get; set; }
    }
}
