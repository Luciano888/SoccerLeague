using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerLeague.Data;
using SoccerLeague.Models;

namespace SoccerLeague.Services
{
    public class FootballPlayerService : IApplicationService
    {
        private readonly ApplicationContext _context;
        public FootballPlayerService(ApplicationContext appctx)
        {
            _context = appctx;
        }
        public Task<FootballPlayer> Create(FootballPlayer footballPlayer)
        {
            return Task.Run(() => {
                try
                {
                    _context.FootballPlayer.Add(footballPlayer);
                    _context.SaveChanges();

                    return footballPlayer;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return null;
            });
        }

        public Task<FootballPlayer> Delete(FootballPlayer footballPlayer)
        {
            return Task.Run(() => {
                try
                {
                    _context.FootballPlayer.Remove(footballPlayer);
                    _context.SaveChanges();

                    return footballPlayer;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return null;
            });
        }

        public Task<IEnumerable<FootballPlayer>> GetAll()
        {
            return Task.Run(() => {
                try
                {
                    return _context.FootballPlayer.OrderBy(x => x.Id).AsEnumerable();
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return null;
            });
        }

        public Task<FootballPlayer> GetById(int id)
        {
            return Task.Run(() => {
                try
                {
                    var player = _context.FootballPlayer.Where(x => x.Id.Equals(id)).FirstOrDefault();
                    if (player != null)
                    {
                        return player;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return null;
            });
        }

        public Task<FootballPlayer> Update(FootballPlayer footballPlayer)
        {
            return Task.Run(() => {
                try
                {
                    _context.FootballPlayer.Update(footballPlayer);
                    _context.SaveChanges();

                    return footballPlayer;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return null;
            });
        }
    }
}