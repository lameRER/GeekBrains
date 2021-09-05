using FluentValidation;
using Timesheets.Service.Request;
using Timesheets.Validations;

namespace Timesheets.Service.Validator
{
    public class AddContractCommandValidator : AbstractValidator<AddContractCommand>
    {
        private const string ErrorCode1 = "BRL-100.1";
        private const string ErrorCode2 = "BRL-100.2";
        private const string ErrorCode3 = "BRL-100.3";
        private const string ErrorCode4 = "BRL-100.4";
        private const string ErrorCode5 = "BRL-100.5";

        public AddContractCommandValidator(IErrorCodes errorCodes)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode1)
                .WithMessage(errorCodes.GetMessage(ErrorCode1));
            
            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode2)
                .WithMessage(errorCodes.GetMessage(ErrorCode2));
            
            RuleFor(x => x.SetDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode3)
                .WithMessage(errorCodes.GetMessage(ErrorCode3));
            
            RuleFor(x => x.EndDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode4)
                .WithMessage(errorCodes.GetMessage(ErrorCode4));
            
            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode5)
                .WithMessage(errorCodes.GetMessage(ErrorCode5));
        }
    }
}