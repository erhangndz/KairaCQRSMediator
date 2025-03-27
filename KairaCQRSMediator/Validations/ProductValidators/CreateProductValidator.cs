using FluentValidation;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;

namespace KairaCQRSMediator.Validations.ProductValidators
{
    public class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı boş bırakılamaz")
                                       .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.")
                                       .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı boş bırakılamaz")
                                 .InclusiveBetween(10, 10000).WithMessage("Ürün fiyatı 10 ile 10000 arasında bir değer olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Ürün Görseli boş bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün Kategorisi boş bırakılamaz");
        }

    }
}
