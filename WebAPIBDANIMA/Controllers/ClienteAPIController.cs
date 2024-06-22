using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        private readonly ClienteDAO dao;

        public ClienteAPIController(ClienteDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<ClienteController>
        [HttpGet("GetCliente")]
        public List<Cliente> GetCliente()
        {
            return dao.ListarClientes();
        }

        [HttpGet("GetTipoCliente")]
        public List<TipoCliente> GetTipoCliente()
        {
            return dao.ListarTipoCliente();
        }

        // GET api/<ClienteController>/5
        [HttpGet("GetClienteFiltro/{dato}")]
        public List<Cliente> GetClienteFiltro(string dato)
        {
            return dao.ListarClienteFiltro(dato);
        }


        [HttpGet("GetClienteCodigo/{codigo}")]
        public Cliente GetClienteCodigo(string codigo)
        {
            return dao.BuscarCliente(codigo);
        }

        // POST api/<ClienteController>
        [HttpPost("PostCliente")]
        public string PostCliente([FromBody] Cliente obj)
        {
            return dao.RegistrarCliente(obj);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("PutCliente")]
        public string PutCliente([FromBody] Cliente obj)
        {
            return dao.ActualizarCliente(obj);
        }

        // DELETE api/<ClienteController>/5
        [HttpPost("DeleteCliente")]
        public string DeleteCliente([FromBody] Cliente obj)
        {
            return dao.EliminarCliente(obj);
        }
    }
}
