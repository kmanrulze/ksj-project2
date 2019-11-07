﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dbnd.Logic.Interfaces;
using Dbnd.Logic.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Dbnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IRepository _repository;

        public GameController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Game
        [HttpGet]
        public async Task<IEnumerable<Logic.Objects.Game>> Get()
        {
            return await _repository.GetGamesAsync();
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<Game> Get(Guid id)
        {
            return await _repository.GetGameByGameIDAsync(id);
        }

        // GET: api/Game/ClientID/5
        [HttpGet("ClientID/{id}")]
        public async Task<List<Game>> ClientID(Guid id)
        {
            return await _repository.GetGamesByClientIDAsync(id);
        }

        // Post: api/Game
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("ClientID, GameName")] Game game)
        {
            await _repository.CreateGameAsync(game.ClientID, game.GameName);
            return Created("api/Game/", game);
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody, Bind("GameName")] Game changedGame)
        {
            await _repository.UpdateGameAsync(id, changedGame);
            var returnGame = await _repository.GetGameByGameIDAsync(id);
            return AcceptedAtAction("Get", "Game", null, returnGame);
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteGameByIDAsync(id);
            return NoContent();
        }

        //Get: api/Game/5/Characters/
        [HttpGet("{id}/Characters")]
        public async Task<List<Character>> GetCharactersInGame(Guid id)
        {
            return await _repository.GetAllCharactersInGameByGameIDAsync(id);
        }

        //Post: api/Game/5/AddCharacter/5
        [HttpPost("{gameID}/AddCharacter/{characterID}")]
        public async Task<ActionResult> AddCharacterToGame(Guid gameID, Guid characterID)
        {
            await _repository.AddEntryToCharacterGameXRef(gameID, characterID);
            var returnGame = await _repository.GetGameByGameIDAsync(gameID);
            return AcceptedAtAction("Get", "Game", null, returnGame);
        }

        //Delete: api/Game/5/RemoveCharacter/5
        [HttpPost("{gameID}/AddCharacter/{characterID}")]
        public async Task<ActionResult> RemoveCharacterFromGame(Guid gameID, Guid characterID)
        {
            await _repository.RemoveEntryToCharacterGameXRefAsync(gameID, characterID);
            var returnGame = await _repository.GetGameByGameIDAsync(gameID);
            return AcceptedAtAction("Get", "Game", null, returnGame);
        }
    }
}