using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USER.WebApi.Domain.Services;
using USER.WebApi.DTOs.User;
using USER.WebApi.DTOs.Validators;

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

        [HttpGet("me")]
        public ActionResult Get()
        {
            var userId = new Guid(User.Identity.Name);
            return CustomResponse(_userService.UserInfo(userId));
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            return CustomResponse(_userService.AllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            return CustomResponse(_userService.GetById(id));
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public ActionResult Post([FromBody] UserDTO user)
        {
            UserDtoValidator validator = new UserDtoValidator();
            ValidationResult result = validator.Validate(user);
            if (!result.IsValid) return CustomResponse(result.Errors);
            return CustomResponse(_userService.Create(user));
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public ActionResult Authenticate([FromBody] UserLoginDTO user)
        {
            UserLoginDtoValidator validator = new UserLoginDtoValidator();
            ValidationResult result = validator.Validate(user);
            if (!result.IsValid) return CustomResponse(result.Errors);
            return CustomResponse(_userService.SignIn(user.Email, user.Password));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return CustomResponse(_userService.DeleteUser(id));
        }
    }
}
