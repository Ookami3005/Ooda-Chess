using System.Collections.Generic;

/*
 * ******************************* OODA CHESS **************************************
 *
 * Autores:
 * - dannaliz
 * - Ookami5018
 * - juanchoeh
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
     */
    public abstract class Pieza
    {

        /*
         * Propiedad que regula el acceso al Color de la pieza
         */
        public Color Bando { get; init; }

        /*
         * Propiedad que regula el acceso al Tablero en el que se encuentra la Pieza
         */
        public Tablero Mesa { get; init;}

        /*
         * Propiedad que regula el acceso a la casilla actual de la Pieza
         */
        public Casilla PosicionActual {get; set;}

        /*
         * Metodo abstracto que deja abierta la implementacion de los movimientos de la pieza
         */
        public abstract List<Casilla> PosiblesMovimientos();

        /*
         * Metodo abstracto sobreescrito ToString que deja abierta la implementacion de la cadena de texto
         * que representa a cada pieza. Se hizo abstracto de manera que sea obligatorio implementarlo para clases derivadas
         */
        public override abstract string ToString();

    }

    /*
     * Clase Peon derivada de Pieza que modela las caracteristicas de un Peon del ajedrez
     *
     * Falta pensar como implementar el comer al paso
     */
    public class Peon : Pieza{

        /*
         * Metodo sobreescrito que devuelve los posibles movimientos de un peon respecto a una casilla PosicionActual
         *
         */
        public  override List<Casilla> PosiblesMovimientos()
        {
            List<Casilla> lista = new();

            lista = this.movimientosRegulares(lista);
            lista = this.ataquesDiagonales(lista);

            return lista;
        }

        /*
         * Metodo auxiliar que calcula los movimientos regulares de un Peon y agrega las casillas a la lista de movimientos
         * Es decir, avanzar una casilla hacia al frente o 2 si se encuentra en la segunda fila
         * de su respectivo bando.
         */
        private List<Casilla> movimientosRegulares(List<Casilla> lista)
        {
            int filaActual = this.PosicionActual.Coordenadas.Fila;
            bool esBlanco = this.Bando == Color.Blanco;
            int segundaFila = esBlanco ? 1 : 6, ultimaFila = esBlanco ? 7 : 0;
            int filaSiguiente = esBlanco ? filaActual+1 : filaActual-1;

            /*
             * Mientras el peon no se encuentre en la ultima fila, consulta si la casilla siguiente esta vacia
             * y en caso de estarlo, la agrega a la lista de movimientos
             */
            if(filaActual != ultimaFila)
            {
                Casilla casillaSiguiente = this.Mesa.MuestraCasilla(filaSiguiente, this.PosicionActual.Coordenadas.Columna);

                if(casillaSiguiente.Trebejo == null)
                {
                    lista.Add(casillaSiguiente);
                }
            }

            /*
             * Si el peon se encuentra en la segunda fila y ya se ha agregado una casilla a la lista
             * (es decir, se pudo agregar la casilla siguiente), entonces se revisa si hay una pieza en la segunda casilla
             * y de no haber, se agrega a la lista de movimientos
             */
            if(lista.Count != 0 && filaActual == segundaFila)
            {
                int filaSiguienteSiguiente = esBlanco ? filaSiguiente+1 : filaSiguiente - 1;
                Casilla casillaSiguienteSiguiente = this.Mesa.MuestraCasilla(filaSiguienteSiguiente, this.PosicionActual.Coordenadas.Columna);

                if(casillaSiguienteSiguiente.Trebejo == null)
                {
                    lista.Add(casillaSiguienteSiguiente);
                }
            }

            return lista;
        }

        /*
         * Metodo auxiliar que calcula si el peon puede realizar movimientos en diagonal para atacar a otra pieza
         * Agrega las casillas a la lista de movimientos
         */
        private List<Casilla> ataquesDiagonales(List<Casilla> lista)
        {
            bool esBlanco = this.Bando == Color.Blanco;
            int filaSiguiente = esBlanco ? PosicionActual.Coordenadas.Fila+1 : PosicionActual.Coordenadas.Fila-1, columnaPosicionActual = (int)PosicionActual.Coordenadas.Columna;
            Casilla diagIzquierda = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaPosicionActual-1) > 0 ? this.Mesa.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaPosicionActual-1)) : null;
            Casilla diagDerecha = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaPosicionActual+1) < 8 ? this.Mesa.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaPosicionActual+1)) : null;

            if(diagIzquierda != null && diagIzquierda.Trebejo != null)
            {
                lista.Add(diagIzquierda);
            }

            if(diagDerecha != null && diagDerecha.Trebejo != null)
            {
                lista.Add(diagDerecha);
            }

            return lista;
        }

        /*
         * Devuelve el caracter Unicode de un peon del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2659" : "\u265F";

        /*
         * Constructor parametrizado simple de un Peon, definiendo su color
         */
        public Peon(Color color, Tablero mesa){
            this.Bando = color;
            this.Mesa = mesa;
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

    public class Dama : Pieza{
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
    // Clase Dama (Juan)
    // Clase Rey (Pastelito (evidentemente Juan))
}
