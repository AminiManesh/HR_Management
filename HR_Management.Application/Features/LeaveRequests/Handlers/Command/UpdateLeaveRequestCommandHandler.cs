using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Command;
using HR_Management.Application.Contracts.Persistence;
using MediatR;
using HR_Management.Application.Responses;
using HR_Management.Domain;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, 
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = await _leaveRequestRepository.Get(request.Id);

                if (request.UpdateLeaveRequestDto != null)
                {
                    _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
                    await _leaveRequestRepository.Update(leaveRequest);
                }
                else if (request.ChangeLeaveRequestApprovedDto != null)
                {
                    await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovedDto.Approved);
                }

                response.Success = true;
                response.Message = "Updated Successfully.";
                response.Id = leaveRequest.Id;
            }

            return response;
        }
    }
}
