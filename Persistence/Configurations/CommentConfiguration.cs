using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c=>c.Post).WithMany(p=>p.Comments).HasForeignKey(c=>c.PostId);
            builder.HasOne(c=>c.CisStudent).WithMany(p=>p.Comments).HasForeignKey(c=>c.CisStudentId);
        }
    }
}
