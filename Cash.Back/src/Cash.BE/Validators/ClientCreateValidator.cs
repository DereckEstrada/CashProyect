using Cash.BE.Helpers;
using Cash.BE.Request;
using FluentValidation;

namespace Cash.BE.Validators;

public class ClientCreateValidator: AbstractValidator<ClientCreateRequets>
{
    public ClientCreateValidator()
    {
        RuleFor(client => client.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(ErrorMessage.RequiredName)
            .Matches(RegularExpressions.AllLetters)
            .WithName(ErrorMessage.ExpressionAllLetters);
        RuleFor(client => client.LastName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(ErrorMessage.RequiredLastName)
            .Matches(RegularExpressions.AllLetters)
            .WithName(ErrorMessage.ExpressionAllLetters);
        RuleFor(client => client.Identification).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(ErrorMessage.RequiredIdentification)
            .Matches(RegularExpressions.Identification)
            .WithMessage(ErrorMessage.ExpressionIdentification);
        RuleFor(client => client.Email).NotEmpty().WithMessage(ErrorMessage.RequiredEmail)
            .EmailAddress().WithMessage(ErrorMessage.NotFormatEmail);
        RuleFor(client => client.Address).NotEmpty().WithMessage(ErrorMessage.RequiredGeneric)
            .Matches(RegularExpressions.AddressAnReferences).WithMessage(ErrorMessage.ExpressionAddressAnReferences);
        RuleFor(client => client.ReferencesAddress).NotEmpty().WithMessage(ErrorMessage.RequiredGeneric)
            .Matches(RegularExpressions.AddressAnReferences).WithMessage(ErrorMessage.ExpressionAddressAnReferences);
        RuleFor(client => client.PhoneNumber).NotEmpty().WithMessage(ErrorMessage.RequiredPhone)
            .Matches(RegularExpressions.Phone).WithMessage(ErrorMessage.ExpressionPhone);
    }
}