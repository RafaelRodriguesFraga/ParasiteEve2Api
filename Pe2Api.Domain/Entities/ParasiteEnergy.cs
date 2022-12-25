using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities.Base;


namespace Pe2Api.Domain.Entities
{
    public class ParasiteEnergy : BaseEntity
    {
        public ParasiteEnergy()
        {

        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public string Action { get; private set; }
        public string Description { get; private set; }
        public int MpCost { get; private set; }
        public int AtpLoss { get; private set; }
        public int ExpCost { get; private set; }
        public int BonusMp { get; private set; }
        public int Power { get; private set; }
        public string Type { get; private set; }


        public static implicit operator ParasiteEnergy(CreateParasiteEnergyRequestCommand command)
        {
            return new ParasiteEnergy()
            {
                Name = command.Name,
                Level = command.Level,
                Action = command.Action,
                Description = command.Description,
                MpCost = command.MpCost,
                AtpLoss = command.AtpLoss,
                ExpCost = command.ExpCost,
                BonusMp = command.BonusMp,
                Power = command.Power,
                Type = command.Type
            };
        }

        public override void Validate()
        {

        }
    }
}