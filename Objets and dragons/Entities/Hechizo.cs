using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{
    class Hechizo : Habilidad
    {
        public Hechizo(int daño) : base(daño) { }

        public override bool EsMejorQue(Habilidad otraArma)
        {
            return (otraArma is Hechizo && otraArma.ObtenerDaño() > Daño);
            
        }
        public override void Atacar(Personaje objetivo, string nombreAtacante, int bonificacion = 1)
        {
            Console.WriteLine($"({nombreAtacante}) ataca a ({objetivo.NombreYVida()}) por {Daño * bonificacion} de daño.");
            objetivo.RecibirDaño(Daño * bonificacion);
        }
    }
}
