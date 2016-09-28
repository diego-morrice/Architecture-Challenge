using System;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using GoProjects.Aplicacao.Interface;
using GoProjects.Aplicacao;
using GoProjects.Dominio.Servicos;
using GoProjects.Infra.Data.Repositorios;
using GoProjects.API;
using GoProjects.Dominio.Interfaces.Servicos;
using GoProjects.Dominio.Interfaces.Repositorios;

namespace GoProjects.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            ConfigureOAuth(app);

            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var formatters = config.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());

            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind(typeof(IAplicacaoServicoBase<>)).To(typeof(AplicacaoServicoBase<>));
            kernel.Bind<IAplicacaoServicoAtividade>().To<AplicacaoServicoAtividade>();
            kernel.Bind<IAplicacaoServicoEmpresa>().To<AplicacaoServicoEmpresa>();
            kernel.Bind<IAplicacaoServicoProfissional>().To<AplicacaoServicoProfissional>();
            kernel.Bind<IAplicacaoServicoUsuario>().To<AplicacaoServicoUsuario>();
            kernel.Bind<IAplicacaoServicoProjeto>().To<AplicacaoServicoProjeto>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IServicoAtividade>().To<ServicoAtividade>();
            kernel.Bind<IServicoEmpresa>().To<ServicoEmpresa>();
            kernel.Bind<IServicoUsuario>().To<ServicoUsuario>();
            kernel.Bind<IServicoProjeto>().To<ServicoProjeto>();
            kernel.Bind<IServicoProfissional>().To<ServicoProfissional>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IRepositorioAtividade>().To<RepositorioAtividade>();
            kernel.Bind<IRepositorioEmpresa>().To<RepositorioEmpresa>();
            kernel.Bind<IRepositorioUsuario>().To<RepositorioUsuario>();
            kernel.Bind<IRepositorioProjeto>().To<RepositorioProjeto>();
            kernel.Bind<IRepositorioProfissional>().To<RepositorioProfissional>();

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new Autorizador(new ServicoUsuario(new RepositorioUsuario()))
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}