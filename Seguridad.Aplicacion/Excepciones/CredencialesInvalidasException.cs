using System;

namespace Seguridad.Aplicacion.Excepciones
{
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException() : base("El usuario o la contraseña son incorrectos.")
        {
        }
    }
}
