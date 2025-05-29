using AccountValidation.Plugins.Handlers;
using Autofac;
using Microsoft.Xrm.Sdk;
using System;

namespace AccountValidation.Plugins.Infrastructure
{
    public static class PluginExecutor
    {
        public static void Execute<THandler>(IServiceProvider serviceProvider) where THandler : IPluginHandler
        {
            PluginExecutionContextFacade context = null;

            try
            {
                var container = AutofacConfig.Configure();
                context = new PluginExecutionContextFacade(serviceProvider);

                using (var scope = container.BeginLifetimeScope())
                {
                    var handler = scope.Resolve<THandler>();

                    context?.Tracing?.Trace($"[PluginExecutor] Running handler: {typeof(THandler).Name}");
                    handler.Execute(context);
                }
            }
            catch (Exception ex)
            {
                context?.Tracing?.Trace($"[PluginExecutor] Exception: {ex.Message}");
                throw new InvalidPluginExecutionException("An unexpected error occurred while executing the plugin. Please contact the system administrator.", ex);
            }
        }
    }
}