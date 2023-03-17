namespace IvaBlog.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IvaBlog.Data.Common.Repositories;
    using IvaBlog.Data.Models;

    using Moq;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenUserVotes2TimesOnly1ShouldBeCounted()
        {
            // Arrange
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback(
                (Vote vote) => list.Add(vote));

            // Act
            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 2);
            await service.SetVoteAsync(1, "1", 3);
            await service.SetVoteAsync(1, "1", 4);
            await service.SetVoteAsync(1, "1", 5);

            // Assert
            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task When2UsersVoteForTheSameRecipeTheAvarageVoteShouldBeCorrect()
        {
            // Arrange
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback(
                (Vote vote) => list.Add(vote));

            // Act
            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(2, "Niki", 5);
            await service.SetVoteAsync(2, "Pesho", 1);
            await service.SetVoteAsync(2, "Niki", 2);


            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal(1.5, service.GetAverageVotes(2));
        }
    }
}
