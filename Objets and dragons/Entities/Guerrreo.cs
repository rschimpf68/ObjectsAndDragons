using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Guerrero : Rol
    {
        private int BonificacionDaño = 3;
        public Guerrero(Arma arma) : base(arma) { }
        

        public override bool DebeCambiarRol(Rol otroRol) { 
            if(Habilidad is Arma arma && !arma.NoEstaRota()){
                return true;
            }
            return ObtenerDaño() < otroRol.ObtenerDaño();
        }

        public override int ObtenerDaño() {
            return Habilidad.ObtenerDaño(BonificacionDaño);
        }

        public override void Atacar(Personaje objetivo, string nombreAtacante)
        {
            if (Habilidad is Arma arma && arma.NoEstaRota())
            {
                Habilidad.Atacar(objetivo,nombreAtacante, BonificacionDaño);                               
            }          
            
        }
    }
}
