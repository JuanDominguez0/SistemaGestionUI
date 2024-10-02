using Microsoft.AspNetCore.Mvc;

using SistemaGestionAPI.Models;

using SistemaGestionBussiness;

using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoVendidoController : ControllerBase
{
  [HttpGet(Name = "ObtenerProductosVendidos")]
  public IActionResult ObtenerProductosVendidos()
  {
    var prodVendidos = ProductoVendidoBussiness.ListarProductosVendidos(Connection.DatabaseConnection);

    return prodVendidos.Count == 0 ? NotFound() : Ok(prodVendidos.ToArray());
  }

  [HttpGet("{id}")]
  public IActionResult ObtenerProductoVendidoPorId(int id)
  {
    var prodVendido = ProductoVendidoBussiness.ObtenerProductoVendido(Connection.DatabaseConnection, id);

    return prodVendido.Id == 0 ? NotFound() : Ok(prodVendido);
  }

  [HttpPost(Name = "CargarProductoVendido")]
  public IActionResult CargarProductoVendido([FromBody] ProductoVendido productoVendido)
  {
    return ProductoVendidoBussiness.CrearProductoVendido(Connection.DatabaseConnection, productoVendido) == false ? NotFound() : Ok(productoVendido);
  }

  [HttpPut(Name = "ModificarProductoVendido")]
  public IActionResult ModificarProductoVendido([FromBody] ProductoVendido productoVendido)
  {
    var prodVendido = ProductoVendidoBussiness.ObtenerProductoVendido(Connection.DatabaseConnection, productoVendido.Id);

    return prodVendido.Id == 0 ? NotFound() : Ok(ProductoVendidoBussiness.ModificarProductoVendido(Connection.DatabaseConnection, productoVendido));
  }

  [HttpDelete(Name = "EliminarProductoVendido")]
  public IActionResult EliminarProductoVendido([FromBody] int id)
  {
    var prodVendido = ProductoVendidoBussiness.ObtenerProductoVendido(Connection.DatabaseConnection, id);

    return prodVendido.Id == 0 ? NotFound() : Ok(ProductoVendidoBussiness.EliminarProductoVendido(Connection.DatabaseConnection, prodVendido));
  }
}