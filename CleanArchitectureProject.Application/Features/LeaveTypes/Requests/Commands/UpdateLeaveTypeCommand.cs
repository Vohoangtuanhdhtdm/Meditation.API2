using CleanArchitectureProject.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}

//    Unit: Kiểu trả về, tương đương với void trong MediatR, nghĩa là command này không trả về 
// giá trị cụ thể mà chỉ thực thi hành động