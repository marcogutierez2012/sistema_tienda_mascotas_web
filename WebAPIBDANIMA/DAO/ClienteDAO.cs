using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class ClienteDAO
    {
        private readonly string cadena;

        public ClienteDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Cliente> ListarClientes()
        {
            var listado = new List<Cliente>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_CLIENTE");

            while (dr.Read())
            {
                listado.Add(new Cliente()
                {
                    codcli = dr.GetString(0),
                    nomcli = dr.GetString(1),
                    doccli = dr.GetString(2),
                    dircli = dr.GetString(3),
                    correo = dr.GetString(4),
                    codtipocli = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public List<TipoCliente> ListarTipoCliente()
        {
            var listado = new List<TipoCliente>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_TIPO_CLIENTE");

            while (dr.Read())
            {
                listado.Add(new TipoCliente()
                {
                    codtipocli = dr.GetInt32(0),
                    nomtipocli = dr.GetString(1)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Cliente> ListarClienteFiltro(string dato)
        {
            var listado = new List<Cliente>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_CLIENTE_FILTRO", dato);

            while (dr.Read())
            {
                listado.Add(new Cliente()
                {
                    codcli = dr.GetString(0),
                    nomcli = dr.GetString(1),
                    doccli = dr.GetString(2),
                    dircli = dr.GetString(3),
                    correo = dr.GetString(4),
                    codtipocli = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public Cliente BuscarCliente(string codigo)
        {
            Cliente? buscado =
            ListarClientes().Find(c => c.codcli!.Equals(codigo));

            if (buscado == null)
                buscado = new Cliente();

            return buscado;
        }

        public string RegistrarCliente(Cliente obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_REGISTRAR_CLIENTE",
                    obj.nomcli!, obj.doccli!, obj.dircli!, obj.correo!, obj.codtipocli);

                return $"El Cliente {obj.nomcli} fue registrado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarCliente(Cliente obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ACTUALIZAR_CLIENTE",
                    obj.nomcli!, obj.doccli!, obj.dircli!, obj.correo!, obj.codtipocli!);

                return $"El Cliente {obj.nomcli} fue actualizado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarCliente(Cliente obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ELIMINAR_CLIENTE",
                    obj.codcli!);

                return $"El Cliente {obj.nomcli} fue eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
