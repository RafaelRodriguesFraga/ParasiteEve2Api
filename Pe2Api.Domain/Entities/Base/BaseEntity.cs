using FluentValidation.Results;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Pe2Api.Domain.Notifications;

namespace Pe2Api.Domain.Entities.Base
{
    public abstract class BaseEntity : Notifiable<Notification>, IBaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        
       [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id  {get;set;}
        public DateTime CreatedAt {get;set;}

        public abstract void Validate();

        public void AddNotifications(ValidationResult validationResult)
        {
            var invalidValidation = !validationResult.IsValid;
            if(invalidValidation)
            {
                foreach(var failure in validationResult.Errors)
                {
                    AddNotification(failure.PropertyName, failure.ErrorMessage);
                }
            }
            
        }
    }
}
