using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
       _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastrar(dto);
        return Ok("Usuário cadastrado.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token =  await _usuarioService.Login(dto);
        return Ok(token);
    }
}
