using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebApp.DAL.Service
{
    public class DataSeviceException : Exception
    {
        public DataSeviceException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
