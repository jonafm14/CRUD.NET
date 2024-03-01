using CursoNET.Models;

namespace CursoNET.Services;

public class UserDataStore
{
    public List<User> Usuarios {get; set;}

    public static UserDataStore Current {get;} = new UserDataStore();

    public UserDataStore()
    {
        Usuarios = new List<User>() {
            new User() {
                Id = 1,
                Nombre = "Jonatan",
                Apellido = "Musciachio",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                    Id = 1,
                    Nombre = "Saltar",
                    Potencia = Habilidad.EPotencia.Moderado
                    }
                }
            },
             new User() {
                Id = 2,
                Nombre = "Omar",
                Apellido = "Rodriguez",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                    Id = 1,
                    Nombre = "Saltar",
                    Potencia = Habilidad.EPotencia.Moderado
                    },
                    new Habilidad() {
                    Id = 2,
                    Nombre = "Caminar",
                    Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                    Id = 3,
                    Nombre = "Gritar",
                    Potencia = Habilidad.EPotencia.RePotente
                    }
                }, 
            },
            new User() {
                Id = 3,
                Nombre = "Candela",
                Apellido = "Giraudo",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                    Id = 1,
                    Nombre = "Nadar",
                    Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                    Id = 2,
                    Nombre = "Correr",
                    Potencia = Habilidad.EPotencia.Extremo
                    },
                    new Habilidad() {
                    Id = 3,
                    Nombre = "Vomitar",
                    Potencia = Habilidad.EPotencia.RePotente
                    }
                },
                
            }
        };
    }
}