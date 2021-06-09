﻿
namespace Obligatorio1_DA1.Exceptions
{
    public class PasswordSiteTooShortException : ValidationException
    {
        public PasswordSiteTooShortException()
        {
            this.messageToDisplay = "El sitio es demasiado corto (min. 3 caracteres). ";
        }
    }
}
