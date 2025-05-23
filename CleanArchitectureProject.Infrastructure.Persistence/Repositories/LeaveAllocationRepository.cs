using CleanArchitectureProject.Application.Persistence.Contracts;
using CleanArchitectureProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Infrastructure.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly CleanArchitectureProjectDbContext _dbContext;

        public LeaveAllocationRepository(CleanArchitectureProjectDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _dbContext.leaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations = await _dbContext.leaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocations;
        }
    }
}
