using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using USER.WebApi.Domain;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Services;
using USER.WebApi.DTOs.User;
using USER.WebApi.DTOs.Validators;
using static USER.WebApi.Domain.Enums;

namespace USER.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet("me")]
        public ActionResult<UserInfoDTO> Get()
        {
            return Ok(_userService.UserInfo());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost("signup")]
        public ActionResult Post([FromBody] UserDTO user)
        {
            UserDtoValidator validator = new UserDtoValidator();
            ValidationResult result = validator.Validate(user);
            if (!result.IsValid) return CustomResponse(result.Errors);
            return CustomResponse(_userService.Create(user));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
