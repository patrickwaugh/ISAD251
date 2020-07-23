using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISAD251_Referral.Models
{
    public partial class ISAD251_PWaughContext : DbContext
    {
        public ISAD251_PWaughContext()
        {
        }

        public ISAD251_PWaughContext(DbContextOptions<ISAD251_PWaughContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Deadline> Deadline { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_PWaugh;User Id=PWaugh; Password=ISAD251_22217737");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.ApptId)
                    .HasName("PK__Appointm__EDACF695B6F4F683");

                entity.Property(e => e.ApptId)
                    .HasColumnName("ApptID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApptDate).HasColumnType("datetime");

                entity.Property(e => e.ApptLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApptNotes)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ApptTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment");
            });

            modelBuilder.Entity<Deadline>(entity =>
            {
                entity.Property(e => e.DeadlineId)
                    .HasColumnName("DeadlineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.DeadlineNotes)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DeadlineTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deadline)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deadline");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
