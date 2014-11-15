[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AffiliateNetwork.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AffiliateNetwork.Web.App_Start.NinjectWebCommon), "Stop")]

namespace AffiliateNetwork.Web.App_Start
{
    using System;
    using System.Web;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Data;
    using AffiliateNetwork.Data.UnitOfWork;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

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

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataProvider>()
                    .To<DataProvider>()
                    .WithConstructorArgument("context", c => new AffiliateNetworkDbContext());
        }        
    }
}
