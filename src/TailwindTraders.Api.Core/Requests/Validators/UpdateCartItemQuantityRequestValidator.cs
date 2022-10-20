namespace TailwindTraders.Api.Core.Requests.Validators;

public class UpdateCartItemQuantityRequestValidator : AbstractValidator<UpdateCartItemQuantityRequest>
{
    public UpdateCartItemQuantityRequestValidator()
    {
        RuleFor(x => x.CartItem.CartItemId)
            .NotNull()
            .NotEmpty()
            .WithMessage("CartItemId cannot be null/empty.");
        RuleFor(x => x.CartItem.Quantity)
            .NotEmpty()
            .NotNull()
            .WithMessage("Quantity cannot be null/empty.");
    }
}