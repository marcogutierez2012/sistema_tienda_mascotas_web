using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultorAPIController : ControllerBase
    {
        private readonly ConsultorDAO dao;

        public ConsultorAPIController(ConsultorDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<ConsultorController>
        [HttpGet("GetConsultor")]
        public List<Consultor> GetConsultor()
        {
            return dao.ListarConsultores();
        }

        [HttpGet("GetEspecialidad")]
        public List<Especialidad> GetEspecialidad()
        {
            return dao.ListarEspecialidad();
        }

        // GET api/<ConsultorController>/5
        [HttpGet("GetConsultorFiltro/{dato}")]
        public List<Consultor> GetConsultorFiltro(string dato)
        {
            return dao.ListarConsultoresFiltro(dato);
        }

        [HttpGet("GetConsultorCodigo/{codigo}")]
        public Consultor GetConsultorCodigo(string codigo)
        {
            return dao.BuscarConsultor(codigo);
        }

        // POST api/<ConsultorController>
        [HttpPost("PostConsultor")]
        public string PostConsultor([FromBody] Consultor obj)
        {
            return dao.RegistrarConsultor(obj);
        }


        // PUT api/<ConsultorController>/5
        [HttpPut("PutConsultor")]
        public string PutConsultor([FromBody] Consultor obj)
        {
            return dao.ActualizarConsultor(obj);
        }

        // DELETE api/<ConsultorController>/5
        [HttpPost("DeleteConsultor")]
        public string DeleteConsultor([FromBody] Consultor obj)
        {
            return dao.EliminarConsultor(obj);
        }
    }
}
