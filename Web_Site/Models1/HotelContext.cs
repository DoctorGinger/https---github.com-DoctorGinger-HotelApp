using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web_Site.Models1
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderPerRoom> OrderPerRooms { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomStatus> RoomStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=Hotel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard");

                entity.HasIndex(e => e.CardNumber, "UQ__CreditCa__A4E9FFE961305880")
                    .IsUnique();

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Card_Number");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("date")
                    .HasColumnName("Expire_Date");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CreditCar__UserI__2E1BDC42");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CreditCardId).HasColumnName("Credit_Card_Id");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_End");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("Date_Start");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.Property(e => e.TakenBeds).HasColumnName("Taken_Beds");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CreditCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__Credi__35BCFE0A");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__RoomI__34C8D9D1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__UserI__33D4B598");
            });

            modelBuilder.Entity<OrderPerRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderPerRoom");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderPerR__Order__66603565");

                entity.HasOne(d => d.Room)
                    .WithMany()
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderPerR__RoomI__6754599E");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Host).HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Path).HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer).HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("User_Agent");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.BedsNum).HasColumnName("Beds_Num");

                entity.Property(e => e.Description)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.ImageSource)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Image_Source");

                entity.Property(e => e.IsView)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Is_View");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms_tbl__Statu__30F848ED");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.ToTable("Room_status");

                entity.HasIndex(e => e.RoomStatus1, "UQ__Room_sta__B32D19EA9198BCB6")
                    .IsUnique();

                entity.Property(e => e.RoomStatus1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Room_Status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.IdentityNum)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Identity_Num");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__User_tbl__Status__2A4B4B5E");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("User_status");

                entity.HasIndex(e => e.UserStatus1, "UQ__User_sta__8CB3224844F1B108")
                    .IsUnique();

                entity.Property(e => e.UserStatus1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
