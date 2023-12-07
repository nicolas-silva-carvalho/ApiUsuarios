using UsuariosApi.Models;

namespace UsuariosApi.Interfaces;
public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}
