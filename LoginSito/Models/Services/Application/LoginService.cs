using LoginSito.Models.Services.Infrastructure;
using LoginSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSito.Models.Services.Application
{
    public class LoginService:ILoginService
    {
        private readonly MyCourseDbContext dbContext;

        public LoginService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public LoginViewModel GetIdLogin(string username, string pass)
        {
            LoginViewModel viewModel = dbContext.Login
                .Where(login => login.Username == username && login.Password == pass)
                .Select(login =>
                new LoginViewModel
                {
                    Id = login.Id,
                    User = login.Username,
                    Pass = login.Password,
                }).FirstOrDefault();
            if (viewModel != null )
            {
                return viewModel;
            }
            else
            {
                return null;
            }
            
        }

    }
}
