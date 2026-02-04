using FluentValidation;

namespace backend_api.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

        RuleFor(v => v.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be zero or greater.");
    }
}
