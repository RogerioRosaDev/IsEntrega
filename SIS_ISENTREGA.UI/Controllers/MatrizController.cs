using Newtonsoft.Json;
using SIS_ISENTREGA.Application;
using SIS_ISENTREGA.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SIS_ISENTREGA.UI.Controllers
{
    [Authorize]
    public class MatrizController : Controller
    {
        private readonly IMatrizApplication _matriz;
        public MatrizController(IMatrizApplication matriz)
        {
            _matriz = matriz;
        }
        public ActionResult Index()
        {
            var lstRet = new List<MatrizViewModel>();
            lstRet = _matriz.GetAll().ToList();
            return View(lstRet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatrizViewModel newRegister)
        {
            var user = Session["User"] as UsuarioViewModel;
            var valid = new MatrizValid().Validate(newRegister);
            if (valid.IsValid)
            {

                var retorno = HttpComponent.Post<string>("http://localhost:63214/api/MatrizServices/Create", newRegister, int.MaxValue, user.Token);
                if(retorno == "OK")
                {
                    var ObjRetorno = new { Message = "sucesso", Erros = "" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                else {
                    var ObjRetorno = new { Message = "false", Erros = "Erro ao cadastrar a matriz!" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                
                //newRegister.DataCadastro = DateTime.Now;
                //_matriz.Add(newRegister);
                // SaveServices(newRegister);
               
             
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valid.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
           
            //
            
        }
        [HttpGet]
        public ActionResult AlterMatriz(int id)
        {
            var matriz = _matriz.GetAll().FirstOrDefault(r => r.OidMatriz == id);
            return View(matriz);
        }
        [HttpGet]
        public ActionResult ReadMatriz(int id)
        {
            var matriz = _matriz.GetAll().FirstOrDefault(r => r.OidMatriz == id);
            return View(matriz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MatrizViewModel newRegister)
        {
            var user = Session["User"] as UsuarioViewModel;
            var valid = new MatrizValid().Validate(newRegister);

            if (valid.IsValid)
            {

                var retorno = HttpComponent.Put<string>("http://localhost:63214/api/MatrizServices/Update", newRegister,"PUT", int.MaxValue, user.Token);
                if (retorno == "OK")
                {
                    var ObjRetorno = new { Message = "sucesso", Erros = "" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var ObjRetorno = new { Message = "false", Erros = "Erro ao cadastrar a matriz!" };
                    return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valid.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult DeletarMatriz(int id)
        {
            _matriz.DeletarCascate(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}