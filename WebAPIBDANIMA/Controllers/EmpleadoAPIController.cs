using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoAPIController : ControllerBase
    {
        private readonly EmpleadoDAO dao;

        public EmpleadoAPIController(EmpleadoDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<EmpleadoController>
        [HttpGet("GetEmpleado")]
        public List<Empleado> GetEmpleado()
        {
            return dao.ListarEmpleados();
        }

        // GET: api/<EmpleadoController>
        [HttpGet("GetEmpleadoFiltro/{dato}")]
        public List<Empleado> GetEmpleadoFiltro(string dato)
        {
            return dao.ListarEmpleadosFiltro(dato);
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("GetEmpleadoCodigo/{codigo}")]
        public Empleado GetEmpleadoCodigo(string codigo)
        {
            return dao.BuscarEmpleado(codigo);
        }

        // POST api/<EmpleadoController>
        [HttpPost("PostEmpleado")]
        public string PostEmpleado([FromBody] Empleado obj)
        {
            return dao.RegistrarEmpleado(obj);
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("PutEmpleado")]
        public string PutEmpleado([FromBody] Empleado obj)
        {
            return dao.ActualizarEmpleado(obj);
        }

        // DELETE api/<EmpleadoController>/5
        [HttpPost("DeleteEmpleado")]
        public string DeleteEmpleado([FromBody] Empleado obj)
        {
            return dao.EliminarEmpleado(obj);
        }
    }
}
