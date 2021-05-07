﻿using Obligatorio1_DA1.Domain;
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
    public partial class PasswordList : UserControl
    {
        private PasswordManager _myPasswordManager;
        private Password _selectedPassword;
        public PasswordList(PasswordManager pPasswordManager)
        {
            InitializeComponent();
            _myPasswordManager = pPasswordManager;
            LoadTblPassword();
        }

        private void LoadTblPassword()
        {
            List<Password> passwords = _myPasswordManager.GetPasswords();
            tblPassword.DataSource = null;
            tblPassword.Rows.Clear();
            tblPassword.DataSource = passwords;
            FormatPasswordListOnTable();
        }

        private void FormatPasswordListOnTable()
        {
            foreach (DataGridViewColumn column in tblPassword.Columns)
            {
                switch (column.Name)
                {
                    case "Site":
                        column.HeaderText = "Sitio";
                        break;
                    case "Username":
                        column.HeaderText = "Nombre de usuario";
                        break;
                    case "Category":
                        column.HeaderText = "Categoria";
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateSelectedPassword();
            if (_selectedPassword != null)
            {
                _myPasswordManager.DeletePassword(_selectedPassword);
                this.lblMessage.Text = "Contraseña eliminada exitosamente.";
                LoadTblPassword();
            }
            else
            {
                this.lblMessage.Text = "Debe seleccionar la contraseña que desea eliminar.";
            }
        }

        private void UpdateSelectedPassword()
        {
            if (tblPassword.SelectedCells.Count > 0)
            {
                try
                {
                    _selectedPassword = (Password)tblPassword.SelectedCells[0].OwningRow.DataBoundItem;
                }
                catch (FormatException exception)
                {
                    this.lblMessage.Text = "Error al seleccionar la contraseña.";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form createPassword = new CreatePassword(_myPasswordManager);
            createPassword.FormClosing += new FormClosingEventHandler(RefreshForm);
            createPassword.ShowDialog();
        }

        private void RefreshForm(object sender, FormClosingEventArgs e)
        {
            LoadTblPassword();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            UpdateSelectedPassword();
            if (_selectedPassword != null)
            {
                Form createCreditCard = new CreatePassword(_myPasswordManager, _selectedPassword);
                createCreditCard.FormClosing += new FormClosingEventHandler(RefreshForm);
                createCreditCard.ShowDialog();
            }
            else
            {
                this.lblMessage.Text = "Debe seleccionar la contraseña que desea eliminar.";
            }
        }
    }
}
