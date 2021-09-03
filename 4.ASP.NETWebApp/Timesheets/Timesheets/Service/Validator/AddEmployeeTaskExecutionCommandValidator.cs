using FluentValidation;
using Timesheets.Service.Request;
using Timesheets.Validations;

namespace Timesheets.Service.Validator
{
    public class AddEmployeeTaskExecutionCommandValidator : AbstractValidator<AddEmployeeTaskExecutionCommand>
    {
        private const string ErrorCode1 = "BRL-102.1";
        private const string ErrorCode2 = "BRL-102.2";
        private const string ErrorCode3 = "BRL-102.3";
        
        public AddEmployeeTaskExecutionCommandValidator(IErrorCodes errorCodes)
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode1)
                .WithMessage(errorCodes.GetMessage(ErrorCode1));
            
            RuleFor(x => x.TaskId)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode2)
                .WithMessage(errorCodes.GetMessage(ErrorCode2));
            
            RuleFor(x => x.TimeSpent)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode3)
                .WithMessage(errorCodes.GetMessage(ErrorCode3));
        }
    }
}