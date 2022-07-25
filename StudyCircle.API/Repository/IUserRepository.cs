using Microsoft.IdentityModel.Protocols;
using StudyCircle.API.Models;

namespace StudyCircle.API.Repository
{
    public interface IUserRepository
    {
        // Create new user account
        Task<int> CreateUserAsync(User user);

        // Update user account details
        Task<User> UpdateUserAsync(User user);

        // Retrieve user
        Task<User?> GetUserByIdAsync(Guid id);

        IReadOnlyCollection<User?> GetAllUsers();

        // Delete user account
        Task<int> DeleteUserByIdAsync(Guid id);

    }
}
