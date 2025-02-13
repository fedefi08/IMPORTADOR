using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importador
{
    internal class ImportarTransportes
    {
        public int IdTransporte { get; set; }
        public string Nombre { get; set; }
        public int Domicilio { get; set; }
        public string Localidad { get; set; }
        public int Cpostal { get; set; }
        public string Telefono { get; set; }
        public int Cuit { get; set; }
        public string Destino { get; set; }
        public int IdProvincia { get; set; }
        public string Patente { get; set; }

        private string SqlConnection;

        // Constructor que recibe la cadena de conexión
        public ImportarTransportes(string connectionString)
        {
            SqlConnection = connectionString;
        }

        public void Add(ImportarTransportes InsertarTransporte)
        {
            // Manejo de excepciones para evitar errores en tiempo de ejecución
            try
            {
                using (var connection = new SqlConnection(SqlConnection))
                {
                    // Consulta SQL
                    string query = "INSERT INTO transportes (idtransporte, nombre, Domicilio, Localidad, Cpostal, Telefono, cuit, Destinos, Idprovincia, Patente) " +
                                   "VALUES (@Idtransporte, @Nombre, @Domicilio, @Localidad, @Cpostal, @Telefono, @Cuit, @Destino, @Idprovincia, @Patente)";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Idtransporte", InsertarTransporte.IdTransporte);
                    command.Parameters.AddWithValue("@Nombre", InsertarTransporte.Nombre);
                    command.Parameters.AddWithValue("@Domicilio", InsertarTransporte.Domicilio);
                    command.Parameters.AddWithValue("@Localidad", InsertarTransporte.Localidad);
                    command.Parameters.AddWithValue("@Cpostal", InsertarTransporte.Cpostal);
                    command.Parameters.AddWithValue("@Telefono", InsertarTransporte.Telefono);
                    command.Parameters.AddWithValue("@Cuit", InsertarTransporte.Cuit);
                    command.Parameters.AddWithValue("@Destino", InsertarTransporte.Destino);
                    command.Parameters.AddWithValue("@Idprovincia", InsertarTransporte.IdProvincia);
                    command.Parameters.AddWithValue("@Patente", InsertarTransporte.Patente);

                    connection.Open(); // Abro la conexión
                    command.ExecuteNonQuery(); // Ejecuto el insert
                } // Cierro automáticamente la conexión al salir del bloque using
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


    }
}
