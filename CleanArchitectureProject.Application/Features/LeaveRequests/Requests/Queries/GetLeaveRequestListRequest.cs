using CleanArchitectureProject.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
