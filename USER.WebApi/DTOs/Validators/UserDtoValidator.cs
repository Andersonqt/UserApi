using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.DTOs.User;
using static USER.WebApi.Domain.Enums;

namespace USER.WebApi.DTOs.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDTO>
    {

        public UserDtoValidator()
        {
            RuleFor(x => x).Must(HasMissingFields).WithErrorCode(((int)ErrorCode.MF).ToString());
            RuleFor(x => x.Email).EmailAddress().WithErrorCode(((int)ErrorCode.IF).ToString());
            //RuleFor(x => x).Must(HasInvalidFields).WithErrorCode(((int)ErrorCode.IF).ToString());
        }
        public override ValidationResult Validate(ValidationContext<UserDTO> context)
        {
            return context == null ? new ValidationResult(new[] { Failure() }) : base.Validate(context);
        }

        private bool HasMissingFields(UserDTO userDTO)
        {
            return !string.IsNullOrEmpty(userDTO.FirstName)
                && !string.IsNullOrEmpty(userDTO.LastName)
                && !string.IsNullOrEmpty(userDTO.Password)
                && !string.IsNullOrEmpty(userDTO.Email);
        }

        private ValidationFailure Failure()
        {
            var failure = new ValidationFailure("", "");
            failure.ErrorCode = ((int)ErrorCode.IF).ToString();
            return failure;
        }

        //private bool HasInvalidFields(object value)
        //{
        //    var typeInfo = value.GetType();
        //    var propertyInfo = typeInfo.GetProperties();

        //    foreach (var property in propertyInfo)
        //    {
        //        if (property != null && property.GetValue(value, null).GetType() != property.GetType())
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
