[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using MidiaSocialEmpresa.Aplicacao.Interface;
    using MidiaSocialEmpresa.Aplicacao;
    using MidiaSocialEmpresa.Dominio.Interfaces.Servicos;
    using MidiaSocialEmpresa.Dominio.Servicos;
    using MidiaSocialEmpresa.Dominio.Interfaces.Repositorios;
    using MidiaSocialEmpresa.Infra.Data.Repositorios;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
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
    }
}
