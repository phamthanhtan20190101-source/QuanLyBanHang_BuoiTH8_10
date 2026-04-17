using System.Text;
using System.Security.Cryptography;

namespace QuanLy_KyTucXa
{
    public static class MaHoaHelper
    {
        // Hàm băm mật khẩu bằng SHA-256
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}