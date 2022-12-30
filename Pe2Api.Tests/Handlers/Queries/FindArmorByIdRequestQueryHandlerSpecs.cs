using MongoDB.Bson;
using Moq;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Handlers.Queries;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Tests.Handlers.Queries
{
    public class FindArmorByIdRequestQueryHandlerSpecs
    {
        private readonly Mock<IArmorReadRepository> _armorReadRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        private readonly NotificationContext _notificationContext;
        private const string ARMOR_NOT_FOUND = "Armor not found";
        public FindArmorByIdRequestQueryHandlerSpecs()
        {
            _armorReadRepositoryMock = new Mock<IArmorReadRepository>();
            _notificationContext = new NotificationContext();
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Given_A_Valid_Query_Should_Find_One_Armor_By_Id()
        {
            _armorReadRepositoryMock
                .Setup(x => x.FindByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<Armor>());

            var query = new FindArmorByIdRequestQuery(It.IsAny<Guid>());

            var handler = new FindArmorByIdRequestQueryHandler(_notificationContext, _armorReadRepositoryMock.Object);

            var result = await handler.Handle(query, _cancellationToken);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Given_A_Invalid_Id_In_Query_Should_Return_Null()
        {

            var query = new FindArmorByIdRequestQuery(Guid.Empty);

            var handler = new FindArmorByIdRequestQueryHandler(_notificationContext, _armorReadRepositoryMock.Object);
            var result = await handler.Handle(query, _cancellationToken);

            var errorMessage = _notificationContext.Notifications.Select(x => x.Message).FirstOrDefault();

            Assert.Equal(ARMOR_NOT_FOUND, errorMessage);

        }
    }
}
