using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Entidad.Dto.Seguridad;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Negocio.Seguridad;

namespace Api
{
    public class MyAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly LnUsuario _lnLogin = new LnUsuario();
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var usuario = await Task.FromResult(_lnLogin.Login(context.UserName, context.Password));

            if (usuario == null)
            {
                context.SetError("invalid_grant", "El nombre de usuario o la contraseña no son correctos.");
                return;
            }

            if (usuario.ListaRolUsuario == null)
            {
                context.SetError("invalid_grant", "El usuario no tiene roles asignados");
                return;
            }

            //var claim = JsonConvert.SerializeObject(new LoginClaim
            //{
            //    IdUsuario = usuario.IdUsuario
            //});

            //identity.AddClaim(new Claim(@"claim", claim));
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nombre));
            identity.AddClaim(new Claim("username", usuario.UserName));
            identity.AddClaim(new Claim("apellido", usuario.ApellidoPaterno));
            //identity.AddClaim(new Claim("idusuario", usuario.IdUsuario.ToString()));

            foreach (RolUsuarioDto rolUsu in usuario.ListaRolUsuario)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, rolUsu.NombreRol));
            }

            string isLogin = "false";
            if (!String.IsNullOrEmpty(usuario.UserName))
            {
                isLogin = "true";
            }

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"isLogin", isLogin},
                {"user", usuario.UserName},
                {"idUsuario", usuario.IdUsuario.ToString()}
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        /// <summary>
        /// Called at the final stage of a successful Token endpoint request. An application may implement this call in order to do any final 
        ///             modification of the claims being used to issue access or refresh tokens. This call may also be used in order to add additional 
        ///             response parameters to the Token endpoint's json response body.
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>
        /// Task to enable asynchronous execution
        /// </returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                switch (property.Key)
                {
                    case @".expires":
                        var fecha = Convert.ToDateTime(context.Properties.ExpiresUtc?.LocalDateTime.ToString(CultureInfo.CurrentCulture));
                        context.AdditionalResponseParameters.Add(@"expires", $"{fecha.Date:yyyyMMdd}|{fecha:HHmmss}");
                        break;

                    case @".issued":
                        break;

                    default:
                        context.AdditionalResponseParameters.Add(property.Key, property.Value);
                        break;
                }
            return Task.FromResult<object>(null);
        }
    }
}