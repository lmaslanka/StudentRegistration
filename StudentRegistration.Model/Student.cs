namespace StudentRegistration.Model
{
    using System;

    public class Student
    {
        public virtual long RecordId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual double ClassAverage { get; set; }
        public virtual double MajorAverage { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}, {2} : {3} ({4}), [{5}, {6}]", this.RecordId, this.LastName, this.FirstName, this.Gender, this.DateOfBirth.ToShortDateString(), this.ClassAverage, this.MajorAverage);
        }
    }
}
