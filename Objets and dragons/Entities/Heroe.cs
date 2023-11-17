using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Heroe : Personaje
    {
        private List<Rol> Roles;
        private int RolSeleccionado;

        public Heroe(string nombre, int vida, List<Rol> roles, int rolSeleccionado) : base(nombre, vida)
        {
            Roles = roles;
            RolSeleccionado = rolSeleccionado; 
        }

        public override int ObtenerDaño()
        {
            return Roles[RolSeleccionado].ObtenerDaño();
        }

        public override List<Habilidad> EquiparMejorHabilidad(List<Habilidad> habilidadesDisponibles)
        {

            foreach (Rol rol in Roles) {             
                habilidadesDisponibles = rol.EquiparMejorHabilidad(habilidadesDisponibles);
            }
            

            return habilidadesDisponibles;
          
        }

        public override Habilidad DejarCaerHabilidad()
        {
            return Roles[RolSeleccionado].DejarCaerHabilidad();
            
        }
        

        public void CambiarRol()
        {
            
                RolSeleccionado = RolSeleccionado == 1? 0 : 1;
                Console.WriteLine($"({Nombre} ha cambiado su rol a {Roles[RolSeleccionado].GetType().Name}: {Vida} HP)");                   
            
        }

        public override string NombreYVida()
        {
            return $"{Nombre} {Roles[RolSeleccionado].GetType().Name}: {Vida} HP";
        }

        public override void Atacar(Personaje objetivo)
        {
            Rol rol = Roles[RolSeleccionado];
            Rol otroRol = Roles[RolSeleccionado == 1 ? 0 : 1];
            
            
            //Si el otro heroe esta mejor equipado, gasta el turno en cambiar de rol.
            if (rol.DebeCambiarRol(otroRol))
            {                
                CambiarRol();
                return;
            }            

            // Sino, ataca.
            rol.Atacar(objetivo, NombreYVida());
            
            
            
            
        }
    }
}
