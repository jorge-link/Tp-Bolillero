using SimulacionBolillero;
namespace Test_Bolillero
{
    public class UnitTest1
    {
        [Fact]
        public void SacarBolilla()
        {
            var numerosElegidos = new List<int> { 0 }; // solo para que compile
            var bolillero = new Bolillero(numerosElegidos, 1, 10);

            bolillero.SacarBolilla(); // Saca la primera bolilla

            Assert.Contains(0, bolillero.BolillasFuera);
            Assert.Equal(9, bolillero.NumerosBolilleros.Count);
            Assert.Single(bolillero.BolillasFuera);
        }

        [Fact]
        public void ReIngresar()
        {
            var numerosElegidos = new List<int> { 0 };
            var bolillero = new Bolillero(numerosElegidos, 1, 10);

            bolillero.JugarFija();
            bolillero.MeterBolillasFuera();

            Assert.Equal(10, bolillero.NumerosBolilleros.Count);
            Assert.Empty(bolillero.BolillasFuera);
        }

        [Fact]
        public void JugarGana()
        {
            var jugadaGanadora = new List<int> { 0, 1, 2, 3 };
            var bolillero = new Bolillero(jugadaGanadora, 1, 10);

            bool gano = bolillero.JugarFija();
            Assert.True(gano);
        }

        [Fact]
        public void JugarPierde()
        {
            var jugadaPerdedora = new List<int> { 4, 2, 1 };
            var bolillero = new Bolillero(jugadaPerdedora, 1, 10);

            bool gano = bolillero.JugarFija();
            Assert.False(gano);
        }

        [Fact]
        public void GanarNVeces()
        {
            var jugada = new List<int> { 0, 1 };
            var bolillero = new Bolillero(jugada, 1, 10);

            bool gano = bolillero.JugarFija();
            Assert.True(gano);
        }
    }
}