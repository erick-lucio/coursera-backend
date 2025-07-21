using FluentValidation;
using WebApiCRUD.Models;

namespace WebApiCRUD.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required")
                            .MinimumLength(3).WithMessage("Name must be at least 3 characters");
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required")
                             .EmailAddress().WithMessage("Email must be valid");
    }
}