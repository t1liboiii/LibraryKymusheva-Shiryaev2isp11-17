using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShiryaev2isp11_17.ClassHelper
{
    class Book
    {
        public static EF.Book Context { get; } = new EF.Book();
    }
}
