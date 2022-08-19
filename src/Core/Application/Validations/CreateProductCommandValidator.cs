using Application.Features.Products.Commands.Request;
using FluentValidation;
namespace Application.Validations
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(2);
        }
    }
}
