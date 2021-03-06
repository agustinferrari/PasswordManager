using Obligatorio1_DA1.Exceptions;
using Obligatorio1_DA1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Obligatorio1_DA1.Domain
{
    public class Password : Item
    {
        public const int MaxSiteLength = 25;
        public const int MinSiteLength = 3;
        public const int MaxUsernameLength = 25;
        public const int MinUsernameLength = 5;
        public const int MaxPasswordLength = 25;
        public const int MinPasswordLength = 5;

        private string _site;
        private string _username;
        private string _pass;
        private string _encryptedPass;
        private List<User> _sharedWith;
        private DateTime _lastModification;
        private IEncryption encryption;

        public Password()
        {
            LastModification = DateTime.Today;
            encryption = new AesEncryption();
        }

        public PasswordStrengthColor PasswordStrength { get; set; }

        public List<User> SharedWith
        {
            get
            {
                if (_sharedWith == null)
                {
                    _sharedWith = new List<User>();
                }
                return _sharedWith;
            }
        }

        public string Site
        {
            get => _site;
            set
            {
                ValidateSite(value);
                _site = value;
            }

        }

        public string Username
        {
            get => _username;
            set
            {
                ValidateUsername(value);
                _username = value;
            }
        }

        public string Pass
        {
            get
            {
                if (_pass == null)
                    _pass = DecryptPass(this.EncryptedPass);
                return _pass;
            }
            set
            {
                ValidatePass(value);
                _pass = value;
                this.PasswordStrength = PasswordStrengthCalculation.CalculatePasswordStrength(value);
                this.EncryptedPass = EncryptPass(value);
            }

        }
        public DateTime LastModification
        {
            get => _lastModification;
            set
            {
                _lastModification = value;
            }
        }

        public string EncryptedPass
        {
            get => _encryptedPass;
            set
            {
                _encryptedPass = value;
            }
        }

        private string DecryptPass(string encryptedPass)
        {
            string decyptedPassword = encryption.Decrypt(encryptedPass, this.User.DecryptionKey);
            return decyptedPassword;
        }

        private string EncryptPass(string pass)
        {
            string encryptedPassword = encryption.Encrypt(this.Pass, this.User.DecryptionKey);
            return encryptedPassword;
        }

        private void ValidateSite(string siteToValidate)
        {
            if (!Validator.MinLengthOfString(siteToValidate, Password.MinSiteLength))
                throw new PasswordSiteTooShortException();
            if (!Validator.MaxLengthOfString(siteToValidate, Password.MaxSiteLength))
                throw new PasswordSiteTooLongException();
        }

        private void ValidateUsername(string usernameToValidate)
        {
            if (!Validator.MinLengthOfString(usernameToValidate, Password.MinUsernameLength))
                throw new PasswordUsernameTooShortException();
            if (!Validator.MaxLengthOfString(usernameToValidate, Password.MaxUsernameLength))
                throw new PasswordUsernameTooLongException();
        }

        public void ValidatePass(string passToValidate)
        {
            if (!Validator.MinLengthOfString(passToValidate, Password.MinPasswordLength))
                throw new PasswordTooShortException();
            if (!Validator.MaxLengthOfString(passToValidate, Password.MaxPasswordLength))
                throw new PasswordTooLongException();
        }

        public void ShareWithUser(User userShareWith)
        {
            if (!this.SharedWith.Contains(userShareWith))
                this.SharedWith.Add(userShareWith);
        }

        public void UnShareWithUser(User userRemoveShare)
        {
            this.SharedWith.Remove(userRemoveShare);
        }


        public override bool Equals(object obj)
        {
            Password passwordToCompare;
            try
            {
                passwordToCompare = (Password)obj;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
            return CheckEqualityOfPassword(passwordToCompare, this);
        }

        private bool CheckEqualityOfPassword(Password passwordToCompare, Password password)
        {
            bool userObjectAreEqual = passwordToCompare.User.Equals(password.User);
            bool userNameAreEqual = passwordToCompare.Username.ToLower() == password.Username.ToLower();
            bool siteAreEqual = passwordToCompare.Site.ToLower() == password.Site.ToLower();

            return (userNameAreEqual && siteAreEqual && userObjectAreEqual);
        }


    }


}
