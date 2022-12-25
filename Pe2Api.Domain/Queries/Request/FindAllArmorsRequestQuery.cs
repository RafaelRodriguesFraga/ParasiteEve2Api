﻿using MediatR;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindAllArmorsRequestQuery : IRequest<IEnumerable<Armor>>
    {
    }
}
