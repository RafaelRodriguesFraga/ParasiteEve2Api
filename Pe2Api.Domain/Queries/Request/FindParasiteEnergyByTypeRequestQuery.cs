using MediatR;
using Pe2Api.Domain.Queries.Response;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindParasiteEnergyByTypeRequestQuery : IRequest<ParasiteEnergySeparatedByType>
    {
    }
}
