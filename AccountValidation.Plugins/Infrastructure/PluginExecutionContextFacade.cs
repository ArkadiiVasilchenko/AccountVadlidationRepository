using AccountValidation.Plugins.EarlyBoundEntities;
using Microsoft.Xrm.Sdk;
using System;

namespace AccountValidation.Plugins.Infrastructure
{
    public class PluginExecutionContextFacade : IExecutionContextFacade
    {
        public Account Target { get; }
        public Account PreImage { get; }
        public IOrganizationService Service { get; }
        public ITracingService Tracing { get; }

        public PluginExecutionContextFacade(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

            Service = factory.CreateOrganizationService(context.UserId);
            Tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            if (context.InputParameters.TryGetValue("Target", out var target) && target is Entity targetEntity)
            {
                Target = targetEntity.ToEntity<Account>();
            }

            if (context.PreEntityImages.TryGetValue("preImage", out var preImageEntity))
            {
                PreImage = preImageEntity.ToEntity<Account>();
            }
        }
    }
}
