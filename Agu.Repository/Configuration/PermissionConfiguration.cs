using Agu.Domain.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Repository.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "dbo");
            builder.HasKey(a => a.PermissionId);

            builder.Property(a => a.Action).HasColumnName("Action").IsRequired();
            builder.Property(a => a.Module).HasColumnName("Module").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description");
            
        }
    }
}