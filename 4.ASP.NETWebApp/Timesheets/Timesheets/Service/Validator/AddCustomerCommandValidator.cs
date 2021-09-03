using FluentValidation;
using Timesheets.Service.Request;
using Timesheets.Validations;

namespace Timesheets.Service.Validator
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        private const string ErrorCode1 = "BRL-101.1";

        public AddCustomerCommandValidator(IErrorCodes errorCodes)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode1)
                .WithMessage(errorCodes.GetMessage(ErrorCode1));
        }
    }
}