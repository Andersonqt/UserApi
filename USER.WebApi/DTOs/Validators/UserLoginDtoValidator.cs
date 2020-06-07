using FluentValidation;
using FluentValidation.Results;
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

        public override ValidationResult Validate(ValidationContext<UserLoginDTO> context)
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
