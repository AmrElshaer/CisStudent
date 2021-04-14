using Application.Account.Commands.Register;
using Application.Account.Commands.ResetPassword;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public UserManagerService(UserManager<ApplicationUser> userManager,IMediator mediator)
        {
            _userManager = userManager;
            this._mediator = mediator;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string name, string password,string email,string clientUrl)
        {
            var user = new ApplicationUser { UserName = name, Email = email};
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)throw new ValidationException();
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmLink = await GenerateLink(email, clientUrl, token);
            await _mediator.Publish(new UserRegistered(confirmLink,email));
            return (result.ToApplicationResult(), user.Id);
        }

        private async Task<string> GenerateLink(string email, string clientUrl,string token)
        {
            
            var encodeToken = Encoding.UTF8.GetBytes(token);
            token = WebEncoders.Base64UrlEncode(encodeToken);
            var confirmLink = $"{clientUrl}?token={token}&email={email}";
            return confirmLink;
        }

        public async Task<bool> UserIsRegister(string email,string password) {

            var user =await GetUserAsync(email);
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
                var applicationUser = GetUserAsync(email).GetAwaiter().GetResult();
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
        private async Task<ApplicationUser> GetUserAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task ConfirmationEmail(string email,string token)
        {
            ApplicationUser applicationUser = await GetUserAsync(email);
            if (applicationUser == null) throw new NotFoundException(email, email);
            var confirmResult = await _userManager.ConfirmEmailAsync(applicationUser, token);
            if (!confirmResult.Succeeded)throw new ValidationException();
        }
        public async Task<bool> EmailIsConfirm(string email)
        {
            ApplicationUser applicationUser = await GetUserAsync(email);
            if (applicationUser == null)throw new NotFoundException(email, email);
            return await _userManager.IsEmailConfirmedAsync(applicationUser);
        }
        public async Task ForgetPassword(string email,string clientUrl)
        {
            var token =await GeneratePasswordToken(email);
            string confirmLink = await GenerateLink(email, clientUrl, token);
            await _mediator.Publish(new ResetPassword(confirmLink,email));
        }
        private async Task<string> GeneratePasswordToken(string email)
        {
            var user = await GetUserAsync(email);
            if (user == null) throw new NotFoundException(email, email);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<Result> ChangePassword(string email, string token, string newPassword)
        {
            var user = await GetUserAsync(email);
            if (user == null) throw new NotFoundException(email, email);
            var resetPassResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return resetPassResult.ToApplicationResult();
        }
    }
}
