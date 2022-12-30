using MongoDB.Bson;
using Moq;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Handlers.Queries;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Tests.Handlers.Queries
{
    public class FindCharacterByIdRequestQueryHandlerSpecs
    {
        private readonly Mock<ICharacterReadRepository> _characterReadRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        private readonly NotificationContext _notificationContext;

        public FindCharacterByIdRequestQueryHandlerSpecs()
        {
            _characterReadRepositoryMock = new Mock<ICharacterReadRepository>();
            _cancellationToken = new CancellationToken();
            _notificationContext = new NotificationContext();
        }

        [Fact]
        public async Task Given_A_Valid_Query_Should_Find_One_Character_By_Id()
        {
            _characterReadRepositoryMock
                .Setup(x => x.FindByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<Character>());

            var query = new FindCharacterByIdRequestQuery(It.IsAny<Guid>());
            
            var handler = new FindCharacterByIdRequestQueryHandler(_notificationContext, _characterReadRepositoryMock.Object);
            var result = handler.Handle(query, _cancellationToken);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Given_A_Invalid_Id_In_Query_Should_Return_Null()
        {
            
            var query = new FindCharacterByIdRequestQuery(Guid.Empty);

            var handler = new FindCharacterByIdRequestQueryHandler(_notificationContext, _characterReadRepositoryMock.Object);
            var result = await handler.Handle(query, _cancellationToken);

            Assert.Null(result);
        }
    }
}
