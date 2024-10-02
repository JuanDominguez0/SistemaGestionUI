using System.Data.SqlClient;

using SistemaGestionData;

using SistemaGestionEntities;

namespace SistemaGestionBussiness;

public class VentaBussiness
{
  public static Venta ObtenerVenta(SqlConnection connection, int id)
  {
    return VentaData.ObtenerVenta(connection, id);
  }

  public static List<Venta> ListarVentas(SqlConnection connection)
  {
    return VentaData.ListarVentas(connection);
  }

  public static bool CrearVenta(SqlConnection connection, Venta venta)
  {
    return VentaData.CrearVenta(connection, venta);
  }

  public static bool ModificarVenta(SqlConnection connection, Venta venta)
  {
    return VentaData.ModificarVenta(connection, venta);
  }

  public static bool EliminarVenta(SqlConnection connection, Venta venta)
  {
    return VentaData.EliminarVenta(connection, venta);
  }
}