using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Infrastructure.Persistence
{
    public class CleanArchitectureProjectDbContextFactory :
        IDesignTimeDbContextFactory<CleanArchitectureProjectDbContext>
    {
        public CleanArchitectureProjectDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CleanArchitectureProjectDbContext>();
            var connectionString = configuration.GetConnectionString("CleanArchitectureConnectionString");

            builder.UseSqlServer(connectionString);

            return new CleanArchitectureProjectDbContext(builder.Options);
        }
    }
}
