using WebAppPubs.Models.AuthorDTO;

namespace WebAppPubs.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(AuthorDTO user);
    }
}
