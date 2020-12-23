using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    internal class ResponseToCommentConfiguration : IEntityTypeConfiguration<ResponseToComment>
    {
        public void Configure(EntityTypeBuilder<ResponseToComment> builder)
        {
            builder.HasOne(rc=>rc.Comment).WithMany(c=>c.ResponseToComments).HasForeignKey(rc=>rc.CommentId);
            builder.HasOne(rc=>rc.CisStudent).WithMany(c=>c.ResponseToComments).HasForeignKey(rc=>rc.CisStudentId);

        }
    }
}
