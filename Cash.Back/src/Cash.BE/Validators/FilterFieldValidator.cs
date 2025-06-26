using Cash.BE.Helpers;
using Cash.BE.Request;
using FluentValidation;

namespace Cash.BE.Validators;

public class FilterFieldValidator: AbstractValidator<FilterField>
{
    public FilterFieldValidator()
    {
        RuleFor(field => field.Method).NotEmpty().WithMessage(ErrorMessage.RequiredMethod);
        RuleFor(field => field.FieldName).NotEmpty().WithMessage(ErrorMessage.RequiredFieldName);
        RuleFor(field => field.FieldValue).NotEmpty().WithMessage(ErrorMessage.RequiredFieldValue);
    }
}