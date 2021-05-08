﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_DA1.Exceptions
{
    public class UsernameAlreadyTakenException : ValidationException
    {
        public UsernameAlreadyTakenException()
        {
            this.message = "El usuario ingresado ya esta en uso.";
        }
    }
}