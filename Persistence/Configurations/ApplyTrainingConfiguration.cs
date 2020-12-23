using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Persistence.Configurations
{
    internal class ApplyTrainingConfiguration : IEntityTypeConfiguration<ApplyTraining>
    {
        public void Configure(EntityTypeBuilder<ApplyTraining> builder)
        {
            builder.HasOne(t => t.CisStudent).WithMany(c => c.ApplyTrainings).HasForeignKey(t=>t.CisStudentId);
            builder.HasOne(t => t.Training).WithMany(c => c.Applies).HasForeignKey(t=>t.TrainingId);

        }
    }
}
