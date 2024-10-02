using System.Data.SqlClient;

using SistemaGestionData;

using SistemaGestionEntities;

namespace SistemaGestionBussiness;

public class ProductoVendidoBussiness
{
  public static ProductoVendido ObtenerProductoVendido(SqlConnection connection, int id)
  {
    return ProductoVendidoData.ObtenerProductoVendido(connection, id);
  }

  public static List<ProductoVendido> ListarProductosVendidos(SqlConnection connection)
  {
    return ProductoVendidoData.ListarProductosVendidos(connection);
  }

  public static bool CrearProductoVendido(SqlConnection connection, ProductoVendido product)
  {
    return ProductoVendidoData.CrearProductoVendido(connection, product);
  }

  public static bool ModificarProductoVendido(SqlConnection connection, ProductoVendido product)
  {
    return ProductoVendidoData.ModificarProductoVendido(connection, product);
  }

  public static bool EliminarProductoVendido(SqlConnection connection, ProductoVendido product)
  {
    return ProductoVendidoData.EliminarProductoVendido(connection, product);
  }
}