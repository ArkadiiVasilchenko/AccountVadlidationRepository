using AccountValidation.Plugins.Infrastructure;
using System;

namespace AccountValidation.Plugins.Handlers
{
    public class MainPhoneValidationHandler : IPluginHandler
    {
        public void Execute(IExecutionContextFacade context)
        {
            var oldPhone = context.PreImage?.Telephone1;
            var newPhone = string.IsNullOrWhiteSpace(context.Target.Telephone1)
                ? oldPhone
                : context.Target.Telephone1;

            bool newIsValidated = !string.IsNullOrWhiteSpace(newPhone);

            if (!string.Equals(newPhone, oldPhone, StringComparison.Ordinal) || string.IsNullOrWhiteSpace(oldPhone))
            {
                context.Target.ark_IsValidated = newIsValidated;
                context.Tracing.Trace($"[MainPhoneValidationHandler] Phone validation status updated. Valid: {newIsValidated}");
            }
            else
            {
                context.Tracing.Trace("[MainPhoneValidationHandler] Phone validation status is not updated, as Main Phone has not changed.");
            }
        }
    }
}