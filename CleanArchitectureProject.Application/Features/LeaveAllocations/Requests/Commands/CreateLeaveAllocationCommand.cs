using CleanArchitectureProject.Application.DTOs.LeaveAllocation;
using CleanArchitectureProject.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
