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
        // - Para diferenciarlo de la propiedad publica de abajo, ademas por convencion de C#, asi se les pone a los campos privados
        private int _fila;

        /*
         * Propiedad que regula el acceso y la modificacion a la fila del tablero
         */
        /*
         * No entiendo para qué es estoOoOOOoOoO, o sea, sé que asigna los números que pusiste en la enumeración pasada, pero como xq?
         * tipo, ya lo hiciste en la enumeración Letra bro.
         *
         * - Las letras de arriba son exclusivamente para la columna, esto de fila es algo distinto, aqui me interesa que solo puedan asignar un numero entre 0 y 7
         */
        public int Fila
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
         * Propiedad autoimplementada que representa la columna del tablero
         */
        /*
         * Qué es get init? ununun
         * - Esto de aqui se llama propiedad autoimplementada, si ves arriba, yo implemente el get y el init, porque el init debia
         *   cumplir ciertas condiciones especiales, sin embargo para la columna no es necesario, si quisiera implementarlas
         *   seria trivialmente un get{return _columna} e init{_columna = value}. Poner el get; init; que puse abajo es una manera
         *   cortisima de escribir justamente eso
         *
         *   Tambien, un init es simplemente un set, solo que solo lo puedes usar en el constructor, pero es eso, un set
         */
        public Letra Columna { get; init; }

        /*
         * Constructor parametrizado simple de una Coordenada del tablero
         */
        public Coordenada(int row, Letra column)
        {
            Fila = row;
            Columna = column;
        }

        /*
         * Metodo sobreescrito ToString que devuelve la notacion convencional de la Coordenada
         */
        public override string ToString()
        {
            return $"{this.Columna}{this.Fila+1}";
        }

    }

    /*
     * Clase Casilla que modela una casilla o escaque del tablero
     */
    /*
     * A esto sí le entendí jijija
     * - <3
     */
    public class Casilla
    {
        /*
         * Propiedad Tono que indica de que color es la casilla
         * Solo puede asignarse durante la construccion del objeto
         */
        public Color Tono { get; init; }

        /*
         * Propiedad Trebejo que indica que Pieza esta colocada en esta casilla
         * Devuelve null en caso de no haber ninguna pieza en ese momento
         */
        public Pieza Trebejo {get; set;}

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
            Trebejo = null;
        }

    }

    /*
     * Clase Tablero que modela un tablero de ajedrez
     */
    public class Tablero
    {
        // Campo privado donde se almacena la matriz que representa el tablero

        // xq pones la , dentro de []?
        // - Asi se escriben las matrices en C#, seria el equivalente a Casilla[][] en java
        private Casilla[,] _matriz;

        /*
         * Propiedad Escaques que regula el acceso a la matriz representante del tablero
         */
        /*
         * No entiendo, si la matriz es el tablero y los escaques el tamblero tmb xq son diferentes?
         * - La matriz es un campo privado, y solo quiero poder modificarlo yo, entonces declare un "envoltorio"
         *   Escaques de solo lectura para regresarla si me la piden
         *
         *   Basicamente es como que solo le hice un getter y no un setter, y para no regresar el campo privado _matriz
         *   regreso el alter ego Escaques
         */
        public Casilla[,] Escaques
        {
            get => _matriz;
        }

        /*
         * Metodo MuestraCasilla que recibe como parametros una fila y una Letra y devuelve la Casilla correspondiente del tablero
         *
         * NOTA! Lo hice de tal manera que para los posibles movimientos podamos acceder a las casillas
         * realmente utilizadas en el tablero del juego, evitando comparaciones
         */
        public Casilla MuestraCasilla(int fila, Coordenada.Letra columna) => _matriz[fila,(int)columna];

        /*
         * Constructor por defecto que define una representacion de un Tablero convencional de ajedrez
         * (Tablero 8x8 con colores alternados)
         */
        public Tablero()
        {
            // Bandera que indicara que color asignarle a cada casilla
            bool turno = false;

            // Definimos una matriz 8x8

            // Xq la matriz se define hasta aca y no cuando la declaras al inicio
            // - Realmente da lo mismo, podrias declararla al inicio o aqui
            // Pero me gusta hacerlo aqui
            _matriz = new Casilla[8,8];

            // Iniciamos un bucle para recorrer la matriz
            for(int i=0; i < 8 ;i++){
                for(int j=0; j < 8 ;j++){

                    // Definimos el elemento de la Enumeracion Color por asignar
                    Color color = turno ? Color.Blanco : Color.Negro;

                    // Creamos una nueva casilla en el matriz[i,j]
                    _matriz[i,j] = new Casilla(color, new Coordenada( i, (Coordenada.Letra)j ));

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
            /*
            for(int i=0; i<8 ; i++){
                for(int j=0; j<8 ;j++){
                    Console.WriteLine(mesa.Escaques[i,j].Coordenadas.ToString() + " " + $"{mesa.Escaques[i,j].Tono}");
                }
            }
            */
            Pieza peon = new Peon(Color.Negro);
            mesa.Escaques[6,4].Trebejo = peon;
            Console.WriteLine(mesa.Escaques[6,4].Trebejo);
            foreach(Casilla moves in peon.PosiblesMovimientos(mesa.Escaques[6,4], mesa)){
                Console.WriteLine(moves.Coordenadas);
            }
        }
    }

}
