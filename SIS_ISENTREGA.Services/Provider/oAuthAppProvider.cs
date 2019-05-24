using Microsoft.Owin.Security.OAuth;
using Ninject;
using SIS_ISENTREGA.Application;
using SIS_ISENTREGA.IOC;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Security;

namespace SIS_ISENTREGA.Services.Provider
{
    public class oAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                var kernel = RegisterServices();
                var _user = kernel.Get<UsuarioApplication>();
               var senha= FormsAuthentication.HashPasswordForStoringInConfigFile(context.Password, "MD5");
                var user = _user.FindLogin(context.UserName, senha);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.NomeUsuario),
                        new Claim("UserID",user.OidUsuario.ToString())
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.oAuthOptions.AuthenticationType);
                    context.Validated(new Microsoft.Owin.Security.AuthenticationTicket(oAutIdentity, new Microsoft.Owin.Security.AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Usuário ou senha invalida");
                }
            });


            // return base.GrantResourceOwnerCredentials(context);
        }


        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<Object>(null);
        }
        private static StandardKernel RegisterServices()
        {

            return new Container().GetModules();
        }
    }
}