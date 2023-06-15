using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Mapiranja;

namespace Zatvor
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString(c =>
                    c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;USER ID=S17513;Password=S17513"));

                return Fluently.Configure()
                    .Database(cfg.ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZatvorskaJedinicaMapiranja>())
                    //.ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }
            catch (Exception 
            ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
                return null;
            }

        }
    }
}
