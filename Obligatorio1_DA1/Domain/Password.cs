using Obligatorio1_DA1.Exceptions;
using Obligatorio1_DA1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MissingFieldException = Obligatorio1_DA1.Exceptions.MissingFieldException;

namespace Obligatorio1_DA1.Domain
{
    public class Password
    {
        private string category;
        private string site;
        private string username;
        private string pass;
        private string notes;
        public PasswordStrengthColor PasswordStrength { get; private set; }

        public string Category
        {
            get => category;
            set
            {
                ValidateCategory(value);
                category = value;
            }

        }

        private void ValidateCategory(string value)
        {
            if (!Validator.MinLengthOfString(value, 3))
                throw new CategoryTooShortException();
            if (!Validator.MaxLengthOfString(value, 15))
                throw new CategoryTooLongException();
        }
        public string Site
        {
            get => site;
            set
            {
                ValidateSite(value);
                site = value;
            }

        }

        private void ValidateSite(string value)
        {
            if (!Validator.MinLengthOfString(value, 3))
                throw new SiteTooShortException();
            if (!Validator.MaxLengthOfString(value, 25))
                throw new SiteTooLongException();
        }
        public string Username
        {
            get => username;
            set
            {
                ValidateUsername(value);
                username = value;
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
                throw new MissingFieldException("nombre de usuario");
            if (!Validator.MinLengthOfString(username, 5))
                throw new UsernameTooShortException();
            if (!Validator.MaxLengthOfString(username, 25))
                throw new UsernameTooLongException();

        }

        public string Pass
        {
            get => pass;
            set
            {
                ValidatePass(value);
                pass = value;
                this.PasswordStrength = CalculatePasswordStrength(value);
            }

        }

        private void ValidatePass(string value)
        {
            if (!Validator.MinLengthOfString(value, 5))
                throw new PasswordTooShortException();
            if (!Validator.MaxLengthOfString(value, 25))
                throw new PasswordTooLongException();
        }

        public string Notes
        {
            get => notes;
            set
            {
                ValidateNotes(value);
                notes = value;
            }

        }

        private void ValidateNotes(string value)
        {
            if (value == null)
                return;
            if (!Validator.MaxLengthOfString(value, 250))
                throw new NotesTooLongException();
        }

        public static string GenerateRandomPassword(int length, Boolean uppercase, Boolean lowercase, Boolean digits, Boolean specialDigits)
        {
            if (length < 5 || length > 25)
                throw new ArgumentException();
            if (!(uppercase || lowercase || digits || specialDigits))
                throw new ArgumentException();

            const string uppercaseSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseSet = "abcdefghijklmnopqrstuvwxyz";
            const string digitsSet = "0123456789";
            const string specialDigitsSet = " !\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";

            List<char> validChars = new List<char>();
            string pass = "";
            Random random = new Random();

            if (uppercase)
                AddRandomCharFromSubSet(ref pass, uppercaseSet, random, validChars);

            if (lowercase)
                AddRandomCharFromSubSet(ref pass, lowercaseSet, random, validChars);

            if (digits)
                AddRandomCharFromSubSet(ref pass, digitsSet, random, validChars);

            if (specialDigits)
                AddRandomCharFromSubSet(ref pass, specialDigitsSet, random, validChars);


            while (pass.Length < length)
                AddRandomChar(ref pass, validChars, random);

            return pass;
        }
        private static void AddRandomCharFromSubSet(ref string word, string subSet, Random random, List<char> mainSet)
        {
            List<char> newValidChars = subSet.ToList();
            AddRandomChar(ref word, newValidChars, random);
            mainSet.AddRange(newValidChars);
        }
        private static void AddRandomChar(ref string word, List<char> validChars, Random random)
        {
            char randomChar = validChars[random.Next(0, validChars.Count - 1)];
            int index = random.Next(0, word.Length);
            word = word.Insert(index, randomChar + "");
        }

        private PasswordStrengthColor CalculatePasswordStrength(string pass)
        {
            if (IsRedStrength(pass))
                return PasswordStrengthColor.Red;
            if (IsOrangeStrength(pass))
                return PasswordStrengthColor.Orange;
            return CalculateLargePasswordStrength(pass);
        }

        private PasswordStrengthColor CalculateLargePasswordStrength(string pass)
        {
            bool hasUpperCase, hasLowerCase, hasNumber, hasSymbol;
            hasUpperCase = hasLowerCase = hasNumber = hasSymbol = false;
            int typeCount = 0;
            for (int i = 0; i < pass.Length && typeCount < 4; i++)
            {
                if (IsLowerCase(pass.ElementAt(i)) && !hasLowerCase)
                {
                    typeCount++;
                    hasLowerCase = true;
                }
                else if (IsUpperCase(pass.ElementAt(i)) && !hasUpperCase)
                {
                    typeCount++;
                    hasUpperCase = true;
                }
                else if (IsNumber(pass.ElementAt(i)) && !hasNumber)
                {
                    typeCount++;
                    hasNumber = true;
                }
                else if (IsSymbol(pass.ElementAt(i)) && !hasSymbol)
                {
                    typeCount++;
                    hasSymbol = true;
                }
            }
            if (hasLowerCase && hasUpperCase && typeCount == 2)
                return PasswordStrengthColor.LightGreen;
            return CheckResultDependingOnTypeCount(typeCount);
        }

        private PasswordStrengthColor CheckResultDependingOnTypeCount(int typeCount)
        {
            switch (typeCount)
            {
                case 3:
                    return PasswordStrengthColor.LightGreen;
                case 4:
                    return PasswordStrengthColor.DarkGreen;
                default:
                    return PasswordStrengthColor.Yellow;
            }
        }

        private bool IsRedStrength(string pass)
        {
            Regex regex = new Regex(@"^.{1,8}$", RegexOptions.Compiled);
            return regex.IsMatch(pass);
        }

        private bool IsOrangeStrength(string pass)
        {
            Regex regex = new Regex(@"^.{8,14}$", RegexOptions.Compiled);
            return regex.IsMatch(pass);
        }

        private bool IsSymbol(char character)
        {
            Regex regex = new Regex(@"^[ -/:-@[-`{-~]+$", RegexOptions.Compiled);
            return regex.IsMatch(character.ToString());
        }
        private bool IsNumber(char character)
        {
            Regex regex = new Regex(@"^[0-9]+$", RegexOptions.Compiled);
            return regex.IsMatch(character.ToString());
        }

        private bool IsUpperCase(char character)
        {
            Regex regex = new Regex(@"^[A-Z]+$", RegexOptions.Compiled);
            return regex.IsMatch(character.ToString());
        }

        private bool IsLowerCase(char character)
        {
            Regex regex = new Regex(@"^[a-z]+$", RegexOptions.Compiled);
            return regex.IsMatch(character.ToString());
        }


    }


}