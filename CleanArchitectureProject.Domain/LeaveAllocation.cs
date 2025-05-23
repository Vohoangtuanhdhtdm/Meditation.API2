using CleanArchitectureProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Domain
{
    public class LeaveAllocation : BaseDomainEntity // Phân bổ ngày nghỉ
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set;}
    }
}


