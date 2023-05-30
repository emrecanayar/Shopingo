using FluentValidation;

namespace webAPI.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MinimumLength(2).WithMessage("{PropertyName} must be a minimum of 2 characters.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MinimumLength(2).WithMessage("{PropertyName} must be a minimum of 2 characters.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("{PropertyName} is required").EmailAddress().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MinimumLength(6).WithMessage("{PropertyName} must be a minimum of 6 characters.");
        }
    }
}
