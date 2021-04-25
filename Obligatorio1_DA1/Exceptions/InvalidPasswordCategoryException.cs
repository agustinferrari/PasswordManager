﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_DA1.Exceptions
{

    public class InvalidPasswordCategoryException : ValidationException
    {
        public InvalidPasswordCategoryException()
        {
            this.message = "El usuario no tiene la categoria seleccionada para la contraseña.";
        }
    }
}
