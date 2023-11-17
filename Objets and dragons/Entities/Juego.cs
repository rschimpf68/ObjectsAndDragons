using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Juego
    {
        private List<Personaje> Bando1;
        private List<Personaje> Bando2;
        private List<Habilidad> HabilidadesDisponibles = new List<Habilidad>(); 

        public Juego(List<Personaje> bando1, List<Personaje> bando2)
        {
            Bando1 = bando1;
            Bando2 = bando2;     
        }

        public void Jugar()
        {
            while (!JuegoTerminado())
            {
                //El primer turno es del Bando1
                Turno(Bando1, Bando2);
                if (Bando2.Any(p => p.EstaVivo()))
                {
                    //El segundo turno es del Bando 2 si tiene a alguien vivo.
                    Turno(Bando2, Bando1);
                }
                
                Console.WriteLine();
                Console.WriteLine("Turn end");
                Console.WriteLine();
            }

            if (Bando1.Any(p => p.EstaVivo()))
            {
                Console.WriteLine("El bando 1 ha ganado la partida!");
                return;
            }           
           
            Console.WriteLine("El bando 2 ha ganado la partida!");
            
        }
        private bool JuegoTerminado()
        {
            return !(Bando1.Any(p => p.EstaVivo()) && Bando2.Any(p => p.EstaVivo()));
        }
        private void Turno(List<Personaje> atacantes, List<Personaje> defensores)
        {
            var atacantesVivos = atacantes.Where(p => p.EstaVivo());
            foreach (var atacante in atacantesVivos)
            {              
                    //Equipar una de las habilidades libre si le sirve.
                    //Solo el guerrero puede eeequipar un nuevo arma según la consigna.
                    //Se podria sacar el atacante is Heroe para que los Monstruos tambien se fijen si el arma les conviene.
                    if ( HabilidadesDisponibles.Any() && atacante is Heroe)
                    {
                        //Ya se que esta parte esta dudosa
                        // El método devuelve la lista de habilidades disponibles actualizada con el arma que soltó el heroe.
                        List<Habilidad> habilidadesRetornadas=  atacante.EquiparMejorHabilidad(HabilidadesDisponibles);

                        //Se actualiza la lista de habilidades disponibles del juego.
                        HabilidadesDisponibles = habilidadesRetornadas;                      
                    }
                    //atacar primero al que hace mas daño

                    var defensor = defensores.Where(d => d.EstaVivo()).OrderByDescending(x=> x.ObtenerDaño()).FirstOrDefault();
                    if (defensor != null)
                    {
                        atacante.Atacar(defensor);
                        if (!defensor.EstaVivo()) { 
                            //Si se muere dejar caer su habilidad y queda disponible para que otro la agarre.
                            Habilidad habilidad= defensor.DejarCaerHabilidad();
                            if (habilidad != null)
                            {                                
                                Console.WriteLine($"({defensor.NombreYVida()}) ha dejado caer un {habilidad.GetType().Name} con {habilidad.MostrarHabilidad()}");
                                HabilidadesDisponibles.Add(habilidad);
                               
                            }

                        }
                    }
                
            }
        }
    }
}
