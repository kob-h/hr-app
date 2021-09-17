using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace HR.Persistence.Database
{
    public class HRDbContextFactory : IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContextFactory()
        {
            
        }

        public HRDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRDbContext>();
            optionsBuilder.UseSqlServer("Server=LENO-PF22KR\\HRMSSQLSERVER;Database=HRDB;User Id=SA;Password=pmFFgqI1988$;");

            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
