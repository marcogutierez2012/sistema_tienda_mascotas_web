using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class UsuarioDAO
    {
        private readonly string cadena;

        public UsuarioDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Usuario> ListarUsuarios()
        {
            var listado = new List<Usuario>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_USUARIO");

            while (dr.Read())
            {
                listado.Add(new Usuario()
                {
                    codusu = dr.GetInt32(0),
                    usuario = dr.GetString(1),
                    clave = dr.GetString(2),
                    codrol = dr.GetInt32(3),
                    codemp = dr.GetString(4),
                    eliminado = dr.GetString(5)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Rol> ListarRoles()
        {
            var listado = new List<Rol>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_ROLES");

            while (dr.Read())
            {
                listado.Add(new Rol()
                {
                    codrol = dr.GetInt32(0),
                    nomrol = dr.GetString(1),
                });
            }
            dr.Close();

            return listado;
        }

        public List<Usuario> ListarUsuariosFiltro(string usuario)
        {
            var listado = new List<Usuario>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_USUARIO_FILTRO", usuario);

            while (dr.Read())
            {
                listado.Add(new Usuario()
                {
                    codusu = dr.GetInt32(0),
                    usuario = dr.GetString(1),
                    clave = dr.GetString(2),
                    codrol = dr.GetInt32(3),
                    codemp = dr.GetString(4),
                    eliminado = dr.GetString(5)
                });
            }
            dr.Close();

            return listado;
        }

        public Usuario BuscarUsuario(string codigo)
        {
            Usuario? buscado =
            ListarUsuarios().Find(u => u.codusu!.Equals(codigo));

            if (buscado == null)
                buscado = new Usuario();

            return buscado;
        }

        public string RegistrarUsuario(Usuario obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_REGISTRAR_USUARIO",
                    obj.usuario!, obj.clave!, obj.codrol!, obj.codemp!);

                return $"El Usuario {obj.usuario} fue registrado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarUsuario(Usuario obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ACTUALIZAR_USUARIO",
                    obj.usuario!, obj.clave!, obj.codrol!, obj.codemp!, obj.codusu!);

                return $"El Usuario {obj.usuario} fue actualizado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarUsuario(Usuario obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ELIMINAR_USUARIO",
                    obj.codusu!);

                return $"El Usuario {obj.usuario} fue eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
