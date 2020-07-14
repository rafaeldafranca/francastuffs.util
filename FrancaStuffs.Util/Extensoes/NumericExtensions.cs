namespace FrancaStuffs.Util.Extensoes
{
    public static class NumericExtensions
    {
        private static string ToNumericSqlResult(object objeto)
        {
            string resultado = "Null";
            if (objeto == null) return resultado;

            if (decimal.TryParse(objeto.ToString(), out decimal valor))
            {
                if (valor == 0) return "0";
                resultado = string.Format("{0:#.00}", valor)
                                  .Remover(new string[] { ".", ",00" })
                                  .Replace(",", ".");

                //resultado = string.Format(minhaCultura, "{0:N}", valor)
                //                  .Remover(".")
                //                  .Replace(",", ".");
            }
            return resultado.TrimEnd('0');
        }

        public static string ToNumericSql(this string input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this int input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this int? input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this long input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this long? input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this double input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this double? input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this float? input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this float input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this decimal input) => ToNumericSqlResult(input);
        public static string ToNumericSql(this decimal? input) => ToNumericSqlResult(input);

    }
}
