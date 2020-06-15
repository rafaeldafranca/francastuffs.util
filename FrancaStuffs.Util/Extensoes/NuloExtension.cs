using System;
using System.Linq;

namespace FrancaStuffs.Util.Extensoes
{
    public static class NuloExtension
    {
        /// <summary>
        /// Verifica se é nulo um objeto
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <returns>true/false</returns>
        public static bool IsNull<T>(this T input) => input == null;

        /// <summary>
        /// Retorna um objeto não nulo se o objeto for nulo.
        /// </summary>
        /// <param name="input">valor do texto que é passado pela extensão</param>
        /// <param name="defaultValue">valor que deve ser retornado caso seja nulo o objeto</param>
        /// <returns>retorna o valor default se não for nulo</returns>
        public static string TrocaNulo(this string input, string defaultValue = null)
        {
            if (!string.IsNullOrEmpty(input))
                return input;

            return defaultValue;
        }
        /// <summary>
        /// Retorna verdadeiro se ele for nulo ou vazio.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static bool TrocaNulo(this bool? input, bool def)
        {
            if (input.HasValue)
                return input.Value;

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static T TrocaNulo<T>(this T input)
            where T : class
        {
            if (input == null)
                return Activator.CreateInstance<T>();

            return input;
        }
        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static T TrocaNulo<T>(this T input, T def)
            where T : class
        {
            if (input != null)
                return input;

            if (def == null)
                return Activator.CreateInstance<T>();

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static int TrocaNulo(this int? input, int def)
        {
            if (input.HasValue)
                return input.Value;


            return def;
        }
        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static decimal TrocaNulo(this decimal? input, decimal def)
        {
            if (input.HasValue)
                return input.Value;

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static long TrocaNulo(this long? input, long def)
        {
            if (input.HasValue)
                return input.Value;

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static double TrocaNulo(this double? input, double def)
        {
            if (input.HasValue)
                return input.Value;

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>

        public static DateTime TrocaNulo(this DateTime? input, DateTime def)
        {
            if (input.HasValue)
                return input.Value;

            return def;
        }

        /// <summary>
        /// Retorna um valor que não seja nulo.
        /// </summary>
        /// <typeparam name="input">objeto que será testado</typeparam>
        /// <param name="def">Valor default que deverá voltar caso o valor passado seja nulo.</param>
        /// <returns>Retora o valor atual se não for nulo. caso seja, voltará um valor de um objeto desse tipo não nulo ou o valor default</returns>
        public static Guid TrocaNulo(this Guid? input, Guid def)
        {
            Guid guid;

            if (input.HasValue)
                return input.Value;

            if (guid == def)
                return Guid.NewGuid();

            return def;
        }
    }
}
