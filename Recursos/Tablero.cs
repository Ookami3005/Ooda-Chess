using System;

/*
 * ******************************* OODA CHESS **************************************
 *
 * Autores:
 * - dannaliz
 * - Ookami5018
 *
 * En este archivo definimos una parte de los recursos que utlizaremos para Ooda Chess
 * Particularmente son aquellos que tienen que ver con el Tablero
 */
namespace Recursos
{

    /*
     * Clase Coordenada que modela las coordenadas tipicas de la notacion del ajedrez
     * Ejemplo (A4,B8,...)
     */
    public class Coordenada
    {

        /*
         * Enumeracion de las letras que representan las columnas del tablero
         * Van de la A hasta la H
         */
        public enum Letra
        {
            A=0,
            B=1,
            C=2,
            D=3,
            E=4,
            F=5,
            G=6,
            H=7
        }

        // Campo privado que almacena el numero de la fila del tablero
        // por qué le pones _ ?
        private int _fila;

        /*
         * Propiedad que regula el acceso y la modificacion a la fila del tablero
         * No entiendo para qué es estoOoOOOoOoO, o sea, sé que asigna los números que pusiste en la enumeración pasada, pero como xq?
         * tipo, ya lo hiciste en la enumeración Letra bro.
         */
        public int fila
        {
            get => _fila;
            init
            {
                if(value > -1 && value < 8){
                    _fila = value;
                }
                else{
                    throw new InvalidOperationException();
                }
            }
        }

        /*
         * Propiedad que representa la columna del tablero
         * Qué es get init? ununun
         */
        public Letra columna { get; init; }

        /*
         * Constructor parametrizado simple de una Coordenada del tablero
         */
        public Coordenada(int row, Letra column)
        {
            fila = row;
            columna = column;
        }

        /*
         * Metodo sobreescrito ToString que devuelve la notacion convencional de la Coordenada
         */
        public override string ToString()
        {
            return $"{this.columna}{this.fila+1}";
        }

    }

    /*
     * Clase Casilla que modela una casilla o escaque del tablero
     * A esto sí le entendí jijija
     */
    public class Casilla
    {
        /*
         * Propiedad Tono que indica de que color es la casilla
         * Solo puede asignarse durante la construccion del objeto
         */
        public Color Tono { get; init; }

        /*
         * Propiedad Coordenadas que indica que coordenadas se le asignan a esta casilla
         * Solo puede asignarse durante la construccion del objeto
         */
        public Coordenada Coordenadas { get; init; }

        /*
         * Constructor parametrizado simple de una Casilla con tono y coordenadas
         */
        public Casilla(Color tono, Coordenada coor)
        {
            Tono = tono;
            Coordenadas = coor;
        }
    }

    /*
     * Clase Tablero que modela un tablero de ajedrez
     */
    public class Tablero
    {
        // Campo privado donde se almacena la matriz que representa el tablero
        // xq pones la , dentro de []?
        private Casilla[,] matriz;

        /*
         * Propiedad Escaques que regula el acceso a la matriz representante del tablero
         * No entiendo, si la matriz es el tablero y los escaques el tamblero tmb xq son diferentes?
         */
        public Casilla[,] Escaques
        {
            get => matriz;
        }

        /*
         * Constructor por defecto que define una representacion de un Tablero convencional de ajedrez
         * (Tablero 8x8 con colores alternados)
         */
        public Tablero()
        {
            // Bandera que indicara que color asignarle a cada casilla
            bool turno = false;

            // Definimos una matriz 8x8
            //Xq la matriz se define hasta aca y no cuando la declaras al inicio
            matriz = new Casilla[8,8];

            // Iniciamos un bucle para recorrer la matriz
            for(int i=0; i < 8 ;i++){
                for(int j=0; j < 8 ;j++){

                    // Definimos el elemento de la Enumeracion color por asignar
                    Color color = turno ? Color.Blanco : Color.Negro;

                    // Creamos una nueva casilla en el matriz[i,j]
                    matriz[i,j] = new Casilla(color, new Coordenada( i, (Coordenada.Letra)j ));

                    // Alternamos el color para la siguiente casilla
                    turno = !turno;

                }

                // Alternamos el color con el que empieza la siguiente fila de casillas
                turno = !turno;
            }
        }
    }

    /*
     * Clase Programa para pruebas
     */
    public class Programa
    {

        /*
         * Metodo Main utilizado unicamente para probar y poder corregir errores con las clases que desarrollemos
         */
        public static void Main(string[] args)
        {

            /*
             * En esta seccion revise la correcta construccion de un objeto de la clase Tablero
             */
            Tablero mesa = new Tablero();
            for(int i=0; i<8 ; i++){
                for(int j=0; j<8 ;j++){
                    Console.WriteLine(mesa.Escaques[i,j].Coordenadas.ToString() + " " + $"{mesa.Escaques[i,j].Tono}");
                }
            }

        }
    }

}
