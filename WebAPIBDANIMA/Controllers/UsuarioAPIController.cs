using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        private readonly UsuarioDAO dao;

        public UsuarioAPIController(UsuarioDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<UsuarioAPIController>
        [HttpGet("GetUsuario")]
        public List<Usuario> GetUsuario()
        {
            return dao.ListarUsuarios();
        }

        [HttpGet("GetRol")]
        public List<Rol> GetRol()
        {
            return dao.ListarRoles();
        }

        // GET api/<UsuarioAPIController>/5
        [HttpGet("GetUsuarioFiltro/{usuario}")]
        public List<Usuario> GetUsuarioFiltro(string usuario)
        {
            return dao.ListarUsuariosFiltro(usuario);
        }

        [HttpGet("GetUsuarioCodigo/{codigo}")]
        public Usuario GetUsuarioCodigo(string codigo)
        {
            return dao.BuscarUsuario(codigo);
        }

        // POST api/<UsuarioAPIController>
        [HttpPost("PostUsuario")]
        public string PostUsuario([FromBody] Usuario obj)
        {
            return dao.RegistrarUsuario(obj);
        }

        // PUT api/<UsuarioAPIController>/5
        [HttpPut("PutUsuario")]
        public string PutUsuario([FromBody] Usuario obj)
        {
            return dao.ActualizarUsuario(obj);
        }

        // DELETE api/<UsuarioAPIController>/5
        [HttpPost("DeleteUsuario")]
        public string DeleteUsuario([FromBody] Usuario obj)
        {
            return dao.EliminarUsuario(obj);
        }
    }
}
