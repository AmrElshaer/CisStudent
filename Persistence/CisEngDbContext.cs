using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public  class CisEngDbContext:DbContext,ICisEngDbContext
    {
        public CisEngDbContext(DbContextOptions<CisEngDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CisStudent> CisStudents { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ApplyTraining> ApplyTrainings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
