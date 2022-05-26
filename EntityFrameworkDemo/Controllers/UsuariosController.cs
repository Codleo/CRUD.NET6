using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Controllers
{
    [Route("API/v1/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UsuarioService _usuarioServices;

        public UsuarioController(UsuarioService usuarioServices, IUnitOfWork unitOfWork)
        {
            _usuarioServices = usuarioServices;
            _unitOfWork = unitOfWork;
        }
        // POST: api/usuario
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost]
        public ActionResult<Usuario> Postusuario(Usuario user)
        {
            _usuarioServices.Create(user);
            try
            {
                _unitOfWork.SaveChangesAsync().Wait();

            }
            catch (Exception)
            {
                if (UsuarioExists(user.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getusuario", new { Id = user.ID }, user);

        }

        // GET: api/usuario
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _usuarioServices.GetUsers();
        }

        // GET: api/usuario/5
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet("ID")]
        public ActionResult<Usuario> Getusuario(Guid id)
        {
            var usuario = _usuarioServices.Getuser(id);
            //var usuario = Getusuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/usuario/5
        [HttpPut("ID")]
        public IActionResult Putusuario(Guid id, Usuario usuario)
        {
            var updateUsuario = _usuarioServices.Getuser(id);
            //   var updateUsuario =Getusuario(id)
            try
            {
                updateUsuario.Email = usuario.Email;
                updateUsuario.Nome = usuario.Nome;
                updateUsuario.Telefone = usuario.Telefone;
                updateUsuario.Senha = usuario.Senha;
                _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateUsuario);
        }
        // DELETE: api/usuario/5
        [HttpDelete("ID")]
        public IActionResult DeleteUsuario(Guid id)
        {
            var usuario = _usuarioServices.Getuser(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioServices.DeleteUser(id);
            _unitOfWork.SaveChangesAsync();

            return Ok($"ID:{ usuario.ID} DELETADO");

        }

        private bool UsuarioExists(Guid id)
        {

            var user = _usuarioServices.Getuser(id);
            return user != null;
            //if (user == null ) A expressão de linha faz o que esses dois IFs fazem.
            //{
            //    return false;
            //}
            //if(user != null)
            //{
            //    return true;
            //}
        }
    }
}
