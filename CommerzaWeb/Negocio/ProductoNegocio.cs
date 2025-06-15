using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommerzaWeb.Datos;
using CommerzaWeb.Dominio;

namespace CommerzaWeb.Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProducto()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsuta("SELECT Id, Nombre, Descripcion, Precio, ImagenUrl, Stock FROM Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (String)datos.Lector["Nombre"];
                    producto.Descripcion = (String)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];
                    producto.Stock = (int)datos.Lector["Stock"];
                    producto.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}