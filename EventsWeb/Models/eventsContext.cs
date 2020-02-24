using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventsWeb.Models
{
    public partial class eventsContext : DbContext
    {
        public eventsContext() { }

        public eventsContext(DbContextOptions<eventsContext> options) : base(options) { }

        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventregister> Eventregister { get; set; }
        public virtual DbSet<Eventschedule> Eventschedule { get; set; }
        public virtual DbSet<Eventtype> Eventtype { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }
        public virtual DbSet<Usertype> Usertype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.Iddocument)
                    .HasName("documents_pk");

                entity.ToTable("documents", "events");

                entity.Property(e => e.Iddocument)
                    .HasColumnName("iddocument")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Blob)
                    .IsRequired()
                    .HasColumnName("blob");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Idregister).HasColumnName("idregister");

                entity.HasOne(d => d.IdregisterNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.Idregister)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documents_register_fk");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Idevent)
                    .HasName("event_pk");

                entity.ToTable("event", "events");

                entity.Property(e => e.Idevent)
                    .HasColumnName("idevent")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasMaxLength(255);

                entity.Property(e => e.Ideventtype).HasColumnName("ideventtype");

                entity.HasOne(d => d.IdeventtypeNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Ideventtype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_eventtype_fk");
            });

            modelBuilder.Entity<Eventregister>(entity =>
            {
                entity.HasKey(e => e.Ideventregister)
                    .HasName("eventregister_pk");

                entity.ToTable("eventregister", "events");

                entity.Property(e => e.Ideventregister)
                    .HasColumnName("ideventregister")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Evaluation)
                    .HasColumnName("evaluation")
                    .HasMaxLength(50);

                entity.Property(e => e.Ideventschedule).HasColumnName("ideventschedule");


                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdeventscheduleNavigation)
                    .WithMany(p => p.Eventregister)
                    .HasForeignKey(d => d.Ideventschedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventregister_eventschedule_fk");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Eventregister)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventregister_user_fk");
            });

            modelBuilder.Entity<Eventschedule>(entity =>
            {
                entity.HasKey(e => e.Ideventschedule)
                    .HasName("eventschedule_pk");

                entity.ToTable("eventschedule", "events");

                entity.Property(e => e.Ideventschedule)
                    .HasColumnName("ideventschedule")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Dateend)
                    .HasColumnName("dateend")
                    .HasColumnType("date");

                entity.Property(e => e.Datestart)
                    .HasColumnName("datestart")
                    .HasColumnType("date");

                entity.Property(e => e.Idevent).HasColumnName("idevent");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdeventNavigation)
                    .WithMany(p => p.Eventschedule)
                    .HasForeignKey(d => d.Idevent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventschedule_event_fk");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Eventschedule)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventschedule_user_fk");
            });

            modelBuilder.Entity<Eventtype>(entity =>
            {
                entity.HasKey(e => e.Ideventtype)
                    .HasName("eventtype_pk");

                entity.ToTable("eventtype", "events");

                entity.Property(e => e.Ideventtype)
                    .HasColumnName("ideventtype")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Idgender)
                    .HasName("gender_pk");

                entity.ToTable("gender", "events");

                entity.Property(e => e.Idgender)
                    .HasColumnName("idgender")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Idregister)
                    .HasName("register_pk");

                entity.ToTable("register", "events");

                entity.Property(e => e.Idregister)
                    .HasColumnName("idregister")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Isvalid).HasColumnName("isvalid");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Register)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("register_user_fk");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Idsession)
                    .HasName("session_pk");

                entity.ToTable("session", "events");

                entity.Property(e => e.Idsession)
                    .HasColumnName("idsession")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Lastaccess)
                    .HasColumnName("lastaccess")
                    .HasColumnType("date");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_user_fk");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Idstate)
                    .HasName("state_pk");

                entity.ToTable("state", "events");

                entity.Property(e => e.Idstate)
                    .HasColumnName("idstate")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("user_pk");

                entity.ToTable("user", "events");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(1000);

                entity.Property(e => e.Idusertype).HasColumnName("idusertype");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdusertypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Idusertype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_usertype_fk");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("userinfo_pk");

                entity.ToTable("userinfo", "events");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Idgender).HasColumnName("idgender");

                entity.Property(e => e.Idstate).HasColumnName("idstate");

                entity.HasOne(d => d.IdgenderNavigation)
                    .WithMany(p => p.Userinfo)
                    .HasForeignKey(d => d.Idgender)
                    .HasConstraintName("userinfo_gender_fk");

                entity.HasOne(d => d.IdstateNavigation)
                    .WithMany(p => p.Userinfo)
                    .HasForeignKey(d => d.Idstate)
                    .HasConstraintName("userinfo_state_fk");

                entity.HasOne(d => d.IduserNavigation)
                    .WithOne(p => p.Userinfo)
                    .HasForeignKey<Userinfo>(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userinfo_user_fk");
            });

            modelBuilder.Entity<Usertype>(entity =>
            {
                entity.HasKey(e => e.Idusertype)
                    .HasName("usertype_pk");

                entity.ToTable("usertype", "events");

                entity.Property(e => e.Idusertype)
                    .HasColumnName("idusertype")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);
            });
        }
    }
}