using ShoppingCart.Data.Models;

namespace ShoppingCart.API.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);

        Task<(int, string)> Login(LoginModel model);
    }
}