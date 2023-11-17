using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Mago : Rol
    {
        public Mago(Hechizo hechizo) : base(hechizo) { }

        public override bool DebeCambiarRol(Rol otroRol)
        {
            return ObtenerDaño() < otroRol.ObtenerDaño();
        }
        public override int ObtenerDaño()
        {
            return Habilidad.ObtenerDaño();
        }
        public override void Atacar(Personaje objetivo, string nombreAtacante)
        {
           Habilidad.Atacar(objetivo, nombreAtacante);
        }
    }
}
