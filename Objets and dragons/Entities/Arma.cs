using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objets_and_dragons.Entities
{

    class Arma : Habilidad
    {
        private int Durabilidad;
        public Arma(int daño, int durabilidad) : base(daño) {
            Durabilidad = durabilidad;
        }

        public override void Atacar(Personaje objetivo, string nombreAtacante ,int bonificacion = 1)
        {
            if (NoEstaRota())
            {
                
                
                Console.WriteLine($"({nombreAtacante}) ataca a ({objetivo.NombreYVida()}) por {Daño * bonificacion} de daño.");                
                BajarDurabilidad(nombreAtacante);
                objetivo.RecibirDaño(Daño * bonificacion);
            }
        }

        public override bool EsMejorQue(Habilidad otraArma)
        {           
            return (otraArma is Arma && otraArma.ObtenerDaño() > Daño);
           
        }

        public void BajarDurabilidad(string nombreAtacante) { 
            Durabilidad--;
            if (Durabilidad == 0) {
                Console.WriteLine($"El arma de ({nombreAtacante}) se rompió");
            }            
        }
        public bool NoEstaRota() => Durabilidad > 0;

        public override string MostrarHabilidad()
        {
            return $"Daño: {Daño} Durabilidad: {Durabilidad}";
        }

        public bool EsMejorArma(Arma otraArma) { 
        
            if (otraArma.Daño > Daño)
            {
                return true;
            }
            return false;
        }
        
        
    }
}
