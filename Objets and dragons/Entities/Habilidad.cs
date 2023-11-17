using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    abstract class Habilidad
    {
        protected int Daño;
        

        public Habilidad(int daño)
        {
            Daño = daño;
        }
        public virtual string MostrarHabilidad()
        {
            return $"Daño: {Daño}";
        }
        public abstract bool EsMejorQue(Habilidad otraHabilidad);

        public int ObtenerDaño(int bonificacion =1)
        {
            return Daño*bonificacion;
        }
        
        

        public abstract void Atacar(Personaje objetivo, string nombreAtacante, int bonificacion =1);
    }
}
