
using System;
using System.Collections.Generic;
using HotelManagementSystem.Entities.LoginManager;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Context.LoginManager;

public partial class LoginManagerContext : DbContext
{
    public LoginManagerContext()
    {
    }

    public LoginManagerContext(DbContextOptions<LoginManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Frontend> Frontends { get; set; }

    public virtual DbSet<Kitchen> Kitchens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
                System.Configuration.ConfigurationManager
                .ConnectionStrings["LoginManagerConnection"]
                .ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Frontend>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK_Table");
        });

        modelBuilder.Entity<Kitchen>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__kitchen__7628B51D2FDAF8B5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}