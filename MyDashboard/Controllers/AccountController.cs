using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyDashboard.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;
        

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager ,
                                 IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            
        }

        #region Registration
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration( RegistrationVM Model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = mapper.Map<IdentityUser>(Model);

                    var result = await userManager.CreateAsync(user,Model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var Error in result.Errors)
                        {
                            ModelState.AddModelError("", Error.Description); 
                        }
                    }
                }
                return View(Model);
            }
            catch (Exception ex)
            {
                return View(Model);
                
            }
            
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password Or Email");
                    }
                   
                }
                return View(Model);
            }
            catch (Exception ex)
            {
                return View(Model);

            }
           
        }
        #endregion

        #region Logoff

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM Model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(Model.Email);

                    if (user != null)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = Model.Email, Token = token }, Request.Scheme);


                        //MailSender.Mail("Password Reset", passwordResetLink);

                        //logger.Log(LogLevel.Warning, passwordResetLink);

                        using (var stream = new StreamWriter(@"F:\sharp academy course\.NetCore\Session10\ResestPass.txt"))
                        {
                            await stream.WriteLineAsync(passwordResetLink);
                        }


                        return RedirectToAction("ConfirmForgetPassword");
                    }

                    return RedirectToAction("ConfirmForgetPassword");


                }


            }
            catch (Exception ex)
            {

            }
            return View();
        }
        #endregion

        #region ConfirmForgetPassword
        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }


        #endregion

        #region Reset Password
        [HttpGet]
        public IActionResult ResetPassword(ResetPasswordVM Model)
        {
            if (Model.Email is null || Model.Token is null)
            {
                ModelState.AddModelError("","Invaled Token And Email");
                return View();
            }
            else
            {
                return View();
            }
        }

        [ActionName("ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordPost( ResetPasswordVM Model)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(Model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, Model.Token, Model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(Model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }
            catch (Exception ex)
            {

                return View(Model);
            }
           
        }
        #endregion

        #region ConfirmResetPassword
        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
        #endregion


    }
}
