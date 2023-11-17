using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    abstract class Personaje
    {
        protected string Nombre;
        protected int Vida;

        public Personaje(string nombre, int vida)
        {
            Nombre = nombre;
            Vida = vida;
        }

        public void RecibirDaño(int daño)
        {
            Vida -= daño;      
            if (Vida <= 0)
            {
                Vida = 0;
                Console.WriteLine($"{Nombre} ha muerto.");
            }
        }

        public abstract List<Habilidad> EquiparMejorHabilidad(List<Habilidad> habilidadesDisponibles);


        public abstract int ObtenerDaño();

        

        public abstract Habilidad DejarCaerHabilidad();
        public virtual string NombreYVida()
        {
            return $"{Nombre}: {Vida} HP";
        }   
        public bool EstaVivo()
        {
            return Vida > 0;
        }

        public abstract void Atacar(Personaje objetivo);
    }
}
