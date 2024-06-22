using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaAPIController : ControllerBase
    {
        private readonly VentaDAO dao;

        public VentaAPIController(VentaDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<VentaController>
        [HttpGet("GetVenta")]
        public List<Venta> GetVenta()
        {
            return dao.ListarVentas();
        }

        [HttpGet("GetTipoVenta")]
        public List<TipoVenta> GetTipoVenta()
        {
            return dao.ListarTipoVenta();
        }

        // GET api/<VentaController>/5
        [HttpGet("GetVentaFiltro/{dato}")]
        public List<Venta> GetVentaFiltro(string dato)
        {
            return dao.ListarVentasFiltro(dato);
        }

        [HttpGet("GetVentaCodigo/{codigo}")]
        public Venta GetVentaCodigo(string codigo)
        {
            return dao.BuscarVenta(codigo);
        }

        // POST api/<VentaController>
        [HttpPost("PostVenta")]
        public string PostVenta([FromBody] Venta obj)
        {
            return dao.GrabarVenta(obj);
        }

        // DELETE api/<VentaController>/5
        [HttpPost("DeleteVenta")]
        public string DeleteVenta([FromBody] Venta obj)
        {
            return dao.AnularVenta(obj);
        }

        [HttpGet("GetDetalleVenta")]
        public List<Detalle> GetDetalleVenta()
        {
            return dao.ListarDetalleVenta();
        }

        // GET api/<VentaController>/5
        [HttpGet("GetDetalleVentaFiltro/{dato}")]
        public List<Detalle> GetDetalleVentaFiltro(string dato)
        {
            return dao.ListarDetalleVentasFiltro(dato);
        }

        [HttpGet("GetDetalleVentaCodigo/{codigo}")]
        public Detalle GetDetalleVentaCodigo(string codigo)
        {
            return dao.BuscarDetalleVenta(codigo);
        }

        // POST api/<VentaController>
        [HttpPost("PostDetalleVenta")]
        public string PostDetalleVenta([FromBody] Detalle obj)
        {
            return dao.GrabarDetalleVenta(obj);
        }
    }
}
