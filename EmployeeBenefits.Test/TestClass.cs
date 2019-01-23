using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;
using Xunit;
using Environment = NHibernate.Cfg.Environment;

namespace Unit.Test
{
    public class InMemoryDatabaseForXmlMappings : IDisposable
    {        
        protected Configuration config;
        protected ISessionFactory sessionFactory;
        public ISession Session;

        [Fact]
        public void InMemoryDatabaseXmlMappings()
        {            
            config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof (SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof (SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "data source =:memory:")
                .AddFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\..\Persistence/bin/debug/netcoreapp2.1/Xml/Employee.hbm.xml"));

            sessionFactory = config.BuildSessionFactory();

            Session = sessionFactory.OpenSession();

            new SchemaExport(config).Execute(
                useStdOut: true,
                execute: true,
                justDrop: false,
                connection: Session.Connection,
                exportOutput: Console.Out);
        }

        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
