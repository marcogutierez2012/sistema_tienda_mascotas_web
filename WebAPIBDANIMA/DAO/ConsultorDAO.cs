using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class ConsultorDAO
    {
        private readonly string cadena;

        public ConsultorDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Consultor> ListarConsultores()
        {
            var listado = new List<Consultor>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_CONSULTOR");

            while (dr.Read())
            {
                listado.Add(new Consultor()
                {
                    codconsul = dr.GetString(0),
                    nomconsul = dr.GetString(1),
                    apeconsul = dr.GetString(2),
                    dni = dr.GetString(3),
                    correo = dr.GetString(4),
                    codesp = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Especialidad> ListarEspecialidad()
        {
            var listado = new List<Especialidad>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_ESPECIALIDAD");

            while (dr.Read())
            {
                listado.Add(new Especialidad()
                {
                    codesp = dr.GetInt32(0),
                    nomesp = dr.GetString(1)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Consultor> ListarConsultoresFiltro(string dato)
        {
            var listado = new List<Consultor>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_CONSULTOR_FILTRO", dato);

            while (dr.Read())
            {
                listado.Add(new Consultor()
                {
                    codconsul = dr.GetString(0),
                    nomconsul = dr.GetString(1),
                    apeconsul = dr.GetString(2),
                    dni = dr.GetString(3),
                    correo = dr.GetString(4),
                    codesp = dr.GetInt32(5),
                    eliminado = dr.GetString(6)
                });
            }
            dr.Close();

            return listado;
        }

        public Consultor BuscarConsultor(string codigo)
        {
            Consultor? buscado =
            ListarConsultores().Find(c => c.codconsul!.Equals(codigo));

            if (buscado == null)
                buscado = new Consultor();

            return buscado;
        }

        public string RegistrarConsultor(Consultor obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_REGISTRAR_CONSULTOR",
                    obj.nomconsul!, obj.apeconsul!, obj.dni!, obj.correo!, obj.codesp);

                return $"El Consultor {obj.nomconsul} {obj.apeconsul} fue registrado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarConsultor(Consultor obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ACTUALIZAR_CONSULTOR",
                    obj.nomconsul!, obj.apeconsul!, obj.dni!, obj.correo!, obj.codesp, obj.codconsul!);

                return $"El Consultor {obj.nomconsul} {obj.apeconsul} fue actualizado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarConsultor(Consultor obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ELIMINAR_CONSULTOR",
                    obj.codconsul!);

                return $"El Consultor {obj.nomconsul} {obj.apeconsul} fue eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
