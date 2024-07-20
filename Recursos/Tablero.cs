using System;

namespace Recursos
{

    /*
     * Clase coordenada que representa las coordenadas tipicas de la notacion del ajedrez
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
        private int _fila;

        /*
         * Propiedad que regula el acceso y la modificacion a la fila del tablero
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
                    throw new System.InvalidOperationException();
                }
            }
        }

        // Propiedad que representa la columna del tablero
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

    public class Casilla
    {
        public Color Tono { get; init; }
        public Coordenada Coordenadas { get; init; }

        public Casilla(Color color, Coordenada coor)
        {
            Tono = color;
            Coordenadas = coor;
        }
    }

    public class Tablero
    {
        private Casilla[,] matriz;
        public Casilla[,] Escaques
        {
            get => matriz;
        }

        public Tablero()
        {
            bool turno = false;

            matriz = new Casilla[8,8];
            for(int i=0; i < 8 ;i++){
                for(int j=0; j < 8 ;j++){
                    Color color = turno ? Color.Blanco : Color.Negro;
                    matriz[i,j] = new Casilla(color, new Coordenada( i, (Coordenada.Letra)j ));
                    turno = !turno;
                }
                turno = !turno;
            }
        }
    }

    public class Programa
    {
        public static void Main(string[] args)
        {
            Tablero mesa = new Tablero();
            for(int i=0; i<8 ; i++){
                for(int j=0; j<8 ;j++){
                    Console.WriteLine(mesa.Escaques[i,j].Coordenadas.ToString() + " " + $"{mesa.Escaques[i,j].Tono}");
                }
            }
        }
    }

}
