using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerLeague.Models;
using SoccerLeague.Services;

namespace SoccerLeague.Controllers
{
    public class FootballPlayerController : Controller
    {
        private readonly FootballPlayerService _footballPlayerSrv;
        public FootballPlayerController(FootballPlayerService srv)
        {
            _footballPlayerSrv = srv;
        }
        public IActionResult Index()
        {
            var footballPlayers = _footballPlayerSrv.GetAll().Result;
            return View(footballPlayers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FootballPlayer footballPlayer)
        {
            if (ModelState.IsValid)
            {
                FootballPlayer result = await _footballPlayerSrv.Create(footballPlayer);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                FootballPlayer result = _footballPlayerSrv.GetById(id.Value).Result;
                if (result != null)
                {
                    return View(result);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(FootballPlayer footballPlayer)
        {
            if (ModelState.IsValid)
            {
                FootballPlayer result = await _footballPlayerSrv.Update(footballPlayer);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            FootballPlayer player = await _footballPlayerSrv.GetById(id);
            if (player != null)
            {
                FootballPlayer playerDeleted = await _footballPlayerSrv.Delete(player);
                if (playerDeleted != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}