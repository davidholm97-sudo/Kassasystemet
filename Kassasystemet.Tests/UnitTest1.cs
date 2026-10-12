namespace Kassasystemet.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void KontrolleraRadPris_TvaProdukter_GerRattPris()
        {
            Produkt produkt = new Produkt("101", "Mjölk", 15.90m, "Styck");
            Varukorgsrad rad = new Varukorgsrad(produkt, 2);

            Assert.Equal(31.80m, rad.RadPris);
        }
    }
}
