using FluentValidation;

namespace Ordering.Application.Commands.OrderCreate
{
    /// <summary>
    /// OrderCreateValidator
    /// </summary>
    public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
    {
        /// <summary>
        /// OrderCreateValidator Constructor that uses for validation rules.
        /// </summary>
        public OrderCreateValidator()
        {
            RuleFor(x => x.SellerUserName)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}
