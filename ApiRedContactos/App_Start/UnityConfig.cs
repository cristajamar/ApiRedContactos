using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using ApiRedContactos.Models;
using ApiRedContactos.Reporsitorios;
using Unity.WebApi;

namespace ApiRedContactos
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<DbContext, RedContactosEntities>();
            container.RegisterType<UsuarioRepositorio>();
            container.RegisterType<MensajeRepositorio>();
            container.RegisterType<ContactoRepositorio>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}