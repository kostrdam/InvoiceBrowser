using FluentValidation;
using RecruitmentTask.Dto;

namespace RecruitmentTask.Validators
{
    /// <summary>DateParamsDto validator class</summary>
    public class DateParamsValidator : AbstractValidator<DateParamsDto>
    {
        /// <summary>Constructor</summary>
        public DateParamsValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be greater than start date");
        }
    }
}
