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
        public abstract List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual);

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
         * Metodo sobreescrito que devuelve los posibles movimientos de un peon respecto a una casilla actual
         *
         */
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            List<Casilla> lista = new List<Casilla>();
            lista = this.movimientosRegulares(tablero, actual, lista);
            lista = this.ataquesDiagonales(tablero, actual, lista);
            return lista;
        }

        /*
         * Metodo auxiliar que calcula los movimientos regulares de un Peon y agrega las casillas a la lista de movimientos
         * Es decir, avanzar una casilla hacia al frente o 2 si se encuentra en la segunda fila
         * de su respectivo bando.
         */
        private List<Casilla> movimientosRegulares(Tablero tablero, Casilla actual, List<Casilla> lista){
            int filaActual = actual.Coordenadas.Fila;
            bool esBlanco = this.Bando == Color.Blanco;
            int segundaFila = esBlanco ? 1 : 6, ultimaFila = esBlanco ? 7 : 0; //Es necesario definir todo esto siempre?
            int filaSiguiente = esBlanco ? filaActual+1 : filaActual-1;
            if(filaActual != ultimaFila){
                Casilla casillaSiguiente = tablero.MuestraCasilla(filaSiguiente,actual.Coordenadas.Columna);
                if(casillaSiguiente.Trebejo == null){
                    lista.Add(casillaSiguiente);
                }
            }

            if(lista.Count != 0 && filaActual == segundaFila){ //no le entendí a este
                int filaSiguienteSiguiente = esBlanco ? filaSiguiente+1 : filaSiguiente - 1;
                Casilla casillaSiguienteSiguiente = tablero.MuestraCasilla(filaSiguienteSiguiente,actual.Coordenadas.Columna);
                if(casillaSiguienteSiguiente.Trebejo == null){
                    lista.Add(casillaSiguienteSiguiente);
                }
            }
            return lista;
        }

        /*
         * Metodo auxiliar que calcula si el peon puede realizar movimientos en diagonal para atacar a otra pieza
         * Agrega las casillas a la lista de movimientos
         */
        private List<Casilla> ataquesDiagonales(Tablero tablero, Casilla actual, List<Casilla> lista){
            bool esBlanco = this.Bando == Color.Blanco;
            int filaSiguiente = esBlanco ? actual.Coordenadas.Fila+1 : actual.Coordenadas.Fila-1, columnaActual = (int)actual.Coordenadas.Columna;
            Casilla diagIzquierda = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual-1) > 0 ? tablero.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaActual-1)) : null;
            Casilla diagDerecha = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual+1) < 8 ? tablero.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaActual+1)) : null;
            if(diagIzquierda != null && diagIzquierda.Trebejo != null){
                lista.Add(diagIzquierda);
            }
            if(diagDerecha != null && diagDerecha.Trebejo != null){
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
        public Peon(Color color){
            this.Bando = color;
        }

    }

    public class Caballo : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            return null;

        }
  
        /*
         * Devuelve el caracter Unicode de un caballo del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2658" : "\u265E";

        /*
         * Constructor parametrizado simple de un caballo, definiendo su color
         */
        public Caballo(Color color){
            this.Bando = color;
        }
    }

    public class Dama : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            return null;

        }

        /*
         * Devuelve el caracter Unicode de un dama del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2655" : "\u265B";

        /*
         * Constructor parametrizado simple de una dama, definiendo su color
         */
        public Dama(Color color){
            this.Bando = color;
        }
    }

    public class Torre : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            return null;

        }

        /*
         * Devuelve el caracter Unicode de una torre del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2656" : "\u265C";

        /*
         * Constructor parametrizado simple de una torre, definiendo su color
         */
        public Torre(Color color){
            this.Bando = color;
        }
    }

    public class Rey : Pieza{
        /*
         * Metodo sobreescrito que devuelve los posibles movimientos del rey en el tablero
         *
         */
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            List<Casilla> lista = new List<Casilla>();
            lista = this.movimientosRegulares(tablero, actual, lista);
            lista = this.ataquesDiagonales(tablero, actual, lista);
            return lista;
        }

        /*
         * Metodo que agrega los movimientos en horizontal y vertical del rey a la lista de posibles movimientos.
         *
        */
        private List<Casilla> movimientosRegulares(Tablero tablero, Casilla actual, List<Casilla> lista){
            int filaActual = actual.Coordenadas.Fila;
            bool esBlanco = this.Bando == Color.Blanco;
            // -No ocupas estas variables
            int segundaFila = esBlanco ? 1 : 6, ultimaFila = esBlanco ? 7 : 0, primerFila = esBlanco ? 0 : 7;
            int columnaActual = (int)actual.Coordenadas.Columna;
            // -Mucho menos esta
            int filaSiguiente = esBlanco ? filaActual+1 : filaActual-1;

            //Movimientos verticales
            //Tengo un error en estoooooooooooooooo, es que o sea, cuando el rey no esta en la ultima o primera fila 
            //Todo jala bien, pero cuando esta en una de esas, no jalan los movimientos verticales, sé que basicamente ya
            //lo tengo porque tengo bien las diagonales, pero es que no entiendo xq no jalaA, cuando he tratado de corregirlo me 
            //aparece que se sale del index pero pero pero según yo noOoOo
            if(filaActual != ultimaFila){
                // - Tampoco ocupas esta
                int filaAnterior = esBlanco ? filaActual-1 : filaActual+1;
                // - Esta bien pero como usas los ternarios estas haciendo cosas extra
                Casilla casillaSiguiente = tablero.MuestraCasilla(filaSiguiente,actual.Coordenadas.Columna); 
                Casilla casillaAnterior = tablero.MuestraCasilla(filaAnterior, actual.Coordenadas.Columna);
                // Esta bien pero no revisas que no exceda la ultima fila
                if(casillaSiguiente.Trebejo == null){
                    lista.Add(casillaSiguiente);
                }
                // - Esto si esta bien
                if(filaActual != primerFila){
                    if(casillaAnterior.Trebejo == null){
                        lista.Add(casillaAnterior);
                    }
                }
            }

            //Movimientos horizontales
            // Bien
            Casilla izq = (columnaActual-1) > -1 ? tablero.MuestraCasilla(filaActual, (Coordenada.Letra)(columnaActual-1)) : null;
            Casilla der = (columnaActual+1) < 8 ? tablero.MuestraCasilla(filaActual, (Coordenada.Letra)(columnaActual+1)) : null;
            // - Lo que hiciste arriba ya esta cuidando que las columnas no excedan los limites, la condicional que debias checar es otra
            if(columnaActual != 0 ){
                lista.Add(izq);
            }
            // - Lo de arriba x2
            if(columnaActual != 8){
                lista.Add(der);
            }
            return lista;
        }

        //Movimientos diagonales
        private List<Casilla> ataquesDiagonales(Tablero tablero, Casilla actual, List<Casilla> lista){
            int filaActual = actual.Coordenadas.Fila;
            bool esBlanco = this.Bando == Color.Blanco;
            // Otra vez no ocupas todo esto
            int filaSiguiente = esBlanco ? actual.Coordenadas.Fila+1 : actual.Coordenadas.Fila-1, columnaActual = (int)actual.Coordenadas.Columna;
            int filaAnterior = esBlanco ? filaActual-1 : filaActual+1;
            Casilla diagDerechaSup = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual+1) < 8 ? tablero.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaActual+1)) : null;
            Casilla diagIzquierdaSup = (-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual-1) >-1 ? tablero.MuestraCasilla(filaSiguiente, (Coordenada.Letra)(columnaActual-1)) : null;
            Casilla diagDerInf = (-1 < filaAnterior) && (filaAnterior < 8) && (columnaActual+1) < 8 ? tablero.MuestraCasilla(filaAnterior, (Coordenada.Letra)(columnaActual+1)) : null;
            Casilla diagIzqInf = (-1 < filaAnterior) && (filaAnterior < 8) && (columnaActual-1) > -1 ? tablero.MuestraCasilla(filaAnterior, (Coordenada.Letra)(columnaActual-1)) : null;

            /*
             * - Para estas 4 condicionales: Lo de la linea 243 x4 (Debias condicionar otra cosa)
             */
            if((-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual+1) < 8 ){
                lista.Add(diagDerechaSup);
            }
            if((-1 < filaSiguiente) && (filaSiguiente < 8) && (columnaActual-1) >-1){
                lista.Add(diagIzquierdaSup);
            }
            if((-1 < filaAnterior) && (filaAnterior < 8) && (columnaActual+1) < 8 ){
                lista.Add(diagDerInf);
            }
            if((-1 < filaAnterior) && (filaAnterior < 8) && (columnaActual+1) < 8 ){
                lista.Add(diagIzqInf);
            }
            return lista;
        }

        /*
         * Devuelve el caracter Unicode de un rey del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2654" : "\u265A";

        /*
         * Constructor parametrizado simple de un Rey, definiendo su color
         */
        public Rey(Color color){
            this.Bando = color;
        }
    }



    public class Alfil : Pieza{
        public  override List<Casilla> PosiblesMovimientos(Tablero tablero, Casilla actual)
        {
            return null;

        }

        /*
         * Devuelve el caracter Unicode de un alfil del color correspondiente
         */
        public override string ToString() => this.Bando != Color.Blanco ? "\u2657" : "\u265D";

        /*
         * Constructor parametrizado simple de un alfil, definiendo su color
         */
        public Alfil(Color color){
            this.Bando = color;
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
