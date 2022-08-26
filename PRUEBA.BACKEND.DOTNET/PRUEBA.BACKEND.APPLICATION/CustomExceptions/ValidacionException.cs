using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.CustomExceptions
{
    public class ValidacionException : Exception
    {
        public ValidacionException(string exception) : base(exception)
        {

        }
    }
}
