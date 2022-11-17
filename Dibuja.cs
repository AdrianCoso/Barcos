using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir
{
    public class Dibuja
    //Se crean los métodos para dibujar en consola: Tablero usuario, tablero máquina y tablero final
    //Se puede utilizar cualquier método creado en las clases Barco, Tablero
    {

        //Dibuja el entorno del tablero. Recibe dos enteros que representan la posición en la que queremos que quede el tablero
        public static void DibujaCuadro(int x, int y)
        {
            //Opcional. Para dibujar los bordes del tablero. x e y representan la posición en la que quiero que 
            //aparezca el tablero
            //Primero escribimos el número de columnas para ayudarnos a identificar las coordenadas de cada casilla
            Console.SetCursorPosition(x + 1, y);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("| " + i + " ");
            }
            Console.WriteLine("|");
            //Dibujamos diez veces el mismo patrón de líneas y espacios
            for (int fila = 0; fila < 10; fila++)
            {
                Console.SetCursorPosition(x+1, y + (fila * 2)+1);
                //Primero ponemos una línea para la parte superior de cada fila
                dibujaLinea();
                //Colocamos el cursor para la siguiente fila
                Console.SetCursorPosition(x, y + (fila * 2) + 2);
                //Escribimos el número de fila para ayudar a identificar las coordenadas de cada casilla
                Console.Write(fila);

                for (int columna = 0; columna < 10; columna++)
                {
                    Console.Write("|   ");
                }
                Console.WriteLine("|");
                //Dibujamos una línea más al final para cerrar el cuadro
                Console.SetCursorPosition(x + 1, y + 21);
                dibujaLinea();
            }

        }
        /**
         * public static void dibujaLinea()
         * 
         * Escribe una sucesión de "+" y "-" para dibujar la parte superior de cada fila
         */
        private static void dibujaLinea()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");
        }

        //Representa el tablero de juego de un jugador
        public static void TableroJuegoUsuario(Tablero T, int x, int y)
        {
            //Este método se llamaba tableroJuego
            //Debe dibujar: Gris si una coordenada no ha sido elegida por el usuario
            //              Rojo si el usuario ha elegido una coordenada y esa coordenada es barco
            //              Azul si el usuario ha elegido una coordenada y esa coordenada es agua
            //x e y representan la posición en la que quiero que aparezca el tablero


            //Tablero.Mar --> Array bidireccional en donde cada compoente vale true or false en función de 
            //si el usuario ha elegido una coordenada determinada
            //Tablero.Barcos --> Array de barcos

            //Para dibujar agua o barco puede convenir utilizar el método  CoordenadaEnBarcos de la clase Tablero

            for (int fila = 0; fila < 10; fila++)
            {
                for (int columna = 0; columna < 10; columna++)
                {
                    Console.SetCursorPosition(x + (columna * 4) + 2, y + (fila * 2) + 2);
                    if (T.Mar[columna, fila] && T.CoordenadaEnBarcos(columna, fila))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (T.Mar[columna, fila] )
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    Console.Write("   ");
                    Console.ResetColor();

                }
            }
        }

        //Representa el tablero final de un jugador/máquina
        public static void DibujaFinal(Barco [] B, int x, int y)
        {
            //Debe dibujar:
            //              Rojo si una coordenada es barco
            //              Azul si si una coordenada es agua
            //x e y representan la posición en la que quiero que aparezca el tablero

            //B --> Array de barcos

            //Para dibujar agua o barco puede convenir utilizar el método CoordenadaEnBarcos (static) de la clase tablero
            
            for (int fila = 0; fila < 10; fila++)
            {
                for (int columna = 0; columna < 10; columna++)
                {
                    Console.SetCursorPosition(x + (columna * 4) + 2, y + (fila * 2) + 2);
                    if (Tablero.CoordenadaEnBarcos(B, columna, fila))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write("   ");
                    Console.ResetColor();
                }
            }

        }

        //Representa el tablero de juego de la maquina
        public static void TableroJuegoMaquina(Tablero T, int x, int y)
        //Debe dibujar:
        //              Rojo si una coordenada es barco
        //              Azul si si una coordenada es agua
        //              X si una coordenada ha sido elegida por la máquina
        //x e y representan la posición en la que quiero que aparezca el tablero

        //B --> Array de barcos

        //Para dibujar agua o barco puede convenir utilizar el método creaBarco de la clase Barco
        {
            for (int fila = 0; fila < 10; fila++)
            {
                for (int columna = 0; columna < 10; columna++)
                {
                    Console.SetCursorPosition(x + (columna * 4) + 2, y + (fila * 2) + 2);
                    if (T.CoordenadaEnBarcos(columna, fila))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (T.Mar[columna, fila])
                    {
                        Console.Write(" X ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.ResetColor();

                    
                }
                   

                
            }

        }
    }
}
