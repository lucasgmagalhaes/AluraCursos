using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Loja.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = CriarSessionFactory();

        private static ISessionFactory CriarSessionFactory()
        {
            Configuration cfg = RecuperarConfiguracao();
            return cfg.BuildSessionFactory();
        }

        public static Configuration RecuperarConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static void GerarEsquemas()
        {
            Configuration cfg = RecuperarConfiguracao();
            new SchemaExport(cfg).Create(true, true);
        }

        public static ISession AbrirSessao()
        {
            return factory.OpenSession();
        }
    }
}
