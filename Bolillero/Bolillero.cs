﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionBolillero 
{
    public class Bolillero : MecanicaAleatoria, MecanicaFija
    {
        public List<int> NumerosBolilleros;
        public List<int> numerosElegidos;
        public int JugarNveces;
        public List<int> BolillasFuera;
        public Bolillero(List<int> numElegidos, int jugarXveces, int RngBolillero)
        {
            numerosElegidos = numElegidos;
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
        public void PrimerBolilla(List<int> NumerosBolilleros, List<int> BolillasFuera)
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
            return gano;
        }
        public void SacarBolilla()
        {
            PrimerBolilla(NumerosBolilleros, BolillasFuera);
        }

        public int JugarXveces(int jugarXveces, List<int>NumerosGanadores)
        {
            int VecesGanadas = 0;
            for (int i = 0; i < jugarXveces; i++)
            {
                if(JugarRandom()){
                    VecesGanadas =+ 1;
                }
            }
            return VecesGanadas;
        }

    }
}
