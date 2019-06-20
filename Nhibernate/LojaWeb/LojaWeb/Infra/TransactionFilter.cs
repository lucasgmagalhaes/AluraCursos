using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Infra
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private readonly ISession session;

        public TransactionFilter()
        {
            this.session = NHibernateHelper.AbreSession();
        }
        public override void OnActionExecuting(ActionExecutingContext contexto)
        {
            session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext contexto)
        {
            if (contexto.Exception != null)
            {
                session.Transaction.Rollback();
                session.Close();
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                this.session.Transaction.Commit();
            }
            else
            {
                this.session.Transaction.Rollback();
            }
            this.session.Close();
        }
    }
}