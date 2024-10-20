using Microsoft.AspNetCore.Identity;
using Orders.Shared.Entities;

namespace Orders.Backend.UnitOfWork.Interfaces
{
    public interface IUsersUnitOfWoks
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string pasword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRolAsync(User user, string roleName);

        Task<bool> IsUserInRolAsync(User user, string roleName);
    }
}