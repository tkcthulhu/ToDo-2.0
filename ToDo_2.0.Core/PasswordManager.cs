using System;
namespace ToDo_2._0
{
    public class PasswordManager : IDisplayable, IResettable
    {
        private string Password
        { get; set; }

        public bool Hidden
        { get; private set; }

        public PasswordManager(string password, bool hidden)
        {
            Password = password;
            Hidden = hidden;
        }

        public bool PasswordCheck(string password)
        {
            if (password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Display()
        {
            if (Hidden)
            {
                int length = Password.Length;

                string[] hashed = new string[length];

                int i = 0;

                foreach (string x in hashed)
                {
                    hashed[i] = "*";
                    i++;
                }

                Console.WriteLine(string.Join("", hashed));
                return string.Join("", hashed);
            }
            else
            {
                Console.WriteLine(Password);
                return Password;
            }
        }

        public void Reset()
        {
            Password = "";
            Hidden = false;
        }

        public void ChangePassword(string newPassword, bool hidden)
        {
            Password = newPassword;
            Hidden = hidden;
            Console.WriteLine("Your password has been successfully changed!");
        }

    }
}

