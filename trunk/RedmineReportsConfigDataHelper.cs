using System;
using System.Text;

namespace combit.RedmineReports
{
    public static class RedmineReportsConfigDataHelper
    {
        private static bool ConnectionStringEmpty(string connString)
        {
            return connString.ToLower().Contains("server=IP");
        }

        public static bool ConnectionStringEncrypted(string connString)
        {
            return !connString.ToLower().Contains("server") & !ConnectionStringEmpty(connString);
        }

        public static bool ConnectionStringIsPlain(string connString)
        {
            return (connString.ToLower().Contains("server") & !connString.ToLower().Contains("server=ip"));
        }

        public static string EncryptData(string data)
        {
            for (int i = 0; i < 10; i++)
            {
                data = Convert.ToBase64String(Encoding.ASCII.GetBytes(data));
            }

            return data;
        }

        public static string DecryptData(string data)
        {
            string decryptedString;
            for (int i = 0; i < 10; i++)
            {
                byte[] convertBytes = Convert.FromBase64String(data);
                decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(convertBytes);
                data = decryptedString;
            }

            return data;
        }
    }
}
