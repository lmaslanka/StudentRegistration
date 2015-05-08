namespace StudentRegistration.Main
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Linq;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;

    using StudentRegistration.Model;
    using StudentRegistration.ModelMapping;

    public class Program
    {
        public static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
                {
                    x.ConnectionString = "Data Source=test.db;Version=3;New=True";
                    x.Driver<SQLite20Driver>();
                    x.Dialect<SQLiteDialect>();
                    x.LogSqlInConsole = true;
                });

            var mapper = new ModelMapper();
            mapper.AddMappings(new List<Type> { typeof(StudentMap), typeof(CourseMap), typeof(CourseStudentMap) });
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddDeserializedMapping(mapping, null);

            var schemaUpdate = new SchemaUpdate(cfg);
            schemaUpdate.Execute(Console.WriteLine, true);

            var sessionFactory = cfg.BuildSessionFactory();
            using(var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var students = from student in session.Query<Student>()
                               orderby student.LastName
                               select student;

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }

                tx.Commit();
            }
        }
    }
}
