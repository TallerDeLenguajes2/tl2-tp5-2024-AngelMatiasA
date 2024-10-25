using System.Data.SQLite;
using Tp5Tienda.Models;

namespace Tp5Tienda.Repositorio
{
    public class ProductosRepositorio
    {
        private string connectionString = @"Data Source =  Tienda.db;Initial Catalog=Northwind;Integrated Security=true";

        public List<Productos> MostrarProductos()
        {
            List<Productos> productos = new List<Productos>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string queryString = @"SELECT * FROM Productos;";
                var command = new SQLiteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Productos();
                        producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                        producto.Descripcion = reader["Descripcion"].ToString();
                        producto.Precio = Convert.ToInt32(reader["Precio"]);
                        productos.Add(producto);
                    }
                }
                connection.Close();
            }

            if (productos.Count == 0)
            {
                return null;
            }

            return productos;
        }


    }
}
