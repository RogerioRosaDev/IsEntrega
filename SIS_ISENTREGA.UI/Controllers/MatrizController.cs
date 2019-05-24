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

                var retorno = HttpComponent.Put<string>("http://localhost:63214/api/MatrizServices/Create", newRegister,"PUT", int.MaxValue, user.Token);
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
                //_matriz.Update(newRegister);
                //var ObjRetorno = new { Message = "sucesso", Erros = "" };
                //return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
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

        private void SaveServices(MatrizViewModel newRegister)
        {
            var user = Session["User"] as UsuarioViewModel;
            var client = new HttpClient();
            var token = string.Empty;
            //var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{newRegister.NomeMatriz}:{newRegister.DataCadastro}:{newRegister.CEP} :{newRegister.OidMatriz}");
            client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Authorization", "Bearer "+ user.Token);
            var postMessage = new Dictionary<string, string>();
            postMessage.Add("DataCadastro", newRegister.DataCadastro.ToShortDateString());
            postMessage.Add("NomeMatriz", newRegister.NomeMatriz);
            postMessage.Add("CEP", newRegister.CEP);
            postMessage.Add("OidMatriz", newRegister.OidMatriz.ToString());
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:63214/api/MatrizServices/Create")
            {
                Content = new FormUrlEncodedContent(postMessage)
            };
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                //var rr = JsonConvert.DeserializeObject<Token>(json);
                //token = rr.access_token;
                //this.token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
            }
            
        }

    }
}