using AutoFixture;
using Moq;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Handlers.Commands;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Tests.Handlers.Commands
{
    public class CreateArmorRequestCommandHandlerSpecs
    {
        private readonly Mock<IArmorWriteRepository> _armorWriteRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        private readonly NotificationContext _notificationContext;
        public CreateArmorRequestCommandHandlerSpecs()
        {
            _armorWriteRepositoryMock = new Mock<IArmorWriteRepository>();
            _cancellationToken = new CancellationToken();
            _notificationContext = new NotificationContext();
        }

        [Fact]
        public async Task Given_A_Valid_Command_Should_Return_Armor()
        {
            var armorMock = new Fixture().Create<Armor>();

            _armorWriteRepositoryMock
                .Setup(x => x.InsertOneAsync(It.IsAny<Armor>()))
                .ReturnsAsync(armorMock);

            var handler = new CreateArmorRequestCommandHandler(_notificationContext, _armorWriteRepositoryMock.Object);
            var armorRequestCommand = new Fixture().Create<CreateArmorRequestCommand>();

            var armorResult = await handler.Handle(armorRequestCommand, _cancellationToken);

            Assert.NotNull(armorResult);

        }

        [Fact]
        public async Task Given_A_Invalid_Command_Should_Have_Notification()
        {           
            var handler = new CreateArmorRequestCommandHandler(_notificationContext, _armorWriteRepositoryMock.Object);

            var armorRequestCommand = new CreateArmorRequestCommand("Armor", "+30", "+20", "url", -1,
                new List<string> {"resist poison" }, 1500, 500, "description", "alternativeDescription",
                new List<string> { "akropolis"}, true);

           await handler.Handle(armorRequestCommand, _cancellationToken);

            Assert.Equal(1, armorRequestCommand.Notifications.Count);
        }
    }
}
