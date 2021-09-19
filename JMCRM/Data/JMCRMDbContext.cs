using JMCRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Data
{
    public class JMCRMDbContext : DbContext
    {
        public JMCRMDbContext(DbContextOptions<JMCRMDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<JMCRM.Models.Storyline> Storyline { get; set; }
    }
}
