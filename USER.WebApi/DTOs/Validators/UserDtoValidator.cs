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
            RuleFor(x => x).Must(HasMissingFields).WithErrorCode(((int)ErrorCode.MF).ToString()).WithMessage(ErrorCode.MF.GetEnumDescription());
            RuleFor(x => x.Email).EmailAddress().WithErrorCode(((int)ErrorCode.IF).ToString()).WithMessage(ErrorCode.IF.GetEnumDescription());
            RuleFor(x => x.Phones).Must(HasPhoneMissingFields).When(x => x.Phones.Any()).WithMessage(ErrorCode.MF.GetEnumDescription());
        }

        private bool HasPhoneMissingFields(IEnumerable<PhoneDTO> phones)
        {
            return !phones.Any(x => !x.Area_Code.HasValue || !x.Number.HasValue || string.IsNullOrEmpty(x.Country_Code));
        }

        private bool HasMissingFields(UserDTO userDTO)
        {
            return !string.IsNullOrEmpty(userDTO.FirstName)
                && !string.IsNullOrEmpty(userDTO.LastName)
                && !string.IsNullOrEmpty(userDTO.Password)
                && !string.IsNullOrEmpty(userDTO.Email);
        }

        public override ValidationResult Validate(ValidationContext<UserDTO> context)
        {
            return context == null || context.InstanceToValidate == null ? new ValidationResult(new[] { Failure() }) : base.Validate(context);
        }

        private ValidationFailure Failure()
        {
            var failure = new ValidationFailure("", "");
            failure.ErrorCode = ((int)ErrorCode.IF).ToString();
            failure.ErrorMessage = ErrorCode.IF.GetEnumDescription();
            return failure;
        }
    }
}
