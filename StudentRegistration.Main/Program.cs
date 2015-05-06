namespace StudentRegistration.Main
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
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

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var mapper = new ModelMapper();
            mapper.AddMappings(new List<Type> { typeof(StudentMap) });
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddDeserializedMapping(mapping, null);

            //var schemaUpdate = new SchemaUpdate(cfg);
            //schemaUpdate.Execute(Console.WriteLine, true);

            var sessionFactory = cfg.BuildSessionFactory();
            using(var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var students = session.CreateCriteria<Student>().List<Student>();

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }

                tx.Commit();
            }
        }
    }
}
