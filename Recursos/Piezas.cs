using System.Collections.Generic;

/*
 * ******************************* OODA CHESS **************************************
 *
 * Autores:
 * - dannaliz
 * - Ookami5018
 *
 * En este archivo definimos una parte de los recursos que utlizaremos para Ooda Chess
 * Particularmente son aquellos que tienen que ver con las Piezas del juego
 */
namespace Recursos
{

    /*
     * Enumeracion de los colores que pueden tener las piezas (y casillas)
     */
    public enum Color
    {
        Blanco,
        Negro
    }

    /*
     * Clase abstracta Pieza que modela las caracteristicas basicas de una pieza del ajedrez
     *
     * NOTA: Amor, decidi quitarle la propiedad Coordenada y pasarsela como parametro al metodo
     * Creo que es mas eficiente asi
     */
    public abstract class Pieza
    {

        /*
         * Propiedad que regula el acceso al Color de la pieza
         */
        public Color Bando { get; init; }

        /*
         * Metodo abstracto que deja abierta la implementacion de los movimientos de la pieza
         */
        public abstract List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero);

        /*
         * Metodo abstracto sobreescrito ToString que deja abierta la implementacion de la cadena de texto
         * que representa a cada pieza. Se hizo abstracto de manera que sea obligatorio implementarlo para clases derivadas
         */
        public override abstract string ToString();

    }

    /*
     * Clase Peon derivada de Pieza que modela las caracteristicas de un Peon del ajedrez
     *
     * NOTA!!! Me falta implementar el ataque diagonal del peon
     * Ademas falta pensar como implementar el comer al paso
     */
    public class Peon : Pieza{

        /*
         * Metodo sobreescrito que devuelve los posibles movimientos de un peon respecto a una casilla actual
         *
         * NOTA:
         * Esta implementado el avance de una casilla del peon y el avance de 2 casillas en caso de estar
         * en segunda fila
         */
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
        {
            List<Casilla> lista = new List<Casilla>();
            int filaActual = actual.Coordenadas.Fila;
            bool esBlanco = this.Bando == Color.Blanco;
            int segundaFila = esBlanco ? 1 : 6, ultimaFila = esBlanco ? 7 : 0;
            int filaSiguiente = esBlanco ? filaActual+1 : filaActual-1;
            if(filaActual != ultimaFila){
                lista.Add(tablero.MuestraCasilla(filaSiguiente,actual.Coordenadas.Columna));
            }
            if(filaActual == segundaFila){
                lista.Add(tablero.MuestraCasilla((filaSiguiente+1),actual.Coordenadas.Columna));
            }
            return lista;
        }

        /*
         * Devuelve el caracter Unicode de un peon del color correspondiente
         *
         * NOTA: Devuelvo el blanco cuando me piden el negro y viceversa
         * Es que el peon blanco es "transparente" entonces por el fondo de la terminal se ve negro
         * Y el negro es de color solido entonces es completamente blanco
         * XD
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u265F" : "\u2659";

        /*
         * COnstructor parametrizado simple de un Peon, definiendo su color
         */
        public Peon(Color color){
            this.Bando = color;
        }

    }

    public class Caballo : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Dama : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Torre : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Rey : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
        {
            return null;

        }

        public override string ToString()
        {
            return "";
        }
    }

    public class Alfil : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Casilla actual, Tablero tablero)
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
// - Pues resulta que hay un bug con las versiones de esa clase y no existe para el compilador entonces la tenemos que hacer nosotros
//Pues no lo pongas y ya bro, poner bugs es malo, daah
// - Si no la pongo no compila amor
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}
