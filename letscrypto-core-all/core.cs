using System.Diagnostics;
using System.Text;

namespace core
{
    public class Core
    {
        public string generateKey(int count = 20)
        {
            string res = "";

            var currentProcess = Process.GetCurrentProcess();

            for (int i = 0; i < count; i++)
            {
                DateTime timenow = DateTime.Now;
                string dateTime = timenow.ToString("yyyy-MM-dd HH:mm:ss.fff");

                int randomNumber = new Random().Next(0, 1000);

                System.Security.Cryptography.SHA256 sha256 =
                    System.Security.Cryptography.SHA256.Create();
                byte[] hashBytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(dateTime + currentProcess + randomNumber + i)
                );

                res += System.Convert.ToBase64String(hashBytes);
            }

            return res;
        }

        public string formatKey(string key)
        {
            var res = "";

            res += "------------------- Key --------------------\n";
            for (int i = 0; i < key.Length; i += 44)
            {
                res += key.Substring(i, Math.Min(44, key.Length - i)) + "\n";
            }
            res += "------------------- End --------------------";

            return res;
        }

        public int randomOffset(int min = 3, int max = 20)
        {
            return new Random().Next(min, max);
        }

        public string encrypt(string text, string key, int offset)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] resultBytes = new byte[textBytes.Length];

            for (int i = 0; i < textBytes.Length; i++)
            {
                int keyIndex = (i + offset) % keyBytes.Length;
                resultBytes[i] = (byte)(textBytes[i] ^ keyBytes[keyIndex]);
            }

            return Convert.ToBase64String(resultBytes);
        }

        public string decrypt(string text, string key, int offset)
        {
            byte[] textBytes = Convert.FromBase64String(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] resultBytes = new byte[textBytes.Length];

            for (int i = 0; i < textBytes.Length; i++)
            {
                int keyIndex = (i + offset) % keyBytes.Length;
                resultBytes[i] = (byte)(textBytes[i] ^ keyBytes[keyIndex]);
            }
            return Encoding.UTF8.GetString(resultBytes);
        }
    }
}
