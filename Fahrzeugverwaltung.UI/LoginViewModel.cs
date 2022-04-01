using System.Security.Cryptography;
using System.Windows.Input;
using System.Linq;
using Microsoft.Toolkit.Mvvm.Input;

namespace FahrzeugVerwaltung.UI
{
    public class LoginViewModel
    {
        private readonly IResultable window;
        private readonly User user;

        public LoginViewModel(User user, IResultable window)
        {
            this.window = window;
            this.user = user;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            if (Username != null && Password != null)
            {
                // Create new user
                if (!user.Created)
                {
                    Create(user);
                    window.DialogResult = true;
                }
                else
                {
                    window.DialogResult = Username == user.Name && VerifyAndReHash(user);
                    user.Keep = Keep;
                }
            }
            else
            {
                window.DialogResult = false;
            }
            window.Close();
        }

        private void Create(User user)
        {
            user.Name = Username;
            user.Salt = RandomNumberGenerator.GetBytes(16);
            user.Hash = GetHash(user.Salt, 32);
            user.Keep = Keep;
            user.Created = true;
        }

        private bool VerifyAndReHash(User user)
        {
            if (!user.Created)
            {
                return false;
            }
            int slen = user.Salt?.Length ?? 16;
            int hlen = user.Hash?.Length ?? 32;
            byte[] salt = user.Salt ?? new byte[slen];
            byte[] hash = GetHash(salt, hlen);
            if (user.Hash == null || !user.Hash.SequenceEqual(hash))
            {
                return false;
            }
            salt = RandomNumberGenerator.GetBytes(slen);
            user.Salt = salt;
            user.Hash = GetHash(salt, hlen);
            return true;
        }

        private byte[] GetHash(byte[] salt, int hashlen)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 100000);
            return pbkdf2.GetBytes(hashlen);
        }

        public string Username { private get; set; }
        public string Password { private get; set; }
        public bool Keep { get; set; }
        public ICommand LoginCommand { get; set; }
    }
}
