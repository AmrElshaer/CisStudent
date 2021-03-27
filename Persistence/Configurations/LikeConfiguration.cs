using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(a => a.Post).WithMany(a => a.Likes).HasForeignKey(a => a.PostId);
            builder.HasOne(a => a.Student).WithMany(a => a.Likes).HasForeignKey(a => a.StudentId);
        }
    }
}
