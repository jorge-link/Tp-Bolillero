using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionBolillero
{
    public class Simulacion
    {

        public long SimularSinHilos(Bolillero bolillero, long cantidadSimulaciones)
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

        public static List<Task<int>> MecanicaSimulacionConTareas(Bolillero bolillero, int cantidadSimulaciones, int cantidadHilos)
        {
            int simulacionesBase = cantidadSimulaciones / cantidadHilos;
            int simulacionesRestantes = cantidadSimulaciones % cantidadHilos;

            var tareas = new List<Task<int>>();

            for (int i = 0; i < cantidadHilos; i++)
            {
                int simulacionesParaEsteHilo = simulacionesBase;
                if (i < simulacionesRestantes)
                {
                    simulacionesParaEsteHilo += 1;
                }

                tareas.Add(Task.Run(() =>
                {
                    int ganadas = 0;
                    for (int j = 0; j < simulacionesParaEsteHilo; j++)
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
            return tareas;
        }

        public long SimularConHilos(Bolillero bolillero, int cantidadSimulaciones, int cantidadHilos)
        {
            int totalGanadas = 0;
            var tareas = MecanicaSimulacionConTareas(bolillero, cantidadSimulaciones, cantidadHilos);
            Task.WaitAll(tareas.ToArray());

            totalGanadas = tareas.Sum(t => t.Result);

            return totalGanadas;
        }

        public async Task<long> SimularConHilosAsync(Bolillero bolillero, int cantidadSimulaciones, int cantidadHilos)
        {
            var tareas = MecanicaSimulacionConTareas(bolillero, cantidadSimulaciones, cantidadHilos);

            var resultados = await Task.WhenAll(tareas);

            return resultados.Sum();
        }


        public async Task<long> SimularParallelAsync(Bolillero bolillero, int cantidadSimulaciones, int cantidadHilos)
        {
            long SimulacionesGanadas = 0;
            long SimulacionesRestantes = cantidadSimulaciones % cantidadHilos;

            long simsMinPorHilo = (cantidadSimulaciones - SimulacionesRestantes) / cantidadHilos;

            Task<long>[] tareas = new Task<long>[cantidadHilos];

            long[] resultados = new long[cantidadHilos];

            await Task.Run(() =>
            {
                Parallel.For(0, cantidadHilos, i =>
                {
                    long simsPorHilo = simsMinPorHilo + (SimulacionesRestantes > i ? 1 : 0);

                    resultados[i] = SimularSinHilos(bolillero, simsPorHilo);
                });
            });
            SimulacionesGanadas = resultados.Sum();

            return SimulacionesGanadas;
        }
    }
}
