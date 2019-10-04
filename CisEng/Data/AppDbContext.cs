using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CisEng.Models;

namespace CisEng.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
        public DbSet<CisEng.Models.CisStudent> CisStudent { get; set; }
        public DbSet<CisEng.Models.Posts> Posts { get; set; }
        public DbSet<CisEng.Models.Profile> Profile { get; set; }
        public DbSet<CisEng.Models.Comments> Comments { get; set; }
        public DbSet<CisEng.Models.ResponsetoComment> ResponsetoComment { get; set; }
        public DbSet<CisEng.Models.responsetorespone> responsetorespone { get; set; }
        public DbSet<CisEng.Models.Followus> Followus { get; set; }
        public DbSet<CisEng.Models.Taining> Taining { get; set; }
        public DbSet<CisEng.Models.AppliesforTraining> AppliesforTraining { get; set; }
        public DbSet<CisEng.Models.Jobs> Jobs { get; set; }
        public DbSet<CisEng.Models.ApplyJobs> ApplyJobs { get; set; }
    }
}
