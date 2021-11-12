using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros
{
    class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("Password=Luismars85;Persist Security Info=False;User ID=sa;Initial Catalog=Consultorio;Data Source=THEHOOLIGANS-V2");

        //Metodo para ver datos 
        public List<Registro> GetRegistros()
        {
            List<Registro> registro = new List<Registro>();
            try
            {
                conn.Open();
                string query = @" SELECT id_consulta, nombre_paciente, apellido_paciente, id_servicio, costo_servicio,fecha_consulta
                                FROM Registros";

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    registro.Add(new Registro
                    {
                        Id = int.Parse(reader["id_consulta"].ToString()),
                        Paciente = reader["nombre_paciente"].ToString(),
                        Apellidos = reader["apellido_paciente"].ToString(),
                        Servicio = reader["id_servicio"].ToString(),
                        Costo = reader["costo_servicio"].ToString(),
                        Fecha = reader["fecha_consulta"].ToString(),

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }

            return registro;
        }

        public void InsertRegistro(Registro registro)
        {
            try
            {
                conn.Open();
                string query = @"
                               INSERT INTO Registros(nombre_paciente, apellido_paciente, id_servicio, costo_servicio,fecha_consulta)
                               VALUES (@Paciente, @Apellidos, @Servicio, @Costo, @Fecha)
                                ";
                SqlParameter paciente = new SqlParameter();
                paciente.ParameterName = "@Paciente";
                paciente.Value = registro.Paciente;
                paciente.DbType = System.Data.DbType.String;

                SqlParameter apellidos = new SqlParameter("@Apellidos", registro.Apellidos);
                SqlParameter servicio = new SqlParameter("@Servicio", registro.Servicio);
                SqlParameter costo = new SqlParameter("@Costo", registro.Costo);
                SqlParameter fecha = new SqlParameter("@Fecha", registro.Fecha);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(paciente);
                command.Parameters.Add(apellidos);
                command.Parameters.Add(servicio);
                command.Parameters.Add(costo);
                command.Parameters.Add(fecha);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}