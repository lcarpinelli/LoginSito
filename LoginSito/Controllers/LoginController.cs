using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginSito.Models;
using LoginSito.Models.Services.Application;
using LoginSito.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSito.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginSevice)
        {
            this._loginService = loginSevice;
        }

        public IActionResult Index()
        {
            this.ModelState.Clear();
            return View();
        }

        public  IActionResult Control(InfoControl info)
        {
            LoginViewModel value = _loginService.GetIdLogin(info.Username, info.Password);
            if(value!= null)
            {
                return View("Sucess",value);
            }
            else
            {
                this.ModelState.Clear();               
                return View("Index");
            }
        }

        public IActionResult Sucess(LoginViewModel login)
        {
            return View(login);
        }



    }
}