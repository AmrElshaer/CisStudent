using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class ResponseToResCongfiguration : IEntityTypeConfiguration<ResponseToResponse>
    {
        public void Configure(EntityTypeBuilder<ResponseToResponse> builder)
        {
            builder.HasOne(a => a.Comment).WithMany(a => a.ResponseToResponses).HasForeignKey(a=>a.ResponseToCommentId);
            builder.HasOne(a => a.CisStudent).WithMany(a => a.ResponseToResponses).HasForeignKey(a => a.CisStudentId);
        }
    }
}
