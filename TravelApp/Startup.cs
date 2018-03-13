using System.Web.Http;
using TravelApp;
using TravelApp.App_Start;
using Microsoft.Owin;
using Unity;
using Owin;
using TravelApp.DAL.Context;
using TravelApp.DAL.Models;
using Unity.AspNet.WebApi;

[assembly: OwinStartup(typeof(TravelApp.Startup))]

namespace TravelApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            //using (TravelContext context = new TravelContext())
            //{
            //    Administrator administrator = new Administrator();
            //    context.Administrators.Add(administrator);
            //    context.SaveChanges();
            //}

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.Container);
            app.UseWebApi(config);
        }
    }
}
