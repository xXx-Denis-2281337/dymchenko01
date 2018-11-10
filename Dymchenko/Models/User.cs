using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Dymchenko.Tools;

namespace Dymchenko.Models
{
    [Serializable]
    public class User
    {
        #region Fields
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;
        private string _password;
        private string _lastLoginDate;
        #endregion

        #region Properties
        [Key]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string LastLoginDate
        {
            get
            {
                return _lastLoginDate;
            }
            set
            {
                _lastLoginDate = value;
            }
        }
        #endregion

        #region Constructors
        public User()  { }

        public User(string firstName, string lastName, string email, string login, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            _lastLoginDate = DateTime.Now.ToString();
            SetPassword(password);
        }
        #endregion

        #region Public Methods
        internal bool CheckPassword(string password)
        {
            try
            {
                return _password == Encrypting.EncryptString(password);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
        #endregion

        #region Private Methods
        private void SetPassword(string password)
        {
            try
            {
                _password = Encrypting.EncryptString(password);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        #endregion
    }
}