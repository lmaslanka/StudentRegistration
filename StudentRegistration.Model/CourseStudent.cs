namespace StudentRegistration.Model
{
    public class CourseStudent
    {
        public virtual long RecordId { get; set; }
        public virtual float Mark { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
