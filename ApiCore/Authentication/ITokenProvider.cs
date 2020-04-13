

namespace ApiCore.Authentication
{
    using ApiModel;
    using Microsoft.IdentityModel.Tokens;
    using System;
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
