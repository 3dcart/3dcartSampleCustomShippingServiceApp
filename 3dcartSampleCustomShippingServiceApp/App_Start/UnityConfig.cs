using _3dcartSampleCustomShippingServiceApp.Interfaces;
using _3dcartSampleCustomShippingServiceApp.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace _3dcartSampleCustomShippingServiceApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHttpContextService, HttpContextService>();
            container.RegisterType<IRatesService, RatesService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}