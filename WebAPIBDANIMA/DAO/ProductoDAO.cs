using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class ProductoDAO
    {
        private readonly string cadena;

        public ProductoDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Producto> ListarProductos()
        {
            var listado = new List<Producto>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_PRODUCTO");

            while (dr.Read())
            {
                listado.Add(new Producto()
                {
                    codprod = dr.GetString(0),
                    desprod = dr.GetString(1),
                    preprod = dr.GetDecimal(2),
                    stkprod = dr.GetInt32(3),
                    codanimal = dr.GetInt32(4),
                    codtipopro = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public List<TipoProducto> ListarTipoProductos()
        {
            var listado = new List<TipoProducto>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_TIPO_PRODUCTO");

            while (dr.Read())
            {
                listado.Add(new TipoProducto()
                {
                    codtipopro = dr.GetInt32(0),
                    nomtipopro = dr.GetString(1)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Animal> ListarAnimales()
        {
            var listado = new List<Animal>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_ANIMALES");

            while (dr.Read())
            {
                listado.Add(new Animal()
                {
                    codanimal = dr.GetInt32(0),
                    nomanimal = dr.GetString(1)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Producto> ListarProductosFiltro(string dato)
        {
            var listado = new List<Producto>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_PRODUCTO_FILTRO", dato);

            while (dr.Read())
            {
                listado.Add(new Producto()
                {
                    codprod = dr.GetString(0),
                    desprod = dr.GetString(1),
                    preprod = dr.GetDecimal(2),
                    stkprod = dr.GetInt32(3),
                    codanimal = dr.GetInt32(4),
                    codtipopro = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public Producto BuscarProducto(string codigo)
        {
            Producto? buscado =
            ListarProductos().Find(p => p.codprod!.Equals(codigo));

            if (buscado == null)
                buscado = new Producto();

            return buscado;
        }

        public string RegistrarProducto(Producto obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_REGISTRAR_PRODUCTO",
                    obj.desprod!, obj.preprod!, obj.stkprod!, obj.codanimal!, obj.codtipopro);

                return $"El Producto {obj.desprod} fue registrado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarProducto(Producto obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ACTUALIZAR_PRODUCTO",
                    obj.desprod!, obj.preprod!, obj.stkprod!, obj.codanimal!, obj.codtipopro, obj.codprod!);

                return $"El Producto {obj.desprod} fue actualizado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarProducto(Producto obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ELIMINAR_PRODUCTO",
                    obj.codprod!);

                return $"El Producto {obj.desprod} fue eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
