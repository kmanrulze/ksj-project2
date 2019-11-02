﻿using System;
using System.Collections.Generic;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dbnd.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DbndContext _context;

        public Repository(DbndContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Logic.Objects.Character>> GetCharactersAsync()
        {
            var entityCharList = await _context.Character.ToListAsync();
            return entityCharList.Select(Mapper.MapCharacter);
        }

        public async Task<Logic.Objects.Character> GetCharacterByCharacterIDAsync(Guid CharacterID)
        {
            try
            {
                Logic.Objects.Character LogicCharacter = Mapper.MapCharacter(await _context.Character.FirstAsync(pc => pc.CharacterID == CharacterID));
                return LogicCharacter;
            }
            catch
            {
                throw new Exception("Getting by ID did not complete successfully");
            }
        }

        public async Task CreateCharacterAsync(Guid clientID, string firstName, string lastName)
        {
            try
            {
                _context.Character.Add(Mapper.MapCharacter(new Logic.Objects.Character(clientID, firstName, lastName)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldnt create character for some reason");
            }
        }

        public async Task<Logic.Objects.Client> GetClientByIDAsync(Guid ClientID)
        {
            try
            {
                Logic.Objects.Client LogicClient = Mapper.MapClient(await _context.Client.FirstAsync(c => c.ClientID == ClientID));
                return LogicClient;
            }
            catch
            {
                throw new Exception("did not get client successfully");
            }
        }
        
        public async Task CreateClientAsync(string userName, string email)
        {
            try
            {
                _context.Client.Add(Mapper.MapClient(new Logic.Objects.Client(userName, email)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldn't create client for some reason.");
            }

        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByDungeonMasterIDAsync(Guid DungeonMasterID)
        {
            try
            {
                Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDungeonMaster(await _context.DungeonMaster.FirstAsync(dm => dm.DungeonMasterID == DungeonMasterID));
                return LogicDungeonMaster;
            }
            catch
            {
                throw new Exception("Did not get DM successfully");
            }
        }

        public async Task<Logic.Objects.DungeonMaster> GetDMByClientIDAsync(Guid ClientID)
        {
            try
            {
                Logic.Objects.DungeonMaster LogicDungeonMaster = Mapper.MapDungeonMaster(await _context.DungeonMaster.FirstAsync(dm => dm.ClientID == ClientID));
                return LogicDungeonMaster;
            }
            catch
            {
                throw new Exception("Did not get DM successfully");
            }
        }

        public async Task CreateDungeonMasterAsync(Guid clientID)
        {
            try
            {
                _context.DungeonMaster.Add(Mapper.MapDungeonMaster(new Logic.Objects.DungeonMaster(clientID)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldn't create DungeonMaster for some reason");
            }
        }

        public async Task<IEnumerable<Logic.Objects.Game>> GetGamesAsync()
        {
            var entityGameList = await _context.Game.ToListAsync();
            return entityGameList.Select(Mapper.MapGame);
        }

        public async Task<Logic.Objects.Game> GetGameByGameID(Guid GameID)
        {
            try
            {
                Logic.Objects.Game LogicGame = Mapper.MapGame(await _context.Game.FirstAsync(g => g.GameID == GameID));
                return LogicGame;
            }
            catch
            {
                throw new Exception("Did not get game successfully");
            }
        }

        public List<Logic.Objects.Game> GetGamesByDungeonMasterID(Guid DungeonMasterID)
        {
            try
            {
                List<Logic.Objects.Game> LogicGameList = new List<Logic.Objects.Game>();

                foreach (Entities.Game ContextGame in _context.Game.Where(g => g.DungeonMasterID == DungeonMasterID))
                {
                    LogicGameList.Add( Mapper.MapGame(ContextGame) );
                }
                return LogicGameList;
            }
            catch
            {
                throw new Exception("Did not get Game from DMID successfully");
            }
        }

        public async Task CreateGameAsync(Guid dungeonMasterID, string gameName)
        {
            try
            {
                _context.Game.Add(Mapper.MapGame(new Logic.Objects.Game(dungeonMasterID, gameName)));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Couldnt create a game for some reason");
            }
        }

        public async Task<IEnumerable<Logic.Objects.Client>> GetClientsAsync()
        {
            var entityClientList = await _context.Client.ToListAsync();
            return entityClientList.Select(Mapper.MapClient);
        }

        public async Task DeleteClientByIDAsync(Guid clientID)
        {
            Client ContextClient = await _context.Client.FirstAsync(c => c.ClientID == clientID);
            _context.Remove(ContextClient);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCharacterByIDAsync(Guid CharacterID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameByIDAsync(Guid GameID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDungeonMasterByIDAsync(Guid DungeonMasterID)
        {
            throw new NotImplementedException();
        }
    }
}
