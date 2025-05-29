using AccountValidation.Plugins.Infrastructure;

namespace AccountValidation.Plugins.Handlers
{
    public interface IPluginHandler
    {
        void Execute(IExecutionContextFacade context);
    }
}
