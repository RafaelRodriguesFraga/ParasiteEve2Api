using FluentValidation.Results;
using Pe2Api.Domain.Notifications;

namespace Pe2Api.Domain.Commands.Base
{
    public abstract class BaseRequestCommand : Notifiable<Notification>
    {
        public abstract void Validate();
        public void AddNotifications(ValidationResult validationResult)
        {
            var invalidValidationResult = !validationResult.IsValid;
            if (invalidValidationResult)
            {
                foreach (var failure in validationResult.Errors)
                {
                    AddNotification(failure.PropertyName, failure.ErrorMessage);
                }
            }
        }
    }
}
