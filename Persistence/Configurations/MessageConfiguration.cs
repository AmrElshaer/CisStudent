using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(a => a.SendSTD).WithMany(a => a.MessagesSend).HasForeignKey(a => a.SendId);
            builder.HasOne(a => a.RecieveSTD).WithMany(a => a.MessagesRecieve).HasForeignKey(a => a.RecieveId);
        }
    }
}
