using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Monstruo : Personaje
    {
        private Arma Arma;

        public Monstruo(string nombre, int vida, Arma arma) : base(nombre, vida)
        {
            Arma = arma;
        }      
        public override List<Habilidad> EquiparMejorHabilidad(List<Habilidad> habilidadesDisponibles)
        {
            List<Habilidad> habilidadesDisponiblesOrdenadas = habilidadesDisponibles.OrderByDescending(x => x.ObtenerDaño()).ToList();
            List<Habilidad> habilidadesParaEliminar = new List<Habilidad>();
            foreach(Habilidad habilidadDisponible in habilidadesDisponiblesOrdenadas)
            {
                if ( Arma.EsMejorQue(habilidadDisponible))
                {
                    Habilidad habilidadAnterior = CambiarHabilidad(habilidadDisponible);
                    Console.WriteLine($"({NombreYVida()}) ha equipado un arma con {Arma.MostrarHabilidad()}");
                    habilidadesDisponibles.Add(Arma);
                    habilidadesDisponibles.Remove(habilidadDisponible);                    
                }
            }
            foreach (Habilidad habilidadParaEliminar in habilidadesParaEliminar)
            {
                habilidadesDisponibles.Remove(habilidadParaEliminar);
            }
            return habilidadesDisponibles;

        }

        public override int ObtenerDaño()
        {
            return Arma.ObtenerDaño();
        }

        private Habilidad CambiarHabilidad(Habilidad nuevaHabilidad )
        {
            Habilidad habilidadAnterior = Arma;
            Arma = (Arma)nuevaHabilidad;
            return habilidadAnterior;

        }
        public override Habilidad DejarCaerHabilidad()
        {
            Arma arma = Arma;
            Arma = null;
            return arma;
        }

        public override void Atacar(Personaje objetivo)
        {
            if (Arma.NoEstaRota()) {                
                Arma.Atacar(objetivo,NombreYVida());
                return;
            }
            Console.WriteLine($"({NombreYVida()}) ataca a ({objetivo.NombreYVida()}) por 1 de daño");
            objetivo.RecibirDaño(1);            
        }
    }
}
