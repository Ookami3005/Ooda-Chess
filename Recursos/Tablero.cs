namespace Recursos
{
    public class Coordenada
    {

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

        private int _fila;
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

        public Letra columna { get; init; }

        public Coordenada(int row, Letra column)
        {
            fila = row;
            columna = column;
        }

    }

    public class Casilla
    {
        public Color tono { get; init; }
        public Coordenada posicion { get; init; }

        public Casilla(Color color, Coordenada coor)
        {
            tono = color;
            posicion = coor;
        }
    }

    public class Programa
    {
        public static void Main(string[] args)
        {
            Coordenada primera = new Coordenada(5,Coordenada.Letra.E);
            System.Console.WriteLine(primera.columna);
            System.Console.WriteLine(primera.fila);

            // primera.fila = 7;

            Casilla sed = new Casilla(Color.Blanco, primera);
            System.Console.WriteLine(sed.tono);
            System.Console.WriteLine(sed.posicion.fila);

        }
    }

}
