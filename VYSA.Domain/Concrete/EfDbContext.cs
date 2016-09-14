﻿using System.Data.Entity;
using VYSA.Domain.Entities;
using VYSA.Domain.Util;

namespace VYSA.Domain.Concrete
{
    public partial class EfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }

        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<ParentRep> ParentReps { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<PlayerGuardian> PlayerGuardians { get; set; }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<TeamEvent> TeamEvents { get; set; }
        public DbSet<TeamCoach> TeamCoaches { get; set; }
        public DbSet<TeamParentRep> TeamParentReps { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Field> Fields { get; set; }
        //public DbSet<Match> Matches { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<MailingListMember> MailingListMembers { get; set; }
        public DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Due to EntityFramework problem with DateTime2 [would work in SQLServer2005 I think without this]
            ModelBuilderHelper.FixDateTimeColumns(modelBuilder);

            //UserRoles - many-2-many on-the-fly
            modelBuilder.Entity<User>()
                .HasMany<Role>(r => r.Roles)
                .WithMany(u => u.Users)
                .Map(ur =>
                {
                    ur.MapLeftKey("UserId");
                    ur.MapRightKey("RoleId");
                    ur.ToTable("UserRoles");
                });

            //RolePermissions - many-2-many on-the-fly
            modelBuilder.Entity<Permission>()
                .HasMany<Role>(r => r.Roles)
                .WithMany(u => u.Permissions)
                .Map(ur =>
                {
                    ur.MapLeftKey("RoleId");
                    ur.MapRightKey("PermissionId");
                    ur.ToTable("RolePermissions");
                });

            //UserTypes - many-2-many on-the-fly
            modelBuilder.Entity<User>()
                .HasMany<Type>(r => r.Types)
                .WithMany(u => u.Users)
                .Map(ur =>
                {
                    ur.MapLeftKey("UserId");
                    ur.MapRightKey("TypeId");
                    ur.ToTable("UserTypes");
                });

            modelBuilder.Entity<Division>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Divisions");
            });

            modelBuilder.Entity<MailingListMember>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("MailingListMembers");
            });

            modelBuilder.Entity<Upload>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Uploads");
            });

            modelBuilder.Entity<ContactUsMessage>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ContactUsMessages");
            });

            modelBuilder.Entity<Announcement>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Announcements");
            });

            modelBuilder.Entity<BoardMember>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BoardMembers");
            });

            modelBuilder.Entity<Player>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Players");
            });

            modelBuilder.Entity<Guardian>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Guardians");
            });

            modelBuilder.Entity<PlayerGuardian>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PlayerGuardians");
            });

            modelBuilder.Entity<Event>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Events");
            });

            modelBuilder.Entity<Coach>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Coaches");
            });

            modelBuilder.Entity<ParentRep>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ParentReps");
            });

            modelBuilder.Entity<Season>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Seasons");
            });

            modelBuilder.Entity<Team>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teams");
            });

            modelBuilder.Entity<Roster>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Rosters");
            });

            modelBuilder.Entity<TeamEvent>().HasRequired(x => x.Event).WithMany()
                //                                .HasForeignKey(x => x.EventID)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<TeamEvent>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TeamEvents");
            });

            modelBuilder.Entity<TeamCoach>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TeamCoaches");
            });

            modelBuilder.Entity<TeamParentRep>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TeamParentReps");
            });

            //modelBuilder.Entity<Location>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Locations");
            //});

            //modelBuilder.Entity<Field>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Fields");
            //});

            //modelBuilder.Entity<Practice>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Practices");
            //});

            //modelBuilder.Entity<Registration>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Registrations");
            //});
        }
    }
}