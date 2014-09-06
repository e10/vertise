using System.Data.Entity;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Owin;
using System.Web.Http;
using Vertise.Core.Data;
using Vertise.Repositories;
using Autofac.Integration.WebApi;
using System.Reflection;
using AutoMapper;
using Vertise.ViewModels;

namespace Vertise
{
    public partial class Startup
    {
        public static void ConfigureIoC(IAppBuilder app)
        {
            AutoMaps();
            var container = RegisterServices();
            app.UseAutofacMiddleware(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void AutoMaps()
        {
            Mapper.CreateMap<Message, MessageViewModel>();
            Mapper.CreateMap<Message, MessageResult>().ForMember(dto => dto.Replies, conf => conf.MapFrom(ol => ol.Replies));
        }

        public static IContainer RegisterServices() {

            var builder = new ContainerBuilder();

            //data context
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();

            //repositories
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MediaRepository>().As<IMediaRepository>().InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}