using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace LojaWeb.Infra
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory factory = RecuperaConfiguracao().BuildSessionFactory();

        public static Configuration RecuperaConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static ISession AbreSession()
        {
            return factory.OpenSession();
        }
    }
}