using Microsoft.AspNetCore.Mvc;

using SistemaGestionAPI.Models;

using SistemaGestionBussiness;

using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
  [HttpGet(Name = "ObtenerUsuarios")]
  public IActionResult ObtenerUsuarios()
  {
    var users = UsuarioBussiness.ListarUsuarios(Connection.DatabaseConnection);

    return users.Count == 0 ? NotFound() : Ok(users.ToArray());
  }

  [HttpGet("{id}")]
  public IActionResult ObtenerUsuarioPorId(int id)
  {
    var user = UsuarioBussiness.ObtenerUsuario(Connection.DatabaseConnection, id);

    return user.Id == 0 ? NotFound() : Ok(user);
  }

  [HttpPost(Name = "CrearUsuario")]
  public IActionResult CrearUsuario([FromBody] Usuario usuario)
  {
    return UsuarioBussiness.CrearUsuario(Connection.DatabaseConnection, usuario) == false ? NotFound() : Ok(usuario);
  }

  [HttpPut(Name = "ModificarUsuario")]
  public IActionResult ModificarUsuario([FromBody] Usuario usuario)
  {
    var user = UsuarioBussiness.ObtenerUsuario(Connection.DatabaseConnection, usuario.Id);

    return user.Id == 0 ? NotFound() : Ok(UsuarioBussiness.ModificarUsuario(Connection.DatabaseConnection, usuario));
  }

  [HttpDelete(Name = "EliminarUsuario")]
  public IActionResult EliminarUsuario([FromBody] int id)
  {
    var user = UsuarioBussiness.ObtenerUsuario(Connection.DatabaseConnection, id);

    return user.Id == 0 ? NotFound() : Ok(UsuarioBussiness.EliminarUsuario(Connection.DatabaseConnection, user));
  }
}