using System.Security.Cryptography;
using System.Text;

namespace BaseBackEnd.Infrastructure.Util.Cryptography
{
    public static class GenerateMD5
    {
        public static string Get(this string input)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
