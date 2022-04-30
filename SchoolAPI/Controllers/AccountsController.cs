using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models.DTO;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        // in Node.js -->
        //  requset.body
        //  requst.query
        //  request.params

        [HttpPost("Register")]
        public async Task <ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //    return Ok("ModelState is Valid");

                //} 
                //else
                //{
                //    //return BadRequest("is not valid");
                //    //return BadRequest(ModelState);
                //    //ModelState.AddModelError("Key Error", "value ValueError");
                //    List<string> ErrorList = new List<String> { "InputError", "PasswordIssue", "AnotherrError" };
                //    int counter = 0;
                //    foreach (var error in ErrorList)
                //    {
                //        counter++;
                //        ModelState.AddModelError("Error No " + counter, error);
                //    }
                //    return BadRequest(new ValidationProblemDetails(ModelState));
                //}
                await _userService.Register(registerDto, this.ModelState);
                if (ModelState.IsValid)
                {
                    return Ok("Registered done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));
                //return Ok("A User hase beed registed successfully");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("Login")]
        public async Task <ActionResult> Login()
        {
            return  Ok("Login Page");
        }
    }
}
