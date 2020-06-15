
using System;
using System.Security.Cryptography;
using System.Text;

namespace FrancaStuffs.Util.Seguranca
{
    public class Cripto
    {
        private static string _chave;

        /// <summary>
        /// Atribui caracteres aleatórros para criação da chave de criptografia.
        /// </summary>
        public static string SetChave
        {
            set
            {
                _chave = value;
            }
        }

        /// <summary>
        /// Criptografa um texto
        /// </summary>
        /// <param name="valor">texto a ser criptogrado</param>
        /// <returns>Texto criptografado</returns>
        public static string Criptografar(string valor)
        {
            try
            {
                return Criptografar(valor, _chave);
            }
            catch (Exception ex)
            {
                return string.Format("String errada.{0}", ex.Message);
            }

        }

        /// <summary>
        /// Descriptografa um texto
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Texto descriptografado</returns>
        public static string Descriptografar(string valor)
        {
            try
            {
                return Descriptografar(valor, _chave);
            }
            catch (Exception ex)
            {
                return string.Format("String errada.{0}", ex.Message);
            }
        }

        /// <summary>
        /// Criptogra um texto 
        /// </summary>
        /// <param name="valor">texto a ser criptogrado</param>
        /// <param name="chave">chave para se basear a criptografia</param>
        /// <returns>Texto criptografado</returns>
        public static string Criptografar(string valor, string chave)
        {
            try
            {
                var objcriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = chave;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objcriptografaSenha.Key = byteHash;
                objcriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = ASCIIEncoding.ASCII.GetBytes(valor);
                return Convert.ToBase64String(objcriptografaSenha.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }

        /// <summary>
        /// Descriptogra um texto baseado em uma chave a ser informada
        /// </summary>
        /// <param name="valor">texto a ser descriptogrado</param>
        /// <param name="chave">chave para se basear a criptografia</param>
        /// <returns>Texto descriptografado</returns>
        public static string Descriptografar(string valor, string chave)
        {
            try
            {
                var objdescriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = chave;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objdescriptografaSenha.Key = byteHash;
                objdescriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = Convert.FromBase64String(valor);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objdescriptografaSenha.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objdescriptografaSenha = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }
    }
}
