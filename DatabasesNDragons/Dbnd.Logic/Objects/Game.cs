﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dbnd.Logic.Objects
{
    public class Game
    {
        private Guid gameID = Guid.NewGuid();

        public Guid GameID
        {
            get { return gameID; }
            set { gameID = value; }
        }

        // 6-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        // no double . _
        public string GameName { get; set; }
        public Guid DungeonMasterID { get; set; }

        // 'Not Null' checks for properties that are not autogenerated
        public bool RequiredFieldsNotNull()
        {
            if (String.IsNullOrEmpty(GameName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Valid GameName checks
        // 6-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        // no double . _
        bool IsValidFirstName()
        {
            Regex regex = new Regex(@"^(?=.{6,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            Match match = regex.Match(GameName);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
