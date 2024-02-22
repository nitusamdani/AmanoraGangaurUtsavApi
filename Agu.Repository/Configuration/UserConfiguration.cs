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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName).HasColumnName("FullName").IsRequired();
            builder.Property(a => a.Email).HasColumnName("Email").IsRequired();
            builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired();
            builder.Property(a => a.Password).HasColumnName("Password").IsRequired();
            builder.Property(a => a.RoleId).HasColumnName("RoleId").IsRequired();
            builder.Property(a => a.Active).HasColumnName("Active").IsRequired();
            builder.Property(a => a.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(a => a.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
