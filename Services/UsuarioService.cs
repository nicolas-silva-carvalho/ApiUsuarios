using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ITokenService _tokenService;
        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            var result = await _userManager.CreateAsync(usuario, dto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if(!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token =_tokenService.GenerateToken(usuario);

            return token;
        }
    }
}