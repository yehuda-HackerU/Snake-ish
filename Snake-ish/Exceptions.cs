using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{

    public class PositionException : ApplicationException
    {
        public PositionException()
        {
        }

        public PositionException(string message) : base(message)
        {
        }
    }
}
