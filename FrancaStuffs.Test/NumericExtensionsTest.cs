using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrancaStuffs.Util.Extensoes;
using System.Globalization;
using System.Threading;

namespace FrancaStuffs.Test
{
    [TestClass]
    public class NumericExtensionsTest
    {
        public NumericExtensionsTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }
        [TestMethod]
        public void TofloatSqlTest()
        {
            decimal n = 0;
            Assert.AreEqual(n.ToNumericSql(), "0", "Nao retornou 0", CultureInfo.CurrentCulture);

            n = 1;
            Assert.AreEqual(n.ToNumericSql(), "1", "Nao retornou 1", CultureInfo.CurrentCulture);

            double? numero0 = null;
            Assert.AreEqual(numero0.ToNumericSql(), "Null", "Nao retornou nulo", CultureInfo.CurrentCulture);

            double? numero1 = 1232.9;
            Assert.AreEqual(numero1.ToNumericSql(), "1232.9", "não são numeros iguais com double? ", CultureInfo.CurrentCulture);

            double? numero2 = 1232.21;
            Assert.AreEqual(numero2.ToNumericSql(), "1232.21", "não são numeros iguais com double? ", CultureInfo.CurrentCulture);

            double numero3 = 1232.23;
            Assert.AreEqual(numero3.ToNumericSql(), "1232.23", "não são numeros iguais com double ", CultureInfo.CurrentCulture);

          
            Assert.AreEqual("1.232,50".ToNumericSql(), "1232.5", "não são numeros iguais com string padrao brasileiro ", CultureInfo.CurrentCulture);

            Assert.AreEqual("1.232,24".ToNumericSql(), "1232.24", "não são numeros iguais com string padrao brasileiro ", CultureInfo.CurrentCulture);

            int? numero5 = 12345;
            Assert.AreEqual(numero5.ToNumericSql(), "12345", "não são numeros iguais com int? ", CultureInfo.CurrentCulture);

            Assert.AreEqual("22345,00".ToNumericSql(), "22345", "não são numeros iguais com string com casas zeradas ", CultureInfo.CurrentCulture);

            Assert.AreEqual("".ToNumericSql(), "Null", "não são numeros iguais com string nula ", CultureInfo.CurrentCulture);

            int? numero8 = null;
            Assert.AreEqual(numero8.ToNumericSql(), "Null", "não são numeros iguais com int? nulo ", CultureInfo.CurrentCulture);
        }

    }
}
