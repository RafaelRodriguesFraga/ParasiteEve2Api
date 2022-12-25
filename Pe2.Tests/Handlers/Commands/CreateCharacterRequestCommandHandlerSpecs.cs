using AutoFixture;
using Moq;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Handlers.Commands;
using Pe2Api.Domain.Repositories;
using Pe2Api.Domain.Notifications;

namespace Pe2.Tests.Handlers.Command
{
    public class CreateCharacterRequestCommandHandlerSpecs
    {
        private readonly Mock<ICharacterWriteRepository> _characterWriteRepositoryMock;
        private readonly CancellationToken _cancellationToken;
        private readonly NotificationContext _notificationContext;

        public CreateCharacterRequestCommandHandlerSpecs()
        {
            _characterWriteRepositoryMock = new Mock<ICharacterWriteRepository>();
            _cancellationToken = new CancellationToken();
            _notificationContext = new NotificationContext();
        }

        [Fact]
        public async Task Given_A_Valid_Command_Should_Return_Character()
        {
            var characterMock = new Fixture().Create<Character>();

            _characterWriteRepositoryMock.
                Setup(x => x.InsertOneAsync(It.IsAny<Character>()))
               .ReturnsAsync(characterMock);

            var handler = new CreateCharacterRequestCommandHandler(_notificationContext, _characterWriteRepositoryMock.Object);
            var characterRequestCommand = new Fixture().Create<CreateCharacterRequestCommand>();

            var characterResult = await handler.Handle(characterRequestCommand, _cancellationToken);

            Assert.NotNull(characterResult);
        }

        [Fact]
        public async Task Given_A_Invalid_Command_Should_Have_Notification()
        {
            var handler = new CreateCharacterRequestCommandHandler(_notificationContext, _characterWriteRepositoryMock.Object);

            var characterRequestCommand = new CreateCharacterRequestCommand("Char 1", -1, "url", "blue", "brown", "occupation");

            await handler.Handle(characterRequestCommand, _cancellationToken);

            Assert.Equal(1, characterRequestCommand.Notifications.Count);
        }
    }
}

