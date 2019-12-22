using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    public class AccountController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Login/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(GestionZafra.Models.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Usuario.First(u => u.nombreUsuario.Equals(model.Usuario));
                if (CompareEqualsPasswords(user.pass,model.Contrasena))
                {
                    Session.Add("usuarioActual", user);
                    if (!db.ParametrosGenerales.Any())
                    {
                        return RedirectToAction("Zafra", "Config");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "El nombre de usuario o la contreseña son incorrectos");
            return View(model);
        }

        [HandleError]
        public ActionResult LogOff()
        {
            Session.Remove("usuarioActual");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [LoginFilter(Rol = "Todos")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var usuarioactual = Session["usuarioActual"] as Usuario;
            var usuario = db.Usuario.Find(usuarioactual.id);
            MD5 crypto = MD5.Create();
            var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(changePasswordModel.NewPassword)));
            usuario.pass = passcryto;
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                Session.Remove("usuarioActual");
                Session.Add("usuarioActual", usuario);
                return RedirectToAction("Index", "Home");
            }
            return View(changePasswordModel);
        }
        [HttpPost]
        public JsonResult CheckOldPassword(string OldPassword)
        {
            var result = true;
            var usuario = Session["usuarioActual"] as Usuario;
            result = CompareEqualsPasswords(usuario.pass, OldPassword);
            return Json(result, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult CheckLoginPassword(string Contrasena,string Usuario)
        {
            var result = true;
            try
            {
                var user = db.Usuario.First(u => u.nombreUsuario == Usuario && u.activo);
                result = CompareEqualsPasswords(user.pass, Contrasena);
            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult CheckLoginUser(string Usuario)
        {
            var result = true;
            try
            {
                var user = db.Usuario.First(u => u.nombreUsuario == Usuario && u.activo);
            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public static bool CompareEqualsPasswords(string pass1, string pass2)
        {
            MD5 crypto = MD5.Create();
            var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(pass2)));
            return pass1.Equals(passcryto);
        }

    }
}
