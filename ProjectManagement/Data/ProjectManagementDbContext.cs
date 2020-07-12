using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ProjectManagement.Infrastructure;
using ProjectManagement.Models;

namespace ProjectManagement.Data
{
    public class ProjectManagementDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {

      public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
            : base(options)
      {}

      public DbSet<Board> Boards { get; set; }
      public DbSet<Card> Cards { get; set; }

    }
}
