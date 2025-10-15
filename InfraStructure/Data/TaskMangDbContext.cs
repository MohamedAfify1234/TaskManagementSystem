using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMangmentSystem.ConfigtrationClasses;

namespace InfraStructure.Data
{
    public class TaskMangDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TaskManagement;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //}
        public TaskMangDbContext():base()
        {
            
        }
        public TaskMangDbContext(DbContextOptions<TaskMangDbContext> options):base(options) 
        {
            
        }
        public DbSet<TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskManagementConfiguration());
        }
    }
}
