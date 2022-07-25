using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using StudyCircle.API.DataAccess;
using StudyCircle.API.Models;

namespace StudyCircle.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly StudyContext _context;

    public UserRepository(StudyContext context)
    {
        _context = context;
    }
    public async Task<int> CreateUserAsync(User user)
    {
        if (CheckIfUserExistsAsync(user.UserId))
        {
            return 0;
        }

        try
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException exception)
        {
            return exception.HResult;
        }

    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.UserId);

        if (existingUser != null)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        else
        {
            return existingUser ?? new User();
        }
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
    }

    public async Task<int> DeleteUserByIdAsync(Guid id)
    {
        var user = await GetUserByIdAsync(id);
        if (user != null)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return -1;
            }
        }
        return 2;
    }

    public IReadOnlyCollection<User?> GetAllUsers()
    {
        return _context.Users.AsEnumerable().ToList();
    }

    private bool CheckIfUserExistsAsync(Guid id)
    {
        var user = GetUserByIdAsync(id);
        return user.Result != null;
    }
}