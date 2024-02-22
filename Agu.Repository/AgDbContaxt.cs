﻿using Agu.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Agu.Repository.Configuration;
using Agu.Interface.Repository;

namespace Agu.Repository
{
    public class AgDbContext : DbContext , IAgDbContext
    {
        public AgDbContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserRoleConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }
    }
}
