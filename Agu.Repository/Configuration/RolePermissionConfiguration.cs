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
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission", "dbo");
            builder.HasKey(a => a.RolePermissionId);

            builder.Property(a => a.RoleId).HasColumnName("RoleId").IsRequired();
            builder.Property(a => a.PermissionId).HasColumnName("PermissionId").IsRequired();
            
        }
    }
}
