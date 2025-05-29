using AccountValidation.Plugins.Handlers;
using Autofac;

namespace AccountValidation.Plugins.Infrastructure
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainPhoneValidationHandler>().AsSelf();

            return builder.Build();
        }
    }
}
