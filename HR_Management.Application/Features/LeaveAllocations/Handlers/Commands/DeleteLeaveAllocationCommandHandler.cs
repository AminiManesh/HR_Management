using AutoMapper;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation is null)
            {
                response.Success = false;
                response.Message = "Not Found.";
            }
            else
            {
                await _leaveAllocationRepository.Delete(leaveAllocation);
                response.Success = true;
                response.Message = "Deleted Successfully.";
                response.Id = leaveAllocation.Id;
            }

            return response;
        }
    }
}
