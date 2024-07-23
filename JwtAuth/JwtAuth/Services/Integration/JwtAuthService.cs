using JwtAuth.Common.Utils;
using JwtAuth.Data.Entity;
using JwtAuth.Models.RequestModels;
using JwtAuth.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace JwtAuth.Services.Integration
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;

        public JwtAuthService(UserManager<ApplicationUserModel> userManager, SignInManager<ApplicationUserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Register logic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<ApplicationUserModel> Register(UserRequestModel model)
        {
            var user = new ApplicationUserModel { UserName = model.Username };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new System.Exception("User registration failed");
            }
            return user;
        }

        /// <summary>
        /// Login Logic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<string> Login(UserRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new System.Exception("Invalid username or password");
            }

            return JwtUtils.GenerateToken(user);
        }
    }
}
