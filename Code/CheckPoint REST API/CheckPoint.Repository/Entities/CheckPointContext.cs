namespace CheckPoint.Repository.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CheckPointContext : DbContext
    {
        public CheckPointContext()
            : base("name=CheckPointContext")
        {
        }

        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<APPOINTMENT> APPOINTMENT { get; set; }
        public virtual DbSet<ATTENDEE> ATTENDEE { get; set; }
        public virtual DbSet<ATTENDEE_STATUS> ATTENDEE_STATUS { get; set; }
        public virtual DbSet<CLIENT> CLIENT { get; set; }
        public virtual DbSet<CLIENT_TAG> CLIENT_TAG { get; set; }
        public virtual DbSet<CLIENT_TYPE> CLIENT_TYPE { get; set; }
        public virtual DbSet<COURSE> COURSE { get; set; }
        public virtual DbSet<READER> READER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ADDRESS>()
                .HasMany(e => e.CLIENT)
                .WithRequired(e => e.ADDRESS1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ADDRESS>()
                .HasMany(e => e.APPOINTMENT)
                .WithRequired(e => e.ADDRESS1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<APPOINTMENT>()
                .Property(e => e.AppointmentName)
                .IsUnicode(false);

            modelBuilder.Entity<APPOINTMENT>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<APPOINTMENT>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<APPOINTMENT>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<APPOINTMENT>()
                .HasMany(e => e.ATTENDEE)
                .WithRequired(e => e.APPOINTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ATTENDEE>()
                .Property(e => e.PersonalNote)
                .IsUnicode(false);

            modelBuilder.Entity<ATTENDEE>()
                .Property(e => e.TagId)
                .IsUnicode(false);

            modelBuilder.Entity<ATTENDEE_STATUS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ATTENDEE_STATUS>()
                .HasMany(e => e.ATTENDEE)
                .WithRequired(e => e.ATTENDEE_STATUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.APPOINTMENT)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.CLIENT_TAG)
                .WithRequired(e => e.CLIENT)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.CLIENT_TAG1)
                .WithRequired(e => e.CLIENT1)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.COURSE)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT_TAG>()
                .Property(e => e.TagId)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT_TAG>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT_TAG>()
                .HasMany(e => e.ATTENDEE)
                .WithRequired(e => e.CLIENT_TAG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT_TYPE>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT_TYPE>()
                .HasMany(e => e.CLIENT)
                .WithRequired(e => e.CLIENT_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<READER>()
                .HasMany(e => e.APPOINTMENT)
                .WithMany(e => e.READER)
                .Map(m => m.ToTable("READER_APPOINTMENT").MapLeftKey("ReaderId").MapRightKey("AppointmentId"));
        }
    }
}
