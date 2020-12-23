using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    internal class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasOne(f=>f.CisStudentSend).WithMany(c=>c.SendFollow).HasForeignKey(f=>f.CisStudentSendId);
            builder.HasOne(f=>f.CisStudentRecieve).WithMany(c=>c.ReceiveFollow).HasForeignKey(f=>f.CisStudentRecieveId);
        }
    }
}
