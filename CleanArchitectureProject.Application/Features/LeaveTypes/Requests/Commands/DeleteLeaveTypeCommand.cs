using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
