using Application.Common.Interfaces;
using Infrastructure.Authorization;
using Infrastructure.Hubs;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                      configuration.GetConnectionString("CisEngConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IJwtFactoryService, JwtFactoryService>();
            services.AddTransient<INotifierMediatorService, EmailNofifierService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddSingleton<IChatHup, ChatHub>();
            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
            });
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                     ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SigningKey)]))
                 };
             });
            // Configure JwtIssuerOptions to use when  generate Token
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SigningKey)])), SecurityAlgorithms.HmacSha256);
            });
            //Mail Configration
            var mailSetting = configuration.GetSection(nameof(MailSettings));
            services.Configure<MailSettings>(a=> {
                a.DisplayName = mailSetting[nameof(MailSettings.DisplayName)];
                a.Host = mailSetting[nameof(MailSettings.Host)];
                a.Password = mailSetting[nameof(MailSettings.Password)];
                a.Port=Convert.ToInt32(mailSetting[nameof(MailSettings.Port)]);
                a.Mail= mailSetting[nameof(MailSettings.Mail)];
            });
            //SignalR
            services.AddSignalR();
            return services;

        }
        
    }
}
