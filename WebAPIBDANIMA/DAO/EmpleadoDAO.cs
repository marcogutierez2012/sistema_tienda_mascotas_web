using System.Data.SqlClient;
using WebAPIBDANIMA.Entidades;

namespace WebAPIBDANIMA.DAO
{
    public class EmpleadoDAO
    {
        private readonly string cadena;

        public EmpleadoDAO(IConfiguration config)
        {
            cadena = config.GetConnectionString("cone");
        }

        public List<Empleado> ListarEmpleados()
        {
            var listado = new List<Empleado>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_EMPLEADO");

            while (dr.Read())
            {
                listado.Add(new Empleado()
                {
                    codemp = dr.GetString(0),
                    nomemp = dr.GetString(1),
                    apeemp = dr.GetString(2),
                    dni = dr.GetString(3),
                    fecnac = dr.GetDateTime(4).ToString("dd/MM/yyyy"),
                    eliminado = dr.GetString(5)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Empleado> ListarEmpleadosFiltro(string dato)
        {
            var listado = new List<Empleado>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena, "SP_LISTAR_EMPLEADO_FILTRO", dato);

            while (dr.Read())
            {
                listado.Add(new Empleado()
                {
                    codemp = dr.GetString(0),
                    nomemp = dr.GetString(1),
                    apeemp = dr.GetString(2),
                    dni = dr.GetString(3),
                    fecnac = dr.GetDateTime(4).ToString("dd/MM/yyyy"),
                    eliminado = dr.GetString(5)
                });
            }
            dr.Close();

            return listado;
        }

        public Empleado BuscarEmpleado(string codigo)
        {
            Empleado? buscado =
            ListarEmpleados().Find(e => e.codemp!.Equals(codigo));

            if (buscado == null)
                buscado = new Empleado();

            return buscado;
        }

        public string RegistrarEmpleado(Empleado obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_REGISTRAR_EMPLEADO",
                    obj.nomemp!, obj.apeemp!, obj.dni!, obj.fecnac!);

                return $"El Empleado {obj.nomemp} {obj.apeemp} fue registrado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarEmpleado(Empleado obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ACTUALIZAR_EMPLEADO",
                    obj.nomemp!, obj.apeemp!, obj.dni!, obj.fecnac!, obj.codemp!);

                return $"El Empleado {obj.nomemp} {obj.apeemp} fue actualizado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarEmpleado(Empleado obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cadena, "SP_ELIMINAR_EMPLEADO",
                    obj.codemp!);

                return $"El Empleado {obj.nomemp} {obj.apeemp} fue eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
