using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNF_eDomain.Validation
{
    public class NFeExceptionValidation : Exception
    {
        public NFeExceptionValidation(string error) : base(error)
        { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new NFeExceptionValidation(error);

        }
    }
}
