using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string name, string password,string email)
        {
            var user = new ApplicationUser
            {
                UserName = name,
                Email = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }
        public async Task<bool> UserIsRegister(string email,string password) {

            var user =await  _userManager.FindByEmailAsync(email);
            switch (user)
            {
                case null:
                    return false;
                case ApplicationUser applicationUser when await _userManager.CheckPasswordAsync(applicationUser, password):
                    return true;
            }
            return false;
        }
        public  bool IsUniqueEmail(string email) {
            if (!string.IsNullOrEmpty(email))
            {
                var applicationUser = _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
                if (applicationUser == null) return true;
                return false;
            }

            return true;

        }
        public bool IsUniqueName(string name)
        {

            if (!string.IsNullOrEmpty(name))
            {
                var applicationUser =  _userManager.FindByNameAsync(name).GetAwaiter().GetResult();
                if (applicationUser == null) return true;
                return false;
            }

            return true;
        }
    }
}
