using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.DTOs.User;
using static USER.WebApi.Domain.Enums;

namespace USER.WebApi.DTOs.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x).Must(HasMissingFields).WithErrorCode(((int)ErrorCode.MF).ToString()).WithMessage(ErrorCode.MF.GetEnumDescription());
        }

        private bool HasMissingFields(UserLoginDTO userLogin)
        {
            return !string.IsNullOrEmpty(userLogin.Email)
                && !string.IsNullOrEmpty(userLogin.Password);
        }
    }
}
