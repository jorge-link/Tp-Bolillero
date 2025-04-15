using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionBolillero
{
    public class Simulacion
    {
        public long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones)
        {
            int ganadas = 0;

            for (int i = 0; i < cantidadSimulaciones; i++)
            {
                var copiaBolillero = (Bolillero)bolillero.Clone();
                if (copiaBolillero.JugarRandom())
                {
                    ganadas++;
                }
            }

            return ganadas;
        }

        public long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
        {
            int totalGanadas = 0;
            int simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;

            var tareas = new List<Task<int>>();

            for (int i = 0; i < cantidadHilos; i++)
            {
                tareas.Add(Task.Run(() =>
                {
                    int ganadas = 0;
                    for (int j = 0; j < simulacionesPorHilo; j++)
                    {
                        var copiaBolillero = (Bolillero)bolillero.Clone();
                        if (copiaBolillero.JugarRandom())
                        {
                            ganadas++;
                        }
                    }
                    return ganadas;
                }));
            }

            Task.WaitAll(tareas.ToArray());

            foreach (var t in tareas)
            {
                totalGanadas += t.Result;
            }

            return totalGanadas;
        }
    }
}
