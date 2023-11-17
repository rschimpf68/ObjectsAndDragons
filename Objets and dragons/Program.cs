using Objets_and_dragons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons
{
    class Program
    {
        static void Main()
        {
            //Ernst Adriel, Rifel Gerardo, Schimpf Ronald.
            // Crear los personajes segun la consigan
            Heroe heroe = new Heroe("Player", 100, new List<Rol> {  new Mago(new Hechizo(20)), new Guerrero(new Arma(5, 2)), }, 0);
            Monstruo monstruo1 = new Monstruo("Monstruo1", 35, new Arma(3,10));
            Monstruo monstruo2 = new Monstruo("Monstruo2", 35, new Arma(10,10));
            Monstruo monstruo3 = new Monstruo("Monstruo3", 35, new Arma(5,10));

            // Crear los bandos
            List<Personaje> bando1 = new List<Personaje> { heroe };
            List<Personaje> bando2 = new List<Personaje> { monstruo1, monstruo2, monstruo3 };

            // Crear e iniciar el juego
            Juego juego = new Juego(bando1, bando2);
            juego.Jugar();

            Console.ReadLine();
        }
    }
}
