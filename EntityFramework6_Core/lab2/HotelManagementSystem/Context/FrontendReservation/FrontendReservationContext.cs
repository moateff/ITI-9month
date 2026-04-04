using System;
using System.Collections.Generic;
using HotelManagementSystem.Entities.FrontendReservation;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Context.FrontendReservation;

public partial class FrontendReservationContext : DbContext
{
    public FrontendReservationContext()
    {
    }

    public FrontendReservationContext(DbContextOptions<FrontendReservationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
                System.Configuration.ConfigurationManager
                .ConnectionStrings["FrontendReservationConnection"]
                .ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC070939E04D");

            entity.Property(e => e.CardCvc).IsFixedLength();
            entity.Property(e => e.CardType).IsFixedLength();
            entity.Property(e => e.PaymentType).IsFixedLength();
            entity.Property(e => e.RoomFloor).IsFixedLength();
            entity.Property(e => e.RoomNumber).IsFixedLength();
            entity.Property(e => e.RoomType).IsFixedLength();
            entity.Property(e => e.ZipCode).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}