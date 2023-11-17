using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    abstract class Rol
    {
        protected Habilidad Habilidad;

        public Rol(Habilidad habilidad)
        {
            Habilidad = habilidad;
        }
        public Habilidad DejarCaerHabilidad() { 
            Habilidad habilidad = Habilidad;
            Habilidad = null;
            return habilidad;
        }

        public List<Habilidad> EquiparMejorHabilidad(List<Habilidad> habilidadesDisponibles) {
            var habilidadesParaEliminar = new List<Habilidad>();
            var habilidadesParaAgregar = new List<Habilidad>();

            List<Habilidad> habilidadesOrdenadas = habilidadesDisponibles.OrderByDescending(habilidad => habilidad.ObtenerDaño()).ToList();

            foreach (Habilidad habilidadDisponible in habilidadesOrdenadas)
            {
                if (Habilidad.EsMejorQue(habilidadDisponible))
                {
                    
                    //Si es mejor cambiar habilidad                 
                    Habilidad habilidadAnterior = CambiarHabilidad(habilidadDisponible);
                    habilidadesParaEliminar.Add(habilidadDisponible);
                    habilidadesParaAgregar.Add(habilidadAnterior);
                    Console.WriteLine($"({GetType().Name}) ha equipado un {Habilidad.GetType().Name} {Habilidad.MostrarHabilidad()}");
                    Console.WriteLine($"({GetType().Name}) ha dejado caer un {habilidadAnterior.GetType().Name} {habilidadAnterior.MostrarHabilidad()}");
                }
            }

            foreach (var habilidad in habilidadesParaEliminar)
            {
                habilidadesDisponibles.Remove(habilidad);
            }

            habilidadesDisponibles.AddRange(habilidadesParaAgregar);

            return habilidadesDisponibles;
        }
        public abstract void Atacar(Personaje objetivo, string nombreAtacante);

        public abstract bool DebeCambiarRol(Rol otroRol);

        public abstract int ObtenerDaño();


        public Habilidad CambiarHabilidad(Habilidad nuevaHabilidad)
        {
            Habilidad habilidadAnterior = Habilidad;
            Habilidad = nuevaHabilidad;
            return habilidadAnterior;
        }
    }
}
