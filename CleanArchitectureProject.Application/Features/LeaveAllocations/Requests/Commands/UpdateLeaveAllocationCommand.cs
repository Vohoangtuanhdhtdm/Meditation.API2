using CleanArchitectureProject.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
