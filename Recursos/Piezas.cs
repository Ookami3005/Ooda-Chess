namespace Recursos
{
    public enum Color
    {
        Blanco,
        Negro
    }

    public abstract class Pieza
    {

        public Color bando { get; init; }
        public Casilla posicion { get; set; }

        public abstract void posiblesMovimientos();

    }

    // Clase Peon (Ookami)
    // Clase Caballo (Ookami)
    // Clase Alfil (Amorcito)
    // Clase Torre (Cuchurrumin)
    // Clase Dama (Ookami)
    // Clase Rey (Pastelito)
}

// Bug (No tocar)
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}
