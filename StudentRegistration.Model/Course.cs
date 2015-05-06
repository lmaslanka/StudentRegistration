namespace StudentRegistration.Model
{
    public class Course
    {
        public virtual long RecordId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Capacity { get; set; }
    }
}
