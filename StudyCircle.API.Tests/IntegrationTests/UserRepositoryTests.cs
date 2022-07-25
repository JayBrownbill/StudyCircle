using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyCircle.API.DataAccess;
using StudyCircle.API.Models;
using StudyCircle.API.Repository;
using StudyCircle.API.ServiceCollections;
using StudyCircle.API.Tests.Config;

namespace StudyCircle.API.Tests.IntegrationTests;

public class UserRepositoryTests
{
    private readonly IUserRepository _userRepository;
    private readonly IStudyTopicRepository _subjectRepository;
    private StudyContext _context;
    public UserRepositoryTests()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddRepoServiceCollection();

        var connString = TestConfiguration.GetConnectionString();
        var builder = new DbContextOptionsBuilder<StudyContext>();
        builder.UseSqlServer(connString);

        _context = new StudyContext(builder.Options);
        _userRepository = new UserRepository(_context);
        _subjectRepository = new StudyTopicRepository(_context);
    }


    [Fact]
    public async Task Create_New_User_Success()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        // Arrange
        Fixture fixture = new Fixture();

        var userModels = fixture.Build<User>()
            .Without(u => u.Subjects)
            .CreateMany().ToList();

        foreach (User user in userModels)
        {
            await _userRepository.CreateUserAsync(user);
        }

        var act = _userRepository.GetAllUsers()
            .Where(u => u != null && userModels
                .Select(x => x.UserId)
                .Contains(u.UserId))
            .ToList();
        
        act.Should().HaveCount(3);
        act.Should().AllBeAssignableTo(typeof(User));
        act.Should().BeEquivalentTo(userModels);

        await transaction.RollbackAsync();
    }

    [Fact]
    public async Task Delete_User_Success()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        // Init fixture
        Fixture fixture = new Fixture();

        // Arrange
        Guid userID = fixture.Create<Guid>();

        // Create user with multiple subjects
        User user = fixture.Build<User>()
            .With<Guid>(u => u.UserId, userID)
            .Without(u => u.Subjects)
            .Do(u =>
            {
                u.Subjects = fixture.Build<StudyTopic>()
                    .Without(s => s.UserAccount)
                    .With<Guid>(u => u.UserId, userID)
                    .CreateMany()
                    .ToList();
            }).Create();

        // Add user then check user exists
        await _userRepository.CreateUserAsync(user);
        if (user.Subjects.Any()) await _subjectRepository.AddTopics(user.Subjects);

        User? createdUserRecord = await _userRepository.GetUserByIdAsync(userID);
        IReadOnlyCollection<StudyTopic> userSubjects = await _subjectRepository.GetAllTopicsByUserId(userID);

        createdUserRecord.Should().NotBeNull();
        userSubjects.Should().HaveCount(3);
        userSubjects.Should().NotBeEmpty();

        // Delete user then check user has been deleted
        var act = await _userRepository.DeleteUserByIdAsync(userID);

        // Actual
        act.Should().Be(2);

        await transaction.RollbackAsync();
    }
}