using Cash.BE.Helpers;
using Cash.BE.Request;
using FluentValidation;

namespace Cash.BE.Validators;

public class UserCreateValidator: AbstractValidator<UserCreateRequest>
{
    public UserCreateValidator()
    {
        RuleFor(user => user.UserName).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(ErrorMessage.RequiredUsename)
            .Matches(RegularExpressions.UserName).WithMessage(ErrorMessage.ExpressionUserName);
        RuleFor(user => user.Email).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(ErrorMessage.RequiredEmail)
            .EmailAddress().WithMessage(ErrorMessage.NotFormatEmail);
        RuleFor(user => user.Password).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(ErrorMessage.RequiredPassword)
            .Matches(RegularExpressions.Password).WithMessage(ErrorMessage.ExpressionPassword);
        RuleFor(user => user.RolId).NotEqual(0).WithMessage(ErrorMessage.RequiredRol);
    }   
}