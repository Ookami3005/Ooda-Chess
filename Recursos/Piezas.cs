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

        public abstract void PosiblesMovimientos();

        public abstract void ToString();
    }

    public class Peon : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
    }

    public class Caballo : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
    }

    public class Reina : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
    }

    public class Torre : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
    }

    public class Rey : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
    }

    public class Alfil : Pieza{
        public  override void PosiblesMovimientos(){

        }

        public override void ToString(){

        }
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
