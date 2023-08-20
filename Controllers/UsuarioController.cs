using Microsoft.AspNetCore.Mvc;
using System;

using SistemaOcorrencias.Models;

namespace SistemaOcorrencias.Controllers
{
    namespace MinhaApi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class UsuarioController : ControllerBase
        {
            // Não estou utilizando o EntityFramework para acesso ao banco de dado
            private static List<Usuario> _usuarios = new List<Usuario>();

            [HttpGet]
            public IEnumerable<Usuario> GetUsuarios()
            {
                // Retorna todos os Usuarios

                return _usuarios;
            }

            [HttpPost]
            public IActionResult CriarUsuario(Usuario usuario)
            {
                // Verificação de Usuario já criado
                var user = _usuarios.Find(u => u.cpf == usuario.cpf);
                if (user != null)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(GetUsuario), new { cpf = usuario.cpf }, usuario);
            }

            [HttpGet("{cpf}")]
            public ActionResult<Usuario> GetUsuario(UInt64 cpf)
            {
                // Retorna Usuario específico
                var usuario = _usuarios.Find(u => u.cpf == cpf);
                if (usuario == null)
                {
                    return NotFound();
                }
                return usuario;
            }
        }
    }
}
