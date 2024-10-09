using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SampleSecureCoding.Data;
using SampleSecureCoding.Models;
using SampleSecureCoding.ViewModels;

namespace SampleSecureCoding.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _userData;
        public AccountController (IUser user)
        {
            _userData = user;
        }
        // GET: AccountCont`roller
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel registartionViewModel)
        {
            try
            {
               if(ModelState.IsValid)
               {
                    var user = new Models.User
                    {
                        Username = registartionViewModel.Username,
                        Password = registartionViewModel.Password,
                        RoleName = "contributor"
                    };
                     _userData.Registration(user);
                     return RedirectToAction("Index", "Home");
            }
        }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(registartionViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

       [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                loginViewModel.ReturnUrl = loginViewModel.ReturnUrl ?? Url.Content("~/");
                
                    var user = new User 
                    {
                        Username = loginViewModel.Username,
                        Password = loginViewModel.Password
                    };
                    var loginUser = _userData.Login(user);
                    if (loginUser == null)
                    {
                        ViewBag.Message = "Invalid login attempt.";
                        return View(loginViewModel);
                    }

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)  
                    };
                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, new AuthenticationProperties
                    {
                        IsPersistent = loginViewModel.RememberLogin
                    });
                    
                        return RedirectToAction("Index","Home");
                    
            }
            catch (System.Exception ex)
            {
                ViewBag.Massage = ex.Message;
            }
            return View(loginViewModel);
        }
    }
}