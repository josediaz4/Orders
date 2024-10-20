using Microsoft.AspNetCore.Identity;
using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitOfWork.Interfaces;
using Orders.Shared.Entities;

namespace Orders.Backend.UnitOfWork.Implementations
{
    public class UsersUnitOfWorks : IUsersUnitOfWoks
    {
        private readonly IUsersRepository _usersRepository;

        public UsersUnitOfWorks(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string pasword) => await _usersRepository.AddUserAsync(user, pasword);

        public async Task AddUserToRolAsync(User user, string roleName) => await _usersRepository.AddUserToRolAsync(user, roleName);

        public async Task CheckRoleAsync(string roleName) => await _usersRepository.CheckRoleAsync(roleName);

        public async Task<User> GetUserAsync(string email) => await _usersRepository.GetUserAsync(email);

        public async Task<bool> IsUserInRolAsync(User user, string roleName) => await _usersRepository.IsUserInRolAsync(user, roleName);
    }
}