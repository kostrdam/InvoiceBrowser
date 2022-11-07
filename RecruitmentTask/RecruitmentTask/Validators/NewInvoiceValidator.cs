using FluentValidation;
using RecruitmentTask.Dto;

namespace RecruitmentTask.Validators
{
    public class NewInvoiceValidator : AbstractValidator<InvoiceDto>
    {
        public NewInvoiceValidator()
        {
            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("Payment date is required");

            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("End date is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("End date is required");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("End date is required");
        }
    }
}
