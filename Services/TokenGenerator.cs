using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace APITryitter.Services
{
  public class TokenGenerator
  {
    public string Generate()
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor()
      {
        SigningCredentials = new SingningCredentials()
        {
          new SymmectricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret));
        }
      }
    }
  }
}