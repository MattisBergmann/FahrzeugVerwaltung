using System.Security.Cryptography;
using System.Windows.Input;
using System.Linq;
using Microsoft.Toolkit.Mvvm.Input;

namespace FahrzeugVerwaltung.UI
{
    public class LoginViewModel
    {
        private readonly IDialogResultable window;
        private readonly User user;

        public LoginViewModel(User user, IDialogResultable window)
        {
            this.window = window;
            this.user = user;
            LoginCommand = new RelayCommand(Login);
        }

        /// <summary>
        /// Perform Login when Login Button is clicked
        /// </summary>
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

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="user"></param>
        private void Create(User user)
        {
            user.Name = Username;
            user.Salt = RandomNumberGenerator.GetBytes(16);
            user.Hash = GetHash(user.Salt, 32);
            user.Keep = Keep;
            user.Created = true;
        }

        /// <summary>
        /// Verifies users credentials and rehashes the users password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gives a PBKDF2 hashed password
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="hashlen"></param>
        /// <returns></returns>
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
