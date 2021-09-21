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


    public class StartPointException : ApplicationException
    {
        public StartPointException()
        {
        }

        public StartPointException(string message) : base(message)
        {
        }
    }

    public class EndGameException : ApplicationException
    {
        public EndGameException()
        {
        }

        public EndGameException(string message) : base(message)
        {
        }
    }
}
