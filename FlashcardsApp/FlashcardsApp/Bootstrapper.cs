using Autofac;
using FlashcardsApp.Helpers;
using FlashcardsApp.ViewModels;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FlashcardsApp
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; set; }

        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes.Where(e => e.IsSubclassOf(typeof(Page)) || 
                                                                          e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<WebAPIService>().As<IWebAPIService>().InstancePerLifetimeScope();
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();

            Resolver.Initialize(container);
        }
    }
}
