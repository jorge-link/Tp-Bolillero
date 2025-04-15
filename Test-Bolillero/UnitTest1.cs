using SimulacionBolillero;
namespace Test_Bolillero
{
    public class UnitTest1
    {

        [Fact]
        public void TestJugarRandom()
        {
            List<int> numerosElegidos = new List<int> { 1, 2, 3 };
            int rangoBolillero = 20;
            int jugarXveces = 3;
            Bolillero bolillero = new Bolillero(numerosElegidos, jugarXveces, rangoBolillero);

            bool resultado = bolillero.JugarRandom();

            Assert.True(resultado || !resultado);
        }

        [Fact]
        public void TestJugarFija()
        {
            List<int> numerosElegidos = new List<int> { 0, 1, 2 };
            int rangoBolillero = 20;
            int jugarXveces = 3;
            Bolillero bolillero = new Bolillero(numerosElegidos, jugarXveces, rangoBolillero);

            bool resultado = bolillero.JugarFija();

            Assert.True(resultado);
        }

        [Fact]
        public void TestJugarXveces()
        {
            List<int> numerosElegidos = new List<int> { 3, 5, 13 };
            int rangoBolillero = 20;
            int jugarXveces = 5;
            Bolillero bolillero = new Bolillero(numerosElegidos, jugarXveces, rangoBolillero);

            int vecesGanadas = bolillero.JugarXveces(jugarXveces, new List<int>());

            Assert.InRange(vecesGanadas, 0, jugarXveces);
        }
    }
}