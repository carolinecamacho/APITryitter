using APITryitter.Models;
namespace APITryitter.Services
{
  public interface ITokenService
  {
    string GerarToken(string key, string issuer, string audience, UserModel user);
  }
}