using Microsoft.AspNetCore.Mvc;

using SistemaGestionAPI.Models;

using SistemaGestionBussiness;

using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentaController : ControllerBase
{
  [HttpGet(Name = "ObtenerVentas")]
  public IActionResult ObtenerVentas()
  {
    var sales = VentaBussiness.ListarVentas(Connection.DatabaseConnection);

    return sales.Count == 0 ? NotFound() : Ok(sales.ToArray());
  }

  [HttpGet("{id}")]
  public IActionResult ObtenerVentaPorId(int id)
  {
    var sale = VentaBussiness.ObtenerVenta(Connection.DatabaseConnection, id);

    return sale.Id == 0 ? NotFound() : Ok(sale);
  }

  [HttpPost(Name = "CargarVenta")]
  public IActionResult CargarVenta([FromBody] Venta venta)
  {
    return VentaBussiness.CrearVenta(Connection.DatabaseConnection, venta) == false ? NotFound() : Ok(venta);
  }

  [HttpPut(Name = "ModificarVenta")]
  public IActionResult ModificarVenta([FromBody] Venta venta)
  {
    var sale = VentaBussiness.ObtenerVenta(Connection.DatabaseConnection, venta.Id);

    return sale.Id == 0 ? NotFound() : Ok(VentaBussiness.ModificarVenta(Connection.DatabaseConnection, venta));
  }

  [HttpDelete(Name = "EliminarVenta")]
  public IActionResult EliminarVenta([FromBody] int id)
  {
    var sale = VentaBussiness.ObtenerVenta(Connection.DatabaseConnection, id);

    return sale.Id == 0 ? NotFound() : Ok(VentaBussiness.EliminarVenta(Connection.DatabaseConnection, sale));
  }
}