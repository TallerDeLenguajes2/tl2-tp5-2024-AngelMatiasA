using System.Data.SQLite;
using Tp5Tienda.Models;

namespace Tp5Tienda.Repositorio
{
    public class PresupuestosRepository
    {
        private string connectionString = @"Data Source =  Tienda.db;Initial Catalog=Northwind;Integrated Security=true";

        public List<Presupuestos> MostrarPresupuestos()
        {
            List<Presupuestos> presupuestos = new List<Presupuestos>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string queryString = @"SELECT * FROM Presupuestos;";
                var command = new SQLiteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Presupuestos presupuesto = new Presupuestos();
                        presupuesto.IdPresupuesto = Convert.ToInt32(reader["Idpresupuesto"]);
                        presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                        presupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                        presupuestos.Add(presupuesto);
                    }
                }
                connection.Close();
            }

            if (presupuestos.Count == 0)
            {
                return null;
            }

            return presupuestos;
        }

    }
}
