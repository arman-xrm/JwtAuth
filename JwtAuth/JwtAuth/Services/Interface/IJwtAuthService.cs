using JwtAuth.Data.Entity;
using JwtAuth.Models.RequestModels;

namespace JwtAuth.Services.Interface
{
    public interface IJwtAuthService
    {
        Task<ApplicationUserModel> Register(UserRequestModel model);
        Task<string> Login(UserRequestModel model);
    }
}
