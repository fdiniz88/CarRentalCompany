﻿using Microsoft.AspNetCore.Identity;
using CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Configuration;
using System.Threading.Tasks;
using CarRentalCompany.Microservices.IamMicroservice.Shared.Configuration.Identity;

namespace CarRentalCompany.Microservices.IamMicroservice.STS.Identity.Helpers
{
    public class UserResolver<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly LoginResolutionPolicy _policy;

        public UserResolver(UserManager<TUser> userManager, LoginConfiguration configuration)
        {
            _userManager = userManager;
            _policy = configuration.ResolutionPolicy;
        }

        public async Task<TUser> GetUserAsync(string login)
        {
            switch (_policy)
            {
                case LoginResolutionPolicy.Username:
                    return await _userManager.FindByNameAsync(login);
                case LoginResolutionPolicy.Email:
                    return await _userManager.FindByEmailAsync(login);
                default:
                    return null;
            }
        }
    }
}






