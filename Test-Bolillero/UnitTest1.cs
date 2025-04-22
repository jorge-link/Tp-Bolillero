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

            var resultado = simulacion.SimularConHilos(bolillero, NumerosGanadores, 100, 4);

            Assert.InRange(resultado, 0, 100);
        }
    }
}