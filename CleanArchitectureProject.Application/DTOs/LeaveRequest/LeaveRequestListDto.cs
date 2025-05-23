using CleanArchitectureProject.Application.DTOs.Common;
using CleanArchitectureProject.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
            public LeaveTypeDto LeaveType { get; set; }
            public DateTime DateRequested { get; set; }
            public bool? Approved { get; set; }
    }
}
