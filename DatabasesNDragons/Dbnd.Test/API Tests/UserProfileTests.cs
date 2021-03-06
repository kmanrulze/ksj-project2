﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace Dbnd.Test.API_Tests
{
    public class UserProfileTests
    {
        [Fact]
        public void UserProfileInitSuccess()
        {
            var userProfile = new Dbnd.Api.UserProfile()
            {
                
                //given_name = "stringCheck",
                //family_name = "stringCheck",
                //middle_name = "stringCheck",
                //preferred_username = "stringCheck",
                //profile = "stringCheck",
                //website = "stringCheck",
                //gender = "stringCheck",
                //birthdate = "stringCheck",
                //zoneinfo = "stringCheck",
                //locale = "stringCheck",
                //phone_number = "stringCheck",
                //updated_at = "stringCheck",
                //phone_number_verified = true,
                sub = "stringCheck",
                name = "stringCheck",
                nickname = "stringCheck",
                picture = "stringCheck",
                email = "stringCheck",
                email_verified = true
            };

            Assert.Equal("stringCheck", userProfile.sub);
            Assert.Equal("stringCheck", userProfile.name);
            //Assert.Equal(userProfile.given_name, "stringCheck");
            //Assert.Equal(userProfile.family_name, "stringCheck");
            //Assert.Equal(userProfile.middle_name, "stringCheck");
            Assert.Equal("stringCheck", userProfile.nickname);
            //Assert.Equal(userProfile.preferred_username, "stringCheck");
            //Assert.Equal(userProfile.profile, "stringCheck");
            Assert.Equal("stringCheck", userProfile.picture);
            //Assert.Equal(userProfile.website, "stringCheck");
            Assert.Equal("stringCheck", userProfile.email);
            //Assert.Equal(userProfile.gender, "stringCheck");
            //Assert.Equal(userProfile.birthdate, "stringCheck");
            //Assert.Equal(userProfile.zoneinfo, "stringCheck");
            //Assert.Equal(userProfile.locale, "stringCheck");
            //Assert.Equal(userProfile.phone_number, "stringCheck");
            //Assert.Equal(userProfile.updated_at, "stringCheck");
            //Assert.Equal(userProfile.phone_number_verified, true);
            Assert.True(userProfile.email_verified);
            
    }

    }
}
