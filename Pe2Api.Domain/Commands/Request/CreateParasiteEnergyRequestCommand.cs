using MediatR;
using Pe2Api.Domain.Commands.Base;
using Pe2Api.Domain.Entities;


namespace Pe2Api.Domain.Commands.Request
{
    public class CreateParasiteEnergyRequestCommand : BaseRequestCommand, IRequest<ParasiteEnergy>
    {

        public string Name { get; set; }
        public int Level { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int MpCost { get; set; }
        public int AtpLoss { get; set; }
        public int ExpCost { get; set; }
        public int BonusMp { get; set; }
        public int Power { get; set; }
        public string Type { get; set; }

        public override void Validate()
        {
            
        }
    }
}
