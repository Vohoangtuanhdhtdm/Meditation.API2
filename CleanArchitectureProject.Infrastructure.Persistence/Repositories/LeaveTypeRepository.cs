using CleanArchitectureProject.Application.Persistence.Contracts;
using CleanArchitectureProject.Domain;
using CleanArchitectureProject.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Infrastructure.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly CleanArchitectureProjectDbContext _dbContext;

        public LeaveTypeRepository(CleanArchitectureProjectDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}

//  :base(dbContext) cần thiết để truyền tham số từ class con lên class cha, đảm bảo class cha(GenericRepository)
// được khởi tạo đúng với dbContext.
// Nếu không có nó, lớp cha không thể hoạt động vì thiếu dữ liệu cần thiết (_dbContext).