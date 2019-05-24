using Newtonsoft.Json;
using SIS_ISENTREGA.Application;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Security;

namespace SIS_ISENTREGA.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly IUsuarioApplication _usuario;

        public AccountController(IUsuarioApplication usuario)
        {
            _usuario = usuario;

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel newRegister)
        {

            var valdiade = new UsuarioValid().Validate(newRegister);
            if (valdiade.Errors != null && valdiade.Errors.Count == 2 && valdiade.Errors[0].PropertyName == "Login" && valdiade.Errors[1].PropertyName == "SenhaLogin")
            {
                var senhaToken = newRegister.Senha;

                newRegister.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile(newRegister.Senha, "MD5");
                newRegister.DataCadastro = DateTime.Now;
                newRegister.FlAtivo = true;
                var objRet = _usuario.AddReturnEntity(newRegister);
                FormsAuthentication.SetAuthCookie(objRet.Email, false);
                var ObjRetorno = new { Message = "sucesso", Erros = "" };
                objRet.Token = GetTokenAsync(objRet.Email, senhaToken);
                Session.Add("User", objRet);
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valdiade.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel user)
        {
            var isvalid = true;
            var valid = new UsuarioValid().Validate(user);
            foreach (var item in valid.Errors)
            {
                if (item.PropertyName == "Login" || item.PropertyName == "SenhaLogin")
                {
                    isvalid = false;
                }
            }
            if (isvalid)
            {
                var senhaToken = user.SenhaLogin;
                var senha = FormsAuthentication.HashPasswordForStoringInConfigFile(user.SenhaLogin, "MD5");
                user = _usuario.FindLogin(user.Login, senha);
                if (user == null)
                {

                    var ObjRe = new { Message = "usuario_not", Error = "" };
                    return Json(ObjRe, JsonRequestBehavior.AllowGet);
                }

                user.Token = GetTokenAsync(user.Email, senhaToken);

                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session.Add("User", user);
                var ObjRetorno = new { Message = "sucesso", Erros = "" };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var ObjRetorno = new { Message = "false", Erros = valid.Errors };
                return Json(ObjRetorno, JsonRequestBehavior.AllowGet);
            }




        }
        private string GetTokenAsync(string user, string senha)
        {
            var client = new HttpClient();
            var token = string.Empty;
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{user}:{senha}");
            client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "password");
            postMessage.Add("username", user);
            postMessage.Add("password", senha);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:63214/token")
            {
                Content = new FormUrlEncodedContent(postMessage)
            };
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var rr = JsonConvert.DeserializeObject<Token>(json);
                token = rr.access_token;
                //this.token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
            }
            return token;
        }
    }

}