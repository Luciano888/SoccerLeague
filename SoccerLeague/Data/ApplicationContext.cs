using Microsoft.EntityFrameworkCore;
using SoccerLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<FootballPlayer> FootballPlayer { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<SoccerLeague.Models.BaseEntity> BaseEntity { get; set; }
    }
}
