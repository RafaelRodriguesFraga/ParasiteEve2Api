using MediatR;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Queries.Response;
using Pe2Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindParasiteEnergyByTypeRequestQueryHandler : IRequestHandler<FindParasiteEnergyByTypeRequestQuery, ParasiteEnergySeparatedByType>
    {
        private readonly IParasiteEnergyReadRepository _parasiteEnergyReadRepository;

        public FindParasiteEnergyByTypeRequestQueryHandler(IParasiteEnergyReadRepository parasiteEnergyReadRepository)
        {
            _parasiteEnergyReadRepository = parasiteEnergyReadRepository;
        }

        public async Task<ParasiteEnergySeparatedByType> Handle(FindParasiteEnergyByTypeRequestQuery request, CancellationToken cancellationToken)
        {
            var parasiteEnergies = await _parasiteEnergyReadRepository.FindAllAsync();

            List<Fire> fireList = new List<Fire>();
            List<Water> waterList = new List<Water>();
            List<Wind> windList = new List<Wind>();
            List<Earth> earthList = new List<Earth>();

            foreach (var parasiteEnergy in parasiteEnergies)
            {
                var type = parasiteEnergy.Type;
                switch (type)
                {
                    case "Fire":
                        Fire fire = new Fire()
                        {
                            Name = parasiteEnergy.Name,
                            Level = parasiteEnergy.Level,
                            Action = parasiteEnergy.Action,
                            Description = parasiteEnergy.Description,
                            MpCost = parasiteEnergy.MpCost,
                            AtpLoss = parasiteEnergy.AtpLoss,
                            ExpCost = parasiteEnergy.ExpCost,
                            BonusMp = parasiteEnergy.BonusMp,
                            Power = parasiteEnergy.Power,

                        };

                        fireList.Add(fire);

                        break;

                    case "Water":
                        Water water = new Water()
                        {
                            Name = parasiteEnergy.Name,
                            Level = parasiteEnergy.Level,
                            Action = parasiteEnergy.Action,
                            Description = parasiteEnergy.Description,
                            MpCost = parasiteEnergy.MpCost,
                            AtpLoss = parasiteEnergy.AtpLoss,
                            ExpCost = parasiteEnergy.ExpCost,
                            BonusMp = parasiteEnergy.BonusMp,
                            Power = parasiteEnergy.Power,

                        };

                        waterList.Add(water);
                        break;

                    case "Wind":
                        Wind wind = new Wind()
                        {
                            Name = parasiteEnergy.Name,
                            Level = parasiteEnergy.Level,
                            Action = parasiteEnergy.Action,
                            Description = parasiteEnergy.Description,
                            MpCost = parasiteEnergy.MpCost,
                            AtpLoss = parasiteEnergy.AtpLoss,
                            ExpCost = parasiteEnergy.ExpCost,
                            BonusMp = parasiteEnergy.BonusMp,
                            Power = parasiteEnergy.Power,

                        };

                        windList.Add(wind);
                        break;

                    case "Earth":
                        Earth earth = new Earth()
                        {
                            Name = parasiteEnergy.Name,
                            Level = parasiteEnergy.Level,
                            Action = parasiteEnergy.Action,
                            Description = parasiteEnergy.Description,
                            MpCost = parasiteEnergy.MpCost,
                            AtpLoss = parasiteEnergy.AtpLoss,
                            ExpCost = parasiteEnergy.ExpCost,
                            BonusMp = parasiteEnergy.BonusMp,
                            Power = parasiteEnergy.Power,

                        };

                        earthList.Add(earth);
                        break;
                }
            }

            return new ParasiteEnergySeparatedByType(fireList, waterList, windList, earthList);
        }
    }

}
