using AccountValidation.Plugins.Handlers;
using AccountValidation.Plugins.Infrastructure;
using Microsoft.Xrm.Sdk;
using System;

namespace AccountValidation.Plugins.Plugins.Account
{
    public class MainPhoneValidationPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            PluginExecutor.Execute<MainPhoneValidationHandler>(serviceProvider);
        }
    }
}
