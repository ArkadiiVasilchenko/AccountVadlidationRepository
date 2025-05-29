using AccountValidation.Plugins.EarlyBoundEntities;
using Microsoft.Xrm.Sdk;
using System;

namespace AccountValidation.Plugins.Infrastructure
{
    public interface IExecutionContextFacade
    {
        Account Target { get; }
        Account PreImage { get; }
        IOrganizationService Service { get; }
        ITracingService Tracing { get; }
    }
}
