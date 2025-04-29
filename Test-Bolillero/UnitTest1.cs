using SimulacionBolillero;
namespace Test_Bolillero
{
    public class UnitTest1
    {
        [Fact]
        public void SimularSinHilos()
        {
            var NumerosGanadores = new List<int> { 0, 1, 2 };
            var bolillero = new Bolillero(NumerosGanadores, 1, 20);
            var simulacion = new Simulacion();

            var resultado = simulacion.SimularSinHilos(bolillero, NumerosGanadores, 100);

            Assert.InRange(resultado, 0, 100);
        }

        [Fact]
        public void SimularConHilos()
        {
            var NumerosGanadores = new List<int> { 0, 1, 2 };
            var bolillero = new Bolillero(NumerosGanadores, 1, 20);
            var simulacion = new Simulacion();

            var resultado = simulacion.SimularConHilos(bolillero, 32, 3);

            Assert.InRange(resultado, 0, 32);
        }
        [Fact]
        public void PruebaCopia()
        {
            var NumerosGanadores = new List<int> { 0, 1, 2, 3 };
            var bolillero = new Bolillero(NumerosGanadores, 1, 20);
            var copiaBolillero = bolillero.Clone();

            Assert.Equivalent(bolillero, copiaBolillero);
        }

        [Fact]
        public void SimularSinHilosGana()
        {
            var NumerosGanadores = new List<int> { 0, 1, 2 };
            var bolillero = new Bolillero(NumerosGanadores, 10, 20);


            int resultado = bolillero.SimularSinHilosFija();

            Assert.Equal(10, resultado);
        }
    }
}