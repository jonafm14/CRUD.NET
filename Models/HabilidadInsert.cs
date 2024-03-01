using static CursoNET.Models.Habilidad;

namespace CursoNET.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
}
