using Microsoft.AspNetCore.Mvc;
using StudyCircle.API.Models;
using StudyCircle.API.Repository;

namespace StudyCircle.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<User?> GetUser(Guid id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        [HttpGet("All")]
        public List<User?> GetAllUsers()
        {
            return _repository.GetAllUsers().ToList();
        }

        [HttpPost("Create")]
        public async Task<int> CreateUser([FromBody]User user)
        {
            return await _repository.CreateUserAsync(user);
        }
    }
}