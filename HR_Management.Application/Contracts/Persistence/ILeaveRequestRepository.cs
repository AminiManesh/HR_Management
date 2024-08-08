using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
        Task<List<LeaveRequest>> GetLeaveRequestsListWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    }
}
