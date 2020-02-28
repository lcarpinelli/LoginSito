using LoginSito.Models.ViewModels;

namespace LoginSito.Models.Services.Application
{
    public interface ILoginService
    {
        public LoginViewModel GetIdLogin(string username, string pass);
    }
}