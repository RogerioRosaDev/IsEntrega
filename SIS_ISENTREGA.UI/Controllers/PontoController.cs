using SIS_ISENTREGA.Application;
using SIS_ISENTREGA.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS_ISENTREGA.UI.Controllers
{
    [Authorize]
    public class PontoController : Controller
    {
        // GET: Ponto
        private readonly IMatrizApplication _matriz;
        private readonly IPontoApplication _ponto;

        public PontoController(IMatrizApplication matriz, IPontoApplication ponto)
        {
            _matriz = matriz;
            _ponto = ponto;
        }
        public ActionResult Index()
        {
            var lstRet = new List<PontoViewModel>();

            lstRet = _ponto.GetAll().ToList();
            lstRet.ForEach(r => {
                r.Matriz = _matriz.GetAll().FirstOrDefault(x => x.OidMatriz == r.OidMatriz);
            });


            return View(lstRet);
        }

        public ActionResult Create()
        {
            CarregarDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PontoViewModel newRegister)
        {
            newRegister.DataCadastro = DateTime.Now;

            var valid = new PontoValid().Validate(newRegister);

            if (valid.IsValid)
            {
                if (string.IsNullOrWhiteSpace(newRegister.NomeMatriz))
                {
                    newRegister.NomeMatriz = _matriz.GetAll().FirstOrDefault(r => r.OidMatriz == newRegister.OidMatriz).NomeMatriz;
                }

                var user = Session["User"] as UsuarioViewModel;
                var retorno = HttpComponent.Post<string>("http://localhost:63214/api/PontoServices/Create", newRegister,  int.MaxValue, user.Token);
                //_ponto.Update(newRegister);
                if (retorno == "OK")
                {
                  
                    var ObjRetorno = new { Message = "sucesso", Erros = "" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var ObjRetorno = new { Message = "false", Erros = "Erro ao cadastrar ponto!" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                //_ponto.Add(newRegister);
                //var ObjRetorno = new { Message = "sucesso", Erros = "" };
                //return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valid.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AlterPonto(int id)
        {
            CarregarDropDown();
            return View(_ponto.GetAll().FirstOrDefault(r => r.OidPonto == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterPonto(PontoViewModel newRegister)
        {
            var valid = new PontoValid().Validate(newRegister);

            if (valid.IsValid)
            {
                if (string.IsNullOrWhiteSpace(newRegister.NomeMatriz))
                {
                    newRegister.NomeMatriz = _matriz.GetAll().FirstOrDefault(r => r.OidMatriz == newRegister.OidMatriz).NomeMatriz;
                }
                var user = Session["User"] as UsuarioViewModel;
                var retorno = HttpComponent.Put<string>("http://localhost:63214/api/PontoServices/Update", newRegister,"PUT", int.MaxValue, user.Token);
                //_ponto.Update(newRegister);
                if (retorno == "OK")
                {

                    var ObjRetorno = new { Message = "sucesso", Erros = "" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var ObjRetorno = new { Message = "false", Erros = "Erro ao cadastrar ponto!" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                //_ponto.Update(newRegister);
                //var ObjRetorno = new { Message = "sucesso", Erros = "" };
                //return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valid.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ReadPonto(int id)
        {
            CarregarDropDown();
            return View(_ponto.GetAll().FirstOrDefault(r => r.OidPonto == id));
        }

        [HttpPost]
        public ActionResult DeletePonto(int id)
        {
            _ponto.Delete(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        private void CarregarDropDown()
        {
            var lstDrop = _matriz.GetAll().ToList().Select(r => new SelectListItem() { Text = string.Format("{0} - {1}", r.OidMatriz, r.NomeMatriz), Value = r.OidMatriz.ToString() }).ToList();
            lstDrop.Add(new SelectListItem() { Text = "Selecione", Value = "", Selected = true });
            ViewBag.Matriz = lstDrop;
        }
    }
}