using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionBolillero
{
    public abstract class MecanicaAleatoria
    {
        Random IndiceRnd = new Random();
        public void MecanicaRandom(List<int> NumerosBolilleros, List<int> BolillasFuera)
        { 
            var indiceRnd = IndiceRnd.Next(0, NumerosBolilleros.Count);

            var bolilla = NumerosBolilleros[indiceRnd];

            NumerosBolilleros.RemoveAt(indiceRnd);

            BolillasFuera.Add(indiceRnd);

            
        }
    }
}
