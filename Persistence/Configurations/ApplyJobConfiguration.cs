using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    internal class ApplyJobConfiguration : IEntityTypeConfiguration<ApplyJob>
    {
        public void Configure(EntityTypeBuilder<ApplyJob> builder)
        {
            builder.HasOne(j => j.CisStudent).WithMany(c=>c.ApplyJobs).HasForeignKey(j=>j.CisStudentId);
            builder.HasOne(j => j.Job).WithMany(jo=>jo.Applies).HasForeignKey(j=>j.JobId);
        }
    }
}
