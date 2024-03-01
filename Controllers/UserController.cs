using CursoNET.Models;
using CursoNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    //Actions
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(UserDataStore.Current.Usuarios);
    }

    [HttpGet("{userId}")]
    public ActionResult<User> GetUser(int userId)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        return Ok(user);

    }

    [HttpPost]
    public ActionResult<User> PostMandril(UserInsert userInsert)
    {
        var maxUserId = UserDataStore.Current.Usuarios.Max(x => x.Id);

        var usuarioNuevo = new User() {
            Id = maxUserId + 1,
            Nombre = userInsert.Nombre,
            Apellido = userInsert.Apellido
        };

        UserDataStore.Current.Usuarios.Add(usuarioNuevo);

        return CreatedAtAction(nameof(GetUser),
            new { userId = usuarioNuevo.Id },
            usuarioNuevo
        );
    }

    [HttpPut("{userId}")]
    public ActionResult<User> PutUser(int userId, UserInsert userInsert)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        user.Nombre = userInsert.Nombre;
        user.Apellido = userInsert.Apellido;

        return NoContent();

    }

    [HttpDelete("{userId}")]
    public ActionResult<User> DeleteUser(int userId)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        UserDataStore.Current.Usuarios.Remove(user);

        return NoContent();
    }

};
