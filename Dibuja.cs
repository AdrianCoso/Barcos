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
            //Dibujamos diez veces el mismo patrón de líneas y espacios
            for (int fila = 0; fila < 10; fila++)
            {
                Console.SetCursorPosition(x, y + (fila * 2));
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
                //Colocamos el cursor para la siguiente fila
                Console.SetCursorPosition(x, y + (fila * 2) + 1);

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("|   ");
                }
                Console.WriteLine("|");
                //Nos colocamos al final para cerrar el cuadro
                Console.SetCursorPosition(x, y + 20);
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("+---");

                }
                Console.WriteLine("+");
            }

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

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(x + (j * 4) + 1, y + (i * 2) + 1);
                    if (T.Mar[j, i] && T.CoordenadaEnBarcos(j, i))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (T.Mar[j, i] )
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
            Tablero.CoordenadaEnBarcos(B, x, y);


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(x + (j * 4) + 1, y + (i * 2) + 1);
                    if (Tablero.CoordenadaEnBarcos(B, j, i))
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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(x + (j * 4) + 1, y + (i * 2) + 1);
                    if (T.CoordenadaEnBarcos(j, i))
                        
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        
                    }
                    
                    else
                    
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (T.Mar[j, i])
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
