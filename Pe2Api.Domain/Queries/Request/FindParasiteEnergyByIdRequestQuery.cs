using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindParasiteEnergyByIdRequestQuery : IRequest<ParasiteEnergy>
    {
        public FindParasiteEnergyByIdRequestQuery()
        {

        }

        public FindParasiteEnergyByIdRequestQuery(Guid id)
        {
            Id = id;
        }   
        [FromRoute(Name = "id")] 
        public Guid Id { get; set; }
    }
}
