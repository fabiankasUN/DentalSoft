namespace Data {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DentalModel : DbContext {
        public DentalModel( )
            : base( "name=DentalModel" ) {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Billing> Billing { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Odontogram> Odontogram { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<StateAppointment> StateAppointment { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teeth> Teeth { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            modelBuilder.Entity<AspNetRoles>( )
                .HasMany( e => e.AspNetUsers )
                .WithMany( e => e.AspNetRoles )
                .Map( m => m.ToTable( "AspNetUserRoles" ).MapLeftKey( "RoleId" ).MapRightKey( "UserId" ) );

            modelBuilder.Entity<AspNetUsers>( )
                .HasMany( e => e.AspNetUserClaims )
                .WithRequired( e => e.AspNetUsers )
                .HasForeignKey( e => e.UserId );

            modelBuilder.Entity<AspNetUsers>( )
                .HasMany( e => e.AspNetUserLogins )
                .WithRequired( e => e.AspNetUsers )
                .HasForeignKey( e => e.UserId );

            modelBuilder.Entity<AspNetUsers>( )
                .HasMany( e => e.User )
                .WithRequired( e => e.AspNetUsers )
                .HasForeignKey( e => e.Id_AspNetUser )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Client>( )
                .HasMany( e => e.Service )
                .WithMany( e => e.Client )
                .Map( m => m.ToTable( "ClientService" ).MapLeftKey( "Id_Client" ).MapRightKey( "Id_Service" ) );

            modelBuilder.Entity<Client>( )
                .HasMany( e => e.User )
                .WithMany( e => e.Client )
                .Map( m => m.ToTable( "UserClient" ).MapLeftKey( "Id_Client" ).MapRightKey( "Id_user" ) );

            modelBuilder.Entity<Odontogram>( )
                .HasMany( e => e.Teeth )
                .WithRequired( e => e.Odontogram )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Patient>( )
                .HasMany( e => e.Appointment )
                .WithRequired( e => e.Patient )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Patient>( )
                .HasMany( e => e.Odontogram )
                .WithRequired( e => e.Patient )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Service>( )
                .HasMany( e => e.Appointment )
                .WithRequired( e => e.Service )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<StateAppointment>( )
                .HasMany( e => e.Appointment )
                .WithRequired( e => e.StateAppointment )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<User>( )
                .HasMany( e => e.Appointment )
                .WithRequired( e => e.User )
                .WillCascadeOnDelete( false );
        }
    }
}
