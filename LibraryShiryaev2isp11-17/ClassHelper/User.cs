using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShiryaev2isp11_17.ClassHelper
{
    class User
    {
        public static EF.Customer Context { get; } = new EF.Customer();
    }
}
