﻿using Obligatorio1_DA1.Domain;
using BusinessLogic;
using Obligatorio1_DA1.Exceptions;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class CreateModifyCreditCard : Form
    {
        private PasswordManager _myPasswordManager;
        private CreditCard _myCreditCardToModify;

        public CreateModifyCreditCard(PasswordManager passwordManager)
        {
            InitializeComponent();
            _myPasswordManager = passwordManager;
            LoadComboBoxCategory();
        }

        public CreateModifyCreditCard(PasswordManager passwordManager, CreditCard creditCard)
        {
            InitializeComponent();
            _myPasswordManager = passwordManager;
            _myCreditCardToModify = creditCard;
            LoadComboBoxCategory();
            LoadFromCreditCard();
        }


        private void LoadComboBoxCategory()
        {
            cbCategory.DataSource = _myPasswordManager.GetCategoriesFromCurrentUser();
        }

        private void LoadFromCreditCard()
        {
            txtName.Text = _myCreditCardToModify.Name;
            txtType.Text = _myCreditCardToModify.Type;
            mtxtNumber.Text = _myCreditCardToModify.Number;
            mtxtSecureCode.Text = _myCreditCardToModify.SecureCode;
            mtxtExpirationDate.Text = _myCreditCardToModify.ExpirationDate;
            txtNotes.Text = _myCreditCardToModify.Notes;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (CategoryIsSelectedComboBox())
            {
                try
                {
                    if (_myCreditCardToModify == null)
                        CreateNewCreditCard();
                    else
                        ModifyCreditCard();

                    CloseForm();
                }
                catch (ValidationException exception)
                {
                    lblError.Text = exception.Message;
                }
            }
            else
                lblError.Text = "Debes seleccionar una categoría";
        }

        private void ModifyCreditCard()
        {
            ModifyCreditCardObjectFormFields();
            _myPasswordManager.ModifyCreditCardOnCurrentUser(_myCreditCardToModify);

        }

        private void CreateNewCreditCard()
        {
            CreditCard newCreditCard = CreateCreditCardObjectFormFields();
            _myPasswordManager.CreateCreditCard(newCreditCard);
        }

        private CreditCard CreateCreditCardObjectFormFields()
        {
            CreditCard newCreditCard = new CreditCard
            {
                User = _myPasswordManager.CurrentUser,
                Category = (Category)cbCategory.SelectedItem,
                Name = txtName.Text,
                Type = txtType.Text,
                Number = mtxtNumber.Text,
                SecureCode = mtxtSecureCode.Text,
                ExpirationDate = mtxtExpirationDate.Text,
                Notes = txtNotes.Text,
            };

            return newCreditCard;
        }

        private void ModifyCreditCardObjectFormFields()
        {
            _myCreditCardToModify.User = _myPasswordManager.CurrentUser;
            _myCreditCardToModify.Category = (Category)cbCategory.SelectedItem;
            _myCreditCardToModify.Name = txtName.Text;
            _myCreditCardToModify.Type = txtType.Text;
            _myCreditCardToModify.Number = mtxtNumber.Text;
            _myCreditCardToModify.SecureCode = mtxtSecureCode.Text;
            _myCreditCardToModify.ExpirationDate = mtxtExpirationDate.Text;
            _myCreditCardToModify.Notes = txtNotes.Text;
        }

        private void CloseForm()
        {
            this.Close();
        }

        private bool CategoryIsSelectedComboBox()
        {
            return cbCategory.SelectedItem != null;
        }
    }
}
