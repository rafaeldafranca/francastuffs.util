
using FrancaStuffs.Util.Extensoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace FrancaStuffs.Test
{
    [TestClass]
    public class StringExtensionTest
    {
        public StringExtensionTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void RemoverPassandoArrayTest()
        {


            string cpf = "999.999.999-99";
            string resultado = "99999999999";

            Assert.AreEqual(resultado, cpf.Remover(new string[] { ".", "-" }), "não foram removidos todos os caracteres", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void RemoverTest()
        {
            ;
            string cpf = "999.999.999-99";
            string resultado = "999999999-99";

            Assert.AreEqual(resultado, cpf.Remover("."), "não foi removido todos os caracteres", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void CompararTest()
        {
            Assert.IsTrue("Texto".Comparar("Texto"), "Não houve comparação");
            Assert.IsFalse("Texto".Comparar("TextoFalso"), "Retornou ok em um texto diferente", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void ToCamelCasingTest()
        {
            Assert.AreEqual("rafael frança".ToCamelCasing(), "Rafael frança", "Não deixou a primeira letra maiúscula", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void ToDoubleTest()
        {
            double? valor = 123;
            Assert.AreEqual("123".ToDouble(), valor, "Não transformou em um double", CultureInfo.CurrentCulture);
            Assert.AreEqual("123a".ToDouble(), null, "Não transformou em um null um alfanumerico", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void AddQueryStringTest()
        {
            string uri = "endereco.asp";

            uri = uri.AddQueyString("param1", "valor1");
            Assert.AreEqual(uri, "endereco.asp?param1=valor1", "Não montou o endereco com um parametro!", CultureInfo.CurrentCulture);

            uri = uri.AddQueyString("param2", "valor2");
            Assert.AreEqual(uri, "endereco.asp?param1=valor1&param2=valor2", "Não montou o endereco com 2 parametros!", CultureInfo.CurrentCulture);

            uri = uri.AddQueyString("param3", "valor3");
            Assert.AreEqual(uri, "endereco.asp?param1=valor1&param2=valor2&param3=valor3", "Não montou o endereco com 3 parametros", CultureInfo.CurrentCulture);

            uri = "endereco.asp";
            uri = uri.AddQueyString("nome", "Rafael França");
            Assert.AreEqual(uri, "endereco.asp?nome=Rafael%20França", "Não montou o endereco com um parametro com espaço!", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void PrimeiraLetraMaiusculaTest()
        {
            Assert.AreEqual("rafael franca".PrimeiraLetraMaiuscula(), "Rafael Franca", "Não conseguiu colocar letra maiuscula", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void ZerosAEsquerdaTest()
        {
            Assert.AreEqual("123".ZerosAEsquerda(5), "00123", "Não completou com os zeros a esquerda", CultureInfo.CurrentCulture);
            Assert.AreEqual("".ZerosAEsquerda(5), "00000", "Com valor em branco, não preencheu com 5 zeros", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void ZerosADireitaTest()
        {
            Assert.AreEqual("123".ZerosADireita(2), "123,00", "Ok, preencheu com zero!");
            Assert.AreEqual("123,4".ZerosADireita(2), "123,40", "Ok, com decimais acrescentou uma casa!", CultureInfo.CurrentCulture);
            Assert.AreEqual("123,00".ZerosADireita(2), "123,00", "Ok, com decimais ja preenchidos!", CultureInfo.CurrentCulture);
            Assert.AreEqual("123,40".ZerosADireita(2), "123,40", "Ok, com decimais ja preenchidos!", CultureInfo.CurrentCulture);
            Assert.AreEqual("123,45".ZerosADireita(2), "123,45", "Ok, com decimais ja preenchidos!", CultureInfo.CurrentCulture);
            Assert.AreEqual("123,45".ZerosADireita(5), "123,45000", "Ok, com decimais ja preenchidos!", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void DecimaisComDigitosTest()
        {
            Assert.AreEqual("123".DecimaisComDigitos(2), "123,00", "Não preencheu com zero com um valor sem casas decimais!");
            Assert.AreEqual("123,4".DecimaisComDigitos(2), "123,40", "Não acrescentou com 2 decimais com uma casa!");
            Assert.AreEqual("123,00".DecimaisComDigitos(2), "123,00", "Não acrescentou com mais decimais com duas casas com zero!");
            Assert.AreEqual("123,40".DecimaisComDigitos(2), "123,40", "Não acrescentou com mais decimais com duas casas com 1 zero!");
            Assert.AreEqual("123,45".DecimaisComDigitos(2), "123,45", "Não acrescentou com mais decimais com duas casas sem zero!", CultureInfo.CurrentCulture);
            Assert.AreEqual("123,45".DecimaisComDigitos(5), "123,45000", "Não conseguiu preencher 5 digitos!", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void RemoverAcentosTest()
        {
            Assert.AreEqual("ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç".RemoverAcentos(),
                            "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc", "Não validou um campo com acentuacao", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void RemoverCharEspecialTest()
        {
            string valor = "!Rafáel ||França+-#,".RemoverCharEspecial();
            Assert.AreEqual(valor, "RafelFrana", "Não conseguiu validar com caracteres especiais e acentuacao", CultureInfo.CurrentCulture);

        }

        [TestMethod]
        public void DuplicarTextoText()
        {
            Assert.AreEqual("9".DuplicarTexto(11), "99999999999", "Não criou 11x o 9", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void ValidaCpfTest()
        {
            Assert.IsFalse("00057254336333".ValidarCpf(), "Validou um cpf com mais numeros!", CultureInfo.CurrentCulture);
            Assert.IsFalse("57254336333000".ValidarCpf(), "Validou um cpf com mais numeros!", CultureInfo.CurrentCulture);
            Assert.IsFalse("57254336331".ValidarCpf(), "Validou um cpf invalido!", CultureInfo.CurrentCulture);
            Assert.IsTrue("57254336333".ValidarCpf(), "Não validou sem pontuacao!", CultureInfo.CurrentCulture);
            Assert.IsTrue("976.441.437-00".ValidarCpf(), "Não validou com pontuacao!", CultureInfo.CurrentCulture);
            Assert.IsFalse("99999999999".ValidarCpf(), "Validou cpf invalido!", CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void ValidaCnpjTest()
        {
            Assert.IsFalse("00023084929000140".ValidarCpf(), "Validou um cnpj com mais numeros!");
            Assert.IsFalse("23084929000140000".ValidarCpf(), "Validou um cnpj com mais numeros!");
            Assert.IsFalse("23084929000140".ValidarCnpj(), "Validou um cnpj invalido!");
            Assert.IsTrue("23084929000141".ValidarCnpj(), "Não validou um cnpj sem pontuacao!");
            Assert.IsTrue("71.459.148/0001-37".ValidarCnpj(), "Não validou um cnpj com pontuacao!");
            Assert.IsFalse("99999999999999".ValidarCnpj(), "Validou um cnpj invalido!");
        }

        [TestMethod]
        public void ToStringSqlTest()
        {
            //com texto.
            Assert.AreEqual("".ToStringSql(), "Null", "Não retornou Null !", CultureInfo.CurrentCulture);
            Assert.AreEqual("Teste".ToStringSql(), "'Teste'", "Não colocou o plic !", CultureInfo.CurrentCulture);
            Assert.AreEqual("Mc Donald's".ToStringSql(), "'Mc Donald''s'", "Não duplicou o plic !", CultureInfo.CurrentCulture);

            //com Data.
            DateTime? data = null;
            Assert.AreEqual(data.ToStringSql(), "Null", "Não retornou Null para data !", CultureInfo.CurrentCulture);
            data = new DateTime(2020, 10, 31);
            Assert.AreEqual(data.ToStringSql(), "'2020/10/31'", "Não colocou o plic na data !", CultureInfo.CurrentCulture);

            //com guid.
            Guid? guid = null;
            Assert.AreEqual(guid.ToStringSql(), "Null", "Não retornou Null para guid !", CultureInfo.CurrentCulture);
            guid = new Guid("c9d6dff8-a403-421c-bf20-881ef7bdf8b1");
            Assert.AreEqual(guid.ToStringSql(), "'c9d6dff8-a403-421c-bf20-881ef7bdf8b1'", "Não colocou o plic no guid !", CultureInfo.CurrentCulture);

        }
    }
}
