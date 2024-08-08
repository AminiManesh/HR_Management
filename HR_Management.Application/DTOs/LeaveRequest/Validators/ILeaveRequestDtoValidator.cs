using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .NotNull().WithMessage("{PropertyName} is required.")
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be ealier than {ComparisonProperty}");

            RuleFor(p => p.EndDate)
               .NotNull().WithMessage("{PropertyName} is required.")
               .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be later than {ComparisonProperty}");

            RuleFor(p => p.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{ProperyName} doesn't exists.")
                .MustAsync(async (id, token) =>
                {
                    return await _leaveTypeRepository.Exists(id);
                });
        }
    }
}
