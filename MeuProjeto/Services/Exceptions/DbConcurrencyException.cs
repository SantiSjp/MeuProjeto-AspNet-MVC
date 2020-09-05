using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {

        public DbConcurrencyException(String message) : base()
        {
        }

    }
}
