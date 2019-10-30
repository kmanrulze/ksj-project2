﻿using System;
using System.Collections.Generic;
using Dbnd.Logic.Objects;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Moq;

namespace Dbnd.Test
{

    public class DataRepositoryTests
    {

        [Fact]
        public async Task GetAllGamesByDungeonMasterIDHasCorrectCountAsync()
        {
            var testDungeonMasterID = Guid.NewGuid();

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = testDungeonMasterID,
                    GameID = Guid.NewGuid()
                },
                new Logic.Objects.Game()
                {
                    GameName = "NeverwinterNights",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                },
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "DrunkenCampFireFollies",
                    DungeonMasterID = testDungeonMasterID,
                    GameID = Guid.NewGuid()
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetAllGamesByDungeonMasterID(testDungeonMasterID))
                .Returns(() => Task.FromResult(listOfGames.Where(x => x.DungeonMasterID == testDungeonMasterID).ToList()));

            var testList = (await mockRepository.Object.GetAllGamesByDungeonMasterID(testDungeonMasterID)).Count();

            Assert.Equal(2, testList);
        }

        [Fact]
        public async Task GetCharacterByCharacterIDAsyncReturnsCorrectCharacter()
        {
            var testCharacterID = Guid.NewGuid();

            var listOfCharacters = new List<Dbnd.Logic.Objects.Character>()
            {
                new Dbnd.Logic.Objects.Character()
                {
                    CharacterID = testCharacterID,
                    FirstName = "Kaanyraa",
                    LastName = "Vhokerson"
                },
                new Logic.Objects.Character()
                {
                    CharacterID = Guid.NewGuid(),
                    FirstName = "Elaithyea",
                    LastName = "Craulnober"
                },
                new Dbnd.Logic.Objects.Character()
                {
                    CharacterID = Guid.NewGuid(),
                    FirstName = "Dinininin",
                    LastName = "DoUrden"
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetCharacterByCharacterID(testCharacterID))
                .Returns(() => Task.FromResult(listOfCharacters.Where(x => x.CharacterID == testCharacterID).Single()));

            var testCharacter = (await mockRepository.Object.GetCharacterByCharacterID(testCharacterID));

            Assert.Equal(testCharacterID.ToString(), testCharacter.CharacterID.ToString());

        }
    [Fact]
    public async Task GetDMbyDungeonMasterIDAsyncReturnsCorrectDungeonMaster()
    {
        var testDungeonMasterID = Guid.NewGuid();

        var listOfDungeonMasters = new List<Dbnd.Logic.Objects.DungeonMaster>()
            {
                new Dbnd.Logic.Objects.DungeonMaster()
                {
                    DungeonMasterID = testDungeonMasterID,
                    ClientId = Guid.NewGuid()
                },
                new Logic.Objects.DungeonMaster()
                {
                    DungeonMasterID = Guid.NewGuid(),
                    ClientId = Guid.NewGuid()
                },
                new Dbnd.Logic.Objects.DungeonMaster()
                {
                    DungeonMasterID = Guid.NewGuid(),
                    ClientId = Guid.NewGuid()
                }
            };

        Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
        mockRepository
            .Setup(x => x.GetDMByDungeonMasterID(testDungeonMasterID))
            .Returns(() => Task.FromResult(listOfDungeonMasters.Where(x => x.DungeonMasterID == testDungeonMasterID).Single()));

        var testDungeonMaster = (await mockRepository.Object.GetDMByDungeonMasterID(testDungeonMasterID));

        Assert.Equal(testDungeonMasterID.ToString(), testDungeonMaster.DungeonMasterID.ToString());
    }

        [Fact]
        public async Task GetGameByGameId()
        {
            var testGameID = Guid.NewGuid();

            var listOfGames = new List<Dbnd.Logic.Objects.Game>()
            {
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = testGameID
                },
                new Logic.Objects.Game()
                {
                    GameName = "NeverwinterNights",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                },
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "DrunkenCampFireFollies",
                    DungeonMasterID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetGameByGameID(testGameID))
                .Returns(() => Task.FromResult(listOfGames.Where(x => x.GameID == testGameID).Single()));

            var testGame = (await mockRepository.Object.GetGameByGameID(testGameID));

            Assert.Equal(testGameID.ToString(), testGame.GameID.ToString());
        }

        [Fact]
        public async Task GetClientByIDAsyncReturnsCorrectClient()
        {
            var testClientID = Guid.NewGuid();

            var listOfClients = new List<Dbnd.Logic.Objects.Client>()
            {
                new Dbnd.Logic.Objects.Client()
                {
                    ClientID = testClientID,
                    UserName = "DNDBOY4EVR",
                    Email = "DNDBOY4EVER@Gmail.com"
                },
                new Logic.Objects.Client()
                {
                    ClientID = Guid.NewGuid(),
                    UserName = "DNDGURL4EVR",
                    Email = "DNDGURL4EVER@Gmail.com"
                },
                new Dbnd.Logic.Objects.Client()
                {
                    ClientID = Guid.NewGuid(),
                    UserName = "DNDCOWBOY4EVR",
                    Email = "DNDCOWBOY4EVER@Gmail.com"
                }
            };

            Mock<Logic.Interfaces.IRepository> mockRepository = new Mock<Logic.Interfaces.IRepository>();
            mockRepository
                .Setup(x => x.GetClientByIDAsync(testClientID))
                .Returns(() => Task.FromResult(listOfClients.Where(x => x.ClientID == testClientID).Single()));

            var testClient = (await mockRepository.Object.GetClientByIDAsync(testClientID));

            Assert.Equal(testClientID.ToString(), testClient.ClientID.ToString());
        }

    }
}