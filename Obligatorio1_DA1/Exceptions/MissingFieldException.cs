﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_DA1.Exceptions
{
    public class MissingFieldException : ValidationException
    {
        public MissingFieldException(string fieldName)
        {
            this.message = String.Format("El campo {0} no puede ser vacio. ", fieldName);
        }
    }
}