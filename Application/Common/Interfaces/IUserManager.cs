using Application.Common.Models;
using System.Threading.Tasks;
namespace Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string name, string password, string email);
        bool IsUniqueEmail(string email);
        bool IsUniqueName(string name);
        Task<bool> UserIsRegister(string email, string password);

    }
}
