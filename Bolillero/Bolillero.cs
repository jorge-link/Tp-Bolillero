using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulacionBolillero
{
    public class Bolillero : MecanicaAleatoria,  ICloneable, MecanicaFija
    {
        List<int> NumerosBolilleros;
        List<int> numerosElegidos;
        int JugarNveces;
        List<int> BolillasFuera;

        public Bolillero(List<int> numElegidos, int jugarXveces, int RngBolillero)
        {
            numerosElegidos = new List<int>(numElegidos);
            JugarNveces = jugarXveces;

            NumerosBolilleros = new List<int>();
            BolillasFuera = new List<int>();

            for (int i = 0; i < RngBolillero; i++)
            {
                NumerosBolilleros.Add(i);
            }
        }

        public void MeterBolillasFuera()
        {
            NumerosBolilleros.AddRange(BolillasFuera);
            BolillasFuera.Clear();
        }
        public void OrdenarBolillas()
        {
            NumerosBolilleros.Sort();
        }

        void PrimerBolilla(List<int> NumerosBolilleros, List<int> BolillasFuera)
        {
            var bolilla = NumerosBolilleros[0];
            NumerosBolilleros.RemoveAt(0);
            BolillasFuera.Add(bolilla);
        }

        public bool JugarRandom()
        {
            bool gano = false;
            for (int i = 0; i < numerosElegidos.Count; i++)
            {
                MecanicaRandom(NumerosBolilleros, BolillasFuera);
            }

            if (numerosElegidos.SequenceEqual(BolillasFuera))
            {
                gano = true;
            }

            MeterBolillasFuera();
            return gano;
        }

        public bool JugarFija()
        {
            bool gano = false;
            for (int i = 0; i < numerosElegidos.Count; i++)
            {
                PrimerBolilla(NumerosBolilleros, BolillasFuera);
            }

            if (numerosElegidos.SequenceEqual(BolillasFuera))
            {
                gano = true;
            }

            MeterBolillasFuera();
            OrdenarBolillas();
            return gano;
        }

        public int SimularSinHilosFija()
        {
            int VecesGanadas = 0;
            for (int i = 0; i < JugarNveces; i++)
            {
                if (JugarFija())
                {
                    VecesGanadas++;
                }
            }
            return VecesGanadas;
        }

        public object Clone()
        {
            var copiaNumerosElegidos = new List<int>(numerosElegidos);
            var copia = new Bolillero(copiaNumerosElegidos, JugarNveces, NumerosBolilleros.Count);
            return copia;
        }
    }
}
