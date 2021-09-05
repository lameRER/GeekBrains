using FluentValidation;
using Timesheets.Service.Request;
using Timesheets.Validations;

namespace Timesheets.Service.Validator
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        private const string ErrorCode1 = "BRL-104.1";

        public AddTaskCommandValidator(IErrorCodes errorCodes)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode1)
                .WithMessage(errorCodes.GetMessage(ErrorCode1));
        }
    }
}