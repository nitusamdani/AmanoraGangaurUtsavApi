using Agu.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agu.Repository.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", "dbo");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.Property(a => a.Active).HasColumnName("Active").IsRequired();
            builder.Property(a => a.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(a => a.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
