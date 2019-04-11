using SoccerLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Services
{
    public interface IApplicationService
    {
        Task<FootballPlayer> Create(FootballPlayer footballPlayer);
        Task<IEnumerable<FootballPlayer>> GetAll();
        Task<FootballPlayer> GetById(int id);
        Task<FootballPlayer> Update(FootballPlayer footballPlayer);
        Task<FootballPlayer> Delete(FootballPlayer footballPlayer);
    }
}
