namespace StudentRegistration.ModelMapping
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    using StudentRegistration.Model;

    public class StudentMap : ClassMapping<Student>
    {
        public StudentMap()
        {
            Id(s => s.RecordId, m => m.Generator(Generators.Identity));
            Property(s => s.FirstName);
            Property(s => s.LastName);
            Property(s => s.Gender);
            Property(s => s.DateOfBirth);
            Property(s => s.ClassAverage);
            Property(s => s.MajorAverage);
        }
    }
}
