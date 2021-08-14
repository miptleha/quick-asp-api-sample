using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quick_asp_api_sample.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {
            log.Debug("ctor");
            Database.EnsureCreated();
        }
    }
}
