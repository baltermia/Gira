using System;
using System.Security.Cryptography;
using System.Text;

namespace Gira
{
    public class Login
    {
        public string Username { get; private set; }

        private string password;

        public Login(string username, string password)
        {
            Username = username;
            this.password = password;

            Save();
        }

        public bool MatchesPassword(string password, bool isEncrypted = false)
        {
            return (isEncrypted ? Encrypt(password) : password) == this.password;
        }

        public void Save()
        {
            Properties.Settings.Default.username = Username;
            Properties.Settings.Default.password = Decrypt(password);

            Properties.Settings.Default.Save();
        }

        public bool ChangePassword(string oldPw, string newPw)
        {
            if (!MatchesPassword(oldPw))
                return false;

            password = newPw;

            Save();

            return true;
        }

        public static Login GetSavedLogin()
        {
            string username = Properties.Settings.Default.username;
            string password = Properties.Settings.Default.password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return new Login(username, Encrypt(password));
        }

        public static string Encrypt(string data)
        {
            byte[] encrypted = ProtectedData.Protect(Encoding.Unicode.GetBytes(data), null, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string data)
        {
            byte[] decrypted = ProtectedData.Unprotect(Convert.FromBase64String(data), null, DataProtectionScope.CurrentUser);

            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
