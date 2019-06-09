using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/

        private readonly UsuariosDAO usuarioDAO;

        public UsuariosController()
        {
            this.usuarioDAO = new UsuariosDAO(NHibernateHelper.AbreSession());
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            usuarioDAO.Adiciona(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            return RedirectToAction("Index");
        }

    }
}
