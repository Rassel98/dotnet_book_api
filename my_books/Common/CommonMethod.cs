using System.Text;

namespace my_books.Common
{
    public static class CommonMethod
    {
        public static string key = "dkgvdjhvkd@fdg$53gfdjg";
        public static string ConvertToEncrypt(string password)
        {
            if (password == null) return "";
            password += key;
            var passBytes=Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passBytes);
        }
        public static string ConvertToDecrypt(string base64encode)
        {
            if (base64encode == null) return "";
            var passBytes = Convert.FromBase64String(base64encode);
            var result = Encoding.UTF8.GetString(passBytes);
            return result.Substring(0,result.Length-key.Length);
        }
    }
}
