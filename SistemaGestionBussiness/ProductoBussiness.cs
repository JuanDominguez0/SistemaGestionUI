using System.Data.SqlClient;

using SistemaGestionData;

using SistemaGestionEntities;

namespace SistemaGestionBussiness;

public class ProductoBussiness
{
  public static Producto ObtenerProducto(SqlConnection connection, int id)
  {
    return ProductoData.ObtenerProducto(connection, id);
  }

  public static List<Producto> ListarProductos(SqlConnection connection)
  {
    return ProductoData.ListarProductos(connection);
  }

  public static bool CrearProducto(SqlConnection connection, Producto product)
  {
    return ProductoData.CrearProducto(connection, product);
  }

  public static bool ModificarProducto(SqlConnection connection, Producto product)
  {
    return ProductoData.ModificarProducto(connection, product);
  }

  public static bool EliminarProducto(SqlConnection connection, Producto product)
  {
    return ProductoData.EliminarProducto(connection, product);
  }
}