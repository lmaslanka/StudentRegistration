namespace StudentRegistration.ModelMapping
{
    using NHibernate.Mapping.ByCode.Conformist;
    using Model;
    using NHibernate.Mapping.ByCode;

    public class CourseStudentMap : ClassMapping<CourseStudent>
    {
        public CourseStudentMap()
        {
            Id(cs => cs.RecordId, m => m.Generator(Generators.Identity));

            Property(cs => cs.Mark);

            ManyToOne(cs => cs.Student, m =>
            {
                m.Column("StudentId");
                m.Cascade(Cascade.None);
                m.NotNullable(true);
            });

            ManyToOne(cs => cs.Course, m =>
            {
                m.Column("CourseId");
                m.Cascade(Cascade.None);
                m.NotNullable(true);
            });
        }
    }
}
