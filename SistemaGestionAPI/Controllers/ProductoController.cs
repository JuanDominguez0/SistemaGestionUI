using Microsoft.AspNetCore.Mvc;

using SistemaGestionAPI.Models;

using SistemaGestionBussiness;

using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
  [HttpGet(Name = "ObtenerProductos")]
  public IActionResult ObtenerProductos()
  {
    var products = ProductoBussiness.ListarProductos(Connection.DatabaseConnection);

    return products.Count == 0 ? NotFound() : Ok(products.ToArray());
  }

  [HttpGet("{id}")]
  public IActionResult ObtenerProductoPorId(int id)
  {
    var product = ProductoBussiness.ObtenerProducto(Connection.DatabaseConnection, id);

    return product.Id == 0 ? NotFound() : Ok(product);
  }

  [HttpPost(Name = "CrearProducto")]
  public IActionResult CrearProducto([FromBody] Producto producto)
  {
    return ProductoBussiness.CrearProducto(Connection.DatabaseConnection, producto) == false ? NotFound() : Ok(producto);
  }

  [HttpPut(Name = "ModificarProducto")]
  public IActionResult ModificarProducto([FromBody] Producto producto)
  {
    var product = ProductoBussiness.ObtenerProducto(Connection.DatabaseConnection, producto.Id);

    return product.Id == 0 ? NotFound() : Ok(ProductoBussiness.ModificarProducto(Connection.DatabaseConnection, producto));
  }

  [HttpDelete(Name = "EliminarProducto")]
  public IActionResult EliminarProducto([FromBody] int id)
  {
    var product = ProductoBussiness.ObtenerProducto(Connection.DatabaseConnection, id);

    return product.Id == 0 ? NotFound() : Ok(ProductoBussiness.EliminarProducto(Connection.DatabaseConnection, product));
  }
}