using FluentValidation;
using Timesheets.Service.Request;
using Timesheets.Validations;

namespace Timesheets.Service.Validator
{
    public class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
    {
        private const string ErrorCode1 = "BRL-103.1";
        private const string ErrorCode2 = "BRL-103.2";
        private const string ErrorCode3 = "BRL-103.3";
        private const string ErrorCode4 = "BRL-103.4";
        
        public AddInvoiceCommandValidator(IErrorCodes errorCodes)
        {
            RuleFor(x => x.ContractId)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode1)
                .WithMessage(errorCodes.GetMessage(ErrorCode1));
            
            RuleFor(x => x.Date)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode2)
                .WithMessage(errorCodes.GetMessage(ErrorCode2));
            
            RuleFor(x => x.Total)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode3)
                .WithMessage(errorCodes.GetMessage(ErrorCode3));
            
            RuleFor(x => x.Tasks)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode4)
                .WithMessage(errorCodes.GetMessage(ErrorCode4));
        }
    }
}