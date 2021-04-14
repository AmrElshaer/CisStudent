using Application.Common.Models;
using System.Threading.Tasks;
namespace Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string name, string password, string email, string clientUrl);
        bool IsUniqueEmail(string email);
        bool IsUniqueName(string name);
        Task<bool> UserIsRegister(string email, string password);
        Task ConfirmationEmail(string email, string token);
        Task<bool> EmailIsConfirm(string email);
        Task ForgetPassword(string email, string clientUrl);
        Task<Result> ChangePassword(string email, string token,string newPassword);

    }
}
