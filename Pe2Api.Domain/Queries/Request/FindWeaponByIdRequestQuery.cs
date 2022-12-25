using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindWeaponByIdRequestQuery : IRequest<Weapon>
    {
        public FindWeaponByIdRequestQuery()
        {

        }
        public FindWeaponByIdRequestQuery(Guid id)
        {
            Id = id;
        }
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

       
    }
}
