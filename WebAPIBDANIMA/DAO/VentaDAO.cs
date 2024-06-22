using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class VentaDAO
    {
        private readonly string cadena;

        public VentaDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Venta> ListarVentas()
        {
            var listado = new List<Venta>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_VENTA");

            while (dr.Read())
            {
                listado.Add(new Venta()
                {
                    codventa = dr.GetString(0),
                    fecventa = dr.GetDateTime(1).ToString("dd/MM/yyyy"),
                    codtipoven = dr.GetInt32(2),
                    codcli = dr.GetString(3),
                    codemp = dr.GetString(4),
                    codconsul = dr.GetString(5),
                    total = dr.GetDecimal(6),
                    anulado = dr.GetString(7)
                });
            }
            dr.Close();

            return listado;
        }

        public List<TipoVenta> ListarTipoVenta()
        {
            var listado = new List<TipoVenta>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_TIPO_VENTA");

            while (dr.Read())
            {
                listado.Add(new TipoVenta()
                {
                    codtipoven = dr.GetInt32(0),
                    nomtipoven = dr.GetString(1)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Venta> ListarVentasFiltro(string filtro)
        {
            var listado = new List<Venta>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_VENTA_FILTRO", filtro);

            while (dr.Read())
            {
                listado.Add(new Venta()
                {
                    codventa = dr.GetString(0),
                    fecventa = dr.GetDateTime(1).ToString("dd/MM/yyyy"),
                    codtipoven = dr.GetInt32(2),
                    codcli = dr.GetString(3),
                    codemp = dr.GetString(4),
                    codconsul = dr.GetString(5),
                    total = dr.GetDecimal(6),
                    anulado = dr.GetString(7)
                });
            }
            dr.Close();

            return listado;
        }

        public Venta BuscarVenta(string codigo)
        {
            Venta? buscado =
            ListarVentas().Find(v => v.codventa!.Equals(codigo));

            if (buscado == null)
                buscado = new Venta();

            return buscado;
        }

        public List<Detalle> ListarDetalleVenta()
        {
            var listado = new List<Detalle>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_DETA_VENTA");

            while (dr.Read())
            {
                listado.Add(new Detalle()
                {
                    codventa = dr.GetString(0),
                    codprod = dr.GetString(1),
                    cantidad = dr.GetInt32(2),
                    total = dr.GetDecimal(3)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Detalle> ListarDetalleVentasFiltro(string filtro)
        {
            var listado = new List<Detalle>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_DETA_VENTA_FILTRO", filtro);

            while (dr.Read())
            {
                listado.Add(new Detalle()
                {
                    codventa = dr.GetString(0),
                    codprod = dr.GetString(1),
                    cantidad = dr.GetInt32(2),
                    total = dr.GetDecimal(3)
                });
            }
            dr.Close();

            return listado;
        }

        public Detalle BuscarDetalleVenta(string codigo)
        {
            Detalle? buscado =
            ListarDetalleVenta().Find(d => d.codventa!.Equals(codigo));

            if (buscado == null)
                buscado = new Detalle();

            return buscado;
        }

        public string GrabarVenta(Venta obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_GRABAR_BOL_VENTA",
                    obj.codtipoven!, obj.codcli!, obj.codemp!, obj.codconsul!, obj.total);

                return $"La Venta Nro: {obj.codventa} fue grabada correctamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AnularVenta(Venta obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ANULAR_BOL_VENTA",
                    obj.codventa!);

                return $"La Venta Nro: {obj.codventa} fue ANULADA correctamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GrabarDetalleVenta(Detalle obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_GRABAR_DETA_VENTA",
                    obj.codventa!, obj.codprod!, obj.cantidad!);

                return $"La Venta Nro: {obj.codventa} fue grabada correctamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
