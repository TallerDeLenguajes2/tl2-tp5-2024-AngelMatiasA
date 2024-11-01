﻿using System.Data.SQLite;
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
        
        public PostProducto CrearProductos( PostProducto nuevoProducto)
        {
            int rowAffected = 0;
            if (nuevoProducto == null)
            {
                return null;
            }
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string queryString = @"INSERT INTO Productos VALUES (@Descripcion, @Precio);";
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@Descripcion", nuevoProducto.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@Precio", nuevoProducto.Precio));
                rowAffected = command.ExecuteNonQuery();
                connection.Close();
               
            }

            if (rowAffected == 0)
            {
                return null;
            }

            return nuevoProducto;
        }


    }
}
