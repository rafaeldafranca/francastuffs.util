
using FrancaStuffs.Util.Extensoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace FrancaStuffs.Test
{
    [TestClass]
    public class NuloExtensionTest
    {
        public NuloExtensionTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }
        [TestMethod]
        public void IsNullOrEmptyTest()
        {
            string texto = string.Empty;
            Assert.IsTrue(texto.IsNullOrEmpty(), "O valor não é nulo ou vazio", CultureInfo.CurrentCulture);
            texto = "";
            Assert.IsTrue(texto.IsNullOrEmpty(), "O valor não é nulo ou vazio", CultureInfo.CurrentCulture);
            texto = null;
            Assert.IsTrue(texto.IsNullOrEmpty(), "O valor não é nulo ou vazio", CultureInfo.CurrentCulture);

            texto = "Rafael";
            Assert.IsFalse(texto.IsNullOrEmpty(), "O valor é nulo ou vazio", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void IsNullTest()
        {
            string texto = string.Empty;
            Assert.IsFalse(texto.IsNull(), "O valor é nulo", CultureInfo.CurrentCulture);
            texto = "";
            Assert.IsFalse(texto.IsNull(), "O valor é nulo", CultureInfo.CurrentCulture);
            texto = null;
            Assert.IsTrue(texto.IsNull(), "O valor nao é nulo", CultureInfo.CurrentCulture);

            var isnullTestClass = new IsnullTestClass();
            Assert.IsFalse(isnullTestClass.IsNull(), "O objeto é nulo", CultureInfo.CurrentCulture);
            isnullTestClass = null;
            Assert.IsTrue(isnullTestClass.IsNull(), "O objeto nao é nulo", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void TrocaNuloTest()
        {
            IsnullTestClass isnullTestClass = null;
            IsnullTestClass isnullTestClassCriada = new IsnullTestClass();

            //Assert.AreEqual(isnullTestClass.TrocaNulo(), new IsnullTestClass(), "Campos não ficaram iguais com uma nova instancia");
            Assert.AreEqual(isnullTestClass.TrocaNulo(isnullTestClassCriada), isnullTestClassCriada, "Os campos não ficaram iguais com objetos com o mesmo valor", CultureInfo.CurrentCulture);

            isnullTestClassCriada = new IsnullTestClass() { Id = 1, Nome = "Rafael" };
            Assert.AreEqual(isnullTestClass.TrocaNulo(isnullTestClassCriada), isnullTestClassCriada, "Os campos não ficaram iguais com objetos tipados com valor", CultureInfo.CurrentCulture);

        }
    }

    public class IsnullTestClass
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
