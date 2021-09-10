using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyTrade.Helper.Authentication
{
    public  class AuthService
    {
        private readonly bool _isAuthenticationEnabled;
        private readonly string _issuer;
        private readonly string _audiance;
        private readonly string _securityKey;
        public AuthService(IConfiguration configuration)
        {
            var authConfigSection = configuration.GetSection("Authentication");
            _isAuthenticationEnabled = authConfigSection.GetValue<bool>("IsAuthenticationEnabled");
            _audiance = authConfigSection.GetValue<string>("ClientKeys");
            _issuer = authConfigSection.GetValue<string>("Issuer");
            _securityKey = authConfigSection.GetValue<string>("SecurityKey");

        }
        public void AddAuthentication(ref IServiceCollection services)
        {
            try
            {
                if (_isAuthenticationEnabled)
                {
                    var secret = Encoding.UTF8.GetBytes(_securityKey);
                    //Configure JWT Token Authentication
                    services.AddAuthentication(auth =>
                    {
                        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(token =>
                    {
                        token.RequireHttpsMetadata = false;
                        token.SaveToken = true;
                        token.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secret),
                            ValidateIssuer = true,
                            ValidIssuer = _issuer,
                            ValidateAudience = true,
                            ValidAudiences = _audiance.Split(","),
                            RequireExpirationTime = false,
                            ValidateLifetime = false
                        };
                    });
                }

            }
            catch (Exception ex)
            {
                //log
            }

        }
        public string GenerateToken(string ClientKey)
        {

            var secret = Encoding.UTF8.GetBytes(_securityKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var signature = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = ClientKey,
                SigningCredentials = signature,
                IssuedAt = DateTime.UtcNow,
                // Expires= DateTime.UtcNow.AddMinutes(10)
            };

            var sectoken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(sectoken);


        }
    }
}
