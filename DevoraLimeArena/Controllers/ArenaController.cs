using DevoraLimeArena.DB;
using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;

namespace DevoraLimeArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        //lehetne dependency injectiont használni de kicsit overkill lenne ide
        private readonly IArenaservice _arenaservice;
        private readonly IArenaRepository _arenaRepository;

        public ArenaController(IArenaservice arenaservice,IArenaRepository arenaRepository)
        {
            this._arenaservice = arenaservice;
            this._arenaRepository = arenaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to the Arena!");
        }

        [HttpGet("GenerateArenaWithHeroes/{heroesAmount}")]
        public IActionResult GenerateArenaWithHeroes(int heroesAmount)
        {
            if (heroesAmount<2)
            {
                return BadRequest(new { Message = "Not enough fighters to fight!" });
            }
            return Ok(new { ArenaId = _arenaservice.BuildNewArena(heroesAmount)});
        }

        [HttpGet("Fight/{arenaId}")]
        public IActionResult Fight(int arenaId) {


            if (!this._arenaRepository.ArenaExists(arenaId))
            {
                return NotFound(new { Message = "Arena not found" });
            }

            return Ok(_arenaservice.StartArenaFight(arenaId).OrderBy(x=>x.RoundNr).Select(x=>new PrettyFightResultModel(x)).ToList());
        
        }

    }
}
