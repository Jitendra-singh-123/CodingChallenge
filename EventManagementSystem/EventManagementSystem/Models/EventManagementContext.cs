using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManagementSystem.Models
{
    public partial class EventManagementContext : DbContext
    {
        public EventManagementContext()
        {
        }

        public EventManagementContext(DbContextOptions<EventManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventRegistration> EventRegistrations { get; set; } = null!;
        public virtual DbSet<Organizer> Organizers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EventManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.RegistrationFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Events__Organize__46E78A0C");
            });

            modelBuilder.Entity<EventRegistration>(entity =>
            {
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventRegi__Event__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EventRegi__UserI__4F7CD00D");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Organize__A9D10534ACD6C435")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4116179FE")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D105345E822E48")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
