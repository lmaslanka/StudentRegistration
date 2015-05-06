namespace StudentRegistration.ModelMapping
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    using StudentRegistration.Model;

    public class CourseMap : ClassMapping<Course>
    {
        public CourseMap()
        {
            Id(c => c.RecordId, m => m.Generator(Generators.Identity));
            Property(c => c.Name);
            Property(c => c.Description);
            Property(c => c.Capacity);
        }
    }
}
