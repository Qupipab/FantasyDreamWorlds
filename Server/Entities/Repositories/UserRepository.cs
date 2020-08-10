using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Entities.Repositories
{
  public class UserRepository : IUserRepository
  {

    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
      _userManager = userManager;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
      return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
      return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
      return await _userManager.CheckPasswordAsync(user, password);
    }

  }
}
