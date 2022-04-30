using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models.DTO;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Register(RegisterDto registerDto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Gender = registerDto.Gender,
                //PasswordHash = registerDto.Password 
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
                    
            if (result.Succeeded)
            {
                return;
            }
            // // Else, that means there is an error, let us collect all the errors using the modelState
            foreach (var error in result.Errors)
            {
                // // conditional operator ?:, also known as the ternary conditional operator
                // // condition ? consequent : alternative
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                    "";

                // // the explicit way
                //var errorKey2 = "";
                //if (error.Code.Contains("Password"))
                //{
                //    errorKey2 = "Password Issue";
                //}
                //if (error.Code.Contains("Email"))
                //{
                //    errorKey2 = "Email Issue";
                //}

                modelstate.AddModelError(errorKey, error.Description);
            }
            return;
            //throw new Exception("Error Acour during registeration");
            
            
            
        }
    }
}
