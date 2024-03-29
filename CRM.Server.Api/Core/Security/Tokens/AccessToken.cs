using System;
using System.Collections.Generic;
 
namespace CRM.Server.Web.Api.Core.Security.Tokens
{
    public class AccessToken : JsonWebToken
    {
        public RefreshToken RefreshToken { get; private set; }

        public AccessToken(string token, long expiration, RefreshToken refreshToken,List<string> roles) : base(token, expiration,roles)
        {
            if(refreshToken == null)
                throw new ArgumentException("Specify a valid refresh token.");
                
            RefreshToken = refreshToken;
        }
    }
}