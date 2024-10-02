using System.Data.SqlClient;

using SistemaGestionData;

using SistemaGestionEntities;

namespace SistemaGestionBussiness;

public class UsuarioBussiness
{
  public static Usuario ObtenerUsuario(SqlConnection connection, int id)
  {
    return UsuarioData.ObtenerUsuario(connection, id);
  }

  public static List<Usuario> ListarUsuarios(SqlConnection connection)
  {
    return UsuarioData.ListarUsuarios(connection);
  }

  public static bool CrearUsuario(SqlConnection connection, Usuario user)
  {
    return UsuarioData.CrearUsuario(connection, user);
  }

  public static bool ModificarUsuario(SqlConnection connection, Usuario user)
  {
    return UsuarioData.ModificarUsuario(connection, user);
  }

  public static bool EliminarUsuario(SqlConnection connection, Usuario user)
  {
    return UsuarioData.EliminarUsuario(connection, user);
  }
}