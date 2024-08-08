using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using HR_Management.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Test Vacation",
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDay = 12,
                    Name = "Test Sickness",
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });

            return mockRepo;
        }
    }

    public static class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetLeaveRequestRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    ActionDate = null,
                    Approved = null,
                    Canceled = null,
                    CreateDate = DateTime.Now,
                    CreatedBy = null,
                    EndDate = DateTime.Now.AddDays(10),
                    LastModifiedBy = null,
                    LastModifiedDate = DateTime.Now,
                    LeaveTypeId = 1,
                    LeaveType =   new LeaveType
                    {
                        Id = 1,
                        DefaultDay = 10,
                        Name = "Test Vacation",
                    },
                    RequestComment = "Hello",
                    RequestDate = DateTime.Now,
                    StartDate = DateTime.Now,
                }
            };

            var mockRepo = new Mock<ILeaveRequestRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveRequests);

            mockRepo.Setup(r => r.GetLeaveRequestsListWithDetails()).ReturnsAsync(leaveRequests);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveRequest>()))
                .ReturnsAsync((LeaveRequest leaveRequest) =>
                {
                    leaveRequests.Add(leaveRequest);
                    return leaveRequest;
                });

            return mockRepo;
        }
    }
}
