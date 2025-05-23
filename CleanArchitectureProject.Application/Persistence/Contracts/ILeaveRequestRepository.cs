using CleanArchitectureProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
// IGenericRepository<LeaveRequest> : Có nghĩa là tất cả các phương thức trong IGenericRepository sẽ hoạt động với kiểu dữ liệu LeaveRequest.