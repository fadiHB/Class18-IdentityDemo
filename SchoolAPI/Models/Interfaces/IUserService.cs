using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
    public interface IUserService
    {
        public Task Register(RegisterDto registerDto, ModelStateDictionary modelstate);
    }
}
