using Microsoft.AspNetCore.Mvc;
using WebAPIBDANIMA.DAO;
using WebAPIBDANIMA.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBDANIMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoAPIController : ControllerBase
    {
        private readonly ProductoDAO dao;

        public ProductoAPIController(ProductoDAO _dao)
        {
            dao = _dao;
        }

        // GET: api/<ProductoController>
        [HttpGet("GetProducto")]
        public List<Producto> GetProducto()
        {
            return dao.ListarProductos();
        }

        [HttpGet("GetTipoProducto")]
        public List<TipoProducto> GetTipoProducto()
        {
            return dao.ListarTipoProductos();
        }

        [HttpGet("GetAnimal")]
        public List<Animal> GetAnimal()
        {
            return dao.ListarAnimales();
        }

        // GET api/<ProductoController>/5
        [HttpGet("GetProductoFiltro/{dato}")]
        public List<Producto> GetProductoFiltro(string dato)
        {
            return dao.ListarProductosFiltro(dato);
        }

        [HttpGet("GetProductoCodigo/{codigo}")]
        public Producto GetProductoCodigo(string codigo)
        {
            return dao.BuscarProducto(codigo);
        }

        // POST api/<ProductoController>
        [HttpPost("PostProducto")]
        public string PostProducto([FromBody] Producto obj)
        {
            return dao.RegistrarProducto(obj);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("PutProducto")]
        public string PutProducto([FromBody] Producto obj)
        {
            return dao.ActualizarProducto(obj);
        }

        // DELETE api/<ProductoController>/5
        [HttpPost("DeleteProducto")]
        public string DeleteProducto([FromBody] Producto obj)
        {
            return dao.EliminarProducto(obj);
        }
    }
}
