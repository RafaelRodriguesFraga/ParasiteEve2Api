using AutoFixture;
using Moq;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;
using Pe2Api.Domain.Handlers.Queries;
using Pe2Api.Domain.Queries.Request;

namespace Pe2.Tests.Handlers.Queries
{
    public class FindAllCharactersRequestQueryHandlerSpecs
    {
        private readonly Mock<ICharacterReadRepository> _characterReadRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        public FindAllCharactersRequestQueryHandlerSpecs()
        {
            _characterReadRepositoryMock = new Mock<ICharacterReadRepository>();
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Given_A_Valid_Query_Should_Find_All_Characters()
        {
            var characterMock = new Fixture().Create<Character>();

            _characterReadRepositoryMock
                .Setup(x => x.FindAllAsync())
                .ReturnsAsync(new List<Character> { characterMock });

            var query = new FindAllCharactersRequestQuery();
            var handler = new FindAllCharactersRequestQueryHandler(_characterReadRepositoryMock.Object);
            
            var result = handler.Handle(query, _cancellationToken);

            Assert.NotNull(result);
        }
    }
}
