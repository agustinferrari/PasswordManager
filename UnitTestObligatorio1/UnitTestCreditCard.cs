﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_DA1;
using Obligatorio1_DA1.Domain;
using System;
using Obligatorio1_DA1.Exceptions;

namespace UnitTestObligatorio1
{
    [TestClass]
    public class UnitTestCreditCard
    {
        private CreditCard _card;
        private PasswordManager _passwordManager;
        private User _user;
        private Category _category;


        [TestInitialize]
        public void TestInitialize()
        {
            try
            {
                _passwordManager = new PasswordManager();
                _user = new User()
                {
                    Name = "Gonzalo",
                    Pass = "HolaSoyGonzalo123"
                };
                _category = new Category()
                {
                    Name = "Personal"
                };
                _user.Categories.Add(_category);
                this._card = new CreditCard
                {
                    User = _user,
                    Category = _category,
                    Name = "Visa Gold",
                    Type = "Visa",
                    Number = "2354678713003498",
                    SecureCode = "189",
                    ExpirationDate = "10/21",
                    Notes = "Límite 400k UYU"
                };
            }
            catch (Exception exception)
            {
                Assert.Fail("Expected no exception, but got: " + exception.Message);
            }
        }


        [TestMethod]
        public void CreateValidCreditCard()
        {
            _user = new User()
            {
                Name = "Mauricio",
                Pass = "HolaSoyGonzalo123"
            };
            _category = new Category()
            {
                Name = "Personal"
            };
            _user.Categories.Add(_category);
            CreditCard creditCard = new CreditCard
            {
                User = _user,
                Category = _category,
                Name = "Visa Gold",
                Type = "Visa",
                Number = "7754678713003477",
                SecureCode = "189",
                ExpirationDate = "10/21",
                Notes = "Límite 400k UYU"
            };

            _passwordManager.CreateCreditCard(creditCard);
        }


        [TestMethod]
        public void GetCategoryCard()
        {
            Assert.AreEqual<string>(this._card.Category.Name, "Personal");
        }

        [TestMethod]
        public void GetExpirationDateCard()
        {
            Assert.AreEqual<string>(this._card.ExpirationDate, "10/21");
        }

        [TestMethod]
        public void GetNameCard()
        {
            Assert.AreEqual<string>(this._card.Name, "Visa Gold");
        }

        [TestMethod]
        public void GetNotesCard()
        {
            Assert.AreEqual<string>(this._card.Notes, "Límite 400k UYU");
        }

        [TestMethod]
        public void GetSecureCodeCard()
        {
            Assert.AreEqual<string>(this._card.SecureCode, "189");
        }

        [TestMethod]
        public void GetTypeCard()
        {
            Assert.AreEqual<string>(this._card.Type, "Visa");
        }

        [TestMethod]
        [ExpectedException(typeof(NumberCardLengthIncorrect))]
        public void CreateInvalidCardNumberTooShort()
        {
            this._card.Number = "235467871";
        }

        [TestMethod]
        [ExpectedException(typeof(NumberCardInvalidCharacters))]
        public void CreateInvalidCardNumberWithWrongCharacters()
        {
            this._card.Number = "2s46f871/00r3498";
        }

        [TestMethod]
        [ExpectedException(typeof(NumberCardLengthIncorrect))]
        public void CreateInvalidCardNumberTooLong()
        {
            this._card.Number = "2354 6787 1300 3498 134/00r3498";
        }



        [TestMethod]
        public void CreateNewCardWithoutNotes()
        {
            try
            {
                CreditCard newCard = new CreditCard
                {
                    User = _user,
                    Category = _category,
                    Name = "Visa Black",
                    Type = "Visa",
                    Number = "2354678713003498",
                    SecureCode = "189",
                    ExpirationDate = "10/21"
                };
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        [TestMethod]
        public void CreateCardShowingOnlyLast4Digits()
        {
            string cardNumberShowingOnlyLast4Digits = this._card.ShowOnly4LastDigits();
            Assert.AreEqual<string>("XXXX XXXX XXXX 3498", cardNumberShowingOnlyLast4Digits);
        }


    }


}

