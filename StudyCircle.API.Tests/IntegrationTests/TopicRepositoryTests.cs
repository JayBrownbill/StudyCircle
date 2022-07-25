using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyCircle.API.DataAccess;
using StudyCircle.API.Models;
using StudyCircle.API.Repository;
using StudyCircle.API.ServiceCollections;
using StudyCircle.API.Tests.Config;
using StudyCircle.API.Tests.Helpers;

namespace StudyCircle.API.Tests.IntegrationTests
{
    public class TopicRepositoryTests
    {
        private readonly IStudyTopicRepository _subjectRepository;
        private readonly IUserRepository _userRepository;
        private readonly StudyContext _context;
        private readonly Fixture _fixture;

        public TopicRepositoryTests()
        {
            string connString = TestConfiguration.GetConnectionString();
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddRepoServiceCollection();

            _fixture = new Fixture();

            var builder = new DbContextOptionsBuilder<StudyContext>();
            builder.UseSqlServer(connString);
            _context = new StudyContext(builder.Options);
            _userRepository = new UserRepository(_context);
            _subjectRepository = new StudyTopicRepository(_context);
        }

        [Fact]
        public async Task GetTopicById_Successful()
        {
            Guid topicId = Guid.NewGuid();

            StudyTopic subject = _fixture
                .Build<StudyTopic>()
                .Without(s => s.UserAccount)
                .With(s => s.StudyTopicId, topicId)
                .Create();

            StudyTopic act = await _subjectRepository.AddTopic(subject);
            act.StudyTopicId.Should().Be(topicId);
        }
    }
}
