using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Cesar_xamarin.Models
{
    public class Response
    {
        public bool IsSuccess
        {
            get;
            set;            
        }

        public string Message
        {
            get;
            set;
        }
        public object Result
        {
            get;
            set;
        }
    }
}
