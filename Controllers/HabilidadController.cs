using CursoNET.Models;
using CursoNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoNET.Controllers;

[ApiController]
[Route("api/user/{userId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int userId)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        return Ok(user.Habilidades);
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int userId, int habilidadId)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        var habilidad = user.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

        if (habilidad == null)
            return NotFound("El habilidad solicitado no existe");

        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int userId, HabilidadInsert habilidadInsert)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        var habilidadExistente = user.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if (habilidadExistente != null)
            return BadRequest("Ya existe otra habilidad con el mismo nombre");

        var maxHabilidad = user.Habilidades.Max(h => h.Id);

        var habilidadNueva = new Habilidad()
        {
            Id = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia
        };

        user.Habilidades.Add(habilidadNueva);

        return CreatedAtAction(nameof(GetHabilidad),
        new { userId = userId, habilidadId = habilidadNueva.Id },
        habilidadNueva
        );
    }

    [HttpPut("{habilidadId}")]
     public ActionResult<Habilidad> PutHabilidad(int userId, int habilidadId, HabilidadInsert habilidadInsert)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");

        var habilidadExistente = user.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if (habilidadExistente != null)
            return BadRequest("Ya existe otra habilidad con el mismo nombre");

        var habilidadMismoNombre = user.Habilidades?.FirstOrDefault(h => h.Id != habilidadId && h.Nombre == habilidadInsert.Nombre);

        if (habilidadMismoNombre != null)
            return BadRequest("Ya existe otra habilidad con el mismo nombre.");

        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

         return NoContent();
    }

    [HttpDelete("{habilidadId}")]
    public ActionResult<Habilidad> DeleteHabilidad(int userId, int habilidadId)
    {
        var user = UserDataStore.Current.Usuarios.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            return NotFound("El usuario solicitado no existe");
        
        var habilidadExiste = user.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);

        if (habilidadExiste != null)
            return BadRequest("Ya existe otra habilidad con el mismo nombre");

        user.Habilidades?.Remove(habilidadExiste);

        return NoContent();
    }
}
