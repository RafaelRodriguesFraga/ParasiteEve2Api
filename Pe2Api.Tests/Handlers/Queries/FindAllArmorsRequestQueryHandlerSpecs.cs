using AutoFixture;
using Moq;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Handlers.Queries;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2.Tests.Handlers.Queries
{
    public class FindAllArmorsRequestQueryHandlerSpecs
    {
        private readonly Mock<IArmorReadRepository> _armorReadRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        public FindAllArmorsRequestQueryHandlerSpecs()
        {
            _armorReadRepositoryMock = new Mock<IArmorReadRepository>();
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Given_A_Valid_Query_Should_Find_All_Armors()
        {
            var armorMock = new Fixture().Create<Armor>();

            _armorReadRepositoryMock
                .Setup(x => x.FindAllAsync())
                .ReturnsAsync(new List<Armor> { armorMock });

            var query = new FindAllArmorsRequestQuery();
            var handler = new FindAllArmorsRequestQueryHandler(_armorReadRepositoryMock.Object);

            var result = await handler.Handle(query, _cancellationToken);

            Assert.NotNull(result);       
        }
    }
}
