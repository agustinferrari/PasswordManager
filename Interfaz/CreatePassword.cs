﻿using Obligatorio1_DA1.Domain;
using Obligatorio1_DA1.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class CreatePassword : Form
    {
        private PasswordManager _myPasswordManager;
        public CreatePassword(PasswordManager pPasswordManager)
        {
            InitializeComponent();
            _myPasswordManager = pPasswordManager;
            LoadComboBoxCategory();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem != null)
            {
                try
                {
                    Password newPassword = new Password
                    {
                        User = _myPasswordManager.CurrentUser,
                        Category = (Category)cbCategory.SelectedItem,
                        Site = txtSite.Text,
                        Username = txtUser.Text,
                        Pass = txtPassword.Text,
                        Notes = txtNotes.Text,
                    };
                    _myPasswordManager.CreatePassword(newPassword);
                    CloseForm();

                }
                catch (ValidationException exception)
                {
                    lblError.Text = exception.Message;
                }
            }
            else
                lblError.Text = "Debe seleccionar una categoría";
        }

        private void LoadComboBoxCategory()
        {
            cbCategory.DataSource = _myPasswordManager.GetCategoriesFromCurrentUser();
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int passwordLength = decimal.ToInt32(nudLength.Value);
            bool hasUppercase = cbUppercase.Checked;
            bool hasLowercase = cbLowercase.Checked;
            bool hasDigit = cbDigit.Checked;
            bool hasSymbol = cbSymbol.Checked;
            try
            {
                txtPassword.Text = Password.GenerateRandomPassword(passwordLength, hasUppercase, hasLowercase, hasDigit, hasSymbol);
            }
            catch (ValidationException exception)
            {
                lblMessage.Text = exception.Message;
            }
        }
    }
}