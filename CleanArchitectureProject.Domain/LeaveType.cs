using CleanArchitectureProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureProject.Domain
{
    public class LeaveType: BaseDomainEntity // Loại nghỉ phép
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }


    }
}

