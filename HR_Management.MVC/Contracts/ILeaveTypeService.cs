using HR_Management.MVC.Models.LeaveType;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
        Task<UpdateLeaveTypeVM> GetLeaveTypeDetailsForUpdate(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType);
        Task<Response<int>> UpdateLeaveType(int id, UpdateLeaveTypeVM leaveType);
        Task<Response<int>> DeleteLeaveType(int id);
    }
}
