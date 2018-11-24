using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Runtime.Serialization;
using Dymchenko.Tools;

namespace Dymchenko.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {
        #region Fields
        [DataMember]
        private Guid _id;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _email;
        [DataMember]
        private string _login;
        [DataMember]
        private string _password;
        [DataMember]
        private string _lastLoginDate;
        [DataMember]
        private List<Folder> _folders;
        #endregion

        #region Properties
        public Guid Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }
        private string FirstName
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
        private string LastName
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
        private string Email
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
        private string Password
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
        private string LastLoginDate
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

        private List<Folder> Folders
        {
            get
            {
                if (_folders != null)
                {
                    return _folders;
                }
                else
                {
                    _folders = new List<Folder>();
                    return _folders;
                }
            }

            set
            {
                _folders = value;
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
        public bool CheckPassword(string password)
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

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(k => k.Id);

                Property(p => p.Id)
                    .HasColumnName("Id")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsRequired();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();
                HasMany(s => s.Folders)
                    .WithRequired(w => w.User)
                    .HasForeignKey(h => h.UserId)
                    .WillCascadeOnDelete(true);
            }
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