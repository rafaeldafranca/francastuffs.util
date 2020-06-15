
using System;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FrancaStuffs.Util.Extensoes
{
    public static class StringExtension
    {
        /// <summary>
        /// Comparar texto baseado no objeto extendido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="texto">texto que deve ser comparado</param>
        /// <returns>Retorna um boleano baseado na comparação</returns>
        public static bool Comparar(this string input, string texto)
        {
            if (input.Equals(texto)) return true;
            return false;
        }

        /// <summary>
        /// Remove um texto baseado no objeto extendido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="valor">texto a ser removido</param>
        /// <returns>Retorna o texto modificado</returns>
        public static string Remover(this string input, string valor)
        {
            if (input.IsNullOrEmpty()) return null;
            return input.Replace(valor, "");
        }

        /// <summary>
        /// Remove um texto baseado no objeto extendido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="valor">texto a ser removido</param>
        /// <returns>Retorna o texto modificado</returns>
        public static string Remover(this string input, string[] valor)
        {
            foreach (string item in valor)
                input = input.Remover(item);

            return input;
        }



        /// <summary>
        /// Criar um hash
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns>Retorna um Hash baseado no texto</returns>
        public static string ObterHashAlgorithm(this string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        /// <summary>
        /// Transformar texto em Camel case, ou seja, primeira letra maiuscula
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns>Retorna o texto no formato Camel Case</returns>
        public static string ToCamelCasing(this string input)
        {
            if (!string.IsNullOrEmpty(input))
                return input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1);

            return input;
        }
        /// <summary>
        /// Transformar o texto em double
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="culture">Formato do double</param>
        /// <returns></returns>
        public static double? ToDouble(this string input, string culture = "en-US")
        {
            try
            {
                return double.Parse(input, new CultureInfo(culture));
            }
            catch
            {
                return null;
            }
        }

        public static bool? ToBoolean(this string value)
        {
            bool valor = false;
            if (bool.TryParse(value, out valor))
            {
                return valor;
            }

            return null;
        }

        public static int? ToInt32(this string value)
        {
            int valor = 0;
            if (int.TryParse(value, out valor))
            {
                return valor;
            }

            return null;
        }

        public static long? ToInt64(this string value)
        {
            long valor = 0;
            if (long.TryParse(value, out valor))
            {
                return valor;
            }

            return null;
        }

        public static Guid? ToGuid(this string value)
        {
            Guid valor = Guid.Empty;
            if (Guid.TryParse(value, out valor))
            {
                return valor;
            }

            return null;
        }

        public static Guid ToGuid(this string value, Guid defaultValue)
        {
            Guid valor = Guid.Empty;
            if (Guid.TryParse(value, out valor))
            {
                return valor;
            }

            return defaultValue;
        }

        /// <summary>
        /// Monta o querystring de uma postagem na web
        /// </summary>
        /// <param name="url">caminho</param>
        /// <param name="queryStringKey">o nome do parametro</param>
        /// <param name="queryStringValue">o valor do parametro</param>
        /// <returns>retorna o caminho completo</returns>
        public static string AddQueyString(this string url, string queryStringKey, string queryStringValue)
        {
            var queryString = "";
            var segments = url.Split('?');
            if (segments.Length > 1)
            {
                queryString = "&";
            }
            else
            {
                queryString = "?";
            }

            return (url + queryString + queryStringKey + "=" + queryStringValue).Replace(" ", "%20");
        }
        /// <summary>
        /// Retorna as letras maiusculas de cada palavra separaa por espaco
        /// </summary>
        /// <param name="input"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string PrimeiraLetraMaiuscula(this string input, string culture = "en-US")
        {
            return CultureInfo.GetCultureInfo(culture).TextInfo.ToTitleCase(input);
        }

        /// <summary>
        /// Preenche de zeros a direita textos que são numéricos.
        /// </summary>
        /// /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="digitos">quantidade de zeros a direita</param>
        /// <returns></returns>
        public static string ZerosADireita(this string input, int digitos)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var sb = new StringBuilder();
                if (input.IndexOf(",").Equals(-1)) input += ",";
                sb.Append(input);
                var s = input.Split(',');
                for (var i = s[s.Length - 1].Length; i < digitos; i++)
                {
                    sb.Append("0");
                }

                input = sb.ToString();
            }

            return input;
        }

        /// <summary>
        /// Retorna um numero com a quantidade de zeros a esquerda infomados no tamanho
        /// </summary>
        //// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="tamanho">Total do tamanho do numero</param>
        /// <returns></returns>
        public static string ZerosAEsquerda(this string input, int tamanho)
        {
            var valor = "0".DuplicarTexto(tamanho) + input;
            return valor.Substring(valor.Length - tamanho);
        }

        public static string DecimaisComDigitos(this string input, int? digitos)
        {
            if (input.IsNullOrEmpty()) return input;

            if (!input.IndexOf(",").Equals(-1))
            {
                var s = input.Split(',');
                if (s.Length.Equals(2) && s[1].Length > 0)
                {
                    input = s[0] + "," + s[1].Substring(0, s[1].Length >= digitos.Value ? digitos.Value : s[1].Length);
                }
            }

            return digitos.HasValue ? input.ZerosADireita(digitos.Value) : input;
        }

        /// <summary>
        /// Remove todos os caracteres que não sejam letras nao acentuadas e numeros.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoverCharEspecial(this string input)
        {
            string patternCharEsp = @"[^0-9a-zA-Z]+";
            //string patternCharEsp = @"[^\w\.@-]";
            string result = input;
            if (!string.IsNullOrEmpty(result))
            {
                result = Regex.Replace(result, patternCharEsp, "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            return result;
        }

        /// <summary>
        /// Remove toda a acentuação trocando por caracteres sem acentuação
        /// </summary>
        //// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns></returns>
        public static string RemoverAcentos(this string input)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = input.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        /// <summary>
        /// Verifica se um numero é valido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns></returns>
        public static bool ValidarNumero(this string input)
        {
            char[] datachars = input.ToCharArray();

            foreach (var datachar in datachars)
                if (!char.IsNumber(datachar)) return false;


            return true;
        }

        /// <summary>
        /// Abrevia o nome dependendo do tamanho do texto.
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="tamanho">Tamanho máximo que o nome pode ficar</param>
        /// <returns></returns>
        public static string AbreviarNome(this string input, int tamanho = 0)
        {
            var posicao = 1;
            var nomes = input.Trim().Split(' ').ToList();
            var nomeAux = input.Trim();

            string[] excluidos = { "de", "da", "do", "das", "dos", "ltda", "sa" };
            tamanho = (tamanho == 0) ? input.Length : tamanho;

            if (nomeAux.Length > tamanho)
            {
                while (nomeAux.Length >= tamanho)
                {
                    var sobrenome = nomes[posicao].ToLower().Replace(".", "");
                    nomeAux = "";

                    if (excluidos.ToList().IndexOf(sobrenome) != 1)
                        nomes[posicao] = nomes[posicao].Substring(0, 1) + ".";

                    foreach (var item in nomes)
                        nomeAux += item + " ";

                    nomeAux = nomeAux.Trim();
                    posicao++;

                    if (posicao == nomes.Count && nomeAux.Length > tamanho)
                        return input.Trim().Substring(0, tamanho);

                    if (nomeAux.Length <= tamanho) return nomeAux;
                }
            }

            return nomeAux;
        }

        /// <summary>
        /// Valida se é um CNPJ válido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns></returns>
        public static bool ValidarCnpj(this string input)

        {
            int soma = 0, resto;
            string digito, tempCnpj;
            int[] numeros = new int[10] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            input = RemoverCharEspecial(input.Trim());
            if (input.Length != 14) return false;

            foreach (var item in numeros)
                if (item.ToString().DuplicarTexto(14) == input) return false;

            tempCnpj = input.Substring(0, 12);

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            resto = (resto < 2) ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCnpj += digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = (resto < 2) ? 0 : 11 - resto;

            digito += resto.ToString();
            return input.EndsWith(digito);

        }

        /// <summary>
        /// Duplico o mesmo texto várias vezes
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="vezes">Quantidade de vezes</param>
        /// <returns></returns>
        public static string DuplicarTexto(this string input, int vezes = 1)
        {
            string resultado = input;
            for (int i = 0; i < vezes - 1; i++)
                resultado += input;

            return resultado;
        }

        /// <summary>
        /// Valida se é um CPF válido
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns></returns>
        public static bool ValidarCpf(this string input)
        {
            string tempCpf, digito;
            int soma = 0, resto;
            int[] numeros = new int[10] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            input = RemoverCharEspecial(input.Trim());
            if (input.Length != 11) return false;

            foreach (var item in numeros)
                if (item.ToString().DuplicarTexto(11) == input) return false;


            tempCpf = input.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return input.EndsWith(digito);
        }

        public static string ObterMd5Hash(this string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string ObterHashPassword(this string input)
        {
            byte[] salt;
            byte[] buffer2;
            if (input == null)
                throw new ArgumentNullException("Sem senha informada!");

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(input, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);

            return Convert.ToBase64String(dst);
        }

        public static string ToStringSql(this string input)
        {
            string resultado = "Null";
            if (!string.IsNullOrEmpty(input))
                resultado = $"'{input.Replace("'", "''")}'";

            return resultado;
        }

        public static string ToStringSql(this Guid? input)
        {
            string resultado = "Null";
            if (!input.IsNull())
            {
                resultado = $"'{input.ToString().Replace("'", "''")}'";
            }

            return resultado;
        }

        public static string ToStringSql(this Guid input)
        {
            return input.ToString().ToStringSql();
        }
        public static string ToStringSql(this DateTime? input)
        {
            DateTime temp;
            if (DateTime.TryParse(input.ToString(), out temp))
            {
                return ToStringSql(temp);
            }
            else
                return "Null";

        }

        public static string ToStringSql(this DateTime input)
        {
            string resultado = "Null";
            DateTime temp;

            if (DateTime.TryParse(input.ToString(), out temp))
                resultado = $"'{temp.ToString("yyyy/MM/dd").Replace("'", "''")}'";


            return resultado;
        }

        public static string ToStringSql(this bool? input)
        {
            if (input == null) return null;
            var resultado = (bool)input;
            return resultado ? "1" : "0";
        }

        public static string ToStringSql(this bool input)
        {
            return input ? "1" : "0";
        }
    }
}
