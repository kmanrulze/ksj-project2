﻿using Dbnd.Logic.Objects;
using System.Linq;

namespace Dbnd.Data.Repository
{
    public static class Mapper
    {
        #region Character
        public static Character MapCharacter(Entities.Character ContextCharacter)
        {
            Character LogicCharacter = new Character(ContextCharacter.ClientID, ContextCharacter.FirstName, ContextCharacter.LastName)
            {
                CharacterID = ContextCharacter.CharacterID
            };
            return LogicCharacter;
        }

        public static Entities.Character MapCharacter(Character ContextCharacter)
        {
            Entities.Character EntityCharacter = new Entities.Character
            {
                CharacterID = ContextCharacter.CharacterID,
                ClientID = ContextCharacter.ClientID,
                FirstName = ContextCharacter.FirstName,
                LastName = ContextCharacter.LastName
            };

            return EntityCharacter;
        }
        #endregion

        #region Client
        public static Client MapClient(Entities.Client ContextClient)
        {
            Client LogicClient = new Client(ContextClient.UserName, ContextClient.Email)
            {
                ClientID = ContextClient.ClientID,
                Characters = ContextClient.Characters.Select(Mapper.MapCharacter).ToList()
            };

            return LogicClient;
        }
        public static Entities.Client MapClient(Client ContextClient)
        {
            Entities.Client EntitiesClient = new Entities.Client
            {
                UserName = ContextClient.UserName,
                Email = ContextClient.Email,
                ClientID = ContextClient.ClientID,
                Characters = ContextClient.Characters.Select(Mapper.MapCharacter).ToList(),
                Games = ContextClient.Games.Select(Mapper.MapGame).ToList()
            };

            return EntitiesClient;
        }
        #endregion

        #region Game
        public static Game MapGame(Entities.Game ContextGame)
        {
            Game LogicGame = new Game
            {
                ClientID = ContextGame.ClientID,
                GameID = ContextGame.GameID,
                GameName = ContextGame.GameName
            };
            return LogicGame;
        }
        public static Entities.Game MapGame(Game ContextGame)
        {
            Entities.Game EntityGame = new Entities.Game
            {
                GameID = ContextGame.GameID,
                GameName = ContextGame.GameName,
                ClientID = ContextGame.ClientID,
                Characters = ContextGame.Characters.Select(Mapper.MapCharacter).ToList(),
                Overviews = ContextGame.Overviews.Select(Mapper.MapOverview).ToList()
            };
            return EntityGame;
        }
        #endregion

        #region Overview
        public static Overview MapOverview(Entities.Overview ContextOverview)
        {
            Overview LogicOverview = new Overview()
            {
                GameID = ContextOverview.GameID,
                OverviewID = ContextOverview.OverviewID,
                TypeID = ContextOverview.TypeID
            };
            return LogicOverview;
        }

        public static Entities.Overview MapOverview(Overview ContextOverview)
        {
            Entities.Overview EntityOverview = new Entities.Overview
            {
                GameID = ContextOverview.GameID,
                OverviewID = ContextOverview.OverviewID,
                TypeID = ContextOverview.TypeID
            };
            return EntityOverview;
        }

        // Not necessary until the type system is fleshed out (or murdered)
        /* public static OverviewType MapOverviewType(Entities.OverviewType ContextOverviewType)
        {
            OverviewType LogicOverviewType = new OverviewType()
            {
                TypeID = ContextOverviewType.TypeID
            };
            return LogicOverviewType;
        }

        public static Entities.OverviewType MapOverviewType(OverviewType ContextOverviewType)
        {
            Entities.OverviewType EntityOverviewType = new Entities.OverviewType
            {
                TypeID = ContextOverviewType.TypeID
            };
            return EntityOverviewType;
        } */
        #endregion
    }
}
