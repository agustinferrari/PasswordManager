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

namespace Interfaz
{
    public partial class MainWindow : Form
    {
        private PasswordManager _myPasswordManager;
        private UserControl _menu;
        public MainWindow()
        {
            InitializeComponent();
            _myPasswordManager = new PasswordManager();
        }

    }
}
