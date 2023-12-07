using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Interfaces;
public interface IUsuarioService
{
    Task Cadastrar(CreateUsuarioDto dto);
    Task<string> Login(LoginUsuarioDto dto);
}
