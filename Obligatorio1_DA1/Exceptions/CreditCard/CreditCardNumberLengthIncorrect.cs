﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_DA1.Exceptions
{

    public class CreditCardNumberLengthIncorrect : ValidationException
    {
        public CreditCardNumberLengthIncorrect()
        {
            this.message = "El número ingresado tiene que ser de 16 números.";
        }
    }
}