using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PruebaMVC.App_Start
{
    public class Util
    {
        #region "INSTANCIA"
        private static Util daoutil = null;
        public Util() { }
        public static Util GetInstance()
        {
            if (daoutil == null)
            {
                daoutil = new Util();
            }
            return daoutil;
        }
        #endregion

        public String generarSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[15];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public String generarMD5(String password)
        {
            using (MD5 hash = MD5.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int n = 0; n <= bytes.Length - 1; n++)
                {
                    sb.Append(bytes[n].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}