using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
  public interface IUserRepository
  {

    Task<User> FindByEmailAsync(string email);
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<bool> CheckPasswordAsync(User user, string password);

  }
}
