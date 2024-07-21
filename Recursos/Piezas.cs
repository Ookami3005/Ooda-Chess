using System.Collections.Generic;

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

        public abstract List<Casilla> PosiblesMovimientos();

        public override abstract string ToString();
    }

    public class Peon : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Caballo : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Reina : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Torre : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Rey : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Alfil : Pieza{
        public  override List<Casilla> PosiblesMovimientos()
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    // Clase Peon (Ookami)
    // Clase Caballo (Ookami)
    // Clase Alfil (Amorcito)
    // Clase Torre (Cuchurrumin)
    // Clase Dama (Ookami) //Quien le dice dama mi todo naco?, es la Reina // Le decimos Dama los cultos bebe
    // Clase Rey (Pastelito)
}

// Bug (No tocar)
//Como que bug?
// Pues resulta que hay un bug con las versiones de esa clase y no existe para el compilador entonces la tenemos que hacer nosotros
//Pues no lo pongas y ya bro, poner bugs es malo, daah
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}
