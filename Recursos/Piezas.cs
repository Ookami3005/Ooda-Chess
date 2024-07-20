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

        public abstract void toString();
    }

    public class Peon : Pieza{
    }

    public class Caballo : Pieza{
    }

    public class Alfil : Pieza{
    }

    public class Torre : Pieza{
    }

    public class Reina : Pieza{
    }

    public class Rey : Pieza{
    }
    
    // Clase Peon (Ookami)
    // Clase Caballo (Ookami)
    // Clase Alfil (Amorcito)
    // Clase Torre (Cuchurrumin)
    // Clase Dama (Ookami) //Quien le dice dama mi todo naco?, es la Reina
    // Clase Rey (Pastelito)
}

// Bug (No tocar)
//Como que bug?
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}
