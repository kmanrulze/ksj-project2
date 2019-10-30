﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Dbnd.Logic.Objects
{
    public class Client
    {
        // 8-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        // no double . _
        public string UserName { get; set; }
        public string Email { get; set; }
        private string passwordHash;
        private Guid clientID = Guid.NewGuid();
        private List<Character> characters = new List<Character>();

        // Valid PasswordHash check
        // At least one upper case English letter, (?=.*?[A-Z])
        // At least one lower case English letter, (?=.*?[a - z])
        // At least one digit, (?=.*?[0 - 9])
        // At least one special character, (?=.*?[#?!@$%^&*-])
        // Minimum eight in length.{8,}
        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }
        public Guid ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        public List<Character> Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        // 'Not Null' checks for properties that are not autogenerated
        public bool RequiredFieldsNotNull()
        {
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(PasswordHash))
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        // Valid email check
        // From Microsoft:
        // docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public bool IsValidEmail()
        {
            var email = Email;

            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                        RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }

        // Valid Username check
        // 8-20 alphanumeric . _ chars
        // . and _ can not be leading or trailing
        // no double . _
        public bool IsValidUserName()
        {
            Regex regex  = new Regex(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", RegexOptions.None, TimeSpan.FromMilliseconds(2000));
            Match match = regex.Match(UserName);
            if (match.Success)
            {
                return true;
            } else
            {
                return false;
            }
        }

        // Valid PasswordHash check
        // At least one upper case English letter, (?=.*?[A-Z])
        // At least one lower case English letter, (?=.*?[a - z])
        // At least one digit, (?=.*?[0 - 9])
        // At least one special character, (?=.*?[#?!@$%^&*-])
        // Minimum eight in length.{8,}
        public bool IsValidPasswordHash()
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.None, TimeSpan.FromMilliseconds(2000));
            Match match = regex.Match(passwordHash);
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
