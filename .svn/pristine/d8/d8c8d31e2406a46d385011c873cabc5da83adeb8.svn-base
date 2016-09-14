using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using VYSA.Domain.Entities;

namespace VYSA.Domain.Util
{
    class ModelBuilderHelper
    {
        public static void FixDateTimeColumns(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(f => f.LastActivityDateTimeUtc).HasColumnType("datetime2");
            modelBuilder.Entity<User>().Property(f => f.LastLoginDateTimeUtc).HasColumnType("datetime2");
            modelBuilder.Entity<User>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<User>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<User>().Property(f => f.LastPasswordChangeDateTimeUtc).HasColumnType("datetime2");

            //modelBuilder.Entity<User>().Property(f => f.Role.ID).IsConcurrencyToken(true);

            modelBuilder.Entity<Role>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Role>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Announcement>().Property(f => f.StartTime).HasColumnType("datetime2");
            modelBuilder.Entity<Announcement>().Property(f => f.EndTime).HasColumnType("datetime2");
            modelBuilder.Entity<Announcement>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Announcement>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<BoardMember>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<BoardMember>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<PlayerGuardian>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<PlayerGuardian>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Guardian>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Guardian>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Season>().Property(f => f.RegistrationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Season>().Property(f => f.StartDate).HasColumnType("datetime2");
            modelBuilder.Entity<Season>().Property(f => f.EndDate).HasColumnType("datetime2");
            modelBuilder.Entity<Season>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Season>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Event>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Event>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Event>().Property(f => f.StartDate).HasColumnType("datetime2");
            modelBuilder.Entity<Event>().Property(f => f.EndDate).HasColumnType("datetime2");

            modelBuilder.Entity<Team>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Team>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Roster>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Roster>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<TeamEvent>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<TeamEvent>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<TeamCoach>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<TeamCoach>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<TeamCoach>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<TeamCoach>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Coach>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Coach>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<ParentRep>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<ParentRep>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Division>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Division>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Player>().Property(f => f.MothersDateOfBirth).HasColumnType("datetime2");
            modelBuilder.Entity<Player>().Property(f => f.DateOfBirth).HasColumnType("datetime2");
            modelBuilder.Entity<Player>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Player>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Location>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Location>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Field>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Field>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            //modelBuilder.Entity<Match>().Property(f => f.LastUpdate).HasColumnType("datetime2");
            //modelBuilder.Entity<Match>().Property(f => f.CreatedDate).HasColumnType("datetime2");

            modelBuilder.Entity<Practice>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Practice>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

            modelBuilder.Entity<Registration>().Property(f => f.DateRegistered).HasColumnType("datetime2");
            modelBuilder.Entity<Registration>().Property(f => f.LastUpdateUtc).HasColumnType("datetime2");
            modelBuilder.Entity<Registration>().Property(f => f.CreatedDateUtc).HasColumnType("datetime2");

        }
    }
}
