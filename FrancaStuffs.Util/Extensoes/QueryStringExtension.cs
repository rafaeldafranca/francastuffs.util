
using System.Collections.Specialized;

namespace FrancaStuffs.Util.Extensoes
{
    public static class QueryStringExtension
    {
        public static string GetSecureQueryString(string qs)
        {
            var newQs = string.Empty;
            if (!string.IsNullOrEmpty(qs))
            {
                newQs = System.Web.HttpUtility.UrlDecode(qs);
                if (System.Text.RegularExpressions.Regex.Match(newQs, "[<';>]").Success)
                    newQs = string.Empty;

            }
            return newQs;
        }

        public static string GetSecure(this NameValueCollection input, string name)
        {
            return GetSecureQueryString(input[name]);
        }

        public static string ToString(this NameValueCollection input, bool secure)
        {
            return secure ? GetSecureQueryString(input.ToString()) : input.ToString();
        }
    }
}
